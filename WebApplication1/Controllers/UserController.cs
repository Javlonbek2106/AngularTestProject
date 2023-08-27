using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Interfaceses;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpGet]
        public async ValueTask<IEnumerable<UserDTO>> GetAsync()
        {
            return await userService.GetUsersAsync();
        }

        [HttpGet("userbyid")]
        public async ValueTask<UserDTO> GetByUserId(Guid Id)
        {
            var res = await userService.GetByUserId(Id);
            return res;
        }

        [HttpPost("[action]")]
        public async ValueTask<ActionResult<Guid>> CreateUserAsync(PostUserDTO userDTO)
        {
            Guid userId = await userService.CreateUserAsync(userDTO);
            return userId;
        }
        [HttpPut]
        public async ValueTask<ValueTask> Update(UserDTO userDTO)
        {
            await userService.UpdateUserAsync(userDTO);
            return ValueTask.CompletedTask;
        }
        [HttpDelete("[action]")]
        public async ValueTask<ValueTask> Delete(Guid Id)
        {
            await userService.DeleteUser(Id);
            return ValueTask.CompletedTask;
        }
        [HttpDelete("[action]")]
        public async ValueTask<ValueTask> DeleteRange(Guid[] RangeIds)
        {
            await userService.DeleteRange(RangeIds);
            return ValueTask.CompletedTask;
        }
    }
}
