# Cria as pastas necessárias, caso elas não existam
mkdir -p elastic_cluster
cd elastic_cluster
mkdir -p logs

# Realiza o download do docker-compose com o cluster configurado, 3 nós do elasticsearch e 1 kibana
wget https://raw.githubusercontent.com/fernandoareias/SchoolManagerAPI/main/docker/docker-compose.yaml


# Cria a network que ira conectar os containers
docker network create elastic

# Evita que a JVM use memória SWAP no lugar da RAM 
sudo mkdir -p /etc/systemd/system/docker.service.d
echo -e "[Service]\nLimitMEMLOCK=infinity" | sudo tee /etc/systemd/system/docker.service.d/memlock.conf
sudo systemctl daemon-reload
sudo systemctl restart docker

# Aumenta o número máximo de memória que o processo pode mapear
echo vm.max_map_count=262144 | sudo tee /etc/sysctl.d/99-max_map_count.conf
echo vm.max_map_count=262144 | sudo tee /etc/sysctl.d/99-max_map_count.conf
sudo sysctl --system >> logs/system_logs & 

# Levanta os containers

docker-compose up >> logs/docker_logs &

# Caso necessário 
# https://www.elastic.co/guide/en/cloud-enterprise/2.1/ece-configure-hosts-rhel-centos.html
