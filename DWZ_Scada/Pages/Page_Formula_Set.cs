using CSharpFormApplication;
using DWZ_Scada.Forms.ProductFormula;
using LogTool;
using Microsoft.Extensions.DependencyInjection;
using ScadaBase.DAL.DAL;
using ScadaBase.DAL.Entity;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DWZ_Scada.Pages
{
    public partial class Page_Formula_Set : UIPage
    {
        private static Page_Formula_Set _instance;
        public static Page_Formula_Set Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (typeof(Page_Formula_Set))
                    {
                        if (_instance == null)
                        {
                            _instance = new Page_Formula_Set();
                        }
                    }
                }
                return _instance;
            }
        }
        AutoResizeForm asc = new AutoResizeForm();

        private IProductFormulaDAL productFormulaDAL;
        public Page_Formula_Set()
        {
            InitializeComponent();
            productFormulaDAL = Global.ServiceProvider.GetRequiredService<IProductFormulaDAL>();
        }

        private void Formula_set_FormClosing(object sender, FormClosingEventArgs e)
        {
            Page_Formula_Set.Instance?.Dispose();
        }

        private void Page_Formula_Set_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
            Task.Run(SelectAll);
        }

        private void ReflashTable(List<ProductFormulaEntity> list)
        {
            if (InvokeRequired)
            {
                dgv.Invoke(new Action<List<ProductFormulaEntity>>(ReflashTable), list);
                return;
            }
            dgv.Rows.Clear();
            dgv.SuspendLayout();
            int id = 1;
            foreach (var item in list)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgv);
                row.Cells[0].Value = id++;
                row.Cells[1].Value = item.ProductType;
                row.Cells[2].Value = item.ProductName;
                row.Cells[3].Value = item.ProductCode;
                row.Cells[4].Value = item.ProductPLCNo;

                //增加隐藏ID列
                row.Cells[5].Value = item.ID;
                dgv.Rows.Add(row);
            }
            dgv.ResumeLayout();
            dgv.ClearSelection();
        }

        private void Page_Formula_Set_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void uiButton4_Click(object sender, EventArgs e)
        {
            string input = tbx_input.Text;
            if (input.IsNullOrEmpty())
            {
                SelectAll();
            }
            else
            {
                SelectByProdCode(input);
            }
        }

        private void SelectByProdCode(string code)
        {
            List<ProductFormulaEntity> list = productFormulaDAL.SelectAllByProdCode(code);
            ReflashTable(list);
        }

        private void SelectAll()
        {
            List<ProductFormulaEntity> list = productFormulaDAL.SelectAll();
            ReflashTable(list);
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            //弹出一个添加的form
            FormProductFormulaAdd form = new FormProductFormulaAdd();
            form.ShowDialog();
            SelectAll();
        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            //获取选中项 弹出菜单
            int index = dgv.SelectedIndex;
            if (index==-1)
            {
                return;
            }
            try
            {
                int id = (int)dgv.Rows[index].Cells[5].Value;
                FormProductFormulaUpdate form = new FormProductFormulaUpdate(id);
                form.ShowDialog();
                SelectAll();
            }
            catch (Exception ex)
            {
                LogMgr.Instance.Error($"错误:{ex.Message}");
            }
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            int index = dgv.SelectedIndex;
            if (index == -1)
            {
                return;
            }
            try
            {
                bool b = UIMessageBox.ShowAsk($"确定要删除产品配方吗?\n" +
                                                        $"名称:{dgv.Rows[index].Cells[2].Value}\n " +
                                                        $"编号:{dgv.Rows[index].Cells[3].Value}");

                if (!b)
                {
                    return;
                }

                int id = (int)dgv.Rows[index].Cells[5].Value;
                bool flag = productFormulaDAL.RemoveById(id);
                if (!flag)
                {
                    UIMessageBox.ShowError($"删除失败:ID[{id}]");
                }
                else
                {
                    UIMessageBox.Show("删除成功!");
                }
                SelectAll();
            }
            catch (Exception ex)
            {
                LogMgr.Instance.Error($"错误:{ex.Message}");
            }
        }
    }
}
