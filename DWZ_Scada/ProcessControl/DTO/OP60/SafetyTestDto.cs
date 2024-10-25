using LogTool;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWZ_Scada.ProcessControl.DTO.OP60
{
    /// <summary>
    /// 安规测试DTO
    /// </summary>
    public class SafetyTestDto
    {
        public string SafetyTestResult { get; set; }

        public string TestTime { get; set; }

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



        public static string OKStr = "Func=QueryDetailsWorkResult,Result=Success,ErrTxt=,TestResult=Y,ProductModel=1,ProductId=SN010WER,Tester=MAC,TestTime=2024-10-24 13:36:35,AC_EsCosSin_Gnd_Result=Y,AC_EsCosSin_Gnd_Voltage=499.9V,AC_EsCosSin_Gnd_Current=0.026178mA,AC_EsCosSin_Gnd_Arc=0%,AC_Cos_Sin_Result=Y,AC_Cos_Sin_Voltage=499.9V,AC_Cos_Sin_Current=0.303mA,AC_Cos_Sin_Arc=0%,AC_Es_CosSin_Result=Y,AC_Es_CosSin_Voltage=499.9V,AC_Es_CosSin_Current=0.30026mA,AC_Es_CosSin_Arc=0%,IR_EsCosSin_Gnd_Result=Y,IR_EsCosSin_Gnd_Voltage=499.9V,IR_EsCosSin_Gnd_Resistance=50G\\A6\\B8,IR_Es_Cos_Result=Y,IR_Es_Cos_Voltage=500V,IR_Es_Cos_Resistance=4.375G\\A6\\B8,IR_Es_Sin_Result=Y,IR_Es_Sin_Voltage=499.9V,IR_Es_Sin_Resistance=3.18G\\A6\\B8,DCR_Es_Result=Y,DCR_Es_Resistance=25.225\\A6\\B8,DCR_Es_Temperature=0\\A1\\E6,DCR_Cos_Result=Y,DCR_Cos_Resistance=39.792\\A6\\B8,DCR_Cos_Temperature=0\\A1\\E6,DCR_Sin_Result=Y,DCR_Sin_Resistance=36.9\\A6\\B8,DCR_Sin_Temperature=0\\A1\\E6\\0D\\0A";
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
                            result.SafetyTestResult = value;
                            break;
                        //case "ProductModel": result.ProductModel = value; break;
                        //case "ProductId": result.ProductId = value; break;
                        //case "Tester": result.Tester = value; break;
                        case "TestTime":
                            result.TestTime = value;
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
