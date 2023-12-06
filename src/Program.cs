using FinancialPlanner;
using FinancialPlanner.Components;
using FinancialPlanner.Services;
using Microsoft.Extensions.DependencyInjection;
using static FinancialPlanner.Components.Pages.Manage_Accounts;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddBlazorBootstrap(); // Add this line for Blazor Bootstrap 1.10.3
builder.Services.AddRazorPages();   // Added for web api
builder.Services.AddServerSideBlazor(); // Added for web api

// Added for calling web api
builder.Services.AddHttpClient<IAccountHolderService, AccountHolderService>();


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
