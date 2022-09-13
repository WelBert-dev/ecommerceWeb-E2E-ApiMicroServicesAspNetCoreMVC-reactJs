using Microsoft.AspNetCore.Identity;
using VShop.IdentityServer.Configuration;
using VShop.IdentityServer.Data;

using System.Security.Claims;
using IdentityModel;

namespace VShop.IdentityServer.SeedDatabase;

public class DatabaseIdentityServerInitializer : IDatabaseSeedInitializer
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public DatabaseIdentityServerInitializer(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public void InitializeSeedRoles()
    {
        // Se o perfil admin não existir então cria o perfil
        if (!_roleManager.RoleExistsAsync(IdentityConfiguration.Admin).Result)
        {
            // cria o perfil admin
            IdentityRole roleAdmin = new IdentityRole();
            roleAdmin.Name = IdentityConfiguration.Admin;
            roleAdmin.NormalizedName = IdentityConfiguration.Admin.ToUpper();
            _roleManager.CreateAsync(roleAdmin).Wait();
        }
        // se o perfil client não existir então cria o perfil
        if (!_roleManager.RoleExistsAsync(IdentityConfiguration.Client).Result)
        {
            // cria o perfil client
            IdentityRole roleClient = new IdentityRole();
            roleClient.Name = IdentityConfiguration.Client;
            roleClient.NormalizedName = IdentityConfiguration.Client.ToUpper();
            _roleManager.CreateAsync(roleClient).Wait();
        }
    }
    public void InitializeSeedUsers()
    {
        // se o usuário admin não existir cria o usuário, define senha e atribui ao perfil
        if (_userManager.FindByEmailAsync("admin1@com.br").Result is null)
        {
            // define os dados do usuário admin
            ApplicationUser admin = new ApplicationUser()
            {
                UserName = "admin1",
                NormalizedUserName = "ADMIN1",
                Email = "admin1@com.br",
                NormalizedEmail = "ADMIN1@COM.BR",
                EmailConfirmed = true,
                LockoutEnabled = false,
                PhoneNumber = "+55 (11) 9 4298-9935",
                FirstName = "Usuario",
                LastName = "Admin",
                SecurityStamp = Guid.NewGuid().ToString()
            };

            // cria o usuário admin e atribui a senha
            IdentityResult resultAdmin = _userManager.CreateAsync(admin, "Numsey#2022").Result;
            if (resultAdmin.Succeeded)
            {
                // inclui o usuário admin1 ao perfil admin
                _userManager.AddToRoleAsync(admin, IdentityConfiguration.Admin).Wait();

                // inclui as claims do usuário admin

                var adminClaims = _userManager.AddClaimsAsync(admin, new Claim[]
                {
                    new Claim(JwtClaimTypes.Name, $"{admin.FirstName} {admin.LastName}"),
                    new Claim(JwtClaimTypes.GivenName, admin.FirstName),
                    new Claim(JwtClaimTypes.FamilyName, admin.LastName),
                    new Claim(JwtClaimTypes.Role, IdentityConfiguration.Admin)
                }).Result;
            }
        }

        // se o usuário client não existir cria o usuário, define senha e atribui ao perfil
        if (_userManager.FindByEmailAsync("client1@com.br").Result is null)
        {
            // define os dados do usuário client
            ApplicationUser client = new ApplicationUser()
            {
                UserName = "client1",
                NormalizedUserName = "CLIENT1",
                Email = "client1@com.br",
                NormalizedEmail = "CLIENT1@COM.BR",
                EmailConfirmed = true,
                LockoutEnabled = false,
                PhoneNumber = "+55 (11) 9 4298-9935",
                FirstName = "Usuario",
                LastName = "Client",
                SecurityStamp = Guid.NewGuid().ToString()
            };

             // cria o usuário client e atribui a senha
            IdentityResult resultClient = _userManager.CreateAsync(client, "Numsey#2022").Result;
            if (resultClient.Succeeded)
            {
                // inclui o usuário client1 ao perfil client
                _userManager.AddToRoleAsync(client, IdentityConfiguration.Client).Wait();

                // inclui as claims do usuário client

                var clientClaims = _userManager.AddClaimsAsync(client, new Claim[]
                {
                    new Claim(JwtClaimTypes.Name, $"{client.FirstName} {client.LastName}"),
                    new Claim(JwtClaimTypes.GivenName, client.FirstName),
                    new Claim(JwtClaimTypes.FamilyName, client.LastName),
                    new Claim(JwtClaimTypes.Role, IdentityConfiguration.Client)
                }).Result;
            }
        }
    }
}