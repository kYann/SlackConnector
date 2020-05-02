using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SlackAspNet.Services;
using SlackLibrary;
using System;
using System.IO;
using System.Threading.Tasks;

namespace SlackAspNet
{
	public class SlackMiddleware
	{
		private readonly RequestDelegate next;
        private readonly EventDispatcher eventDispatcher;
        private readonly ISlackSecurity slackSecurity;
        private readonly IOptions<SlackAspNetConfig> slackConfig;

        public SlackMiddleware(RequestDelegate next, 
            EventDispatcher eventDispatcher, 
            ISlackSecurity slackSecurity,
            IOptions<SlackAspNetConfig> slackConfig)
		{
			this.next = next;
            this.eventDispatcher = eventDispatcher;
            this.slackSecurity = slackSecurity;
            this.slackConfig = slackConfig;
        }

        private string ReadBody(HttpRequest request)
        {
            using (var reader = new StreamReader(request.Body))
            {
                var body = reader.ReadToEnd();

                return body;
            }
        }

        private void AssertSecurity(HttpRequest request, string body)
        {
            var signature = request.Headers[SlackSecurity.SignatureHeader];
            var timestamp = request.Headers[SlackSecurity.RequestTimestampHeader];

            this.slackSecurity.AssertRequestFromSlack(slackConfig.Value.SigningKey, timestamp, body, signature);
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var endpoints = this.slackConfig.Value?.Endpoints;

            if (context.Request.Path == endpoints.ActionPath)
                ;
            if (context.Request.Path == endpoints.CommandPath)
                ;
            if (context.Request.Path == endpoints.EventPath)
            {
                var body = this.ReadBody(context.Request);
                this.AssertSecurity(context.Request, body);
                var result = await eventDispatcher.Dispatch(body);

                if (result != null)
                {
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(result));
                }
            }

            await this.next(context);
        }
    }
}
