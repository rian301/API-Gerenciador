using Black.Application.Base;
using Black.Domain.Models;
using System.Threading.Tasks;

namespace Black.Application
{
    public interface IExpenseCategoryApp : IAppBaseCRUD<ExpenseCategory, int>
    {
        Task<int> QuantityExpenseCategorys();
    }
}
