using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LogTool
{
    public partial class ListViewEx_Log : ListView
    {
        Queue<LogStruct> _unShownLogQueue = new Queue<LogStruct>();

        public Control BindingControl;

        public ListViewEx_Log()
        {
            InitializeComponent();
            this.Columns[0].Text = "时间";
            this.Columns[1].Text = "信息";

            // this.Font =new System.Drawing.Font("宋体", 15F);
        }

        public ListViewEx_Log(IContainer container) : this()
        {
            container.Add(this);
        }

        public void AppendLog(LogStruct log)
        {
            _unShownLogQueue.Enqueue(log);
            return;
        }

        private void listView_Log_Resize(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (IsHandleCreated && _unShownLogQueue.Count > 0)
            {
                if (this.Items.Count > 1000)
                {
                    this.Items.Clear();
                }
                //this.Invalidate();
                while (_unShownLogQueue.Count > 0)
                {
                    var log = _unShownLogQueue.Dequeue();
                    if (log.line == null)
                    {
                        return;
                    }
                    //string[] logs = log.log.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                    string[] logs = new string[] { log.line };
                    int i = 0;
                    foreach (var item in logs)
                    {
                        ListViewItem listViewItem = new ListViewItem();
                        if (i == 0)
                        {
                            listViewItem.Text = log.dt;
                        }
                        listViewItem.SubItems.Add(item);
                        switch (log.lvl)
                        {
                            case LogLvl.debug:
                                listViewItem.ForeColor = Color.Green;
                                break;
                            case LogLvl.info:
                                listViewItem.BackColor = Color.Yellow;

                                listViewItem.ForeColor = Color.Black;
                                break;
                            case LogLvl.error:
                                listViewItem.BackColor = Color.Red;
                                listViewItem.ForeColor = Color.Black;
                                break;
                            default:
                                break;
                        }
                        Items.Add(listViewItem);
                        i++;
                    }
                    if (Items.Count > 0)
                    {
                        EnsureVisible(Items.Count - 1);
                    }
                }
            }
        }

        public void Clean()
        {
            Items.Clear();
        }

        private void 清除_Click(object sender, EventArgs e)
        {
            Clean();
        }

        private void 弹出日志_Click(object sender, EventArgs e)
        {
            if (this.Parent.Name == "formCustomDialog_ListViewEx_Log")
            {
                //避免二次弹窗
                return;
            }
            FormCustom form = new FormCustom(this, "调试日志");
            form.Name = "formCustomDialog_ListViewEx_Log";
            form.Show();
            form.CustomFormClosed += Form_CustomFormClosed;
        }

        private void Form_CustomFormClosed(object sender, EventArgs e)
        {
            try
            {
                LogMgr.Instance.Init();

                if (BindingControl == null)

                {
                    BindingControl = this.Parent;
                }
                BindingControl.Controls.Add(this);
            }
            catch (Exception exception)
            {
                throw new Exception("未设置日志绑定控件！");
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void 复制选中项_Click(object sender, EventArgs e)
        {
            SelectedListViewItemCollection selectedItems = this.SelectedItems;

            foreach (ListViewItem item in selectedItems)
            {
                int index = item.Index;

                string info = this.Items[index].SubItems[1].Text;
                string time = item.Text;
                Clipboard.SetText(time + ":" + info);
            }
        }
    }
}
