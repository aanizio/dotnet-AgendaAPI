# WebAPI de Agenda

API para consultar, criar, atualizar e deletar contatos em uma agenda.

## Rodar

Instale o .NET SDK 6.

Garanta que tenha o MySQL rodando ou rode com Docker utilizando `docker-compose up`.

Na pasta do projeto, é preciso rodar o migration do banco de dados e rodar a API:

```
dotnet run .
```

No VS Code, é possível utilizar o comando `Ctrl+F5`.

## Testes

```
dotnet test AgendaAPI.Testes/
```

## Todo

-OK Informações MYsql de app config
- Criar classes de domínio. Exemplo seria criar uma classe Telefone e Email, que valide e tenha métodos específicos.
- Evitar nulos na entidade Contato
- Testes unitários
- Remove Mysql's dbContextOptions for production
- Validação do email e telefone
- vs code tasks add test
- Melhorar e corrigir testes de telefone
