using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace popmsg
{
    public partial class frmpop3 : Form
    {
        public frmpop3()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.StandardClick, true);
            this.SetStyle(ControlStyles.UserMouse, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.UpdateStyles();
 


            this.Paint += Frmpop3_Paint;

            this.BackColor = Color.Pink;
            this.TransparencyKey = this.BackColor;
            this.Opacity = 1.0d;


            uint style = GetWindowLong(this.Handle, GWL_EXSTYLE);
            SetWindowLong(this.Handle, GWL_EXSTYLE, style | WS_EX_TRANSPARENT | WS_EX_LAYERED);

        }
        #region 窗体标事件穿透
        private const uint WS_EX_LAYERED = 0x80000;
        private const int WS_EX_TRANSPARENT = 0x20;
        private const int GWL_STYLE = (-16);
        private const int GWL_EXSTYLE = (-20);
        [DllImport("user32", EntryPoint = "SetWindowLong")]
        private static extern uint SetWindowLong(IntPtr hwnd, int nIndex, uint dwNewLong);
        [DllImport("user32", EntryPoint = "GetWindowLong")]
        private static extern uint GetWindowLong(IntPtr hwnd, int nIndex);

        #endregion


        private void Frmpop3_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                this.ss.DrawImage(e.Graphics, e.ClipRectangle);
            }
            catch { }
        }

        private ShowStyle ss = null;
        private Rectangle RScreen = Screen.PrimaryScreen.Bounds;


        public static int RadomX(int min, int max)
        {
            System.Random r = new Random();
            return r.Next(min, max);
        }
        public static int RadomX(int max)
        {
            System.Random r = new Random();
            return r.Next(0, max);
        }



        public void SetStyle(ShowStyle style)
        {
            this.ss = style;
            this.ss.ResetSpeed();
            this.timer1.Interval = style.Interval;
            int h = RScreen.Height / 3;
            switch (style.Localtion)
            {
                case PLocaltion.Top:
                    this.Top = RadomX(0, h);
                    break;
                case PLocaltion.Middle:
                    this.Top = RadomX(h, h * 2);
                    break;
                case PLocaltion.Bottom:
                    this.Top = RadomX(h * 2, h * 3);
                    break;
                case PLocaltion.FullScreen:
                    this.Top = RadomX(0, h * 3);
                    break;
            }
            switch (style.Order)
            {
                case MvOrder.R2L:
                    this.Left = RScreen.Width + 1;
                    break;
                case MvOrder.L2R:
                    this.Left = 0 - RScreen.Width;
                    break;
            }
            using (Graphics g = Graphics.FromHwnd(this.Handle))
            {
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (Brush b = ss.PPStyle.GetFontBrush())
                {
                    using (Font font = ss.PPStyle.GetFont())
                    {
                        using (StringFormat sf = new StringFormat(StringFormatFlags.LineLimit))
                        {
                            SizeF sz = g.MeasureString(ss.Text, font, new PointF(5, 5), StringFormat.GenericTypographic);
                            if (sz.Width > this.Width)
                            {
                                this.Width = (int)(sz.Width + 2);
                            }
                            if (sz.Height > this.Height)
                            {
                                this.Height = (int)(sz.Height + 2);
                            }
                        }
                    }
                }
            }
            this.timer1.Start();
        }
        public bool canClose()
        {
            switch (ss.Order)
            {
                case MvOrder.L2R:
                    return this.Left > RScreen.Width;
                case MvOrder.R2L:
                    return this.Left + this.Width < 0;
            }
            return false;
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (canClose())
                {
                    timer1.Stop();
                    this.Close();
                    return;
                }
                switch (ss.Order)
                {
                    case MvOrder.L2R: this.Left += this.ss.Interval_pixel; break;
                    case MvOrder.R2L: this.Left -= this.ss.Interval_pixel; break;
                }
                this.Invalidate();
            }
            catch { }
        }
        public static void ShowMe(ShowStyle style)
        {
            frmpop3 frm = new frmpop3();
            frm.SetStyle(style);
            frm.Show();
        }
    }


}
