using System.Threading.Tasks;

namespace Black.Domain.Interfaces
{
    public interface IUnitOfWork
    {        
        Task<bool> SaveAsync();
        bool Save();
        void BeginTransaction();
        void Commit();
        void Rollback();
        void Dispose();
    }
}
