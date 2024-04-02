﻿using ServerAPI.Repositories;

namespace ServerAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        builder.Services.AddSingleton<IShoppingRepository, ShoppingRepositoryInMemory>();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("policy",
                              policy =>
                              {
                                  policy.AllowAnyOrigin();
                              
                                  policy.AllowAnyHeader();
                              });
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.

        app.UseHttpsRedirection();

        

        app.UseAuthorization();

        app.UseCors("policy");

        app.MapControllers();

        app.Run();
    }
}

