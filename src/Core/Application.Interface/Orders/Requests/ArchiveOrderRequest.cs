﻿using Optivem.Framework.Core.Application;

namespace Optivem.Northwind.Core.Application.Orders.Requests
{
    public class ArchiveOrderRequest : IRequest<int>
    {
        public int Id { get; set; }
    }
}
