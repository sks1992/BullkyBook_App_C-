using BullkyBook.Models;

namespace BullkyBook.DataAccess.Repository.IRepository
{

    public interface ICoverTypeRepository : IRepository<CoverType>
    {
        void Update(CoverType coverType);
    }
}
