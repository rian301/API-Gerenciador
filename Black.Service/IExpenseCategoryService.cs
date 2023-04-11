using Black.Domain.Models;
using Black.Service.Base;
using System.Threading.Tasks;

namespace Black.Service
{
    public interface IExpenseCategoryService : IServiceBaseCRUD<ExpenseCategory, int>
    {
        Task<int> QuantityExpenseCategorys();
    }
}
