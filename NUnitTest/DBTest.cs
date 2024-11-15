using System.Diagnostics;
using DWZ_Scada;
using DWZ_Scada.HttpRequest;
using DWZ_Scada.HttpServices;
using DWZ_Scada.HttpServices.response;
using DWZ_Scada.ProcessControl.DTO;
using DWZ_Scada.ProcessControl.DTO.OP20;
using DWZ_Scada.ProcessControl.DTO.OP60;
using DWZ_Scada.Services;
using DWZ_Scada.VO;
using LogTool;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NUnit.Framework.Internal;
using RestSharp;
using ScadaBase.DAL.BLL;
using ScadaBase.DAL.DAL;
using ScadaBase.DAL.Entity;

namespace NUnitTest
{
    /// <summary>
    /// 易损易耗件接口测试
    /// </summary>
    class DBTest
    {
        [SetUp]
        public void Setup()
        {
            LogMgr.Instance.Init();
            SystemParams.Load();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            Global.ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            //1.注册数据访问层
            /* services.AddScoped<IMatlabPaarmsDAL, MatlabParams_DAL>();
             services.AddScoped<IFormulaParamsDAL, FormulaParamsDAL>();*/

            //2.注册业务逻辑层
            /*      services.AddScoped<IMatlabParamsBLL, MatlabParamsBLL>();
                  services.AddScoped<IFormulaParamsBLL, FormulaParamsBLL>();*/

            //注册主窗体
            //services.AddScoped<MainForm>();

            services.AddSingleton<RestClient>(new RestClient(new RestClientOptions()
            {
                //BaseUrl = new Uri(URLConstants.Base),//配置基础URL-
                //ThrowOnAnyError = true, //如果有错误，抛出异常
                Timeout = TimeSpan.FromMilliseconds(3000),//设置超时 3秒
            }));
            //创建设备状态上报服务

            #region 注册数据库访问接口
            services.AddSingleton<IDeviceAlarmDAL, DeviceAlarmDAL>();
            services.AddSingleton<IDeviceAlarmBLL, DeviceAlarmBLL>();
            #endregion
            services.AddSingleton<IProductFormulaDAL, ProductFormulaDAL>();
        }

        [Test]
        public void SelectSingleByProdCode()
        {
            string code = "321";
            IProductFormulaDAL service = Global.ServiceProvider.GetRequiredService<IProductFormulaDAL>();
            ProductFormulaEntity entity = service.SelectSingleByProdCode(code);
            if (entity!=null)
            {
                int no = entity.ProductPLCNo;
                Assert.Pass($"获取ID:{no}");
            }
            else
            {
                
            }
        }
    }
}
