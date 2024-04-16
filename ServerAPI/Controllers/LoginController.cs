using Microsoft.AspNetCore.Mvc;
using ServerAPI.Repositories;
using Core.Model;


namespace HelloBlazor.Server.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : ControllerBase
    {
        ILoginRepository mRepo;
        public LoginController(ILoginRepository repo)
        {
            mRepo = repo;
        }

        [HttpGet]
        [Route("verify")]
        public User VerifyLogin([FromQuery] string username, [FromQuery] string password)
        {
            var validUser = mRepo.Verify(username, password);
            
            return validUser?? new User { UserName = "NO-NAME"}; 
        }
    }
}

