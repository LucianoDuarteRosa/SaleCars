using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaleCars.Data;
using SaleCars.Data.DTO;
using SaleCars.Models;

namespace SaleCars.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly SaleCarsContext _context;
         private readonly UserManager<UserModel> _userManager;

        public UsersController(SaleCarsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var users = await _context.Users
                                       .Include(u => u.Profile)
                                       .Select(u => new UserDto
                                       {
                                           Id = u.Id,
                                           UserName = u.UserName,
                                           Email = u.Email,
                                           UserActive = u.UserActive,
                                           ProfileId = u.ProfileId,
                                           ProfileName = u.Profile.ProfileName
                                       })
                                       .ToListAsync();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            var user = await _context.Users
                                     .Include(u => u.Profile)  // Incluindo os dados do perfil
                                     .Where(u => u.Id == id)
                                     .Select(u => new UserDto
                                     {
                                         Id = u.Id,
                                         UserName = u.UserName,
                                         Email = u.Email,
                                         UserActive = u.UserActive,
                                         ProfileId = u.ProfileId,
                                         ProfileName = u.Profile.ProfileName
                                     })
                                     .FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserDto userDto)
        {
            if (id != userDto.Id)
            {
                return BadRequest("ID in the URL does not match the ID in the body.");
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            // Atualizar os campos necessários
            user.UserName = userDto.UserName;
            user.Email = userDto.Email;
            user.UserActive = userDto.UserActive;
            user.ProfileId = userDto.ProfileId;

            // Salvar as alterações
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
