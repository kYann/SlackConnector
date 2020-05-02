using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SlackAspNet.Types
{
#pragma warning disable CS0660, CS0661
	[Serializable]
	public class TimestampSlack : StrongType<string>
	{
		public TimestampSlack(string value) : base(value)
		{
		}

		protected TimestampSlack(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}


		public static explicit operator TimestampSlack(string slackId)
		{
			if (slackId is null)
				return null;
			return new TimestampSlack(slackId);
		}

		public static bool operator ==(TimestampSlack a, TimestampSlack b)
		{
			if (a is null)
				return b is null;
			return a.Equals(b);
		}

		public static bool operator !=(TimestampSlack a, TimestampSlack b)
		{
			if (a is null)
				return !(b is null);
			return !a.Equals(b);
		}
	}
}
