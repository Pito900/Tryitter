# Boas-vindas ao repositório do Projeto da ACC de C#!

<details>
  <summary><strong>👨‍💻 Resumo do desenvolvimento</strong></summary>
  
  Nestre projeto desenvolvemos uma `API` e um `banco de dados` para do Tryitter. Desenvolvemos essa aplicação em `.NET 6` usando o pacote `Entity Framework`. Todos os endpoint estão disponíveis no swagger da aplicação.
</details>

<br />

# Para rodar o projeto localmente

Fizemos o docker da aplicação pensando em receber PRs e para que possam avaliar o projeto, localmente, sem problemas 😁. Para isso nada mais justo do que fazer um docker da aplicação e da base de dados.

<details>
  <summary><strong>🐋 O Docker do projeto</strong></summary>

  ## 👉 Aviso sobre a versão do docker compose:
 
  **:warning: Seu docker-compose precisa estar na versão 1.29 ou superior. [Veja aqui](https://www.digitalocean.com/community/tutorials/how-to-install-and-use-docker-compose-on-ubuntu-20-04-pt) ou [na documentação](https://docs.docker.com/compose/install/) como instalá-lo. No primeiro artigo, você pode substituir onde está com `1.26.0` por `1.29.2`.**

**:warning:** **TODOS** os comandos disponíveis no `package.json` (npm start, npm test, npm run dev, ...) devem ser executados **DENTRO** do container, ou seja, no terminal que aparece após a execução do comando `docker exec` citado acima. 

**:warning:** O **git** dentro do container não vem configurado com suas credenciais. Indico que realizem comandos com **git** fora do container (aonde suas credenciais estão cadastradas). 


  > :information_source: Utilizei o docker compose, então para que consiga rodar localmente o projeto é necessário que rode os serviços `.NET` e `db` com o comando `docker-compose up -d --build`.

  - A base de dados do desenvolvimento foi `sqlServer` e container irá executa, localmente, na porta padrão `1433`. Lembre-se de deixa-la livre.

  - Se chegou até aqui então conseguiu, ao ter executado o comando acima, criar e inicializar dois containers: os `Tryitter_api` e o `Tryitter_db`;

  - Agora você conseguirá executara o container `Tryitter_api` via CLI ou abri-lo no VS Code. Para ter acesso ao terminal interativo do container criado pelo compose basta rodar o comando a seguir.

  > :information_source: Use o comando `docker exec -it Tryitter_api bash`.

  - Lembre-se de instalar as depêndencias, dentro do container, com o seguinte comando: 
  > :information_source: Instale as dependências com o `dotnet restore`.

  <br/>
</details>



<br />

# Tecnologias
  <img align="center" alt="Js" height="30" width="40" src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/microsoftsqlserver/microsoftsqlserver-plain.svg" />

  <img align="center" alt="Js" height="30" width="40" src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/csharp/csharp-original.svg" />
    </div>
<br />

# Funcionalidades

Nessa rede social, as pessoas estudantes conseguem se cadastrar com nome, e-mail, módulo atual que estão estudando na Trybe, status personalizado e senha para se autenticar. É ser possível também alterar essa conta a qualquer momento, desde que a pessoa usuária esteja autenticada.

1 - Implementar um C.R.U.D. para as contas de pessoas estudantes;

2 - Implementar um C.R.U.D. para um post de uma pessoa estudante;:

3 - Alterar um post depois de publicado.
