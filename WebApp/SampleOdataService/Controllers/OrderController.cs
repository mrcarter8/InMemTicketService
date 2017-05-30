using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.OData;
using TicketDataService.DataSource;
using TicketDataService.Models;

namespace TicketDataService.Controllers
{
	public class OrdersController :ODataController
	{
		[EnableQuery(MaxTop = 10000)]
		public IQueryable<Order> Get()
		{
			return OrderDataSource.Instance.Orders.AsQueryable();
		}

		[EnableQuery]
		public SingleResult<Order> Get([FromODataUri] Guid key)
		{
			IQueryable<Order> result = OrderDataSource.Instance.Orders.AsQueryable().Where(p => p.OrderID == key);
			return SingleResult.Create(result);
		}
	}
}