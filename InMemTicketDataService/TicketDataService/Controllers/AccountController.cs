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
	public class AccountsController : ODataController
	{
		[EnableQuery]
		public IQueryable<Account> Get()
		{
			return AccountDataSource.Instance.Accounts.AsQueryable();
		}

		[EnableQuery]
		public SingleResult<Account> Get([FromODataUri] Guid key)
		{
			IQueryable<Account> result = AccountDataSource.Instance.Accounts.AsQueryable().Where(p => p.AccountID == key);
			return SingleResult.Create(result);
		}
	}
}