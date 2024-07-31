# API MongoDB - Demonstração com ASP.NET Core

## Descrição

Este projeto é uma API REST desenvolvida com ASP.NET Core para demonstrar a integração com o MongoDB. A API fornece operações básicas de CRUD para gerenciar duas entidades: `Book` e `Ticket`. Este projeto é uma demonstração simples de como utilizar MongoDB com ASP.NET Core, incluindo a criação, leitura, atualização e exclusão de documentos.

## Tecnologias Utilizadas

- **Linguagem**: C#
- **Framework**: .NET 8
- **Banco de Dados**: MongoDB
- **Driver**: MongoDB.Driver
- **Arquitetura**: Injeção de dependências

## Estrutura do Projeto

A estrutura do projeto está organizada da seguinte forma:

- **Models**: Contém os modelos de dados para cada entidade.
  - **Book**: Representa um livro com campos como nome, preço, categoria, autor e uma lista de IDs de tickets associados.
  - **Ticket**: Representa um ticket com campos como nome, código e ID do livro associado.

- **Services**: Contém a lógica de negócio para cada entidade. Os serviços realizam operações de CRUD e mantêm a integridade entre livros e tickets.
  - **BooksService**: Lógica para gerenciar livros.
  - **TicketsService**: Lógica para gerenciar tickets e atualizar a lista de tickets associados aos livros.

- **Controllers**: Contém um controlador para cada entidade, expondo os endpoints da API.
  - **BooksController**: API RESTful para operações CRUD na coleção `Books`.
  - **TicketsController**: API RESTful para operações CRUD na coleção `Tickets`.

- **Program.cs**: Arquivo de configuração onde são injetados os serviços e a lógica de inicialização.

## Funcionalidades

- **Livros**: CRUD completo para gerenciar livros.
  - **GET /api/books**: Obtém todos os livros.
  - **GET /api/books/{id}**: Obtém um livro específico por ID.
  - **POST /api/books**: Cria um novo livro.
  - **PUT /api/books/{id}**: Atualiza um livro existente.
  - **DELETE /api/books/{id}**: Exclui um livro pelo ID.

- **Tickets**: CRUD completo para gerenciar tickets.
  - **GET /api/tickets**: Obtém todos os tickets.
  - **GET /api/tickets/{id}**: Obtém um ticket específico por ID.
  - **POST /api/tickets**: Cria um novo ticket.
  - **PUT /api/tickets/{id}**: Atualiza um ticket existente.
  - **DELETE /api/tickets/{id}**: Exclui um ticket pelo ID.

## Requisitos
- MongoDB
- .NET 8


