using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Autofac.Builder;
using Autofac.Integration.Mvc;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using Nop.Services.Media;
using VJeek.Plugin.Misc.WaterMark.Core;

namespace VJeek.Plugin.Misc.WaterMark
{
	public partial class DependencyRegistrar : IDependencyRegistrar
	{
		public int Order
		{
			get
			{
				return 1000;
			}
		}

		public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
		{
			builder.RegisterType<VJeekPictureService>().As<IPictureService>().InstancePerHttpRequest();
		}
	}
}
