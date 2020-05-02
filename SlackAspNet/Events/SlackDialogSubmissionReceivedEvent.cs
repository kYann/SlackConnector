using SlackAspNet.Types;
using SlackLibrary.MessageActions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SlackAspNet.Events
{
	public class SlackDialogSubmissionReceivedEvent
	{
		public SlackDialogSubmissionReceivedEvent(DialogSubmissionPayload input)
		{
			Input = input;
		}

		public DialogSubmissionPayload Input { get; }
	}
}
