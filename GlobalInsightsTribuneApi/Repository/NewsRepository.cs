using GlobalInsightsTribuneApi.Context;
using GlobalInsightsTribuneApi.Entitys;
using GlobalInsightsTribuneApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GlobalInsightsTribuneApi.Repository
{
    public class NewsRepository : INewsRepository
    {

        private readonly NewsManagerContext _context;

        public NewsRepository(NewsManagerContext context)
        {
            _context = context;
        }
        public void Refresh()
        {
            throw new NotImplementedException();
        }
        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        public void Add(News news)
        {
            _context.News.Add(news);    
        }
        public async Task<IEnumerable<News>> SelectAll()
        {
            var News = await _context.News.ToListAsync();
            return News;
                
        }

    }
}
