using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SlackAspNet.Types
{
#pragma warning disable CS0660, CS0661
	[Serializable]
	public class ChannelSlackId : StrongType<string>
	{
		public ChannelSlackId(string value) : base(value)
		{
		}

		protected ChannelSlackId(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}


		public static explicit operator ChannelSlackId(string slackId)
		{
			if (slackId is null)
				return null;
			return new ChannelSlackId(slackId);
		}

		public static bool operator ==(ChannelSlackId a, ChannelSlackId b)
		{
			if (a is null)
				return b is null;
			return a.Equals(b);
		}

		public static bool operator !=(ChannelSlackId a, ChannelSlackId b)
		{
			if (a is null)
				return !(b is null);
			return !a.Equals(b);
		}
	}
}
