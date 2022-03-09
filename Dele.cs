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
using System.Runtime.InteropServices;
using System.Collections;

namespace popmsg
{
    #region CB
    public delegate void CB();
    public delegate void CB_Object(object o);
    public delegate void CB_BOOL(bool a);
    public delegate void CB_INT_BOOL(int a, bool b);
    public delegate void CB_INT_STR(int a, string b);
    public delegate void CB_STR_BOOL(string a, bool b);
    public delegate void CB_INT(int a);
    public delegate void CB_INT_INT(int a, int b);
    public delegate void CB_STR(string a);
    public delegate void CB_STR_STR(string a, string b);
    public delegate void CB_STR_INT(string a, int b);
    public delegate void CB_STR_INT_INT(string a, int b, int c);
    public delegate void CB_STR_STR_STR(string a, string b, string c);
    public delegate void CB_LIST_INT(List<int> a);
    public delegate void CB_LIST_INT_INT(List<int> a, int b);
    public delegate void CB_STR_BOOL_STR(string a, bool b, string c);
    public delegate void CB_STR_BOOL_STR_STR_STR_STR_STR_INT(string a, bool b, string c, string d, string e, string f, string g, int h);

    public delegate void CBShow_FlashText_CB(Control tb, int time_interval, int times, List<Color> showColors);
    public delegate void CBShow_FlashText_TB(TextBox tb, int time_interval, int times, List<Color> showColors);
    public delegate void CBShow_FlashText_LB(Label tb, int time_interval, int times, List<Color> showColors);
    public delegate void CBShow_FlashText_BB(Button tb, int time_interval, int times, List<Color> showColors);
    public delegate void CBShow_FlashText_GB(GroupBox tb, int time_interval, int times, List<Color> showColors);




    public delegate void CBDataHasChanged(object obj);


    public delegate string CB_Return_Str_Str(string a);
    public delegate string CB_Return_Str_Str_More(string[] argList);
    public delegate bool CB_Return_BOOL();
    #endregion

    #region base
    [Guid("99999999-DDDA-1111-AF5B-F78AF9CD7F89")]
    [ComVisible(true)]
    public class base_SeqDownloadingEventArgs
    {
        public long StoreID { get; set; }
        public int TotalSeqs { get; set; }
        public int Seq { get; set; }
        public bool IsCancel { get; set; }

        public base_SeqDownloadingEventArgs()
        {
            StoreID = 0;
            TotalSeqs = 0;
            Seq = 0;
        }
        public base_SeqDownloadingEventArgs(long storeID, int totalSeqs, int seq, bool cancel)
        {
            StoreID = storeID;
            TotalSeqs = totalSeqs;
            Seq = seq;
            IsCancel = cancel;
        }
    }
    public delegate void base_SeqDownloadingEventHandler(base_SeqDownloadingEventArgs e);
    [Guid("99999999-DDD1-1111-AF5B-F78AF9CD7F89")]
    [ComVisible(true)]
    public class base_FileCompletedArgs
    {
        public base_FileCompletedArgs()
        { 
        }
        public base_FileCompletedArgs(string file)
            : this(file, "")
        {
        }
        public base_FileCompletedArgs(string file, string error)
        {
            this.File = file;
            this.Error = error;
        }
        public string File { get; set; }
        public string Error { get; set; }
    }
    public delegate void base_FileCompleted(base_FileCompletedArgs e);


    [Guid("99999999-DDD2-1111-AF5B-F78AF9CD7F89")]
    [ComVisible(true)]
    public class base_SeqUploadingEventArgs
    {
        public long StoreID { get; set; }
        public int TotalSeqs { get; set; }
        public int Seq { get; set; }

        public bool Cancel { get; set; }

        public base_SeqUploadingEventArgs()
        {
            StoreID = 0;
            TotalSeqs = 0;
            Seq = 0;
        }
        public base_SeqUploadingEventArgs(long storeID, int totalSeqs, int seq, bool cancel)
        {
            StoreID = storeID;
            TotalSeqs = totalSeqs;
            Seq = seq;
            Cancel = cancel;
        }
    }
    public delegate void base_SeqUploadingEventHandler(base_SeqUploadingEventArgs e);
    [Guid("99999999-DDD3-1111-AF5B-F78AF9CD7F89")]
    [ComVisible(true)]
    public class base_DCFileSeqDownloadingEventArgs
    {
        public string DCID { get; set; }
        public string FileName { get; set; }
        public int Ver { get; set; }
        public int TotalSeqs { get; set; }
        public int Seq { get; set; }

