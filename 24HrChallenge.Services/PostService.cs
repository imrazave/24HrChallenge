﻿using _24HrChallenge.Data;
using _24HrChallenge.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HrChallenge.Services
{
    public class PostService
    {
        private readonly Guid _userId;

        public PostService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePost(PostCreate model)
        {
            var entity =
                new Post()
                {
                    Author = _userId,
                    Title = model.Title,
                    Text = model.Text,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }


        }

        public IEnumerable<PostListItem> GetPost()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Posts

                        .Where(e => e.Author == _userId)

                        .Select(
                            e =>
                                new PostListItem
                                {
                                    PostId = e.Id,
                                    Title = e.Title,
                                    Text = e.Text,
                                    CreatedUtc = e.CreatedUtc

                                }
                        );

                return query.ToArray();
            }
        }
    }
}
