using System.Drawing;
using RanOpt.Common.RemoteLib.Http.Client.Base;
using RanOpt.Common.RemoteLib.Http.Client.Enum;
using RanOpt.Common.RemoteLib.Http.Client.Helper;

namespace RanOpt.Common.RemoteLib.Http.Client.BaseBll
{
    /// <summary>
    /// 具体实现方法
    /// </summary>
    internal class HttpHelperBll
    {
        /// <summary>
        /// Httphelper原始访问类对象
        /// </summary>
        private HttphelperBase _httpbase = new HttphelperBase();

        /// <summary>
        /// 根据相传入的数据，得到相应页面数据
        /// </summary>
        /// <param name="item">参数类对象</param>
        /// <returns>返回HttpResult类型</returns>
        internal HttpResult GetHtml(HttpItem item)
        {
            if (item.Allowautoredirect && item.AutoRedirectCookie)
            {
                HttpResult result = null;
                for (var i = 0; i < 100; i++)
                {
                    item.Allowautoredirect = false;
                    result = _httpbase.GetHtml(item);
                    if (string.IsNullOrWhiteSpace(result.RedirectUrl))
                    {
                        break;
                    }
                    item.Url = result.RedirectUrl;
                    item.Method = "GET";
                    if (item.ResultCookieType == ResultCookieType.String)
                    {
                        item.Cookie += result.Cookie;
                    }
                    else
                    {
                        item.CookieCollection.Add(result.CookieCollection);
                    }
                }
                return result;
            }
            return _httpbase.GetHtml(item);
        }

        /// <summary>
        /// 根据Url获取图片
        /// </summary>
        /// <param name="item">参数类对象</param>
        /// <returns>返回图片</returns>
        internal Image GetImage(HttpItem item)
        {
            item.ResultType = ResultType.Byte;
            return ImageHelper.ByteToImage(GetHtml(item).ResultByte);
        }

        /// <summary>
        /// 快速Post数据这个访求与GetHtml一样，只是不接收返回数据，只做提交。
        /// </summary>
        /// <param name="item">参数类对象</param>
        /// <returns>返回HttpResult类型</returns>
        internal HttpResult FastRequest(HttpItem item)
        {
            return _httpbase.FastRequest(item);
        }
    }
}