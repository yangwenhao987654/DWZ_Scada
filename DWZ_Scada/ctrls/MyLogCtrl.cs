using DWZ_Scada.ctrls.LogCtrl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DWZ_Scada.ctrls
{
    public partial class MyLogCtrl : ListView
    {
        Queue<LogStruct> _unShownLogQueue = new Queue<LogStruct>();

        public Control BindingControl;

        public MyLogCtrl()
        {
            InitializeComponent();
            /*     this.Columns[0].Text = "时间";
                 this.Columns[1].Text = "信息";*/
        }

        public void AppendLog(LogStruct log)
        {
            _unShownLogQueue.Enqueue(log);
            return;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (IsHandleCreated && _unShownLogQueue.Count > 0)
            {
                if (Items.Count > 100)
                {
                    Items.Clear();
                }
                //this.Invalidate();
                while (_unShownLogQueue.TryDequeue(out LogStruct log))
                {
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
                                listViewItem.ForeColor = Color.Black;
                                listViewItem.BackColor = Color.White;
                                break;
                            case LogLvl.alarm:
                                listViewItem.ForeColor = Color.Black;
                                listViewItem.BackColor = Color.Green;
                                break;
                            case LogLvl.info:
                                listViewItem.ForeColor = Color.Black;
                                listViewItem.BackColor = Color.Yellow;
                                break;
                            case LogLvl.error:
                                listViewItem.ForeColor = Color.Black;
                                listViewItem.BackColor = Color.Red;
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

        private void 清除_Click_1(object sender, EventArgs e)
        {
            Clean();
        }

        private void 复制_Click(object sender, EventArgs e)
        {
            SelectedListViewItemCollection selectedItems = this.SelectedItems;
            
            foreach (ListViewItem item in selectedItems)
            {
                int index = item.Index;
              
                string info = this.Items[index].SubItems[1].Text;
                string time = item.Text;
                Clipboard.SetText(time + ":"+ info);
            }
        }
    }
}
