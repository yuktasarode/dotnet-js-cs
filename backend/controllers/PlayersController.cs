using Microsoft.AspNetCore.Mvc;
using backend.Models;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlayersController : ControllerBase
{
    private readonly HttpClient _httpClient;
    private const string DataUrl = "https://raw.githubusercontent.com/algolia/datasets/refs/heads/master/basketball/nba-players.json";

    public PlayersController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    [HttpGet]
    public async Task<IActionResult> GetPlayers()
    {
        try
        {
            var players = await _httpClient.GetFromJsonAsync<List<Player>>(DataUrl);

            if (players == null)
            {
                return StatusCode(500, "Could not load player data.");
            }

            return Ok(players);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error fetching data: {ex.Message}");
        }
    }
}