﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.Net.Http.Headers;
using Xunit;
using Microsoft.EntityFrameworkCore;
using onBoard.DBRepo;
using Microsoft.Extensions.DependencyInjection;
using onBoard.DBRepo;
using onBoard.Data;

namespace onBoard.Test
{
    public class WebApplicationFactory
    {
        [Fact]
        public async Task HelloWorldTest()
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
            //...
        }
    }
}