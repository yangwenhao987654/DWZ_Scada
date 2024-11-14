using DWZ_Scada.ProcessControl.DTO;
using LogTool;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DWZ_Scada.Forms
{
    public partial class BomListForm : UIForm
    {
        public List<ProductBomDTO> ProductBomList { get; set; }

        public BomListForm(List<ProductBomDTO> productBomList)
        {
            InitializeComponent();
            ProductBomList = productBomList;
        }
        private void BomListForm_Load(object sender, EventArgs e)
        {
            if (ProductBomList==null)
            {
                return;
            }
            List<string> items = new List<string>();
            foreach (var bomItem in ProductBomList)
            {
                string item =$"物料:[{bomItem.BomItemName}] ,物料编码:[{bomItem.BomItemCode}]";
                items.Add(item);
            }
            uiListBox1.DataSource = items;
        }


        private void uiButton6_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void 复制选中物料码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           int index =  uiListBox1.SelectedIndex;
           if (index!=-1)
           {
               try
               {
                   string bomItemCode = ProductBomList[index].BomItemCode;
                   Clipboard.SetText(bomItemCode);
                   UIMessageTip.ShowOk("复制成功");
               }
               catch (Exception exception)
               {
                   LogMgr.Instance.Error($"复制BomCode失败,Index:[{index}] Msg:[{exception.Message}]");
               }
           }
        }
    }
}
