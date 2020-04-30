using System;
using System.Collections.Generic;
using System.Text;

namespace SlackAspNet.Events
{
	public class SlackTeamJoinedEvent
	{
		public SlackTeamJoinedEvent(SlackTeam team, UserSlackId slackId)
		{
			Team = team;
			SlackId = slackId;
		}

		public SlackTeam Team { get; }
		public UserSlackId SlackId { get; }
	}
}
