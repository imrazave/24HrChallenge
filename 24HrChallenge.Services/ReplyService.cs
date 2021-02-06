using _24HrChallenge.Data;
using _24HrChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HrChallenge.Services
{
    public class ReplyService
    {

        private readonly Guid _userId;

        public ReplyService(Guid userId)
        {
            _userId = userId;
        }


        
        public bool CreateReply(ReplyCreate model)
        {

            var entity = new Reply()
            {
                Author = _userId,
                CommentId = model.CommentId,
                Text = model.Text,
                CreatedUtc = DateTimeOffset.Now
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Replies.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }

        public IEnumerable<ReplyListItem> GetReplies(int commentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Replies
                    .Where(e => e.CommentId == commentId)
                    .Select(e => new ReplyListItem
                    {
                        ReplyId = e.ReplyId,
                        Text = e.Text,
                        CreatedUtc = e.CreatedUtc,
                        PostTitle = e.Comment.Post.Title
                    });

                return query.ToArray();
            }
        }

        public bool UpdateReply(ReplyEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Replies.Single(e => e.ReplyId == model.Id && e.Author == _userId);

                entity.Text = model.Text;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteReply(int replyId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Replies.Single(e => e.ReplyId == replyId && e.Author == _userId);

                ctx.Replies.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    

    }
}
