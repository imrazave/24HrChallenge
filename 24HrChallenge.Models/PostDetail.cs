using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HrChallenge.Models
{
    public class PostDetail
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        //public virtual List<Comment> Comments { get; set; } = new List<Comment>();


        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
       
    }
}
