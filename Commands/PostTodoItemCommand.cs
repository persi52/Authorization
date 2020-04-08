using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Modele;

namespace WebApplication1.Commands
{
    public class PostTodoItemCommand : IRequest
    {
        public long id { get; set; }
        public string mail { get; set; }
        public string tresc { get; set; }
    }
}
