# Dapr pub/sub (HTTP Client)

Este exemplo demontra como realizar a produçao e o consumo de eventos através do Dapr sem a necessidade do uso de nenhuma dependência ou biblioteca adicional.

O Dapr possui o conceito de build blocks apis (que plugam capacidades ao nosso app) no nosso caso faremos o uso do pubsub building block, onde conseguimos implementar de uma maneira completamente transparente e agnóstica nossa mssageria apenas utlizidando a intermediação via http da produção e consumo das mensagens.


Visite [dapr.io](https://docs.dapr.io/developing-applications/building-blocks/pubsub/) para mais informações sobre o Dapr e Pub-Sub.

> **Produzindo mensagens:** order-producer

Console que realiza a produçao das mensagens

> **Consumindo mensagens:** order-consumer 

Web aplication que se registra(subscreve no tópico definindo a rota) e recebe as mensagens através de uma rota
 
### Rodando nosso consumidor de orders

1. Navegue ao diretório do projeto para buildar o projeto e baixar as depenências

```powershell
cd ./order-consumer
dotnet restore
dotnet build
```

2. Execute o script que cria nosso side car Dapr: 

```powershell
./dapr-run.ps1
```
### Rodando nosso produtor de orders

1. Navegue ao diretório do projeto para buildar o projeto e baixar as depenências

```powershell
cd ./order-producer
dotnet restore
dotnet build
```
2. Execute o script que cria nosso side car Dapr: 
    
```powershell
./dapr-run.ps1
```
2. Comp encerrar a execução do Dapr app: 

```powershell
dapr stop --app-id order-producer
```
