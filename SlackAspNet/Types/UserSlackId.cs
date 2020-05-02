using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SlackAspNet.Types
{
#pragma warning disable CS0660, CS0661
	[Serializable]
	public class UserSlackId : StrongType<string>
	{
		public UserSlackId(string value) : base(value)
		{
		}

		protected UserSlackId(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}


		public static explicit operator UserSlackId(string slackId)
		{
			if (slackId is null)
				return null;
			return new UserSlackId(slackId);
		}

		public static bool operator ==(UserSlackId a, UserSlackId b)
		{
			if (a is null)
				return b is null;
			return a.Equals(b);
		}

		public static bool operator !=(UserSlackId a, UserSlackId b)
		{
			if (a is null)
				return !(b is null);
			return !a.Equals(b);
		}
	}
}
