using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Text.RegularExpressions;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.Net.Security;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Reflection;
using System.Threading; 
using System.Data.SqlClient;

namespace popmsg
{
    public static class Common
    {

        #region base
        public static string JobResult_Done = "Done";
        public static string JobResult_ErrorFormat = "Error - {0}";
        public static string ProcessJobResult_ErrorFormat(string errMsg)
        {
            return Common.ProcessNVarcharLength(string.Format(Common.JobResult_ErrorFormat, errMsg), 200);
        }
        public static string ProcessJobResult_ErrorFormat(Exception ex)
        {
            return Common.ProcessNVarcharLength(string.Format(Common.JobResult_ErrorFormat, ex.Message), 200);
        }
        public static string ProcessNVarcharLength(string txt, int length)
        {
            if (txt.Length > length)
            {
                return txt.Substring(0, length - 3) + "...";
            }
            else
            {
                return txt;
            }
        }
        
        public static bool Matching(Rectangle rect1, Rectangle rect2, int allowOffsetX, int allowOffsetY, int allowOffsetW, int allowOffsetH)
        {
            if (Math.Abs(rect1.X - rect2.X) > allowOffsetX)
            {
                return false;
            }
            if (Math.Abs(rect1.Y - rect2.Y) > allowOffsetY)
            {
                return false;
            }
            if (Math.Abs(rect1.Width - rect2.Width) > allowOffsetW)
            {
                return false;
            }
            if (Math.Abs(rect1.Height - rect2.Height) > allowOffsetH)
            {
                return false;
            }
            return true;
        }


        public static bool IsValidIXName(string ixName)
        {
            if (string.IsNullOrEmpty(ixName))
            {
                return false;
            }
            if (!Regex.IsMatch(ixName, "^[A-Za-z]{1}[A-Za-z0-9]{0,49}$"))
            {
                return false;
            }
            return true;
        }
        public static bool IsValidVarName(string varName)
        {
            if (string.IsNullOrEmpty(varName))
            {
                return false;
            }
            if (!Regex.IsMatch(varName, "^[A-Za-z]{1}[A-Za-z0-9]{0,49}$"))
            {
                return false;
            }

            return true;
        }
        public static bool IsValidSysName(string sysName)
        {
            if (string.IsNullOrEmpty(sysName))
            {
                return false;
            }
            if (sysName.StartsWith(" "))
            {
                return false;
            }
            if (sysName.EndsWith(" "))
            {
                return false;
            }
            if (sysName.Contains("  "))
            {
                return false;
            }
            if (sysName.Contains("\r"))
            {
                return false;
            }
            if (sysName.Contains("\n"))
            {
                return false;
            }
            if (sysName.Contains("%"))
            {
                return false;
            }
            if (sysName.Contains("["))
            {
                return false;
            }
            if (sysName.Contains("]"))
            {
                return false;
            }
            if (sysName.Contains(","))
            {
                return false;
            }
            return true;
        }

        public static DateTime Now
        {
            get
            {
                DateTime now = DateTime.Now;
                now = now.AddMilliseconds(-now.Millisecond);
                return now;
            }
        }
        public static DateTime DefaultDateTime1 = new DateTime(1900, 1, 1, 0, 0, 0); 
        public static DateTime DefaultDateTime2 = new DateTime(2099, 12, 31, 23, 59, 59);  
        public static DateTime EmptyDateTime = new DateTime(1801, 2, 3, 0, 0, 0);
        /// <summary>
        /// yyyy-MM-dd  yyyy/MM/dd yyyy.MM.dd
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime? Forsql_ToDatetimeFromString(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }
            string tmpstr = str.Replace("\r", "").Replace("\n", "").Trim();
            tmpstr = tmpstr.Replace("-", "").Replace(".", "").Replace("/", "").Trim();
            if (tmpstr.Length != 8)
            {
                return null;
            }
            int yy, mm, dd;
            int.TryParse(tmpstr.Substring(0, 4), out yy);
            int.TryParse(tmpstr.Substring(4, 2), out mm);
            int.TryParse(tmpstr.Substring(6, 2), out dd);

            return new DateTime(yy, mm, dd, 0, 0, 0, 2);
        }
        public static DateTime? Forsql_ToDatetimeFromString2(string str, int h, int m, int s, int mill)
        {

            if (string.IsNullOrEmpty(str))
            {
                return null;
            }
            string tmpstr = str.Replace("\r", "").Replace("\n", "").Trim();
            tmpstr = tmpstr.Replace("-", "").Replace(".", "").Replace("/", "").Trim();
            if (tmpstr.Length != 8)
            {
                return null;
            }
            int yy, mm, dd;
            int.TryParse(tmpstr.Substring(0, 4), out yy);
            int.TryParse(tmpstr.Substring(4, 2), out mm);
            int.TryParse(tmpstr.Substring(6, 2), out dd);

            return new DateTime(yy, mm, dd, h, m, s, mill);
        }
        public static DateTime? Forsql_ToDatetimeFromString_Min(string str)
        {

            if (string.IsNullOrEmpty(str))
            {
                return null;
            }
            string tmpstr = str.Replace("\r", "").Replace("\n", "").Trim();
            tmpstr = tmpstr.Replace("-", "").Replace(".", "").Replace("/", "").Trim();
            if (tmpstr.Length != 8)
            {
                return null;
            }
            int yy, mm, dd;
            int.TryParse(tmpstr.Substring(0, 4), out yy);
            int.TryParse(tmpstr.Substring(4, 2), out mm);
            int.TryParse(tmpstr.Substring(6, 2), out dd);

            return new DateTime(yy, mm, dd, 0, 0, 0, 2);
        }
        public static DateTime? Forsql_ToDatetimeFromString_Max(string str)
        {

            if (string.IsNullOrEmpty(str))
            {
                return null;
            }
            string tmpstr = str.Replace("\r", "").Replace("\n", "").Trim();
            tmpstr = tmpstr.Replace("-", "").Replace(".", "").Replace("/", "").Trim();
            if (tmpstr.Length != 8)
            {
                return null;
            }
            int yy, mm, dd;
            int.TryParse(tmpstr.Substring(0, 4), out yy);
            int.TryParse(tmpstr.Substring(4, 2), out mm);
            int.TryParse(tmpstr.Substring(6, 2), out dd);

            return new DateTime(yy, mm, dd, 23, 59, 59, 995);
        }


