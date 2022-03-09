using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace popmsg
{
    public static class FileHelper
    {
        public static string AssemblyFolder
        {
            get
            {
                Assembly assembly = Assembly.GetAssembly(typeof(FileHelper));
                string folder = string.Empty;
                folder = assembly.CodeBase;
                folder = folder.Substring(8, folder.Length - 8);
                folder = Path.GetDirectoryName(folder);
                return folder;
            }
        }


        public static string GetTempFile_FromFileFolder(string file, bool theSameFileFolder)
        {
            if (theSameFileFolder)
            {
                string fileFolder = Path.GetDirectoryName(file);
                string tmpFile = GetTempFile_TempFolder(fileFolder, Path.GetExtension(file));
                return tmpFile;
            }
            else
            {
                return GetTempFile(Path.GetExtension(file));
            }
        }
        public static string GetTempFile_FromFileFolder_SameFolder(string file)
        {
            return GetTempFile_FromFileFolder(file, true);
        }


        public static string GetTempFile(string fileExt)
        {
            string folder = AssemblyFolder;
            folder = Path.Combine(folder, "TempFiles");
            CreateFolder(folder);
            string file = Path.Combine(folder, IDHelper.NewID().ToString()) + fileExt;
            DeleteFile(file);
            return file;
        }
        public static string GetTempFile_TempFolder(string tempFolder, string fileExt)
        {
            string file = Path.Combine(tempFolder, IDHelper.NewID().ToString()) + fileExt;
            FileHelper.DeleteFile(file);
            return file;
        }

        public static string GetTempFile()
        {
            string folder = AssemblyFolder;
            folder = Path.Combine(folder, "TempFiles");
            CreateFolder(folder);
            string file = Path.Combine(folder, IDHelper.NewID().ToString());
            DeleteFile(file);
            return file;
        }
        public static string GetTempFile_TempFolder(string tempFolder)
        {
            string file = Path.Combine(tempFolder, IDHelper.NewID().ToString());
            FileHelper.DeleteFile(file);
            return file;
        }
        public static string GetTempFolder()
        {
            string folder = AssemblyFolder;
            folder = Path.Combine(folder, "TempFolders");
            folder = Path.Combine(folder, IDHelper.NewID().ToString());
            DeleteFolder(folder);
            CreateFolder(folder);
            return folder;
        }

        public static string GetTempFolder(string folderName)
        {
            string folder = AssemblyFolder;
            folder = Path.Combine(folder, "TempFolders");
            folder = Path.Combine(folder, folderName);
            DeleteFolder(folder);
            CreateFolder(folder);
            return folder;
        }


        public static void CreateFolder(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }
        public static void DeleteFolder(string folderPath, string FileType)
        {
            DirectoryInfo info = new DirectoryInfo(folderPath);
            Regex extensionRegex = new Regex(FileType);
            foreach (var item in info.GetFiles())
            {
                if (extensionRegex.IsMatch(item.Extension))
                {
                    item.Delete();
                }
            }
        }
        public static void DeleteFolder(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                return;
            }
            string[] fileList = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories);
            foreach (string tmpFile in fileList)
            {
                SetReadOnly(tmpFile, false);
            }
            Directory.Delete(folderPath, true);
        }
        public static void DeleteFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return;
            }
            SetReadOnly(filePath, false);
            File.Delete(filePath);
        }
        public static bool IsReadOnly(string filePath)
        {
            FileInfo tmpInfo = new FileInfo(filePath);
            return tmpInfo.IsReadOnly;
        }
        public static void SetReadOnly(string filePath, bool readOnly)
        {
            FileInfo tmpInfo = new FileInfo(filePath);
            if (readOnly)
            {
                tmpInfo.Attributes = tmpInfo.Attributes | (FileAttributes)1;
            }
            else
            {
                tmpInfo.Attributes = tmpInfo.Attributes & (FileAttributes)32766;
            }
        }
        public static bool CanNonShareAccess(string filePath)
        {
            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Write, FileShare.None))
                {
                }
                return true;
            }
            catch
            {
                return false;
            }
        }


        public static string CopyNewFile(string filepath)
        {
            string folder = Path.GetDirectoryName(filepath);
            string filename = Path.GetFileName(filepath);
            string newfileName = "";
            int i = 0;
            string tmpFilename = string.Format("copy_{0} ", i) + filename;
            while (true)
            {
                newfileName = Path.Combine(folder, tmpFilename);
                if (!File.Exists(newfileName))
                {
                    File.Copy(filepath, newfileName, true);
                    break;
                }
                i++;
                tmpFilename = string.Format("copy_{0} ", i) + filename;
            }
            return newfileName;
        }

        private static string GetNewFolder(string folder)
        {
            DirectoryInfo di = new DirectoryInfo(folder);
            string folderName = di.Name;
            if (di.Parent == null)
            {
                throw new ExSys("not found parent path.{0}", folder);
            }
            string parentFolder = di.Parent.FullName;
            int i = 0;
            string tmpFolder = string.Format("copy_{0}", i) + folderName;
            string newFolder = "";
            while (true)
            {
                newFolder = Path.Combine(parentFolder, tmpFolder);
                if (!Directory.Exists(newFolder))
                {
                    break;
                }
                i++;
                tmpFolder = string.Format("copy_{0}", i) + folderName;
            }
            return newFolder;
        }
        public static string CopyNewFolder(string folder)
        {
            string newFolder = GetNewFolder(folder);
            if (string.IsNullOrEmpty(newFolder))
            {
                throw new ExSys("can not create new folder.{0}", folder);
            }
            CopyDirectory(folder, newFolder, true);
            return newFolder;
        }


        public static void CopyDirectory(string sourceDir, string destDir, bool recursive)
        {
            if (string.IsNullOrEmpty(sourceDir))
            {
                return;
            }
            if (!Directory.Exists(sourceDir))
            {
                return;
            }
            if (!Directory.Exists(destDir))
            {
                Directory.CreateDirectory(destDir);
            }
            string[] files = Directory.GetFiles(sourceDir);
            foreach (string file in files)
            {
                FileInfo finfo = new FileInfo(file);
                try
                {
                    File.Copy(file, Path.Combine(destDir, finfo.Name), true);
                }
                catch
                {
                }
            }
            if (!recursive)
                return;
            string[] dirs = Directory.GetDirectories(sourceDir);
            foreach (string dir in dirs)
            {
                CopyDirectory(dir, Path.Combine(destDir, Path.GetFileName(dir)), true);
            }
        }


        public static void CopyDirectory(string sourceDir, string destDir, bool recursive, CB_STR cb)
        {
            if (string.IsNullOrEmpty(sourceDir))
            {
                return;
            }
            if (!Directory.Exists(sourceDir))
            {
                return;
            }
            if (!Directory.Exists(destDir))
            {
                Directory.CreateDirectory(destDir);
            }
            string[] files = Directory.GetFiles(sourceDir);
            foreach (string file in files)
            {
                FileInfo finfo = new FileInfo(file);
                try
                {
                    File.Copy(file, Path.Combine(destDir, finfo.Name), true);
                    if (cb != null)
                    {
                        cb(file);
                    }
                }
                catch
                {
                }
            }
            if (!recursive)
                return;
            string[] dirs = Directory.GetDirectories(sourceDir);
            foreach (string dir in dirs)
            {
                CopyDirectory(dir, Path.Combine(destDir, Path.GetFileName(dir)), recursive, cb);
            }
        }


        public static string GetFileBase64String(string localPath)
        {
            if (!CanNonShareAccess(localPath))
            {
                throw new ExSys("文件无法访问=>{0}", localPath);
            }
            byte[] buffers;
            using (FileStream fs = new FileStream(localPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                long bufferCount = fs.Length;
                buffers = new byte[bufferCount];
                fs.Read(buffers, 0, (int)bufferCount);
            }
            return Convert.ToBase64String(buffers);
        }



        public static bool IsSupportImage(string filePath)
        {
            return IsImageWithoutTif(filePath) || IsTIF(filePath);
        }
        public static bool IsImageWithoutTif(string filePath)
        {
            string ext = Path.GetExtension(filePath).ToLower();
            switch (ext)
            {
                case ".bmp":
                case ".jpg":
                case ".jpeg":
                case ".png":
                    return true;
                default: return false;
            }
        }
        public static bool IsTIF(string filePath)
        {
            return Path.GetExtension(filePath).ToLower() == ".tif";
        }
        public static bool IsPDF(string filePath)
        {
            return Path.GetExtension(filePath).ToLower() == ".pdf";
        }
        public static bool IsWord(string filePath)
        {
            string ext = Path.GetExtension(filePath).ToLower();
            switch (ext)
            {
                case ".doc":
                case ".docx":
                    return true;
            }
            return false;
        }
        public static bool IsWord2003(string filePath)
        {
            string ext = Path.GetExtension(filePath).ToLower();
            switch (ext)
            {
                case ".doc":
                    return true;
            }
            return false;
        }
        public static bool IsWord2007(string filePath)
        {
            string ext = Path.GetExtension(filePath).ToLower();
            switch (ext)
            {
                case ".docx":
                    return true;
            }
            return false;
        }
        public static bool IsExcel(string filePath)
        {
            string ext = Path.GetExtension(filePath).ToLower();
            switch (ext)
            {
                case ".xls":
                case ".xlsx":
                    return true;
            }
            return false;
        }
        public static bool IsExcel2003(string filePath)
        {
            string ext = Path.GetExtension(filePath).ToLower();
            switch (ext)
            {
                case ".xls":
                    return true;
            }
            return false;
        }
        public static bool IsExcel2007(string filePath)
        {
            string ext = Path.GetExtension(filePath).ToLower();
            switch (ext)
            {
                case ".xlsx":
                    return true;
            }
            return false;
        }
        public static bool IsPPT(string filePath)
        {
            string ext = Path.GetExtension(filePath).ToLower();
            switch (ext)
            {
                case ".ppt":
                case ".pptx":
                    return true;
            }
            return false;
        }
        public static bool IsPPT2003(string filePath)
        {
            string ext = Path.GetExtension(filePath).ToLower();
            switch (ext)
            {
                case ".ppt":
                    return true;
            }
            return false;
        }
        public static bool IsPPT2007(string filePath)
        {
            string ext = Path.GetExtension(filePath).ToLower();
            switch (ext)
            {
                case ".pptx":
                    return true;
            }
            return false;
        }
        public static bool IsOffice(string filePath)
        {
            return IsWord(filePath) || IsExcel(filePath) || IsPPT(filePath);
        }
        public static bool IsCSV(string filePath)
        {
            string ext = Path.GetExtension(filePath).ToLower();
            switch (ext)
            {
                case ".csv":
                    return true;
            }
            return false;
        }
        public static bool IsXML(string filePath)
        {
            string ext = Path.GetExtension(filePath).ToLower();
            switch (ext)
            {
                case ".xml":
                    return true;
            }
            return false;
        }
        



        #region 删除文件， 等待文件可用
        /// <summary>
        /// 全局超时时间
        /// </summary>
        public static int Timeout = 45 * 1000;

        /// <summary>
        /// 强制删除指定的文件
        /// </summary>
        /// <param name="file"></param>
        /// <param name="timeout"></param>
        public static void DeleteFile(string file, int timeout = 30 * 1000)
        {
            int dTimeout = timeout;
            while (true)
            {
                try
                {
                    FileHelper.DeleteFile(file);
                    if (!File.Exists(file))
                    {
                        break;
                    }
                    Application.DoEvents();
                    Thread.Sleep(500);
                    dTimeout -= 500;
                    if (dTimeout < 0)
                    {
                        throw new ExSys("删除文件超时 =>{0}", file);
                    }
                }
                catch (ThreadAbortException)
                {
                    throw new ExSys("线程退出=>DeleteFile");
                }
            }
        }

        /// <summary>
        /// 强制等待一个文件，超时抛出异常
        /// </summary>
        /// <param name="file">等待一个文件</param>
        /// <param name="waitTime">超时时间 ，单位：毫秒</param>
        public static void WaitFile(string file, int waitTime = 30 * 1000)
        {
            string pdf = file;
            int timeout = waitTime;
            while (true)
            {
                try
                {
                    Thread.Sleep(1000);
                    if (timeout < 0)
                    {
                        throw new ExSys("文件处理超时=>{0}", file);
                    }
                    timeout -= 1000;
                    if (File.Exists(pdf) && FileHelper.CanNonShareAccess(pdf))
                    {
                        break;
                    }
                }
                catch (ThreadAbortException)
                {
                    throw new ExSys("线程退出=>WaitFile");
                }
            }
        }


        /// <summary>
        /// 等待一组文件中任意一个文件存在（可写）时，返回该文件
        /// 超时时间内未发现，会抛出异常
        /// </summary>
        /// <param name="files"></param>
        /// <param name="waitTime"></param>
        /// <returns></returns>
        public static string FindWaitFile(List<string> files, int waitTime = 30 * 1000)
        {
            if (files.Count == 0)
            {
                throw new ExSys("未发现需要等待的文件");
            }             
            int timeout = waitTime;
            while (true)
            {
                try
                {
                    Thread.Sleep(500);
                    if (timeout < 0)
                    {
                        throw new ExSys("文件处理超时");
                    }
                    timeout -= 500;

                    foreach (var file in files)
                    {
                        if (File.Exists(file) && FileHelper.CanNonShareAccess(file))
                        {
                            return file;
                        }
                    }
                }
                catch (ThreadAbortException)
                {
                    throw new ExSys("线程退出=>FindWaitFile");
                }
            }
        }



        /// <summary>
        /// 强制等待一个文件，超时抛出异常
        /// 等待的文件判断方式，文件存在，且可以独占使用，并且文件的大小不可以为ckSize
        /// </summary>
        /// <param name="file"></param>
        /// <param name="ckSize"></param>
        /// <param name="waitTime"></param>
        public static void WaitFile_checkBlank(string file, long ckSize, int waitTime = 45 * 1000)
        {
            string pdf = file;
            int timeout = waitTime;
            while (true)
            {
                try
                {
                    Thread.Sleep(1000);
                    if (timeout < 0)
                    {
                        throw new ExSys("超时时间内无法检查到虚拟打印文件=>{0}", file);
                    }
                    if (File.Exists(pdf) && FileHelper.CanNonShareAccess(pdf))
                    {
                        FileInfo fi = new FileInfo(pdf);
                        if (fi.Length > ckSize)
                        {
                            break;
                        }
                    }
                    timeout -= 1000;
                }
                catch (ThreadAbortException)
                {
                    throw new ExSys("线程退出=>WaitFile_checkBlank");
                }
            }
        }
        #endregion



        #region 文件特征码

        /// <summary>
        /// 获取文件特征码，文件大小必须在10M 以内
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string GetFileCode(string file)
        {
            byte[] buffer;
            using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                if (fs.Length == 0)
                {
                    throw new ExSys("文件为空，无法获取特征码");
                }
                buffer = new byte[fs.Length];
                fs.Read(buffer, 0, (int)fs.Length);
            }
            if (buffer.Length == 0)
            {
                throw new ExSys("文件为空，无法获取特征码");
            }

            return ComputeHash(buffer);
    
        }

        public static string ComputeHash(byte[] buffer)
        {
            using (MD5 provider = new MD5CryptoServiceProvider())
            {
                byte[] result = provider.ComputeHash(buffer, 0, buffer.Length);

                string strReturn = "";
                for (int j = 0; j < result.Length; j++)
                {
                    strReturn += result[j].ToString("X").PadLeft(2, '0');
                }
                return strReturn;
            }
        }
        #endregion
    }
}