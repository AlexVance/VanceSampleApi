using Microsoft.EntityFrameworkCore;
using VanceSampleApi.Data;
using VanceSampleApi.Repositories;
using VanceSampleApi.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<ProductContext>(options =>
    options.UseInMemoryDatabase("ProductDB"));

builder.Services.AddTransient<IProductRepository, ProductRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
