# Sprint 01 - Problema do Usuário
Primeira Sprint será focada em entender o produto, criar storys, entender o problema real do usuário e criar soluções para isso, a seguir irei detalhar melhor.

---
## Parte 01 - Problema do Usuário
No dia 26/07 ocorreu a Feijoada Encantando Sonhos, um evento beneficente que tem como objetivo arrecadação de dinheiro para outros eventos beneficentes futuros, como distribuição de cestas básicas, brinquedos, etc.\
Nesse dia trabalhei como recepcionista do evento, e pude notar algumas coisas, não só na minha função, mas em outras, que dificultavam o fluxo de trabalho no evento, os problemas notados foram:

### Descentralização dos ingressos vendidos
Antes do evento realmente acontecer, um periodo de 2/3 meses antes, começa a venda dos ingressos, esses ingressos podem ser comprados de duas formas, **Oferecido por um voluntario da ONG** ou também **Comprado por uma bilheteria online**. \
Isso trouxe uma dificuldade durante o evento que foi a Descentralização dos ingressos vendidos, pois a plataforma de bilheteria on-line disponibilizava uma tabela com os ingressos comprados nela. Já os ingressos vendidos pelos voluntários da ONG eram inseridos em outra tabela gerenciada manualmente por um voluntario, essa tabela por vezes acabava com informações repetidas ou incompletas, o que gerava outro problema: **Falta de informações nos ingressos comprados**.

### Dependencia de somente um aparelho para multiplas funções
Por conta de todas as informações estarem concentradas em duas planilhas do Excel que estavam somente em um computador, isso trouxe uma dependencia enorme em somente um aparelho.

### Dificuldade de comunicação entre as funções
O fluxo durante o evento funcionada da seguinte forma:
![Fluxo](/docs/img.docs/fluxo-feijoada.png)
Entre os blocos **Validação Ingresso --> Ingresso já comprado/não comprado** e **Marmita --> Cozinha prepara** há troca de mensagens entre **Recepção <--> Caixa** e **Recepção/Caixa <--> Cozinha** por whatsapp, o que as vezes trás algumas dificuldades em relação a comunicação, já que nem sempre quem recebe a mensagem está com o celular ou está executando aquela função no momento.

---
## Parte 02 - Solução
Com todos esses problemas em mente a solução encontrada foi a criação de um web system focado em gerir os eventos da ONG, não só o almoço de feijoada, mas tabém eventos de doação, sorteios, etc. Mas a abertura para outros eventos é algo que será conversado e alinhado com a dona da ONG conforme necessidade. \
No geral, o sistema irá servir para melhorar o fluxo durante os eventos, centralizando os ingressos em apenas um painel, tirando a dependencia de somente um aparelho e melhorando a comunicação entre as partes através do envio e recebimento de notificações.

---
## Parte 03 - Funcionalidades e Funções
Cada função dentro do evento faz coisas que são especificas dela, o caixa por exemplo, vende novos ingressos na hora, cobra contas feitas, etc. a recepção, analisa os ingressos, faz pedido de marmita e caso a pessoa não tenha comprado o ingresso indica a pessoa para o caixa, a cozinha recebe as marmitas que tem que fazer e entrega para o cliente. \
Com base nas atividades de cada um foi criado a ideia de perfis dentro do sistema, cada perfil com suas funcionalidades especificas e funcionalidades compartilhadas.
![Funcionalidades](/docs/img.docs/funcionalidades.png)

---
## Parte 04 - O que o sistema deverá fazer?

- **RF01**: O sistema deverá gerar relatórios ao final do evento
- **RF02**: O sistema deverá permitir o cadastro de uma cozinha
- **RF03**: O sistema deverá permitir o cadastro de um caixa
- **RF04**: O sistema deverá permitir o cadastro de uma recepção
- **RF05**: O sistema deverá permitir enviar notificações para a cozinha
- **RF06**: O sistema deverá permitir o recebimento das notificações
- **RF07**: O sistema deverá permitir a visualização dos ingressos
- **RF08**: O sistema deverá permitir a aplicação de filtros nos ingressos
- **RF09**: O sistema deverá permitir o cadastro de novos ingressos
- **RF10**: O sistema deverá permitir dar baixa nos ingressos

## Parte 05 - Regras de Negócio
1. os perfis só são cadastrados pelo Admin
2. os Admin só são cadastrados pelo Dev
3. o Admin tem acesso a todas as funções
4. o usuario só pode ter um perfil dentro do sistema
5. os ingressos devem ter um comprador identificado por cpf
6. só é possivel dar baixa nos ingressos uma vez
7. os ingressos são comprados separadamente do produto
8. os produtos consumidos são pagos no fechamento da conta
9. só é possivel dar baixa nos ingressos uma vez
10. somente o Admin pode gerar os relatórios
11. o Admin pode gerenciar os perfis dentro do sistema
12. o ingresso de almoço no local é limitado a um por cpf
13. os ingressos de marmita não tem limitação por cpf
14. um relatório só pode ser gerado ao final do evento