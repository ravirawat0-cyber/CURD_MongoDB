using Microsoft.AspNetCore.Mvc;
using mongoDBtut.Models;
using mongoDBtut.Services;

[ApiController]
[Route("api/[controller]")]
public class UserInfoController : ControllerBase
{
    private readonly UserInfoService _userInfoService;

    public UserInfoController(UserInfoService userInfoService)
    {
        _userInfoService = userInfoService;
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        try
        {
            var users = await _userInfoService.GetAsync();
            return Ok(users);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("{id:length(24)}", Name = "GetUser")]
    public async Task<ActionResult> Get(string id)
    {
        try
        {
            var user = await _userInfoService.GetAsync(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }
        catch (Exception ex)
        {
     
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<ActionResult> Create(UserInfoRequest user)
    {
        try
        {
            var UserInfo = new UserInfo
            {
                Name = user.Name,
                Age = user.Age,
                Address = user.Address,
            }; 
            await _userInfoService.CreateAsync(UserInfo);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, UserInfoRequest updatedUser)
    {
        try
        {
            var user = await _userInfoService.GetAsync(id);

            if (user == null)
                return NotFound();
            
            var UserInfo = new UserInfo
            {
                Id = user.Id,
                Name = updatedUser.Name,
                Age = updatedUser.Age,
                Address = updatedUser.Address,
            };
            
            await _userInfoService.UpdateAsync(id, UserInfo);

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        try
        {
            var user = await _userInfoService.GetAsync(id);

            if (user == null)
                return NotFound();

            await _userInfoService.RemoveAsync(id);

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
