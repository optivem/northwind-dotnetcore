﻿using Optivem.Northwind.Core.Application.Dto;
using Optivem.Northwind.Core.Domain.Entity;

namespace Optivem.Northwind.Infrastructure.Application.Mapping.AutoMapper
{
    public class SupplierResponseMapping : BaseMapping<Supplier, SupplierResponse>
    {
        public SupplierResponseMapping()
        {
            // dtoEntityMapping.ForMember(e => e.PurchaseOrder, opt => opt.Ignore());
        }
    }
}
