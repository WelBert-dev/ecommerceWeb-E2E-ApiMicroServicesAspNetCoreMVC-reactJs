# ecommerceWebApi-microServices-dotNetCore


1. Introdução e instalação de dependências:
    1. Criando template inicial:
        1. $ dotnet new webapi -o VShop.ProductApi -au none
    2. Instalando dependências iniciais:
        1. $ dotnet add package Pomelo.EntityFrameworkCore.MySql
        2. $ dotnet add package Microsoft.EntityFrameworkCore.Design
    3. Instalando ferramenta EF Core Migrations
        1. $ dotnet tool install --global dotnet-ef
        2. $ dotnet tool update --global dotnet-ef
