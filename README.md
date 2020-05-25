# POC-Kafka .Net Core
![enter image description here](https://img.shields.io/badge/.Net%20Core-3.1-blue.svg) ![enter image description here](https://img.shields.io/badge/docker-19.03.8-lightblue.svg)


## Architecture
![The file explorer is accessible using the button in left corner of the navigation bar. You can create a new file by clicking the **New file** button in the file explorer. You can also create folders by clicking the **New folder** button.](https://i.ibb.co/Fqz3SGN/Sch-ma-POC-Kafka.jpg)

## Workflow

 - Product API expose Delete Product Endpoint, when called, the kafka
   producer send message on delete-product topic to notify consumer.
 - Recipe API consumer read the message and delete all recipes with the
   deleted product.
 - Both Consumer group are here to show that a message is read one and
   only one time by consumer group
 - Product and Recipe Get Endpoints are here to check data base state
   after deletion.
 - A five seconds sleep are here to show the asynchronous principle of
   Kafka.
   

## Other Sources

 - [https://github.com/confluentinc/confluent-kafka-dotnet](https://github.com/confluentinc/confluent-kafka-dotnet)
 - [https://hub.docker.com/r/confluentinc/cp-kafka/](https://hub.docker.com/r/confluentinc/cp-kafka/)
 - [https://hub.docker.com/r/confluentinc/cp-zookeeper](https://hub.docker.com/r/confluentinc/cp-zookeeper)
 
