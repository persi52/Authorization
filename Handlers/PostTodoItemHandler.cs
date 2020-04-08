using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApplication1.Commands;
using WebApplication1.Modele;

namespace WebApplication1.Controllers
{
    public class PostTodoItemHandler : IRequestHandler<PostTodoItemCommand>
    {
        public TodoContext _context;

        public PostTodoItemHandler(TodoContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(PostTodoItemCommand request, CancellationToken cancellationToken)
        {
            var todoitem = new TodoItem
            {
                mail = request.mail,
                tresc = request.tresc
            };
             _context.TodoItems.Add(todoitem);
            //await _context.SaveChangesAsync();
            var order2 = await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
