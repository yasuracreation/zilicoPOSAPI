global using zilicoPOSAPI.Models;
global using zilicoPOSAPI.Models.Approval;
global using zilicoPOSAPI.Models.Users;
global using zilicoPOSAPI.Models.OrderManagement;
global using zilicoPOSAPI.Models.Products;
global using zilicoPOSAPI.Models.Inventories;
global using zilicoPOSAPI.Models.Audit;
global using zilicoPOSAPI.Models.TransactionRecords;
using Microsoft.EntityFrameworkCore;
using zilicoPOSAPI.DataAccess;
using zilicoPOSAPI.Interfaces;
using zilicoPOSAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(option =>{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IUserRepository, UserRepositoryImpl>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();


