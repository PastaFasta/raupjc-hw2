using System;
using System.Collections.Generic;
using System.Linq;

namespace Zad2
{
    public class TodoRepository : ITodoRepository
    {

        /// <summary >
        /// Repository does not fetch todoItems from the actual database ,
        /// it uses in memory storage for this excersise .
        /// </ summary >
        private readonly IGenericList<TodoItem> _inMemoryTodoDatabase;

        public TodoRepository(IGenericList<TodoItem> initialDbState = null)
        {
            if (initialDbState != null)
            {
                _inMemoryTodoDatabase = initialDbState;
            }
            else
            {
                _inMemoryTodoDatabase = new GenericList<TodoItem>();
            }
            // Shorter way to write this in C# using ?? operator :
            // x ?? y => if x is not null , expression returns x. Else it will return y.
            // _inMemoryTodoDatabase = initialDbState ?? new List < TodoItem >();    
        }

        #region ItodoRepository

        public TodoItem Get(Guid todoId)
        {
            return _inMemoryTodoDatabase.FirstOrDefault(i => i.Id == todoId);
        }

        public TodoItem Add(TodoItem todoItem)
        {
            if (todoItem == null)
            {
                throw new ArgumentNullException();
            }
            else if (Get(todoItem.Id) == null)
            {
                _inMemoryTodoDatabase.Add(todoItem);
                return todoItem;
            }
            else
            {
                throw new DuplicateTodoItemException($"duplicate id: {todoItem.Id}");
            }
        }

        public bool Remove(Guid todoId)
        {
            TodoItem item = Get(todoId);
            if (item == null)
            {
                return false;
            }
            return _inMemoryTodoDatabase.Remove(item);
        }

        public TodoItem Update(TodoItem todoItem)
        {
            if (todoItem == null)
            {
                throw new ArgumentNullException();
            }

            TodoItem updateItem = Get(todoItem.Id);
            if (updateItem == null)
            {
                return Add(todoItem);
            }
            updateItem.Text = todoItem.Text;
            return updateItem;
        }

        public bool MarkAsCompleted(Guid todoId)
        {
            TodoItem item = Get(todoId);
            if (item == null)
            {
                return false;
            }
            return item.MarkAsCompleted();
        }

        public List<TodoItem> GetAll()
        {
            return _inMemoryTodoDatabase.OrderByDescending(i => i.DateCreated).ToList();
        }

        public List<TodoItem> GetActive()
        {
            return _inMemoryTodoDatabase.Where(i => !i.IsCompleted).OrderByDescending(i => i.DateCreated).ToList();
        }

        public List<TodoItem> GetCompleted()
        {
            return _inMemoryTodoDatabase.Where(i => i.IsCompleted).OrderByDescending(i => i.DateCreated).ToList();
        }

        public List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction)
        {
            return _inMemoryTodoDatabase.Where(filterFunction).OrderByDescending(i => i.DateCreated).ToList();
        }

        #endregion ItodoRepository
    }
}
