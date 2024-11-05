using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWZ_Scada.ProcessControl.DTO
{
    public class ProductDetailDto
    {
        /// <summary>
        /// 产品ID
        /// </summary>
        public string ItemId { get; set; }

        /// <summary>
        /// 产品Code
        /// </summary>
        public string ItemCode { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string ItemName { get; set; }

        public List<ProductBomDTO> ProductBomList { get; set; }
    }
}
