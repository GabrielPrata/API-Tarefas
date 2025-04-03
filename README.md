# API Tarefas
Bem-vindo ao repositório do projeto **API-Tarefas**! 

## Descrição
Esta aplicação foi construída utilizando o framework .NET6 e utiliza o SQL Server como banco de dados. 
Ela implementa recursos para:
  - Adicionar uma nova tarefa;
  - Listar todas as tarefas existentes;
  - Buscar uma tarefa específica pelo ID;
  - Editar uma tarefa existente;
  - Deletar uma tarefa;

## Tecnologias Utilizadas
- [.NET 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- [SQL Server](https://www.microsoft.com/pt-br/sql-server/)

## Pré-requisitos
Antes de executar o projeto, certifique-se de ter instalado:
- .NET6 ou alguma versão compatível;
- Servidor de banco de dados SQL Server;
- Visual Studio (A versão 2022 é a ideal);
- Um ferramenta de gerenciamento de dados como o Azure Data Studio ou o SSMS;
  

## Configuração do Ambiente Local
Siga os passos abaixo para configurar o projeto no seu ambiente:

1. **Clone o repositório:**
   ```bash
   git clone https://github.com/GabrielPrata/API-Tarefas.git)

2. **Criar o banco de dados**
   Na raiz do projeto é possível encontrar o arquivo BD.sql onde há o script para a criação do banco de dados, suas tabelas e as informações necessárias para o bom funcionamento da aplicação.

## Rodando o projeto
Após o banco de dados ter sido criado, abra o arquivo **API-Tarefas.sln** com o Visual Studio e selecione a solução Tarefas.Application como projeto de inicialização. <br>
Na solução **API-Tarefas.sln** edite o arquivo **appsettings.json** e edite a conexão com o banco de dados. <br>
Clique no botão de "play" e o projeto estará funcionando

## Informações adicionais
Link para o Front-End: https://github.com/GabrielPrata/tarefas_frontend <br>
Há também no diretório raiz o arquivo **Tarefas API.postman_collection.json** para ser importado no Postman para a visualização das chamadas para a API.
