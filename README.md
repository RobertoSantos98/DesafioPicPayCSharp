Desafio PicPay – C# Backend

API desenvolvida com .NET Core para resolver o Desafio PicPay, com funcionalidades como criação de usuários, contas (consumidor e lojista), listagem com filtro e transações entre contas, utilizando serviço externo simulado para autorização.

============================================================
📌 Tecnologias

- .NET Core 7+
- Entity Framework Core (SQLite por padrão)
- Swagger / OpenAPI
- xUnit (testes unitários)
- HttpClient (autorização externa)
- Docker (opcional)

============================================================
🚀 Funcionalidades

✅ Usuários
- Cadastro de usuário com:
  - Nome completo
  - CPF (único)
  - Telefone
  - E-mail (único)
  - Senha
- Listagem de usuários com filtro 'q' (nome ou username que inicia com o valor informado)

✅ Contas
- Cada usuário pode ter:
  - 1 conta do tipo Consumidor
  - 1 conta do tipo Lojista
- Campos:
  - Consumidor: username exclusivo
  - Lojista: razão social, nome fantasia, CNPJ, username

✅ Transações
- Realização de transações entre contas
- Serviço externo de autorização simulado:
  - Valores ≥ R$100 → transação negada (HTTP 401)
  - Valores < R$100 → transação autorizada
- Persistência da transação aprovada no banco

============================================================
📦 Estrutura do Projeto

DesafioPicPayCSharp/
├── Controllers/         -> Endpoints
├── Models/              -> Entidades: User, Account, Transaction
├── Data/                -> DbContext e Migrations
├── Services/            -> Lógica de autorização externa
├── DTOs/                -> Data Transfer Objects
└── Tests/               -> Testes unitários (xUnit)

============================================================
🧪 Testes

Execute os testes com o comando abaixo:

dotnet test

============================================================
🛠️ Como Executar

🔁 Clonar o projeto

git clone https://github.com/RobertoSantos98/DesafioPicPayCSharp.git
cd DesafioPicPayCSharp

⚙️ Configurar o appsettings.json

Configure a connection string do banco de dados (SQLite, MySQL ou outro).

🗃️ Aplicar Migrations

dotnet ef database update

▶️ Executar a aplicação

dotnet restore
dotnet build
dotnet run

🐳 Docker (opcional)

docker-compose up --build

============================================================
📄 Swagger

Após rodar o projeto, acesse no navegador:

http://localhost:{porta}/swagger/index.html

Permite testar os endpoints de forma interativa.

============================================================
🔄 Fluxo da Transação

Usuário → Conta → Transação → Serviço Autorização → Resultado

============================================================
💡 Melhorias Futuras

- Autenticação com JWT
- Validações de CPF, CNPJ e e-mail
- Suporte a rollback e transações ACID
- Integração contínua (CI)
- Testes de integração e carga
- Monitoramento e health checks
- Suporte a outros bancos (PostgreSQL, MySQL)

============================================================
👤 Autor

Roberto dos Santos
GitHub: https://github.com/RobertoSantos98

============================================================
📜 Licença

Desafio técnico – uso pessoal. Nenhuma licença formal atribuída.
