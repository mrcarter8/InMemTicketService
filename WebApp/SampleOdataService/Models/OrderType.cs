using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketDataService.Models
{
	public enum OrderType
	{
		Open = 1,
		Suspended = 2,
		Cancelled = 3,
		Closed = 4
	}
}