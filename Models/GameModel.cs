using Repetisjon_REST_og_CRUD.DatabaseContext;
using System.ComponentModel.DataAnnotations;


namespace Repetisjon_REST_og_CRUD.Models;

public class GameModel
{
    [Key]
    public int GameID {get; set;}
    [MaxLength(50)]
    public string? Title {get; set;}
    [MaxLength(30)]
    public string? Genre {get; set;}
    [MaxLength(10)]
    public string? Platform {get; set;}
    public int ReleaseYear {get; set;}
    [MaxLength(30)]
    public string? Publisher {get; set;}
    public double GlobalSales {get; set;}

    [MaxLength(5)]
    public string? Rating {get; set;}
}