using System;
using System.Collections.Generic;
using System.Text;

namespace SlackLibrary
{
	public interface ISlackSecurity
	{
		void AssertRequestFromSlack(string key, string requestTimestamp, string body, string expectedSignature);
	}
}
