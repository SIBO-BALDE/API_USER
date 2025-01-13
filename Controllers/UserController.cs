using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User_Crud.Data;
using User_Crud.Models;
using User_Crud.Models.Entities;

namespace User_Crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public UserController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult getAllUsers()
        {
             var allUsers = dbContext.Users.ToList();
            return Ok(allUsers);

        }
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult getUserById(Guid id)
        {
           var user = dbContext.Users.Find(id);
            if (user is null)
            {
                return NotFound();
                
            }
            return Ok(user);


        }

        [HttpPost]
        public IActionResult AddUser(AddUserDto addUserDto)
        {
            var userEntity = new user()
            {
                Name = addUserDto.Name,
                Email = addUserDto.Email,
                Password = addUserDto.Password,
                Phone = addUserDto.Phone,


            };

           dbContext.Users.Add(userEntity);
            dbContext.SaveChanges();
            return Ok(userEntity);
        }


        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateUser(Guid id , UpdateUserDto updateUserDto)
        {
            var user = dbContext.Users.Find(id);
            if (user is null)
            {
                return NotFound();

            }
            user.Name = updateUserDto.Name;
            user.Email = updateUserDto.Email;
            user.Password = updateUserDto.Password;
            user.Phone = updateUserDto.Phone;
            dbContext.SaveChanges();
            return Ok(user);


        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteUser(Guid id) {

            var user = dbContext.Users.Find(id);
            if (user is null)
            {
                return NotFound();

            }
          
            dbContext.Remove(user);
            dbContext.SaveChanges();
            return Ok();
        }
    }

}

