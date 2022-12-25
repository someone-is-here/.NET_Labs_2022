using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using WEB_053501_Tatsiana_Shurko.Data;
using WEB_053501_Tatsiana_Shurko.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var configuration = builder.Configuration;

builder.Services.AddDbContext<BookContext>(options =>
               options.UseSqlServer(
                   configuration.GetConnectionString("DefaultConnection")));

BookContext context = builder.Services.BuildServiceProvider().GetService<BookContext>();
DbInitializer.InitializeBooks(context);

builder.Host.ConfigureLogging(logging => {
    logging.ClearProviders();
    logging.AddConsole();
});

builder.Services.AddCors(opt =>
opt.AddPolicy("AllowAny",
builder => {
    builder.AllowAnyMethod()
    .AllowAnyHeader()
    .AllowAnyOrigin();

}));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseWebAssemblyDebugging();
} else {
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.UseCors("AllowAny");

app.Run();
