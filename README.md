# Aventuras com Dapr e .NET
## Publicando e consumindo eventos
#### Este repositório possui fins didáticos para demonstrar os conceitos de Pub/Sub através do [Dapr](http://www.dapr.io)

- [Com HttpClient](https://github.com/TeteStorm/pub_sub/tree/master/csharp/http)
- [Com Dapr SDK](https://github.com/TeteStorm/pub_sub/tree/master/csharp/sdk)

## Requisitos para o tutorial

- Docker 
- [Dapr Cli](https://docs.dapr.io/getting-started/install-dapr-cli/) 
- VS Code
- .Net 6

#### Extensões do VS Code
- Docker for Visual Studio Code (exibindo os containers padão criados pela instalação do Dapr Cli)
![image](https://user-images.githubusercontent.com/8992182/163294950-9f55ccd1-1044-4c3b-9dea-32ed79fd5a7b.png)

- Dapr for Visual Studio Code (Preview)
 ![image](https://user-images.githubusercontent.com/8992182/163295446-f6412f88-d681-480c-a79e-0c8b180b299a.png)

- C# for Visual Studio Code (powered by OmniSharp)
- PowerShell Language Support for Visual Studio Code

#### Produzindo eventos diretamente ao componente Dapr

```
curl --location --request POST 'http://localhost:[your side car dapr port]/v1.0/publish/new_pub_sub/events' \
--header 'Content-Type: application/json' \
--data-raw '{
    "eventId": 2
}'
````
![image](https://user-images.githubusercontent.com/8992182/163307285-28e779c6-dd49-47c1-8996-7206311a2da3.png)
