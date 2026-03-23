// using
// api
// controller
// class
// interface
// constructor
// type 
// method
// UACCICTM


using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }


    // GET /api/users?name=john
    [HttpGet]
    public async Task<IActionResult> GetUsers( [FromQuery] string? firstName, [FromQuery] string? lastName)
    {
        var users = await _userService.GetUsers(firstName, lastName);
        return Ok(users);
    }

    // GET /api/users/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await _userService.GetUserById(id);

        if (user == null)
            return NotFound();

        return Ok(user);
    }
}