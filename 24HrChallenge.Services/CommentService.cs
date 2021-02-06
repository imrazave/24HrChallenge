using _24HrChallenge.Data;
using _24HrChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HrChallenge.Services
{
    public class CommentService
    {
        private readonly Guid _userId;
        public CommentService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateComment(CommentCreate model)
        {
            var entity =
                new Comment()
                {
<<<<<<< HEAD
=======
                    PostId = model.PostId,
>>>>>>> a19e8dc76da5aa1c54f67793492400fa82b67bd7
                    Author = _userId,
                    Text = model.Content
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CommentListItem> GetComment()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Comments
                    .Where(e => e.Author == _userId)
                    .Select(
                        e =>
                        new CommentListItem
                        {
                            Id = e.PostId,
                            Text = e.Text,
                        }
                        );

                return query.ToArray();
            }
        }

        public CommentDetails GetCommentById(int id)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Comments.Single(e => e.Id == id && e.Author == _userId);
                return
                    new CommentDetails
                    {
                        CommentId = entity.Id,
                        Text = entity.Text,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
    }
}
