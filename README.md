# ecommerceWebApi-microServices-dotNetCore

# Data Criação: 13/08/2022.
# Licença: GPL v3.0.
# Objetivo: Treinamento e implementação de um Ecommerce Web Básico (AspNetCoreMVC).
# Pré requisitos: C# Intermediário, AspNetCore, EntityFrameworkCore, MySQL, HTML5 CSS3 JavaScript.
# Paradigmas: POO, MVC, DTO's, REST, API MicroServices.
# Fonte base de estudos: Macoratti, StackOverFlow, IFSP, CFBCursos.
# Obejetivos futuro: Parsing cloneAmazon-E2E-react <=> cloneAmazon-E2E-AspNetCore.
# cloneAmazon-E2E-react em andamento: https://github.com/WelBert-dev/amazonClone-E2E-react

1. Ferramentas utilizadas:
 
    1. BackEnd (API): Asp.NetCore Web API (Finalizado 17/08/2022 - Básico)
        1. Namespace: VShop.Products 
        2. Detalhes e step by step de implementação e correção de bugs em: /VShop.Products/README.md
        3. Arquitetura adotada: MVC
        4. Banco de dados: MySQL
    2. FrontEnd (Apresentação web): Asp.NetCore Web MVC (Em andamento)
        1. Namespace: VShop.Web
        2. Detalhes e step by step de implementação e correção de bugs em: /VShop.Products/README.md
        3. Arquitetura: MVC

2. Fontes/Créditos: Macoratti
    1. PlayList completa: https://www.youtube.com/playlist?list=PLJ4k1IC8GhW1UtPi9nwwW9l4TwRLR9Nxg
    2. Modificações foram feitas ao longo da implementação! 

3. Ideias futuras:
    1. Utilizar o projeto como base e parsing "amazonClone-react" <=> "amazonClone-AspNetCore"
    2. Parsing reactjs <=> Asp.NetCore MVC
    3. Projeto "amazonClone-react" em andamento: https://github.com/WelBert-dev/amazonClone-react

4. Conceitos/Paradigmas/Códigos utilizados:
    1. BackEnd (API):
        1. REST (80%)

        2. Contexto: DBContext (EntityFrameworkCore) -> /VShop.Products/README.md -> Step 3 e 4

        3. Fluent API -> /VShop.Products/README.md -> Step 5 e 6
            1. Sobrescrevendo convensões do EF (antes de utilizar Migrations)
            2. Foi adotado para não poluir o código com Data Annotations nos Models.

        4. Migrations -> /VShop.Products/README.md -> Step 5, 6, 7, 8
            1. Utilizado para unir Banco e Aplicação (Data Dicionary)
            2. Utilizamos Fluent API antes das migrações para definição correta dos campos no DB
            3. Criamos as tabelas, e inserimos os primeiros registros para testes
            4. Pasta com as migrações: /VShop.Products/Migrations

        5. DTO's -> /VShop.Products/README.md -> Step 9
            1. Data Transfer Objects: Paradigma utilizado para converter Entidades em DTO's
            2. Fonte mais detalhada: https://pt.stackoverflow.com/questions/31362/o-que-%C3%A9-um-dto
            3. Client<\usa>API{ [Controller] -> [Service] -> [Repository]<\usa>[Database] }.
            4. Detalhes mais ponfundos em Step 9 (Step mais complexo rsrsrs).
        
        6. Correção de Bugs (Relacionamento nos Models) -> Step 13 e 14
            1. Error: A possible object cycle was detect
            2. Correção: Json Ignore 
            3. Detalhes mais profundos nos Steps

        7. Detalhes mais profundos nos Steps
            1. Alguns steps foram ignorados por ser "Básico" 
            2. Pré requisitos para entendimento: 
                1. Arquitetura MVC 
                2. Banco de dados
                3. AspNetCore EntityFramework

    2. FrontEnd (Web): Em andamento

