using SlackAspNet.Actions;
using SlackAspNet.Endpoints;
using SlackLibrary.Models;
using SlackLibrary.Models.Blocks;
using System;
using System.Collections.Generic;
using System.Text;

namespace SlackAspNet
{
	public static class PostEphemeralActionExtensions
	{
		public static EphemeralMessageActionResult Post<T>(this SlackEndpoint<T> endpoint, string text, IEnumerable<BlockBase> blocks, MessageOptions options = null) where T : SlackContext
		{
			return new EphemeralMessageActionResult(text, blocks, options);
		}

		public static EphemeralMessageActionResult Post<T>(this SlackEndpoint<T> endpoint, IEnumerable<BlockBase> blocks, MessageOptions options = null) where T : SlackContext
		{
			return new EphemeralMessageActionResult(null, blocks, options);
		}

		public static EphemeralMessageActionResult Post<T>(this SlackEndpoint<T> endpoint, string text, IEnumerable<SlackAttachment> attachements, MessageOptions options = null) where T : SlackContext
		{
			return new EphemeralMessageActionResult(text, attachements, options);
		}
	}
}
