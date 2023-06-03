using GlobalInsightsTribune.Domain.Entities;
using GlobalInsightsTribune.Domain.Interfaces;
using GlobalInsightsTribune.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalInsightsTribune.Infra.Data.Repositories
{
    internal class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;

        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Comment> GetCommentAll()
        {
            return _context.Comment;
        }
    }
}
