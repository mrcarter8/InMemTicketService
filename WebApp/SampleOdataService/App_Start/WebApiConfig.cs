using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using System.Web.OData.Builder;
using TicketDataService.Models;
using System.Web.OData.Extensions;

namespace SampleOdataService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

			ODataModelBuilder builder = new ODataConventionModelBuilder();
			builder.EntitySet<TicketDataService.Models.Ticket>("Tickets");
			builder.EntitySet<Account>("Accounts");
			builder.EntitySet<Contact>("Contacts");
			builder.EntitySet<Order>("Orders");
			builder.EntitySet<OrderItem>("OrderItems");
			config.MapODataServiceRoute(
				 "ODataRoute",
				 "odata",
				builder.GetEdmModel());
			config.EnsureInitialized();

			//// Web API configuration and services
			//// Configure Web API to use only bearer token authentication.
			//config.SuppressDefaultHostAuthentication();
			//         config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

			//         // Web API routes
			//         config.MapHttpAttributeRoutes();

			//         config.Routes.MapHttpRoute(
			//             name: "DefaultApi",
			//             routeTemplate: "api/{controller}/{id}",
			//             defaults: new { id = RouteParameter.Optional }
			//         );
		}
    }
}
