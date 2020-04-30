using System;
using System.Collections.Generic;
using System.Text;
using Whyse.Bots.Slack.Interactors;

namespace SlackAspNet.Events
{
	public class SlackCommandReceivedEvent
	{
		public SlackCommandReceivedEvent(CommandInput input, SlackTeam team)
		{
			Input = input;
			Team = team;
		}

		public CommandInput Input { get; }
		public SlackTeam Team { get; }
	}
}
