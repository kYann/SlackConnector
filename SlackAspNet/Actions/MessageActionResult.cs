using Microsoft.Extensions.DependencyInjection;
using SlackAspNet.Actions.Executors;
using SlackAspNet.Types;
using SlackLibrary.Connections.Responses;
using SlackLibrary.Models;
using SlackLibrary.Models.Blocks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SlackAspNet.Actions
{
	public interface IMessageActionContext
	{
		public ChannelSlackId ChannelId { get; }
	}

	public class MessageActionContext : IMessageActionContext
	{
		public MessageActionContext(ChannelSlackId channelId)
		{
			ChannelId = channelId;
		}

		public ChannelSlackId ChannelId { get; }
	}

	public class MessageOptions
	{
		public static readonly MessageOptions Default = new MessageOptions()
		{
			AsUser = false,
			LinkNames = true,
			UserName = null,
			IconUrl = null
		};

		public bool AsUser { get; set; }

		public string UserName { get; set; }

		public bool LinkNames { get; set; }

		public string IconUrl { get; set; }
	}

	public class MessageActionResult : MessageActionResult<IMessageActionContext, MessageActionResultExecutor>
	{
		public MessageActionResult(string text, IEnumerable<BlockBase> blocks, MessageOptions options) : base(text, blocks, options)
		{
		}

		public MessageActionResult(string text, IEnumerable<SlackAttachment> attachments, MessageOptions options) : base(text, attachments, options)
		{
		}

		public MessageActionResult(string text, MessageOptions options) : base(text, options)
		{
		}

		protected override IMessageActionContext ActionContextToMessageActionContext(ISlackContextActionContext context)
		{
			return new MessageActionContext(context.SlackContext.ChannelId);
		}
	}

	public abstract class MessageActionResult<T> : ISlackActionResult where T : IMessageActionContext
	{
		public MessageActionResult(string text, IEnumerable<BlockBase> blocks, MessageOptions options)
		{
			Options = options ?? MessageOptions.Default;
			Text = text;
			Blocks = blocks;
		}

		public MessageActionResult(string text, IEnumerable<SlackAttachment> attachments, MessageOptions options)
		{
			Options = options ?? MessageOptions.Default;
			Text = text;
			Attachments = attachments;
		}

		protected MessageActionResult(string text, MessageOptions options)
		{
			Text = text;
			Options = options;
		}

		public string Text { get; }

		public MessageOptions Options { get; }

		public IEnumerable<BlockBase> Blocks { get; }

		public IEnumerable<SlackAttachment> Attachments { get; }

		public abstract Task ExecuteResultAsync(IActionContext context);
	}

	public abstract class MessageActionResult<T, E> : MessageActionResult<T> where T : IMessageActionContext where E : IMessageActionResultExecutor<T>
	{
		public MessageActionResult(string text, IEnumerable<BlockBase> blocks, MessageOptions options) : base(text, blocks, options)
		{
		}

		public MessageActionResult(string text, IEnumerable<SlackAttachment> attachments, MessageOptions options) : base(text, attachments, options)
		{
		}

		protected MessageActionResult(string text, MessageOptions options) : base(text, options)
		{
		}

		public override async Task ExecuteResultAsync(IActionContext context)
		{
			var slackContext = context as ISlackContextActionContext;
			if (slackContext is null)
			{
				throw new ArgumentNullException(nameof(slackContext));
			}

			var messageActionContext = this.ActionContextToMessageActionContext(slackContext);
			if (messageActionContext is null)
			{
				throw new ArgumentNullException(nameof(messageActionContext));
			}

			var response = await this.ExecuteResultAsync(context.ServiceProvider, messageActionContext);

			this.HandleExecutorResponse(response, slackContext);
		}

		protected virtual void HandleExecutorResponse(MessageResponse response, ISlackContextActionContext context)
		{
			if (!response.Ok)
				throw new Exception(response.Error);

			if (context is ISlackContextActionContext sc)
			{
				sc.SlackContext.ThreadTs = new TimestampSlack(response.Timestamp);
			}
		}

		protected abstract T ActionContextToMessageActionContext(ISlackContextActionContext context);

		protected async Task<MessageResponse> ExecuteResultAsync(IServiceProvider provider, T context)
		{
			var executor = provider.GetRequiredService<E>();

			var response = await executor.Execute(context, this);

			return response;
		}
	}
}
