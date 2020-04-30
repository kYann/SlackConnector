using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace SlackAspNet.Endpoints
{
	public class SlackContext
	{
		public SlackContext(string channelId, string threadTs, string teamId, string userId)
		{
			ChannelId = channelId;
			ThreadTs = threadTs;
			TeamId = teamId;
			UserId = userId;
		}

		public string ChannelId { get; }

		public string ThreadTs { get; }

		public string TeamId { get; }

		public string UserId { get; }
	}

	public class SlackEndpoint<T> : SlackEndpoint where T : SlackContext
	{
		public SlackEndpoint(T context)
		{
			Context = context;
		}

		public T Context { get; }
	}

	public class SlackEndpoint
	{
	}
}
