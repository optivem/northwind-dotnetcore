﻿using Optivem.Northwind.Core.Domain.Entity;
using Optivem.Commons.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Northwind.Core.Domain.Repository
{
	public interface IOrderRepository : IRepository<Order, int>
	{

	}
}