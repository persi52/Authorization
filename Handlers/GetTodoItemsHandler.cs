using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApplication1.Modele;
using WebApplication1.Queries;

namespace WebApplication1.Handlers
{
    public class GetTodoItemsHandler : IRequestHandler<GetTodoItemsQuery, List<TodoItem>>
    {
        private readonly TodoContext _context;
        
        public GetTodoItemsHandler(TodoContext context)
        {
            _context = context;
        }
        
        public async Task<List<TodoItem>> Handle(GetTodoItemsQuery request, CancellationToken cancellationToken)
        {

            return await _context.TodoItems.ToListAsync();
        }
    }
}
