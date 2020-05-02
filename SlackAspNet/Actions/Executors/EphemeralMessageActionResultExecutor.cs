using SlackLibrary.Connections.Clients.Chat;
using SlackLibrary.Connections.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SlackAspNet.Actions.Executors
{
	public class EphemeralMessageActionResultExecutor : IMessageActionResultExecutor<IEphemeralMessageActionContext>
	{
		private readonly IChatClient client;

		public EphemeralMessageActionResultExecutor(IChatClient client)
		{
			this.client = client;
		}

		public async Task<MessageResponse> Execute(IEphemeralMessageActionContext context, MessageActionResult<IEphemeralMessageActionContext> actionResult)
		{
			var result = await this.client.PostEphemeral(null, (string)context.ChannelId, (string)context.UserId, actionResult.Text, actionResult.Attachments, null, 
				actionResult.Options.IconUrl, actionResult.Options.UserName, actionResult.Options.AsUser, actionResult.Options.LinkNames, 
				actionResult.Blocks);

			return result;
		}
	}
}
