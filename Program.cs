using Microsoft.EntityFrameworkCore;
using Parcial1_Ap1_DavidRosario.Components;
using Parcial1_Ap1_DavidRosario.DAL;
using Parcial1_Ap1_DavidRosario.Models;
using Parcial1_Ap1_DavidRosario.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<Contexto>
    (o => o.UseSqlite(builder.Configuration.GetConnectionString("ConStr")));

builder.Services.AddScoped<MetasService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
