
# Task Minder

Task Minder é um simples site de lista de tarefas, é uma ferramenta que permite aos usuários criar, organizar e gerenciar suas tarefas diárias de forma eficiente. Como um app todo, os usuários podem criar listas de tarefas, adicionar descrições cada tarefa e marcar as tarefas concluídas à medida que são realizadas.


## Stack utilizada

**Front-end e Back-end:** ASP .NET Razor Pages e ABP Framework.  
**Banco de dados:** Postgresql  
**UI Test:** Cypress

**ASP.NET Razor Pages** é um framework do ASP.NET Core que simplifica o desenvolvimento de aplicativos da web, permitindo que os desenvolvedores criem interfaces de usuário interativas de forma rápida.

**ABP (Application Building Platform) Framework** é um framework de desenvolvimento de aplicativos de código aberto que visa acelerar o desenvolvimento de aplicativos empresariais. Ele segue uma arquitetura modular e fornece um conjunto abrangente de recursos pré-construídos, como autenticação, autorização, gerenciamento de usuários, notificações, controle de versão, internacionalização e muito mais. O ABP Framework suporta vários frameworks web populares, como o ASP.NET Core e o Angular, e permite que os desenvolvedores criem aplicativos escaláveis, modulares e de alta qualidade com facilidade. Ele também promove as melhores práticas de desenvolvimento e segue os princípios SOLID.

**PostgreSQL** é um banco de dados relacional de código aberto, confiável e escalável. Ele suporta recursos avançados, como ACID e integridade referencial, e possui extensibilidade para atender a requisitos personalizados. Com uma comunidade ativa e um ecossistema amplo de ferramentas, é uma escolha popular para aplicativos que necessitam de desempenho, flexibilidade e confiabilidade

**Cypress** é uma ferramenta de automação de testes end-to-end para aplicativos da web. Ele permite escrever testes que simulam a interação do usuário com o aplicativo e é conhecido por sua arquitetura única e recursos avançados.



## Rodando o projeto localmente

Clone o projeto

```bash
  git clone https://github.com/jonathan-sarmento/task-minder.git
```

Entre no diretório do projeto principal e o abra na sua IDE

```bash
  cd task-minder/TaskMinder
```

Defina a Connection String do seu banco Postgres no arquivo `appsettings.json`  
```
"ConnectionStrings": {
    "Default": "Host=localhost;Database=abpDatabase;User ID=user;Password=password;Port=5432;
  } 
  ```

Rode o comando da migração inicial para criar as tabelas no banco de dados (Necessário ter o CLI do Entity Framework instalado)

```
dotnet ef database update

```
Depois de criado as tabelas, é necessário excutar alguns comandos extras. Execute os comandos SQL do arquivo `extra.sql` no seu BD para finalizar as configurações das tabelas.

Após isso, inicie a aplicação
```
dotnet run
```
