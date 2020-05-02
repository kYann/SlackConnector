using System;
using System.Collections.Generic;
using System.Text;

namespace SlackAspNet.Types
{
	public class SlackTeam
	{
		public SlackTeam(TeamSlackId id, string name)
		{
			Id = id;
			Name = name;
		}

		public TeamSlackId Id { get; }

		public string Name { get; }
	}
}
