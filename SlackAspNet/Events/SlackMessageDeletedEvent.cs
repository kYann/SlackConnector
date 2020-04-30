using System;
using System.Collections.Generic;
using System.Text;

namespace SlackAspNet.Events
{
	public class SlackMessageDeletedEvent
	{
		public SlackMessageDeletedEvent(SlackDeletedMessageInput input, SlackTeam team, SlackMessage message)
		{
			Input = input;
			Team = team;
			Message = message;
		}

		public SlackDeletedMessageInput Input { get; }
		public SlackTeam Team { get; }
		public SlackMessage Message { get; }
	}
}
