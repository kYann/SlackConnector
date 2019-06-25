﻿using Newtonsoft.Json;
using SlackConnector.Models.Blocks.Elements;
using SlackConnector.Models.Blocks.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SlackConnector.Models.Blocks
{
	public class ActionsBlock : BlockBase
	{
		public ActionsBlock() : base("actions")
		{
			this.Elements = new List<InteractiveElement>();
		}

		[JsonProperty(PropertyName = "elements")]
		public IList<InteractiveElement> Elements { get; set; }

		public ActionsBlock AddButton(string actionId, string text, string value = null, string url = null, SlackActionStyle? style = null)
		{
			this.Elements.Add(new ButtonElement("action_button", "Button Click") { ActionId = actionId, Value = value, Url = url, Style = style });
			return this;
		}
	}
}
