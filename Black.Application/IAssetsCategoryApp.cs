﻿using Black.Application.Base;
using Black.Domain.Models;
using System.Threading.Tasks;

namespace Black.Application
{
    public interface IAssetsCategoryApp : IAppBaseCRUD<AssetsCategory, int>
    {
        //Task<int> QuantityAssetsCategorys();
    }
}
