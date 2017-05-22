using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.SelfHost;
using TicketDataService.Models;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using TicketDataService.DataSource;

namespace TicketDataService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            HttpSelfHostConfiguration config = new HttpSelfHostConfiguration("http://localhost:1937");
            ODataModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Ticket>("Tickets");
			builder.EntitySet<Account>("Accounts");
			builder.EntitySet<Contact>("Contacts");
	        builder.EntitySet<Order>("Orders");
			builder.EntitySet<OrderItem>("OrderItems");
			config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: null,
                model: builder.GetEdmModel());


	  //      var orderItem = builder.EntityType<OrderItem>();
			//orderItem.Ignore(t=>t.datetime);
	  //      orderItem.Property(t => t.datetimeoffset).Name = "datetime";

			using (HttpSelfHostServer server = new HttpSelfHostServer(config))
            {
                server.OpenAsync().Wait();
                Console.WriteLine("Press Enter to quit");
                Console.ReadLine();
            }
        }
    }
}