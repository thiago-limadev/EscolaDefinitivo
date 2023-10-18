# Escola Definitivo

Aqui, a ideia é que você seja a pessoa responsável por tornar o processo de matrícula e acompanhamento dos cursos mais simples e eficiente. Você terá dois tipos de acesso: como administrador, que permite cadastrar e controlar os perfis dos usuários na plataforma, e como usuário padrão, que pode cadastrar alunos e escolher cursos. O projeto visa explorar conceitos como MVC, relacionamento de tabelas, Entity Framework e versionamento de código no GitHub. Estou empolgado em compartilhar essa jornada de aprendizado e espero que aproveitem cada etapa do caminho.

### Ajustes e melhorias futuras 📌

O projeto ainda está em desenvolvimento e as próximas atualizações serão voltadas nas seguintes tarefas:

- [x] Elaboração do projeto
- [x] Disponibilização de forma funcional no Github
- [ ] Estilização de paginas
- [ ] Implementação de Endereços com autopreencher

     
## 🚀 Começando

Essas instruções permitirão que você obtenha uma cópia do projeto em operação na sua máquina local para fins de desenvolvimento e teste.


### 📋 Pré-requisitos

Antes de começar, verifique se você atendeu aos seguintes requisitos:

* Você instalou a versão mais recente de `<.Net / SQL Server >`
* Você instalou a versão mais recente dos Pacotes `<Microsoft.EntityFrameworkCore / Microsoft.EntityFrameworkCore.Design / Microsoft.EntityFrameworkCore.SqlServer / Microsoft.EntityFrameworkCore.Tools / Newtonsoft.Json>`.
* Você tem uma máquina `<Windows >`.

Além disto é bom ter um editor para trabalhar com o código.

### 🔧 Instalação

Para começar, você precisa clonar este repositório no seu ambiente local(caso prefira você pode realizar o download do arquivo Zip):

```bash
# Clone este repositório
git clone https://github.com/thiago-limadev/EscolaDefinitivo.git

# Acesse a pasta do projeto no terminal
cd sua-pasta-destino

#Abra o arquivo com Visual Studio

#Instale os pacotes através gerenciador de pacotes
Vá em Ferramentas -> Gerenciador de Pacotes do NuGet -> Gerenciar Pacotes do NuGet para Solução..
Instale / atualize  os pacotes necessários da aplicação : Microsoft.EntityFrameworkCore / Microsoft.EntityFrameworkCore.Design / Microsoft.EntityFrameworkCore.SqlServer / Microsoft.EntityFrameworkCore.Tools / Newtonsoft.Json

#Crie a Migration através do Entity Framework com este comando no seu console
Add-Migration InitialCreate EscolaContext -context

#Em Seguida excute o comando de atualizar o banco de dados para confirma a criação no banco de dados
Update-Database

# Dê play na aplicação
Aperte F5
 ````

## ⚙️ Executando os testes

Quando você tiver realizado todos os passos do projeto verá a tela de login

<p> ![image](https://github.com/thiago-limadev/EscolaDefinitivo/assets/109220721/ae8ffa9e-d03d-4172-b27f-f7fadeb1e44f) </p>

Para logar basta inserir o Login e Senha do Administrador que foram criados automaticamente.

<p >Login: Admin</p>
<p > Senha: Admin123</p>

<h4>Login efetuado</h4>
Após realizar o login você será redirecionado para página inicial 
<p> ![image](https://github.com/thiago-limadev/EscolaDefinitivo/assets/109220721/311a7752-b4a2-4f37-bb81-524aab264dd1) </p>

A partir daqui você já pode explorar a funcionalidades tendo na barra de navegações as opções para navegar no sistema, assim como ações rápidas com os botões na tela.


 
## ⚙️ Executando os testes

Caso queira realizar alguns testes antes mesmo de logar, deixo de sugestão tentar acessar outras páginas da aplicação através do URL, para isto basta adicionar algum destes complementos a seu url localhost:suaporta(uma pequena numeraçoa) com: /aluno ou /curso.
Este teste deverá lhe redirecionar para página de login novamente impendindo-o de prosseguir no sistema se não estiver logado.

Também é possível realizar tentativas de login errados, sem senha e com senha errada. Todos estes casos deverão lhe retornar uma informação sobre o erro.


## 🛠️ Construído com

Mencione as ferramentas que você usou para criar seu projeto

* [Entity Framework](https://learn.microsoft.com/pt-br/ef/#desenvolver-com-o-entity-framework-core) - O framework usado para gerenciamento do Banco de Dados
* [MVC](https://learn.microsoft.com/pt-br/aspnet/core/mvc/overview?view=aspnetcore-7.0) - Padrão de Arquitetura
* [Bootstrap](https://getbootstrap.com.br/docs/4.1/getting-started/introduction/) - Usada para estilização

## ✒️ Autores

Mencione todos aqueles que ajudaram a levantar o projeto desde o seu início

* **Euzinho** - *Desenvolvimento do Projeto* - [Thiago Lima](https://github.com/thiago-limadev/)

## 🎁 Expressões de gratidão

* Quero deixar aqui registrado a minha gratidão aos meus amigos que me apoiaram durante essa jornada:
   - Jaqueline Lima - Esposa e amor da minha vida, que vem me apoiando e dando todo o suporte desde início da minha jornada como desenvolvedor;
   - Fabricio Begalli - Quem teve a ideia do desafio e me impulsionou a criar o projeto;
   - Paulo Gabriel - Papel fundamental para o aprendizado de relacionamento de tabelas, estrutura e organização do projeto
   - William Viegas - Apoio no desenvolvimento sanando dúvidas e auxiliando compartilhando conhecimento e me incentivando a ir além;
   - Marlon Brando - Apoio moral rsrs, mesmo não conhecendo sobre a linguagem e sendo uma área diferente da sua esteve ao meu lado durante quase todo o desenvolvimento;
     



