using _24HrChallenge.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _24HrChallenge.WebAPI.Controllers
{
    [Authorize]
    public class CommentController : ApiController
    {
        private CommentService CreateCommentService()
        {
            var postId = Guid.Parse(post.Identity.GetUserId());
            var commentService = new CommentService(postId);
            return commentService;
        }

        public IHttpActionResult Get()
        {
            CommentService commentService = CreateCommentService();
            var notes = commentService.GetComment();
            return Ok(comments);
        }

        public IHttpActionResult Post(CommentCreate comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCommentService();

            if (!service.CreateComment(comment))
                return InternalServerError();

            return Ok();
        }
    }
}
