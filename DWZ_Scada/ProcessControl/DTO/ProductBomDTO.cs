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
        public int BomId { get; set; }

        /// <summary>
        /// 物料产品ID
        /// </summary>
        public int ItemId { get; set; }

        /// <summary>
        /// Bom物料ID
        /// </summary>
        public int BomItemId { get; set; }

        /// <summary>
        /// Bom物料编码
        /// </summary>
        public int BomItemCode { get; set; }

        /// <summary>
        /// Bom物料名称
        /// </summary>
        public int BomItemName { get; set; }
    }
}
