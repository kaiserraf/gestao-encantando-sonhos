# Documentação Backend Gestão Encantando Sonhos
Sistema de gestão de feijoadas. Este documento contempla apenas o backend do projeto, incluindo arquitetura, configuração, modelo de dados e todas as endpoints da API



## 1. Visão Geral
O backend é uma API REST construida com .NET, usando ASP.NET Core e Entity Framework, com autenticação baseada em JWT + refresh token \

### 1.1. Stack e dependências
| Dependência | Uso |
|---|---|
| Springboot | Servidor HTTP e roteamento |
| Spring Data | Gerenciamento de Banco de Dados |
| JWT | Emissão/Verificação de acess tokens JWT |
| BCrypt.Net | Hash de Senhas |


### 1.2. Estrutura de pastas
```
GesApi/

```

## 2. Modelo de dados (PostgreSQL)
Todos os dados são criados a partir de migrations geradas pelo EF Core, garantindo total compatibilidade entre o código e banco de dados. As tabelas são:

### Buyer
| Campo | Tipo | Restrições |
|---|---|---|
| `Id` | BigInt | Not Null, Primary Key |
| `Name` | Varchar | Not Null |
| `Phone` | Varchar | Not Null
| `EmployeeId` | BigInt | FK -> Employee |
| `LeadBuyerId` | BigInt | Null, FK -> Buyer |

### ProfileTypes
| Campo | Tipo | Restrições |
|---|---|---|
| `Id` | Int | Not Null, Primary Key |
| `FunctionName` | Varchar | NotNull |

### Employee
| Campo | Tipo | Restrições |
|---|---|---|
| `Id` | BigInt | Not Null, Primary Key |
| `Name` | Varchar | Not Null |
| `Phone` | Varchar | Not Null, Unique |
| `Cpf` | Varchar | Not Null, Unique |
| `PasswordHash` | Varchar | Not Null |
| `RegisterDate` | DateTime | Not Null |
| `ProfileTypeId` | Int | Null, FK -> ProfileType |

### Ticket
| Campo | Tipo | Restrições |
|---|---|---|
| `Id` | BigInt | Not Null, Primary Key |
| `BuyDate` | DateTime | NotNull |
| `Cleared` | Boolean | Not Null |
| `ClearedDate` | DateTime | Null |
| `MealId` | Int | Not Null, FK -> Meal |
| `BuyerId` | BigInt | Not Null, FK -> Buyer |

### Meal
| Campo | Tipo | Restrições |
|---|---|---|
| `Id` | Int | Not Null, Primary Key |
| `MealName` | Varchar | Not Null |
| `Items` | Varchar[] | Not Null |
| `Price` | Numeric | Not Null |

### RefreshTokens
| Campo | Tipo | Restrições |
|---|---|---|
| `Id` | Int | Not Null, Primary Key |
| `Token` | Varchar | NotNull, Unique |
| `EmployeeId` | BigInt | Not Null, FK -> Employee |
| `CreatedDate` | DateTime | Not Null |
| `ExpiresAt` | DateTime | Not Null |

## 3. Padrão de Resposta

### 3.1. UserAuth
#### 3.1.1 Register
| Metodo |  Status| Body|
|---|---|---|
| `POST` | 201 | usuário registrado e logado |
| `POST` | 400 | `CpfExistsException`, usuario já existe |
| `POST` | 500 | `DbUpdateException`, erro ao conectar com banco de dados |

### 3.1.2 Login
| Metodo |  Status| Body|
|---|---|---|
| `POST` | 200 | usuário logado |
| `POST` | 500 | `OperationCanceledException`, erro na operação com banco de dados |
| `POST` | 400 | `IncorrectException`, cpf ou senha incorretos |



## 4. Autenticação
