using System;
using System.Collections.Generic;
using TodoExample.Api.Models;

namespace TodoExample.Api.Repositories
{
    public interface ITodoRepository
    {
        public List<TodoModel> GetAll();
        public TodoModel GetById(Guid todoId);
        public TodoModel Create(TodoCreateModel createModel);
        public TodoModel Update(Guid todoId, TodoUpdateModel updateModel);
        public void Delete(Guid todoId);
    }
}