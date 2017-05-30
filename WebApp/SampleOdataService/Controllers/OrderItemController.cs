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
	public class OrderItemsController :ODataController
	{
		[EnableQuery(MaxTop = 10000)]
		public IQueryable<OrderItem> Get()
		{
			return OrderItemDataSource.Instance.OrderItems.AsQueryable();
		}

		[EnableQuery]
		public SingleResult<OrderItem> Get([FromODataUri] Guid key)
		{
			IQueryable<OrderItem> result = OrderItemDataSource.Instance.OrderItems.AsQueryable().Where(p => p.OrderItemID == key);
			return SingleResult.Create(result);
		}
	}
}