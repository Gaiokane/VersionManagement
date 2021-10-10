using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VersionManagement.Helper
{
    class CheckHelper
    {
        #region 校验程序所在路径中是否含有空格
        public static string rootPath = Environment.CurrentDirectory;
        //程序所在路径中中包含空格的提示信息
        public static string messagePathContainSpaces = "程序所在路径中不能含有空格，请确认！" + "\r\n" + rootPath;
        public static bool IsPathContainSpaces()
        {
            if (rootPath.IndexOf(" ") >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 校验字符串中是否含有异常字符（_;）
        //字符串中是否包含 _(Underscore) ;(Semicolon)
        static readonly string[] strUnderscoreSemicolon = new string[] { "_", ";" };
        //字符串中包含 _(Underscore) ;(Semicolon)的提示信息
        public static string messageUnderscoreSemicolon = "所填项中不能含有 _ ;";

        //文本框校验是否包含 _ ;
        public static bool IsStringContainsUnderscoreSemicolon(string str)
        {
            return IsStringContains(str, strUnderscoreSemicolon);
        }

        public static bool IsStringContains(string str, string[] arr)
        {
            foreach (var item in arr)
            {
                if (str.Contains(item))
                {
                    return false;
                }
            }
            return true;
        }
        #endregion
    }
}