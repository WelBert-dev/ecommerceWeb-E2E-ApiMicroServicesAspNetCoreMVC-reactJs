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

2. Criando as primeiras entidades (classes de modelo): ProductModel e CategoryModel

    1.  

3. Criando as classes de contexto (conexão com MySQL) para mapear com Migrations:
    1. ./Context/AppDbContext.cs : DbContext -> injeção via construtor base().
    2. Mapeia as entidades/tabelas (./Context/AppDbContext.cs) methods:
        1. DbSet<CategoryModel> Categories get e set.
        2. DbSet<ProductModel> Products get e set.
    3. Referencia nos modelos os relacionamentos:
        1. ./Models/ProductModel.cs -> Aqui faz referência a categoria:
            1. CategoryModel? category get e set.
            2. reforça com int categoryId get e set.
        2. ./Models/CategoryModel.cs -> Aqui faz referência a coleção de Products:
            1. ICollection<ProductModel>? Products get e set.

4. Interligando o contexto com o program e por fim banco:
    1. Define em ./Models/setting.json a string de conexão.
    2. ./Program.cs -> Aqui faz as ligações
        1. Pega a string de conexão
        2. builder.Services.AddDbContext<>() -> faz a ligação utilizando UseMySql e ServiceVersio.AutoDetect()
