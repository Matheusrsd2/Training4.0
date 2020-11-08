# TrainingBackend
Esse projeto consiste em 3 camadas que fazem parte do backend do Sistema Training 4.0
- Dominio
- Repositorio
- Web API


# Integrantes
Matheus dos Reis - RA: 582621

Luis Gustavo - RA: 

Ingrid Nayara - RA: 

# Funcionalidade
| Data  |  Evento  |
| ------------------- | ------------------- |
| 19/10/2020 | Analise das Tecnologias |
| 24/10/2020 | Modelagem e Criação das 3 camadas do backend |
| 24/10/2020 | Definido as entidades no Training.Domain |
| 24/10/2020 | Desenvolvimento da camada Repository  |
| 24/10/2020 | Desenvolvimento da camada WebAPI  |
| 26/10/2020 | Métodos HTTP para requisições ao servidor  |

# Tecnologias
| Tecnologia  |  Descrição  |
| ------------------- | ------------------- |
| C# | Linguagem de programação |
| Microsoft ASP.NET Core | Framework de desenvolvimento web no servidor |
| Entity Framework Core |  ORM para mapear e criar as entidades do banco de dados |
| SQL Server |  SGBD relacional para o banco de dados |


## Como Executar o projeto localmente

- Possuir o .NET Core na versão 2.2.202 instalado na maquina (Necessita ser nessa versão)
- Possuir o SQL Server para o banco de dados 
- Dentro do SQL Server criar o banco de dados com o nome Training4_0

    No diretório \Training.Repository
- Executar os comandos a seguir para criação e execução da migrations responsáveis por criar as tabelas do banco de dados 



- Executar o comando dotnet run para subir o servidor local
- acessar pela url: http://localhost:5000