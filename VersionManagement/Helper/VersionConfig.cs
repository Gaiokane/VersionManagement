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
        //版本详情
        public static string Details;
        //版本详情_V5.0.0
        public static string Details_V5_0_0;

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
            Details_V5_0_0 = ConfigHelper.GetappSettings("Details_V5.0.0", CONFIGPATH);
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
                ConfigHelper.AddappSettings("Details", @"Details_V5.0.0_Base;", CONFIGPATH);
            }
            if (string.IsNullOrEmpty(Details_V5_0_0))
            {
                ConfigHelper.AddappSettings("Details_V5.0.0_Base", @"Type_New;2;发布内容;详细描述;备注;Database_BaseData;E:\SQL脚本.sql;", CONFIGPATH);
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
        /// <returns>返回分隔后的数组</returns>
        public static List<string> GetappSettingsSplitBySemicolon(string key, char split)
        {
            return ConfigHelper.GetappSettingsSplitBySemicolon(key, split, CONFIGPATH);
        }
        #endregion
    }
}