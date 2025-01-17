using LogTool;
using System;

namespace DWZ_Scada.ProcessControl.DTO.OP60
{
    /// <summary>
    /// 安规测试DTO
    /// </summary>
    public class SafetyTestDto
    {
        public bool Good { get; set; }
        public string SafetyTestResult { get; set; } = "N";

        public string SafetyTestTime { get; set; }

        public string ACEsCosSinGndResult { get; set; }

        public string ACEsCosSinGndVoltage { get; set; }


        public string ACEsCosSinGndCurrent { get; set; }

        public string ACEsCosSinGndArc { get; set; }

        public string ACCosSinResult { get; set; }

        public string ACCosSinVoltage { get; set; }

        public string ACCosSinCurrent { get; set; }

        public string ACCosSinArc { get; set; }

        public string ACEsCosSinResult { get; set; }

        public string ACEsCosSinVoltage { get; set; }

        public string ACEsCosSinCurrent { get; set; }

        public string ACEsCosSinArc { get; set; }

        public string IREsCosSinGndResult { get; set; }

        public string IREsCosSinGndVoltage { get; set; }

        public string IREsCosSinGndResistance { get; set; }

        public string IREsCosResult { get; set; }

        public string IREsCosVoltage { get; set; }

        public string IREsCosResistance { get; set; }

        public string IREsSinResult { get; set; }

        public string IREsSinVoltage { get; set; }

        public string IREsSinResistance { get; set; }

        public string DCREsResult { get; set; }

        public string DCREsResistance { get; set; }

        public string DCREsTemperature { get; set; }

        public string DCRCosResult { get; set; }

        public string DCRCosResistance { get; set; }

        public string DCRCosTemperature { get; set; }

        public string DCRSinResult { get; set; }

        public string DCRSinResistance { get; set; }

        public string DCRSinTemperature { get; set; }

        public string IRCosSinResult { get; set; }
        public string IRCosSinVoltage { get; set; }
        public string IRCosSinResistance { get; set; }
        public string IREsCosSinResult { get; set; }
        public string IREsCosSinVoltage { get; set; }
        public string IREsCosSinResistance { get; set; }
        public string IWEsResult { get; set; }
        public string IWEsAreaComparison { get; set; }
        public string IWEsAreaDifferenceComparison { get; set; }
        public string IWEsCoronaComparison { get; set; }
        public string IWEsPhaseComparison { get; set; }
        public string IWCosResult { get; set; }
        public string IWCosAreaComparison { get; set; }
        public string IWCosAreaDifferenceComparison { get; set; }
        public string IWCosCoronaComparison { get; set; }
        public string IWCosPhaseComparison { get; set; }
        public string IWSinResult { get; set; }
        public string IWSinAreaComparison { get; set; }
        public string IWSinAreaDifferenceComparison { get; set; }
        public string IWSinCoronaComparison { get; set; }
        public string IWSinPhaseComparison { get; set; }



