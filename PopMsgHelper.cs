using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace popmsg
{
    public class PopMsgHelper
    { 
        public static List<PopMsgItem> DB { get; set; }
        public static DataTable db_forview
        {
            get
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("文本", typeof(string));
                if (DB == null || DB.Count == 0)
                {
                    return dt;
                }
                for (int i = 0; i < DB.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = DB[i].ShowStyle.ShowTitle;
                    dt.Rows.Add(dr);
                }
                return dt;
            }
        }

        private static List<PopMsgItem> resetDB(PlayOrder order)
        {
            if (DB == null || DB.Count <= 1)
            {
                return DB;
            }
            int count = DB.Count;


            List<PopMsgItem> tmpList = new List<PopMsgItem>();
            for (int i = 0; i < count; i++)
            {
                tmpList.Add(DB[i]);
            }

            if (order == PlayOrder.SX)
            {
                return tmpList;
            }
            int[] ns = new int[count];
            for (int i = 0; i < count; i++)
            {
                ns[i] = i;
            }
            Random r = new Random();
            for (int i = 0; i < count; i++)
            {
                int t = r.Next(count - i) + i;
                int tmp = ns[i];
                ns[i] = ns[t];
                ns[t] = tmp;
            }
            tmpList.Clear();
            for (int i = 0; i < count; i++)
            {
                tmpList.Add(DB[ns[i]]);
            }
            return tmpList;
        }
        public static void PlayAll(PlayOrder order)
        {
            if (DB == null || DB.Count == 0)
            {
                return;
            }
            List<PopMsgItem> tmpList = resetDB(order);

            for (int i = 0; i < tmpList.Count; i++)
            {
                tmpList[i].Play();
            }
        }

        public static string FileName { get { return Path.Combine(FileHelper.AssemblyFolder, "popmsgdb.ini"); } }

        public static List<PopMsgItem> LoadObj()
        {
            if (!File.Exists(FileName))
            {
                return new List<PopMsgItem>();
            }
            return XmlHelper.FromFile<List<PopMsgItem>>(FileName);
        }
        public static void SaveObj(List<PopMsgItem> items)
        {
            if (File.Exists(FileName))
            {
                File.Delete(FileName);
            }
            XmlHelper.ToFile(items, FileName);
        }

    }

    public class PopMsgItem
    {
        public PopMsgItem()
        {
        } 
        public ShowStyle ShowStyle { get; set; }
        public PlayOrder PlayOrder { get; set; }
            
        /// <summary>
        /// 播放时，与下一条的间隔时间 单位：秒
        /// </summary>
        public int IntervalTime { get; set; }

        public void Play()
        {
            frmpop3.ShowMe(this.ShowStyle);
            Application.DoEvents();
            Thread.Sleep(this.IntervalTime * 1000);
        }
    }
}
