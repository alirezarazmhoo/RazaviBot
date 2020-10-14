using AtrinBot.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtrinBot.Data
{
	public class BotContext : DbContext
	{
		//23.254.227.64
		public BotContext() : base("Data Source=.;Initial Catalog=SafiranDb;User Id=sa;Password=Atrin2020")
		{
			this.Configuration.ProxyCreationEnabled = false;
			this.Configuration.LazyLoadingEnabled = false;
		}
		public DbSet<Volunteers> Volunteers { get; set; }

	}
}
