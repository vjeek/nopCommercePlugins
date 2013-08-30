using Nop.Core.Configuration;
using VJeek.Plugin.Misc.WaterMark.Models;

namespace VJeek.Plugin.Misc.WaterMark
{
	public partial class WaterMarkSettings : ISettings
	{
		public int PictureId { get; set; }

		public int Positions { get; set; }

		public bool Enable { get; set; }

		public int Scale { get; set; }

		public int Transparency { get; set; }

		public int OnlyLargerThen { get; set; }
	}
}
