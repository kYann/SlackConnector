using System;
using System.Collections.Generic;
using System.Text;

namespace SlackAspNet.Routing
{
    [System.AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    sealed class SlackRouteAttribute : Attribute
    {

        public SlackRouteAttribute(string template)
        {
            this.Template = template;
        }

        public string Template { get; }
    }
}
