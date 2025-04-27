using checkList.Models;
using CheckList.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CheckList.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<GetUserDto> GetUser()
        {
            return _context.Users
            .Where(u => !u.IsSoftDeleted)
            .Select(u => new GetUserDto
            {
                Id = u.Id,
                Email = u.Email,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Role = u.Role
            })
            .ToList();
        }

        [HttpPost]
        public List<User> PostUser(CreateUserDto dto)
        {
            var user = new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Password = dto.Password,
                Role = dto.Role
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            return _context.Users.ToList();
        }

        [HttpDelete]
        public string DeleteUser(int Id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == Id);
            if (user is not null)
            {
                user.IsSoftDeleted = true;
            }
            _context.SaveChanges();
            return "Ok";
        }

        [HttpPut]
        public string UpdateUser(UpdateUserDto dto)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == dto.Id);
            if (user is not null)
            {
                user.FirstName = dto.FirstName;
                user.LastName = dto.LastName;
                user.Email = dto.Email;
                user.Password = dto.Password;
            }
            _context.SaveChanges();
            return "Ok";
        }
    }
}
