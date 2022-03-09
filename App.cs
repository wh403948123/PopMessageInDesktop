using popmsg;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PopMessage
{
    static class App
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Trace.Listeners.Clear();
            Trace.Listeners.Add(new FileTraceListener());


            try
            {
                mutex = new Mutex(true, "wh.PopMessage", out isRuning);
                if (!isRuning)
                {
                    System.Diagnostics.Process instance = GetInstance();
                    if (instance != null)
                    {
                        ForegroundInstance(instance);
                    }
                    Environment.Exit(0);
                }
                Application.ThreadException += Application_ThreadException;
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
                DeleteLogFiles();
                DeleteTempFolder();

                DevExpress.UserSkins.BonusSkins.Register();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                new ChineseLanguage.Chinese();
                Application.Run(new Form1());

            }
            finally
            {
                if (mutex != null)
                {
                    mutex.ReleaseMutex();
                }
            }
        }

        public static System.Diagnostics.Process GetInstance()
        {
            System.Diagnostics.Process current = System.Diagnostics.Process.GetCurrentProcess();
            System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcessesByName(current.ProcessName);
            foreach (System.Diagnostics.Process process in processes)
            {
                if (process.Id != current.Id)
                {
                    if (System.Reflection.Assembly.GetExecutingAssembly().Location.Replace("/", "\\") == current.MainModule.FileName)
                    {
                        return process;
                    }
                }
            }
            return null;
        }

        public static void ForegroundInstance(System.Diagnostics.Process instance)
        {
            ShowWindowAsync(instance.MainWindowHandle, WS_SHOWNORMAL);
            SetForegroundWindow(instance.MainWindowHandle);
        }
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject != null)
            {
                Trace.LogError(e.ExceptionObject.ToString());
            }
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            if (e.Exception != null)
            {
                Trace.LogError(e.Exception);
            }
        }

        public static string Ver
        {
            get
            {
                Version version = (typeof(App)).Assembly.GetName().Version;
                return string.Format("{0}.{1}.{2}", version.Major, version.Minor, version.Build);
            }
        }

        #region 日志文件，临时文件，单例运行


        private static Mutex mutex = null;
        private static bool isRuning = false;
        [DllImport("User32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);

        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        private const int WS_SHOWNORMAL = 1;
        private static void DeleteLogFiles()
        {
            new Thread(() => {
                try
                {
                    string folder = FileHelper.AssemblyFolder;
                    folder = Path.Combine(folder, "Logs");
                    if (!Directory.Exists(folder))
                    {
                        return;
                    }
                    string[] files = Directory.GetFiles(folder, "*.log", SearchOption.TopDirectoryOnly);

                    for (int i = files.Length - 1; i >= 0; i--)
                    {
                        Application.DoEvents();
                        Thread.Sleep(1);
                        string tmpFile = files[i];
                        try
                        {
                            //20191219
                            string fileName = Path.GetFileNameWithoutExtension(tmpFile);
                            if (fileName.Length != 8)
                            {
                                continue;
                            }
                            int yy = int.Parse(fileName.Substring(0, 4));
                            int mm = int.Parse(fileName.Substring(4, 2));
                            int dd = int.Parse(fileName.Substring(6, 2));

                            DateTime d1 = new DateTime(yy, mm, dd, 0, 0, 0);
                            TimeSpan ts = DateTime.Now - d1;
                            if (ts.TotalDays > 7)
                            {
                                FileHelper.DeleteFile(tmpFile);
                            }
                        }
                        catch
                        {
                        }
                    }
                }
                catch (ThreadAbortException) { }
                catch { }
            }).Start();
        }
        private static void DeleteTempFolder()
        {
            new Thread(() => {
                try
                {
                    string folder = FileHelper.AssemblyFolder;
                    folder = Path.Combine(folder, "TempFolders");
                    if (!Directory.Exists(folder))
                    {
                        return;
                    }
                    string[] dirs = Directory.GetDirectories(folder, "*", SearchOption.TopDirectoryOnly);

                    for (int i = dirs.Length - 1; i >= 0; i--)
                    {
                        Application.DoEvents();
                        Thread.Sleep(1);
                        string tmpFolder = dirs[i];
                        try
                        {
                            DirectoryInfo fi = new DirectoryInfo(tmpFolder);
                            DateTime d1 = IDHelper.GetDateTimeWithoutMilliseconds(long.Parse(fi.Name));
                            TimeSpan ts = DateTime.Now - d1;
                            if (ts.TotalDays > 1)
                            {
                                fi.Delete(true);
                            }
                        }
                        catch
                        {
                            try
                            {
                                FileHelper.DeleteFolder(tmpFolder);
                            }
                            catch { }
                        }
                    }
                }
                catch (ThreadAbortException) { }
                catch { }
            }).Start();
        }
        #endregion
    }
}
