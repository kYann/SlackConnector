using System;
using System.Collections.Generic;
using System.Text;
using Whyse.Bots.Slack.Interactors;

namespace SlackAspNet.Events
{
	public class SlackBlockActionReceivedEvent
	{
		public SlackBlockActionReceivedEvent(SlackBlockActionReceivedInput input, SlackTeam team)
		{
			Input = input;
			Team = team;
		}

		public SlackBlockActionReceivedInput Input { get; }
		public SlackTeam Team { get; }
	}
}
