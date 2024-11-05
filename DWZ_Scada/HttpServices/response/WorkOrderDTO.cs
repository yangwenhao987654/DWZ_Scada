using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWZ_Scada.HttpServices.response
{
    public class @params
    {
    }
    public class WorkOrderDTO
    {
        /// <summary>
        /// 操作成功！
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<DataItem> data { get; set; }
    }

    public class DataItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string searchValue { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string createBy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string createTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string updateBy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string updateTime { get; set; }
        /// <summary>
        /// 加急
        /// </summary>
        public string remark { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public @params @params { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string parentName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string parentId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string orderNum { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ancestors { get; set; }
        /// <summary>
        /// 工单ID
        /// </summary>
        public string workorderId { get; set; }
        /// <summary>
        /// 工单Code
        /// </summary>
        public string workorderCode { get; set; }
        /// <summary>
        /// 工单名称
        /// </summary>
        public string workorderName { get; set; }
        /// <summary>
        /// 工单类型
        /// </summary>
        public string workorderType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string orderSource { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string sourceCode { get; set; }
        /// <summary>
        /// 产品Id
        /// </summary>
        public string productId { get; set; }
        /// <summary>
        /// 产品Code
        /// </summary>
        public string productCode { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string productName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string routeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string routeCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string routeName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string routeDesc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string productSpc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string unitOfMeasure { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string batchCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string quantity { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string quantityProduced { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string quantityChanged { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string quantityScheduled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string clientId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string clientCode { get; set; }
        /// <summary>
        /// 一汽奥迪
        /// </summary>
        public string clientName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string vendorId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string vendorCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string vendorName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string requestDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string finishDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string status { get; set; }
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
        public string tasks { get; set; }
    }



}
