using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace Repetisjon_REST_og_CRUD.Models;

public class QueryDTO
{
    public string? Title {get; set;}
    public string? Genre {get; set;}
    public string? Platform {get; set;}
    public int ReleaseYear {get; set;}
    public string? Publisher {get; set;}
    public double GlobalSales {get; set;}
    public string? Rating {get; set;}

    public IQueryable<GameModel>QueryBuilder(IQueryable<GameModel> Games) {
        var query = Games.AsQueryable();
        if(!string.IsNullOrWhiteSpace(Title)) query = query.Where(game=>string.Equals(game.Title, Title,StringComparison.InvariantCultureIgnoreCase));
        if(!string.IsNullOrWhiteSpace(Genre)) query = query.Where(game=>string.Equals(game.Genre, Genre,StringComparison.InvariantCultureIgnoreCase));
        if(!string.IsNullOrWhiteSpace(Platform)) query = query.Where(game=>string.Equals(game.Platform, Platform,StringComparison.InvariantCultureIgnoreCase));
        if(ReleaseYear != 0) query = query.Where(game => game.ReleaseYear == ReleaseYear);
        if(!string.IsNullOrWhiteSpace(Publisher)) query = query.Where(game=>string.Equals(game.Publisher,Publisher,StringComparison.InvariantCultureIgnoreCase));
        if(GlobalSales != 0) query = query.Where(game => game.GlobalSales == GlobalSales);
        if(!string.IsNullOrWhiteSpace(Rating)) query = query.Where(game=>string.Equals(game.Rating, Rating,StringComparison.InvariantCultureIgnoreCase));
        return query;
    }

}