# Grupo Colorado - Sistema de Gerenciamento de Clientes

Sistema completo de CRUD de clientes desenvolvido em ASP.NET Core 6.0 seguindo o padrão MVC, com API RESTful e interface web responsiva.

## ?? Sobre o Projeto

Este projeto foi desenvolvido como parte do desafio técnico do Grupo Colorado para a vaga de Desenvolvedor Fullstack. O sistema permite o gerenciamento completo de clientes e seus telefones de contato.

### Características Principais

- ? **CRUD Completo** de clientes
- ? **API RESTful** com documentação Swagger
- ? **Interface Web MVC** moderna e responsiva
- ? **Entity Framework Core** com SQL Server
- ? **Arquitetura em camadas** (limpa e padronizada)
- ? **Repository Pattern** para acesso a dados
- ? **jQuery/JavaScript** para interações dinâmicas
- ? **DataTables** para listagem de dados
- ? **Bootstrap 5** para design responsivo

## ??? Arquitetura do Projeto

O projeto está organizado em 4 camadas principais:

```
ColoradoDesafio/
??? ColoradoDesafio.Domain/          # Camada de Domínio
?   ??? Entities/                     # Entidades do negócio
?   ?   ??? Cliente.cs
?   ?   ??? Telefone.cs
?   ?   ??? TipoTelefone.cs
?   ??? Interfaces/                   # Contratos de repositórios
?       ??? IClienteRepository.cs
?       ??? ITipoTelefoneRepository.cs
?
??? ColoradoDesafio.Data/            # Camada de Dados
?   ??? Context/                      # Contexto do Entity Framework
?   ?   ??? ColoradoDbContext.cs
?   ??? Repositories/                 # Implementação dos repositórios
?   ?   ??? ClienteRepository.cs
?   ?   ??? TipoTelefoneRepository.cs
?   ??? Migrations/                   # Migrations do banco de dados
?
??? ColoradoDesafio.Api/             # Web API RESTful
?   ??? Controllers/                  # Controllers da API
?   ?   ??? ClientesController.cs
?   ?   ??? TiposTelefoneController.cs
?   ??? DTOs/                         # Data Transfer Objects
?   ?   ??? ClienteDto.cs
?   ?   ??? TelefoneDto.cs
?   ?   ??? TipoTelefoneDto.cs
?   ??? Program.cs                    # Configuração da API
?
??? ColoradoDesafio.Web/             # Aplicação Web MVC
    ??? Controllers/                  # Controllers MVC
    ?   ??? ClientesController.cs
    ??? Models/                       # ViewModels
    ?   ??? ClienteViewModel.cs
    ?   ??? TelefoneViewModel.cs
    ?   ??? TipoTelefoneViewModel.cs
    ??? Services/                     # Serviços de comunicação com API
    ?   ??? ClienteService.cs
    ?   ??? TipoTelefoneService.cs
    ??? Views/                        # Views Razor
        ??? Clientes/
            ??? Index.cshtml
            ??? Create.cshtml
            ??? Edit.cshtml
            ??? Details.cshtml
            ??? Delete.cshtml
```

## ?? Modelo de Dados

### Tabela: Clientes
| Campo | Tipo | Descrição |
|-------|------|-----------|
| CodigoCliente | int | Chave primária |
| Nome | string(200) | Nome do cliente |
| CPF | string(14) | CPF do cliente |
| TipoPessoa | string(20) | FÍSICA ou JURÍDICA |
| Documento | string(200) | Outros documentos |
| Cadastro | DateTime? | Data de cadastro |
| Cidade | string(100) | Cidade |
| Endereco | string(200) | Endereço |
| Estado | string(2) | UF |
| DataInformacao | DateTime | Data de informação |
| Visualizado | bool? | Se foi visualizado |