        public base_DCFileSeqDownloadingEventArgs()
        {
            this.DCID = "0";
            this.FileName = "";
            this.Ver = 0;
            this.TotalSeqs = 0;
            this.Seq = 0;
        }
        //public base_DCFileSeqDownloadingEventArgs(DCFile dcFile, int totalSeqs, int seq)
        //{
        //    this.DCID = dcFile.DCID.ToString();
        //    this.FileName = dcFile.FileName;
        //    this.Ver = dcFile.Ver;
        //    this.TotalSeqs = totalSeqs;
        //    this.Seq = seq;
        //}
    }
    public delegate void base_DCFileSeqDownloadingEventHandler(base_DCFileSeqDownloadingEventArgs e);
    [Guid("99999999-DDD4-1111-AF5B-F78AF9CD7F89")]
    [ComVisible(true)]
    public class base_DCFileSeqUploadingEventArgs
    {
        public string DCID { get; set; }
        public string FileName { get; set; }
        public int Ver { get; set; }
        public int TotalSeqs { get; set; }
        public int Seq { get; set; }

        public base_DCFileSeqUploadingEventArgs()
        {
            this.DCID = "0";
            this.FileName = "";
            this.Ver = 0;
            this.TotalSeqs = 0;
            this.Seq = 0;
        }
        //public base_DCFileSeqUploadingEventArgs(DCFile dcFile, int totalSeqs, int seq)
        //{
        //    this.DCID = dcFile.DCID.ToString();
        //    this.FileName = dcFile.FileName;
        //    this.Ver = dcFile.Ver;
        //    this.TotalSeqs = totalSeqs;
        //    this.Seq = seq;
        //}
    }
    public delegate void base_DCFileSeqUploadingEventHandler(base_DCFileSeqUploadingEventArgs e);
    [Guid("99999999-DDD5-1111-AF5B-F78AF9CD7F89")]
    [ComVisible(true)]
    public class base_PagePrintingEventArgs
    {
        public string FilePath { get; set; }
        public int TotalPages { get; set; }
        public int Page { get; set; }

        public base_PagePrintingEventArgs()
        {
            FilePath = "";
            TotalPages = 0;
            Page = 0;
        }
        public base_PagePrintingEventArgs(string filePath, int totalPages, int page)
        {
            FilePath = filePath;
            TotalPages = totalPages;
            Page = page;
        }
    }
    public delegate void base_PagePrintingEventHandler(base_PagePrintingEventArgs e);
    [Guid("99999999-DDD6-1111-AF5B-F78AF9CD7F89")]
    [ComVisible(true)]
    public class base_DCFilePagePrintingEventArgs
    {
        public string DCID { get; set; }
        public string FileName { get; set; }
        public int Ver { get; set; }
        public int TotalPages { get; set; }
        public int Page { get; set; }

        public base_DCFilePagePrintingEventArgs()
        {
            this.DCID = "0";
            this.FileName = "";
            this.Ver = 0;
            this.TotalPages = 0;
            this.Page = 0;
        }
        //public base_DCFilePagePrintingEventArgs(DCFile dcFile, int totalPages, int page)
        //{
        //    this.DCID = dcFile.DCID.ToString();
        //    this.FileName = dcFile.FileName;
        //    this.Ver = dcFile.Ver;
        //    this.TotalPages = totalPages;
        //    this.Page = page;
        //}
    }
    public delegate void base_DCFilePagePrintingEventHandler(base_DCFilePagePrintingEventArgs e);
    [Guid("99999999-DDD7-1111-AF5B-F78AF9CD7F89")]
    [ComVisible(true)]
    public class base_ScanPageAcquiredEventArgs
    {
        public string ImagePath { get; set; }

        public base_ScanPageAcquiredEventArgs()
        {
            this.ImagePath = "";
        }
        public base_ScanPageAcquiredEventArgs(string imagePath)
        {
            this.ImagePath = imagePath;
        }
    }
    public delegate void base_ScanPageAcquiredEventHandler(base_ScanPageAcquiredEventArgs e);
    #endregion

    [Guid("99999999-DDD8-1111-AF5B-F78AF9CD7F89")]
    [ComVisible(true)]
    public class FolderSelectedArgs
    {
        public FolderSelectedArgs()
        {
        }

        public FolderSelectedArgs(string folderPath)
        {
            SelectedFolderPath = folderPath;
        }
        public string SelectedFolderPath { get; set; }
    }
    public delegate void FolderSelectedEventHandler(FolderSelectedArgs e);
    [Guid("99999999-DDD9-1111-AF5B-F78AF9CD7F89")]
    [ComVisible(true)]
    public class SearchClickArgs
    {
        public SearchClickArgs()
        {
            SearchResult = new List<string>();
            Key = "";
        }

        public string Key { get; set; }
        public List<string> SearchResult { get; set; }
    }
    public delegate void SearchClickEventHandler(SearchClickArgs e);

}