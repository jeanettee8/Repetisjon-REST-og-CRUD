

namespace Repetisjon_REST_og_CRUD.Models;

public class GameModelDTO
{
    public string Title {get; set;} = string.Empty;
    public string Genre {get; set;} = string.Empty;
    public string Platform {get; set;} = string.Empty;
    public int ReleaseYear {get; set;} //anything here?
    public string Publisher {get; set;} = string.Empty;
    public int GlobalSales {get; set;} //anything here?
    public string Rating {get; set;} = string.Empty;


// Creates a new entity. Used for the POST method,
// and uses the parameterless method
    public GameModel MapToGameModel() {
        return new GameModel() {
            Title=Title,
            Genre=Genre,
            Platform=Platform,
            ReleaseYear=ReleaseYear,
            Publisher=Publisher,
            GlobalSales=GlobalSales,
            Rating=Rating,
        };
    }

// Updates an existing one. Used for the PATCH method,
// and uses the method with the GameModel parameter
    public void MapToGameModel(GameModel existingGame)
    {
        existingGame.Title = Title;
        existingGame.Genre = Genre;
        existingGame.Platform = Platform;
        existingGame.ReleaseYear = ReleaseYear;
        existingGame.Publisher = Publisher;
        existingGame.GlobalSales = GlobalSales;
        existingGame.Rating = Rating;
    }
}

// Using method overloading, these methods have the same name,
// but does different things depending on you using it with a parameter or not
