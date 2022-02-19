using System;
using System.Collections.Generic;
using System.Linq;
using TodoExample.Api.Models;

namespace TodoExample.Api.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly List<TodoModel> _todoItems = new List<TodoModel>
        {
            new TodoModel {Id = Guid.NewGuid(), Task = "Task 1"},
            new TodoModel {Id = Guid.NewGuid(), Task = "Task 2"},
            new TodoModel {Id = Guid.NewGuid(), Task = "Task 3"},
            new TodoModel {Id = Guid.NewGuid(), Task = "Task 4"},
            new TodoModel {Id = Guid.NewGuid(), Task = "Task 5"}
        };

        public List<TodoModel> GetAll()
        {
            return this._todoItems;
        }
        
        public TodoModel GetById(Guid todoId)
        {
            return this._todoItems.FirstOrDefault(todo => todo.Id == todoId);
        }

        public TodoModel Create(TodoCreateModel createModel)
        {
            var todoItem = new TodoModel
            {
                Id = Guid.NewGuid(),
                Task = createModel.Task
            };
            
            this._todoItems.Add(todoItem);

            return todoItem;
        }

        public TodoModel Update(Guid todoId, TodoUpdateModel updateModel)
        {
            var todoItem = this._todoItems.First(todo => todo.Id == todoId);
            todoItem.Task = updateModel.Task;
            return todoItem;
        }

        public void Delete(Guid todoId)
        {
            var todoItem = this._todoItems.First(todo => todo.Id == todoId);
            this._todoItems.Remove(todoItem);
        }
    }
}