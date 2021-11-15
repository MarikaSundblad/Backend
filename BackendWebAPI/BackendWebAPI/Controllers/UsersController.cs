using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendWebAPI.Data;
using BackendWebAPI.Entities;
using BackendWebAPI.Models.User;

namespace BackendWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly SqlContext _context;

        public UsersController(SqlContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetUsers()
        {
            var users = new List<UserModel>();

            foreach (var user in await _context.Users.Include(x => x.Addresses).ToListAsync())
                users.Add(new UserModel
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    AddressLine = user.Addresses.AddressLine,
                    HouseNr = user.Addresses.HouseNr,
                    ZipCode = user.Addresses.ZipCode,
                    City = user.Addresses.City
                });

            return users;
        }

        // GET: api/Users/5
        [HttpGet("{id}")]

        public async Task<ActionResult<UserModel>> GetUser(int id)
        {
       
            var user = await _context.Users.FindAsync(id);
            var address = await _context.Addresses.FindAsync(user.AddressesId);
            var userModel = new UserModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                AddressLine = address.AddressLine,
                HouseNr = address.HouseNr,
                ZipCode = address.ZipCode,
                City = address.City
            };

            if (user == null)
            {
                return NotFound();
            }

            return userModel;
        }




        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(CreateUserModel model)
        {

            var user = new User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Addresses = new Address
                {
                    AddressLine = model.AddressLine,
                    HouseNr = model.HouseNr,
                    ZipCode = model.ZipCode,
                    City = model.City
                }
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
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
