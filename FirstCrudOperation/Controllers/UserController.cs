using FirstCrudOperation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstCrudOperation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public UserController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var user= _applicationDbContext.Userabcsd.AsNoTracking().ToList();
            return Ok(user);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var user = _applicationDbContext.Userabcsd.AsNoTracking().FirstOrDefault(x => x.Id == id);    
            if(user==null)
            {
                return NotFound();
            }
            return Ok(user);
        }





        [HttpPost("Add")]

        public IActionResult Add(User user) 
        { 
            _applicationDbContext.Userabcsd.Add(user);
            _applicationDbContext.SaveChanges();
            return Ok(user); // 200 ok
        }

        [HttpPut("Update")]

        public IActionResult Update(int id, User user)
        {
            var existingUser = _applicationDbContext.Userabcsd.Find(id);

            if (existingUser == null)
            {
                return NotFound();// 404 status code not found
            }
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;

            _applicationDbContext.SaveChanges();
            return Ok(existingUser);
        }

        [HttpDelete("Delete")]

        public IActionResult Delete(int id)
        {
            var user = _applicationDbContext.Userabcsd.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            _applicationDbContext.Userabcsd.Remove(user);
            _applicationDbContext.SaveChanges();
            return Ok(user);
        }

    }
}
