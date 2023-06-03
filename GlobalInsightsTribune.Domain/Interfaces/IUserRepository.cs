
using GlobalInsightsTribune.Domain.Entities;

namespace GlobalInsightsTribune.Domain.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUserAll();

        void RegisterUser(User user);
    }
}
