
#!/bin/bash
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

# Config Logstash
wget https://artifacts.elastic.co/downloads/logstash/logstash-7.16.3-linux-x86_64.tar.gz
tar -xzf logstash-7.16.3-linux-x86_64.tar.gz

wget https://download.microsoft.com/download/b/c/5/bc5e407f-97ff-42ea-959d-12f2391063d7/sqljdbc_9.4.1.0_ptb.tar.gz
tar -xzf sqljdbc_9.4.1.0_ptb.tar.gz

mv sqljdbc_9.4/ptb/*.jar  logstash-7.16.3/logstash-core/lib/jars/
mkdir -p logstash-7.16.3/queries
logstash-7.16.3/bin/logstash --version



