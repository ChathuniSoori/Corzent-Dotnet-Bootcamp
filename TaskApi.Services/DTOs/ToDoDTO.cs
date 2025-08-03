using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApi.Services.DTOs
{
    public class ToDoDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public bool isCompleted { get; set; }
        public int Priority { get; set; }
        public string Category { get; set; }

        
    }
}
