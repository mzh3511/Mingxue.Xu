using System.Security.Cryptography;
using System.Text;

namespace RanOpt.Common.RemoteLib.Http.Client.Helper
{
    /// <summary>
    /// md5操作相关
    /// </summary>
    internal class Md5Helper
    {
        /// <summary>
        /// 传入明文，返回用MD5加密后的字符串
        /// </summary>
        /// <param name="str">要加密的字符串</param>
        /// <returns>MD5加密后的字符串</returns>
        internal static string ToMD5_32(string str)
        {
            var md5Hasher = new MD5CryptoServiceProvider();
            var hashBytes = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(str));
            var sBuilder = new StringBuilder();
            foreach (var t in hashBytes)
            {
                sBuilder.Append(t.ToString("x2"));
            }
            return sBuilder.ToString();
        }

        /// <summary>
        /// 传入明文，返回用SHA1密后的字符串
        /// </summary>
        /// <param name="str">要加密的字符串</param>
        /// <returns>SHA1加密后的字符串</returns>
        internal static string ToSha1(string str)
        {
            var byteArray = Encoding.UTF8.GetBytes(str);
            var hashBytes = SHA1.Create().ComputeHash(byteArray);
            var sbHex = new StringBuilder();
            foreach (var t in hashBytes)
                sbHex.Append(t.ToString("X2"));

            return sbHex.ToString();
        }
    }
}