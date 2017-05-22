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
	public class AccountDataSource
	{
		private static AccountDataSource instance = null;
		public static AccountDataSource Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new AccountDataSource();
				}
				return instance;
			}
		}

		public IQueryable<Account> Accounts
		{
			get
			{
				var exeFile = Assembly.GetExecutingAssembly().Location;
				var dir = Path.GetDirectoryName(exeFile);

				var json = File.ReadAllText(Path.Combine(dir, "accounts.txt"));

				return JsonConvert.DeserializeObject<Account[]>(json).AsQueryable();

			}
		}
	}

	internal class Accounts
	{
		public List<Account> Items { get; set; }
	}
}
