using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SlackAspNet.Actions;
using SlackAspNet.Types;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SlackAspNet.Endpoints
{
	public class SlackContext
	{
		public SlackContext(ChannelSlackId channelId, TimestampSlack threadTs, TeamSlackId teamId, UserSlackId userId)
		{
			ChannelId = channelId;
			ThreadTs = threadTs;
			TeamId = teamId;
			UserId = userId;
		}

		public ChannelSlackId ChannelId { get; }

		public TimestampSlack ThreadTs { get; set; }

		public TeamSlackId TeamId { get; }

		public UserSlackId UserId { get; }
	}

	public class SlackEndpoint<T> : SlackEndpoint where T : SlackContext
	{
		public T Context { get; internal set; }
	}

	public abstract class SlackEndpoint
	{
	}
}
