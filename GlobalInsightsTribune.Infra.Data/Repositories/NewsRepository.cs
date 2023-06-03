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
    public class NewsRepository : INewsRepository
    {
        private readonly ApplicationDbContext _context;

        public NewsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<News> GetNewsAll()
        {
            return _context.News;
        }
    }
}
