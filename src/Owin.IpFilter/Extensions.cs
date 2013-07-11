namespace Owin.IpFilter
{
    using System;
    using System.Net;

    public static class Extensions
    {
        public static IAppBuilder UseIpFiltering(this IAppBuilder appBuilder, Func<IPAddress, bool> rejectRequest)
        {
            appBuilder.Use(typeof(IpFilterMiddleware), rejectRequest);
            return appBuilder;
        }
    }
}
