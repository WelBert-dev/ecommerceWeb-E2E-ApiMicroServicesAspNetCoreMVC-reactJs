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
    1. Define em ./setting.json a string de conexão.
    2. ./Program.cs -> Aqui faz as ligações
        1. Pega a string de conexão
        2. builder.Services.AddDbContext<>() -> faz a ligação utilizando UseMySql e ServiceVersio.AutoDetect()

5. Sobrescrevendo as convenções do EF Core (antes do Migrations): Necessário pois por default as strings var ser parseadas em lontext no MySQL (longtext = até 4GB de Armazenamento, que é muito), então vamos definir para VARCHAR(), e as decimal também.
    1. Possíveis soluções:
        1. Data Annotations: (Não iremos utilizar)
            1. Definição: Fornece atributos de classes (usados para definir metadados) e métodos que
            podemos usar em nossas classes para alterar as convensões padrão e definir um comportamento
            personalizado que pode ser usado em vários cenários.     
            2. NameSpaces: 
                1. System.ComponentModel.DataAnnotations
                2. System.ComponentModel.DataAnnotations.Schema
            3. Modo de uso: (informar a Data Annotations antes da entidade) Ex. Entity's: Name, Price
            nos ./Models/EntityModel.cs:
                1. Name: [Required(ErrorMessage="O nome de user é obrigatório!")]
                         [StringLength(100)]
                         public string Name {get; set; }
                2. Price: [Column(TypeName="decimal(12,2)")]
                          public decimal Price {get; set; }
            4. Desvantagem: Poluição dos Modelos (pois devemos escrever essas convenções nas Entidades)

        2. Fluent API: EntityFrameworkCore: (Iremos utilizar!)
            1. Definição: É usada para configurar as classes de domínio para substituir convenções.
            É definida sobrescrevendo o método OnModelCreating na classe de context (./Context/AppDbContext)
            2. Codigo em ./Context/AppDbContext.cs: protected override void OnModelcreating(ModelBuilder modelBuilder)
            3. Vantagem: Não faz poluição dos modelos e é mais poderoso que Data Annotations!
            4. Vamos utilizar está abordagem!


6. Fluent API - Sobrescrevendo as convenções default do Migrations:
    1. em ./Context/AppDbContext.cs:
        1. No Final das entidades:
            1. Cria method: protected override void OnModelCreating(ModelBuilder mb)
    2. $ dotnet ef migrations add Inicial

7. Instalação e uso do EF Core Migrations ($ dotnet ef):
    1. ./$ dotnet tool install --global dotnet-ef 
    2. ./$ dotnet tool update --global dotnet-ef
    3. Uso: 
        1. ./$ dotnet ef migrations add <nome-migração> (Inicial)
        2. ./$ dotnet ef migrations remove 
        3. ./$ dotnet ef database update -> Roda as migrações criadas (cria por fim as tabelas)
    4. Output:
        1. Vai ser criado uma pasta na raiz "Migrations", contendo nela as migrações.



            