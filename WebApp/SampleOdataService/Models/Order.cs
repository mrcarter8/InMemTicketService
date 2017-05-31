using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using SampleOdataService.Models;
using TicketDataService.DataSource;

namespace TicketDataService.Models
{
	public class Order
	{
		[Key]
		public Guid OrderID { get; set; }

		public string name { get; set; }
		public int discount { get; set; }

		public double amount { get; set; }

		public bool fulfilled { get; set; }

		public Guid crmaccountid { get; set; }

		public OrderType ordertype { get; set; }

		public string emailaddress { get; set; }

		[ForeignKey("OrderItems")]
		public virtual ICollection<OrderItem> OrderItems { get; set; } 
	}
}
