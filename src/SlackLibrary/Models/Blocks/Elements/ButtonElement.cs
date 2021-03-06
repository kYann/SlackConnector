﻿using Newtonsoft.Json;
using SlackLibrary.Models.Blocks.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SlackLibrary.Models.Blocks.Elements
{
	public class ButtonElement : InteractiveElement
	{
		public const string ElementName = "button";

		public ButtonElement() : base(null, ElementName)
		{
		}

		public ButtonElement(string actionId, string text) : base(actionId, ElementName)
		{
			this.Text = new TextObject(text, TextObjectType.PlainText);
		}

		[JsonProperty(PropertyName = "text")]
		public TextObject Text { get; set; }

		[JsonProperty(PropertyName = "url", NullValueHandling = NullValueHandling.Ignore)]
		public string Url { get; set; }

		[JsonProperty(PropertyName = "value", NullValueHandling = NullValueHandling.Ignore)]
		public string Value { get; set; }

		[JsonProperty(PropertyName = "style", NullValueHandling = NullValueHandling.Ignore)]
		public SlackActionStyle? Style { get; set; }
	}
}
