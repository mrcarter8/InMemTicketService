using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using Newtonsoft.Json;
using TicketDataService.Models;

namespace TicketDataService.DataSource
{
	public class ContactDataSource
	{
		private static ContactDataSource instance = null;
		public static ContactDataSource Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new ContactDataSource();
				}
				return instance;
			}
		}

		public IQueryable<Contact> Contacts
		{
			get
			{
				
				var json = File.ReadAllText(System.Web.Hosting.HostingEnvironment.MapPath(HttpContext.Current.Request.ApplicationPath) + "\\contacts.txt");

				return JsonConvert.DeserializeObject<Contact[]>(json).AsQueryable();

			}
		}
	}

	internal class Contacts
	{
		public List<Contact> Items { get; set; }
	}
}
