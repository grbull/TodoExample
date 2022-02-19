using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoExample.Api.Models;
using TodoExample.Api.Repositories;

namespace TodoExample.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : Controller
    {
        private readonly ITodoRepository _todoRepository;

        public TodoController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<TodoModel>))]
        public IActionResult GetAll()
        {
            return this.Ok(this._todoRepository.GetAll());
        }
        
        [HttpGet("{todoId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TodoModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(Guid todoId)
        {
            var todoItem = this._todoRepository.GetById(todoId);
            if (todoItem is null)
            {
                return this.NotFound();
            }
            
            return this.Ok(todoItem);
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TodoModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        public IActionResult Create([FromBody] TodoCreateModel createModel)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState.ValidationState);
            }

            var todoItem =this._todoRepository.Create(createModel);

            return this.Ok(todoItem);
        }
        
        [HttpPut("{todoId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        public IActionResult Update(Guid todoId, TodoUpdateModel updateModel)
        {
            if (this._todoRepository.GetById(todoId) is null)
            {
                return this.NotFound();
            }
            
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState.ValidationState);
            }

            var todoItem = this._todoRepository.Update(todoId, updateModel);
            
            return this.Ok(todoItem);
        }
        
        [HttpDelete("{todoId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(Guid todoId)
        {
            if (this._todoRepository.GetById(todoId) is null)
            {
                return this.NotFound();
            }
            
            this._todoRepository.Delete(todoId);
            
            return this.Ok();
        }
    }
}