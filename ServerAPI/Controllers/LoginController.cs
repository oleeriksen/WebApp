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
        [Route("verify/{username}/{password}")]
        public User? VerifyLogin(string username, string password)
        {
            var validUser = mRepo.Verify(username, password);
            return validUser; 
        }
    }
}

