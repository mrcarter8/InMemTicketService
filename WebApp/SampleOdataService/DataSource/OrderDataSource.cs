using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using Newtonsoft.Json;
using TicketDataService.Models;

namespace TicketDataService.DataSource
{
	public class OrderDataSource
	{
		private static OrderDataSource instance = null;
		public static OrderDataSource Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new OrderDataSource();
				}
				return instance;
			}
		}

		public IQueryable<Order> Orders
		{
			get
			{
				var json = File.ReadAllText(System.Web.Hosting.HostingEnvironment.MapPath(HttpContext.Current.Request.ApplicationPath) + "\\orders.txt");

				var orders = JsonConvert.DeserializeObject<Order[]>(json).AsQueryable();
				orders.First().OrderItems = OrderItemDataSource.Instance.OrderItems.ToArray();
				orders.Last().OrderItems = OrderItemDataSource.Instance.OrderItems.ToArray();
				return orders;
			}
		}
	}

	internal class Orders
	{
		public List<Order> Items { get; set; }
	}
}
