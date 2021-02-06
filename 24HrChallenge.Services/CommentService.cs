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
        private readonly Guid _postId;
        public CommentService(Guid userId)
        {
            _postId = userId;
        }

        public bool CreateComment(CommentCreate model)
        {
            var entity =
                new Comment()
                {
                    PostId = _postId,
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
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new CommentListItem
                        {
                            CommentId = e.PostId,
                            Text = e.Text,
                        }
                        );

                return query.ToArray();
            }
        }
    }
}
