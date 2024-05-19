using GolfCoueseBookingApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GolfCoueseBookingApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // => [controller] maps to "User" because the class is called UserController
    public class UserController : ControllerBase
    {
        /// <summary>
        /// path to this action is : http://localhost:port/api/user/getItems
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")] // => [action] maps to "GetItems" because the method is called getItems()
        public async Task<IActionResult> GetItems()
        {
            try
            {
                // connect to the database
                using (MyContext db = new MyContext())
                {
                    // select * from users
                    // and map rows to the UserModel class
                    List<UserModel> users = await db.User.ToListAsync();
                    // return the users
                    return new ObjectResult(users);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("GetItems got exception: " + ex.Message + ", Stack = " + ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }

        // getById

        /// <summary>
        /// path to this action is : http://localhost:port/api/user/getById/12  (for example)
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]/{id}")] // => [action] maps to "getById" because the method is called GetById()
        public async Task<IActionResult> GetById(Int64 id)
        {
            try
            {
                // connect to the database
                using (MyContext db = new MyContext())
                {
                    // select * from users
                    // and map rows to the UserModel class
                    UserModel user = await db.User.FirstOrDefaultAsync(x => x.UserId == id); // return UserModel or null
                    // above Entity Framework query will get translated to:
                    //
                    // SELECT TOP(1) [u].[UserId], [u].[EmailAddress], [u].[FirstName], [u].[IsActive], [u].[LastName], [u].[PasswordHash]
                    // FROM [User] AS [u]
                    // WHERE [u].[UserId] = @__id_0

                    // return the users
                    return new ObjectResult(user);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("GetById got exception: " + ex.Message + ", Stack = " + ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }

        // post
        /// <summary>
        /// path to this action is : http://localhost:port/api/user/getById/12  (for example)
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<IActionResult> Post([FromBody] UserModel value)
        {
            try
            {
                Console.WriteLine("Adding user with email address " + value.EmailAddress);

                // connect to the database
                using (MyContext db = new MyContext())
                {
                    if (await db.User.FirstOrDefaultAsync(x => x.EmailAddress == value.EmailAddress) != null)
                    {
                        Console.WriteLine("User with email address " + value.EmailAddress + " already exists");
                        return BadRequest("User with email address " + value.EmailAddress + " already exists"); // return a 400
                    }

                    UserModel user = new UserModel();
                    user.FirstName = value.FirstName;
                    user.LastName = value.LastName;
                    user.EmailAddress = value.EmailAddress;
                    user.IsActive = true;
                    user.Password = null;
                    db.User.Add(user);
                    await db.SaveChangesAsync();

                    return new ObjectResult(user);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Post got exception: " + ex.Message + ", Stack = " + ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }

        // put
        /// <summary>
        /// path to this action is : http://localhost:port/api/user/getById/12  (for example)
        /// </summary>
        /// <returns></returns>
        [HttpPut("[action]/{id}")] // => [action] maps to "getById" because the method is called GetById()
        public async Task<IActionResult> Put([FromBody] UserModel value, Int64 id)
        {
            try
            {
                Console.WriteLine("Updating user id " + id);

                // connect to the database
                using (MyContext db = new MyContext())
                {
                    UserModel user = await db.User.FirstOrDefaultAsync(x => x.UserId == id);
                    if (user == null)
                    {
                        Console.WriteLine("User id " + id + "not found");
                        return NotFound("User not found"); // return a 404
                    }

                    if (await db.User.FirstOrDefaultAsync(x => x.EmailAddress == value.EmailAddress && x.UserId != id) != null)
                    {
                        Console.WriteLine("Other user with email address " + value.EmailAddress + " already exists");
                        return BadRequest("Invalid request"); // return a 400
                    }

                    user.FirstName = value.FirstName;
                    user.LastName = value.LastName;
                    user.EmailAddress = value.EmailAddress;
                    user.IsActive = true;
                    user.Password = null;
                    db.User.Update(user);
                    await db.SaveChangesAsync();

                    return new ObjectResult(user);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Put got exception: " + ex.Message + ", Stack = " + ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }

        // delete
        /// <summary>
        /// path to this action is : http://localhost:port/api/user/delete/12  (for example)
        /// </summary>
        /// <returns></returns>
        [HttpDelete("[action]/{id}")] // => [action] maps to "getById" because the method is called GetById()
        public async Task<IActionResult> Delete(Int64 id)
        {
            try
            {
                Console.WriteLine("Deleting user id " + id);

                // connect to the database
                using (MyContext db = new MyContext())
                {
                    CourseModel user = await db.Course.FirstOrDefaultAsync(x => x.UserId == id); // return UserModel or null
                    if (user != null)
                    {
                        db.Course.Remove(user);
                        await db.SaveChangesAsync();
                    }
                    return new OkResult();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Delete got exception: " + ex.Message + ", Stack = " + ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("[action]")] // => [action] maps to "getById" because the method is called GetById()
        public async Task<IActionResult> DeleteBulk([FromBody] Int64[] ids)
        {
            try
            {
                Console.WriteLine("Deleting users in buld" + String.Join(" ", ids));

                // connect to the database
                using (MyContext db = new MyContext())
                {

                    List<CourseModel> users = await db.Course.Where(x => ids.Contains(x.UserId)).ToListAsync(); // return UserModel or null
                    if (users != null)
                    {
                        db.Course.RemoveRange(users);
                        await db.SaveChangesAsync();
                    }
                    return new OkResult();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Delete got exception: " + ex.Message + ", Stack = " + ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }
    }
}