### Tabela: Telefones
| Campo | Tipo | Descrição |
|-------|------|-----------|
| NumeroTelefone | int | Chave primária |
| CodigoCliente | int | FK para Cliente |
| TipoTelefone | string(50) | RESIDENCIAL, COMERCIAL, WHATSAPP, CELULAR |
| Numero | string(20) | Número do telefone |
| DDD | string(10) | DDD |
| DDI | int? | DDI |
| Observacao | string(200) | Observações |
| Ativo | bool? | Se está ativo |
| Descricao | string(200) | Descrição |

### Tabela: TiposTelefone
| Campo | Tipo | Descrição |
|-------|------|-----------|
| Id | int | Chave primária |
| Descricao | string(50) | Descrição do tipo |
| Ativo | bool | Se está ativo |

## ?? Como Executar o Projeto

### Pré-requisitos

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [SQL Server Express](https://www.microsoft.com/sql-server/sql-server-downloads) ou SQL Server LocalDB
- [Visual Studio 2022](https://visualstudio.microsoft.com/) ou [VS Code](https://code.visualstudio.com/)
- Git

### Passo 1: Clonar o Repositório

```bash
git clone https://github.com/mgamorim/coloradoDesafio.git
cd coloradoDesafio
```

### Passo 2: Restaurar Pacotes

```bash
dotnet restore
```

### Passo 3: Configurar o Banco de Dados

1. Edite o arquivo `ColoradoDesafio.Api/appsettings.json` e ajuste a connection string conforme seu ambiente:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=ColoradoDesafioDB;Trusted_Connection=true;TrustServerCertificate=true;MultipleActiveResultSets=true"
  }
}
```

**Opções de Connection String:**

- **SQL Server Express:**
  ```
  Server=localhost\\SQLEXPRESS;Database=ColoradoDesafioDB;Trusted_Connection=true;TrustServerCertificate=true;MultipleActiveResultSets=true
  ```

- **SQL Server LocalDB:**
  ```
  Server=(localdb)\\mssqllocaldb;Database=ColoradoDesafioDB;Trusted_Connection=true;MultipleActiveResultSets=true
  ```

- **SQL Server com autenticação:**
  ```
  Server=localhost;Database=ColoradoDesafioDB;User Id=seu_usuario;Password=sua_senha;TrustServerCertificate=true;MultipleActiveResultSets=true
  ```

### Passo 4: Aplicar Migrations

```bash
dotnet ef database update --project ColoradoDesafio.Data --startup-project ColoradoDesafio.Api
```

### Passo 5: Executar os Projetos

#### Executar a API (Terminal 1):

```bash
cd ColoradoDesafio.Api
dotnet run
```

A API estará disponível em: `https://localhost:7001`
Swagger/Documentação: `https://localhost:7001`

#### Executar a Aplicação Web (Terminal 2):

```bash
cd ColoradoDesafio.Web
dotnet run
```

A aplicação web estará disponível em: `https://localhost:7002`

### Passo 6: Acessar a Aplicação

Abra seu navegador e acesse:
- **Interface Web:** https://localhost:7002
- **API/Swagger:** https://localhost:7001

## ?? Executando com Visual Studio

1. Abra o arquivo `ColoradoDesafio.sln`
2. Configure múltiplos projetos de inicialização:
   - Clique com botão direito na solution
   - Selecione "Set Startup Projects..."
   - Escolha "Multiple startup projects"
   - Configure:
     - ColoradoDesafio.Api ? **Start**
     - ColoradoDesafio.Web ? **Start**
3. Pressione F5 para executar

## ?? API Endpoints

### Clientes

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| GET | `/api/clientes` | Listar todos os clientes |
| GET | `/api/clientes/{id}` | Obter cliente por ID |
| POST | `/api/clientes` | Criar novo cliente |
| PUT | `/api/clientes/{id}` | Atualizar cliente |
| DELETE | `/api/clientes/{id}` | Excluir cliente |

