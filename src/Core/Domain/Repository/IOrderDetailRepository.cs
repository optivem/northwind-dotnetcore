﻿using Optivem.Northwind.Core.Domain.Entity;
using Optivem.Platform.Core.Common.Repository;

namespace Optivem.Northwind.Core.Domain.Repository
{
    public interface IOrderDetailRepository : IRepository<OrderDetail, int>
    {
    }
}