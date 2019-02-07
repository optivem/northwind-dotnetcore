﻿using Optivem.Platform.Infrastructure.Common.Repository.EntityFramework;
using Optivem.Northwind.Core.Domain.Entity;
using Optivem.Northwind.Core.Domain.Repository;

namespace Optivem.Northwind.Infrastructure.Domain.Repository.EntityFrameworkCore
{
    public class SupplierRepository : EntityFrameworkRepository<NorthwindContext, Supplier, int>, ISupplierRepository
    {
        public SupplierRepository(NorthwindContext context) 
            : base(context)
        {
        }
    }
}