using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HrChallenge.Models
{
    public class ReplyByAuthor
    {

        public int Id { get; set; }
        
        public int Text { get; set; }

        
        public Guid Author { get; set; }

        [Display(Name="Created")]
        public DateTimeOffset CreatedUtc { get; set; }

       
    }
}
