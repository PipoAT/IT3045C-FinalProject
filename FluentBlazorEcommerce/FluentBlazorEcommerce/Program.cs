using FluentBlazorEcommerce.Client.Pages;
using Microsoft.FluentUI.AspNetCore.Components;
using FluentBlazorEcommerce.Components;
using FluentBlazorEcommerce.Database;
using Microsoft.EntityFrameworkCore;
using FluentBlazorEcommerce.Models;
using FluentBlazorEcommerce.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddFluentUIComponents();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("sqlite");
    options.UseSqlite(connectionString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
            ID = product.Id,
            Name = product.Name,
            Price = product.Price,
            Description = product.Description
        });
    }

    return Results.Ok(products);
});

app.Run();
