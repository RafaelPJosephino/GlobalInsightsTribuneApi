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
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetUserAll()
        {
            return _context.User.ToList();
        }

        public void RegisterUser(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

    }
}
