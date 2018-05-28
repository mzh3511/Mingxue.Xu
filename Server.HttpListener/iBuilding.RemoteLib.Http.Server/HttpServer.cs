using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace RanOpt.Common.RemoteLib.Http.Server
{
    /// <summary>
    /// Http服务器
    /// </summary>
    public class HttpServer : IDisposable
    {
        private bool _isDisposed;

        /// <summary>
        /// 服务器的端口
        /// </summary>
        public int Port { get; set; } = 8081;

        /// <summary>
        /// 服务器名称
        /// </summary>
        public string Name { get; set; } = "Zhenhua's http server";

        /// <summary>
        /// 响应列表
        /// </summary>
        public List<IHttpResponse> Responses { get; } = new List<IHttpResponse>();

        /// <summary>
        /// Default ServerCore class constructor.
        /// </summary>
        public HttpServer()
        {
            _isDisposed = false;
        }

        /// <summary>
        /// Run the ServerCore.
        /// </summary>
        public void Run()
        {
            _isDisposed = false;

            // initialize http listener
            var listener = new HttpListener();
            listener.Prefixes.Add($"http://+:{Port}/");  // TODO: https! http://stackoverflow.com/questions/11403333/httplistener-with-https-support
            listener.AuthenticationSchemes = AuthenticationSchemes.Anonymous;

            // start listening
            listener.Start();
            PrintCopyright();

            // listener loop
            while (!_isDisposed)
            {
                var result = listener.BeginGetContext(ProcessCallback, listener);
                result.AsyncWaitHandle.WaitOne();
            }
        }

        /// <summary>
        /// Dispose the server core.
        /// </summary>
        public void Dispose()
        {
            if (_isDisposed)
                return;
            _isDisposed = true;
        }

        private void ProcessCallback(IAsyncResult result)
        {
            var listener = (HttpListener)result.AsyncState;
            var context = listener.EndGetContext(result);
            PrintRequestInfo(context.Request);
            var responsed = false;
            foreach (var httpResponse in Responses)
            {
                httpResponse.Response(context, ref responsed);
                if (responsed)
                    break;
            }
            //如果没有响应
            if (!responsed)
                ProcessHelloResponse(context);
        }

        private void ProcessHelloResponse(HttpListenerContext context)
        {
            var request = context.Request;
            var response = context.Response;
            var postData = string.Empty;
            using (var reader = new StreamReader(request.InputStream, request.ContentEncoding))
            {
                postData = reader.ReadToEnd();
            }
            if (string.IsNullOrEmpty(postData))
                postData = "empty";
            var queryString = new StringBuilder();
            foreach (var key in request.QueryString.AllKeys)
            {
                if (queryString.Length > 0)
                    queryString.Append("&");
                queryString.Append($"{key}={request.QueryString[key]}");
            }
            if (queryString.Length == 0)
                queryString.Append("empty");

            // 构造回应内容
            var responseString = $@"
<html>
	<head><title>From {Name}</title></head>
	<body>  
		<h2>Hello, here is {Name}, may I help you?</h2>
		<table align={"\"left\""} border={"\"1px\""} border-style={"\"solid\""}>
            <tr>
				<th width={"\"300px\""} align={"\"left\""}>Key</th>
				<th width={"\"500px\""} align={"\"left\""}>Value</th>
			</tr>
			<tr>
				<td width={"\"300px\""}> Http method</td>
				<td width={"\"500px\""}>{request.HttpMethod}</td>
			</tr>
			<tr>
				<td>Raw url</td>
				<td>{request.RawUrl}</td>
			</tr>
			<tr>
				<td>Post data</td>
				<td>{postData}</td>
			</tr>
			<tr>
				<td>Query string</td>
				<td>{queryString}</td>
			</tr>
		</table>
	</body>
</html>";

            // 设置回应头部内容，长度，编码
            response.ContentLength64 = Encoding.UTF8.GetByteCount(responseString);
            response.ContentType = "text/html; charset=UTF-8";
            // 输出回应内容
            var output = response.OutputStream;
            var writer = new StreamWriter(output);
            writer.Write(responseString);
            // 必须关闭输出流
            writer.Close();
            Console.WriteLine("Response: Hello word");
        }

        private void PrintCopyright()
        {
            Console.WriteLine($"{Name} (c) 2016-{DateTime.Now.Year}");
            Console.WriteLine($"{Name} is running on {Port} port");
        }

        private void PrintRequestInfo(HttpListenerRequest request)
        {
            Console.WriteLine();
            Console.WriteLine($"HTTP{request.ProtocolVersion}/{request.HttpMethod} {request.Url}");
            //Console.WriteLine("Accept: {0}", request.AcceptTypes == null ? string.Empty : string.Join(", ", request.AcceptTypes));
            //Console.WriteLine("Accept-Language: {0}", request.UserLanguages == null ? string.Empty : string.Join(",", request.UserLanguages));
            //Console.WriteLine($"User-Agent: {request.UserAgent}");
            //Console.WriteLine("Connection: {0}", request.KeepAlive ? "Keep-Alive" : "Close");
            ////Console.WriteLine("Host: {0}", request.UserHostName);
            //Console.WriteLine("Client: {0}", request.RemoteEndPoint);
            //foreach (var key in request.Headers.AllKeys)
            //{
            //    Console.WriteLine($"{key}: {request.Headers[key]}");
            //}
        }
    }
}