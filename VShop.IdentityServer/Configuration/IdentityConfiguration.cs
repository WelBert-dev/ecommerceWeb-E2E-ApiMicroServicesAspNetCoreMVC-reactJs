using Duende.IdentityServer.Models;
using Duende.IdentityServer;

namespace VShop.IdentityServer.Configuration;

public class IdentityConfiguration
{
    public const string Admin = "Admin";
    public const string Client = "Client";


    // Define a lista de Resources
    public static IEnumerable<IdentityResource> IdentityResources => 
        new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile()
        };

    // Define a lista de escopos (Permissões da aplicação que irá acessar)

    public static IEnumerable<ApiScope> ApiScopes => 
        new List<ApiScope>
        {   
            // vshop é a aplicação web que vai acessar 
            // o IdentityServer para obter o token
            new ApiScope("vshop", "VShop Server"),
            new ApiScope(name: "read", "Read data."),
            new ApiScope(name: "write", "Write data."),
            new ApiScope(name: "delete",  "Delete data."),
        };

    // Define a lista de Clientes que iram acessar 

    public static IEnumerable<Client> Clients => 
        new List<Client>
        {
            // cliente genérico
            new Client 
            {
                ClientId = "client",
                ClientSecrets = { new Secret("abracadabra#simsalabim".Sha256())},
                AllowedGrantTypes = GrantTypes.ClientCredentials, // precisa das cedenciais do usuário
                AllowedScopes = { "read", "write", "profile" }
            },
            new Client
            {
                ClientId = "vshop",
                ClientSecrets = { new Secret("abracadabra#simsalabim".Sha256())},
                AllowedGrantTypes = GrantTypes.Code, // via codigo
                RedirectUris = {"https://localhost:7165/signin-oidc"}, // login
                PostLogoutRedirectUris = {"https://localhost:7165/signout-callback-oidc"}, // logout
                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    "vshop"
                }
            }
        };
}
