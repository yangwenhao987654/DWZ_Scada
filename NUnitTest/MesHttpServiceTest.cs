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
using RestSharp;
using ScadaBase.DAL.BLL;
using ScadaBase.DAL.DAL;

namespace NUnitTest
{
    /// <summary>
    /// 易损易耗件接口测试
    /// </summary>
    class MesHttpServiceTest
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

        [Test]
        public async Task DamageableServiceTest()
        {
            DamageableService DamageableService = Global.ServiceProvider.GetRequiredService<DamageableService>();

            DamageableDTO dto = new DamageableDTO()
            {
                deviceCode = "OP40",
                code = "01", //焊接探针
                runNumber = 10,
                type = 1,
            };
            Task task = DamageableService.ReportDamageableAsync(dto);
            task.Wait();
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

            #region Mes接口服务

            services.AddSingleton<HttpClientHelper>();
            services.AddSingleton<DeviceStateService>();
            services.AddSingleton<DamageableService>();
            services.AddSingleton<InspectService>();
            services.AddSingleton<EntryRequestService>();
            services.AddSingleton<ProductBomService>();
            services.AddSingleton<UploadPassStationService>();
            services.AddSingleton<WorkOrderService>();

            #endregion

            #region 注册数据库访问接口
            services.AddSingleton<IDeviceAlarmDAL, DeviceAlarmDAL>();
            services.AddSingleton<IDeviceAlarmBLL, DeviceAlarmBLL>();
            #endregion
            services.AddSingleton<IProductFormulaDAL, ProductFormulaDAL>();
        }

        /// <summary>
        /// 查询工单接口测试
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task GetWorkOrderServiceTest()
        {
            WorkOrderService service = Global.ServiceProvider.GetRequiredService<WorkOrderService>();

            List<OrderVo>  Orders = new List<OrderVo>();
            RestResponse response = await service.GetWorkOrder();
            if (response.IsSuccessful)
            {
                WorkOrderDTO orderDto = JsonConvert.DeserializeObject<WorkOrderDTO>(response.Content);
                if (orderDto.code == 200)
                {
                    //
                    LogMgr.Instance.Debug("获取工单成功");
                    List<DataItem> list = orderDto.data;
                    foreach (var item in list)
                    {
                        OrderVo vo = new OrderVo();
                        vo.WorkOrderCode = item.workorderCode;
                        vo.WorkOrderName = item.workorderName;
                        vo.ProductCode = item.productCode; //产品型号Code  ItemCode 根据这个查询物料Bom
                        vo.ProductName = item.productName;
                        Orders.Add(vo);
                    }
                }
                else
                {
                    LogMgr.Instance.Error("获取工单失败");
                }
            }
        }


        [Test]
        public async Task EntryServiceTest()
        {
            EntryRequestService EntryRequestService = Global.ServiceProvider.GetRequiredService<EntryRequestService>();
            string stationCode = "OP70";
            string sn = "24110201";
            string workOrder = "MO202411020002";

            EntryRequestDTO dto = new()
            {
                SnTemp = sn,
                StationCode = stationCode,
                WorkOrder = workOrder
            };
            (bool, string) value = await EntryRequestService.CheckIn(dto);
        }


        [Test]
        public async Task UploadOP10_01_PassStationServiceTest()
        {
            UploadPassStationService UploadPassStationService = Global.ServiceProvider.GetRequiredService<UploadPassStationService>();
            string stationCode = "OP10";
            string sn = "24110201";
            string workOrder = "MO202411020002";
            PassStationDTO dto = new PassStationDTO()
            {
                StationCode = stationCode,
                SnTemp = sn,
                WorkOrder = workOrder,
                PassStationData = new OP10Vision1Data()
                {
                    Vision1Result = true,
                    BreachNo ="01000010",
                    Good = true,
                },
                isLastStep = false
            };
            (bool, string) value = await UploadPassStationService.SendPassStationData(dto);
        }

        [Test]
        public async Task UploadOP10_02_PassStationServiceTest()
        {
            UploadPassStationService UploadPassStationService = Global.ServiceProvider.GetRequiredService<UploadPassStationService>();
            string stationCode = "OP10";
            string sn = "24110201";
            string workOrder = "MO202411020002";
            PassStationDTO dto = new PassStationDTO()
            {
                StationCode = stationCode,
                SnTemp = sn,
                WorkOrder = workOrder,
                PassStationData = new OP10Vision2Data()
                {
                    Vision2Result = true,
                    Good = true,
                },
                isLastStep = true
            };
            (bool, string) value = await UploadPassStationService.SendPassStationData(dto);
        }

