using System;
using System.Collections.Generic;
using System.Text;

namespace SlackAspNet
{
	public class SlackAspNetEndpointConfig
	{
		public string ActionPath { get; set; }

		public string EventPath { get; set; }

		public string CommandPath { get; set; }
	}

	public class SlackAspNetConfig
	{
		public SlackAspNetConfig()
		{
			this.Endpoints = new SlackAspNetEndpointConfig();
		}

		public SlackAspNetEndpointConfig Endpoints { get; set; }
	}
}
