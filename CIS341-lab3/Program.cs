using Microsoft.AspNetCore.Http;
using System;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Add a request delegate to the middleware pipeline with the Use extension and the appropriate parameters
// The delegate should be added to a position where it will run for all requests.
app.Use(async (context, next) =>
{
    // The delegate should write the current time and request URL to the debug output.
    // The delegate should appropriately pass the request to the next delegate.
    await next.Invoke();
    string url = context.Request.Scheme + "://" + context.Request.Host + context.Request.Path + context.Request.QueryString;
    Debug.WriteLine($"{DateTime.Now} {url}");
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
