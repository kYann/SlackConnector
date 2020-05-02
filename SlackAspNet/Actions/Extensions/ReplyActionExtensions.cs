using SlackAspNet.Actions;
using SlackAspNet.Endpoints;
using SlackLibrary.Models;
using SlackLibrary.Models.Blocks;
using System;
using System.Collections.Generic;
using System.Text;

namespace SlackAspNet
{
	public static class ReplyActionExtensions
	{
		public static ReplyMessageActionResult Reply<T>(this SlackEndpoint<T> endpoint, string text, IEnumerable<BlockBase> blocks, MessageOptions options = null) where T : SlackContext
		{
			return new ReplyMessageActionResult(text, blocks, options);
		}

		public static ReplyMessageActionResult Reply<T>(this SlackEndpoint<T> endpoint, IEnumerable<BlockBase> blocks, MessageOptions options = null) where T : SlackContext
		{
			return new ReplyMessageActionResult(null, blocks, options);
		}

		public static ReplyMessageActionResult Reply<T>(this SlackEndpoint<T> endpoint, string text, IEnumerable<SlackAttachment> attachements, MessageOptions options = null) where T : SlackContext
		{
			return new ReplyMessageActionResult(text, attachements, options);
		}
	}
}
