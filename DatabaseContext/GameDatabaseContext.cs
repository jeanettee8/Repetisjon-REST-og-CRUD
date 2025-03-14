using System;
using Microsoft.EntityFrameworkCore;
using Repetisjon_REST_og_CRUD.Models;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace Repetisjon_REST_og_CRUD.DatabaseContext;

public class GameDatabaseContext : DbContext
{
    public DbSet<GameModel>Games {get; set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data source=Game.db");
    }
}