        public static string MoveFileTo(string srcPath, string toPath, string whenFileExisting)
        {
            string toFolder = Path.GetDirectoryName(toPath);
            FileHelper.CreateFolder(toFolder);
            if (!File.Exists(toPath))
            {
                File.Move(srcPath, toPath);
                return toPath;
            }
            if (whenFileExisting.ToLower() == Common.WhenFileExisting_Overwrite.ToLower())
            {
                FileHelper.DeleteFile(toPath);
                File.Move(srcPath, toPath);
                return toPath;
            }
            else if (whenFileExisting.ToLower() == Common.WhenFileExisting_Rename.ToLower())
            {
                int n = 2;
                while (true)
                {
                    string folder = Path.GetDirectoryName(toPath);
                    string fileNameWithoutExtention = Path.GetFileNameWithoutExtension(toPath);
                    string fileExtention = Path.GetExtension(toPath);
                    string nPath = Path.Combine(folder, string.Format("{0}_{1}{2}", fileNameWithoutExtention, n, fileExtention));
                    if (File.Exists(nPath))
                    {
                        n += 1;
                    }
                    else
                    {
                        File.Move(srcPath, nPath);
                        return nPath;
                    }
                }
            }
            else if (whenFileExisting.ToLower() == Common.WhenFileExisting_Append.ToLower())
            {
                throw new ExSys("Can not support! \"{0}\", \"{1}\"", whenFileExisting, toPath);
            }
            else if (whenFileExisting.ToLower() == Common.WhenFileExisting_Insert.ToLower())
            {
                throw new ExSys("Can not support! \"{0}\", \"{1}\"", whenFileExisting, toPath);
            }
            else if (whenFileExisting.ToLower() == Common.WhenFileExisting_Exception.ToLower())
            {
                throw new ExSys("File exists! \"{0}\", \"{1}\"", whenFileExisting, toPath);
            }
            else
            {
                throw new ExSys("Invalid argument whenFileExisting! \"{0}\"", whenFileExisting);
            }
        }
        
        public static decimal GetFileSizeKB(string filePath)
        {
            FileInfo fi = new FileInfo(filePath);
            if (fi.Length == 0)
            {
                throw new ExSys("The file is empty! \"{0}\"", filePath);
            }
            return Math.Round(Convert.ToDecimal(fi.Length) / 1024m, 4);
        }
        #endregion

        #region DataTable
        public static DateTime TryGetDateTimeByIndex_datestring(DataRow row, string colName)
        {
            if (row.IsNull(colName))
            {
                return EmptyDateTime;
            }
            object o = row[colName];
            if (o == null)
            {
                return EmptyDateTime;
            }
            return TryGetDatetimeFromString(o.ToString());
        }
        public static DateTime TryGetDatetimeFromString(DataRow row, string colName)
        {
            return TryGetDatetimeFromString(TryGetStringByIndex(row, colName));
        }
        public static DateTime TryGetDatetimeFromString(string str)
        {
            if (string.IsNullOrEmpty(str.Trim()))
            {
                return EmptyDateTime;
            }
            string tmp = str.Trim();
            Regex reg = new Regex("[ ]+");
            MatchCollection mc = reg.Matches(str);
            if (mc == null)
            {
                return EmptyDateTime;
            }
            //没有空格
            if (mc.Count == 0)
            {
                return TryGetDatetimeFromString_with3(str);
            }
            //有且只有一个空格
            if (mc.Count != 1)
            {
                return EmptyDateTime;
            }

            string[] strs = tmp.Split(" ".ToCharArray());
            if (strs.Length != 2)
            {
                return EmptyDateTime;
            }

            if (str.Contains("/"))
            {
                return TryGetDatetimeFromString_with1(strs[0], strs[1], "/");
            }
            if (str.Contains("-"))
            {
                return TryGetDatetimeFromString_with1(strs[0], strs[1], "-");
            }
            if (str.Contains("."))
            {
                return TryGetDatetimeFromString_with1(strs[0], strs[1], ".");
            }
            return EmptyDateTime;
        }
        public static DateTime TryGetDatetimeFromString_with3(string str)
        {
            int y = 0, m = 0, d = 0;
            if (str.Contains("/"))
            {
                if (!ParseDate1_ymd(str, "/", out y, out m, out d))
                {
                    return EmptyDateTime;
                }
            }
            if (str.Contains("-"))
            {
                if (!ParseDate1_ymd(str, "-", out y, out m, out d))
                {
                    return EmptyDateTime;
                }
            }
            if (str.Contains("."))
            {
                if (!ParseDate1_ymd(str, ".", out y, out m, out d))
                {
                    return EmptyDateTime;
                }
            }
            if (y == 0 || m == 0 || d == 0)
            {
                return EmptyDateTime;
            }
            return new DateTime(y, m, d, 0, 0, 0);
        }

        public static bool ParseTime(string str, out int h, out int m, out int s)
        {
            h = 0;
            m = 0;
            s = 0;

            if (string.IsNullOrEmpty(str))
            {
                return false;
            }

            if (!str.Contains(":"))
            {
                return false;
            }

            string[] strs = str.Trim().Split(":".ToCharArray());

            if (strs.Length != 3)
            {
                return false;
            }

            h = int.Parse(strs[0]);
            m = int.Parse(strs[1]);
            s = int.Parse(strs[2]);
            return true;

        }
        public static bool ParseDate1_ymd(string str, string split, out int y, out int m, out int d)
        {
            y = 0;
            m = 0;
            d = 0;

            if (string.IsNullOrEmpty(str))
            {
                return false;
            }

            if (!str.Contains(split))
            {
                return false;
            }

            string[] strs = str.Trim().Split(split.ToCharArray());

            if (strs.Length != 3)
            {
                return false;
            }

            y = int.Parse(strs[0]);
            m = int.Parse(strs[1]);
            d = int.Parse(strs[2]);
            return true;

        }
        public static DateTime TryGetDatetimeFromString_with1(string str1, string str2, string split)
        {
            int y, m, d, H, M, S;
            if (!ParseDate1_ymd(str1, split, out y, out m, out d))
            {
                return EmptyDateTime;
            }

            if (!ParseTime(str2, out H, out M, out S))
            {
                return EmptyDateTime;
            }
            return new DateTime(y, m, d, H, M, S);
        }

        public static string TryGetStringByIndex(DataRow row, int colIndex)
        {
            if (row.IsNull(colIndex))
            {
                return "";
            }
            object o = row[colIndex];
            if (o == null)
            {
                return "";
            }
            return o.ToString();
        }

        public static string TryGetStringByIndex(DataRow row, string colName)
        {
            if (row.IsNull(colName))
            {
                return "";
            }
            object o = row[colName];
            if (o == null)
            {
                return "";
            }
            return o.ToString();
        }
        public static DateTime TryGetDateTimeByIndex(DataRow row, int colIndex)
        {
            return TryGetDatetimeFromString(TryGetStringByIndex(row, colIndex));
        }
        public static DateTime TryGetDateTimeByIndex(DataRow row, string colName)
        {
            return TryGetDatetimeFromString(TryGetStringByIndex(row, colName));
        }

