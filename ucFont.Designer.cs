namespace popmsg
{
    partial class ucFont
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.spPen = new DevExpress.XtraEditors.SpinEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.FrameTMD = new DevExpress.XtraEditors.SpinEdit();
            this.frameColor = new DevExpress.XtraEditors.ColorPickEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.FontTMD = new DevExpress.XtraEditors.SpinEdit();
            this.FontColor = new DevExpress.XtraEditors.ColorPickEdit();
            this.cbI = new DevExpress.XtraEditors.CheckButton();
            this.cbS = new DevExpress.XtraEditors.CheckButton();
            this.cbU = new DevExpress.XtraEditors.CheckButton();
            this.cbB = new DevExpress.XtraEditors.CheckButton();
            this.fontEdit1 = new DevExpress.XtraEditors.FontEdit();
            this.fontSize = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spPen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FrameTMD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frameColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FontTMD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FontColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontSize.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl4
            // 
            this.groupControl4.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.groupControl4.AppearanceCaption.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.groupControl4.AppearanceCaption.Options.UseFont = true;
            this.groupControl4.AppearanceCaption.Options.UseTextOptions = true;
            this.groupControl4.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.groupControl4.AppearanceCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.groupControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.groupControl4.Controls.Add(this.labelControl1);
            this.groupControl4.Controls.Add(this.spPen);
            this.groupControl4.Controls.Add(this.groupControl2);
            this.groupControl4.Controls.Add(this.groupControl1);
            this.groupControl4.Controls.Add(this.cbI);
            this.groupControl4.Controls.Add(this.cbS);
            this.groupControl4.Controls.Add(this.cbU);
            this.groupControl4.Controls.Add(this.cbB);
            this.groupControl4.Controls.Add(this.fontEdit1);
            this.groupControl4.Controls.Add(this.fontSize);
            this.groupControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl4.Location = new System.Drawing.Point(0, 0);
            this.groupControl4.Margin = new System.Windows.Forms.Padding(4);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(331, 245);
            this.groupControl4.TabIndex = 6;
            this.groupControl4.Text = "字体信息";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(195, 70);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(64, 21);
            this.labelControl1.TabIndex = 26;
            this.labelControl1.Text = "边框画笔";
            // 
            // spPen
            // 
            this.spPen.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spPen.Location = new System.Drawing.Point(265, 67);
            this.spPen.Name = "spPen";
            this.spPen.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.spPen.Properties.Appearance.Options.UseFont = true;
            this.spPen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spPen.Properties.IsFloatValue = false;
            this.spPen.Properties.Mask.EditMask = "N00";
            this.spPen.Properties.MaxValue = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.spPen.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spPen.Size = new System.Drawing.Size(61, 28);
            this.spPen.TabIndex = 25;
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.FrameTMD);
            this.groupControl2.Controls.Add(this.frameColor);
            this.groupControl2.Location = new System.Drawing.Point(0, 172);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(331, 68);
            this.groupControl2.TabIndex = 24;
            this.groupControl2.Text = "边框透明度与颜色";
            // 
            // FrameTMD
            // 
            this.FrameTMD.EditValue = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.FrameTMD.Location = new System.Drawing.Point(5, 32);
            this.FrameTMD.Name = "FrameTMD";
            this.FrameTMD.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.FrameTMD.Properties.Appearance.Options.UseFont = true;
            this.FrameTMD.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FrameTMD.Properties.IsFloatValue = false;
            this.FrameTMD.Properties.Mask.EditMask = "N00";
            this.FrameTMD.Properties.MaxValue = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.FrameTMD.Size = new System.Drawing.Size(119, 28);
            this.FrameTMD.TabIndex = 16;
            // 
            // frameColor
            // 
            this.frameColor.EditValue = System.Drawing.Color.Red;
            this.frameColor.Location = new System.Drawing.Point(131, 33);
            this.frameColor.Margin = new System.Windows.Forms.Padding(4);
            this.frameColor.Name = "frameColor";
            this.frameColor.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.frameColor.Properties.Appearance.Options.UseFont = true;
            this.frameColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.frameColor.Size = new System.Drawing.Size(186, 28);
            this.frameColor.TabIndex = 7;
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.FontTMD);
            this.groupControl1.Controls.Add(this.FontColor);
            this.groupControl1.Location = new System.Drawing.Point(0, 103);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(331, 68);
            this.groupControl1.TabIndex = 23;
            this.groupControl1.Text = "字体透明度与颜色";
            // 
            // FontTMD
            // 
            this.FontTMD.EditValue = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.FontTMD.Location = new System.Drawing.Point(5, 32);
            this.FontTMD.Name = "FontTMD";
            this.FontTMD.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.FontTMD.Properties.Appearance.Options.UseFont = true;
            this.FontTMD.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FontTMD.Properties.IsFloatValue = false;
            this.FontTMD.Properties.Mask.EditMask = "N00";
            this.FontTMD.Properties.MaxValue = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.FontTMD.Size = new System.Drawing.Size(119, 28);
            this.FontTMD.TabIndex = 16;
            // 
            // FontColor
            // 
            this.FontColor.EditValue = System.Drawing.Color.Green;
            this.FontColor.Location = new System.Drawing.Point(131, 32);
            this.FontColor.Margin = new System.Windows.Forms.Padding(4);
            this.FontColor.Name = "FontColor";
            this.FontColor.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.FontColor.Properties.Appearance.Options.UseFont = true;
            this.FontColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FontColor.Properties.ColorDialogOptions.ShowMakeWebSafeButton = false;
            this.FontColor.Size = new System.Drawing.Size(186, 28);
            this.FontColor.TabIndex = 7;
            // 
            // cbI
            // 
            this.cbI.AllowAllUnchecked = true;
            this.cbI.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.cbI.Image = global::popmsg.Properties.Resources.Italic_16x16;
            this.cbI.Location = new System.Drawing.Point(33, 68);
            this.cbI.Name = "cbI";
            this.cbI.Size = new System.Drawing.Size(22, 29);
            this.cbI.TabIndex = 15;
            // 
            // cbS
            // 
            this.cbS.AllowAllUnchecked = true;
            this.cbS.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.cbS.Image = global::popmsg.Properties.Resources.Strikeout_16x16;
            this.cbS.Location = new System.Drawing.Point(61, 68);
            this.cbS.Name = "cbS";
            this.cbS.Size = new System.Drawing.Size(22, 29);
            this.cbS.TabIndex = 14;
            // 
            // cbU
            // 
            this.cbU.AllowAllUnchecked = true;
            this.cbU.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.cbU.Image = global::popmsg.Properties.Resources.UnderlineDouble_16x16;
            this.cbU.Location = new System.Drawing.Point(89, 68);
            this.cbU.Name = "cbU";
            this.cbU.Size = new System.Drawing.Size(22, 29);
            this.cbU.TabIndex = 13;
            // 
            // cbB
            // 
            this.cbB.AllowAllUnchecked = true;
            this.cbB.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.cbB.Image = global::popmsg.Properties.Resources.Bold_16x16;
            this.cbB.Location = new System.Drawing.Point(5, 68);
            this.cbB.Name = "cbB";
            this.cbB.Size = new System.Drawing.Size(22, 29);
            this.cbB.TabIndex = 12;
            // 
            // fontEdit1
            // 
            this.fontEdit1.EditValue = "微软雅黑";
            this.fontEdit1.Location = new System.Drawing.Point(4, 33);
            this.fontEdit1.Margin = new System.Windows.Forms.Padding(4);
            this.fontEdit1.Name = "fontEdit1";
            this.fontEdit1.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.fontEdit1.Properties.Appearance.Options.UseFont = true;
            this.fontEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fontEdit1.Size = new System.Drawing.Size(260, 28);
            this.fontEdit1.TabIndex = 8;
            // 
            // fontSize
            // 
            this.fontSize.EditValue = "32";
            this.fontSize.Location = new System.Drawing.Point(265, 33);
            this.fontSize.Margin = new System.Windows.Forms.Padding(4);
            this.fontSize.Name = "fontSize";
            this.fontSize.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.fontSize.Properties.Appearance.Options.UseFont = true;
            this.fontSize.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fontSize.Properties.Items.AddRange(new object[] {
            "6",
            "8",
            "9",
            "11",
            "12",
            "14",
            "16",
            "18",
            "30",
            "32",
            "36",
            "48",
            "72"});
            this.fontSize.Size = new System.Drawing.Size(63, 28);
            this.fontSize.TabIndex = 7;
            // 
            // ucFont
            // 
            this.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl4);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucFont";
            this.Size = new System.Drawing.Size(331, 245);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            this.groupControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spPen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FrameTMD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frameColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FontTMD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FontColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontSize.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraEditors.FontEdit fontEdit1;
        private DevExpress.XtraEditors.ComboBoxEdit fontSize;
        private DevExpress.XtraEditors.ColorPickEdit FontColor;
        private DevExpress.XtraEditors.CheckButton cbB;
        private DevExpress.XtraEditors.CheckButton cbI;
        private DevExpress.XtraEditors.CheckButton cbS;
        private DevExpress.XtraEditors.CheckButton cbU;
        private DevExpress.XtraEditors.SpinEdit FontTMD;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SpinEdit FrameTMD;
        private DevExpress.XtraEditors.ColorPickEdit frameColor;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SpinEdit spPen;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}
