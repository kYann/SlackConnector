using SlackLibrary.Connections.Clients.Chat;
using SlackLibrary.Connections.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SlackAspNet.Actions.Executors
{
	public interface IMessageActionResultExecutor<C> where C : IMessageActionContext
	{
		Task<MessageResponse> Execute(C context, MessageActionResult<C> actionResult);
	}

	public class MessageActionResultExecutor : IMessageActionResultExecutor<IMessageActionContext>
	{
		private readonly IChatClient client;

		public MessageActionResultExecutor(IChatClient client)
		{
			this.client = client;
		}

		public async Task<MessageResponse> Execute(IMessageActionContext context, MessageActionResult<IMessageActionContext> actionResult)
		{
			var result = await this.client.PostMessage(null, (string)context.ChannelId, actionResult.Text, actionResult.Attachments, null, 
				actionResult.Options.IconUrl, actionResult.Options.UserName, actionResult.Options.AsUser, actionResult.Options.LinkNames, 
				actionResult.Blocks);

			return result;
		}
	}
}
