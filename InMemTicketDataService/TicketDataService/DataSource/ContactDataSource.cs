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
				var exeFile = Assembly.GetExecutingAssembly().Location;
				var dir = Path.GetDirectoryName(exeFile);

				var json = File.ReadAllText(Path.Combine(dir, "contacts.txt"));

				return JsonConvert.DeserializeObject<Contact[]>(json).AsQueryable();

			}
		}
	}

	internal class Contacts
	{
		public List<Contact> Items { get; set; }
	}
}
