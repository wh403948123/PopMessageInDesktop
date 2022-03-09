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

namespace popmsg
{
    public partial class ucFont : DevExpress.XtraEditors.XtraUserControl
    {
        public ucFont()
        {
            InitializeComponent();

            if (DesignMode)
            {
                return;
            }

            this.fontEdit1.SelectedIndexChanged += new System.EventHandler(this.fontEdit1_SelectedIndexChanged);
            this.fontSize.EditValueChanged += new System.EventHandler(this.fontSize_EditValueChanged);
            this.cbI.CheckedChanged += new System.EventHandler(this.cbI_CheckedChanged);
            this.cbS.CheckedChanged += new System.EventHandler(this.cbS_CheckedChanged);
            this.cbU.CheckedChanged += new System.EventHandler(this.cbU_CheckedChanged);
            this.cbB.CheckedChanged += new System.EventHandler(this.cbB_CheckedChanged);
            this.spPen.EditValueChanged += new System.EventHandler(this.spPen_EditValueChanged);
            this.fontEdit1.Properties.EditValueChanged += new System.EventHandler(this.fontEdit1_Properties_EditValueChanged);
            this.FontColor.EditValueChanged += new System.EventHandler(this.FontColor_EditValueChanged);
            this.FontTMD.EditValueChanged += new System.EventHandler(this.FontTMD_EditValueChanged);
            this.frameColor.EditValueChanged += new System.EventHandler(this.frameColor_EditValueChanged);
            this.FrameTMD.EditValueChanged += new System.EventHandler(this.FrameTMD_EditValueChanged);

        }

        public void SetPPStyle(PPStyle pps)
        {
            this.Tag = pps;
            this.fontEdit1.EditValue = pps.FontName;
            this.fontSize.Text = pps.FontSize.ToString();
            this.cbB.Checked = pps.Bold;
            this.cbI.Checked = pps.Italic;
            this.cbS.Checked = pps.Strikeout;
            this.cbU.Checked = pps.Underline;

            this.spPen.Value = pps.PenW;
            this.FontTMD.Value = pps.FontAlpha;
            this.FontColor.Color = ColorTranslator.FromHtml(pps.FontColor);
            this.FrameTMD.Value = pps.FrameAlpha;
            this.frameColor.Color = ColorTranslator.FromHtml(pps.FrameColor);
        }
        public PPStyle GetPPStyle()
        {
            if (this.Tag == null)
            {
                this.Tag = PPStyle.CreateDefault();
            }
            PPStyle pps = this.Tag as PPStyle;

            pps.FontName = this.fontEdit1.Text;
            pps.FontSize = Convert.ToInt32(this.fontSize.EditValue);
            pps.Bold = this.cbB.Checked;
            pps.Italic = this.cbI.Checked;
            pps.Strikeout = this.cbS.Checked;
            pps.Underline = this.cbU.Checked;

            pps.PenW = Convert.ToInt32(this.spPen.Value);
            pps.FontAlpha = Convert.ToInt32(this.FontTMD.Value);
            pps.FontColor = ColorTranslator.ToHtml(this.FontColor.Color);
            pps.FrameAlpha = Convert.ToInt32(this.FrameTMD.Value);
            pps.FrameColor = ColorTranslator.ToHtml(this.frameColor.Color);


            return pps;


        }

        public event CBProPtyChange ProPtyChangeEvent;
        private void OnProPtyChangeEvent(object sender)
        {
            ProPtyChangeEvent?.Invoke(sender);
        }
        private void OnProPtyChangeEvent()
        {
            OnProPtyChangeEvent(this);
        }

        private void fontEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnProPtyChangeEvent();
        }

        private void fontSize_EditValueChanged(object sender, EventArgs e)
        {
            OnProPtyChangeEvent();
        }

        private void fontEdit1_Properties_EditValueChanged(object sender, EventArgs e)
        {
            OnProPtyChangeEvent();
        }

        private void cbB_CheckedChanged(object sender, EventArgs e)
        {
            OnProPtyChangeEvent();
        }

        private void cbI_CheckedChanged(object sender, EventArgs e)
        {
            OnProPtyChangeEvent();
        }

        private void cbS_CheckedChanged(object sender, EventArgs e)
        {
            OnProPtyChangeEvent();
        }

        private void cbU_CheckedChanged(object sender, EventArgs e)
        {
            OnProPtyChangeEvent();
        }

        private void spPen_EditValueChanged(object sender, EventArgs e)
        {
            OnProPtyChangeEvent();
        }

        private void FontTMD_EditValueChanged(object sender, EventArgs e)
        {
            OnProPtyChangeEvent();
        }

        private void FontColor_EditValueChanged(object sender, EventArgs e)
        {
            OnProPtyChangeEvent();
        }

        private void FrameTMD_EditValueChanged(object sender, EventArgs e)
        {
            OnProPtyChangeEvent();
        }

        private void frameColor_EditValueChanged(object sender, EventArgs e)
        {
            OnProPtyChangeEvent();
        }
    }


    public delegate void CBProPtyChange(object sender);
}
