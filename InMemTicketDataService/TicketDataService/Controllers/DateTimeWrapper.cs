using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketDataService.Controllers
{
	public class DateTimeWrapper
	{
		public static implicit operator DateTimeOffset(DateTimeWrapper p)
		{
			return DateTime.SpecifyKind(p._dt, DateTimeKind.Utc);
		}

		public static implicit operator DateTimeWrapper(DateTimeOffset dto)
		{
			return new DateTimeWrapper(dto.DateTime);
		}

		public static implicit operator DateTime(DateTimeWrapper dtr)
		{
			return dtr._dt;
		}

		public static implicit operator DateTimeWrapper(DateTime dt)
		{
			return new DateTimeWrapper(dt);
		}

		protected DateTimeWrapper(DateTime dt)
		{
			_dt = dt;
		}

		private readonly DateTime _dt;
	}
}