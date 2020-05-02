using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SlackAspNet.Types
{
#pragma warning disable CS0660, CS0661
	[Serializable]
	public class AccessTokenSlack : StrongType<string>
	{
		public AccessTokenSlack(string value) : base(value)
		{
		}

		protected AccessTokenSlack(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}


		public static explicit operator AccessTokenSlack(string slackId)
		{
			if (slackId is null)
				return null;
			return new AccessTokenSlack(slackId);
		}

		public static bool operator ==(AccessTokenSlack a, AccessTokenSlack b)
		{
			if (a is null)
				return b is null;
			return a.Equals(b);
		}

		public static bool operator !=(AccessTokenSlack a, AccessTokenSlack b)
		{
			if (a is null)
				return !(b is null);
			return !a.Equals(b);
		}
	}
}
