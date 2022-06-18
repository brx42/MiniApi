using Microsoft.AspNetCore.Mvc;
using ASP.NET_CORE_TRY.Models;
using ASP.NET_CORE_TRY.Repository;

namespace ASP.NET_CORE_TRY.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MiniApiController : ControllerBase
{
    private readonly UserRepository _repository;

    public MiniApiController(UserRepository repository) => _repository = repository;

    [HttpGet("AllUsers")]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _repository.GetAll();
        if (users.Count() != 0) 
            return Ok(users);

        return NoContent();
    }

    [HttpGet("User/{id}")]
    public async Task<IActionResult> GetUser(int id)
    {
        var user = await _repository.Get(id);
        if (user != null)
            return Ok(user);
        return NoContent();
    }

    [HttpPost("Add")]
    public async Task<IActionResult> AddUser([FromBody] User user)
    {
        try
        {
            await _repository.Add(user);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("Update")]
    public async Task<IActionResult> UpdateUser([FromBody] User user)
    {
        try
        {
            await _repository.Update(user);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> DeleteUser([FromBody] User user)
    {
        try
        {
            await _repository.Delete(user);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

