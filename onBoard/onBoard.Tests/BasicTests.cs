using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.Net.Http.Headers;
using onBoard;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using onBoard.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using onBoard.DBRepo;
using Moq;
using onBoard.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Helpers;
using System.Text.Json;

namespace onBoard.Tests
{
    public class BasicTests : IClassFixture<WebApplicationFactory<Program>>

    {

        //    [Theory]
        //    [InlineData("/User/Index")]
        //    public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        //    {
        //        var application = new WebApplicationFactory<Program>()
        //            .WithWebHostBuilder(builder =>
        //            {
        //                builder.ConfigureServices(services =>
        //                {
        //                    services.AddCors(options =>
        //                    {
        //                        options.AddPolicy("AllowInputForYouPolicy",
        //                            builder =>
        //                            {
        //                                builder.WithOrigins("https://*.input4you.be", "http://*.inputforyou.local", "http://localhost:4200")
        //                                    .WithHeaders(HeaderNames.ContentType, "*")
        //                                    .WithMethods("POST", "PUT", "DELETE", "GET", "OPTIONS")
        //                                    .AllowAnyHeader()
        //                                    .SetIsOriginAllowedToAllowWildcardSubdomains();
        //                            });
        //                    });



        //                    services.AddDbContext<ProjectContext>(options =>
        //                            options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ProjectContext1;Trusted_Connection=True;MultipleActiveResultSets=true"));
        //                    services.AddScoped<IDBRepo, DBRepoSQL>();
        //                    services.AddAuthorization(options =>
        //                        options.FallbackPolicy = options.DefaultPolicy
        //                    );
        //                    services.AddRazorPages();
        //                });

        //                builder.UseTestServer();

        //            });

        //        var client = application.CreateClient();
        //        // Act
        //        var response = await client.GetAsync(url);

        //        // Assert
        //        response.EnsureSuccessStatusCode(); // Status Code 200-299
        //        Assert.Equal("text/plain; charset=utf-8",
        //            response.Content.Headers.ContentType.ToString());
        //    }


        [Fact]
        public async Task TestingGetTimesClicked()
        {
            var mockDataBase = new Mock<ProjectContext>();
            var mockIDBRepo = new Mock<DBRepoSQL>(mockDataBase.Object);
            string userName = "Antonio";
            mockIDBRepo.Setup(p => p.GetClicksByUser(userName)).Returns(5);
            var mockUserController = new UsersController(mockIDBRepo.Object);

            var result = await mockUserController.GetTimesClicked(userName);
            var jo = JsonSerializer.Serialize(((dynamic)result.Value).clicks);
            Assert.Equal("5",jo);
        }
    }
}