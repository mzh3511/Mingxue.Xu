namespace RanOpt.Common.RemoteLib.Http.Client.Consts
{
    /// <summary>
    /// 定义用户的浏览器或相关设备如何显示将要加载的数据，或者如何处理将要加载的数据
    /// </summary>
    public class ContentTypeConst
    {
        /// <summary>
        /// application/x-www-form-urlencoded 窗体数据被编码为名称/值对。这是标准的编码格式
        /// </summary>
        public const string AppFormUrlencoded = "application/x-www-form-urlencoded";
        /// <summary>
        /// multipart/form-data
        /// </summary>
        public const string MultipartFormData = "multipart/form-data";
        /// <summary>
        /// text/html
        /// </summary>
        public const string TextHtml = "text/html";
        /// <summary>
        /// text/plain
        /// </summary>
        public const string TextPlain = "text/plain";
    }
}