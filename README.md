# Gestão Encantando Sonhos
Projeto criado e destinado para ajudar a ONG Encantando Sonhos em um de seus projetos, a ideia é organizar e melhorar o fluxo da administração dentro da famosa **Feijoada Beneficente**, o intuito do sistema é ter o facil acesso a ingressos comprados, levantamento de gasto/lucro do evento. \
Futuramente a ideia do projeto é crescer, englobando outros eventos, como **doações, compra de cesta básica, sorteis, rifas, etc.**, por enquanto ele é apenas um simples sistema de gerenciamento. \
Para saber mais sobre a ONG ENCANTANDO SONHOS sinta-se a vontade para visitar as redes sociais, e se for tocado pelas ações, considere entrar em contato para fazer uma doação ou ajudar de outra forma:

<img width="12" />
<a href="https://www.facebook.com/ongencantandosonhos">
<img src="https://cdn.simpleicons.org/facebook/1877F2" height="40" alt="facebook logo"  />
</a>
<img width="12" />
<a href="https://www.instagram.com/encantandosonhos/">
<img src="https://cdn.simpleicons.org/instagram/E4405F" height="40" alt="instagram logo"  />
</a>
<img width="12" />

## Requisitos
Para rodar o projeto sem erros, é necessário ter:
- PostgreSQL 18+
- .NET 10.0+
- EF Core 10.0+

## Configuração do projeto
Para configurar o banco de dados, primeiro crie um banco no seu postgreSQL, e configure o `appsettings.json` com as suas informações, você saberá o que tem nele olhando o `appsettings.Example.json`, as principais informações são:

```json
"ConnectionStrings": {
    "DefaultConnection": "Host=[host];Port=[port];Database=[database_name];Username=[admin_user];Password=[senha_db]"
  },
  "Jwt":{
    "Key" : "Chave_32_caracteres",
    "Issuer" : "ISUER",
    "Audience" : "AUDIENCE"
  }
```

Em seguida, você precisa instalar todas as dependências que o sistema exige, rodando os seguintes comandos:

```powershell
cd GesApi
dotnet restore
```

Em seguida, rode a migração para o banco de dados:

```powershell
dotnet-ef database update
```

Esse comando gera todas as tabelas para o banco de dados, em seguida você pode iniciar a Api com:

```powershell
dotnet run
```