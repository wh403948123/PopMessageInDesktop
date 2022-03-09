using popmsg;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PopMessage
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
            this.Disposed += Form1_Disposed;
        }

        private void Form1_Disposed(object sender, EventArgs e)
        {
            if (ucPopTemplate != null)
            {
                ucPopTemplate.Dispose();
            }
        }


        private void ShowDefaultView()
        {
            this.gcMain.DataSource = PopMsgHelper.db_forview.DefaultView;
            this.vwMain.PopulateColumns();
        }

        public void AddRow(bool isNew=false)
        {
            PopMsgItem pmi = new PopMsgItem();
            pmi.IntervalTime = Convert.ToInt32(seInterval.Value);
            pmi.PlayOrder = (PlayOrder)Enum.Parse(typeof(PlayOrder),
                rbOrder.Properties.Items[rbOrder.SelectedIndex].Value.ToString());
            pmi.ShowStyle = ucPopTemplate.GetUI(isNew);
            if (isNew)
            {
                pmi.ShowStyle.ID = IDHelper.NewID();
            }
            var objs = from PopMsgItem ss in PopMsgHelper.DB where ss.ShowStyle.ID == pmi.ShowStyle.ID select ss;

            if (objs == null || objs.Count() == 0)
            {
                PopMsgHelper.DB.Add(pmi);
            }
            else
            {
                for (int i = 0; i < PopMsgHelper.DB.Count; i++)
                {
                    PopMsgItem tmp = PopMsgHelper.DB[i];
                    if (tmp.ShowStyle.ID == pmi.ShowStyle.ID)
                    {
                        PopMsgHelper.DB[i].IntervalTime = pmi.IntervalTime;
                        PopMsgHelper.DB[i].PlayOrder = pmi.PlayOrder;
                        PopMsgHelper.DB[i].ShowStyle = pmi.ShowStyle;
                        break;
                    }
                }
            }
        }

        private ucPopObj ucPopTemplate = null;

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Trace.Listeners.Clear();
                Trace.Listeners.Add(new FileTraceListener());

                this.Text = this.Text + " - v" + App.Ver;

                ucPopTemplate = new ucPopObj();
                this.splitContainerControl1.Panel2.Controls.Add(ucPopTemplate);
                ucPopTemplate.Dock = DockStyle.Fill;


                PopMsgHelper.DB = PopMsgHelper.LoadObj();
                ShowDefaultView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Trace.LogError(ex);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                PopMsgHelper.DB = PopMsgHelper.LoadObj();
                if (PopMsgHelper.DB.Count == 0)
                {
                    MessageBox.Show("未发现任何数据");
                }
                ShowDefaultView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Trace.LogError(ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (PopMsgHelper.DB.Count == 0)
                {
                    MessageBox.Show("未发现任何数据，无法保存");
                }
                PopMsgHelper.SaveObj(PopMsgHelper.DB);
                ShowDefaultView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Trace.LogError(ex);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                AddRow(true);
                ShowDefaultView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Trace.LogError(ex);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int[] ns =  this.vwMain.GetSelectedRows();
                if (ns.Length == 0)
                {
                    return;
                }
                for (int i = 0; i < ns.Length; i++)
                {
                    int line = ns[i];
                    if (line >= 0 && line < PopMsgHelper.DB.Count)
                    {
                        PopMsgHelper.DB.RemoveAt(line);
                    }
                }
                ShowDefaultView();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Trace.LogError(ex);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                PlayOrder PlayOrder = (PlayOrder)Enum.Parse(typeof(PlayOrder),
                rbOrder.Properties.Items[rbOrder.SelectedIndex].Value.ToString());
                PopMsgHelper.PlayAll(PlayOrder);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Trace.LogError(ex);
            }
        }

        private void btnXHuan_Click(object sender, EventArgs e)
        {
            try
            {
                PlayOrder PlayOrder = (PlayOrder)Enum.Parse(typeof(PlayOrder),
                rbOrder.Properties.Items[rbOrder.SelectedIndex].Value.ToString());

                int cs = Convert.ToInt32(this.seCS.Value);
                int intervalTime = Convert.ToInt32(seInterval.Value);
                for (int i = 0; i < cs; i++)
                {
                    PopMsgHelper.PlayAll(PlayOrder);
                    Thread.Sleep(intervalTime * 1000);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Trace.LogError(ex);
            }
        }
         

        private void vwMain_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {

            try
            {
                if (e.RowHandle < 0 || e.RowHandle > PopMsgHelper.DB.Count)
                {
                    return;
                }
                PopMsgItem pmi = PopMsgHelper.DB[e.RowHandle];
                rbOrder.SelectedIndex = (pmi.PlayOrder == PlayOrder.SX) ? 1 : 2;
                seInterval.Value = pmi.IntervalTime;
                this.ucPopTemplate.SetUI(pmi.ShowStyle);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Trace.LogError(ex);
            }
        }

        private void btnSaveItem_click(object sender, EventArgs e)
        {

            try
            {
                int[] selectrows = this.vwMain.GetSelectedRows();
                AddRow(false);
                ShowDefaultView();
                if (selectrows.Length > 0)
                {
                    int rowindex = selectrows[0];
                    if (rowindex > 0 && rowindex < this.vwMain.RowCount)
                    {
                        this.vwMain.SelectRow(rowindex);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Trace.LogError(ex);
            }
        }
    }



}
