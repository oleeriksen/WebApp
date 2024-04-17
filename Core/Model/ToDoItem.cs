using System;
namespace Core.Model
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public bool IsDone { get; set; }
        public required string Title { get; set; }
        public string Priority { get; set; } = "Normal";
    }
}

