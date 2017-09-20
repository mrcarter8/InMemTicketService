using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TicketDataService.Controllers;

namespace TicketDataService.Models
{
	public class OrderItem
	{
		[Key]
		public Guid OrderItemID { get; set; }

		public string name { get; set; }
		public int? quantity { get; set; }

		public double? amount { get; set; }

		public bool? delivered { get; set; }

		public OrderType? ordertype { get; set; }

		public Guid orderid { get; set; }

		public DateTimeOffset? datetimeoffset { get; set;}
	}
}