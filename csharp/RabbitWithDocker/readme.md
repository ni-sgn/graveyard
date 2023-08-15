# I have just followed the instructions from the official rabbitmq website, Ergo
# Everything is Default
    https://hub.docker.com/_/rabbitmq

# I had to run different image, because in the given example, image that is used
# does not have a management plugin integrated. 
    docker run -d --hostname my-rabbit --name some-rabbit rabbitmq:3-management
# This image is same image(rabbitmq:3-latest) but it additionally has a
# management plugin. To expose(publish) ports, so that I could access it from
# outside, I had to add -p 15672 to the command, ergo I could access rabbit's 
# management as localhost insead of <container-ip>:15672, so the final result:
    docker run -d --hostname rabbit-host --name rabbit1 -p 15672:15672
    rabbitmq:3-management 

# vs code could not connect to the docker, ergo could not see the images and
# containers, that was because my user(which lauches the vscode), was not added
# to the docker group. Ergo, I had to add the user to the group and give
# permissions 
    sudo usermod -aG docker disco
    sudo chmod 666 /var/run/docker.sock
