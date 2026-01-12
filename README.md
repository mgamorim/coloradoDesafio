# Grupo Colorado - Sistema de Gerenciamento de Clientes

**Desenvolvido por: Mauricio Amorim**

Sistema completo de CRUD de clientes desenvolvido em ASP.NET Core 6.0 seguindo o padrão MVC, com API RESTful e interface web responsiva.

## Sobre o Projeto

Este projeto foi desenvolvido como parte do desafio técnico do Grupo Colorado para a vaga de Desenvolvedor Fullstack por **Mauricio Amorim**.

## Autor do Projeto

**Mauricio Amorim**
- GitHub: [@mgamorim](https://github.com/mgamorim)
- LinkedIn: [Mauricio Amorim](https://www.linkedin.com/in/mauricio-amorim)
- Email: mauricioamorim22@gmail.com
- Desenvolvedor Fullstack .NET

## Características Principais

- CRUD Completo de clientes
- API RESTful com documentação Swagger
- Interface Web MVC moderna e responsiva
- Entity Framework Core com SQL Server
- Arquitetura em camadas (limpa e padronizada)
- Repository Pattern para acesso a dados
- jQuery/JavaScript para interações dinâmicas
- DataTables para listagem de dados
- Bootstrap 5 para design responsivo

## Arquitetura do Projeto

O projeto está organizado em 4 camadas principais:

- ColoradoDesafio.Domain - Camada de Domínio (Entidades e Interfaces)
- ColoradoDesafio.Data - Camada de Dados (EF Core, Repositórios, Migrations)
- ColoradoDesafio.Api - Web API RESTful (Controllers, DTOs, Swagger)
- ColoradoDesafio.Web - Aplicação Web MVC (Controllers, Views, Services)

## Tecnologias Utilizadas

### Backend
- ASP.NET Core 6.0
- Entity Framework Core 6.0
- SQL Server
- Swagger/OpenAPI
- Repository Pattern

### Frontend
- ASP.NET Core MVC
- Bootstrap 5
- jQuery
- DataTables
- Font Awesome

## Como Executar

### Pré-requisitos
- .NET 6.0 SDK
- SQL Server Express ou LocalDB
- Visual Studio 2022 ou VS Code

### Passo 1: Clonar o Repositório
```bash
git clone https://github.com/mgamorim/coloradoDesafio.git
cd coloradoDesafio
```

### Passo 2: Configurar o Banco de Dados
Edite `ColoradoDesafio.Api/appsettings.json` com sua connection string

### Passo 3: Aplicar Migrations
```bash
dotnet ef database update --project ColoradoDesafio.Data --startup-project ColoradoDesafio.Api
```

### Passo 4: Executar

Terminal 1 - API:
```bash
cd ColoradoDesafio.Api
dotnet run
```

Terminal 2 - Web:
```bash
cd ColoradoDesafio.Web
dotnet run
```

### Acessar:
- Interface Web: https://localhost:7002
- API/Swagger: https://localhost:7001

## API Endpoints

### Clientes
- GET /api/clientes - Listar todos
- GET /api/clientes/{id} - Obter por ID
- POST /api/clientes - Criar
- PUT /api/clientes/{id} - Atualizar
- DELETE /api/clientes/{id} - Excluir

### Tipos de Telefone
- GET /api/tipostelefone - Listar tipos
- GET /api/tipostelefone/{id} - Obter por ID

## Requisitos Atendidos

### Obrigatórios
- CRUD de clientes usando ASP.Net Core
- Padrão MVC na versão mínima .NET 6.0
- Estrutura de tabelas conforme especificado
- Entidade TiposTelefone com tipos pré-cadastrados
- API RESTful documentada com Swagger
- JavaScript/jQuery para operações no MVC
- Banco de dados gratuito (SQL Server Express/LocalDB)
- Entity Framework para persistência

### Diferenciais
- Arquitetura limpa e padrão de repositório
- Separação clara de responsabilidades
- Código organizado e bem estruturado
- Documentação completa
- Interface moderna e responsiva
- Boas práticas de desenvolvimento

## Licença

Este projeto foi desenvolvido exclusivamente para fins de avaliação técnica do processo seletivo do Grupo Colorado.

---

**Projeto desenvolvido por Mauricio Amorim**

GitHub: https://github.com/mgamorim  
Email: mauricioamorim22@gmail.com  
LinkedIn: https://www.linkedin.com/in/mauricio-amorim
