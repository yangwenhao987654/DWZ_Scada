using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaBase.DAL.Entity
{
    public class ProductFormulaEntity
    {
        public int ID { get; set; }

        public string ProductType { get; set; }

        public string ProductName { get; set; }


        /// <summary>
        /// 产品编号
        /// </summary>
        public string ProductCode { get; set; }


        /// <summary>
        /// PLC产品编号
        /// </summary>
        public int ProductPLCNo { get; set; }

    }
}
