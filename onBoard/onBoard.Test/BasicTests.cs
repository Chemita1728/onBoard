using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.Net.Http.Headers;
using onBoard.Data;
using Microsoft.EntityFrameworkCore;
using onBoard.DBRepo;
namespace onBoard.Test
{
    public class BasicTests
    {

        [Theory]
        [InlineData("https://localhost:7201/")]
        [InlineData("https://localhost:7201/Users")]
        [InlineData("https://localhost:7201/Home/Privacy")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            var application = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        services.AddCors(options =>
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

                        services.AddControllersWithViews();
                        services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
                                .AddNegotiate();
                        services.AddDbContext<ProjectContext>(options =>
                                options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ProjectContext1;Trusted_Connection=True;MultipleActiveResultSets=true"));
                        services.AddScoped<IDBRepo, DBRepoSQL>();
                        services.AddAuthorization(options =>
                            options.FallbackPolicy = options.DefaultPolicy
                        );
                        services.AddRazorPages();

                    });
                });

            var client = application.CreateClient();
            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    }
}
