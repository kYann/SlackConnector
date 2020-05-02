using SlackAspNet.Events;
using SlackLibrary.MessageActions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SlackAspNet.Interactors
{
	internal class InteractionInteractor
	{
		public async Task HandleAction(ActionPayload input)
		{
			await this.domainEvents.Raise(new SlackActionReceivedEvent(input));
		}

		public async Task HandleBlockAction(BlockActionPayload input)
		{
			await this.domainEvents.Raise(new SlackBlockActionReceivedEvent(input));
		}

		public async Task HandleDialogSubmission(DialogSubmissionPayload input)
		{
			await this.domainEvents.Raise(new SlackDialogSubmissionReceivedEvent(input));
		}
	}
}
