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
        readonly Queue<LogStruct> _unShownLogQueue = new Queue<LogStruct>();

        public readonly int ShowMaxCount = 1000;

        public ListViewEx_Log()
        {
            InitializeComponent();
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
            if (!IsHandleCreated || _unShownLogQueue.Count <= 0) return;
            if (this.Items.Count > ShowMaxCount)
            {
                this.Items.Clear();
            }
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
                            listViewItem.ForeColor = Color.DarkGray;
                            break;
                        case LogLvl.info:
                            listViewItem.ForeColor = Color.Green;
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

        private void 清除_Click(object sender, EventArgs e)
        {
            Items.Clear();
        }
    }
}
