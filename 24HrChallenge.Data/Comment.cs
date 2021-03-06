﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HrChallenge.Data
{
    public class Comment
    {
        // Primary Key
        [Key]
        public int Id { get; set; }

        // Foreign Key
        [ForeignKey(nameof(Post))]
        public int PostId { get; set; }

        // Navigation Property

        public virtual Post Post { get; set; }

        [Required]
        public string Text { get; set; }
        
        [Required]
        public Guid Author { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }


        public virtual List<Reply> Replies { get; set; } = new List<Reply>();
    }
}
