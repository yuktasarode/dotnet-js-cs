using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PlayersController : ControllerBase
{
    private readonly IPlayerService _playerservice;
    public PlayersController(IPlayerService playerservice)
    {
        _playerservice = playerservice;
    }

    [HttpGet]
    public async Task<IActionResult> GetPlayers()
    {
       var players = await _playerservice.GetPlayers();
       return Ok(players);
    }
}