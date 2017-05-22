using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TicketDataService.Models
{
	public class Contact
	{
		[Key]
		public Guid ContactID { get; set; }
		public string name { get; set; }
		public int age { get; set; }

		public double annualrevenue { get; set; }
	}
}