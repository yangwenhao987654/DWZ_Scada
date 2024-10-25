using LogTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWZ_Scada.ProcessControl.DTO.OP60
{
    public class AtlBrxTestDto
    {
        public string AtlBrxTestResult { get; set; }

        public string TestTime { get; set; }

        public string PolePairs { get; set; }

        public string ExctingFrequency { get; set; }

        public string ExctingVoltage { get; set; }

        public string ElectricError { get; set; }

        public string UpError { get; set; }

        public string DownError { get; set; }

        public string PeakPeakError { get; set; }

        public string FFTError { get; set; }

        public string SinPhaseDisplacement { get; set; }

        public string CosPhaseDisplacement { get; set; }

        public string TranferRate0 { get; set; }

        public string TranferRate90 { get; set; }

        public string TranferRate180 { get; set; }

        public string TranferRate270 { get; set; }

        public string SinTransferRate { get; set; }

        public string CosTransferRate { get; set; }

        public string EsImpedance { get; set; }

        public string EsImpedanceRealPart { get; set; }

        public string EsImpedanceImagePart { get; set; }

        public string EsInductance { get; set; }

        public string SinImpedance { get; set; }

        public string SinImpedanceRealPart { get; set; }

        public string SinImpedanceImagePart { get; set; }

        public string SinInductance { get; set; }

        public string CosImpedanceRealPart { get; set; }

        public string CosImpedance { get; set; }

        public string CosImpedanceImagePart { get; set; }

        public string CosInductance { get; set; }

        public string ZeroPositionVoltage { get; set; }

        public string BigSmallWaveDifference { get; set; }


        public static string TestInput = "Func=QueryDetailsWorkResult,Result=Success,ErrTxt=,N=21,Tester=MAC,TestTime=2024-10-24 14:45:10,PolePairs=3,ExctingFrequency=10000Hz,ExctingVoltage=7V,ElectricError  =19.62\\A1\\E4,UpError=19.62\\A1\\E4,DownError=-9.93\\A1\\E4,PeakPeakError=29.55\\A1\\E4,FFTError=0:5.08\\A1\\E4;1:0.38\\A1\\E4;2:0.09\\A1\\E4;3:13.29\\A1\\E4,SinPhaseDisplacement=6.04\\A1\\E3,CosPhaseDisplacement=6.14\\A1\\E3,TranferRate0=0.2814,TranferRate90=0.2819,TranferRate180=0.2865,TranferRate270=0.2854,SinTransferRate=0.2854,CosTransferRate=0.2865,EsImpedance=118.6\\A6\\B8,EsImpedanceRealPart=37.18\\A6\\B8,EsImpedanceImagePart=112.6473\\A6\\B8,EsInductance=1.793mH,SinImpedance=244.2\\A6\\B8,SinImpedanceRealPart=66.4\\A6\\B8,SinImpedanceImagePart=234.9935\\A6\\B8,SinInductance=3.74mH,CosImpedance=233.6\\A6\\B8,CosImpedanceRealPart=68.65\\A6\\B8,CosImpedanceImagePart=223.2672\\A6\\B8,CosInductance=3.553mH,ZeroPositionVoltage=1.132mV,BigSmallWaveDifference=0.03638V,TestResult=Y,TestCount=9,OkCount=9,NgCount=0,PassRate=100.00%\\0D\\0A"; 

        public static AtlBrxTestDto ParseDto(string input)
        {
            AtlBrxTestDto result = new AtlBrxTestDto();
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
                            result.AtlBrxTestResult = value;
                            break;
                        //case "ProductModel": result.ProductModel = value; break;
                        //case "ProductId": result.ProductId = value; break;
                        //case "Tester": result.Tester = value; break;
                        case "TestTime":
                            result.TestTime = value;
                            break;
                        //case "Func": workResult.Func = value; break;
                        //case "Result": workResult.Result = value; break;
                        //case "ErrTxt": workResult.ErrTxt = value; break;

                        case "PolePairs": result.PolePairs = value; 
                            break;
                        case "ExctingFrequency": result.ExctingFrequency = value; 
                            break;
                        case "ExctingVoltage": result.ExctingVoltage = value; 
                            break;
                        case "ElectricError": result.ElectricError = value; 
                            break;
                        case "UpError": result.UpError = value; 
                            break;
                        case "DownError": result.DownError = value; 
                            break;
                        case "PeakPeakError": result.PeakPeakError = value;
                            break;
                        case "FFTError": result.FFTError = value;
                            break;
                        case "SinPhaseDisplacement": result.SinPhaseDisplacement = value;
                            break;
                        case "CosPhaseDisplacement": result.CosPhaseDisplacement = value;
                            break;
                        case "TranferRate0": result.TranferRate0 = value;
                            break;
                        case "TranferRate90": result.TranferRate90 = value;
                            break;
                        case "TranferRate180": result.TranferRate180 = value;
                            break;
                        case "TranferRate270": result.TranferRate270 = value;
                            break;
                        case "SinTransferRate": result.SinTransferRate = value;
                            break;
                        case "CosTransferRate": result.CosTransferRate = value;
                            break;
                        case "EsImpedance": result.EsImpedance = value;
                            break;
                        case "EsImpedanceRealPart": result.EsImpedanceRealPart = value; 
                            break;
                        case "EsImpedanceImagePart": result.EsImpedanceImagePart = value;
                            break;
                        case "EsInductance": result.EsInductance = value; 
                            break;
                        case "SinImpedance": result.SinImpedance = value;
                            break;
                        case "SinImpedanceRealPart": result.SinImpedanceRealPart = value;
                            break;
                        case "SinImpedanceImagePart": result.SinImpedanceImagePart = value;
                            break;
                        case "SinInductance": result.SinInductance = value; 
                            break;
                        case "CosImpedance": result.CosImpedance = value; 
                            break;
                        case "CosImpedanceRealPart": result.CosImpedanceRealPart = value; 
                            break;
                        case "CosImpedanceImagePart": result.CosImpedanceImagePart = value; 
                            break;
                        case "CosInductance": result.CosInductance = value; 
                            break;
                        case "ZeroPositionVoltage": result.ZeroPositionVoltage = value;
                            break;
                        case "BigSmallWaveDifference": result.BigSmallWaveDifference = value;
                            break;
                        //case "TestResult": workResult.TestResult = value; break;
                        // case "TestCount": workResult.TestCount = value; break;
                        //case "OkCount": workResult.OkCount = value; break;
                        //case "NgCount": workResult.NgCount = value; break;
                        //case "PassRate": workResult.PassRate = value; break;

                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                LogMgr.Instance.Error($"转换AtlBrx测试结果错误:{ex.StackTrace}");
            }
            return result;
        }
    }
}
