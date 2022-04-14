# Dapr pub/sub

Este exemplo demontra como realizar a produção e o consumo de eventos através do Dapr com a biblioteca Dapr client SDK.

O Dapr possui o conceito de build blocks apis (que plugam capacidades ao nosso app) no nosso caso faremos o uso do pubsub building block, onde conseguimos implementar de uma maneira completamente transparente e agnóstica nossa mssageria apenas utlizidando a intermediação via client do Dapr 
da produção e consumo das mensagens.


Visite [this](https://docs.dapr.io/developing-applications/building-blocks/pubsub/) para mais informações sobre o Dapr e Pub-Sub.


producer

- console que realiza a produçao das mensagens

web-consumer 

- web aplication que se registra(subscreve no tópico definindo a rota) e recebe as mensagens através de uma rota
 
api-consumer 

- api que usa um controller e action para se registrar(subscreve no tópico definindo a rota) e recebe as mensagens
  
### Rodando nosso web-consumidor

1. Navegue ao diretório do projeto para buildar o projeto e baixar as depenências

```powershell
cd ./web-consumer
dotnet restore
dotnet build
```

2. Execute o script que cria nosso side car Dapr: 

```powershell
./dapr-run.ps1
```
### Rodando nosso api-consumidor

1. Navegue ao diretório do projeto para buildar o projeto e baixar as depenências

```powershell
cd ./api-consumer
dotnet restore
dotnet build
```

2. Execute o script que cria nosso side car Dapr: 

```powershell
./dapr-run.ps1
```
### Rodando nosso produtor de eventos

1. Navegue ao diretório do projeto para buildar o projeto e baixar as depenências

```powershell
cd ./producer
dotnet restore
dotnet build
```
2. Execute o script que cria nosso side car Dapr: 
    
```powershell
./dapr-run.ps1
```
2. Comp encerrar a execução do Dapr app: 

```powershell
dapr stop --app-id producer
```

