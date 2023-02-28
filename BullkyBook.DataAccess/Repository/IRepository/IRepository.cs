using System.Linq.Expressions;

namespace BullkyBook.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        T GetFirstOrDefault(Expression<Func<T, bool>> filter,string? includeProperties =null);
        IEnumerable<T> GetAll(string? includeProperties = null);
        void Add(T item);
        void Remove(T item);
        void RemoveRange(IEnumerable<T> items);
    }   
}
