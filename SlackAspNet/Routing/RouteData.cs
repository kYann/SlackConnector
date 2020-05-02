using SlackAspNet.Endpoints;
using System;
using System.Collections.Generic;
using System.Text;

namespace SlackAspNet.Routing
{
    /// <summary>
    /// Describes information determined during routing that specifies
    /// the page to be displayed.
    /// </summary>
    public sealed class RouteData
    {
        /// <summary>
        /// Constructs an instance of <see cref="RouteData"/>.
        /// </summary>
        /// <param name="endpointType">The type of the endpoint matching the route, which must implement <see cref="SlackEndpoint"/>.</param>
        /// <param name="routeValues">The route parameter values extracted from the matched route.</param>
        public RouteData(Type endpointType, IReadOnlyDictionary<string, object> routeValues)
        {
            if (endpointType == null)
            {
                throw new ArgumentNullException(nameof(endpointType));
            }

            if (!typeof(SlackEndpoint).IsAssignableFrom(endpointType))
            {
                throw new ArgumentException($"The value must implement {nameof(SlackEndpoint)}.", nameof(endpointType));
            }

            EndpointType = endpointType;
            RouteValues = routeValues ?? throw new ArgumentNullException(nameof(routeValues));
        }

        /// <summary>
        /// Gets the type of the page matching the route.
        /// </summary>
        public Type EndpointType { get; }

        /// <summary>
        /// Gets route parameter values extracted from the matched route.
        /// </summary>
        public IReadOnlyDictionary<string, object> RouteValues { get; }
    }
}
