using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HrChallenge.Models
{
    public class CommentCreate
    {
        [Required]
        [MaxLength(140)]
        public string Content { get; set; }
    }
}
