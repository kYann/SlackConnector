using Microsoft.Extensions.Logging;
using SlackLibrary.Connections.Sockets.Messages.Inbound;
using SlackLibrary.EventAPI;
using SlackLibrary.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SlackAspNet.Services
{
	public class EventDispatcher
	{
		private readonly IEventInterpreter eventInterpreter;
		private readonly ILogger<EventDispatcher> logger;

		public EventDispatcher(IEventInterpreter eventInterpreter, ILogger<EventDispatcher> logger)
		{
			this.eventInterpreter = eventInterpreter;
			this.logger = logger;
		}

		public async Task<object> Dispatch(string json)
		{
			try
			{
				var outerEvent = this.eventInterpreter.InterpretEvent(json);

				switch (outerEvent)
				{
					case UrlVerificationEvent he:
						return this.GenerateHandshakeResult(he);
					case InboundOuterCommonEvent ie:
						switch (ie.Event)
						{
							case MessageChangedEvent me when me.SubType == MessageSubType.message_changed:
								return this.GenerateMessageChangedResult(me, ie.TeamId, ie.EventTime);
							case MessageDeletedEvent me when me.SubType == MessageSubType.message_deleted:
								return this.GenerateMessageDeletedResult(me, ie.TeamId, ie.EventTime);
							case MessageEvent me:
								return this.GenerateMessageReceivedResult(me, ie.TeamId, ie.EventTime);
							case TeamDomainChangeEvent tdce:
								return await this.GenerateTeamUpdateResult(ie.TeamId);
							case TeamRenameEvent tre:
								return await this.GenerateTeamUpdateResult(ie.TeamId);
							case TeamJoinEvent tje when tje.User != null:
								return this.GenerateUserCreationResult(tje.User.Id, ie.TeamId);
							case UserChangeEvent uce when uce.User != null:
								return await this.GenerateUserUpdateResult(uce.User.Id, ie.TeamId);
							case AppUninstalledEvent aue:
								return this.GenerateAppUninstalledResult(aue.ApiAppId, ie.TeamId);
							case ReactionEvent re when ie.Event.Type == EventType.reaction_added:
								return this.GenerateReactionAddedResult(re, ie.TeamId);
							case ReactionEvent re when ie.Event.Type == EventType.reaction_removed:
								return this.GenerateReactionRemovedResult(re, ie.TeamId);
						}
						break;
				}
			}
			catch (Exception e)
			{
				logger.LogError(e, "Error when dispatching event {payload}", json);
				throw;
			}

			return null;
		}

		private object GenerateReactionRemovedResult(ReactionEvent re, string teamId)
		{
			throw new NotImplementedException();
		}

		private object GenerateReactionAddedResult(ReactionEvent re, string teamId)
		{
			throw new NotImplementedException();
		}

		private object GenerateAppUninstalledResult(string apiAppId, string teamId)
		{
			throw new NotImplementedException();
		}

		private Task<object> GenerateUserUpdateResult(string id, string teamId)
		{
			throw new NotImplementedException();
		}

		private object GenerateUserCreationResult(string id, string teamId)
		{
			throw new NotImplementedException();
		}

		private Task<object> GenerateTeamUpdateResult(string teamId)
		{
			throw new NotImplementedException();
		}

		private object GenerateMessageReceivedResult(MessageEvent me, string teamId, DateTime eventTime)
		{
			throw new NotImplementedException();
		}

		private object GenerateMessageDeletedResult(MessageDeletedEvent me, string teamId, DateTime eventTime)
		{
			throw new NotImplementedException();
		}

		private object GenerateMessageChangedResult(MessageChangedEvent me, string teamId, DateTime eventTime)
		{
			throw new NotImplementedException();
		}

		private object GenerateHandshakeResult(UrlVerificationEvent he)
		{
			throw new NotImplementedException();
		}
	}
}