        public static object GetValueByReaderFieldName(SqlDataReader dr, string fieldName, string CSType)
        {
            if (string.IsNullOrEmpty(CSType))
            {
                throw new ExSys("Null or empty argument(DataType)!");
            }
            string dbtype = CSType.ToLower();
            bool isDBNull = dr.IsDBNull(dr.GetOrdinal(fieldName));
            switch (dbtype)
            {
                case "string":
                    if (isDBNull)
                    {
                        return "";
                    }
                    return (string)dr[fieldName];
                case "byte":
                    if (isDBNull)
                    {
                        return 0;
                    }

                    return Convert.ToByte(dr[fieldName]);
                case "int":
                    if (isDBNull)
                    {
                        return 0;
                    }
                    return (int)dr[fieldName];
                case "long":
                    if (isDBNull)
                    {
                        return 0;
                    }
                    return (long)dr[fieldName];
                case "decimal":
                    if (isDBNull)
                    {
                        return 0m;
                    }
                    return (decimal)dr[fieldName];
                case "datetime":
                    if (isDBNull)
                    {
                        return new DateTime(1900, 1, 1, 0, 0, 0);
                    }
                    return (DateTime)dr[fieldName];
                case "byte[]":
                    if (isDBNull)
                    {
                        return new byte[0];
                    }
                    return (byte[])dr[fieldName];
                default: throw new ExSys("Does not support DataType \"{0}\"!", CSType);
            }
        }
        public static object GetValueByReaderFieldName(DataRow dr, string fieldName, string CSType)
        {
            if (string.IsNullOrEmpty(CSType))
            {
                throw new ExSys("Null or empty argument(DataType)!");
            }
            string dbtype = CSType.ToLower();
            bool isDBNull = dr.IsNull(fieldName); //NULL 可以处理 " "
            switch (dbtype)
            {
                case "string":
                    if (isDBNull)
                    {
                        return "";
                    }
                    return (string)dr[fieldName];
                case "byte":
                    if (isDBNull)
                    {
                        return 0;
                    }
                    else
                    {

                    }

                    return Convert.ToByte(dr[fieldName]);
                case "int":
                    if (isDBNull)
                    {
                        return 0;
                    }
                    return (int)dr[fieldName];
                case "long":
                    if (isDBNull)
                    {
                        return 0;
                    }
                    return (long)dr[fieldName];
                case "decimal":
                    if (isDBNull)
                    {
                        return 0m;
                    }
                    return (decimal)dr[fieldName];
                case "datetime":
                    if (isDBNull)
                    {
                        return Common.EmptyDateTime;
                    }
                    return (DateTime)dr[fieldName];
                case "byte[]":
                    if (isDBNull)
                    {
                        return new byte[0];
                    }
                    return (byte[])dr[fieldName];
                default: throw new ExSys("Does not support DataType \"{0}\"!", CSType);
            }
        }
        public static string TryGetStringByIndex(DataGridViewRow row, int colIndex)
        {
            if (row.Cells.Count < colIndex)
            {
                return "";
            }
            if (row.Cells[colIndex].Value == null)
            {
                return "";
            }
            return row.Cells[colIndex].Value.ToString();
        }


        #endregion


        #region OrderDirection
        public const string OrderDirection_ASC = "ASC";
        public const string OrderDirection_DESC = "DESC";

        public static List<string> GetOrderDirectionList()
        {
            return new List<string>()
            {
                OrderDirection_ASC,
                OrderDirection_DESC
            };
        }
        #endregion


        #region TextAlign
        public const string TextAlign_Left = "Left";
        public const string TextAlign_Center = "Center";
        public const string TextAlign_Right = "Right";

        public static List<string> GetTextAlignList()
        {
            return new List<string>()
            {
                TextAlign_Left,
                TextAlign_Center,
                TextAlign_Right
            };
        }
        #endregion





        #region  WhenFileExisting
        public const string WhenFileExisting_Overwrite = "Overwrite";
        public const string WhenFileExisting_Rename = "Rename";
        public const string WhenFileExisting_Append = "Append";
        public const string WhenFileExisting_Insert = "Insert";
        public const string WhenFileExisting_Exception = "Exception";

        public static List<string> GetWhenFileExistingList()
        {
            return new List<string>()
            {
                WhenFileExisting_Overwrite,
                WhenFileExisting_Rename,
                WhenFileExisting_Append,
                WhenFileExisting_Insert
            };
        }
        public static List<string> GetWhenFileExistingList_ExportFile()
        {
            return new List<string>()
            {
                WhenFileExisting_Overwrite,
                WhenFileExisting_Rename,
                WhenFileExisting_Append,
                WhenFileExisting_Insert
            };
        }
        public static List<string> GetWhenFileExistingList_ExportIndex()
        {
            return new List<string>()
            {
                WhenFileExisting_Overwrite,
                WhenFileExisting_Rename,
                WhenFileExisting_Append
            };
        }

        #endregion

        #region WhenInvalidPathCharsFound
        public const string WhenInvalidPathCharsFound_ReplaceWithUnderScore = "ReplaceWithUnderScore";
        public const string WhenInvalidPathCharsFound_ReplaceWithSpace = "ReplaceWithSpace";
        public const string WhenInvalidPathCharsFound_RemoveInvalidChars = "RemoveInvalidChars";
        public const string WhenInvalidPathCharsFound_Exception = "Exception";

        public static List<string> GetWhenInvalidPathCharsFoundList()
        {
            return new List<string>()
            {
                WhenInvalidPathCharsFound_ReplaceWithUnderScore,
                WhenInvalidPathCharsFound_ReplaceWithSpace,
                WhenInvalidPathCharsFound_RemoveInvalidChars,
                WhenInvalidPathCharsFound_Exception
            };
        }

        public static string GetInvalidFileNameCharFoundErrorMsg()
        {
            return "File name can't contain any char as following:\r\n | \" : ? * < > \\ /";
        }
        public static string GetInvalidFilePathCharFoundErrorMsg()
        {
            return "File path can't contain any char as following:\r\n | \" : ? * < >";
        }
        public static List<string> GetInvalidFileNameCharList()
        {
            return new List<string>() { "|", "\"", ":", "?", "*", "<", ">", "\\", "/" };
        }
        public static List<string> GetInvalidFilePathCharList()
        {
            return new List<string>() { "|", "\"", ":", "?", "*", "<", ">" };
        }

        public static bool HasInvalidInFileName(string fileName)
        {
            foreach (string ichar in GetInvalidFileNameCharList())
            {
                if (fileName.Contains(ichar))
                {
                    return true;
                }
            }
            return false;
        }

