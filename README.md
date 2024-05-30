# .NET & VS-Code com Clean Architecture

Este projeto foi criado utilizando a arquitetura limpa (Clean Architecture) com .NET 8 e o Visual Studio Code.

## Estrutura do Projeto

1. Primeiro, crie o diretório com o nome do projeto:
    ```bash
    mkdir MeuProjeto
    cd MeuProjeto
    ```

2. Crie a solução:
    ```bash
    dotnet new solution
    ```

3. Crie os projetos:

    - **Domain**:
        ```bash
        mkdir MeuProjeto.Domain
        cd MeuProjeto.Domain
        dotnet new classlib
        ```
    - **Application**:
        ```bash
        mkdir MeuProjeto.Application
        cd MeuProjeto.Application
        dotnet new classlib
        ```
    - **CrossCutting**:
        ```bash
        mkdir MeuProjeto.CrossCutting
        cd MeuProjeto.CrossCutting
        dotnet new classlib
        ```
    - **API**:
        ```bash
        mkdir MeuProjeto.Api
        cd MeuProjeto.Api
        dotnet new webapi
        ```

4. Remova as classes geradas automaticamente:
    - Nos projetos `classlib`, delete `Class1.cs`.
    - No projeto `webapi`, delete o `WeatherForecastController.cs`.

## Adicionando as Referências

Adicione as dependências entre os projetos de acordo com a arquitetura limpa:

1. Comando CLI de dependência do projeto (Prompt).
2. Execute o comando:
    ```bash
    dotnet add reference ..\NomeDoDiretorio\NomeDoDiretorio.csproj
    ```
3. Comando CLI de dependência do projeto (Git Bash).
4. Execute o comando:
    ```bash
    dotnet add reference ../NomeDoDiretorio/NomeDoDiretorio.csproj
    ```

## Estrutura de Dependências

### Domain

- **Descrição**: O núcleo da lógica de negócio. Contém as entidades do domínio e regras de negócio.
- **Dependências**: Nenhuma. Por se tratar da camada mais interna do núcleo.

### Application

- **Descrição**: Contém a lógica de aplicação, incluindo serviços, casos de uso e interfaces. Serve como intermediário entre a camada de domínio e outras partes da aplicação.
- **Dependências**: Depende do projeto `Domain`.

### Infrastructure

- **Descrição**: Contém os detalhes da persistência de dados, implementações de repositórios e outros serviços de infraestrutura.
- **Dependências**: Depende do projeto `Domain`.

### CrossCutting

- **Descrição**: Contém preocupações transversais, como log, autenticação, autorização,indejeções de dependências, etc. Estas são funcionalidades que afetam várias partes da aplicação.
- **Dependências**: Depende dos projetos `Domain`, `Application` e `Infrastructure`.

### API

- **Descrição**: Camada de apresentação. Expõe os endpoints da API para os clientes. Deve acessar as funcionalidades transversais através do projeto `CrossCutting`.
- **Dependências**: Depende do projeto `CrossCutting`.

## Detalhamento dos Princípios de Arquitetura Limpa

### Domain (Núcleo da Lógica de Negócio)

- **Responsabilidade**: O núcleo do sistema onde reside a lógica de negócio mais importante. Define as entidades do domínio e suas regras de negócio sem depender de nenhuma outra camada ou tecnologia específica.
- **Princípios**: Independência de tecnologia, frameworks, bancos de dados, e camadas externas. Qualquer mudança em camadas externas não deve afetar a camada de domínio.

### Application (Lógica da Aplicação)

- **Responsabilidade**: Orquestra a lógica de uso da aplicação, chamando a lógica de negócio do `Domain` e delegando operações para as camadas externas. Define interfaces para as operações que precisam ser implementadas pelas camadas de infraestrutura.
- **Princípios**: Depende apenas do `Domain`, garante a separação das regras de negócio (no `Domain`) e das funcionalidades específicas de aplicação.

### Infrastructure (Detalhes da Persistência de Dados)

- **Responsabilidade**: Implementa os detalhes das interfaces definidas na camada de `Application`. Cuida da persistência de dados, comunicações com serviços externos, etc.
- **Princípios**: Deve conhecer e implementar contratos definidos em `Application`, mas `Application` não deve conhecer implementações específicas em `Infrastructure`.

### CrossCutting (Preocupações Transversais)

- **Responsabilidade**: Implementa funcionalidades que são transversais a toda a aplicação, como logging, tratamento de erros, segurança, etc.
- **Princípios**: Deve ser utilizado pelas outras camadas (`Domain`, `Application`, `Infrastructure`), mas idealmente mantém baixo acoplamento, fornecendo serviços genéricos e reutilizáveis.

### API (Camada de Apresentação)

- **Responsabilidade**: Expõe a API pública da aplicação. Trata das requisições HTTP, validações, e delega a lógica de negócio e aplicação para as camadas internas.
- **Princípios**: Depende da camada `CrossCutting` para acessar funcionalidades transversais, mantendo a lógica de apresentação desacoplada das camadas de negócio e aplicação.

## Conclusão

Seguindo a arquitetura limpa, garantimos que nossa aplicação seja flexível, testável e fácil de manter. A separação clara entre as camadas permite que cada parte do sistema evolua independentemente, minimizando o impacto das mudanças e facilitando a adição de novas funcionalidades.
