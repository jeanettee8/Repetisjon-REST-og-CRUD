using System.Linq.Expressions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
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
        public IActionResult Get([FromQuery]QueryDTO? dto) {
            if (dto != null) {
                return Ok(dto.QueryBuilder(context.Games.ToList().AsQueryable()));
            }
            {
            return Ok(context.Games);
            }}

        [HttpGet("{gameID}")]
        public IActionResult Get(int gameID) {
            try
            {
                return Ok(context.Games.FirstOrDefault(game=>game.GameID==gameID));
            }
            catch (Exception e)
            {
                return StatusCode(500, "Something went wrong.");
            }
        }


        [HttpPost]
        public IActionResult Post([FromBody]GameModelDTO dto) {
            try
            {
                context.Games.Add(dto.MapToGameModel());
                context.SaveChanges();
                return Created();
            }
            catch (Exception e)
            {
                return StatusCode(500, "Something went wrong.");
            }
        }

        [HttpPatch("{gameID}")]
            public IActionResult Patch(int gameID, [FromBody]GameModelDTO dto) {
                try 
                {
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
                    return NoContent();
                }
                catch (Exception e)
                {
                    return StatusCode(500, "Something went wrong.");
                }
        }

        [HttpDelete("{gameID}")]
        public IActionResult Delete(int gameID) {
            try
            {
                var existingGame = context.Games.FirstOrDefault(game=>game.GameID==gameID);
                if (existingGame == null) return NotFound();
                context.Games.Remove(existingGame);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode (500, "Something went wrong.");
            }
        }
    }
}