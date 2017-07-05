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
using System.Threading;

namespace SampleOdataService.Controllers
{
    public class TimeOutTicketsController : ODataController
    {
        // GET: TimeOutTicket
        [EnableQuery(MaxTop = 10000)]
        public IQueryable<Ticket> Get()
        {
            //Sleep for 3 minutes.
            Thread.Sleep(180000);
            return TicketDataSource.Instance.Tickets.AsQueryable();
        }

        [EnableQuery]
        public SingleResult<Ticket> Get([FromODataUri] Guid key)
        {
            //Sleep for 3 minutes.
            Thread.Sleep(180000);
            IQueryable<Ticket> result = TicketDataSource.Instance.Tickets.AsQueryable().Where(p => p.TicketID == key);
            return SingleResult.Create(result);
        }
    }
}