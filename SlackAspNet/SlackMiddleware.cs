using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace SlackAspNet
{
	public class SlackMiddleware
	{
		private readonly RequestDelegate next;
        private readonly IOptions<SlackAspNetConfig> slackConfig;

        public SlackMiddleware(RequestDelegate next, IOptions<SlackAspNetConfig> slackConfig)
		{
			this.next = next;
            this.slackConfig = slackConfig;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var endpoints = this.slackConfig.Value?.Endpoints;

            if (context.Request.Path == endpoints.ActionPath)
                ;
            if (context.Request.Path == endpoints.CommandPath)
                ;
            if (context.Request.Path == endpoints.EventPath)
                ;

            await this.next(context);
        }
    }
}
