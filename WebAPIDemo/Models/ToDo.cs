using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIDemo.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; } = false;
        public DateTime? DateAdded { get; set; } = DateTime.Now;
        public DateTime? DateDone { get; set; }
        public DateTime? DeadlineDate { get; set; } = DateTime.Now.AddDays(3);
        public int? AssignedToId { get; set; }

        [ForeignKey(nameof(AssignedToId))]
        public virtual User User { get; set; }
    }
}