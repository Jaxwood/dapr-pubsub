# Dapr PubSub

An example of two microservices communicating using pubsub with Redis and Dapr.

## Install

Install Dapr in the cluster

```sh
kind create cluster
dapr init -k
```

Install Redis in the cluster

```sh
kubectl create ns app
helm repo add bitnami https://charts.bitnami.com/bitnami
helm install redis bitnami/redis -n app
```

Install custom manifests

```sh
kubectl apply -f manifests -n app
```

## Run

Portforward the publisher service (port 8080) and curl

```sh
kubectl port-forward -n app pod/publisher-7f5996b496-m6scs  8080:8080
curl localhost:8080/saysomething/hello
```

Observe the message is being logged in the consumer microservice
