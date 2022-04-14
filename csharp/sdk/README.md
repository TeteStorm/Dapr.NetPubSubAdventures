# Dapr pub/sub

Este exemplo demontra como realizar a produção e o consumo de eventos através do Dapr com a biblioteca Dapr client SDK.

O Dapr possui o conceito de build blocks apis (que plugam capacidades ao nosso app) no nosso caso faremos o uso do pubsub building block, onde conseguimos implementar de uma maneira completamente transparente e agnóstica nossa mssageria apenas utlizidando a intermediação via client do Dapr 
da produção e consumo das mensagens.


Visite [this](https://docs.dapr.io/developing-applications/building-blocks/pubsub/) para mais informações sobre o Dapr e Pub-Sub.


> **Note:** Este exemplo usa o Dapr client SDK


producer

console que realiza a produçao das mensagens


web-consumer 

web aplication que se registra(subscreve no tópico definindo a rota) e recebe as mensagens através de uma rota
 

api-consumer 

api que usa um controller e action para se registrar(subscreve no tópico definindo a rota) e recebe as mensagens
  


### Run Dotnet message subscriber with Dapr

1. Navigate to the directory and install dependencies: 

<!-- STEP
name: Install Dotnet dependencies
-->

```powershell
cd ./web-consumer
dotnet restore
dotnet build
```
<!-- END_STEP -->
2. Run the Dotnet subscriber app with Dapr: 

<!-- STEP
name: Run Dotnet subscriber
expected_stdout_lines:
  - "You're up and running! Both Dapr and your app logs will appear here."
  - '== APP == Subscriber received : 2'
  - "Exited Dapr successfully"
  - "Exited App successfully"
expected_stderr_lines:
working_dir: ./web-consumer
output_match_mode: substring
background: true
sleep: 10
-->


```powershell
./dapr-run.ps1
```

<!-- END_STEP -->
1. Navigate to the directory and install dependencies: 

<!-- STEP
name: Install Dotnet dependencies
-->

```powershell
cd ./api-consumer
dotnet restore
dotnet build
```
<!-- END_STEP -->
2. Run the Dotnet subscriber app with Dapr: 

<!-- STEP
name: Run Dotnet subscriber
expected_stdout_lines:
  - "You're up and running! Both Dapr and your app logs will appear here."
  - '== APP == Subscriber received : 2'
  - "Exited Dapr successfully"
  - "Exited App successfully"
expected_stderr_lines:
working_dir: ./api-consumer
output_match_mode: substring
background: true
sleep: 10
-->


```powershell
./dapr-run.ps1
```

<!-- END_STEP -->
### Run Dotnet message publisher with Dapr

1. Navigate to the directory and install dependencies: 

<!-- STEP
name: Install Dotnet dependencies
-->

```powershell
cd ./producer
dotnet restore
dotnet build
```
<!-- END_STEP -->
2. Run the Dotnet publisher app with Dapr: 

<!-- STEP
name: Run Dotnet publisher
expected_stdout_lines:
  - "You're up and running! Both Dapr and your app logs will appear here."
  - '== APP == Published data: Order { OrderId = 1 }'
  - '== APP == Published data: Order { OrderId = 2 }'
  - "Exited App successfully"
  - "Exited Dapr successfully"
expected_stderr_lines:
working_dir: ./producer
output_match_mode: substring
background: true
sleep: 10
-->
    
```powershell
./dapr-run.ps1
```

<!-- END_STEP -->

```powershell
dapr stop --app-id producer
```
