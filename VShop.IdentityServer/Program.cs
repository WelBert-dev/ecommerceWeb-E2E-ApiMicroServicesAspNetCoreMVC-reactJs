using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VShop.IdentityServer.Configuration;
using VShop.IdentityServer.Data;
using VShop.IdentityServer.SeedDatabase;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Conexão com banco 

var mySqlConnectionString = builder.Configuration.GetConnectionString("DefaulConnection");

builder.Services.AddDbContext<AppDbContext>(options => 
                options.UseMySql(mySqlConnectionString, ServerVersion.AutoDetect(mySqlConnectionString)));

// Injeta o Identity

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
        .AddEntityFrameworkStores<AppDbContext>()
        .AddDefaultTokenProviders();


// Configura o IdentityServer Duende

var builderIdentityServer = builder.Services.AddIdentityServer(options =>
    {
        options.Events.RaiseErrorEvents = true;
        options.Events.RaiseInformationEvents = true;
        options.Events.RaiseFailureEvents = true;
        options.Events.RaiseSuccessEvents = true;
        options.EmitStaticAudienceClaim = true;
    }
).AddInMemoryIdentityResources(IdentityConfiguration.IdentityResources)
            .AddInMemoryApiScopes(IdentityConfiguration.ApiScopes)
            .AddInMemoryClients(IdentityConfiguration.Clients)
            .AddAspNetIdentity<ApplicationUser>();


builderIdentityServer.AddDeveloperSigningCredential();

// Adiciona o serviço de alimentação inicial perfils: admin1 e client1

builder.Services.AddScoped<IDatabaseSeedInitializer, DatabaseIdentityServerInitializer>();

// Finalmente Builda

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Adiciona middleware do IdentityServer

app.UseIdentityServer();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

void SeedDatabaseIdentityServer(IApplicationBuilder app)
{
    using (var serviceScope = app.ApplicationServices.CreateScope())
    {
        var initRolesUsers = serviceScope.ServiceProvider.GetService<IDatabaseSeedInitializer>();
        initRolesUsers.InitializeSeedRoles();
        initRolesUsers.InitializeSeedUsers();
    }
}
