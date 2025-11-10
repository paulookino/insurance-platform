# Plataforma de Seguros – Microserviços (.NET 8)

Este projeto implementa uma **plataforma simples de seguros**, composta por dois microserviços independentes:
- **PropostaService** — Gerencia propostas de seguro.
- **ContratacaoService** — Gerencia contratações de propostas aprovadas.

O sistema segue os princípios de **Arquitetura Hexagonal (Ports & Adapters)**, **DDD**, **Clean Architecture**, **SOLID** e boas práticas de testes automatizados.

---

## Arquitetura

Cada microserviço é independente e contém suas próprias camadas:


Cada camada possui uma responsabilidade clara:

| Camada | Descrição |
|--------|------------|
| **Domain** | Entidades, agregados e regras de negócio puras. |
| **Application** | Casos de uso (Handlers), DTOs e interfaces de portas (Ports). |
| **Infrastructure** | Implementações de repositórios, comunicação entre microserviços e persistência. |
| **Api** | Endpoints REST, validações e injeção de dependências. |
| **Tests** | Testes unitários e de integração. |

---

## Tecnologias

- **.NET 8**
- **C# 12**
- **Entity Framework Core** (ou repositórios em memória)
- **xUnit / Moq / FluentAssertions**
- **Swagger (OpenAPI)**
- **Docker & Docker Compose**
- **SQL Server ou PostgreSQL**
- **Arquitetura Hexagonal + DDD + Clean Architecture**

---

## Execução

### Requisitos
- [.NET SDK 8.0+](https://dotnet.microsoft.com/download)
- [Docker](https://www.docker.com/)
- (Opcional) SQL Server ou PostgreSQL

---

### Build e Execução Local

#### Clonar o repositório
bash
git clone https://github.com/seu-usuario/plataforma-seguros.git
cd plataforma-seguros

