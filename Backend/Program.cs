using Microsoft.EntityFrameworkCore;
using Backend.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<FormResponseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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

// Adicione esta linha para servir o arquivo index.html como padrão
app.UseDefaultFiles();

// Adicione esta linha para servir arquivos estáticos
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();