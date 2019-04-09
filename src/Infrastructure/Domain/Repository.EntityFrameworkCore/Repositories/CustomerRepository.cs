﻿using Optivem.Platform.Infrastructure.Common.Repository.EntityFrameworkCore;
using Optivem.Northwind.Core.Domain.Entity;
using Optivem.Northwind.Core.Domain.Repository;

namespace Optivem.Northwind.Infrastructure.Domain.Repository.EntityFrameworkCore
{
	public class CustomerRepository : EntityFrameworkRepository<NorthwindContext, Customer, int>, ICustomerRepository
	{
		public CustomerRepository(NorthwindContext context)
			: base(context)
		{
		}
	}
}