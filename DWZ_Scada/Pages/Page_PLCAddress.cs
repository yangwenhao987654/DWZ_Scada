using HslCommunication;
using HslCommunication.ModBus;
using LogTool;
using DWZ_Scada;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using CommonUtilYwh.Communication.ModbusTCP;
using DWZ_Scada.dao;
using DWZ_Scada.Pages;
using DWZ_Scada.Pages.StationPages.OP10;
using Sunny.UI.Win32;
using CSharpFormApplication;

namespace DWZ_Scada
{
    public partial class Page_PLCAddress : UIPage
    {
        private static Page_PLCAddress _instance;
        public static Page_PLCAddress Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (typeof(Page_PLCAddress))
                    {
                        if (_instance == null)
                        {
                            _instance = new Page_PLCAddress();
                        }
                    }
                }
                return _instance;
            }
        }
        ComboBox ComboBox_2 = new ComboBox();

        public ModbusTCP ModbusTCP = new ModbusTCP();
        AutoResizeForm asc = new AutoResizeForm();
        /// <summary>
        /// PLC地址数据
        /// </summary>
        public List<PlcData> pLC_DATAs = new List<PlcData>();

        // public string IP = "192.168.1.88";
        /// <summary>
        /// PLC IP地址
        /// </summary>
        public string IP = "192.168.1.88";

        /// <summary>
        /// 端口号
        /// </summary>
        public string DK = "502";

        /// <summary>
        /// 站号
        /// </summary>
        public string ID = "2";

        public string shunxv = "0";

        public static object ObjLock = new object();
        public Page_PLCAddress()
        {
            InitializeComponent();
            //this.Instance = instance as Form_set_PLC;
            //this.TopLevel = false;
            //this.Location = new Point(0, 0);

            //this.Controls.Add(ComboBox_2);
            ////comboBox2.DrawMode = DrawMode.OwnerDrawFixed;
            //ComboBox_2.BringToFront();//将控件放置所有控件最前端  
            //comboBox2.Show();
            ComboBox_2.Items.Add("bool");
            ComboBox_2.Items.Add("short");
            ComboBox_2.Items.Add("int");
            ComboBox_2.Items.Add("long");
            ComboBox_2.Items.Add("float");
            ComboBox_2.Items.Add("ushort");
            ComboBox_2.Items.Add("uint");
            ComboBox_2.Items.Add("ulong");
            ComboBox_2.Items.Add("double");
            ComboBox_2.Items.Add("string");

            ComboBox_2.Hide();

            ComboBox_2.TextChanged += ComboBox_2_TextChanged;
            ComboBox_2.SizeChanged += ComboBox_2_SizeChanged;
            LogMgr.Instance.Info("11111");
            this.Show();
        }

        /// <summary>
        /// 写入信号
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Data"></param>
        /// <returns></returns>
        public void write_obj(string Name, string Data)
        {
            PlcData pLC_DATA = pLC_DATAs.Find(o => o.Name == Name);
            if (pLC_DATA != null)
            {
                ModbusTCP.write_(pLC_DATA.Address, pLC_DATA.Type, Data);
            }
        }

        public string read_obj(string Name)
        {
            try
            {
                PlcData pLC_DATA = pLC_DATAs.Find(o => o.Name == Name);
                if (pLC_DATA != null)
                {
                    return ModbusTCP.read_(pLC_DATA.Address, pLC_DATA.Type);
                }
                else
                {
                    LogMgr.Instance.Error($"查找地址节点[{Name}] 失败");
                }
            }
            catch (Exception e)
            {
                LogMgr.Instance.Error($"读取地址节点[{Name}] 失败," + e.Message);
            }
            return "-1";
        }


        private void ComboBox_2_SizeChanged(object sender, EventArgs e)
        {
            //int columnIndex = dataGridView1.CurrentCell.ColumnIndex;
            //int rowIndex = dataGridView1.CurrentCell.RowIndex;
            //Point p = this.dataGridView1.Location;
            //Rectangle rect = dataGridView1.GetCellDisplayRectangle(columnIndex, rowIndex, false);
            //ComboBox_2.Left = rect.Left + p.X;
            //ComboBox_2.Top = rect.Top + p.Y;
            //ComboBox_2.Width = rect.Width;
            //ComboBox_2.Height = rect.Height;
            ComboBox_2.Hide();
        }

        private void ComboBox_2_TextChanged(object sender, EventArgs e)
        {
            int columnIndex = dataGridView1.CurrentCell.ColumnIndex;
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            if (ComboBox_2.SelectedIndex != -1)
            {
                dataGridView1.Rows[rowIndex].Cells[columnIndex].Value = ComboBox_2.Text;
            }
        }

        public void shuaxingjiemian()
        {
            textBox_IP.Text = IP;
            textBox_DK.Text = DK;
            textBox_ID.Text = ID;
            comboBox1.SelectedIndex = Convert.ToInt32(shunxv);
            for (int i = 0; i < pLC_DATAs.Count; i++)
            {
                dataGridView1.Rows.Add();
            }
            shuaxing_liebiao();
        }

        void Save()
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
                rootElement.SetAttribute("IP", IP);
                rootElement.SetAttribute("端口号", DK);
                rootElement.SetAttribute("设备号", ID);
                rootElement.SetAttribute("字符顺序", shunxv);
                xmldoc.AppendChild(rootElement);

                for (int i = 0; i < pLC_DATAs.Count; i++)      //添加型号
                {
                    // 保存轴参数
                    PlcData pLC_DATA_ = pLC_DATAs[i];
                    XmlElement classElement = xmldoc.CreateElement(pLC_DATA_.Name);
                    classElement.SetAttribute("编号", pLC_DATA_.Index.ToString());
                    classElement.SetAttribute("名称", pLC_DATA_.Name);
                    classElement.SetAttribute("地址", pLC_DATA_.Address);
                    classElement.SetAttribute("数据类型", pLC_DATA_.Type);
                    classElement.SetAttribute("描述", pLC_DATA_.Desp);

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

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            DataGridViewColumn column = dataGridView1.CurrentCell.OwningColumn;
            //如果是要显示下拉列表的列的话
            if (column.Name.Equals("Column4"))
            {
                int columnIndex = dataGridView1.CurrentCell.ColumnIndex;
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                Point p = this.dataGridView1.Location;
                Rectangle rect = dataGridView1.GetCellDisplayRectangle(columnIndex, rowIndex, false);
                ComboBox_2.Left = rect.Left + p.X;
                ComboBox_2.Top = rect.Top + p.Y;
                ComboBox_2.Width = rect.Width;
                ComboBox_2.Height = rect.Height;
                if (my_object.MainForm.WindowState == FormWindowState.Normal)
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
            }
        }
        /// <summary>
        /// 添加参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();

            pLC_DATAs.Add(new PlcData());
            shuaxing_liebiao();
        }

        /// <summary>
        /// 刷新列表
        /// </summary>
        void shuaxing_liebiao()
        {
            for (int i = 0; i < pLC_DATAs.Count; i++)
            {
                pLC_DATAs[i].Index = i;
                dataGridView1.Rows[i].Cells[0].Value = pLC_DATAs[i].Index;
                dataGridView1.Rows[i].Cells[1].Value = pLC_DATAs[i].Name;
                dataGridView1.Rows[i].Cells[2].Value = pLC_DATAs[i].Address;
                dataGridView1.Rows[i].Cells[3].Value = pLC_DATAs[i].Type;
                dataGridView1.Rows[i].Cells[4].Value = pLC_DATAs[i].Desp;

            }
            dataGridView1.ClearSelection();
        }

        /// <summary>
        /// 刷新数据，将界面数据写入内存
        /// </summary>
        void shaxing_data()
        {
            try
            {
                IP = textBox_IP.Text;
                DK = textBox_DK.Text;
                ID = textBox_ID.Text;
                for (int i = 0; i < pLC_DATAs.Count; i++)
                {

                    pLC_DATAs[i].Index = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value.ToString());
                    pLC_DATAs[i].Name = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    pLC_DATAs[i].Address = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    pLC_DATAs[i].Type = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    pLC_DATAs[i].Desp = dataGridView1.Rows[i].Cells[4].Value.ToString();
                }
            }
            catch (Exception)
            {


            }
        }

        /// <summary>
        /// 读取数据
        /// </summary>
        public void read_data()
        {
            #region    读取参数
            try
            {
                string path = "DATA";
                XmlDocument doc = new XmlDocument();
                doc.Load(path + "\\PLC参数设置.XML");
                XmlNode xn = doc.SelectSingleNode("参数");
                XmlElement xe11 = (XmlElement)xn;
                IP = Convert.ToString(xe11.GetAttribute("IP"));
                DK = Convert.ToString(xe11.GetAttribute("端口号"));
                ID = Convert.ToString(xe11.GetAttribute("设备号"));
                shunxv = Convert.ToString(xe11.GetAttribute("字符顺序"));
                //得到根节点的所有子节点
                XmlNodeList xnl = xn.ChildNodes;

                for (int i = 0; i < xnl.Count; i++)
                {
                    try
                    {
                        XmlElement xe = (XmlElement)xnl[i];
                        PlcData pLC_DATA_ = new PlcData();
                        pLC_DATA_.Index = Convert.ToInt32(xe.GetAttribute("编号"));
                        pLC_DATA_.Name = Convert.ToString(xe.GetAttribute("名称"));
                        pLC_DATA_.Address = Convert.ToString(xe.GetAttribute("地址"));
                        pLC_DATA_.Type = Convert.ToString(xe.GetAttribute("数据类型"));
                        // pLC_DATA_.Desp = Convert.ToString(xe.GetAttribute("描述"));
                        pLC_DATAs.Add(pLC_DATA_);
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                //  my_object.LOGS_disp(ex.Message);
            }
            #endregion
        }
        /// <summary>
        /// 焦点行号
        /// </summary>
        int Row_ = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            shaxing_data();
            Save();
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                textBox4.Text = ModbusTCP.read_(pLC_DATAs[Row_].Address, pLC_DATAs[Row_].Type);
                MessageBox.Show("读取完成");
            }
            catch (Exception ex)
            {
                MessageBox.Show("读取失败:" + ex.Message);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                ModbusTCP.write_(pLC_DATAs[Row_].Address, pLC_DATAs[Row_].Type, textBox4.Text);
                MessageBox.Show("写入完成");
            }
            catch (Exception ex)
            {

                MessageBox.Show("写入失败:" + ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Row_ = dataGridView1.CurrentCell.RowIndex;
                label4.Text = pLC_DATAs[Row_].Name;
            }
            catch (Exception)
            {

            }
        }

        private void Form_set_PLC_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            asc.controllInitializeSize(this);
        }

        private void Form_set_PLC_FormClosing(object sender, FormClosingEventArgs e)
        {
            Page_PLCAddress.Instance?.Dispose();
            LogMgr.Instance.Info("关闭配方设定程序");
        }

        private void Page_PLCAddress_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }
    }
}
