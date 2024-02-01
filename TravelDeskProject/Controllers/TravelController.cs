using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using TravelDeskProject.IRepo;
using TravelDeskProject.Models;
using TravelDeskProject.Repo;

namespace TravelDeskProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TravelController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;
        private TravelDbContext _context;
        IUserRepo _userRepo;
        public TravelController(IUserRepo userRepo,IMemoryCache memoryCache, TravelDbContext context)
        {
            _userRepo = userRepo;
            _memoryCache = memoryCache;
            _context = context;

        }
        [HttpGet]
        [Route("GetUser/{id}")]
        public IActionResult GetUser(int id)
        {
            User user= _userRepo.GetUser(id);
            return Ok(user);
        

        }
        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser(User user)
        {
            _userRepo.Add(user);
            return Ok("Added successfully.");
        }
        [HttpGet]
        [Route("AllUsers")]
        public async Task<IActionResult> AllUsers() 
        {
            var cacheKey = "UserList";
            //checks if cache entries exists
            if (!_memoryCache.TryGetValue(cacheKey, out List<User> UserList))
            {
                //calling the server

                UserList = await _context.Users.Where(x=>x.IsActive==true).ToListAsync();
                //setting up cache options
                var cacheExpiryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddSeconds(50),
                    Priority = CacheItemPriority.High,
                    SlidingExpiration = TimeSpan.FromSeconds(20)
                };
                //setting cache entries
                _memoryCache.Set(cacheKey, UserList, cacheExpiryOptions);
            }
            return Ok(UserList);
        }
        [HttpDelete]
        [Route("DeleteUser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            _userRepo.DeleteUser(id);
            return Ok("User deleted Successfully!!!");
        }
        [HttpPatch]
        [Route("EditUser/{id}")]
        public IActionResult EditUser(int id, User user)
        {
            _userRepo.EditUser(id,user);
            return Ok("User edited successfully!!!");
        }
    }
}
