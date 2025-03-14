using Repetisjon_REST_og_CRUD.DatabaseContext;
using System.ComponentModel.DataAnnotations;


namespace Repetisjon_REST_og_CRUD.Models;

public class GameModel
{
    [Key]
    public int GameID {get; set;}
    public string? Title {get; set;}
    public string? Genre {get; set;}
    public string? Platform {get; set;}
    public int ReleaseYear {get; set;}
    public string? Publisher {get; set;}
    public double GlobalSales {get; set;}
    public string? Rating {get; set;}
}