### Tipos de Telefone

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| GET | `/api/tipostelefone` | Listar tipos de telefone |
| GET | `/api/tipostelefone/{id}` | Obter tipo por ID |

### Exemplo de Request (POST /api/clientes)

```json
{
  "nome": "João Silva",
  "cpf": "123.456.789-00",
  "tipoPessoa": "FÍSICA",
  "documento": "RG 12.345.678-9",
  "cadastro": "2026-01-15",
  "cidade": "São Paulo",
  "endereco": "Rua Exemplo, 123",
  "estado": "SP",
  "telefones": [
    {
      "tipoTelefone": "COMERCIAL",
      "numero": "3456-7890",
      "ddd": "11",
      "descricao": "Telefone comercial"
    },
    {
      "tipoTelefone": "WHATSAPP",
      "numero": "98765-4321",
      "ddd": "11",
      "descricao": "WhatsApp pessoal"
    }
  ]
}
```

## ?? Funcionalidades da Interface Web

### Listagem de Clientes
- Tabela com DataTables (ordenação, busca, paginação)
- Visualização de quantidade de telefones
- Ações rápidas (Visualizar, Editar, Excluir)

### Cadastro/Edição de Clientes
- Formulário com validação
- Adição dinâmica de múltiplos telefones
- Máscaras de entrada (CPF, telefone)
- Seleção de tipos de telefone
- Interface responsiva

### Detalhes do Cliente
- Visualização completa dos dados
- Lista de telefones cadastrados
- Navegação rápida para edição

### Exclusão de Clientes
- Tela de confirmação
- Exibição dos dados que serão excluídos
- Exclusão em cascata dos telefones

## ??? Tecnologias Utilizadas

### Backend
- **ASP.NET Core 6.0** - Framework web
- **Entity Framework Core 6.0** - ORM
- **SQL Server** - Banco de dados
- **Swagger/OpenAPI** - Documentação da API
- **Repository Pattern** - Padrão de projeto

### Frontend
- **ASP.NET Core MVC** - Framework de apresentação
- **Bootstrap 5** - Framework CSS
- **jQuery** - Biblioteca JavaScript
- **DataTables** - Plugin de tabelas
- **Font Awesome** - Ícones

## ?? Diferenciais Implementados

? **Arquitetura limpa e organizada** em camadas
? **Repository Pattern** para desacoplamento
? **Injeção de Dependência** configurada
? **Documentação completa com Swagger**
? **CORS configurado** para acesso cross-origin
? **Validações** no backend e frontend
? **Tratamento de erros** apropriado
? **Interface responsiva** para mobile
? **Máscaras de entrada** para melhor UX
? **DataTables** para gestão de grandes volumes
? **Seeds** para dados iniciais (tipos de telefone)
? **Migrations** versionadas

## ?? Estrutura de Requisitos Atendidos

### Requisitos Obrigatórios
- ? CRUD de clientes usando ASP.Net Core
- ? Padrão MVC na versão mínima .NET 6.0
- ? Estrutura de tabelas conforme especificado
- ? Entidade TiposTelefone com tipos pré-cadastrados
- ? API RESTful com arquitetura RESTful
- ? API documentada com Swagger
- ? JavaScript/jQuery para operações no MVC
- ? Banco de dados gratuito (SQL Server Express/LocalDB)
- ? Entity Framework para persistência

### Diferenciais
- ? Arquitetura limpa e padrão de repositório
- ? Separação clara de responsabilidades
- ? Código organizado e bem estruturado
- ? Documentação completa
- ? Interface moderna e responsiva
- ? Boas práticas de desenvolvimento

## ?? Autor

**Mauricio Amorim**
- GitHub: [@mgamorim](https://github.com/mgamorim)
- Email: mauricioamorim22@gmail.com

## ?? Licença

Este projeto foi desenvolvido para fins de avaliação técnica.

---

? **Desenvolvido com dedicação para o Grupo Colorado** ?
