# ?? Guia Rápido de Execução

## Para executar o projeto rapidamente:

### 1. Ajuste a Connection String
Edite `ColoradoDesafio.Api/appsettings.json`:

```json
"DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=ColoradoDesafioDB;Trusted_Connection=true;TrustServerCertificate=true;MultipleActiveResultSets=true"
```

### 2. Crie o banco de dados
```bash
dotnet ef database update --project ColoradoDesafio.Data --startup-project ColoradoDesafio.Api
```

### 3. Execute os projetos

**Terminal 1 - API:**
```bash
cd ColoradoDesafio.Api
dotnet run
```

**Terminal 2 - Web:**
```bash
cd ColoradoDesafio.Web
dotnet run
```

### 4. Acesse
- **Web App:** https://localhost:7002
- **API/Swagger:** https://localhost:7001

---

## ?? Troubleshooting

### Erro de conexão com SQL Server?
**Opção 1 - SQL Server Express:**
```
Server=localhost\\SQLEXPRESS;Database=ColoradoDesafioDB;Trusted_Connection=true;TrustServerCertificate=true;MultipleActiveResultSets=true
```

**Opção 2 - SQL Server LocalDB:**
```
Server=(localdb)\\mssqllocaldb;Database=ColoradoDesafioDB;Trusted_Connection=true;MultipleActiveResultSets=true
```

**Opção 3 - SQL Server com senha:**
```
Server=localhost;Database=ColoradoDesafioDB;User Id=sa;Password=SuaSenha;TrustServerCertificate=true;MultipleActiveResultSets=true
```

### API não está respondendo?
- Verifique se a API está rodando na porta 7001
- Verifique se não há firewall bloqueando
- Tente acessar: https://localhost:7001

### Erro ao criar migration?
```bash
# Remova a migration existente
dotnet ef migrations remove --project ColoradoDesafio.Data --startup-project ColoradoDesafio.Api

# Crie novamente
dotnet ef migrations add InitialCreate --project ColoradoDesafio.Data --startup-project ColoradoDesafio.Api

# Aplique ao banco
dotnet ef database update --project ColoradoDesafio.Data --startup-project ColoradoDesafio.Api
```

---

## ?? Estrutura do Banco de Dados

O sistema criará automaticamente:
- **Tabela Clientes** - Dados dos clientes
- **Tabela Telefones** - Telefones dos clientes
- **Tabela TiposTelefone** - Tipos (pré-populada com: RESIDENCIAL, COMERCIAL, WHATSAPP, CELULAR)

---

## ?? Funcionalidades Disponíveis

### No Web App (https://localhost:7002)
- ? Listar todos os clientes
- ? Criar novo cliente (com múltiplos telefones)
- ? Editar cliente
- ? Visualizar detalhes do cliente
- ? Excluir cliente
- ? Busca e ordenação de clientes
- ? Máscaras de entrada (CPF, telefone)

### Na API (https://localhost:7001)
- ? Documentação interativa Swagger
- ? Endpoints RESTful completos
- ? Suporte a CORS
- ? Validações de dados
- ? Respostas HTTP apropriadas

---

## ?? Dicas

1. **Primeiro acesso:** Use o Swagger para testar a API antes de usar o Web App
2. **Tipos de telefone:** Já vêm pré-cadastrados no banco
3. **Máscaras:** O sistema aplica automaticamente máscaras de CPF e telefone
4. **DataTables:** A listagem suporta ordenação, busca e paginação automática
5. **Responsivo:** A interface funciona em desktop, tablet e mobile

---

## ?? Exemplo de Cliente

```json
{
  "nome": "João da Silva",
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
    }
  ]
}
```

---

**Desenvolvido para o Grupo Colorado** ??
