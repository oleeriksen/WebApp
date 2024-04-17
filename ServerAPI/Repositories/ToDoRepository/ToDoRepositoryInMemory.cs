using System;
using Core.Model;

namespace ServerAPI.Repositories.ToDoRepository
{
    public class ToDoRepositoryInMemory : IToDoRepository
    {
        List<ToDoItem> items;
        public ToDoRepositoryInMemory()
        {
            items = new();
            items.Add(new ToDoItem { Id=1, Title = "todo 1", IsDone = false });
            items.Add(new ToDoItem { Id=2, Title = "todo 2", IsDone = true });

        }

        public void Add(ToDoItem item)
        {
            ;
            var newId = items.Max<ToDoItem>(a => a.Id) + 1; //FIXed
            item.Id = newId;
            items.Add(item);
        }

        public void Delete(int id)
        {
            items.RemoveAll(item => item.Id == id);
        }

        public ToDoItem[] GetAll() => items.ToArray();


        public void Update(ToDoItem item)
        {
            Delete(item.Id);
            Add(item);
        }
    }
}

