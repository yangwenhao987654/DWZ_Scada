using Sunny.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace DWZ_Scada.Page.PLCControl
{

    public partial class Page_PLCAlarmConfigcs : UIPage
    {
        public Page_PLCAlarmConfigcs()
        {
            InitializeComponent();
        }

        private static Page_PLCAlarmConfigcs _instance;
        public static Page_PLCAlarmConfigcs Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (typeof(Page_PLCAlarmConfigcs))
                    {
                        if (_instance == null)
                        {
                            _instance = new Page_PLCAlarmConfigcs();
                        }
                    }
                }
                return _instance;
            }
        }

        private void Page_PLCAlarmConfigcs_Load(object sender, EventArgs e)
        {
            InitTable();
        }

        public void Save()
        {
            string path = "DATA";
            try
            {
                if (Directory.Exists(path) == false)//如果不存在就创建LOGS文件夹
                {
                    Directory.CreateDirectory(path);
                }
                #region  保存XML
                //使用XmlDocument创建xml
                XmlDocument xmldoc = new XmlDocument();
                XmlDeclaration xmldec = xmldoc.CreateXmlDeclaration("1.0", "utf-8", "yes");
                xmldoc.AppendChild(xmldec);
                //添加根节点
                XmlElement rootElement = xmldoc.CreateElement("参数");
                /*       rootElement.SetAttribute("IP", IP);
                       rootElement.SetAttribute("端口号", DK);
                       rootElement.SetAttribute("设备号", ID);
                       rootElement.SetAttribute("字符顺序", shunxv);*/
                xmldoc.AppendChild(rootElement);
                List<PLCAlarmData> list = Global.PlcAlarmList;
                for (var i = 0; i < list.Count; i++)
                {
                    XmlElement classElement = xmldoc.CreateElement(list[i].ID);
                    classElement.SetAttribute("地址", list[i].Address);
                    classElement.SetAttribute("报警名称", list[i].Name);
                    rootElement.AppendChild(classElement);
                }
                //保存文件
                xmldoc.Save(path + "\\PLC参数设置.XML");
                #endregion
                MessageBox.Show("保存完成");
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败");
            }
        }


        private void InitTable()
        {
            dgv.Rows.Clear();
            for (int i = 0; i < Global.PlcAlarmList.Count; i++)
            {
                dgv.Rows.Add();
            }
            reflashTable();
        }

        /// <summary>
        /// 刷新列表
        /// </summary>
        private void reflashTable()
        {
            for (int i = 0; i < Global.PlcAlarmList.Count; i++)
            {
                PLCAlarmData data = Global.PlcAlarmList[i];
                dgv.Rows[i].Cells[0].Value = data.ID;
                dgv.Rows[i].Cells[1].Value = data.Address;
                dgv.Rows[i].Cells[2].Value = data.Name;
            }
        }



        private void dgv_CurrentCellChanged(object sender, EventArgs e)
        {
            /* DataGridViewColumn column = dgv.CurrentCell.OwningColumn;
             //如果是要显示下拉列表的列的话
             if (column.Name.Equals("Column4"))
             {
                 int columnIndex = dgv.CurrentCell.ColumnIndex;
                 int rowIndex = dgv.CurrentCell.RowIndex;
                 Point p = this.dataGridView1.Location;
                 Rectangle rect = dataGridView1.GetCellDisplayRectangle(columnIndex, rowIndex, false);
                 ComboBox_2.Left = rect.Left + p.X;
                 ComboBox_2.Top = rect.Top + p.Y;
                 ComboBox_2.Width = rect.Width;
                 ComboBox_2.Height = rect.Height;
                 if (my_object.Form1_.WindowState == FormWindowState.Normal)
                 {
                     //  my_object._ASF.controllInitializeSize(my_object._Form_Main);
                 }
                 //将单元格的内容显示为下拉列表的当前项
                 if (dataGridView1.Rows[rowIndex].Cells[columnIndex].Value != null)
                 {
                     string consultingRoom = dataGridView1.Rows[rowIndex].Cells[columnIndex].Value.ToString();
                     int index = ComboBox_2.Items.IndexOf(consultingRoom);
                     ComboBox_2.SelectedIndex = index;
                 }
                 else
                 {
                     dataGridView1.Rows[rowIndex].Cells[columnIndex].Value = ComboBox_2.Text;
                 }
                 ComboBox_2.Visible = true;
             }
             else
             {
                 ComboBox_2.Visible = false;
             }*/
        }

        /// <summary>
        /// 刷新数据，将界面数据写入内存
        /// </summary>
        public void shaxing_data()
        {
            try
            {
                for (int i = 0; i < Global.PlcAlarmList.Count; i++)
                {
                    Global.PlcAlarmList[i].ID = dgv.Rows[i].Cells[0].Value.ToString();
                    Global.PlcAlarmList[i].Address = dgv.Rows[i].Cells[1].Value.ToString();
                    Global.PlcAlarmList[i].Name = dgv.Rows[i].Cells[2].Value.ToString();
                }
            }
            catch (Exception)
            {


            }
        }


        private void uiButton1_Click_1(object sender, EventArgs e)
        {
            shaxing_data();
            Save();
        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            InitTable();
        }

        private void uiButton4_Click(object sender, EventArgs e)
        {

        }

        private void uiButton2_Click_1(object sender, EventArgs e)
        {
            dgv.Rows.Add();
            int count = dgv.Rows.Count;
            Global.PlcAlarmList.Add(new PLCAlarmData("序号" + count));
            reflashTable();
        }
    }
}
