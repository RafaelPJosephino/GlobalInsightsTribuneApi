using GlobalInsightsTribuneApi.Entitys;

namespace GlobalInsightsTribuneApi.Interfaces
{
    public interface INewsRepository
    {
        void Refresh();
        void Add(News news);
        Task<bool> SaveAllAsync(); 
        Task<IEnumerable<News>> SelectAll();  
 

    }
}
