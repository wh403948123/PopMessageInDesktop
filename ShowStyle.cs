using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace popmsg
{
    public class ShowStyle
    {
        public ShowStyle()
        {
        }
        public SpeedLevel Speed { get; set; } = SpeedLevel.L5;

        public void ResetSpeed()
        {
            Interval = 200;
            Interval_pixel = 10;
            switch (Speed)
            {
                case SpeedLevel.L1:
                    Interval = 200;
                    Interval_pixel = 1;
                    break;
                case SpeedLevel.L2:
                    Interval = 100;
                    Interval_pixel = 1;
                    break;
                case SpeedLevel.L3:
                    Interval = 80;
                    Interval_pixel = 2;
                    break;
                case SpeedLevel.L4:
                    Interval = 50;
                    Interval_pixel = 2;
                    break;
                case SpeedLevel.L5:
                    Interval = 20;
                    Interval_pixel = 1;
                    break;
                case SpeedLevel.L6:
                    Interval = 20;
                    Interval_pixel = 2;
                    break;
                case SpeedLevel.L7:
                    Interval = 10;
                    Interval_pixel = 3;
                    break;
                case SpeedLevel.L8:
                    Interval = 10;
                    Interval_pixel = 5;
                    break;
                case SpeedLevel.L9:
                    Interval = 5;
                    Interval_pixel = 8;
                    break;
                case SpeedLevel.L10:
                    Interval = 5;
                    Interval_pixel = 15;
                    break;
            }
        }

        /// <summary>
        /// 单位：毫秒
        /// </summary>
        public int Interval { get; set; } = 200;


        /// <summary>
        /// 保存文件时使用
        /// </summary>
        public long ID { get; set; } = 0;

        /// <summary>
        /// 每次移动像素
        /// </summary>
        public int Interval_pixel { get; set; } = 1;
        public PLocaltion Localtion { get; set; } = PLocaltion.Top;
        public MvOrder Order { get; set; } = MvOrder.L2R;
        public Image Header
        {
            get
            {

                if (string.IsNullOrEmpty(ImageContext))
                {
                    return null;
                }
                return ReadFromFileContext(ImageContext);
            }
        }

        public string ImageContext { get; set; }


        public string Text { get; set; }
        public PPStyle PPStyle { get; set; }




        public static string ReadFromFile_FileContext(string imgFile)
        {
            string base64 = Common.ConvertToBase64(imgFile);
            base64 = JsonHelper.Encode(base64);
            return base64;

        }
        public static Image ReadFromFileContext(string fileContext)
        {
            string base64 = JsonHelper.Decode<string>(fileContext);
            return Common.ConvertFromBase64(base64);
        }

        public void DrawImage(Graphics g, Rectangle r)
        {
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rOldImage = Rectangle.Empty;
            Rectangle rDestImage = Rectangle.Empty;
            if (this.Header != null)
            {
                rOldImage = new Rectangle(0, 0, this.Header.Width, this.Header.Height);
                int w = (int)Math.Floor(1m * r.Height * this.Header.Width / this.Header.Height * 1m);
                rDestImage = new Rectangle(0, 0, w + 1, r.Height);
            }
            Rectangle rText = r;
            if (rDestImage != Rectangle.Empty)
            {
                rText = new Rectangle(rDestImage.Width, 0, r.Width - rDestImage.Width, r.Height);
            }
            using (Pen pen = PPStyle.GetFramePen())
            {
                pen.Width = PPStyle.PenW;
                Rectangle rFrame = new Rectangle(rText.X, rText.Y, rText.Width - 2, rText.Height - 2);
                g.DrawRectangle(pen, rFrame);
                if (this.Header != null)
                {
                    g.DrawImage(this.Header, rDestImage, rOldImage, GraphicsUnit.Pixel);
                }
                using (Brush b = PPStyle.GetFontBrush())
                {
                    using (Font font = PPStyle.GetFont())
                    {
                        using (StringFormat sf = new StringFormat(StringFormatFlags.LineLimit))
                        {
                            g.DrawString(Text, font, b, rText, sf);
                        }
                    }
                }
            }
        }
        public static ShowStyle CreateDefault()
        {
            ShowStyle ss = new ShowStyle();
            ss.ID = IDHelper.NewID();
            ss.Speed = SpeedLevel.L7;
            ss.Localtion = PLocaltion.Top;
            ss.Order = MvOrder.R2L;
            ss.ImageContext = null;
            ss.Text = "123456789A123456789B1234567890123456789C";
            ss.PPStyle = PPStyle.CreateDefault();
            return ss;
        }

        public static List<string> FontNames
        {
            get
            {
                List<string> names = new List<string>();
                foreach (var item in FontFamily.Families)
                {
                    if (item.Name.IndexOf("@") == -1)
                    {
                        names.Add(item.Name);
                    }
                }
                return names;
            }
        }

        public string ShowTitle
        {
            get
            {
                if (string.IsNullOrEmpty(this.Text))
                {
                    return IDHelper.NewID().ToString();
                }
                string title = this.Text.Substring(0, this.Text.Length > 16 ? 16 : this.Text.Length);
                return title;
            }
        }
    }

    public class PPStyle
    {
        public PPStyle()
        { }
        public int FontSize { get; set; } = 32;
        public string FontName { get; set; } = "微软雅黑";
        public bool Bold { get; set; } = false;
        public bool Italic { get; set; } = false;
        public bool Underline { get; set; } = false;
        public bool Strikeout { get; set; } = false;
        public string FrameColor { get; set; } = ColorTranslator.ToHtml(Color.Red);
        public int FrameAlpha { get; set; } = 255;

        //透明背景不需要该参数
        //public string FillColor { get; set; }
        //public int FillAlpha { get; set; }
        public string FontColor { get; set; } = ColorTranslator.ToHtml(Color.Green);
        public int FontAlpha { get; set; } = 255;
        public int PenW { get; set; } = 1;

        public static PPStyle CreateDefault()
        {
            PPStyle ss = new PPStyle();
            ss.FontName = "微软雅黑";
            ss.FontSize = 48;
            ss.FrameColor = ColorTranslator.ToHtml(Color.Red);
            ss.FrameAlpha = 255;
            ss.FontColor = ColorTranslator.ToHtml(Color.Green);
            ss.FontAlpha = 128;
            ss.PenW = 5;
            return ss;
        }

        public Pen GetFramePen()
        {
            Color baseColor = ColorTranslator.FromHtml(FrameColor);
            Color argbColor = Color.FromArgb(FrameAlpha, baseColor);
            return new Pen(argbColor);
        }
        public Brush GetFontBrush()
        {
            Color baseColor = ColorTranslator.FromHtml(FontColor);
            Color argbColor = Color.FromArgb(FontAlpha, baseColor);
            return new SolidBrush(argbColor);
        }
        public FontStyle GetFontStyle()
        {
            FontStyle fs = FontStyle.Regular;
            if (Bold)
            {
                fs ^= FontStyle.Bold;
            }
            if (Italic)
            {
                fs ^= FontStyle.Italic;
            }
            if (Underline)
            {
                fs ^= FontStyle.Underline;
            }
            if (Strikeout)
            {
                fs ^= FontStyle.Strikeout;
            }
            return fs;
        }

        public Font GetFont()
        {
            Font font = new Font(FontName, FontSize, GetFontStyle());
            return font;
        }
    }


    public enum PLocaltion : int
    {
        Top = 1,
        Middle,
        Bottom,
        FullScreen
    }
    public enum MvOrder : int
    {
        L2R = 1,
        R2L
    }

    //移动速度 1 最慢 10最快
    public enum SpeedLevel : int
    {
        L1 = 1,
        L2,
        L3,
        L4,
        L5,
        L6,
        L7,
        L8,
        L9,
        L10
    }

    /// <summary>
    /// 播放顺序
    /// </summary>
    public enum PlayOrder : int
    {
         SX=1,
         SJ =2
    }
}
