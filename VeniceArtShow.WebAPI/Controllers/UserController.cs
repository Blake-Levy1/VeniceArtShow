using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]

public class UserController : Controller
{
    private UserManager<UserEntity> userManager;

    public UserController(UserManager<UserEntity> usrMgr)
    {
        userManager = usrMgr;
    }

    [HttpPost]
    public async Task<IActionResult> RegisterUser([FromBody] UserEntity user)
    {
        if (ModelState.IsValid)
        {
            IdentityResult result = await userManager.CreateAsync(user);
            if (result.Succeeded)
                return Ok("User was successfully created");
        }
        return BadRequest("User could not be created");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser([FromBody] UserEntity user)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        IdentityResult result = await userManager.UpdateAsync(user);
        if (result.Succeeded)
        {
            return Ok("Update was successful");
        }
        return BadRequest("Update could not be completed");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteUser(UserEntity user)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        IdentityResult result = await userManager.DeleteAsync(user);
        if (result.Succeeded)
        {
            return Ok("User deleted successfuly");
        }
        return BadRequest("User could not be completed");
    }
}

