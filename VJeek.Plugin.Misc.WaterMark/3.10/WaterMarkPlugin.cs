using System.Web;
using System.Web.Routing;
using Nop.Core.Infrastructure;
using Nop.Core.Plugins;
using Nop.Services.Common;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Media;
using VJeek.Plugin.Misc.WaterMark.Core;
using VJeek.Plugin.Misc.WaterMark.Models;

namespace VJeek.Plugin.Misc.WaterMark
{
	public class WaterMarkPlugin : BasePlugin, IMiscPlugin
	{
		private readonly ISettingService _settingService;
		private readonly ILogger _logger;
		private readonly HttpContextBase _httpContext;

		public WaterMarkPlugin(ISettingService settingService, ILogger logger, HttpContextBase httpContext)
		{
			_settingService = settingService;
			_logger = logger;
			_httpContext = httpContext;
		}

		public void GetConfigurationRoute(out string actionName, out string controllerName, out RouteValueDictionary routeValues)
		{
			actionName = "Configure";
			controllerName = "VJeekWaterMark";
			routeValues = new RouteValueDictionary() { { "Namespaces", "VJeek.Plugin.Misc.WaterMark.Controllers" }, { "area", null } };
		}

		void IPlugin.Install()
		{
			//settings
			var settings = new WaterMarkSettings()
			{
				Positions = (int)WaterMarkPositions.Center,
				Enable = false
			};

			_settingService.SaveSetting(settings);

			//locales
			this.AddOrUpdatePluginLocaleResource("VJeek.Plugin.Misc.WaterMark.PictureId", "Image for watermark");
			this.AddOrUpdatePluginLocaleResource("VJeek.Plugin.Misc.WaterMark.PictureId.Hint", "Upload watermark image for place on images");

			this.AddOrUpdatePluginLocaleResource("VJeek.Plugin.Misc.WaterMark.Positions", "Positions of watermark image");
			this.AddOrUpdatePluginLocaleResource("VJeek.Plugin.Misc.WaterMark.Positions.Hint", "Select positions where watermark will be placed on image");

			this.AddOrUpdatePluginLocaleResource("VJeek.Plugin.Misc.WaterMark.Enable", "Enable watermark");
			this.AddOrUpdatePluginLocaleResource("VJeek.Plugin.Misc.WaterMark.Scale", "Image scaling (percents)");
			this.AddOrUpdatePluginLocaleResource("VJeek.Plugin.Misc.WaterMark.Transparency", "Transparency of watermark image");
			this.AddOrUpdatePluginLocaleResource("VJeek.Plugin.Misc.WaterMark.OnlyLargerThen", "Use only for photos larger then Xpx in one dimension");

			base.Install();
		}

		void IPlugin.Uninstall()
		{
			//settings
			_settingService.DeleteSetting<WaterMarkSettings>();

			//locales
			this.DeletePluginLocaleResource("VJeek.Plugin.Misc.WaterMark.PictureId");
			this.DeletePluginLocaleResource("VJeek.Plugin.Misc.WaterMark.PictureId.Hint");
			this.DeletePluginLocaleResource("VJeek.Plugin.Misc.WaterMark.Positions");
			this.DeletePluginLocaleResource("VJeek.Plugin.Misc.WaterMark.Positions.Hint");
			this.DeletePluginLocaleResource("VJeek.Plugin.Misc.WaterMark.Enable");
			this.DeletePluginLocaleResource("VJeek.Plugin.Misc.WaterMark.Scale");
			this.DeletePluginLocaleResource("VJeek.Plugin.Misc.WaterMark.Transparency");
			this.DeletePluginLocaleResource("VJeek.Plugin.Misc.WaterMark.OnlyLargerThen");
			((VJeekPictureService)EngineContext.Current.Resolve<IPictureService>()).ClearThumbs();
			base.Uninstall();
		}
	}
}
