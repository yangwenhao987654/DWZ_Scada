using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWZ_Scada.ProcessControl
{
    public static class URLConstants
    {
        /// <summary>
        /// BaseUrl属性
        /// </summary>
        public static string Base =>$"http://{SystemParams.Instance.MesIP}/dev-api/";

        //public static string Base = $"http://127.0.0.1/dev-api/";

        /// <summary>
        /// <para>提供Mes选型接口</para>
        /// <para>请求Body  SelectionModelDTO</para>
        /// </summary>
        public const string SelectModel = "/workorder/issue";

        /// <summary>
        /// 易损易耗件请求路径
        /// </summary>
        public const string ConsumablePartsUrl = "/damageable/issue";

        /// <summary>
        /// 上报易损易耗件路径
        /// </summary>
        public const string ReportConsumableUrl = "mes/produceApi/mes/buildcontrol/reportDamageable";

        /// <summary>
        /// 设备点检请求路径
        /// </summary>
        public const string InspectUrl = "mes/produceApi/mes/buildcontrol/addDvInspect";

        /// <summary>
        /// 上传过站数据路径
        /// </summary>
        public const string PassStationUpload = "mes/produceApi/mes/buildcontrol/passStationUpload";

        /// <summary>
        /// 获取产品Bom请求路径
        /// </summary>
        public const string ProductBomList = "mes/produceApi/mes/buildcontrol/mdProductBomList";

        /// <summary>
        /// 进站请求路径
        /// </summary>
        public const string EntryUrl = "mes/produceApi/mes/buildcontrol/checkinStation";

        /// <summary>
        /// 获取工单请求路径
        /// </summary>
        public const string GetWorkOrderUrl = "mes/produceApi/mes/buildcontrol/getWorkOrder";

        /// <summary>
        /// 获取最终码路径
        /// </summary>
        public const string GetFinalCodeUrl = "mes/produceApi/mes/buildcontrol/getFinalCode";

        /// <summary>
        /// 上传设备状态路径
        /// </summary>
        public const string DeviceStateUrl = "mes/produceApi/mes/buildcontrol/addDvStateLog";
    }

}