        [Test]
        public async Task UploadOP20_01_PassStationServiceTest()
        {
            UploadPassStationService UploadPassStationService = Global.ServiceProvider.GetRequiredService<UploadPassStationService>();
            string stationCode = "OP20";
            string sn = "24110201";
            string workOrder = "MO202411020002";
            List<double> doubles = new List<double>()
            {
                       15.51,
                       16.45,
                       52.12,
                       165.62,
                       15.25,
                       98.65,
                       78.12,
                       987.451,
                       456.213,
                       482.012,
                       456.254,
                       475.125,
                        15.51,
                       16.45,
                       52.12,
                       165.62,
                       15.25,
                       98.65,
                       78.12,
                       987.451,
                       456.213,
                       482.012,
                       456.254,
                       475.125,
                        15.51,
                       16.45,
                       52.12,
                       165.62,
                       15.25,
                       98.65,
                       78.12,
                       987.451,
                       456.213,
                       482.012,
                       456.254,
                       475.125,
                        15.51,
                       16.45,
                       52.12,
                       165.62,
                       15.25,
                       98.65,
                       78.12,
                       987.451,
                       456.213,
                       482.012,
                       456.254,
                       475.125,
                        15.51,
                       16.45,
                       52.12,
                       165.62,
                       15.25,
                       98.65,
                       78.12,
                       987.451,
                       456.213,
                       482.012,
                       456.254,
                       475.125,
                        15.51,
                       16.45,
                       52.12,
                       165.62,
                       15.25,
                       98.65,
                       78.12,
                       987.451,
                       456.213,
                       482.012,
                       456.254,
                       475.125,
                        15.51,
                       16.45,
                       52.12,
                       165.62,
                       15.25,
                       98.65,
                       78.12,
                       987.451,
                       456.213,
                       482.012,
                       456.254,
                       475.125,
            };
            string str = string.Join(",",doubles);

            PassStationDTO dto = new PassStationDTO()
            {
                StationCode = stationCode,
                SnTemp = sn,
                WorkOrder = workOrder,
                PassStationData = new CoildDataDto()
                {
                    BreachNo = "001210215",
                    CoilsCurNum = 399.99,
                    CoilsTargetNum = 400,
                    TensionValue = str,
                    Good = true
                },
                isLastStep = true
            };
            (bool, string) value = await UploadPassStationService.SendPassStationData(dto);
        }

        [Test]
        public async Task UploadOP30_01_PassStationServiceTest()
        {
            UploadPassStationService UploadPassStationService = Global.ServiceProvider.GetRequiredService<UploadPassStationService>();
            string stationCode = "OP30";
            string sn = "24110201";
            string workOrder = "MO202411020002";
            PassStationDTO dto = new PassStationDTO()
            {
                StationCode = stationCode,
                SnTemp = sn,
                WorkOrder = workOrder,
                PassStationData = new OP30Vision1Data()
                {
                    Vision1Result = true,
                    //BreachNo = "01000010",
                    Good = true,
                },
                isLastStep = true
            };
            (bool, string) value = await UploadPassStationService.SendPassStationData(dto);
        }

        [Test]
        public async Task UploadOP40_01_PassStationServiceTest()
        {
            UploadPassStationService UploadPassStationService = Global.ServiceProvider.GetRequiredService<UploadPassStationService>();
            string stationCode = "OP40";
            string sn = "24110201";
            string workOrder = "MO202411020002";

            short[] arrA = new short[6]{ 154,215,154,154,145,125};
            short[] arrB = new short[6] { 187,154,875,845,145,488};
            short[] arrC = new short[6] { 123, 324, 4375, 1245, 1435, 8988 };
            PassStationDTO dto = new PassStationDTO()
            {
                StationCode = stationCode,
                SnTemp = sn,
                WorkOrder = workOrder,
            

                PassStationData = new OP40WeldingData()
                {
                    WeldingResult = true,
                    Good = true,
                    GasA1 = arrA[0].ToString(),
                    GasA2 = arrA[1].ToString(),
                    GasA3 = arrA[2].ToString(),
                    GasA4 = arrA[3].ToString(),
                    GasA5 = arrA[4].ToString(),
                    GasA6 = arrA[5].ToString(),

                    GasB1 = arrB[0].ToString(),
                    GasB2 = arrB[1].ToString(),
                    GasB3 = arrB[2].ToString(),
                    GasB4 = arrB[3].ToString(),
                    GasB5 = arrB[4].ToString(),
                    GasB6 = arrB[5].ToString(),

                    GasC1 = arrC[0].ToString(),
                    GasC2 = arrC[1].ToString(),
                    GasC3 = arrC[2].ToString(),
                    GasC4 = arrC[3].ToString(),
                    GasC5 = arrC[4].ToString(),
                    GasC6 = arrC[5].ToString(),
                },
                isLastStep = false
            };
            (bool, string) value = await UploadPassStationService.SendPassStationData(dto);
        }

