using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SQL_Query_Logger.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<SQL_Query_LoggerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQL_Query_LoggerContext") ?? throw new InvalidOperationException("Connection string 'SQL_Query_LoggerContext' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//app.UseAuthorization();

app.MapRazorPages();

app.Run();
