using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VersionManagement.Helper
{
    class VersionConfig
    {
        //版本配置
        public static string Version;
        //系统配置_V5.0.0
        public static string Version_V5_0_0;
        //系统配置
        public static string System;
        //系统配置_基础
        public static string System_Base;
        //类型配置
        public static string Type;
        //类型配置_BUG
        public static string Type_BUG;
        //类型配置_优化
        public static string Type_Optimization;
        //类型配置_新增
        public static string Type_New;
        //版本详情_模板
        public static string Details;
        //版本详情_V5.0.0
        public static string Detail_V5_0_0;
        //版本详情_V5.0.0_基础_Ids
        public static string Detail_V5_0_0_Base_Ids;
        //版本详情_V5.0.0_基础
        public static string Detail_V5_0_0_Base;
        //版本详情_V5.0.0_基础_1
        public static string Detail_V5_0_0_Base_1;
        //版本详情_V5.0.0_基础_2
        public static string Detail_V5_0_0_Base_2;

        //配置文件路径
        public static string CONFIGPATH = "./Version";

        #region 配置文件初始化，检查默认键是否有缺失，有则新增
        /// <summary>
        /// 配置文件初始化，检查默认键是否有缺失，有则新增
        /// </summary>
        public static void Init()
        {
            GetAllDefaultappSettings();
            SetDefaultSettingsIfIsNullOrEmpty();
            GetAllDefaultappSettings();
        }
        #endregion

        #region 获取配置文件中所有默认键值
        /// <summary>
        /// 获取配置文件中所有默认键值
        /// </summary>
        public static void GetAllDefaultappSettings()
        {
            Version = ConfigHelper.GetappSettings("Version", CONFIGPATH);
            Version_V5_0_0 = ConfigHelper.GetappSettings("Version_V5.0.0", CONFIGPATH);
            System = ConfigHelper.GetappSettings("System", CONFIGPATH);
            System_Base = ConfigHelper.GetappSettings("System_Base", CONFIGPATH);
            Type = ConfigHelper.GetappSettings("Type", CONFIGPATH);
            Type_BUG = ConfigHelper.GetappSettings("Type_BUG", CONFIGPATH);
            Type_Optimization = ConfigHelper.GetappSettings("Type_Optimization", CONFIGPATH);
            Type_New = ConfigHelper.GetappSettings("Type_New", CONFIGPATH);
            Details = ConfigHelper.GetappSettings("Details", CONFIGPATH);
            Detail_V5_0_0 = ConfigHelper.GetappSettings("Detail_V5.0.0", CONFIGPATH);
            Detail_V5_0_0_Base_Ids = ConfigHelper.GetappSettings("Detail_V5.0.0_Base_Ids", CONFIGPATH);
            Detail_V5_0_0_Base = ConfigHelper.GetappSettings("Detail_V5.0.0_Base", CONFIGPATH);
            Detail_V5_0_0_Base_1 = ConfigHelper.GetappSettings("Detail_V5.0.0_Base_1", CONFIGPATH);
            Detail_V5_0_0_Base_2 = ConfigHelper.GetappSettings("Detail_V5.0.0_Base_2", CONFIGPATH);
        }
        #endregion

        #region 如果配置文件中有缺失默认键，则新增
        /// <summary>
        /// 如果配置文件中有缺失默认键，则新增
        /// </summary>
        public static void SetDefaultSettingsIfIsNullOrEmpty()
        {
            if (string.IsNullOrEmpty(Version))
            {
                ConfigHelper.AddappSettings("Version", @"Version_V5.0.0;", CONFIGPATH);
            }
            if (string.IsNullOrEmpty(Version_V5_0_0))
            {
                ConfigHelper.AddappSettings("Version_V5.0.0", @"V5.0.0初始版本;2021-07-31;", CONFIGPATH);
            }
            if (string.IsNullOrEmpty(System))
            {
                ConfigHelper.AddappSettings("System", @"System_Base;", CONFIGPATH);
            }
            if (string.IsNullOrEmpty(System_Base))
            {
                ConfigHelper.AddappSettings("System_Base", @"基础", CONFIGPATH);
            }
            if (string.IsNullOrEmpty(Type))
            {
                ConfigHelper.AddappSettings("Type", @"Type_BUG;Type_Optimization;Type_New;", CONFIGPATH);
            }
            if (string.IsNullOrEmpty(Type_BUG))
            {
                ConfigHelper.AddappSettings("Type_BUG", @"BUG", CONFIGPATH);
            }
            if (string.IsNullOrEmpty(Type_Optimization))
            {
                ConfigHelper.AddappSettings("Type_Optimization", @"优化", CONFIGPATH);
            }
            if (string.IsNullOrEmpty(Type_New))
            {
                ConfigHelper.AddappSettings("Type_New", @"新增", CONFIGPATH);
            }
            if (string.IsNullOrEmpty(Details))
            {
                ConfigHelper.AddappSettings("Details", @"Detail_V5.0.0;", CONFIGPATH);
            }
            if (string.IsNullOrEmpty(Detail_V5_0_0))
            {
                ConfigHelper.AddappSettings("Detail_V5.0.0", @"Detail_V5.0.0_Base", CONFIGPATH);
            }
            if (string.IsNullOrEmpty(Detail_V5_0_0_Base_Ids))
            {
                ConfigHelper.AddappSettings("Detail_V5.0.0_Base_Ids", @"1", CONFIGPATH);
            }
            if (string.IsNullOrEmpty(Detail_V5_0_0_Base))
            {
                ConfigHelper.AddappSettings("Detail_V5.0.0_Base", @"Detail_V5.0.0_Base_1;Detail_V5.0.0_Base_2;", CONFIGPATH);
            }
            if (string.IsNullOrEmpty(Detail_V5_0_0_Base_1))
            {
                ConfigHelper.AddappSettings("Detail_V5.0.0_Base_1", @"Type_New;1;发布内容1;详细描述1;备注1;Database_BaseData;E:\SQL脚本1.sql;", CONFIGPATH);
            }
            if (string.IsNullOrEmpty(Detail_V5_0_0_Base_2))
            {
                ConfigHelper.AddappSettings("Detail_V5.0.0_Base_2", @"Type_BUG;2;发布内容2;详细描述2;备注2;Database_BaseData;E:\SQL脚本2.sql;", CONFIGPATH);
            }
        }
        #endregion

        #region 调用ConfigHelper
        /// <summary>
        /// 配置文件中是否存在指定key
        /// </summary>
        /// <param name="key"></param>
        /// <returns>返回true,false</returns>
        public static bool IsappSettingsExists(string key)
        {
            return ConfigHelper.IsappSettingsExists(key, CONFIGPATH);
        }

        /// <summary>
        /// 指定Key的Value按指定字符分割，遍历是否存在指定字符串
        /// </summary>
        /// <param name="key">appSettings键</param>
        /// <param name="split">value中分隔符</param>
        /// <param name="checkvalue">需要查找到的value</param>
        /// <returns>true, false</returns>
        public static bool IsappSettingsValueExistsBySemicolon(string key, char split, string checkvalue)
        {
            return ConfigHelper.IsappSettingsValueExistsBySemicolon(key, split, checkvalue, CONFIGPATH);
        }

        /// <summary>
        /// 配置文件中新增键值对
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns>返回true,false</returns>
        public static bool AddappSettings(string key, string value)
        {
            return ConfigHelper.AddappSettings(key, value, CONFIGPATH);
        }

        /// <summary>
        /// 配置文件中删除指定key
        /// </summary>
        /// <param name="key"></param>
        /// <returns>返回true,false</returns>
        public static bool DelappSettings(string key)
        {
            return ConfigHelper.DelappSettings(key, CONFIGPATH);
        }

        /// <summary>
        /// 配置文件中删除指定key中的指定value
        /// </summary>
        /// <param name="key"></param>
        /// <param name="delValue"></param>
        /// <param name="split"></param>
        /// <returns>返回true,false</returns>
        public static bool DelappSettingsByValue(string key, string delValue, char split)
        {
            return ConfigHelper.DelappSettingsByValue(key, delValue, split, CONFIGPATH);
        }

        /// <summary>
        /// 配置文件中修改键值对
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns>返回true,false</returns>
        public static bool EditappSettings(string key, string value)
        {
            return ConfigHelper.EditappSettings(key, value, CONFIGPATH);
        }

        /// <summary>
        /// 配置文件中修改键值对，在指定key的value中新增内容
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns>返回true,false</returns>
        public static bool EditappSettingsAddValue(string key, string addvalue, char split)
        {
            return ConfigHelper.EditappSettingsAddValue(key, addvalue, split, CONFIGPATH);
        }

        /// <summary>
        /// 配置文件中读取指定key
        /// </summary>
        /// <param name="key"></param>
        /// <returns>返回key对应value</returns>
        public static string GetappSettings(string key)
        {
            return ConfigHelper.GetappSettings(key, CONFIGPATH);
        }

        /// <summary>
        /// 配置文件中读取指定key，并按指定字符分隔
        /// </summary>
        /// <param name="key"></param>
        /// <param name="split">value中分隔符</param>
        /// <param name="removeEmpty">是否移除空行，默认是</param>
        /// <returns>返回分隔后的数组</returns>
        public static List<string> GetappSettingsSplitBySemicolon(string key, char split, bool removeEmpty = true)
        {
            return ConfigHelper.GetappSettingsSplitBySemicolon(key, split, CONFIGPATH, removeEmpty);
        }

        /// <summary>
        /// 通过主key下子key的value查对应子key
        /// </summary>
        /// <param name="mainKey">主key，如System</param>
        /// <param name="split">主key中子key间的分隔符</param>
        /// <param name="value">子key的value</param>
        /// <returns>若子key中有匹配项，返回子key，否则返回空</returns>
        public static string GetappSettingsKeyByValue(string mainKey, char split, string value)
        {
            List<string> mainKeyValue = GetappSettingsSplitBySemicolon(mainKey, split);
            foreach (var item in mainKeyValue)
            {
                string temp = GetappSettings(item);
                if (temp == value)
                {
                    return item;
                }
            }
            return "";
        }
        #endregion
    }
}