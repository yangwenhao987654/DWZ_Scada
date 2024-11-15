using Microsoft.Extensions.DependencyInjection;
using ScadaBase.DAL.DAL;
using ScadaBase.DAL.Entity;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace DWZ_Scada.Forms.ProductFormula
{
    public partial class FormProductFormulaUpdate : UIForm
    {
        private ProductFormulaEntity entity;
        public int RecordID { get; set; }
        public FormProductFormulaUpdate(int ID)
        {
            InitializeComponent();
            RecordID = ID;
            productFormulaDAL = Global.ServiceProvider.GetRequiredService<IProductFormulaDAL>();
        }

        private IProductFormulaDAL productFormulaDAL;

        private void uiButton1_Click(object sender, EventArgs e)
        {

            if (tbx_Code.Text.IsNullOrEmpty())
            {
                UIMessageBox.ShowError("产品编号不能为空");
                return;
            }

            if (tbx_PLCNo.Text.IsNullOrEmpty())
            {
                UIMessageBox.ShowError("PLC料号不能为空");
                return;
            }

            bool f = int.TryParse(tbx_PLCNo.Text, out int plcNo);
            if (!f || plcNo == 0)
            {
                UIMessageBox.ShowError("PLC料号不能为0");
                return;
            }

            entity.ProductPLCNo = plcNo;
            entity.ProductCode = tbx_Code.Text;
            entity.ProductName = tbxName.Text;
            entity.ProductType = tbx_Type.Text;

  

            bool flag = productFormulaDAL.Update(entity);
            if (flag)
            {
                UIMessageBox.Show("更新配方成功");
                this.Close();
            }
            else
            {
                UIMessageBox.ShowError("更新配方失败");
            }
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormProductFormulaUpdate_Load(object sender, EventArgs e)
        {
            entity = productFormulaDAL.SelectById(RecordID);
            if (entity == null)
            {
                UIMessageBox.ShowError("查询产品配方失败");
                Close();
                return;
            }

            LoadEntity();
        }

        private void LoadEntity()
        {
            tbx_Code.Text = entity.ProductCode;
            tbx_PLCNo.Text = entity.ProductPLCNo.ToString();
            tbx_Type.Text = entity.ProductType;
            tbxName.Text =entity.ProductName;
        }
    }
}
