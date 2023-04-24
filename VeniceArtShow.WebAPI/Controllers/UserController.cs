using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]

public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly ITokenService _tokenService;
    public UserController(IUserService userService, ITokenService tokenService)
    {
        _userService = userService;
        _tokenService = tokenService;
    }
    [HttpPost("Register")]
    public async Task<IActionResult> RegisterUser([FromBody] UserRegister model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var registerResult = await _userService.RegisterUserAsync(model);
        if (registerResult)
        {
            return Ok("User was registered.");
        }
        return BadRequest("User could not be registered.");
    }

    [HttpPut("Update")]
    public async Task<IActionResult> UpdateUser([FromBody] UserUpdate model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        return await _userService.UpdateUserAsync(model)
            ? Ok("User updated successfully.")
            : BadRequest("User could not be updated");
    }
    
    [HttpGet("{userId:int}")]
    public async Task<IActionResult> GetUserById([FromRoute] int userId)
    {
        var userDetail = await _userService.GetUserByIdAsync(userId);
        if (userDetail is null)
        {
            return NotFound();
        }
        return Ok(userDetail);
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> DeleteUser([FromBody] int userId)
    {
        return await _userService.DeleteUserAsync(userId)
        ? Ok($"User {userId} was deleted successfully.")
        : BadRequest($"User {userId} could not be deleted.");
    }

    [HttpPost("~/api/Token")]
    public async Task<IActionResult> Token([FromBody] TokenRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var tokenResponse = await _tokenService.GetTokenAsync(request);
        if (tokenResponse is null)
            return BadRequest("Invalid username or password.");
        return Ok(tokenResponse);
    }
}