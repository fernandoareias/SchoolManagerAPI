mkdir -p elastic_cluster
cd elastic_cluster
mkdir -p logs

wget https://raw.githubusercontent.com/fernandoareias/SchoolManagerAPI/main/docker/docker-compose.yaml


# Cria a network que ira conectar os containers
docker network create elastic

sudo mkdir -p /etc/systemd/system/docker.service.d
echo -e "[Service]\nLimitMEMLOCK=infinity" | sudo tee /etc/systemd/system/docker.service.d/memlock.conf
sudo systemctl daemon-reload
sudo systemctl restart docker

# Aumento o numero maximo de memoria que o processo pode mapear
echo vm.max_map_count=262144 | sudo tee /etc/sysctl.d/99-max_map_count.conf
echo vm.max_map_count=262144 | sudo tee /etc/sysctl.d/99-max_map_count.conf
sudo sysctl --system >> logs/system_logs & 

# Levanta os containers

docker-compose up >> logs/docker_logs &

# Caso necessário 
# https://www.elastic.co/guide/en/cloud-enterprise/2.1/ece-configure-hosts-rhel-centos.html
