using System.Linq.Expressions;

namespace BullkyBook.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        T GetFirstOrDefault(Expression<Func<T, bool>> filter);
        IEnumerable<T> GetAll();
        void Add(T item);
        void Remove(T item);
        void RemoveRange(IEnumerable<T> items);
    }   
}
