using SlackLibrary.MessageActions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SlackAspNet.Events
{
	public class SlackBlockActionReceivedEvent
	{
		public SlackBlockActionReceivedEvent(BlockActionPayload input)
		{
			Input = input;
		}

		public BlockActionPayload Input { get; }
	}
}
