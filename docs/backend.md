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

#### 3.1.2 Login
| Metodo |  Status| Body|
|---|---|---|
| `POST` | 200 | usuário logado |
| `POST` | 500 | `OperationCanceledException`, erro na operação com banco de dados |
| `POST` | 400 | `IncorrectException`, cpf ou senha incorretos |

### 3.2 Tickets
#### 3.2.1 Create
| Metodo |  Status| Body|
|---|---|---|
|`POST` | 201 | Created |
| `POST` | 500 | `OperationCanceledException`, erro na operação com banco de dados |
| `POST` | 500 | `DbUpdateException`, Não foi possivel salvar as alterações no banco |

#### 3.2.1 Read All
| Metodo |  Status| Body|
|---|---|---|
| `GET` | 200 | Lista de tickets |
| `GET` | 500 | `OperationCanceledException`, erro na operação com banco de dados |
| `GET` | 500 | `DbUpdateException`, Não foi possivel salvar as alterações no banco |

#### 3.2.1 Read By Filter
| Metodo |  Status| Body|
|---|---|---|
| `GET` | 200 | Lista de tickets filtrados |
| `GET` | 500 | `OperationCanceledException`, erro na operação com banco de dados |
| `GET` | 500 | `DbUpdateException`, Não foi possivel salvar as alterações no banco |
| `DELETE` | 404 | `KeyNotFoundException`, Não foi possivel salvar as alterações no banco |

#### 3.2.1 Read By Id
| Metodo |  Status| Body|
|---|---|---|
| `GET` | 200 | Ticket solicitado |
| `GET` | 500 | `OperationCanceledException`, erro na operação com banco de dados |
| `GET` | 500 | `DbUpdateException`, Não foi possivel salvar as alterações no banco |

#### 3.2.1 Delete
| Metodo |  Status| Body|
|---|---|---|
| `DELETE` | 200 | Deleta o ticket solicitado |
| `DELETE` | 500 | `OperationCanceledException`, erro na operação com banco de dados |
| `DELETE` | 500 | `DbUpdateException`, Não foi possivel salvar as alterações no banco |
| `DELETE` | 404 | `KeyNotFoundException`, Não foi possivel salvar as alterações no banco |

### 3.2 Buyers
#### 3.2.1 Create
| Metodo |  Status| Body|
|---|---|---|
|`POST` | 201 | Created |
| `POST` | 500 | `OperationCanceledException`, erro na operação com banco de dados |
| `POST` | 500 | `DbUpdateException`, Não foi possivel salvar as alterações no banco |

#### 3.2.1 Read All
| Metodo |  Status| Body|
|---|---|---|
| `GET` | 200 | Lista de compradores |
| `GET` | 500 | `OperationCanceledException`, erro na operação com banco de dados |
| `GET` | 500 | `DbUpdateException`, Não foi possivel salvar as alterações no banco |

#### 3.2.1 Read By Filter
| Metodo |  Status| Body|
|---|---|---|
| `GET` | 200 | Lista de compradores filtrados |
| `GET` | 500 | `OperationCanceledException`, erro na operação com banco de dados |
| `GET` | 500 | `DbUpdateException`, Não foi possivel salvar as alterações no banco |
| `DELETE` | 404 | `KeyNotFoundException`, Não foi possivel salvar as alterações no banco |

#### 3.2.1 Read By Id
| Metodo |  Status| Body|
|---|---|---|
| `GET` | 200 | comprador solicitado |
| `GET` | 500 | `OperationCanceledException`, erro na operação com banco de dados |
| `GET` | 500 | `DbUpdateException`, Não foi possivel salvar as alterações no banco |

#### 3.2.1 Delete
| Metodo |  Status| Body|
|---|---|---|
| `DELETE` | 200 | Deleta comprador solicitado |
| `DELETE` | 500 | `OperationCanceledException`, erro na operação com banco de dados |
| `DELETE` | 500 | `DbUpdateException`, Não foi possivel salvar as alterações no banco |
| `DELETE` | 404 | `KeyNotFoundException`, Não foi possivel salvar as alterações no banco |

## 4. Autenticação

## 5. Rotas HTTP
### 5.1 Users
| Metodo | Rota | Descrição |
|---|---|---|
| `POST` | `/Register` | Cadastra um novo usuário |
| `POST` | `/Login` | Autentica cpf e senha, disponibilizando accessToken para o usuário |
| `POST` | `/Logout` | Invalida o token no banco, encerrando a sessão |
| `POST` | `/RefreshToken` | Renova o access token |

### 5.2 Tickets
| Metodo | Rota | Descrição |
|---|---|---|
| `POST` | `/NewTicket` | Gera um novo ingresso |
| `GET` | `/Tickets` | Pega todos os ingressos disponiveis |
| `GET` | `/Tickets/{id:long}` | Pega um ingresso pelo seu Id  |
| `GET` | `/TicketsFilter` | Pega um ou mais ingressos baseado em filtros |
| `POST` | `/TicketCleared/{id:long}` | Da baixa em um ingresso pelo seu Id |
| `DELETE` | `/Tickets/{id:long}` | Deleta um ingresso pelo seu Id |

### 5.3 Buyers
| Metodo | Rota | Descrição |
|---|---|---|
| `POST` | `/NewBuyer` | Cadastra um novo comprador |
| `GET` | `/Buyers` | Pega todos os compradores disponiveis |
| `GET` | `/Buyers/{id:long}` | Pega um comprador pelo seu Id  |
| `GET` | `/BuyersFilter` | Pega um ou mais compradores baseado em filtros |
| `PATCH` | `/BuyersUpdate/{id:long}` | Atualiza as informações de um comprador pelo seu Id |
| `DELETE` | `/Buyers/{id:long}` | Deleta um comprador pelo seu Id |