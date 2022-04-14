# Dapr pub/sub (HTTP Client)

Este exemplo demontra como realizar a produçao e o consumo de eventos através do Dapr sem a necessidade do uso de nenhuma dependência ou biblioteca adicional.

O Dapr possui o conceito de build blocks apis (que plugam capacidades ao nosso app) no nosso caso faremos o uso do pubsub building block, onde conseguimos implementar de uma maneira completamente transparente e agnóstica nossa mssageria apenas utlizidando a intermediação via http da produção e consumo das mensagens.


Visite [this](https://docs.dapr.io/developing-applications/building-blocks/pubsub/) para mais informações sobre o Dapr e Pub-Sub.

> **Note:** Este exemplo usa apenas HTTPClient

order-producer

console que realiza a produçao das mensagens


order-consumer 

web aplication que se registra(subscreve no tópico definindo a rota) e recebe as mensagens através de uma rota
 


### Run Dotnet message subscriber with Dapr

1. Navigate to the directory and install dependencies: 

<!-- STEP
name: Install Dotnet dependencies
-->

```powershell
cd ./order-consumer
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
working_dir: ./order-consumer
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
cd ./order-producer
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
working_dir: ./order-producer
output_match_mode: substring
background: true
sleep: 10
-->
    
```powershell
./dapr-run.ps1
```

<!-- END_STEP -->

```powershell
dapr stop --app-id order-producer
```
