# 💼 SisFuncionarios Web

Sistema web desenvolvido em **ASP.NET Core MVC (net8.0)** com **Entity Framework Core 9** e **SQL Server**, voltado para o gerenciamento de profissionais e cálculo de horas extras.

Este projeto é a evolução do antigo sistema desktop, agora totalmente migrado para a plataforma web, com **injeção de dependência**, **validações de modelo** e **interface responsiva** com **Bootstrap 5**.

---

## ⚙️ Tecnologias Utilizadas

- **ASP.NET Core MVC (net8.0)**
- **Entity Framework Core 9.0**
- **SQL Server**
- **Bootstrap 5**
- **Razor Views**
- **LINQ**
- **Dependency Injection**
- **Localization (pt-BR)**

---

## 🧩 Funcionalidades

### 👤 Módulo de Profissionais
- CRUD completo de profissionais  
- Validação de campos obrigatórios e formatos (telefone, CEP, RG, salário etc.)  
- Máscara de salário com conversão automática para decimal  
- Seleção de estado (UF) via dropdown  
- Confirmação de exclusão com JavaScript  
- Feedback de sucesso com TempData  

### ⏱️ Módulo de Cálculo de Hora Extra
- Seleção de profissional com carregamento automático de salário  
- Inserção manual de quantidade de horas  
- Cálculo total com base no salário informado (5% por hora extra)  
- Exibição dinâmica de resultados  
- Opção de limpar cálculo e iniciar novo  

**🧮 Fórmula usada:**  
```
Total = Salário + (Salário × 0.05 × HorasExtras)
```

---

## 🚀 Como Executar o Projeto

### 1️⃣ Pré-requisitos
- Visual Studio 2022  
- .NET SDK 8.0  
- SQL Server (Developer ou Express)  
- SQL Server Management Studio (SSMS) *(opcional)*  

### 2️⃣ Banco de Dados

Você pode criar o banco de dados de duas formas:

#### 🧾 Opção A — Script SQL (recomendado)
Execute o arquivo:  
📂 `script/ScriptBanco.sql`

#### ⚙️ Opção B — Migrations via Entity Framework
No Console do Gerenciador de Pacotes, execute:  
```
Update-Database
```

### 3️⃣ Configuração de Conexão
No arquivo `appsettings.json`, configure o servidor SQL:
```json
{
  "ConnectionStrings": {
    "ConexaoPadrao": "Server=SEU_SERVIDOR_SQL;Database=FuncionariosDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

### 4️⃣ Executando
1. Abra o projeto `SisSistemasWeb.sln` no Visual Studio  
2. Restaure os pacotes NuGet *(geralmente automático)*  
3. Pressione **F5** ou clique em ▶️ **Executar**  
4. O navegador abrirá em: `https://localhost:xxxx`

---

## 👨‍💻 Autor
**Desenvolvido por Matheus Gomes**
