using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Modele
{
    public class TodoItem
    {      
        [Key]
        public long Id { get; set; }
        [Required]
        [EmailAddress]
        public string mail { get; set; }
        
        [StringLength(150, ErrorMessage = "Message needs to be beetwen [0,150]")]
        public string tresc { get; set; }
    }
}
