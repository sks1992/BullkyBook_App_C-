using BullkyBook.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BullkyBook.DataAccess.Repository
{

    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext  db)
        {
            _db = db;
            //_db.Products.Include(u => u.Category).Include(u=>u.CoverType);
            this.dbSet =_db.Set<T>();
        }
        public void Add(T item)
        {
            dbSet.Add(item);    
        }
        //includeProperties - "Category,CoverType"
        public IEnumerable<T> GetAll(string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if(includeProperties != null)
            {
                foreach(var property in includeProperties.Split(new char[] {','},StringSplitOptions.RemoveEmptyEntries)) 
                {
                    query = query.Include(property).AsNoTracking();
                }
            }
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            query =query.Where(filter);
            if (includeProperties != null)
            {
                foreach (var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property).AsNoTracking();
                }
            }
            return query.FirstOrDefault();
        }

        public void Remove(T item)
        {
           dbSet.Remove(item);
        }

        public void RemoveRange(IEnumerable<T> items)
        {
            dbSet.RemoveRange(items);
        }
    }
}
