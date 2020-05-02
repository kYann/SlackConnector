using SlackAspNet.Types;
using SlackLibrary.MessageActions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SlackAspNet.Events
{
	public class SlackActionReceivedEvent
	{
		public SlackActionReceivedEvent(ActionPayload input)
		{
			Input = input;
		}

		public ActionPayload Input { get; }
	}
}