        public static string OKStr = "Func=QueryDetailsWorkResult,Result=Success,ErrTxt=,TestResult=Y,ProductModel=TSY1020N5303E102,ProductId=1111,Tester=MAC,TestTime=2025-01-15 09:38:41,AC_EsCosSin_Gnd_Result=Y,AC_EsCosSin_Gnd_Voltage=600V,AC_EsCosSin_Gnd_Current=0.049257mA,AC_EsCosSin_Gnd_Arc=0%,AC_Cos_Sin_Result=Y,AC_Cos_Sin_Voltage=599.7V,AC_Cos_Sin_Current=0.27453mA,AC_Cos_Sin_Arc=6%,AC_Es_CosSin_Result=Y,AC_Es_CosSin_Voltage=599.8V,AC_Es_CosSin_Current=0.30948mA,AC_Es_CosSin_Arc=3%,IR_EsCosSin_Gnd_Result=Y,IR_EsCosSin_Gnd_Voltage=499.8V,IR_EsCosSin_Gnd_Resistance=50G\\A6\\B8,IR_Cos_Sin_Result=Y,IR_Cos_Sin_Voltage=500V,IR_Cos_Sin_Resistance=49.689G\\A6\\B8,IR_Es_CosSin_Result=Y,IR_Es_CosSin_Voltage=499.9V,IR_Es_CosSin_Resistance=41.679G\\A6\\B8,DCR_Es_Result=Y,DCR_Es_Resistance=24.192\\A6\\B8,DCR_Es_Temperature=21.3\\A1\\E6,DCR_Cos_Result=Y,DCR_Cos_Resistance=38.196\\A6\\B8,DCR_Cos_Temperature=21.4\\A1\\E6,DCR_Sin_Result=Y,DCR_Sin_Resistance=35.583\\A6\\B8,DCR_Sin_Temperature=21.5\\A1\\E6,IW_Es_Result=Y,IW_Es_AreaComparison=0.6%,IW_Es_AreaDifferenceComparison=1.6,IW_Es_CoronaComparison=2,IW_Es_PhaseComparison=0.5%,IW_Cos_Result=Y,IW_Cos_AreaComparison=0%,IW_Cos_AreaDifferenceComparison=0.5,IW_Cos_CoronaComparison=2,IW_Cos_PhaseComparison=1.2%,IW_Sin_Result=Y,IW_Sin_AreaComparison=0.4%,IW_Sin_AreaDifferenceComparison=1,IW_Sin_CoronaComparison=2,IW_Sin_PhaseComparison=0%\\0D\\0A";
        public static SafetyTestDto ParseDto(string input)
        {
            SafetyTestDto result = new SafetyTestDto();
            try
            {
                var keyValuePairs = input.Split(',');
                foreach (var pair in keyValuePairs)
                {
                    var split = pair.Split('=');
                    var key = split[0].Trim();
                    var value = "";
                    if (split.Length <= 1)
                    {
                        continue;

                    }
                    value = split[1].Trim();
                    switch (key)
                    {
                        //case "Func": result.Func = value; break;
                        //case "Result": result.SafetyTestResult = value; break;
                        //case "ErrTxt": result.ErrTxt = value; break;
                        case "TestResult":
                            if ("Y" == value)
                            {
                                result.Good =true;
                            }
                            result.SafetyTestResult = value;
                            break;
                        //case "ProductModel": result.ProductModel = value; break;
                        //case "ProductId": result.ProductId = value; break;
                        //case "Tester": result.Tester = value; break;
                        case "TestTime":
                            result.SafetyTestTime = value;
                            break;
                        case "AC_EsCosSin_Gnd_Result":
                            result.ACEsCosSinGndResult = value;
                            break;
                        case "AC_EsCosSin_Gnd_Voltage":
                            result.ACEsCosSinGndVoltage = value;
                            break;
                        case "AC_EsCosSin_Gnd_Current":
                            result.ACEsCosSinGndCurrent = value;
                            break;
                        case "AC_EsCosSin_Gnd_Arc":
                            result.ACEsCosSinGndArc = value;
                            break;
                        case "AC_Cos_Sin_Result":
                            result.ACCosSinResult = value;
                            break;
                        case "AC_Cos_Sin_Voltage":
                            result.ACCosSinVoltage = value;
                            break;
                        case "AC_Cos_Sin_Current":
                            result.ACCosSinCurrent = value;
                            break;
                        case "AC_Cos_Sin_Arc":
                            result.ACCosSinArc = value;
                            break;
                        case "AC_Es_CosSin_Result":
                            result.ACEsCosSinResult = value;
                            break;
                        case "AC_Es_CosSin_Voltage":
                            result.ACEsCosSinVoltage = value;
                            break;
                        case "AC_Es_CosSin_Current":
                            result.ACEsCosSinCurrent = value;
                            break;
                        case "AC_Es_CosSin_Arc":
                            result.ACEsCosSinArc = value;
                            break;
                        case "IR_EsCosSin_Gnd_Result":
                            result.IREsCosSinGndResult = value;
                            break;
                        case "IR_EsCosSin_Gnd_Voltage":
                            result.IREsCosSinGndVoltage = value;
                            break;
                        case "IR_EsCosSin_Gnd_Resistance":
                            result.IREsCosSinGndResistance = value;
                            break;
                        case "IR_Es_Cos_Result":
                            result.IREsCosResult = value;
                            break;
                        case "IR_Es_Cos_Voltage":
                            result.IREsCosVoltage = value;
                            break;
                        case "IR_Es_Cos_Resistance":
                            result.IREsCosResistance = value;
                            break;
                        case "IR_Es_Sin_Result":
                            result.IREsSinResult = value;
                            break;
                        case "IR_Es_Sin_Voltage":
                            result.IREsSinVoltage = value;
                            break;
                        case "IR_Es_Sin_Resistance":
                            result.IREsSinResistance = value;
                            break;
                        case "DCR_Es_Result":
                            result.DCREsResult = value;
                            break;
                        case "DCR_Es_Resistance":
                            result.DCREsResistance = value;
                            break;
                        case "DCR_Es_Temperature":
                            result.DCREsTemperature = value;
                            break;
                        case "DCR_Cos_Result":
                            result.DCRCosResult = value;
                            break;
                        case "DCR_Cos_Resistance":
                            result.DCRCosResistance = value;
                            break;
                        case "DCR_Cos_Temperature":
                            result.DCRCosTemperature = value;
                            break;
                        case "DCR_Sin_Result":
                            result.DCRSinResult = value;
                            break;
                        case "DCR_Sin_Resistance":
                            result.DCRSinResistance = value;
                            break;
                        case "DCR_Sin_Temperature":
                            result.DCRSinTemperature = value;
                            break;
                        case "IR_Cos_Sin_Result":
                            result.IRCosSinResult = value;
                            break;
                        case "IR_Cos_Sin_Voltage":
                            result.IRCosSinVoltage = value;
                            break;
                        case "IR_Cos_Sin_Resistance":
                            result.IRCosSinResistance = value;
                            break;
                        case "IR_Es_CosSin_Result":
                            result.IREsCosSinResult = value;
                            break;
                        case "IR_Es_CosSin_Voltage":
                            result.IREsCosSinVoltage = value;
                            break;
                        case "IR_Es_CosSin_Resistance":
                            result.IREsCosSinResistance = value;
                            break;
                        case "IW_Es_Result":
                            result.IWEsResult = value;
                            break;
                        case "IW_Es_AreaComparison":
                            result.IWEsAreaComparison = value;
                            break;
                        case "IW_Es_AreaDifferenceComparison":
                            result.IWEsAreaDifferenceComparison = value;
                            break;
                        case "IW_Es_CoronaComparison":
                            result.IWEsCoronaComparison = value;
                            break;
                        case "IW_Es_PhaseComparison":
                            result.IWEsPhaseComparison = value;
                            break;
                        case "IW_Cos_Result":
                            result.IWCosResult = value;
                            break;
                        case "IW_Cos_AreaComparison":
                            result.IWCosAreaComparison = value;
                            break;
                        case "IW_Cos_AreaDifferenceComparison":
                            result.IWCosAreaDifferenceComparison = value;
                            break;
                        case "IW_Cos_CoronaComparison":
                            result.IWCosCoronaComparison = value;
                            break;
                        case "IW_Cos_PhaseComparison":
                            result.IWCosPhaseComparison = value;
                            break;
                        case "IW_Sin_Result":
                            result.IWSinResult = value;
                            break;
                        case "IW_Sin_AreaComparison":
                            result.IWSinAreaComparison = value;
                            break;
                        case "IW_Sin_AreaDifferenceComparison":
                            result.IWSinAreaDifferenceComparison = value;
                            break;
                        case "IW_Sin_CoronaComparison":
                            result.IWSinCoronaComparison = value;
                            break;
                        case "IW_Sin_PhaseComparison":
                            result.IWSinPhaseComparison = value;
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                LogMgr.Instance.Error($"转换安规测试结果错误:{ex.StackTrace}");
            }
            return result;
        }

    }
}
