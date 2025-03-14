using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Repetisjon_REST_og_CRUD.DatabaseContext;
using Repetisjon_REST_og_CRUD.Models;

namespace Repetisjon_REST_og_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController(GameDatabaseContext context) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(){
            return Ok(context.Games);
        }

        [HttpGet("{gameID}")]
        public IActionResult Get(int gameID) {
            return Ok(context.Games.FirstOrDefault(game=>game.GameID==gameID));
        }

        [HttpPost]
        public IActionResult Post([FromBody]GameModelDTO dto) {
            context.Games.Add(dto.MapToGameModel());
            context.SaveChanges();
            return Created();
        }

        [HttpPatch("{gameID}")]
        public IActionResult Patch(int gameID, [FromBody]GameModelDTO dto) {
            var existingGame = context.Games.FirstOrDefault(game=>game.GameID==gameID);
            if (existingGame == null) return NotFound();
            existingGame.Title = dto.Title;
            existingGame.Genre = dto.Genre;
            existingGame.Platform = dto.Platform;
            existingGame.ReleaseYear = dto.ReleaseYear;
            existingGame.Publisher = dto.Publisher;
            existingGame.GlobalSales = dto.GlobalSales;
            existingGame.Rating = dto.Rating;
            context.SaveChanges();
            return Created();
        }

        [HttpDelete("{gameID}")]
        public IActionResult Delete(int gameID) {
            var existingGame = context.Games.FirstOrDefault(game=>game.GameID==gameID);
            if (existingGame == null) return NotFound();
            context.Games.Remove(existingGame);
            context.SaveChanges();
            return NoContent();
        }
    }
}