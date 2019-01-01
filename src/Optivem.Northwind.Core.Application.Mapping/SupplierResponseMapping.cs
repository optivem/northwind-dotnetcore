﻿using Optivem.Northwind.Core.Application.Dto;
using Optivem.Northwind.Core.Domain.Entity;

namespace Optivem.Northwind.Core.Application.Mapping
{
    public class SupplierResponseMapping : BaseMapping<Supplier, SupplierResponse>
    {
        public SupplierResponseMapping()
        {
            dtoEntityMapping.ForMember(e => e.Products, opt => opt.Ignore());
        }
    }
}
