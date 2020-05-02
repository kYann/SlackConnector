using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SlackAspNet.Routing
{
	public class Router
	{
		private RouteTable Routes { get; }

		public Router(IEnumerable<Assembly> assemblies)
		{
			Routes = RouteTableFactory.Create(assemblies);
		}


	}
}
