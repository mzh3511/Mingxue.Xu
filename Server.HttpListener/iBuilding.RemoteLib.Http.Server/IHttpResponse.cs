using System.Net;

namespace RanOpt.Common.RemoteLib.Http.Server
{
    public interface IHttpResponse
    {
        void Response(HttpListenerContext listenerContext, ref bool responsed);
    }
}