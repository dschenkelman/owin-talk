namespace Owin.Sample
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;

    using Owin.IpFilter;
    using AppFunc = System.Func<System.Collections.Generic.IDictionary<string, object>, System.Threading.Tasks.Task>;

    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            appBuilder.UseIpFiltering(
                remoteAddress =>
                    {
                        var bytes = remoteAddress.GetAddressBytes();
                        return bytes[0] != 192 && bytes[0] != 172 && bytes[0] != 10 && bytes[0] != 127 && bytes[0] != 0;
                    });
            
            appBuilder.Use(new Func<AppFunc, AppFunc>(ignoredNextMiddleware => this.HelloWorld));
        }

        public Task HelloWorld(IDictionary<string, object> env)
        {
            var responseBytes = Encoding.UTF8.GetBytes("Hello world from OWIN");
            var responseStream = (Stream)env["owin.ResponseBody"];
            var responseHeaders = (IDictionary<string, string[]>)env["owin.ResponseHeaders"];
            responseHeaders["Content-Length"] = new[] { responseBytes.Length.ToString(CultureInfo.InvariantCulture) };
            responseHeaders["Content-Type"] = new[] { "text/plain" };
            return responseStream.WriteAsync(responseBytes, 0, responseBytes.Length);
        }
    }
}