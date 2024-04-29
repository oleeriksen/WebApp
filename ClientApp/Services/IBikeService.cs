using System;
using Core.Model;
namespace ClientApp.Services
{
    public interface IBikeService
    {
        Task<BEBike[]> GetAll();

        Task Add(BEBike bike);
    }
}

