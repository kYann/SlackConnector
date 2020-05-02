using SlackAspNet.Actions;
using SlackAspNet.Endpoints;
using SlackLibrary.Models;
using SlackLibrary.Models.Blocks;
using System;
using System.Collections.Generic;
using System.Text;

namespace SlackAspNet
{
	public static class PostActionExtensions
	{
		public static MessageActionResult Post<T>(this SlackEndpoint<T> endpoint, string text, MessageOptions options = null) where T : SlackContext
		{
			return new MessageActionResult(text, options);
		}

		public static MessageActionResult Post<T>(this SlackEndpoint<T> endpoint, string text, IEnumerable<BlockBase> blocks, MessageOptions options = null) where T : SlackContext
		{
			return new MessageActionResult(text, blocks, options);
		}

		public static MessageActionResult Post<T>(this SlackEndpoint<T> endpoint, IEnumerable<BlockBase> blocks, MessageOptions options = null) where T : SlackContext
		{
			return new MessageActionResult(null, blocks, options);
		}

		public static MessageActionResult Post<T>(this SlackEndpoint<T> endpoint, string text, IEnumerable<SlackAttachment> attachements, MessageOptions options = null) where T : SlackContext
		{
			return new MessageActionResult(text, attachements, options);
		}
	}
}
