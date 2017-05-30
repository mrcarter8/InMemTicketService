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
	public class ContactsController : ODataController
	{
		[EnableQuery(MaxTop = 10000)]
		public IQueryable<Contact> Get()
		{
			return ContactDataSource.Instance.Contacts.AsQueryable();
		}

		[EnableQuery]
		public SingleResult<Contact> Get([FromODataUri] Guid key)
		{
			IQueryable<Contact> result = ContactDataSource.Instance.Contacts.AsQueryable().Where(p => p.ContactID == key);
			return SingleResult.Create(result);
		}
	}
}