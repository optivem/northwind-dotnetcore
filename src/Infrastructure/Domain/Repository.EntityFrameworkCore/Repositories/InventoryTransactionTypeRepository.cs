﻿using Optivem.Northwind.Core.Domain.Entity;
using Optivem.Northwind.Core.Domain.Repository;
using Optivem.Platform.Infrastructure.Common.Repository.EntityFrameworkCore;

namespace Optivem.Northwind.Infrastructure.Domain.Repository.EntityFrameworkCore
{
    public class InventoryTransactionTypeRepository : EntityFrameworkRepository<NorthwindContext, InventoryTransactionType, int>, IInventoryTransactionTypeRepository
    {
        public InventoryTransactionTypeRepository(NorthwindContext context)
            : base(context)
        {
        }
    }
}