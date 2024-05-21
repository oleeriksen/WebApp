using Microsoft.AspNetCore.Mvc;
using ServerAPI.Repositories;
using Core.Model;


namespace ServerAPI.Controllers
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
        public bool VerifyLogin([FromQuery] string username, [FromQuery] string password)
        {
            return mRepo.Verify(username, password);       
        }

        [HttpGet]
        [Route("getuser")]
        public User GetUserByUserName([FromQuery] string username)
        {
            return mRepo.GetUserByUserName(username);
        }

    }
}

