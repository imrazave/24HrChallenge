using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HrChallenge.Models
{
    public class ReplyEdit
    {

        public int Id { get; set; }
        
        public int Text { get; set; }

        public Guid Author { get; set; }
    }
}
