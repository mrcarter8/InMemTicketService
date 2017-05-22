using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Routing;
using TicketDataService.DataSource;
using TicketDataService.Models;
using Newtonsoft.Json;

namespace TicketDataService.Controllers
{
    public class TicketsController : ODataController
    {
        [EnableQuery]
		public IQueryable<Ticket> Get()
        {
            return TicketDataSource.Instance.Tickets.AsQueryable();
        }

        [EnableQuery]
		public SingleResult<Ticket> Get([FromODataUri] Guid key)
        {
            IQueryable<Ticket> result = TicketDataSource.Instance.Tickets.AsQueryable().Where(p => p.TicketID == key);
            return SingleResult.Create(result);
        }
    }
}