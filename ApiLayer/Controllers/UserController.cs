using Microsoft.AspNetCore.Mvc;
using SpaceProgram.BusinessLayer.DtoModels;
using SpaceProgram.BusinessLayer.Interfaces;
using System.Security.Cryptography;

namespace SpaceProgram.ApiLayer.Controllers;

[Route("api/user")]
public class UserController : ControllerBase
{
    private IUserManager UserManager { get; }

    public UserController(IUserManager userManager)
    {
        UserManager = userManager;
    }

    [HttpGet]
    public ActionResult<IList<UserDto>> GetAll()
    {
        var fetchedUsers = UserManager.GetAll();

        if (fetchedUsers == null)
        {
            return Problem("An error occured while trying to find the users.");
        }

        return Ok(new { fetchedUsers });
    }

    [HttpGet("{id}")]
    public ActionResult<UserDto> Get(Guid id)
    {
        var fetchedUser = UserManager.Get(id);

        if (fetchedUser == null)
        {
            return NotFound(new { errorMessage = "Could not find requested user." });
        }

        return Ok(new { fetchedUser });
    }

    [Route("username")]
    [HttpPost]
    public ActionResult<OfficerDto> Get([FromBody] UserDto user)
    {
        var fetchedUsers = UserManager.GetAll();

        if (fetchedUsers == null)
        {
            return NotFound(new { errorMessage = "Could not find requested user." });
        }

        var requestedUser = fetchedUsers.FirstOrDefault(x => x.Username == user.Username);

        if (requestedUser == null)
        {
            return NotFound(new { errorMessage = "Username not found." });
        }

        VerifyPasswordHash(user, requestedUser);

        return Ok(requestedUser.UserId);
    }

    private static void VerifyPasswordHash(UserDto user, UserDto? requestedUser)
    {
        string savedPasswordHash = requestedUser.Password;
        byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
        byte[] salt = new byte[16];
        Array.Copy(hashBytes, 0, salt, 0, 16);
        var pbkdf2 = new Rfc2898DeriveBytes(user.Password, salt, 100000);
        byte[] hash = pbkdf2.GetBytes(20);
        for (int i = 0; i < 20; i++)
            if (hashBytes[i + 16] != hash[i])
                throw new UnauthorizedAccessException();
    }

    [HttpPost]
    public ActionResult Post([FromBody] UserDto user)
    {
        var createdUser = UserManager.Create(user);

        if (createdUser == null)
        {
            return Problem("Could not create the user.");
        }

        return Created("", new { createdUser });
    }

    [HttpPut]
    public ActionResult Put([FromBody] UserDto user)
    {
        var originalUser = UserManager.Get(user.UserId);
        var modifiedUser = UserManager.Modify(user);

        if (modifiedUser == null)
        {
            return Problem("Could not modify the user.");
        }

        return Ok(new { originalUser, modifiedUser });
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(Guid id)
    {
        var deletedUser = UserManager.Delete(id);

        if (deletedUser == null)
        {
            return Problem("Could not delete the user.");
        }

        return Ok(new { deletedUser });
    }
}
