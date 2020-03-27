    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using todoapp.Models.Interfaces;

namespace todoapp.Models
{
    public class TaskTodo : IEntity
    {
       public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
       
        public string Description { get; set; }

        public bool Completed { get; set; }
    }
}
