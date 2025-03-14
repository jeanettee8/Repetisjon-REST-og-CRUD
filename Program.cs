using Microsoft.AspNetCore.Mvc;
using Repetisjon_REST_og_CRUD.DatabaseContext;
using Repetisjon_REST_og_CRUD.Models;
using Microsoft.EntityFrameworkCore.Design;

namespace Repetisjon_REST_og_CRUD;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<GameDatabaseContext>();
        // This one is important to not forget, I had forgotten this one and struggled for 30 mins without it working

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();
        using (var context=new GameDatabaseContext()) {
            if (!context.Games.Any()) {
                var games = File.ReadAllLines("Videogames.csv");
                foreach (var game in games.Skip(1)) {
                    var gameData  = game.Split(',', StringSplitOptions.None).ToList();
                    while (gameData.Count<8) {
                        gameData.Add(string.Empty);
                    }
                    var newGame = new GameModel() {
                        Title = gameData[1], Genre = gameData[2], Platform = gameData[3], Publisher = gameData[5], Rating = gameData[7]};
                        context.Games.Add(newGame);
                    }
                    context.SaveChanges();
                }
        }

        app.Run();
    }
}