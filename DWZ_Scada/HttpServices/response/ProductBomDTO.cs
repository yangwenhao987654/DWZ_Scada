using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWZ_Scada.HttpServices.response
{
    public class ProductBomListItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string bomId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string itemId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string bomItemId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string bomItemCode { get; set; }
        /// <summary>
        /// 硬塑料
        /// </summary>
        public string bomItemName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string bomItemSpec { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string unitOfMeasure { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string itemOrProduct { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int quantity { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string enableFlag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string attr1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string attr2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string attr3 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string attr4 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string processCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string processName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> batchList { get; set; }
    }

    public class Data
    {
        /// <summary>
        /// 
        /// </summary>
        public string itemId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string itemCode { get; set; }
        /// <summary>
        /// 保险杠
        /// </summary>
        public string itemName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string specification { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string unitOfMeasure { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string itemOrProduct { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string itemTypeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string itemTypeCode { get; set; }
        /// <summary>
        /// 产成品
        /// </summary>
        public string itemTypeName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string enableFlag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string safeStockFlag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<ProductBomListItem> productBomList { get; set; }
    }



}
