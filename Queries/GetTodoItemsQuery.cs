using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Modele;

namespace WebApplication1.Queries
{
    public class GetTodoItemsQuery : IRequest<List<TodoItem>>
    {
    }
}
