using FluentBlazorEcommerce.Client.Pages;
using Microsoft.FluentUI.AspNetCore.Components;
using FluentBlazorEcommerce.Components;
using FluentBlazorEcommerce.Database;
using Microsoft.EntityFrameworkCore;
using FluentBlazorEcommerce.Models;
using FluentBlazorEcommerce.Entities;
using Microsoft.AspNetCore.OpenApi;
using Swashbuckle.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddFluentUIComponents();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("sqlite");
    options.UseSqlite(connectionString);
});

builder.Services.AddSingleton<HttpClient>(new HttpClient { BaseAddress = new Uri("https://localhost:7025") });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(FluentBlazorEcommerce.Client._Imports).Assembly);

app.MapGet("/api/products", async (AppDbContext dbContext) =>
{
    var products = await dbContext.Products.ToListAsync();

    List<ProductViewModel> productViewModels = new();

    foreach (var product in products)
    {
        productViewModels.Add(new ProductViewModel
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Description = product.Description
        });
    }

    return Results.Ok(products);
})
.WithName("GetProducts")
.WithOpenApi();

app.MapGet("/api/products/{Id}", async (AppDbContext dbContext, int Id) =>
{
    var product = await dbContext.Products.FindAsync(Id);

    if (product == null)
    {
        return Results.NotFound();
    }

    ProductViewModel productViewModel = new()
    {
        Id = product.Id,
        Name = product.Name,
        Price = product.Price,
        Description = product.Description
    };

    return Results.Ok(productViewModel);
})
.WithName("GetProduct")
.WithOpenApi();


app.MapPost("/api/products", async (AppDbContext dbContext, ProductViewModel productViewModel) =>
{
    Product product = new()
    {
        Name = productViewModel.Name,
        Price = productViewModel.Price,
        Description = productViewModel.Description
    };

    await dbContext.Products.AddAsync(product);
    await dbContext.SaveChangesAsync();
    return Results.Created($"/api/products/{product.Id}", product);
})
.WithName("PostProduct")
.WithOpenApi();

app.MapPut("api/products/{Id}", async (AppDbContext dbContext, int Id, ProductViewModel productViewModel) =>
{
    var product = await dbContext.Products.FindAsync(Id);
    if (product == null)
    {
        return Results.NotFound();
    }

    product.Name = productViewModel.Name;
    product.Price = productViewModel.Price;
    product.Description = productViewModel.Description;

    await dbContext.SaveChangesAsync();
    return Results.Ok(product);

})
.WithName("PutProduct")
.WithOpenApi();

app.MapDelete("api/products/{id}", async (AppDbContext dbContext, int Id) =>
{
    var product = await dbContext.Products.FindAsync(Id);
    if (product == null)
    {
        return Results.NotFound();
    }

    dbContext.Products.Remove(product);
    await dbContext.SaveChangesAsync();
    return Results.Ok();

})
.WithName("DeleteProduct")
.WithOpenApi();

app.Run();
