using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VersionManagement.Helper
{
    class DefaultConfig
    {
        //数据库key集合
        public static string Database;
        //数据库BaseData映射
        public static string Database_BaseData;
        //数据库连接信息
        public static string DatabaseConn;

        //配置文件路径
        public static string CONFIGPATH = "./VersionManagement.exe";

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
            Database = ConfigHelper.GetappSettings("Database", CONFIGPATH);
            Database_BaseData = ConfigHelper.GetappSettings("Database_BaseData", CONFIGPATH);
            DatabaseConn = ConfigHelper.GetappSettings("DatabaseConn", CONFIGPATH);
        }
        #endregion

        #region 如果配置文件中有缺失默认键，则新增
        /// <summary>
        /// 如果配置文件中有缺失默认键，则新增
        /// </summary>
        public static void SetDefaultSettingsIfIsNullOrEmpty()
        {
            if (string.IsNullOrEmpty(Database))
            {
                ConfigHelper.AddappSettings("Database", @"Database_BaseData;", CONFIGPATH);
            }
            if (string.IsNullOrEmpty(Database_BaseData))
            {
                ConfigHelper.AddappSettings("Database_BaseData", @"AMS_BaseData", CONFIGPATH);
            }
            if (string.IsNullOrEmpty(DatabaseConn))
            {
                ConfigHelper.AddappSettings("DatabaseConn", @"127.0.0.1\SQL2012,1433;sa;123456;", CONFIGPATH);
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