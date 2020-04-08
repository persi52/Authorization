using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Commands;
using WebApplication1.Modele;
using WebApplication1.Queries;

namespace WebApplication1.Controllers
{
    [Authorize]

    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly TodoContext _context;
        private readonly IMediator _mediator;

        public TodoItemsController(TodoContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetTodoItems()//<IEnumerable<TodoItem>>> GetTodoItems()
        {
            var query = new GetTodoItemsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
            //return await _context.TodoItems.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetTodoItemById(long id)//ActionResult<TodoItem>> GetTodoItem(long id)
        {
            var query = new GetTodoItemByIdQuery(id);// var todoItem = await _context.TodoItems.FindAsync(id);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult) Ok(result) : NotFound();

            /*if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;*/
        }
        
      
        [HttpPost]
        public async Task<IActionResult> PostTodoItem(PostTodoItemCommand command)//ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
        {
            // _context.TodoItems.Add(todoItem); await _context.SaveChangesAsync();
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }



    }
}
