# Planejamento de Sistemas: Gestão Encantando Sonhos — Feijoada

## Descrição do Sistema

Sistema desenvolvido para solucionar problemas encontrados no "almoço de feijoada", relacionados principalmente à comunicação, gerenciamento de convites e controle financeiro do evento.

### Problemas encontrados

- Descentralização de venda dos ingressos
- Dependência de somente um aparelho para múltiplas funções durante o evento
- Dificuldade de comunicação entre as funções

Tendo isso em vista, foi analisada a possibilidade de um sistema e foram levantados seus principais requisitos.

---

## Quem utiliza o sistema?

| Usuário/Papel | Principais Responsabilidades |
|---|---|
| Recepção | Visualização dos ingressos comprados; buscar e listar clientes; enviar notificações para cozinha |
| Caixa | Visualização dos ingressos comprados; enviar notificações para cozinha; gerar novos ingressos/vendas; gerar despesas; dar baixa em ingressos; abertura de conta |
| Cozinha | Visualização dos ingressos comprados; receber notificações; dar baixa nos ingressos |
| Garçons | Registrar produtos solicitados |
| Administrador | Todas as funções anteriores; gerar relatórios |

---

## O que o sistema deverá fazer? (Requisitos Funcionais)

- **RF01**: O sistema deverá permitir o cadastro de garçons
- **RF02**: O sistema deverá permitir o cadastro de uma cozinha
- **RF03**: O sistema deverá permitir o cadastro de um caixa
- **RF04**: O sistema deverá permitir o cadastro de uma recepção
- **RF05**: O sistema deverá permitir o usuário com perfil caixa abrir uma conta
- **RF06**: O sistema deverá permitir o registro de produtos e suas quantidades no estoque
- **RF07**: O sistema deverá permitir o registro de um produto em uma conta
- **RF08**: O sistema deverá atualizar o valor da conta a cada novo item inserido
- **RF09**: O sistema deverá permitir enviar notificações para a cozinha
- **RF10**: O sistema deverá permitir o recebimento das notificações
- **RF11**: O sistema deverá permitir a visualização dos ingressos
- **RF12**: O sistema deverá permitir a aplicação de filtros nos ingressos
- **RF13**: O sistema deverá permitir o cadastro de novos ingressos
- **RF14**: O sistema deverá permitir dar baixa nos ingressos
- **RF15**: O sistema deverá gerar relatórios ao final do evento

### Priorização de Requisitos e Funcionalidades do Sistema

| Requisitos/Funcionalidades | Nível de Prioridade |
|---|---|
| RF02, RF03, RF04, RF06, RF11, RF12, RF13, RF14 | Indispensável (extremamente alta) |
| RF15, RF09, RF10 | Alta |
| RF01, RF05, RF07, RF08 | Média |
| Stripe de pagamentos (RF16) | Baixa |

Essa priorização de requisitos foi feita baseada no quão importante é aquela funcionalidade para o sistema, sendo as duas primeiras linhas da tabela aquelas que o sistema não pode ficar sem.

---

## Regras de Negócio

Com a presença de diversas funcionalidades, deve haver junto às regras de negócio do sistema:

- **RN01**: Os perfis só são cadastrados pelo administrador
- **RN02**: Os administradores só são cadastrados pelo dev
- **RN03**: O administrador tem acesso a todas as funções
- **RN04**: O usuário só pode ter um perfil dentro do sistema e uma função
- **RN05**: Os ingressos devem ter um comprador identificado por CPF
- **RN06**: Só é possível dar baixa no ingresso uma vez só
- **RN07**: Os ingressos são comprados separadamente dos produtos
- **RN08**: Os produtos consumidos são pagos ao final do evento no fechamento da conta
- **RN09**: Só é possível dar baixa nos ingressos registrados como "pago"
- **RN10**: Somente o administrador pode gerar o relatório do evento

Para esse sistema é necessário definir quais dados o sistema irá usar; eles serão separados como "objetos" para melhor organização.

---

## Modelo de Dados

### USUÁRIO

| Campo | Tipo | Nulo | Descrição |
|---|---|---|---|
| id | int | não | Identificador do usuário |
| nome | string | não | Nome do usuário |
| email | string | não | Email do usuário |
| cpf | string | não | CPF do usuário |
| senha | string | não | Senha de acesso |
| data_cadastro | date | não | Data do cadastro |
| tipo_perfil | int | não | Tipo do perfil |

### COMPRADOR

| Campo | Tipo | Nulo | Descrição |
|---|---|---|---|
| id | int | não | Identifica comprador |
| nome | string | não | Nome comprador |
| cpf | string | não | CPF comprador |
| voluntario | int | não | Id voluntário que vendeu |
| tipo_ingresso | int | não | Id do tipo do ingresso |

### TIPO_PERFIL

| Campo | Tipo | Nulo | Descrição |
|---|---|---|---|
| id | int | não | Identificador do tipo de perfil |
| tipo_perfil | string | não | Tipo do perfil |

### MARMITAS

| Campo | Tipo | Nulo | Descrição |
|---|---|---|---|
| id | int | não | Identificador do tipo de marmita |
| tipo_marmita | string | não | Tipo da marmita |
| itens | string[] | não | Itens na marmita |

### INGRESSO

| Campo | Tipo | Nulo | Descrição |
|---|---|---|---|
| id | int | não | Identificador do ingresso |
| tipo_ingresso | string | não | Tipo do ingresso |
| data_compra | date | não | Data da compra |
| dado_baixa | boolean | não | Se foi dado baixa |
| baixa_ingresso | date | não | Data de quando foi dado baixa |

### INGRESSO_MARMITA

| Campo | Tipo | Nulo | Descrição |
|---|---|---|---|
| id | int | não | Identificador da ligação |
| id_marmita | int | não | Identificador marmita |
| id_ingresso | int | não | Identificador ingresso |

A seguir o diagrama principal do Banco de Dados

![sql-diagram](/docs/img.docs/sql-diagram.webp) \

---

## Técnologias Utilizadas
- ASP.NET Core
- postgreSQL
- EF Core
- JWT Token
- HTML5
- CSS3

---


> **Importante:** todas as análises podem ser alteradas futuramente. Todas as alterações na documentação podem ser acessadas em: [https://github.com/kaiserraf/gestao-encantando-sonhos](https://github.com/kaiserraf/gestao-encantando-sonhos)