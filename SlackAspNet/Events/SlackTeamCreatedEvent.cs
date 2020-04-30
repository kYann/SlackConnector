using System;
using System.Collections.Generic;
using System.Text;

namespace SlackAspNet.Events
{
	public class SlackTeamCreatedEvent
	{
		public SlackTeamCreatedEvent(SlackTeam team)
		{
			Team = team;
		}

		public SlackTeam Team { get; protected set; }
	}
}
