﻿using Microsoft.AspNetCore.Mvc;
using Optivem.Northwind.Core.Application.Dto;
using Optivem.Northwind.Core.Application.Service;
using Optivem.Northwind.Core.Domain.Repository;
using Optivem.Platform.Web.AspNetCore.Rest;

namespace Optivem.Northwind.Web.Rest.Controllers
{
    [Route("api/orders-status")]
    [ApiController]
    public class OrdersStatusController : AspNetCoreCrudController<INorthwindUnitOfWork, IOrderStatusService, OrderStatusRequest, OrderStatusResponse, int>
    {
        public OrdersStatusController(INorthwindUnitOfWork unitOfWork, IOrderStatusService service)
            : base(unitOfWork, service, e => e.Id, e => e.Id)
        {
        }
    }
}