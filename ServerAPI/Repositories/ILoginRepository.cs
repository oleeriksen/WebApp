﻿using System;
using Core.Model;

namespace ServerAPI.Repositories
{
    public interface ILoginRepository
    {

        bool Verify(string userName, string password);

        User GetUserByUserName(string username);

    }
}

