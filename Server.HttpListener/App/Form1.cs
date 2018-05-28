using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RanOpt.Common.RemoteLib.Http.Client;
using RanOpt.Common.RemoteLib.Http.Client.Consts;

namespace App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            var http = new HttpHelper();
            //创建Httphelper参数对象
            var item = new HttpItem
            {
                Url = txtUrl.Text.Trim(),
                Method = HttpMethodConst.Get,
                ContentType = ContentTypeConst.AppFormUrlencoded,
                PostEncoding = Encoding.UTF8,
                Postdata = string.Empty
            };
            //请求的返回值对象
            var result = http.GetHtml(item);
            txtResult.AppendText($"Request Url = \r\n{item.Url}");
            txtResult.AppendText("\r\n");
            txtResult.AppendText($"Result.StatusCode = \r\n{result.StatusCode}\r\n");
            txtResult.AppendText($"Result.StatusDescription = \r\n{result.StatusDescription}\r\n");
            txtResult.AppendText("\r\n");
            txtResult.AppendText($"Result.Html = \r\n{result.Html}\r\n");
        }

        private void btnFtpRequest_Click(object sender, EventArgs e)
        {
            var request = WebRequest.Create(txtFtpUrl.Text.Trim()) as FtpWebRequest;
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            var response = request.GetResponse() as FtpWebResponse;
            var reader = new StreamReader(response.GetResponseStream());//中文文件名

            List<string> strs = new List<string>();
            string line = reader.ReadLine();
            while (line != null)
            {
                //if (line.Contains("<DIR>"))
                //{
                //    string msg = line.Substring(line.LastIndexOf("<DIR>") + 5).Trim();
                    strs.Add(line);
                //}
                line = reader.ReadLine();
            }
            reader.Close();
            response.Close();
        }
    }
}
