using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApplication1.Modele;
using WebApplication1.Queries;

namespace WebApplication1.Handlers
{
    public class GetTodoItemByIdHandler : IRequestHandler<GetTodoItemByIdQuery, TodoItem>
    {
        private readonly TodoContext _context;

        public GetTodoItemByIdHandler(TodoContext context)
        {
            _context = context;
        }

        public async Task<TodoItem> Handle(GetTodoItemByIdQuery request, CancellationToken cancellationToken)
        {                       
            return await _context.TodoItems.FindAsync(request.id);
        }
    }
}
