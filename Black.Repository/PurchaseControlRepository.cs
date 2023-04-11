using Black.Domain.DTO;
using Black.Domain.Models;
using Black.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Black.Repository
{
    public interface IPurchaseControlRepository : IRepositoryBaseCRUD<PurchaseControl, int>
    {
        Task<int> QuantityPurchaseControls();
        Task<IQueryable<PurchaseControl>> GetAllPagination(string requestName, string description, DateTime? dateSolicitation, DateTime? datePurchase, DateTime? dateDelivery, PaginationDTO pagination);
    }
}
