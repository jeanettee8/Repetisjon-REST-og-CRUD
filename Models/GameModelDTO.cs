

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
}