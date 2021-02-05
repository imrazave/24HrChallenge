using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HrChallenge.Data
{
    public class Reply
    {
        [Key]
        public int Id { get; set; }

        //Foreign Key
        [ForeignKey(nameof(Comment))]
        public int PostId { get; set; }

        [Required]
        public int Text { get; set; }

        [Required]
        public Guid Author { get; set; }





    }
}
