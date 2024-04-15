using Microsoft.AspNetCore.Mvc;
using ServerAPI.Repositories;
using Core.Model;
using Core.Crypto;


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
            var crypt = new SimpleEncryption(12);
            var clearPassword = crypt.Decrypt(password);
            var validUser = mRepo.Verify(username, clearPassword);
            return validUser; 
        }
    }
}

