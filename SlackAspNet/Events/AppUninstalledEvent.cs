using SlackAspNet.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace SlackAspNet.Events
{
	public class AppUninstalledEvent
	{
		public AppUninstalledEvent(SlackTeam team)
		{
			Team = team;
		}

		public SlackTeam Team { get; }
	}
}
