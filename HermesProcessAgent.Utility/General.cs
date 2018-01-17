using System;
using System.Diagnostics;
using System.IO;

namespace HermesProcessAgent.Utility
{
    public static class General
    {
        public static string GetCurrentTimeStamp(TimestampFormat tsf)
        {
            string str = "";
            string str1 = "";
            switch (tsf)
            {
                case TimestampFormat.European:
                    {
                        str = "dd/MM/yyyy";
                        str1 = "HH:mm:ss";
                        break;
                    }
                case TimestampFormat.American:
                    {
                        str = "MM-dd-yyyy";
                        str1 = "h:mm:ss tt";
                        break;
                    }
                default:
                    {
                        str = "yyyyMMdd";
                        str1 = "HHmmss";
                        break;
                    }
            }
            string str2 = DateTime.Today.ToString(str);
            DateTime now = DateTime.Now;
            string str3 = string.Concat(str2, " ", now.ToString(str1));
            return str3;
        }

        public static string GetSettingsValue(string settingEntry)
        {
            string str;
            string str1 = Path.Combine(Directory.GetCurrentDirectory(), "HermesProcessAgent.ini");
            try
            {
                if (File.Exists(str1))
                {
                    StreamReader streamReader = new StreamReader(str1);
                    try
                    {
                        string str2 = "";
                        while (true)
                        {
                            string str3 = streamReader.ReadLine();
                            str2 = str3;
                            if (str3 == null)
                            {
                                break;
                            }
                            if (str2.Trim().ToUpper().StartsWith(settingEntry.ToUpper()))
                            {
                                if (str2.Contains("="))
                                {
                                    char[] chrArray = new char[] { '=' };
                                    str = str2.Split(chrArray)[1].Trim();
                                    return str;
                                }
                            }
                        }
                    }
                    finally
                    {
                        if (streamReader != null)
                        {
                            ((IDisposable)streamReader).Dispose();
                        }
                    }
                }
            }
            catch
            {
            }
            str = null;
            return str;
        }

        public static Process IsProcessOpen(string name)
        {
            Process process;
            Process[] processes = Process.GetProcesses();
            int num = 0;
            while (true)
            {
                if (num < (int)processes.Length)
                {
                    Process process1 = processes[num];
                    if (!process1.ProcessName.ToLower().Contains(Path.GetFileNameWithoutExtension(name.ToLower())))
                    {
                        num++;
                    }
                    else
                    {
                        process = process1;
                        break;
                    }
                }
                else
                {
                    process = null;
                    break;
                }
            }
            return process;
        }
    }

    public enum TimestampFormat
    {
        European,
        American,
        Scandinavian
    }

}
