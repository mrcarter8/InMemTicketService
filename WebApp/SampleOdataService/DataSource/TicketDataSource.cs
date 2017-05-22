using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TicketDataService.Models;
using Newtonsoft.Json;
using System.IO;


namespace TicketDataService.DataSource
{
    public class TicketDataSource
    {
        private static TicketDataSource instance = null;
        public static TicketDataSource Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new TicketDataSource();
                }
                return instance;
            }
        }

        public IQueryable<Ticket> Tickets
		{
			get
			{
				var exeFile = Assembly.GetExecutingAssembly().Location;
				var dir = Path.GetDirectoryName(exeFile);

				var json = File.ReadAllText(System.Web.Hosting.HostingEnvironment.MapPath(HttpContext.Current.Request.ApplicationPath) + "\\tickets.txt");

				return JsonConvert.DeserializeObject<Ticket[]>(json).AsQueryable();
				
			}
		}
    }

	internal class Tickets
	{
		public List<Ticket> Items { get; set; }
	}
}