        public static string ProcessWhenInvalidFileNameCharsFound(string fileName, string whenFound)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return fileName;
            }
            if (false)
            {
            }
            else if (whenFound.ToLower() == Common.WhenInvalidPathCharsFound_ReplaceWithUnderScore.ToLower())
            {
                foreach (string ichar in GetInvalidFileNameCharList())
                {
                    if (fileName.Contains(ichar))
                    {
                        fileName = fileName.Replace(ichar, "_");
                    }
                }
            }
            else if (whenFound.ToLower() == Common.WhenInvalidPathCharsFound_ReplaceWithSpace.ToLower())
            {
                foreach (string ichar in GetInvalidFileNameCharList())
                {
                    if (fileName.Contains(ichar))
                    {
                        fileName = fileName.Replace(ichar, " ");
                    }
                }
            }
            else if (whenFound.ToLower() == Common.WhenInvalidPathCharsFound_RemoveInvalidChars.ToLower())
            {
                foreach (string ichar in GetInvalidFileNameCharList())
                {
                    if (fileName.Contains(ichar))
                    {
                        fileName = fileName.Replace(ichar, "");
                    }
                }
            }
            else if (whenFound.ToLower() == Common.WhenInvalidPathCharsFound_Exception.ToLower())
            {
                foreach (string ichar in GetInvalidFileNameCharList())
                {
                    if (fileName.Contains(ichar))
                    {
                        throw new ExSys(GetInvalidFilePathCharFoundErrorMsg() + "\r\n" + fileName);
                    }
                }
            }
            return fileName;
        }
        public static string ProcessWhenInvalidFileNamePathCharsFound(string fileNamePath, string whenFound)
        {
            string fileFolder = Path.GetDirectoryName(fileNamePath);
            string fileExt = Path.GetExtension(fileNamePath);
            string fileName = ProcessWhenInvalidFileNameCharsFound(Path.GetFileNameWithoutExtension(fileNamePath), whenFound);
            return Path.Combine(fileFolder, fileName + fileExt);
        }
        public static string ProcessWhenInvalidFilePathCharsFound(string filePath, string whenFound)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                return filePath;
            }
            string tmpPath = filePath.Replace("/", "\\");
            string[] strs = tmpPath.Split('\\');
            if (strs.Length < 1)
            {
                return filePath;
            }
            string rPath = strs[0] + "\\";
            for (int i = 1; i < strs.Length; i++)
            {
                string str = strs[i];
                if (false)
                {
                }
                else if (whenFound.ToLower() == Common.WhenInvalidPathCharsFound_ReplaceWithUnderScore.ToLower())
                {
                    foreach (string ichar in GetInvalidFilePathCharList())
                    {
                        if (str.Contains(ichar))
                        {
                            str = str.Replace(ichar, "_");
                        }
                    }
                }
                else if (whenFound.ToLower() == Common.WhenInvalidPathCharsFound_ReplaceWithSpace.ToLower())
                {
                    foreach (string ichar in GetInvalidFilePathCharList())
                    {
                        if (str.Contains(ichar))
                        {
                            str = str.Replace(ichar, " ");
                        }
                    }
                }
                else if (whenFound.ToLower() == Common.WhenInvalidPathCharsFound_RemoveInvalidChars.ToLower())
                {
                    foreach (string ichar in GetInvalidFilePathCharList())
                    {
                        if (str.Contains(ichar))
                        {
                            str = str.Replace(ichar, "");
                        }
                    }
                }
                else if (whenFound.ToLower() == Common.WhenInvalidPathCharsFound_Exception.ToLower())
                {
                    foreach (string ichar in GetInvalidFilePathCharList())
                    {
                        if (str.Contains(ichar))
                        {
                            throw new ExSys(GetInvalidFilePathCharFoundErrorMsg() + " \"{0}\"", str);
                        }
                    }
                }
                rPath += str + "\\";
            }
            return rPath.TrimEnd('\\');
        }


        #endregion

        #region ExportConversion
        public const string ExportConversion_None = "None";
        public const string ExportConversion_TIF = "TIF";
        public const string ExportConversion_PDF = "PDF";
        public const string ExportConversion_SearchablePDF = "SearchablePDF";

        public static List<string> GetExportConversionList()
        {
            return new List<string>()
            {
                ExportConversion_None,
                ExportConversion_TIF,
                ExportConversion_PDF,
                ExportConversion_SearchablePDF
            };
        }
        #endregion





        #region PDFVersion
        public const string PDFVersion_1_2 = "1.2";
        public const string PDFVersion_1_3 = "1.3";
        public const string PDFVersion_1_4 = "1.4";
        public const string PDFVersion_1_5 = "1.5";
        public const string PDFVersion_1_6 = "1.6";
        public const string PDFVersion_1_7 = "1.7";
        public const string PDFVersion_1_6_A = "1.6 PDFA";
        public const string PDFVersion_1_7_A = "1.7 PDFA";
        public static List<string> GetPDFVersionList()
        {
            return new List<string>()
            {
                PDFVersion_1_2,
                PDFVersion_1_3,
                PDFVersion_1_4,
                PDFVersion_1_5,
                PDFVersion_1_6,
                PDFVersion_1_7,
                PDFVersion_1_6_A,
                PDFVersion_1_7_A
            };
        }
        #endregion

        #region HowToUsePDFSetting
        public const string HowToUsePDFSetting_All = "All";
        public const string HowToUsePDFSetting_NotInUse = "NotInUse";
        public static List<string> GetHowToUsePDFSettingList()
        {
            return new List<string>()
            {
                HowToUsePDFSetting_NotInUse,
                HowToUsePDFSetting_All
            };
        }
        #endregion

        #region BW_SaveFormat
        public const string BW_SaveFormat_group4 = "group4";
        public const string BW_SaveFormat_lzw = "lzw";
        public const string BW_SaveFormat_Uncompress = "Uncompress";
        public static List<string> GetBW_SaveFormatList()
        {
            return new List<string>()
            {
                BW_SaveFormat_group4,
                BW_SaveFormat_lzw,
                BW_SaveFormat_Uncompress
            };
        }
        #endregion

        #region Color_SaveFormat
        public const string Color_SaveFormat = "jpeg";
        public const string Color_SaveFormat_lzw = "lzw";
        public const string Color_SaveFormat_Uncompress = "Uncompress";
        public static List<string> GetColor_SaveFormatList()
        {
            return new List<string>()
            {
                Color_SaveFormat,
                Color_SaveFormat_lzw,
                Color_SaveFormat_Uncompress
            };
        }
        #endregion

        #region WatermarkLocation
        public const string WatermarkLocation_LeftTop = "LeftTop";
        public const string WatermarkLocation_LeftMiddle = "LeftMiddle";
        public const string WatermarkLocation_LeftBottom = "LeftBottom";
        public const string WatermarkLocation_TopLeft = "TopLeft";
        public const string WatermarkLocation_TopCenter = "TopCenter";
        public const string WatermarkLocation_TopRight = "TopRight";
        public const string WatermarkLocation_RightTop = "RightTop";
        public const string WatermarkLocation_RightMiddle = "RightMiddle";
        public const string WatermarkLocation_RightBottom = "RightBottom";
        public const string WatermarkLocation_BottomLeft = "BottomLeft";
        public const string WatermarkLocation_BottomCenter = "BottomCenter";
        public const string WatermarkLocation_BottomRight = "BottomRight";

        public static List<string> GetWatermarkLocationList()
        {
            return new List<string>()
            {
                WatermarkLocation_LeftTop,
                WatermarkLocation_LeftMiddle,
                WatermarkLocation_LeftBottom,
                WatermarkLocation_TopLeft,
                WatermarkLocation_TopCenter,
                WatermarkLocation_TopRight,
                WatermarkLocation_RightTop,
                WatermarkLocation_RightMiddle,
                WatermarkLocation_RightBottom,
                WatermarkLocation_BottomLeft,
                WatermarkLocation_BottomCenter,
                WatermarkLocation_BottomRight
            };
        }
        public static List<string> GetFonts()
        {
            List<string> fontNames = new List<string>();
            FontFamily[] ffs = FontFamily.Families;
            foreach (FontFamily ff in ffs)
            {
                if (string.IsNullOrEmpty(ff.Name))
                {
                    continue;
                }
                if (ff.Name.Contains("@"))
                {
                    continue;
                }
                fontNames.Add(ff.Name);
            }
            return fontNames;
        }



        #endregion



        #region WebScanMode
        public const string WebScanMode_OnlyOneTIF = "OnlyOneTIF";
        public const string WebScanMode_OnlyOnePDF = "OnlyOnePDF";
        public const string WebScanMode_MultipleFiles = "MiltipleFiles";

        public static List<string> GetWebScanModeList()
        {
            return new List<string>()
            {
                WebScanMode_OnlyOneTIF,
                WebScanMode_OnlyOnePDF,
                WebScanMode_MultipleFiles
            };
        }
        #endregion

        #region WebScanThumbnailMode
        public const string WebScanThumbnailMode_Normal = "Normal";
        public const string WebScanThumbnailMode_FullScreen = "FullScreen";
        public const string WebScanThumbnailMode_NotDisplayThumbnail = "NotDisplayThumbnail";

        public static List<string> GetWebScanThumbnailModeList()
        {
            return new List<string>()
            {
                WebScanThumbnailMode_Normal,
                WebScanThumbnailMode_FullScreen,
                WebScanThumbnailMode_NotDisplayThumbnail
            };
        }
        #endregion







        #region ContentStrategy
        public const string ContentStrategy_NotUpdate = "NotUpdate";
        public const string ContentStrategy_Replace = "Replace";
        public const string ContentStrategy_Append = "Append";
        public const string ContentStrategy_Insert = "Insert";

        public static List<string> GetContentStrategyList()
        {
            return new List<string>()
            {
                ContentStrategy_NotUpdate,
                ContentStrategy_Replace,
                ContentStrategy_Append,
                ContentStrategy_Insert
            };
        }
        #endregion



        #region ConvertToBWMode
        public const string ConvertToBWMode_General = "General";
        public const string ConvertToBWMode_Jarvis = "Jarvis";
        public const string ConvertToBWMode_Burkes = "Burkes";
        public const string ConvertToBWMode_FloydStein = "FloydStein";

        public static List<string> GetConvertToBWModeList()
        {
            return new List<string>()
            {
                ConvertToBWMode_General,
                ConvertToBWMode_Jarvis,
                ConvertToBWMode_Burkes,
                ConvertToBWMode_FloydStein
            };
        }
        #endregion

        #region LineRemoveMode
        public const string LineRemoveMode_Both = "Both";
        public const string LineRemoveMode_Horizontal = "Horizontal";
        public const string LineRemoveMode_Vertical = "Vertical";

        public static List<string> GetLineRemoveModeList()
        {
            return new List<string>()
            {
                LineRemoveMode_Both,
                LineRemoveMode_Horizontal,
                LineRemoveMode_Vertical
            };
        }
        #endregion

        #region CharacterSmoothMode
        public const string CharacterSmoothMode_General = "General";
        public const string CharacterSmoothMode_FavorLong = "FavorLong";

        public static List<string> GetCharacterSmoothModeList()
        {
            return new List<string>()
            {
                CharacterSmoothMode_General,
                CharacterSmoothMode_FavorLong
            };
        }
        #endregion

        #region OcrEngineName
        public const string OcrEngineName_JS = "JIASHI";
        public const string OcrEngineName_TS = "TS";

        public static List<string> GetOcrEngineNameList()
        {
            return new List<string>()
            {
                OcrEngineName_TS
                //,OcrEngineName_JS
            };
        }

        #endregion





        #region SegmentFindingPosition
        public const string SegmentFindingPosition_Left = "Left";
        public const string SegmentFindingPosition_Top = "Top";
        public const string SegmentFindingPosition_Right = "Right";
        public const string SegmentFindingPosition_Bottom = "Bottom";
        public const string SegmentFindingPosition_LeftTop = "LeftTop";
        public const string SegmentFindingPosition_LeftBottom = "LeftBottom";
        public const string SegmentFindingPosition_RightTop = "RightTop";
        public const string SegmentFindingPosition_RightBottom = "RightBottom";
        public const string SegmentFindingPosition_InnerFirstSegment = "InnerFirstSegment";
        public const string SegmentFindingPosition_InnerLastSegment = "InnerLastSegment";

        public static List<string> GetSegmentFindingPositionList_Keyword()
        {
            return new List<string>()
            {
                SegmentFindingPosition_Left,
                SegmentFindingPosition_Top,
                SegmentFindingPosition_Right,
                SegmentFindingPosition_Bottom,
                SegmentFindingPosition_LeftTop,
                SegmentFindingPosition_LeftBottom,
                SegmentFindingPosition_RightTop,
                SegmentFindingPosition_RightBottom
            };
        }
        public static List<string> GetSegmentFindingPositionList_Frame()
        {
            return new List<string>()
            {
                SegmentFindingPosition_Left,
                SegmentFindingPosition_Top,
                SegmentFindingPosition_Right,
                SegmentFindingPosition_Bottom,
                SegmentFindingPosition_LeftTop,
                SegmentFindingPosition_LeftBottom,
                SegmentFindingPosition_RightTop,
                SegmentFindingPosition_RightBottom,
                SegmentFindingPosition_InnerFirstSegment,
                SegmentFindingPosition_InnerLastSegment
            };
        }
        #endregion

        #region EmailPriority
        public const string EmailPriority_High = "High";
        public const string EmailPriority_Normal = "Normal";
        public const string EmailPriority_Low = "Low";

        public static List<string> GetEmailPriorityList()
        {
            return new List<string>()
            {
                EmailPriority_High,
                EmailPriority_Normal,
                EmailPriority_Low
            };
        }
        #endregion

        #region StdBarcodeDirection
        public const string StdBarcodeDirection_Skew = "Skew";
        public const string StdBarcodeDirection_Horizontal = "Horizontal";
        public const string StdBarcodeDirection_Vertical = "Vertical";
        public static List<string> GetStdBarcodeDirectionList()
        {
            return new List<string>()
            {
                StdBarcodeDirection_Skew,
                StdBarcodeDirection_Horizontal,
                StdBarcodeDirection_Vertical
            };
        }
        #endregion

        #region StdBarcodeType
        public const string StdBarcodeType_Ean8 = "Ean8";
        public const string StdBarcodeType_Ean13 = "Ean13";
        public const string StdBarcodeType_Code39 = "Code39";
        public const string StdBarcodeType_Code93 = "Code93";
        public const string StdBarcodeType_Code128 = "Code128";
        public const string StdBarcodeType_CodeStandard25 = "CodeStandard25";
        public const string StdBarcodeType_CodeInterleaved25 = "CodeInterleaved25";
        public const string StdBarcodeType_Codabar = "Codabar";
        public const string StdBarcodeType_UpcVersionA = "UpcVersionA";
        public const string StdBarcodeType_UpcVersionE = "UpcVersionE";
        public const string StdBarcodeType_Eanext2 = "Eanext2";
        public const string StdBarcodeType_Eanext5 = "Eanext5";
        public static List<string> GetStdBarcodeTypes()
        {
            return new List<string>()
            {
                StdBarcodeType_Ean8,
                StdBarcodeType_Ean13,
                StdBarcodeType_Code39,
                StdBarcodeType_Code93,
                StdBarcodeType_Code128,
                StdBarcodeType_CodeStandard25,
                StdBarcodeType_CodeInterleaved25,
                StdBarcodeType_Codabar,
                StdBarcodeType_UpcVersionA,
                StdBarcodeType_UpcVersionE,
                StdBarcodeType_Eanext2,
                StdBarcodeType_Eanext5
            };
        }
        #endregion






        #region ActionButtonHotKey
        public const string ActionButtonHotKey_F2 = "F2";
        public const string ActionButtonHotKey_F8 = "F8";
        public const string ActionButtonHotKey_F9 = "F9";

        public static List<string> GetActionButtonHotKeyList()
        {
            return new List<string>()
            {
                ActionButtonHotKey_F2,
                ActionButtonHotKey_F8,
                ActionButtonHotKey_F9
            };
        }
        #endregion

        #region PageSize（Inch）
        public static RectangleF A0 = new RectangleF(0f, 0f, 33.11f, 46.811f);
        public static RectangleF A1 = new RectangleF(0f, 0f, 23.386f, 33.11f);
        public static RectangleF A2 = new RectangleF(0f, 0f, 16.535f, 23.386f);
        public static RectangleF A3 = new RectangleF(0f, 0f, 11.693f, 16.536f);
        public static RectangleF A4 = new RectangleF(0f, 0f, 8.268f, 11.693f);
        public static RectangleF A5 = new RectangleF(0f, 0f, 5.827f, 8.268f);
        public static bool IsA0(float w, float h)
        {
            if (w > h)
            {
                float tmp = w;
                w = h;
                h = tmp;
            }
            float LR = (A0.Width - A1.Width) / 2f;
            return w > A0.Width - LR && w <= A0.Width + LR;
        }
        public static bool IsA1(float w, float h)
        {
            if (w > h)
            {
                float tmp = w;
                w = h;
                h = tmp;
            }

            float R = (A0.Width - A1.Width) / 2f;
            float L = (A1.Width - A2.Width) / 2f;
            return w > A1.Width - L && w <= A1.Width + R;
        }
        public static bool IsA2(float w, float h)
        {
            if (w > h)
            {
                float tmp = w;
                w = h;
                h = tmp;
            }

            float R = (A1.Width - A2.Width) / 2f;
            float L = (A2.Width - A3.Width) / 2f;
            return w > A2.Width - L && w <= A2.Width + R;
        }
        public static bool IsA3(float w, float h)
        {
            if (w > h)
            {
                float tmp = w;
                w = h;
                h = tmp;
            }

            float R = (A2.Width - A3.Width) / 2f;
            float L = (A3.Width - A4.Width) / 2f;
            return w > A3.Width - L && w <= A3.Width + R;
        }
        public static bool IsA4(float w, float h)
        {
            if (w > h)
            {
                float tmp = w;
                w = h;
                h = tmp;
            }

            float R = (A3.Width - A4.Width) / 2f;
            float L = (A4.Width - A5.Width) / 2f;
            return w > A4.Width - L && w <= A4.Width + R;
        }
        public static bool IsA5(float w, float h)
        {
            if (w > h)
            {
                float tmp = w;
                w = h;
                h = tmp;
            }

            float LR = (A4.Width - A5.Width) / 2f;
            return w <= A5.Width + LR;
        }
        #endregion

        #region 像素转化成磅
        public static int ToPtFontSize(int pxFontSize)
        {
            //调试值  一般显示器默认96显示进行换算
            return ToPt(pxFontSize, 96);
        }
        public static int ToPt(int px, int dpi)
        {
            return (int)(px * 72f / dpi);
        }
        public static float ToPt(float px, float dpi)
        {
            return (float)(px * 72f / dpi);
        }
        public static SizeF ToPtSize(Size pxSize, int xDpi, int yDpi)
        {
            return ToPtSize(new SizeF(pxSize.Width, pxSize.Height), xDpi, yDpi);
        }
        public static SizeF ToPtSize(SizeF pxSize, float xDpi, float yDpi)
        {
            return new SizeF(ToPt(pxSize.Width, xDpi), ToPt(pxSize.Height, yDpi));
        }
        public static RectangleF ToPtRect(Rectangle pxRect, int xDpi, int yDpi)
        {
            return ToPtRect(new RectangleF(pxRect.X, pxRect.Y, pxRect.Width, pxRect.Height), xDpi, yDpi);
        }
        public static RectangleF ToPtRect(RectangleF pxRect, float xDpi, float yDpi)
        {
            return new RectangleF(ToPt(pxRect.X, xDpi), ToPt(pxRect.Y, yDpi), ToPt(pxRect.Width, xDpi), ToPt(pxRect.Height, yDpi));
        }
        #endregion
        #region 页面尺寸 单位：像素

        #endregion
        //150 dpi
        public static Size A3_px = new Size(3508, 4961);
        public static Size A4_px = new Size(2480, 3508);
        public static Size A5_px = new Size(1748, 2480);
        //300 dpi
        public static Size A3_px_300 = new Size(A3_px.Width / 2, A3_px.Height / 2);
        public static Size A4_px_300 = new Size(A4_px.Width / 2, A4_px.Height / 2);
        public static Size A5_px_300 = new Size(A5_px.Width / 2, A5_px.Height / 2);

        public static List<string> GetPageSizeForYDNameList()
        {
            return new List<string>()
            {
               "A4","A5","A3","None"
            };
        }
        #region Barcode
        public const string WriteBarcodeType_Ean8 = "Ean8";
        public const string WriteBarcodeType_Ean13 = "Ean13";
        public const string WriteBarcodeType_Code39 = "Code39";
        public const string WriteBarcodeType_Code93 = "Code93";
        public const string WriteBarcodeType_Code128 = "Code128";
        public const string WriteBarcodeType_QR = "QR";
        public static List<string> GetWriteBarcodeTypeList()
        {
            return new List<string>()
            {
                WriteBarcodeType_Ean8,
                WriteBarcodeType_Ean13,
                WriteBarcodeType_Code39,
                WriteBarcodeType_Code93,
                WriteBarcodeType_Code128,
                WriteBarcodeType_QR
            };
        }
        #endregion

        #region Page Info
        public static string PageSize_A0 = "A0";
        public static string PageSize_A1 = "A1";
        public static string PageSize_A2 = "A2";
        public static string PageSize_A3 = "A3";
        public static string PageSize_A4 = "A4";
        public static string PageSize_A5 = "A5";
        public static string PageSize_Other = "Other";
        public static List<string> GetPageSizeNameList()
        {
            return new List<string>()
            {
                PageSize_A0,
                PageSize_A1,
                PageSize_A2,
                PageSize_A3,
                PageSize_A4,
                PageSize_A5,
                PageSize_Other
            };
        }

        public static string ColorMode_BW = "BW";
        public static string ColorMode_Color = "Color";
        public static List<string> GetColorModeList()
        {
            return new List<string>()
            {
                ColorMode_BW,
                ColorMode_Color
            };
        }
        #endregion

        #region X509
        public static bool X509_callback(Object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
        public static void X509()
        {
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(X509_callback);
            ServicePointManager.Expect100Continue = false;
        }
        #endregion






        public static Image ConvetTo32x32(Image bit)
        {
            if (bit.Width > 32)
            {
                Image tmpImt = new Bitmap(bit, 32, 32);
                return tmpImt;
            }

            return bit;

        }
        

        public static string ConvertToBase64(string file)
        {
            if (!File.Exists(file))
            {
                throw new ExSys("Not found file({0}).", file);
            }
            string tmpFile = FileHelper.GetTempFile();
            try
            {
                File.Copy(file, tmpFile, true);

                byte[] bs = File.ReadAllBytes(tmpFile);
                return Convert.ToBase64String(bs);
            }
            finally
            {
                FileHelper.DeleteFile(tmpFile);
            }
        }
        public static Image ConvertFromBase64(string base64String)
        {
            using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(base64String)))
            {
                return (Image) Image.FromStream(ms).Clone();
            }
        }

        #region 版本对比
        private static int CompareList(List<int> l1, List<int> l2)
        {
            if (l1.Count != l2.Count)
            {
                throw new ExSys("l1.Count != l2.Count");
            }

            for (int i = 0; i < l1.Count; i++)
            {
                if (l1[i] == l2[i])
                {
                    continue;
                }
                if (l1[i] > l2[i])
                {
                    return 1;
                }
                if (l1[i] < l2[i])
                {
                    return -1;
                }
            }
            return 0;
        }
        private static List<int> GetListFromString(string v)
        {
            List<int> r = new List<int>();
            string[] strs = v.Split(".".ToCharArray());
            foreach (var str in strs)
            {
                int iv = 0;
                if (int.TryParse(str, out iv))
                {
                    r.Add(iv);
                }
                else
                {
                    r.Add(0);
                }
            }


            return r;
        }
        private static List<int> ConvertToLongList(List<int> list, int length)
        {
            List<int> r = new List<int>();
            r.AddRange(list);
            int count = length - list.Count;
            while (count > 0)
            {
                r.Add(0);
                count--;
            }
            return r;
        }
        /// <summary>
        /// 比较两个版本 
        /// V1 大于 V2 返回1 
        /// V1 等于 V2 返回0 
        /// V1 小于 V2 返回-1
        /// </summary>
        /// <param name="V1">4位版本号</param>
        /// <param name="V2">4位版本号</param>
        /// <returns>1，0， -1</returns>
        public static int CompareV(string V1, string V2)
        {
            if (string.IsNullOrEmpty(V1) && string.IsNullOrEmpty(V2))
            {
                return 0;
            }
            if (string.IsNullOrEmpty(V1) && !string.IsNullOrEmpty(V2))
            {
                return -1;
            }
            if (!string.IsNullOrEmpty(V1) && string.IsNullOrEmpty(V2))
            {
                return 1;
            }

            List<int> v1List = GetListFromString(V1);
            List<int> v2List = GetListFromString(V2);

            int l1 = v1List.Count;
            int l2 = v2List.Count;

            if (l1 == l2)
            {
                return CompareList(v1List, v2List);
            }
            else if (l1 > l2)
            {
                List<int> v2Listcopy = ConvertToLongList(v2List, l1);
                return CompareList(v1List, v2Listcopy);
            }
            else
            {
                List<int> v1Listcopy = ConvertToLongList(v1List, l2);
                return CompareList(v1Listcopy, v2List);
            }

        }
        #endregion


        #region 类型转化
        public static int ConvertToInt(string str)
        {
            try
            {
                return int.Parse(str);
            }
            catch { }
            return 0;
        }
        #endregion

        #region 计算一个颜色的亮色

        private static LinkedList<Color> system_colors = new LinkedList<Color>();
        public static Color GetSimilarColor(Color c, int rate)
        {
            if (system_colors.Count == 0)
            {
                Type t = typeof(System.Drawing.Color);
                System.Reflection.PropertyInfo[] properties = t.GetProperties();
                foreach (System.Reflection.PropertyInfo property in properties)
                {
                    if (property.PropertyType.ToString() == "System.Drawing.Color")
                    {
                        system_colors.AddLast((Color)property.GetValue(t, null));
                    }
                }
            }
            int interval = rate;
            List<Color> foundR = new List<Color>();
            foreach (Color cs in system_colors)
            {
                if (Math.Abs(cs.R - c.R) < interval &&
                    Math.Abs(cs.G - c.G) < interval &&
                    Math.Abs(cs.B - c.B) < interval)
                {
                    foundR.Add(cs);
                }
            }
            if (foundR.Count > 0)
            {
                foundR.Sort((a, b) => { return (int)Math.Ceiling(100 * (a.GetBrightness() - b.GetBrightness())); });
                return foundR[foundR.Count - 1];
            }
            else
            {
                rate %= 255;
                float r = rate;
                return GetBringhtFromOld(c, r);
            }
        }


        public static Color GetBringhtFromOld(Color c, float rate)
        {

            int r = c.R;
            int g = c.G;
            int b = c.B;
            float br = 0.299f * r + 0.587f * g + 0.114f * b;

            br += rate;
            br %= 255;

            int a = c.ToArgb();

            //Y = 0.299 * R + 0.587 * G + 0.114 * B;
            int nR = r + (int)Math.Ceiling(br);
            nR %= 255;

            int nG = g + (int)Math.Ceiling(br);
            nG %= 255;

            int nB = b + (int)Math.Ceiling(br);
            nB %= nB;

            return Color.FromArgb(nR, nG, nB);


        }

        /// <summary>
        ///  RGB转HSB
        /// </summary>
        /// <param name="red">红色值</param>
        /// <param name="green">绿色值</param>
        /// <param name="blue">蓝色值</param>
        /// <returns>返回：HSB值集合</returns>
        public static List<float> RGBtoHSB(int red, int green, int blue)
        {
            List<float> hsbList = new List<float>();
            System.Drawing.Color dColor = System.Drawing.Color.FromArgb(red, green, blue);
            hsbList.Add(dColor.GetHue());
            hsbList.Add(dColor.GetSaturation());
            hsbList.Add(dColor.GetBrightness());
            return hsbList;
        }

        public static Color HSBtoRGB(float hue, float saturation, float brightness)
        {
            return HSBtoRGB(255, hue, saturation, brightness);
        }

        /// <summary>
        /// HSB转RGB
        /// </summary>
        /// <param name="hue">色调</param>
        /// <param name="saturation">饱和度</param>
        /// <param name="brightness">亮度</param>
        /// <returns>返回：Color</returns>
        public static Color HSBtoRGB(int alpha, float hue, float saturation, float brightness)
        {
            int r = 0, g = 0, b = 0;
            if (saturation == 0)
            {
                r = g = b = (int)(brightness * 255.0f + 0.5f);
            }
            else
            {
                float h = (hue - (float)Math.Floor(hue)) * 6.0f;
                float f = h - (float)Math.Floor(h);
                float p = brightness * (1.0f - saturation);
                float q = brightness * (1.0f - saturation * f);
                float t = brightness * (1.0f - (saturation * (1.0f - f)));
                switch ((int)h)
                {
                    case 0:
                        r = (int)(brightness * 255.0f + 0.5f);
                        g = (int)(t * 255.0f + 0.5f);
                        b = (int)(p * 255.0f + 0.5f);
                        break;
                    case 1:
                        r = (int)(q * 255.0f + 0.5f);
                        g = (int)(brightness * 255.0f + 0.5f);
                        b = (int)(p * 255.0f + 0.5f);
                        break;
                    case 2:
                        r = (int)(p * 255.0f + 0.5f);
                        g = (int)(brightness * 255.0f + 0.5f);
                        b = (int)(t * 255.0f + 0.5f);
                        break;
                    case 3:
                        r = (int)(p * 255.0f + 0.5f);
                        g = (int)(q * 255.0f + 0.5f);
                        b = (int)(brightness * 255.0f + 0.5f);
                        break;
                    case 4:
                        r = (int)(t * 255.0f + 0.5f);
                        g = (int)(p * 255.0f + 0.5f);
                        b = (int)(brightness * 255.0f + 0.5f);
                        break;
                    case 5:
                        r = (int)(brightness * 255.0f + 0.5f);
                        g = (int)(p * 255.0f + 0.5f);
                        b = (int)(q * 255.0f + 0.5f);
                        break;
                }
            }
            return Color.FromArgb(alpha, Convert.ToByte(r), Convert.ToByte(g), Convert.ToByte(b));
        }
        /// <summary>
        /// 获取指定颜色的相反颜色
        /// </summary>
        /// <param name="sourceColor">Color of the source.</param>
        /// <returns></returns>
        ///   CreateTime:2012-11-24 15:42.
        public static Color NegateColor(Color sourceColor)
        {
            return Color.FromArgb(255 - sourceColor.A, 255 - sourceColor.R, 255 - sourceColor.G, 255 - sourceColor.B);
        }

        #endregion


        #region 操作系统版本

        /// <summary>
        /// 当前是否是windows平台
        /// </summary>
        public static bool IsWindow
        {
            get
            {
                return Environment.OSVersion.Platform == PlatformID.Win32NT
                    || Environment.OSVersion.Platform == PlatformID.Win32S
                    || Environment.OSVersion.Platform == PlatformID.Win32Windows;
            }
        }
        /// <summary>
        /// window 7以后的版本，包含windows7
        /// </summary>
        public static bool IsWindow7Later
        {
            get
            {
                if (!IsWindow)
                {
                    throw new ExSys("Not support your system.");
                }
                return (Environment.OSVersion.Platform == PlatformID.Win32NT)
                    && (Environment.OSVersion.Version.Major >= 6)
                    && (Environment.OSVersion.Version.Minor >= 0);
            }
        }
        /// <summary>
        /// windows XP以前的版本，包含windows XP
        /// </summary>
        public static bool IsWindowXPEarler
        {
            get
            {
                if (!IsWindow)
                {
                    throw new ExSys("Not support your system.");
                }
                return (Environment.OSVersion.Platform == PlatformID.Win32NT)
                    && (Environment.OSVersion.Version.Major <= 5)
                    && (Environment.OSVersion.Version.Minor >= 0);
            }
        }


        public static bool IsSupportOpencv
        {
            get
            {
                return true;
                //if (IsWindow7Later)
                //{
                //    return true;
                //}
                //if (IsWindowXPEarler)
                //{
                //    return false;
                //}
                //return false;
            }
        }

        public static bool IsDebug
        {
            get
            {
#if DEBUG
                return true;
#else

                return false;
#endif
            }
        }

        #endregion



        #region System.Windows.Forms.DataGridView to CSV
        public static string CreateCSVFromDG(string Title, string subTitle, System.Windows.Forms.DataGridView dg)
        {
            string tmpFile = FileHelper.GetTempFile() + ".csv";

            if (dg.Rows.Count == 0)
            {
                throw new ExSys("数据为空，无法导出");
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("," + Title);
            sb.AppendLine(subTitle);
            string title = "";
            //添加标头
            for (int i = 0; i < dg.Columns.Count; i++)
            {
                string colName = dg.Columns[i].HeaderText;
                title += string.Format(",\"{0}\"", colName);
            }
            title = title.Substring(1);

            sb.AppendLine(title);

            for (int i = 0; i < dg.Rows.Count; i++)
            {
                string tmpLine = "";
                for (int j = 0; j < dg.Columns.Count; j++)
                {
                    object ov = dg.Rows[i].Cells[j].Value;
                    string v = "";
                    if (ov != null)
                    {
                        v = ov.ToString();
                    }
                    if (v.Contains("0:00:00"))
                    {
                        v = v.Replace("0:00:00", "");
                    }
                    v = v.Replace("\r", "").Replace("'", "").Replace("\"", "").Replace("\n", "").Trim();
                    tmpLine += string.Format(",\"{0}\"", v);
                }
                tmpLine = tmpLine.Substring(1);
                sb.AppendLine(tmpLine);
            }

            if (sb.Length == 0)
            {
                throw new ExSys("数据为空，无法导出");
            }

            File.AppendAllText(tmpFile, sb.ToString(), Encoding.Default);

            return tmpFile;
        }
        #endregion


        #region 打印系统用户权限配置
        public static string pt_userPower_flag = "pt_userPower_flag";
        #endregion

    }



    public sealed class WaitCursor : IDisposable
    {
        private Cursor _cursor;

        public WaitCursor()
        {
            _cursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~WaitCursor()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_cursor != null)
                {
                    Cursor.Current = _cursor;
                    _cursor = null;
                }
            }
        }
    }
    

    
}
