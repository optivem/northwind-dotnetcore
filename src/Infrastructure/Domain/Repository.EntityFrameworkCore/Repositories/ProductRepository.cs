﻿using Optivem.Northwind.Core.Domain.Entity;
using Optivem.Northwind.Core.Domain.Repository;
using Optivem.Platform.Infrastructure.Common.Repository.EntityFrameworkCore;

namespace Optivem.Northwind.Infrastructure.Domain.Repository.EntityFrameworkCore
{
    public class ProductRepository : EntityFrameworkRepository<NorthwindContext, Product, int>, IProductRepository
    {
        public ProductRepository(NorthwindContext context)
            : base(context)
        {
        }
    }
}