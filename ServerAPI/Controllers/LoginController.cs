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
        [Route("verify")]
        public bool VerifyLogin([FromQuery] string username, [FromQuery] string password)
        {
            var crypt = new SimpleEncryption(12);
            var clearPassword = crypt.Decrypt(password);
            return mRepo.Verify(username, clearPassword);
        }

        [HttpGet]
        [Route("getuser")]
        public User GetUser([FromQuery] string username)
        {
            return mRepo.GetUserByUserName(username);
        }
    }
}

