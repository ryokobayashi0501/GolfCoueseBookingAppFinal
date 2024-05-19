using GolfCoueseBookingApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace GolfCoueseBookingApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // => [controller] maps to "Course" because the class is called UserController
    public class CourseController : ControllerBase
    {
        /// <summary>
        /// path to this action is : http://localhost:port/api/course/getItems
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
                    // and map rows to the CourseModel class
                    List<CourseModel> course = await db.Course.ToListAsync();
                    // return the users
                    return new ObjectResult(course);
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
        /// path to this action is : http://localhost:port/api/course/getById/12  (for example)
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
                    // select * from course
                    // and map rows to the CourseModel class
                    CourseModel course = await db.Course.FirstOrDefaultAsync(x => x.CourseId == id); // return CourseModel or null
                    // above Entity Framework query will get translated to:
                    //
                    // SELECT TOP(1) [u].[UserId], [u].[EmailAddress], [u].[FirstName], [u].[IsActive], [u].[LastName], [u].[PasswordHash]
                    // FROM [User] AS [u]
                    // WHERE [u].[UserId] = @__id_0

                    // return the users
                    return new ObjectResult(course);
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
        public async Task<IActionResult> Post([FromBody] CourseModel value)
        {
            try
            {
                Console.WriteLine("Adding user with email address " + value.Address);

                // connect to the database
                using (MyContext db = new MyContext())
                {
                    //if (await db.Course.FirstOrDefaultAsync(x => x.Address == value.Address) != null)
                    //{
                    //    Console.WriteLine("User with email address " + value.Address + " already exists");
                    //    return BadRequest("User with email address " + value.Address + " already exists"); // return a 400
                    //}
                            // public Int64 CourseId { get; set; }
                            //public Int64 UserId { get; set; }

                            //[MaxLength(250)]
                            //public String? CourseName { get; set; }
                            //[MaxLength(250)]
                            //public String? CourseURL { get; set; }
                            //[MaxLength(250)]
                            //public String? Address { get; set; }
                            //[MaxLength(512)]
                            //public String? Description { get; set; }
                            //public Int64? TelephoneNumber { get; set; }

                    CourseModel course = new CourseModel();
                    course.UserId = value.UserId;
                    
                    course.CourseName = value.CourseName;
                    course.CourseURL = value.CourseURL;
                    course.Address = value.Address;
                    course.Description = value.Description;
                    course.TelephoneNumber = value.TelephoneNumber;
                    db.Course.Add(course);
                    await db.SaveChangesAsync();

                    return new ObjectResult(course);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("inner exception" + ex.InnerException);
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
        public async Task<IActionResult> Put([FromBody] CourseModel value, Int64 id)
        {
            try
            {
                Console.WriteLine("Updating user id " + id);

                // connect to the database
                using (MyContext db = new MyContext())
                {
                    CourseModel course = await db.Course.FirstOrDefaultAsync(x => x.CourseId == id);
                    if (course == null)
                    {
                        Console.WriteLine("User id " + id + "not found");
                        return NotFound("User not found"); // return a 404
                    }

                    if (await db.Course.FirstOrDefaultAsync(x => x.Address == value.Address && x.CourseId != id) != null)
                    {
                        Console.WriteLine("Other user with email address " + value.Address + " already exists");
                        return BadRequest("Invalid request"); // return a 400
                    }

                    
                    course.UserId = value.UserId;
                    course.CourseURL = value.CourseURL;
                    course.CourseName = value.CourseName;
                    course.TelephoneNumber = value.TelephoneNumber;
                    course.Description = value.Description;
                    db.Course.Add(course);
                    await db.SaveChangesAsync();

                    return new ObjectResult(course);
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
                    CourseModel course = await db.Course.FirstOrDefaultAsync(x => x.CourseId == id); // return UserModel or null
                    if (course != null)
                    {
                        db.Course.Remove(course);
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

                    List<CourseModel> course = await db.Course.Where(x => ids.Contains(x.CourseId)).ToListAsync(); // return UserModel or null
                    if (course != null)
                    {
                        db.Course.RemoveRange(course);
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