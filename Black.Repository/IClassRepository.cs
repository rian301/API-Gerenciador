﻿using Black.Domain.Models;
using Black.Repository.Base;
using System.Threading.Tasks;

namespace Black.Repository
{
    public interface IClassRepository : IRepositoryBaseCRUD<Class, int>
    {
    }
}
