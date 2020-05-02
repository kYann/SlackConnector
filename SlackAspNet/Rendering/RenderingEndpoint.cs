using Microsoft.Extensions.DependencyInjection;
using SlackAspNet.Actions;
using SlackAspNet.Endpoints;
using SlackAspNet.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlackAspNet.Render
{
	public interface IRenderingEndpoint
	{
		Task RenderAsync<T, C>(C context, Func<T, Task<IEnumerable<ISlackActionResult>>> handle) where T : SlackEndpoint<C>, new() where C : SlackContext;

		Task RenderAsync<T, C>(C context, Func<T, IEnumerable<ISlackActionResult>> handle) where T : SlackEndpoint<C>, new() where C : SlackContext;
	}

	public class RenderingEndpoint : IRenderingEndpoint
	{
		private readonly IServiceProvider serviceProvider;

		public RenderingEndpoint(IServiceProvider serviceProvider)
		{
			this.serviceProvider = serviceProvider;
		}

		internal async Task RenderResultsAsync(SlackContext context, IEnumerable<ISlackActionResult> results)
		{
			foreach (var result in results)
			{
				if (context is null)
				{
					await result.ExecuteResultAsync(new ActionContext(serviceProvider));
				}
				else
				{
					await result.ExecuteResultAsync(new SlackContextActionContext(serviceProvider, context));
				}
			}
		}

		public async Task RenderAsync<T, C>(C context, Func<T, Task<IEnumerable<ISlackActionResult>>> handle) where T : SlackEndpoint<C>, new() where C : SlackContext
		{
			var endpoint = new T();
			endpoint.Context = context;
			var results = await handle(endpoint);

			await this.RenderResultsAsync(context, results);
		}

		public async Task RenderAsync<T, C>(C context, Func<T, IEnumerable<ISlackActionResult>> handle) where T : SlackEndpoint<C>, new() where C : SlackContext
		{
			var endpoint = new T();
			endpoint.Context = context;
			var results = handle(endpoint);

			await this.RenderResultsAsync(context, results);
		}
	}
}
