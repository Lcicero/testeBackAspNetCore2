## Recursos Utilizados: :computer:

Se faz necessário realizar a instalação das aplicações/frameworks abaixo:

* Visual Studio Code

    - [Visual Studio Code](https://code.visualstudio.com/)
    - [.NET Core SDK](https://www.microsoft.com/net/download)

* Visual Studio

    - [Visual Studio](https://bit.ly/2zBXxF8)
    - [.NET Core 2.x](https://www.microsoft.com/net/download)
   
 ## Design pattern :blue_book:

Design pattern na solução de backEnd:

* Repository : gerenciamento de acesso a dados.
* MVC : separa a representação da informação da interação do usuário com ela. Normalmente usado para o desenvolvimento de interfaces de usuário que divide uma aplicação em três partes interconectadas.
 
 ## Arquitetura: :pencil2:
 
 * TesteBack.Model : modelo de dominio do negocio.
 * TesteBack.Repository: reponsavel pelo acesso a dados.
 * TesteBack.Test : responsavel pelos teste(TDD).
 * TesteBack.WebAPI : resposanvel por expor api Rest.
 
 ## Executando o Projeto Localmente :fire:
 
  * criar a database com o scrpit testesql
  * configurar a porta do IIS Express para rodar na porta 5000
  * restaurar os packge com nuget
  * executar a aplicação
 
