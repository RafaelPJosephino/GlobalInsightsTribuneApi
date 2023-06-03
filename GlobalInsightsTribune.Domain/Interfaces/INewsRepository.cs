

using GlobalInsightsTribune.Domain.Entities;

namespace GlobalInsightsTribune.Domain.Interfaces
{
    public interface INewsRepository
    {
        IEnumerable<News> GetNewsAll();
    }
}
