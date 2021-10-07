using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VersionManagement.Helper
{
    class CMDHelper
    {
        /*
        string path = @"E:\testsqlcmd";
        path = @"G:\sqlscript";
        string cmd = @".\SQLCMD.EXE /?";
        cmd = @".\SQLCMD.EXE -S " + TextBoxSQLUrl.Text.Trim() + " -U sa -P 11111";
        string result = RunCmd(path, cmd);
        MessageBox.Show(result);
        */

        /*
        int pos = result.IndexOf(cmd) + cmd.Length;
        string cmdexit = path + ">exit";
        int posexit = result.IndexOf(cmdexit);
        int resultlen = result.Length;
        int endlen = resultlen - pos - cmdexit.Length - 2;
        string sub = result.Substring(pos, endlen);
        sub = sub.Trim();
        MessageBox.Show(sub);
        */

        #region 调用cmd执行命令
        public static string RunCmd(string strPath, string strCmd)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            //执行目录
            p.StartInfo.WorkingDirectory = strPath;
            //不使用WorkingDirectory属性查找可执行文件
            p.StartInfo.UseShellExecute = false;
            //重定向输入流
            p.StartInfo.RedirectStandardInput = true;
            //重定向输出流
            p.StartInfo.RedirectStandardOutput = true;
            //重定向错误流
            p.StartInfo.RedirectStandardError = true;
            //隐藏窗口运行
            p.StartInfo.CreateNoWindow = true;

            p.Start();
            //写入命令
            p.StandardInput.WriteLine(strCmd);
            //执行结束
            p.StandardInput.WriteLine("exit");
            //return p.StandardError.ReadToEnd();
            //return p.StandardOutput.ReadToEnd();
            string outputAll = p.StandardError.ReadToEnd();
            //没有报错
            if (string.IsNullOrEmpty(outputAll))
            {
                outputAll = p.StandardOutput.ReadToEnd();
                int outputAllLen = outputAll.Length;
                int responseBegin = outputAll.IndexOf(strCmd) + strCmd.Length;
                string cmdExit = strPath + ">exit";
                int cmdExitBegin = outputAllLen - responseBegin - cmdExit.Length - 2;
                string result = outputAll.Substring(responseBegin, cmdExitBegin).Trim();
                return result;
            }
            //有报错，直接输出错误日志
            else
            {
                return outputAll;
            }
        }
        #endregion
    }
}