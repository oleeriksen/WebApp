using System;
using System.Collections;

namespace ClientApp.Util
{
    public class ToDoItem : IComparable<ToDoItem>
    {
        public bool IsDone { get; set; }
        public required string Title { get; set; }
        public int Priority { get; set; } = 2;

        public int CompareTo(ToDoItem? other)
        {
            return -Priority.CompareTo(other.Priority);
        }
    }
}

