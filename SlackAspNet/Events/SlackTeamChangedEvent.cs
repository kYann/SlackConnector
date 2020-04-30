using System;
using System.Collections.Generic;
using System.Text;

namespace SlackAspNet.Events
{
	public class SlackTeamChangedEvent
	{
		public SlackTeamChangedEvent(SlackTeam team)
		{
			Team = team;
		}

		public SlackTeam Team { get; }
	}
}
