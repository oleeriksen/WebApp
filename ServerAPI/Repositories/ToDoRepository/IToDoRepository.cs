using System;
using Core.Model;

namespace ServerAPI.Repositories.ToDoRepository
{
    public interface IToDoRepository
    {
        ToDoItem[] GetAll();

        void Delete(int id);

        void Update(ToDoItem item);

        void Add(ToDoItem item);
    }
}

