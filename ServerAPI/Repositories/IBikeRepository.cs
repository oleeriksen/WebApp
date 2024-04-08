using System;
using Core.Model;
namespace ServerAPI.Repositories
{
	public interface IBikeRepository
	{
		BEBike[] GetAll();
		void Add(BEBike bike);
	}
}

