using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWZ_Scada.ProcessControl.DTO
{
    public class ProductBomDTO
    {
        /// <summary>
        /// 流水号
        /// </summary>
        public string BomId { get; set; }

        /// <summary>
        /// 物料产品ID
        /// </summary>
        public string ItemId { get; set; }

        /// <summary>
        /// Bom物料ID
        /// </summary>
        public string BomItemId { get; set; }

        /// <summary>
        /// Bom物料编码
        /// TODO 需要这个
        /// </summary>
        public string BomItemCode { get; set; }

        /// <summary>
        /// Bom物料名称
        /// </summary>
        public string BomItemName { get; set; }
    }
}
