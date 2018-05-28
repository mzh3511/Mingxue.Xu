using System;
using System.IO;
using System.Net;
using System.Text;
using Love.Server.Models;
using Newtonsoft.Json;
using RanOpt.Common.RemoteLib.Http.Server;

namespace Love.Server.Responses
{
    class AddPensonResponse: IHttpResponse
    {
        public void Response(HttpListenerContext listenerContext, ref bool responsed)
        {
            var request = listenerContext.Request;
            var response = listenerContext.Response;

            var url = request.Url.AbsolutePath;
            if (string.CompareOrdinal(url, "/AddPerson") != 0)
                return;
            var postData = string.Empty;
            using (var reader = new StreamReader(request.InputStream, Encoding.UTF8))
            {
                postData = reader.ReadToEnd();
            }
            //var param = JsonConvert.DeserializeObject<Pet>(postData);
            //if (string.IsNullOrEmpty(param.ProjectId))
            //    param.ProjectId = DateTime.Now.ToFileTimeUtc().ToString();
            responsed = true;
            //var svnUrl = @"svn://192.168.1.119/DB1/COMERICSS000001/" + param.ProjectId;
            var responseString = "你好";
            //JsonConvert.SerializeObject(new RespSyncAuthParam
            //{
            //    ProjectId = param.ProjectId,
            //    SyncServerUrl = svnUrl,
            //    Username = "ibuildnet",
            //    Password = "ranplan"
            //});

            Console.WriteLine($"Response: {responseString}");
            // 设置回应头部内容，长度，编码
            response.ContentLength64 = Encoding.UTF8.GetByteCount(responseString);
            response.ContentType = "text/html; charset=UTF-8";
            // 输出回应内容
            var output = response.OutputStream;
            using (var writer = new StreamWriter(output))
            {
                writer.Write(responseString);
            }
        }
    }
}
