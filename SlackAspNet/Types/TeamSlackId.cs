using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SlackAspNet.Types
{
#pragma warning disable CS0660, CS0661
	[Serializable]
	public class TeamSlackId : StrongType<string>
	{
		public TeamSlackId(string value) : base(value)
		{
		}

		protected TeamSlackId(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}


		public static explicit operator TeamSlackId(string slackId)
		{
			if (slackId is null)
				return null;
			return new TeamSlackId(slackId);
		}

		public static bool operator ==(TeamSlackId a, TeamSlackId b)
		{
			if (a is null)
				return b is null;
			return a.Equals(b);
		}

		public static bool operator !=(TeamSlackId a, TeamSlackId b)
		{
			if (a is null)
				return !(b is null);
			return !a.Equals(b);
		}
	}
}
