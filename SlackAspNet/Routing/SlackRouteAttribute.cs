using System;
using System.Collections.Generic;
using System.Text;

namespace SlackAspNet.Routing
{
    [System.AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    sealed class SlackRouteAttribute : Attribute
    {

        public SlackRouteAttribute(string route)
        {
            this.PositionalString = route;
        }

        public string PositionalString { get; }
    }
}
