using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;

namespace popmsg
{
    public partial class ucPopObj : DevExpress.XtraEditors.XtraUserControl
    {
        public ucPopObj()
        {
            InitializeComponent();


            if (DesignMode)
            {
                return;
            }

            this.ucFont1.ProPtyChangeEvent += UcFont1_ProPtyChangeEvent;

            this.tbLocation.EditValueChanged += new System.EventHandler(this.tbLocation_EditValueChanged);
            this.tbSpeed.EditValueChanged += new System.EventHandler(this.tbSpeed_EditValueChanged);
            this.tbOrder.EditValueChanged += new System.EventHandler(this.tbOrder_EditValueChanged);
            this.picHeader.ImageChanged += new System.EventHandler(this.picHeader_ImageChanged);
            this.picHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picHeader_MouseDown);
            this.txtTest.EditValueChanged += new System.EventHandler(this.txtTest_EditValueChanged);


            PPStyle ss = PPStyle.CreateDefault();
            this.txtTest.Font = ss.GetFont();
            this.txtTest.ForeColor = ColorTranslator.FromHtml(ss.FontColor);
        }

        private void UcFont1_ProPtyChangeEvent(object sender)
        {
            OnProPtyChangeEvent();

            PPStyle tmpFont = ucFont1.GetPPStyle();

            this.txtTest.Font = tmpFont.GetFont();
            this.txtTest.ForeColor = ColorTranslator.FromHtml(tmpFont.FontColor);
            this.txtTest.Update();

        }

        public event CBProPtyChange ProPtyChangeEvent;
        private void OnProPtyChangeEvent(object sender)
        {
            ProPtyChangeEvent?.Invoke(sender);
        }
        private void OnProPtyChangeEvent()
        {
            if (DesignMode)
            {
                return;
            }
            OnProPtyChangeEvent(this);
        }


        public void SetUI(ShowStyle ss)
        {
            this.Tag = ss;

            this.tbSpeed.Value = (int)ss.Speed;
            this.tbOrder.Value = (int)ss.Order;
            this.tbLocation.Value = (int)ss.Localtion;

            this.ucFont1.SetPPStyle(ss.PPStyle);
            this.picHeader.Image = ss.Header;
            this.txtTest.Text = ss.Text;

        }
        public ShowStyle GetUI(bool isNew= true)
        {
            ShowStyle ss = null;
            if (this.Tag == null || isNew)
            {
                ss = ShowStyle.CreateDefault();
            }
            else
            {
                ss = this.Tag as ShowStyle;
            }
            ss.Speed = (SpeedLevel)Enum.Parse(typeof(SpeedLevel), this.tbSpeed.Value.ToString());
            ss.Order = (MvOrder)Enum.Parse(typeof(MvOrder), this.tbOrder.Value.ToString());
            ss.Localtion = (PLocaltion)Enum.Parse(typeof(PLocaltion), tbLocation.Value.ToString());

            ss.PPStyle = this.ucFont1.GetPPStyle();
            if (labImageInfo.Tag != null)
            {
                ss.ImageContext = labImageInfo.Tag.ToString();
            }
            ss.Text = this.txtTest.Text;
            return ss;
        }

        private void tbSpeed_EditValueChanged(object sender, EventArgs e)
        {
            OnProPtyChangeEvent();
        }

        private void tbLocation_EditValueChanged(object sender, EventArgs e)
        {
            OnProPtyChangeEvent();
        }

        private void tbOrder_EditValueChanged(object sender, EventArgs e)
        {
            OnProPtyChangeEvent();
        }

        private void picHeader_ImageChanged(object sender, EventArgs e)
        {
            OnProPtyChangeEvent();

            if (this.picHeader.Image == null)
            {
                return;
            }
            string gs = "JPEG";
            if (this.picHeader.Tag != null)
            {
                gs = Path.GetFileNameWithoutExtension(this.picHeader.Tag as string).Replace(".", "").Trim().ToUpper();
            }
            int w = this.picHeader.Image.Width;
            int h = this.picHeader.Image.Height;
            string msg = string.Format("{0} \r\n W={1} \r\n H={2}", gs, w, h);
            this.labImageInfo.Text = msg;

        }

        private void txtTest_EditValueChanged(object sender, EventArgs e)
        {
            OnProPtyChangeEvent();
        }

        private void picHeader_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Title = "请选择本地一个图片文件";
                    ofd.Multiselect = false;
                    ofd.CheckFileExists = true;
                    ofd.Filter = "显示图标|*.jpg;*.jpeg;*.bmp*.gif;*.png";
                    if (ofd.ShowDialog(this.FindForm()) == DialogResult.OK)
                    {
                        this.picHeader.Tag = ofd.FileName;
                        this.picHeader.Image = Image.FromFile(ofd.FileName);
                        string text = ShowStyle.ReadFromFile_FileContext(ofd.FileName);
                        this.labImageInfo.Tag = text;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
