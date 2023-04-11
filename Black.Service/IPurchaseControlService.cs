using Black.Domain.DTO;
using Black.Domain.Models;
using Black.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Black.Service
{
    public interface IPurchaseControlService : IServiceBaseCRUD<PurchaseControl, int>
    {
        Task<int> QuantityPurchaseControls();
        Task<IQueryable<PurchaseControl>> GetAllPagination(string requestName, string description, DateTime? dateSolicitation, DateTime? datePurchase, DateTime? dateDelivery, PaginationDTO pagination);
    }
}
