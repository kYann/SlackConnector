using System;
using System.Collections.Generic;
using System.Text;

namespace SlackAspNet.Events
{
	public class SlackUserChangedEvent
	{
		public SlackUserChangedEvent(SlackTeam team, UserSlackId slackId)
		{
			Team = team;
			SlackId = slackId;
		}

		public SlackTeam Team { get; protected set; }

		public UserSlackId SlackId { get; protected set; }
	}
}
