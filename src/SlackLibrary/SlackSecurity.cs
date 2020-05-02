using System;
using System.Collections.Generic;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace SlackLibrary
{
	public class SlackSecurity : ISlackSecurity
	{
		public const string RequestTimestampHeader = "X-Slack-Request-Timestamp";
		public const string SignatureHeader = "X-Slack-Signature";

		const string Version = "v0";

		public static string ToHexString(byte[] array)
		{
			StringBuilder hex = new StringBuilder(array.Length * 2);
			foreach (byte b in array)
			{
				hex.AppendFormat("{0:x2}", b);
			}
			return hex.ToString();
		}

		public string ComputeHash(string key, string requestTimestamp, string body)
		{
			var hash = new HMACSHA256(Encoding.UTF8.GetBytes(key));
			var message = $"{Version}:{requestTimestamp}:{body}";
			var result = hash.ComputeHash(Encoding.UTF8.GetBytes(message));

			var hexResult = ToHexString(result);

			return $"{Version}={hexResult}";
		}

		public void AssertRequestFromSlack(string key, string requestTimestamp, string body, string expectedSignature)
		{
			var computedSignature = this.ComputeHash(key, requestTimestamp, body);

			if (computedSignature != expectedSignature)
				throw new SecurityException($"Request signature {expectedSignature} does not match computed one {computedSignature}");
		}
	}
}
