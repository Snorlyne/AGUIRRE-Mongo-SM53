using AGUIRRE_Mongo_SM53.Models;
using AGUIRRE_Mongo_SM53.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<mario_brosDBSettings>(
builder.Configuration.GetSection("Mongomario_brosDatabase"));

//Add Services
builder.Services.AddSingleton<bandoServices>();
builder.Services.AddSingleton<claseServices>();
builder.Services.AddSingleton<personajesServices>();
builder.Services.AddSingleton<poderesServices>();
builder.Services.AddSingleton<lugaresServices>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
