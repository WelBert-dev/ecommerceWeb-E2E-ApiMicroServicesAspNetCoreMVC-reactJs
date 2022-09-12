

1. Usando o Duende IdentityServer - Templates e interface com usuário
    1. dotnet new --install Duende.IdentityServer.Templates 
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
 
