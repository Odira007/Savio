using Microsoft.EntityFrameworkCore;
using SavioApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());//THIS IS FOR THE AUTOMAPPER

builder.Services.AddDbContext<SavioDbContext>(options=>{
    options.UseSqlite(builder.Configuration.GetConnectionString("SavioDb"));
});//THIS IS FOR  THE ENTITY FRAMEWORK AND THE MODELS.

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
