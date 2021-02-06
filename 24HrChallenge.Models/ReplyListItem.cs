using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HrChallenge.Models
{
    public class ReplyListItem
    {

        public int ReplyId { get; set; }
        
        public string Text { get; set; }

        public string PostTitle { get; set; }

        [Display(Name="Created")]
        public DateTimeOffset CreatedUtc { get; set; }

       
    }
}
