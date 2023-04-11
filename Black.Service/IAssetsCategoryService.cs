using Black.Domain.Models;
using Black.Domain.QuerieResult;
using Black.Service.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Service
{
    public interface IAssetsCategoryService : IServiceBaseCRUD<AssetsCategory, int>
    {
    }
}
