using GlobalInsightsTribune.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GlobalInsightsTribune.Domain.Entities
{
    public class Comment
    {
        public int Id { get; private set; }
        public int NewsId { get; private set; }
        public int UserId { get; private set; }
        public string Content { get; private set; }
        public DateTime CommentDate { get; private set; }

        //teste

        public Comment(int newsId, int userId, string content, DateTime commentDate)
        {
            
            ValidateDomain(newsId, userId, content, commentDate);
        }

        public Comment(int id, int newsId, int userId, string content, DateTime commentDate)
        {
            DomainExceptionValidation.When(id < 0, "Error: Invalid Comment Id");

            Id = id;
            ValidateDomain(newsId, userId, content, commentDate);
        }

        public void Update(int newsId, int userId, string content, DateTime commentDate)
        {
            ValidateDomain(newsId, userId, content, commentDate);
        }

        public void ValidateDomain(int newsId, int userId, string content, DateTime commentDate)
        {
            DomainExceptionValidation.When(content.Length > 1000, "Error: Comment exceeds maximum length of 1000 characters");

            NewsId = newsId;
            UserId = userId;
            Content = content;
            CommentDate = commentDate;
        }
    }

}
