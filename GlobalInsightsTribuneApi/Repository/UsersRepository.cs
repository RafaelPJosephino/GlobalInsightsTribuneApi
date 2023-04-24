using GlobalInsightsTribuneApi.Context;
using GlobalInsightsTribuneApi.Entitys;
using GlobalInsightsTribuneApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GlobalInsightsTribuneApi.Repository
{
    public class UsersRepository: IUsersRepository
    {
        private readonly NewsManagerContext _context;

        public UsersRepository(NewsManagerContext context)
        {
            _context = context;
        }

        public void Add(Users users)
        {
            _context.Users.Add(users);
        }

        public void Remove(Users users)
        {
            _context.Users.Remove(users);
        }

        public async Task<Users> SelectById(int id)
        {
            return await _context.Users.Where(x=>x.Id == id).FirstOrDefaultAsync();
            
        }
        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        

        public void Update(Users users)
        {
            _context.Entry(users).State = EntityState.Modified;  
        }
    }
}
