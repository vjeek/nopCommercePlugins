using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Nop.Web.Framework;
using Nop.Web.Framework.Mvc;

namespace VJeek.Plugin.Misc.WaterMark.Models
{
	public partial class WaterMarkSettingsModel : BaseNopModel
	{
		public int ActiveStoreScopeConfiguration { get; set; }

		[NopResourceDisplayName("VJeek.Plugin.Misc.WaterMark.PictureId")]
		[UIHint("Picture")]
		public virtual int PictureId { get; set; }
		public bool PictureId_Override { get; set; }

		[NopResourceDisplayName("VJeek.Plugin.Misc.WaterMark.Positions")]
		public int Positions { get; set; }
		public bool Positions_Override { get; set; }
		public List<string> PositionsSelectedValues { get; set; } 

		public IList<SelectListItem> PositionsValues { get; set; }

		[NopResourceDisplayName("VJeek.Plugin.Misc.WaterMark.Enable")]
		public bool Enable { get; set; }
		public bool Enable_Override { get; set; }

		[NopResourceDisplayName("VJeek.Plugin.Misc.WaterMark.Scale")]
		public int Scale { get; set; }
		public bool Scale_Override { get; set; }

		[NopResourceDisplayName("VJeek.Plugin.Misc.WaterMark.Transparency")]
		public int Transparency { get; set; }
		public bool Transparency_Override { get; set; }

		[NopResourceDisplayName("VJeek.Plugin.Misc.WaterMark.OnlyLargerThen")]
		public int OnlyLargerThen { get; set; }
		public bool OnlyLargerThen_Override { get; set; }


		[NopResourceDisplayName("VJeek.Plugin.Misc.WaterMark.ApplyOnProductPictures")]
		public bool ApplyOnProductPictures { get; set; }
		public bool ApplyOnProductPictures_Override { get; set; }

		[NopResourceDisplayName("VJeek.Plugin.Misc.WaterMark.ApplyOnCategoryPictures")]
		public bool ApplyOnCategoryPictures { get; set; }
		public bool ApplyOnCategoryPictures_Override { get; set; }

		[NopResourceDisplayName("VJeek.Plugin.Misc.WaterMark.ApplyOnProductVariantAttributeValuePictures")]
		public bool ApplyOnProductVariantAttributeValuePictures { get; set; }
		public bool ApplyOnProductVariantPictures_Override { get; set; }

		public WaterMarkSettingsModel()
			: base()
		{
			this.PositionsValues = new List<SelectListItem>();
		}
	}
}
