using System;
using System.Collections.Generic;
using System.Text;
using Whyse.Bots.Slack.Interactors;
using Whyse.Bots.Slack.Services;

namespace SlackAspNet.Events
{
	public class SlackDialogSubmissionReceivedEvent
	{
		public SlackDialogSubmissionReceivedEvent(SlackDialogReceivedInput input, SlackTeam team, CallbackContext callbackContext)
		{
			Input = input;
			Team = team;
			CallbackContext = callbackContext;
		}

		public SlackDialogReceivedInput Input { get; }
		public SlackTeam Team { get; }
		public CallbackContext CallbackContext { get; }
	}
}
