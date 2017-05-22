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
	public class OrderItemDataSource
	{
		private static OrderItemDataSource instance = null;
		public static OrderItemDataSource Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new OrderItemDataSource();
				}
				return instance;
			}
		}

		public IQueryable<OrderItem> OrderItems
		{
			get
			{
				var exeFile = Assembly.GetExecutingAssembly().Location;
				var dir = Path.GetDirectoryName(exeFile);

				var json = File.ReadAllText(System.Web.Hosting.HostingEnvironment.MapPath(HttpContext.Current.Request.ApplicationPath) + "\\orderitems.txt");

				return JsonConvert.DeserializeObject<OrderItem[]>(json).AsQueryable();

			}
		}
	}

	internal class OrderItems
	{
		public List<OrderItem> Items { get; set; }
	}
}
