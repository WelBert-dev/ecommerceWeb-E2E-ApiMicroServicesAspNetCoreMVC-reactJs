// depois de builder.Services.AddSwaggerGe();
// adicionar a conexão com bando:


// Configura o serviço do contexto (se conecta com o banco)

var mySqlConnectionString = builder.Configurations.getConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options => 
                options.UseMySql(mySqlConnectionString, ServerVersion.AutoDetect(mySqlConnectionString)));


var app = builder.Build();

