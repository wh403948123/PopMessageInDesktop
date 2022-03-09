namespace PopMessage
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.seCS = new DevExpress.XtraEditors.SpinEdit();
            this.btnXHuan = new DevExpress.XtraEditors.SimpleButton();
            this.btnPlay = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.seInterval = new DevExpress.XtraEditors.SpinEdit();
            this.rbOrder = new DevExpress.XtraEditors.RadioGroup();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnLoad = new DevExpress.XtraEditors.SimpleButton();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gcMain = new DevExpress.XtraGrid.GridControl();
            this.vwMain = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveItem = new DevExpress.XtraEditors.SimpleButton();
            this.spinEdit2 = new DevExpress.XtraEditors.SpinEdit();
            this.radioGroup2 = new DevExpress.XtraEditors.RadioGroup();
            this.btnNew = new DevExpress.XtraEditors.SimpleButton();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seCS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seInterval.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbOrder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vwMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.groupControl2);
            this.panelControl1.Controls.Add(this.btnXHuan);
            this.panelControl1.Controls.Add(this.btnPlay);
            this.panelControl1.Controls.Add(this.groupControl1);
            this.panelControl1.Controls.Add(this.rbOrder);
            this.panelControl1.Controls.Add(this.btnSave);
            this.panelControl1.Controls.Add(this.btnLoad);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(979, 61);
            this.panelControl1.TabIndex = 0;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.seCS);
            this.groupControl2.Location = new System.Drawing.Point(673, 6);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(92, 50);
            this.groupControl2.TabIndex = 4;
            this.groupControl2.Text = "次数";
            // 
            // seCS
            // 
            this.seCS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seCS.EditValue = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.seCS.Location = new System.Drawing.Point(2, 22);
            this.seCS.Name = "seCS";
            this.seCS.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.seCS.Properties.Appearance.Options.UseFont = true;
            this.seCS.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seCS.Properties.IsFloatValue = false;
            this.seCS.Properties.Mask.EditMask = "N00";
            this.seCS.Properties.MaxValue = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.seCS.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.seCS.Size = new System.Drawing.Size(88, 28);
            this.seCS.TabIndex = 3;
            // 
            // btnXHuan
            // 
            this.btnXHuan.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXHuan.Appearance.Options.UseFont = true;
            this.btnXHuan.Image = global::PopMessage.Properties.Resources.Media_32x32;
            this.btnXHuan.Location = new System.Drawing.Point(565, 6);
            this.btnXHuan.Margin = new System.Windows.Forms.Padding(0);
            this.btnXHuan.Name = "btnXHuan";
            this.btnXHuan.Size = new System.Drawing.Size(105, 50);
            this.btnXHuan.TabIndex = 5;
            this.btnXHuan.Text = "循环播放";
            this.btnXHuan.Click += new System.EventHandler(this.btnXHuan_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlay.Appearance.Options.UseFont = true;
            this.btnPlay.Image = global::PopMessage.Properties.Resources.Media_32x32;
            this.btnPlay.Location = new System.Drawing.Point(460, 6);
            this.btnPlay.Margin = new System.Windows.Forms.Padding(0);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(105, 50);
            this.btnPlay.TabIndex = 4;
            this.btnPlay.Text = "单次播放";
            this.btnPlay.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.seInterval);
            this.groupControl1.Location = new System.Drawing.Point(367, 6);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(92, 50);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "时间(秒)";
            // 
            // seInterval
            // 
            this.seInterval.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seInterval.EditValue = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.seInterval.Location = new System.Drawing.Point(2, 22);
            this.seInterval.Name = "seInterval";
            this.seInterval.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.seInterval.Properties.Appearance.Options.UseFont = true;
            this.seInterval.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seInterval.Properties.IsFloatValue = false;
            this.seInterval.Properties.Mask.EditMask = "N00";
            this.seInterval.Properties.MaxValue = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.seInterval.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.seInterval.Size = new System.Drawing.Size(88, 28);
            this.seInterval.TabIndex = 3;
            // 
            // rbOrder
            // 
            this.rbOrder.EditValue = 1;
            this.rbOrder.Location = new System.Drawing.Point(183, 10);
            this.rbOrder.Name = "rbOrder";
            this.rbOrder.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbOrder.Properties.Appearance.Options.UseFont = true;
            this.rbOrder.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "顺序播放"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "随机播放")});
            this.rbOrder.Size = new System.Drawing.Size(181, 42);
            this.rbOrder.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Image = global::PopMessage.Properties.Resources.SaveAll_32x32;
            this.btnSave.Location = new System.Drawing.Point(81, 6);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 50);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnLoad.Appearance.Options.UseFont = true;
            this.btnLoad.Image = global::PopMessage.Properties.Resources.Refresh_32x32;
            this.btnLoad.Location = new System.Drawing.Point(5, 6);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(73, 50);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "载入";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.splitContainerControl1.Appearance.Options.UseFont = true;
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 61);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gcMain);
            this.splitContainerControl1.Panel1.Controls.Add(this.panelControl2);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(979, 495);
            this.splitContainerControl1.SplitterPosition = 178;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gcMain
            // 
            this.gcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcMain.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.gcMain.Location = new System.Drawing.Point(0, 44);
            this.gcMain.MainView = this.vwMain;
            this.gcMain.Name = "gcMain";
            this.gcMain.Size = new System.Drawing.Size(178, 451);
            this.gcMain.TabIndex = 0;
            this.gcMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.vwMain});
            // 
            // vwMain
            // 
            this.vwMain.ActiveFilterEnabled = false;
            this.vwMain.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.vwMain.Appearance.HeaderPanel.Options.UseFont = true;
            this.vwMain.Appearance.Preview.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.vwMain.Appearance.Preview.Options.UseFont = true;
            this.vwMain.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.vwMain.Appearance.Row.Options.UseFont = true;
            this.vwMain.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colText});
            this.vwMain.GridControl = this.gcMain;
            this.vwMain.Name = "vwMain";
            this.vwMain.OptionsBehavior.Editable = false;
            this.vwMain.OptionsView.ShowGroupPanel = false;
            this.vwMain.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.vwMain_RowCellClick);
            // 
            // colText
            // 
            this.colText.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.colText.AppearanceCell.Options.UseFont = true;
            this.colText.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.colText.AppearanceHeader.Options.UseFont = true;
            this.colText.Caption = "文本";
            this.colText.Name = "colText";
            this.colText.OptionsColumn.ReadOnly = true;
            this.colText.Visible = true;
            this.colText.VisibleIndex = 0;
            this.colText.Width = 104;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.panelControl3);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(178, 44);
            this.panelControl2.TabIndex = 0;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.btnDelete);
            this.panelControl3.Controls.Add(this.btnSaveItem);
            this.panelControl3.Controls.Add(this.spinEdit2);
            this.panelControl3.Controls.Add(this.radioGroup2);
            this.panelControl3.Controls.Add(this.btnNew);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(2, 2);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(174, 40);
            this.panelControl3.TabIndex = 1;
            // 
            // btnDelete
            // 
            this.btnDelete.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Appearance.Options.UseFont = true;
            this.btnDelete.Image = global::PopMessage.Properties.Resources.Cancel_32x32;
            this.btnDelete.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnDelete.Location = new System.Drawing.Point(69, 1);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(32, 36);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.ToolTip = "删除";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSaveItem
            // 
            this.btnSaveItem.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnSaveItem.Appearance.Options.UseFont = true;
            this.btnSaveItem.Image = global::PopMessage.Properties.Resources.Save_32x32;
            this.btnSaveItem.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnSaveItem.Location = new System.Drawing.Point(37, 1);
            this.btnSaveItem.Name = "btnSaveItem";
            this.btnSaveItem.Size = new System.Drawing.Size(32, 36);
            this.btnSaveItem.TabIndex = 2;
            this.btnSaveItem.ToolTip = "保存修改";
            this.btnSaveItem.Click += new System.EventHandler(this.btnSaveItem_click);
            // 
            // spinEdit2
            // 
            this.spinEdit2.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit2.Location = new System.Drawing.Point(687, 20);
            this.spinEdit2.Name = "spinEdit2";
            this.spinEdit2.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.spinEdit2.Properties.Appearance.Options.UseFont = true;
            this.spinEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEdit2.Size = new System.Drawing.Size(100, 28);
            this.spinEdit2.TabIndex = 3;
            // 
            // radioGroup2
            // 
            this.radioGroup2.EditValue = 1;
            this.radioGroup2.Location = new System.Drawing.Point(500, 12);
            this.radioGroup2.Name = "radioGroup2";
            this.radioGroup2.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioGroup2.Properties.Appearance.Options.UseFont = true;
            this.radioGroup2.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "顺序播放"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "随机播放")});
            this.radioGroup2.Size = new System.Drawing.Size(181, 42);
            this.radioGroup2.TabIndex = 2;
            // 
            // btnNew
            // 
            this.btnNew.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnNew.Appearance.Options.UseFont = true;
            this.btnNew.Image = global::PopMessage.Properties.Resources.AddItem_32x32;
            this.btnNew.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnNew.Location = new System.Drawing.Point(5, 1);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(32, 36);
            this.btnNew.TabIndex = 0;
            this.btnNew.ToolTip = "新增";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Blue";
            // 
            // Form1
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 556);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.panelControl1);
            this.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "弹幕小工具";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.seCS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.seInterval.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbOrder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vwMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup2.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.SimpleButton btnLoad;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraGrid.GridControl gcMain;
        private DevExpress.XtraGrid.Views.Grid.GridView vwMain;
        private DevExpress.XtraGrid.Columns.GridColumn colText;
        private DevExpress.XtraEditors.SpinEdit seInterval;
        private DevExpress.XtraEditors.RadioGroup rbOrder;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.SpinEdit spinEdit2;
        private DevExpress.XtraEditors.RadioGroup radioGroup2;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnNew;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnPlay;
        private DevExpress.XtraEditors.SimpleButton btnXHuan;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SpinEdit seCS;
        private DevExpress.XtraEditors.SimpleButton btnSaveItem;
    }
}

