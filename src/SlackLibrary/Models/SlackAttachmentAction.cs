﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace SlackLibrary.Models
{
	public class SlackAttachmentOptionAction
	{
		public SlackAttachmentOptionAction(string text, string value)
		{
			Text = text;
			Value = value;
		}

		[JsonProperty(PropertyName = "text")]
		public string Text { get; set; }

		[JsonProperty(PropertyName = "value")]
		public string Value { get; set; }
	}

	public class SlackAttachmentAction
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "style", NullValueHandling = NullValueHandling.Ignore)]
        public SlackActionStyle? Style { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "value", NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }

		[JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
		public string Url { get; set; }

		[JsonProperty("data_source", NullValueHandling = NullValueHandling.Ignore)]
		public string DataSource { get; set; }

		[JsonProperty("options", NullValueHandling = NullValueHandling.Ignore)]
		public IEnumerable<SlackAttachmentOptionAction> Options { get; set; }

		public SlackAttachmentAction()
        {
            Type = "button";
        }
    }
}