        [Test]
        public async Task UploadOP40_02_PassStationServiceTest()
        {
            UploadPassStationService UploadPassStationService = Global.ServiceProvider.GetRequiredService<UploadPassStationService>();
            string stationCode = "OP40";
            string sn = "24110201";
            string workOrder = "MO202411020002";
            PassStationDTO dto = new PassStationDTO()
            {
                StationCode = stationCode,
                SnTemp = sn,
                WorkOrder = workOrder,
                PassStationData = new OP40Vision1Data()
                {
                    Vision1Result = true,
                    //BreachNo = "01000010",
                    Good = true,
                },
                isLastStep = true
            };
            (bool, string) value = await UploadPassStationService.SendPassStationData(dto);
        }

        [Test]
        public async Task UploadOP60_01_PassStationServiceTest()
        {
            UploadPassStationService UploadPassStationService = Global.ServiceProvider.GetRequiredService<UploadPassStationService>();
            string stationCode = "OP60";
            string sn = "24110201";
            string workOrder = "MO202411020002";
            SafetyTestDto safetyTestDto =  SafetyTestDto.ParseDto(SafetyTestDto.OKStr);
            safetyTestDto.Good = true;
            PassStationDTO dto = new PassStationDTO()
            {
                StationCode = stationCode,
                SnTemp = sn,
                WorkOrder = workOrder,
                PassStationData = safetyTestDto,
                isLastStep = false
            };
            (bool, string) value = await UploadPassStationService.SendPassStationData(dto);
        }

        [Test]
        public async Task UploadOP60_02_PassStationServiceTest()
        {
            UploadPassStationService UploadPassStationService = Global.ServiceProvider.GetRequiredService<UploadPassStationService>();
            string stationCode = "OP60";
            string sn = "24110201";
            string workOrder = "MO202411020002";
            AtlBrxTestDto atlBrxTestDto = AtlBrxTestDto.ParseDto(AtlBrxTestDto.OKStr);
         
            PassStationDTO dto = new PassStationDTO()
            {
                StationCode = stationCode,
                SnTemp = sn,
                WorkOrder = workOrder,
                PassStationData = atlBrxTestDto,
                isLastStep = true
            };
            (bool, string) value = await UploadPassStationService.SendPassStationData(dto);
        }

        [Test]
        public async Task UploadOP70_01_PassStationServiceTest()
        {
            UploadPassStationService UploadPassStationService = Global.ServiceProvider.GetRequiredService<UploadPassStationService>();
            string stationCode = "OP70";
            string sn = "24110201";
            string workOrder = "MO202411020002";
            PassStationDTO dto = new PassStationDTO()
            {
                StationCode = stationCode,
                SnTemp = sn,
                WorkOrder = workOrder,
                PassStationData = new OP70Vision1Data()
                {
                    Vision1Result = true,
                    Good = true,
                },
                isLastStep = false
            };
            (bool, string) value = await UploadPassStationService.SendPassStationData(dto);
        }

        [Test]
        public async Task UploadOP70_02_PassStationServiceTest()
        {
            UploadPassStationService UploadPassStationService = Global.ServiceProvider.GetRequiredService<UploadPassStationService>();
            string stationCode = "OP70";
            string sn = "24110201";
            string workOrder = "MO202411020002";

            string finalCode = "F24110201";

            PassStationDTO dto = new PassStationDTO()
            {
                StationCode = stationCode,
                SnTemp = sn,
                WorkOrder = workOrder,
                PassStationData = new FinalCodeData()
                {
                    Good = true,
                    SN = finalCode,
                    Level = "A"
                },
                isLastStep = true
            };
            (bool, string) value = await UploadPassStationService.SendPassStationData(dto);
        }

        [Test]
        public async Task ProductBomServiceTest()
        {
            ProductBomService service = Global.ServiceProvider.GetRequiredService<ProductBomService>();

            //根据物料编码 查询产品Bom
            string itemCode = "IF20240816002";
            (bool flag, string err, ProductDetailDto dto)  = await service.GetBomList(itemCode);
            if (flag)
            {
                string itemMsg = "";
                foreach (var item in dto.ProductBomList)
                {
                    itemMsg += $" 物料名称:{item.BomItemName} ,物料编码:{item.BomItemCode}\n"; 
                }
                Assert.Pass("获取成功:\n"+itemMsg);
            }
            else
            {
                //请求失败
                Assert.Fail(err);
            }
        }
    }
}
