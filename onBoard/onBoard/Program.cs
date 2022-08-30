
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Negotiate;
using onBoard.Data;
using onBoard.Models;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication;
using onBoard;
using onBoard.DBRepo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowInputForYouPolicy",
        builder =>
        {
            builder.WithOrigins("https://*.input4you.be", "http://*.inputforyou.local", "http://localhost:4200")
                .WithHeaders(HeaderNames.ContentType, "*")
                .WithMethods("POST", "PUT", "DELETE", "GET", "OPTIONS")
                .AllowAnyHeader()
                .SetIsOriginAllowedToAllowWildcardSubdomains();
        });
});

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
   .AddNegotiate();

//builder.Services.AddAuthentication("BasicAuthentication")
//   .AddScheme<AuthenticationSchemeOptions,MockAuthenticatedUser>("BasicAuthentication", null);

builder.Services.AddDbContext<ProjectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProjectContext")));

builder.Services.AddScoped<IDBRepo, DBRepoSQL>();

builder.Services.AddAuthorization(options =>
{
     // By default, all incoming requests will be authorized according to the default policy.
    options.FallbackPolicy = options.DefaultPolicy;
});
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors("AllowInputForYouPolicy");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();