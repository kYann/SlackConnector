using System;
using System.Collections.Generic;
using System.Text;
using Whyse.Bots.Slack.Gateways;

namespace SlackAspNet.Events
{
	public class AuthorizeEvent
	{
		public AuthorizeEvent(SlackTeam team, AccessTokenSlack accessToken, string state, SlackClientIdentity authorizedUser)
		{
			Team = team;
			AccessToken = accessToken;
			State = state;
			AuthorizedUser = authorizedUser;
		}

		public SlackTeam Team { get; protected set; }

		public AccessTokenSlack AccessToken { get; protected set; }

		public string State { get; protected set; }

		public SlackClientIdentity AuthorizedUser { get; protected set; }
	}
}
