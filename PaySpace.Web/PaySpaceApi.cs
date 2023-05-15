using Microsoft.AspNetCore.Authentication;
using Yarp.ReverseProxy.Forwarder;
using Yarp.ReverseProxy.Transforms;
using Yarp.ReverseProxy.Transforms.Builder;

namespace PaySpace.Web
{
    public static class PaySpaceApi
    {
        public static RouteGroupBuilder MapTax(this IEndpointRouteBuilder routes , string url)
        {
            var group = routes.MapGroup("/taxCalc");

            group.RequireAuthorization();

            var transformBuilder = routes.ServiceProvider.GetRequiredService<ITransformBuilder>();
            var transform = transformBuilder.Create(b =>
            {
                b.AddRequestTransform(async c =>
                {
                    var accessToken = await c.HttpContext.GetTokenAsync("access_token");

                    c.ProxyRequest.Headers.Authorization = new("Bearer", accessToken);
                });
            });

            group.MapForwarder("{*path}", url, new ForwarderRequestConfig(), transform);

            return group;
        }
    }
}
