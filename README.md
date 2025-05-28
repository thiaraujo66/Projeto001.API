# 🛠️ Projeto001 - API REST em .NET 9 com autenticação JWT e oAuth2

Este repositório contém o código-fonte de uma API REST desenvolvida com foco em organização, segurança e testabilidade. A API foi construída em **.NET 9.0**, utilizando boas práticas de arquitetura em camadas, autenticação via **JWT**, integração com **OAuth2** e persistência com **Entity Framework Core**.

---

## 🚀 Tecnologias e Frameworks

- **.NET 9.0**
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **SQL Server**
- **JWT (JSON Web Tokens)** – Autenticação e autorização
- **OAuth2** – Integração via Swagger para testes autenticados
- **AutoMapper** – Mapeamento entre DTOs e entidades
- **xUnit** – Testes unitários e de integração
- **AutoFixture** – Geração automática de dados em testes
- **Swashbuckle** – Documentação interativa com Swagger

---

## 📦 Estrutura de Pastas

- **Projeto001.API/**             → Controllers e configurações da API  
- **Projeto001.Application/**     → Regras de negócio e serviços  
- **Projeto001.Domain/**          → Entidades, enums e interfaces  
- **Projeto001.Infraestrutura/**  → Contexto do banco, repositórios  
- **Projeto001.Test/**            → Testes automatizados com xUnit  

---

## 🔐 Autenticação e Autorização
- **Implementação com JWT Bearer Token**
- **Controle de acesso baseado em roles via [Authorize(Roles = "...")]**
- **Swagger configurado com OAuth2 para testes autenticados**
- **Claims populadas no token:**
  - **sub (ID do usuário)**
  - **name (nome de usuário)**
  - **role (tipo de permissão)**

---

## 🧪 Testes Automatizados
- **Testes unitários e de integração com rollback de transações**
- **Fixture com DBCC CHECKIDENT para controle de IDENTITY após rollback**
- **dotnet test Projeto001.Test**

---

## ▶️ Executar o Projeto
**Pré-requisitos:**
- **.NET SDK 9.0**
- **SQL Server (local ou via Docker)**
- **Visual Studio 2022+ ou VS Code**

---

## 📄 Swagger e Interface de Testes
**A documentação interativa da API está disponível após rodar o projeto em:**
- **https://localhost:{porta}/swagger**
