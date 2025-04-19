using System.Reflection;
using Catalog.API.Application.Contracts.Query;
using Catalog.API.Domain.ProductAggregate;
using Catalog.API.Infrastructure;
using Catalog.API.Infrastructure.Queries;
using Catalog.API.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IProductRepository, ProductSqlRepository>();
builder.Services.AddTransient<IProductQuery, ProductSqlQuery>();
builder.Services.AddDbContext<CatalogContext>(options =>
{
    //? Development
    var cnStr = builder.Configuration.GetConnectionString("Catalog");
    options.UseSqlServer(cnStr);

    //? Production
});

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
