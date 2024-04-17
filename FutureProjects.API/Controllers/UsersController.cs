using FutureProjects.Application.Abstractions.IServices;
using FutureProjects.Domain.Entities.DTOs;
using FutureProjects.Domain.Entities.Models;
using FutureProjects.Domain.Entities.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FutureProjects.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetAllUsers()
        {
            var result = await _userService.GetAll();

            return Ok(result);
        }
        [HttpGet("GetUserById")]
        public async Task<ActionResult<UserViewModel>> GetUserById(int id)
        {
            var result = await _userService.GetById(id);
            return Ok(result);
        }  

        [HttpPost]
        public async Task<ActionResult<IEnumerable<User>>> CreateUser(UserDTO model)
        {
            var result = await _userService.Create(model);

            return Ok(result);
        }
        [HttpPut]
        public async Task<ActionResult<User>> Update(UserDTO user, int id) 
        {
            var result = await _userService.Update(id, user);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<bool> DeleteUserById(int id)
        {
            var result = await _userService.Delete(x => x.Id == id);

            return result;
        }

    }
}
