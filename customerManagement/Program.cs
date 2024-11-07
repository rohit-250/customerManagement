using customerManagement.Models;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

// injecting database service as singleton
builder.Services.AddSingleton<IDataBaseService>(sp =>
    new DataBaseService(configuration.GetConnectionString("CustomerDB") ?? "")
);

// Add services to the container.

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

app.UseAuthorization();

app.MapControllers();

app.Run();
