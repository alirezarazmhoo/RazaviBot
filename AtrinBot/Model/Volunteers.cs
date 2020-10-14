using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtrinBot.Model
{
	public class Volunteers
	{
		public int Id { get; set; }
		public string FullName { get; set; }
		public string UserName { get; set; }

		public DateTime CreateDate { get; set; }

		public Cooperation CooperationType { get; set; }

		public string Link { get; set; }
		public string Mobile { get; set; }
		public bool AlreadyRegistered { get; set; } = false;
	}

	public enum Cooperation
	{
		empty,
		PostOrInstagramStory   , 
		ShareTextInInputOrOutputMassengers,
		ContentProductionClipOrPoster,
		Tweet , 
		ReshareRazaviContent
	}
}
