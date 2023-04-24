using GlobalInsightsTribuneApi.Entitys;

namespace GlobalInsightsTribuneApi.Interfaces
{
    public interface IUsersRepository
    {
        void Add(Users users);
        void Update(Users users);
        void Remove(Users users);
        Task<Users> SelectById(int id);
        Task<bool> SaveAllAsync();
    }
}
