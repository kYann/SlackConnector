using SlackAspNet.Actions.Executors;
using SlackAspNet.Types;
using SlackLibrary.Models;
using SlackLibrary.Models.Blocks;
using System;
using System.Collections.Generic;
using System.Text;

namespace SlackAspNet.Actions
{
	public interface IReplyMessageActionContext : IMessageActionContext
	{
		public TimestampSlack ThreadTs { get; }
	}

	public class ReplyMessageActionContext : MessageActionContext, IReplyMessageActionContext
	{
		public ReplyMessageActionContext(ChannelSlackId channelId, TimestampSlack threadTs) : base(channelId)
		{
			ThreadTs = threadTs;
		}

		public TimestampSlack ThreadTs { get; }
	}

	public class ReplyMessageActionResult : MessageActionResult<IReplyMessageActionContext, ReplyMessageActionResultExecutor>
	{
		public ReplyMessageActionResult(string text, MessageOptions options) : base(text, options)
		{
		}

		public ReplyMessageActionResult(string text, IEnumerable<BlockBase> blocks, MessageOptions options) : base(text, blocks, options)
		{
		}

		public ReplyMessageActionResult(string text, IEnumerable<SlackAttachment> attachments, MessageOptions options) : base(text, attachments, options)
		{
		}

		protected override IReplyMessageActionContext ActionContextToMessageActionContext(ISlackContextActionContext context)
		{
			return new ReplyMessageActionContext(context.SlackContext.ChannelId, context.SlackContext.ThreadTs);

		}
	}
}
