using BullkyBook.DataAccess.Repository.IRepository;
using BullkyBook.Models;
namespace BullkyBook.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) :base(db) 
        {
            _db = db;
        }

        public void Update(Category category)
        {
            _db.Category.Update(category);
        }
    }
}
