using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace SlackAspNet.Endpoints
{
	public class SlackActionContext : SlackContext
	{
		public SlackActionContext(string channelId, string threadTs, string teamId, string userId, JToken state) : base(channelId, threadTs, teamId, userId)
		{
			State = state;
		}

		public dynamic State { get; }

		public T GetState<T>()
		{
			if (this.State is null)
				return default(T);
			if (!(this.State is JToken))
				throw new ArgumentException("Can only deserializer dynamic to object when using JToken as dynamic " + this.State.GetType().FullName);
			return (this.State as JToken).ToObject<T>();
		}
	}
}
