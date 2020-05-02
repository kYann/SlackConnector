using SlackLibrary.Connections.Clients.Chat;
using SlackLibrary.Connections.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SlackAspNet.Actions.Executors
{
	public class ReplyMessageActionResultExecutor : IMessageActionResultExecutor<IReplyMessageActionContext>
	{
		private readonly IChatClient client;

		public ReplyMessageActionResultExecutor(IChatClient client)
		{
			this.client = client;
		}

		public async Task<MessageResponse> Execute(IReplyMessageActionContext context, MessageActionResult<IReplyMessageActionContext> actionResult)
		{
			var result = await this.client.PostMessage(null, (string)context.ChannelId, actionResult.Text, actionResult.Attachments, (string)context.ThreadTs, 
				actionResult.Options.IconUrl, actionResult.Options.UserName, actionResult.Options.AsUser, actionResult.Options.LinkNames, 
				actionResult.Blocks);

			return result;
		}
	}
}
