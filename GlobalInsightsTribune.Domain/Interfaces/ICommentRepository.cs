

using GlobalInsightsTribune.Domain.Entities;

namespace GlobalInsightsTribune.Domain.Interfaces
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> GetCommentAll();
    }
}
