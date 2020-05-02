using SlackAspNet.Endpoints;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SlackAspNet.Actions
{
	public interface IActionContext
	{
		IServiceProvider ServiceProvider { get; }
	}

	public interface ISlackContextActionContext : IActionContext
	{
		SlackContext SlackContext { get; }
	}

	public class ActionContext : IActionContext
	{
		public ActionContext(IServiceProvider serviceProvider)
		{
			ServiceProvider = serviceProvider;
		}

		public IServiceProvider ServiceProvider { get; }
	}

	public class SlackContextActionContext : ActionContext, ISlackContextActionContext
	{
		public SlackContextActionContext(IServiceProvider serviceProvider, SlackContext slackContext) : base(serviceProvider)
		{
			SlackContext = slackContext;
		}

		public SlackContext SlackContext { get; }
	}

	public interface ISlackActionResult
	{
		Task ExecuteResultAsync(IActionContext context);
	}
}
