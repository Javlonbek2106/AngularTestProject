using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Interfaceses
{
    public interface IUserService
    {
        ValueTask<IEnumerable<UserDTO>> GetUsersAsync();
        ValueTask<UserDTO> GetByUserId(Guid Id);
        ValueTask<Guid> CreateUserAsync(PostUserDTO userDTO);
        ValueTask DeleteUser(Guid userId);
        ValueTask DeleteRange(Guid[] usersIds);
        ValueTask UpdateUserAsync(UserDTO userDTO);
    }
}
