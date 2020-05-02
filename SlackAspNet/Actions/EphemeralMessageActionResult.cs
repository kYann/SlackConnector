using SlackAspNet.Actions.Executors;
using SlackAspNet.Types;
using SlackLibrary.Models;
using SlackLibrary.Models.Blocks;
using System;
using System.Collections.Generic;
using System.Text;

namespace SlackAspNet.Actions
{
	public interface IEphemeralMessageActionContext : IMessageActionContext
	{
		public UserSlackId UserId { get; }
	}

	public class EphemeralMessageActionContext : MessageActionContext, IEphemeralMessageActionContext
	{
		public EphemeralMessageActionContext(ChannelSlackId channelId, UserSlackId userId) : base(channelId)
		{
			UserId = userId;
		}

		public UserSlackId UserId { get; }
	}

	public class EphemeralMessageActionResult : MessageActionResult<IEphemeralMessageActionContext, EphemeralMessageActionResultExecutor>
	{
		public EphemeralMessageActionResult(string text, MessageOptions options) : base(text, options)
		{
		}

		public EphemeralMessageActionResult(string text, IEnumerable<BlockBase> blocks, MessageOptions options) : base(text, blocks, options)
		{
		}

		public EphemeralMessageActionResult(string text, IEnumerable<SlackAttachment> attachments, MessageOptions options) : base(text, attachments, options)
		{
		}

		protected override IEphemeralMessageActionContext ActionContextToMessageActionContext(ISlackContextActionContext context)
		{
			return new EphemeralMessageActionContext(context.SlackContext.ChannelId, context.SlackContext.UserId);
		}
	}
}
