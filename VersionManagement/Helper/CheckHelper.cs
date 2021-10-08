using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VersionManagement.Helper
{
    class CheckHelper
    {
        //字符串中是否包含 _(Underscore) ;(Semicolon)
        static string[] strUnderscoreSemicolon = new string[] { "_", ";" };
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
    }
}