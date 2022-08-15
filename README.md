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
    3. $ dotnet ef database update -> roda a migração criada (necessário realizar o step 7 antes)

7. Instalação e uso do EF Core Migrations ($ dotnet ef):
    1. ./$ dotnet tool install --global dotnet-ef 
    2. ./$ dotnet tool update --global dotnet-ef
    3. Uso: 
        1. ./$ dotnet ef migrations add <nome-migração> (Inicial)
        2. ./$ dotnet ef migrations remove 
        3. ./$ dotnet ef database update -> Roda as migrações criadas (cria por fim as tabelas)
    4. Output:
        1. Vai ser criado uma pasta na raiz "Migrations", contendo nela as migrações.

8. Populamento inicial em Products para testes:
    1. $ dotnet ef migrations add Inicial -> vai gerar uma migração vazia
    2. Editar a migração com o comando:
        1. no método Up(): migrationsBuilder.Sql("INSERT INTO products....");
        2. ainda no método Up() adicionar mais linhas de migrationsBuilder.Sql("INSERT INTO...")
    3. Em caso de B.O deleção automática:
        1. no método Down(): migrationsBuilder.Sql("delete from products");
    4. $ dotnet ef database update

9. Criando os DTO's (Data Transfer Object) do projeto:
    1. Definição: Padrão de projeto usado para transportar dados entre diferentes componentes de um sistema, diferentes instâncias ou processos de um sistema distribuído ou diferentes camadas em um aplicativo.
    2. Em uma API teremos a seguinte estrutura:
        1. Client <usa> API{ [Controller] -> [Service] -> [Repository]<usa>[Database] }.
            1. Controller: Atende os Requests.
            2. Service: Contém a lógica aplicada (regras de negócios).
            3. Repository: Acessa por fim os dados no banco.
        2. Quando um Client faz o request:
            1. Ele o faz utilizando um DTO:
            2. O [Controller] recebe e re-passa para a camada de [Service].
            3. A Lógica é aplicada (regras de negócios) mapeando assim os DTO's nas entidades de seu domínio, 
            4. repassando a <Entity> para o [Repository]:
                1. Client-<usa-[DTO-]--API{-> [Controller]-[DTO]-> [Service parsing [DTO]<=>[ENTITY]] [ENTITY]-> [Repository atua utilizando a entidade para reculperar ou persistir dados]<usa>[Database] }.
            5. Ao final, os dados voltam nas camadas anteiroes a chamada (retornando ao chamador):
                1. {[Database] --[ENTITY]-> [Repository] -[ENTITY]-> [Service parsing [ENTITY]<=>[DTO]]-> -[DTO]-> [Controller] -[DTO]-> Client que fez a chamada recebe resultado do request}

        3. Em [Service] iremos utilizar AutoMapper para as conversões [DTO]<=>[ENTITY].
    3. Vantagens: 
        1. Permite ocultar o modelo de domínio do mundo externo (criando uma abstração).
        2. Facilita o versionamento dos endpoints.
            1. Pois em caso de mudanças no domínio da aplicação, 
            não será necessário alterar o código [DTO] anterior,
            más sim criar novos [DTO's] que atendem a nova versão, 
            avisando assim os usuários sobre a nova versão, e solicitando migração.
        3. Pela lógica estar contida em [Services], não será necessário em caso de alterações
        mudanças em [Repository], e sim ficando tudo concentrado em [Service], ou seja divide as
        tarefas corretamente, pois [Repository] é uma abstração das Entidades, então
        o papel dela é apenas mapear Entidades, ficando a lógica apenas na camada de [Service].
        4. DTO's são DIFERENTES de VO's!

    4. AutoMapper: Mapeador orientado a objetos baseado em convensões, que irá transformar
        um obejto de origem em um objeto de destino. 
        1. Instalar os pacotes:
            1. ./$ dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
            2. ./$ dotnet add package AutoMapper
        2. Configurar os serviços na classe Program.cs:
            1. builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            2. isto faz o AutoMapper detectar em quais assemblie's os Profiles (que sera implementado após) contém os mapeamentos que foram definidos.
                1. isto é possível pois pegamos os assemblies do contexto atual de execução com:
                    1. AppDomain.CurrentDomain.GetAssemblies();
                
        3. Definir o mapeamento entre objetos: DTO's e Entidades(Profile) [DTO]<=>[ENTITY]
            1. Esses Profiles permitem organizar o mapeamento em uma classe, facilitando assim a manutenção do código.
        4. Injetar a interface IMapper e fazer o mapeamento
            1. utilizando Dependency Injection.
            2. na camada de serviços (isso é muito importante!)
