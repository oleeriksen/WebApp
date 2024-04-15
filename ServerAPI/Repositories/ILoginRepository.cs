using System;
using Core.Model;

namespace ServerAPI.Repositories
{
    public interface ILoginRepository
    {

        User? Verify(string userName, string password);

        User[] GetAll();
    }
}

