using Microsoft.Extensions.DependencyInjection;
using SlackAspNet.Actions;
using SlackAspNet.Endpoints;
using SlackAspNet.Render;
using SlackAspNet.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlackAspNet.Rendering
{
	public class RenderingHandler : IRenderingHandler
	{
		private readonly IServiceProvider serviceProvider;
		private readonly RenderingEndpoint renderingEndpoint;

		public RenderingHandler(IServiceProvider serviceProvider, RenderingEndpoint renderingEndpoint)
		{
			this.serviceProvider = serviceProvider;
			this.renderingEndpoint = renderingEndpoint;
		}

		public async Task RenderAsync(RouteData routeData)
		{
			var asyncReturnType = typeof(Task<IEnumerable<ISlackActionResult>>);
			var returnType = typeof(Task<IEnumerable<ISlackActionResult>>);
			var method = routeData.EndpointType.GetMethods(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance)
				.FirstOrDefault(m => m.ReturnType == asyncReturnType || m.ReturnType == returnType);

			if (method is null)
				throw new ArgumentNullException($"Could not find a public method with return Type {asyncReturnType} or {returnType}");

			var endpoint = serviceProvider.GetRequiredService(routeData.EndpointType) as SlackEndpoint;

			var parameters = method.GetParameters();
			var values = parameters.Select(p => routeData.RouteValues[p.Name]).ToArray();

			IEnumerable<ISlackActionResult> results = null;
			if (method.ReturnType == asyncReturnType)
				results = await(Task<IEnumerable<ISlackActionResult>>)method.Invoke(endpoint, values);
			else
				results = (IEnumerable<ISlackActionResult>)method.Invoke(endpoint, values);

			await renderingEndpoint.RenderResultsAsync((endpoint as SlackEndpoint<SlackContext>)?.Context, results);
		}
	}
}
