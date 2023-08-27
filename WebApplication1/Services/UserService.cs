using Microsoft.EntityFrameworkCore;
using WebApplication1.DTOs;
using WebApplication1.Interfaceses;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class UserService : IUserService
    {
        private readonly IDbContext _dbContext;

        public UserService(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async ValueTask<Guid> CreateUserAsync(PostUserDTO userDTO)
        {
            User user = new User();
            user.Fullname = userDTO.Fullname;
            user.Username = userDTO.Username;
            user.Email = userDTO.Email;
            user.Password = userDTO.Password;
            user.Age = userDTO.Age;
            user.Phonenumber = userDTO.Phonenumber;
            user.CompanyId = userDTO.CompanyId;
            await _dbContext.Users.AddAsync(user);
            _dbContext.SaveChanges();
            return user.Id;
        }

        public ValueTask DeleteUser(Guid userId)
        {
            User? user = _dbContext.Users.Include(u => u.Company).FirstOrDefault(u => u.Id.Equals(userId));

            if (user != null)
            {
                // Check if the user has a company
                if (user.Company != null)
                {
                    // Remove the user from the company's user list
                    user.Company.Users.Remove(user);
                }

                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
            }

            return ValueTask.CompletedTask;
        }


        public async ValueTask<IEnumerable<UserDTO>> GetUsersAsync()
        {
            List<UserDTO> userDTOs = await _dbContext.Users
                //.AsNoTracking()
                .Select(
                user => new UserDTO
                {
                    Id = user.Id,
                    Fullname = user.Fullname,
                    Username = user.Username,
                    Password = user.Password,
                    Email = user.Email,
                    Phonenumber = user.Phonenumber,
                    Age = user.Age
                }).ToListAsync();
            return userDTOs;
        }
        public async ValueTask<UserDTO> GetByUserId(Guid Id)
        {

            var user = _dbContext.Users.FirstOrDefault(u => u.Id == Id);
            UserDTO userDTO = new()
            {
                Id = user.Id,
                Fullname = user.Fullname,
                Username = user.Username,
                Password = user.Password,
                Email = user.Email,
                Phonenumber = user.Phonenumber,
                Age = user.Age
            };
            return userDTO;
        }

        public ValueTask DeleteRange(Guid[] usersIds)
        {
            foreach (var id in usersIds)
            {
                DeleteUser(id);
            }
            return ValueTask.CompletedTask;
        }

        public ValueTask UpdateUserAsync(UserDTO userDTO)
        {
            User? user = _dbContext.Users.FirstOrDefault(u => u.Id.Equals(userDTO.Id));
            user.Fullname = userDTO.Fullname;
            user.Username = userDTO.Username;
            user.Email = userDTO.Email;
            user.Password = userDTO.Password;
            user.Age = userDTO.Age;
            user.Phonenumber = userDTO.Phonenumber;
            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
            return ValueTask.CompletedTask;
        }
    }
}
