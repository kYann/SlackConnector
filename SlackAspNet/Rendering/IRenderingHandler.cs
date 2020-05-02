using SlackAspNet.Routing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SlackAspNet.Render
{
	public interface IRenderingHandler
	{
		Task RenderAsync(RouteData routeData);
	}
}
