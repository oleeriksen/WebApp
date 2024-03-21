using System;
namespace ClientApp.Util
{
    public class ToDoPriorityComparator : IComparer<ToDoItem>
    {
        public ToDoPriorityComparator()
        {
        }

        public int Compare(ToDoItem? x, ToDoItem? y)
        {
            if (x is null)
                return -1;
            if (y is null)
                return 1;
            return -x.Priority.CompareTo(y.Priority);
            // - to reverse from high to low..
        }
    }
}

