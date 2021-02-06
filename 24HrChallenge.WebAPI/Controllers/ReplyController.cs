using _24HrChallenge.Models;
using _24HrChallenge.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _24HrChallenge.WebAPI.Controllers
{
    public class ReplyController : ApiController
    {

        


            private ReplyService CreateReplyService()
            {
                var userId = Guid.Parse(User.Identity.GetUserId());
                var replyService = new ReplyService(userId);
                return replyService;
            }


            public IHttpActionResult Get(int id)
            {

                ReplyService replyService = CreateReplyService();
                var userId = Guid.Parse(User.Identity.GetUserId());

                CommentService commentService = new CommentService(userId);
                var comment = commentService.GetCommentById(id);
                

                var replies = replyService.GetReplies(comment.CommentId);
                return Ok(replies);
            }

            public IHttpActionResult Post(ReplyCreate reply)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var service = CreateReplyService();

                if (!service.CreateReply(reply))
                    return InternalServerError();

                return Ok();

            }

            //public IHttpActionResult Get(int id)
            //{
            //    ReplyService noteService = CreateReplyService();
            //    var note = ReplyService.GetReplyById(id);
            //    return Ok(note);
            //}

            public IHttpActionResult Put(ReplyEdit reply)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var service = CreateReplyService();

                if (!service.UpdateReply(reply))
                    return InternalServerError();

                return Ok();
            }

            public IHttpActionResult Delete(int id)
            {
                var service = CreateReplyService();

                if (!service.DeleteReply(id))
                    return InternalServerError();

                return Ok();
            }

        }
    
}
