using Black.Domain.Models;
using Black.Domain.QuerieResult;
using Black.Repository.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Repository
{
    public interface IPatrimonyRepository : IRepositoryBaseCRUD<Patrimony, int>
    {
        Task<int> QuantityPatrimonys();
    }
}
