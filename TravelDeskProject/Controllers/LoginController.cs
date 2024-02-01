using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelDeskProject.IRepo;
using TravelDeskProject.ViewModel;

namespace TravelDeskProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        ILoginRepo _loginRepo;

        public LoginController(ILoginRepo loginRepo)
        {
            _loginRepo = loginRepo;
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel loginuser)
        {
            if(_loginRepo.Login(loginuser))
            {
                return Ok(loginuser);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
