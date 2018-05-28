using System.Drawing;
using System.IO;

namespace RanOpt.Common.RemoteLib.Http.Client.Helper
{
    internal class ImageHelper
    {
        /// <summary>
        /// 将字节数组转为图片
        /// </summary>
        /// <param name="bytes">字节数组</param>
        /// <returns>返回图片</returns>
        internal static Image ByteToImage(byte[] bytes)
        {
            try
            {
                var ms = new MemoryStream(bytes);
                return Image.FromStream(ms, true);
            }
            catch
            {
                return null;
            }
        }
    }
}