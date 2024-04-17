using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Model;
using Microsoft.AspNetCore.Mvc;
using ServerAPI.Repositories.ToDoRepository;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerAPI.Controllers
{
    [ApiController]
    [Route("api/todo")]
    public class ToDoController : ControllerBase
    {

        private IToDoRepository mRepo;

        public ToDoController(IToDoRepository repo) {
            mRepo = repo;
        }

        [HttpGet]
        [Route("getall")]
        public ToDoItem[] GetAll()
        {
            return mRepo.GetAll();
        }

        [HttpDelete]
        [Route("delete/{n:int}")]
        public void Delete(int n) {
            mRepo.Delete(n);
        }

        [HttpPost]
        [Route("update")]
        public void Update(ToDoItem item) {
            mRepo.Update(item);
        }

        [HttpPost]
        [Route("add")]
        public void Add(ToDoItem item) {
            mRepo.Add(item);
        }

    }

}

