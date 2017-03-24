using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace Demo.Web
{
    public static class HtmlHelperExtend
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="html"></param>
        /// <param name="src"></param>
        /// <returns></returns>
        public static string GetJsCssVersion(this HtmlHelper html, string src)
        {
            var virtualPath = UrlHelper.GenerateContentUrl("~/", html.ViewContext.HttpContext);
            src = src.Replace("~/", "");
            src = virtualPath + src;

            var filePath = HttpContext.Current.Server.MapPath(src);
            var v = filePath.GetFileMD5();
            return string.Format("{0}?v={1}", src, v);
            //return string.Format("{0}?v={1}", src, ConfigHelper.GetConfigString("jscssversion"));
        }
        public static string GetJsCssVersion(this UrlHelper help, string src)
        {
            var virtualPath = help.Content("~/");
            src = src.Replace("~/", "");
            src = virtualPath + src;
            var filePath = HttpContext.Current.Server.MapPath(src);
            var v = filePath.GetFileMD5();
            return string.Format("{0}?v={1}", src, v);
        }

        #region 獲取文件MD5值
        /// <summary>
        /// 獲取文件MD5值
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string GetFileMD5(this string filePath)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                byte[] hash_byte = md5.ComputeHash(fileStream);
                string str = System.BitConverter.ToString(hash_byte);
                str = str.Replace("-", "");
                return str;
            }
        }
        #endregion
    }
}