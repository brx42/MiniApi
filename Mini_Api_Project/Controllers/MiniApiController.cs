using Microsoft.AspNetCore.Mvc;
using ASP.NET_CORE_TRY.Models;
using ASP.NET_CORE_TRY.Repository;

namespace ASP.NET_CORE_TRY.Controllers;

[ApiController]
public class MiniApiController : ControllerBase
{
    private readonly IRepository<User> _repository;
    

    public MiniApiController(IRepository<User> repository) => _repository = repository;
    

    
    [HttpGet("get_users")]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _repository.GetAll();
        if (users.Count() != 0) 
            return Ok(users);

        return NoContent();
    }

    [HttpGet("get_user/{id}")]
    public async Task<IActionResult> GetUser(int id)
    {
        var user = await _repository.Get(id);
        if (user != null)
            return Ok(user);
        return NoContent();
    }

    [HttpGet("get_user_by_name/{name}")]
    public async Task<IActionResult> GetUserByName(string name)
    {
        var user = await _repository.GetByName(name);
        if (user != null)
            return Ok(user);
        return NoContent();
    }

    [HttpGet("get_user_by_age/{age}")]
    public async Task<IActionResult> GetUserByAge(int age)
    {
        var user = await _repository.GetByAge(age);
        if (user != null)
            return Ok(user);
        return NoContent();
    }

    [HttpPost("create_user")]
    public async Task<IActionResult> Post([FromBody] User user)
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

    [HttpPut("update_user")]
    public async Task<IActionResult> Put([FromBody] User user)
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

    [HttpDelete("delete_user")]
    public async Task<IActionResult> Delete([FromBody] User user)
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

