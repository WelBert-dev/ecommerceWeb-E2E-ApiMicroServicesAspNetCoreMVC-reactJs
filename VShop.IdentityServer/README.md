

1. Usando o Duende IdentityServer - Templates e interface com usuário
    1. $ dotnet new --install Duende.IdentityServer.Templates 
    2. Templates UI do Duende baixados do repo macoratti
        1. Pois gerar com o comando iria baixar razor pages e a abordaegm que tomaremos sera MVC.
    3. Controller sera modificada para "MainModule" 
    4. Arquivos baixados: Views, MainModule, wwwroot 

2. Utilizando o Duende IdentityServer - Referências/Dependências Iniciais
    1. Instalar a referência do Duende:
        1. $ dotnet add package Duende.IdentityServer.AspNetIdentity
    2. Incluir as referências do Identity da ASP.NET Core:
        1. $ dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
        2. $ dotnet add package Microsoft.AspNetCore.Identity.UI
    3. Incluir a referência Pomelo para MySQL
        1. $ dotnet add package Pomelo.EntityFrameworkCore.MySql
        2. $ dotnet add package Microsoft.EntityFrameworkCore.Design

3. Utilizando o Duende IdentityServer - Configuração
    1. Criar a pasta Data no projeto VShop.IdentityServer
        1. Crias a classe ApplicationUser que herda de IdentityUser
        2. Criar a classe AppDbContext que herda de IdentityDbContext<ApplicationUser>
    2. Configurar a String de conexão em appsettings.json
    3. Registrar o serviço do contexto no container DI na classe Program.cs
    4. Registrar o serviço do Identity na classe Program.cs
    5. Criar a pasta Configuration no projeto VShop.IdentityServer
        1. Criar a classe IdentityConfiguration (Definir: Resources, Scopes e Clients)
            1. Utilizando o namespace Duende.IdentityServer.Models;
            2. Utilizando tambem o namespace Duende.IdentityServer;

    6. Injeta o Identity em Program.cs utilizando o namespace: using Microsoft.AspNetCore.Identity;
        1. Adiciona middleware do IdentityServer após buildar:
            1. app.UseIdentityServer();
    7. Configurar os serviços do IdentityServer em Program.cs (injetar no container DI)
        1. Antes de buildar

4. Podemos aplicar a primeira Migrations:
    1. Instalando dependências:
        1. Ferramenta EF Core Tools
            1. $ dotnet tool install --global dotnet-ef
            2. $ dotnet tool update --global dotnet-ef
        2. Aplicar a migrations:
            1. $ dotnet ef migrations add CriaDatabaseIdentityServer
            2. $ dotnet ef database update

5. Cria os primeiros 2 users na tabela do IdentityServer (Client e Admin) em ./SeedDatabase
    1. Criar a interface de assinatura IDatabaseSeedInitializer:
        1. void InitializeSeedRoles();
        2. void InitializeSeedUsers();
    2. Implementar elas injetando via construtor utilizando recursos do namespace Identity.
    3. Injetar o serviço no container DI Program.cs antes de buildar.
    4. Finalmente roda o método ao rodar Program.cs utilizando uma instância do proprio program em tempo de execução:
        1. após app.Run() define o método;
            1. void SeedDatabaseIdentityServer(IApplicationBuilder app)
            {
                using (var serverScope = app.ApplicationServices.CreateScope())
                {
                    var initRolesUsers = serviceScope.ServiceProvider.GetService<IDatabaseSeedInitializer>();

                    initRolesUsers.initializeSeedRoles();
                    initRolesUsers.initializeSeedUsers();
                }
            }
        2. Antes de app.Run() roda o método definido chamando e passando a instancia de app

6. Fluxograma de funcionamento:
    1. Web <Obter Token ( Login )> -> Duende IdentityServer <Valida e desonve Token> -> Web <Request mandando no body o Token> -> ProductApi <Validação e devolve recurso> -> 
    2. Web manda uma requisição ao Duende e realiza login.
    3. Duende valida informação e manda Token de acesso ao Web.
    4. Web Faz requisição ao ProductApi passando o Token.
    5. ProductApi faz validação e devolve recurso. 

7. Para isto, devemos implementar agora a Autenticação e Autorização:
    1. Inicialmente iremos definir a segurança protegendo os Endpoints, tanto no web quanto na api.
        1. Implementar a segurança com atributo Authorize nos Controllers.
            1. Na ProductApi iremos utilizar os dataAnnotations do AspNet
                1. ProductsController : POST: [Authorize] e DELETE: [Authorize(Roles = Role.Admin)]
                2. CategoriesController : POST: [Authorize] e DELETE: [Authorize(Roles = Role.Admin)]
            2. No Web como é outra tecnologia futuramente irei buscar mais conhecimento.
    2. Alguns ajustes para prosseguir.

