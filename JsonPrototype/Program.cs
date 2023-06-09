﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using JsonPrototype.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc(setupAction: options => options.EnableEndpointRouting = false).SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);
builder.Services.AddRazorPages();
builder.Services.AddDbContext<PrototypeDbContext>(options => PrototypeDbContext.EFCoreSetup(options, builder.Configuration.GetConnectionString("PrototypeDbContext")));
builder.Services.AddServerSideBlazor();

DbContextFactory.SetConnectionString("PrototypeDbContext");

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseMvcWithDefaultRoute();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
