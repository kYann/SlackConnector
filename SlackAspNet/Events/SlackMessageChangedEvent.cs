using System;
using System.Collections.Generic;
using System.Text;

namespace SlackAspNet.Events
{
	public class SlackMessageChangedEvent
	{
		public SlackMessageChangedEvent(SlackChangedMessageInput input, SlackTeam team, SlackMessage message)
		{
			Input = input;
			Team = team;
			Message = message;
		}

		public SlackChangedMessageInput Input { get; }
		public SlackTeam Team { get; }
		public SlackMessage Message { get; }
	}
}
