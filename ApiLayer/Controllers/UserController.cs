using Microsoft.AspNetCore.Mvc;

namespace SpaceProgram.ApiLayer.Controllers;

[Route("api/user")]
public class UserController : ControllerBase
{
    public SqlServerUserRepository _userRepository = new SqlServerUserRepository();

    [HttpGet]
    public ActionResult<IEnumerable<User>> GetAll()
    {
        return Ok(_userRepository.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult <ActionResult<User>> Get(Guid id)
    {
        return Ok(_userRepository.Get(id));
    }

    [HttpPost]
    public ActionResult Post([FromBody] User user)
    {
        _userRepository.Create(user);
        return Created("", user);
    }

    [HttpPut("{id}")]
    public ActionResult Put([FromBody] User user)
    {
        _userRepository.Modify(user);
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public ActionResult Delete(Guid id)
    {
        _userRepository.Delete(id);
        return Ok();
    }
}
