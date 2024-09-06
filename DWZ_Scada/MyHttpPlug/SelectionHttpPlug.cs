using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DWZ_Scada;
using DWZ_Scada.ProcessControl;
using DWZ_Scada.ProcessControl.DTO;
using DWZ_Scada.ProcessControl.RequestModel;
using DWZ_Scada.ProcessControl.RequestSelectModel;
using LogTool;
using Newtonsoft.Json;
using TouchSocket.Core;
using TouchSocket.Http;

namespace DWZ_Scada.MyHttpPlug
{
    /// <summary>
    /// 处理Mes选型请求 Mes下发选型 客户端监听
    /// </summary>
    public class SelectionHttpPlug : PluginBase, IHttpPlugin<IHttpSocketClient>
    {
        SelectionStrategyBase selectHandle;

        public async Task OnHttpRequest(IHttpSocketClient client, HttpContextEventArgs e)
        {
            LogMgr.Instance.Debug("接收请求:" + e.Context.Request.URL);
            if (URLConstants.SelectModel.Equals(e.Context.Request.RelativeURL))
            {
                SelectionResultDTO resultDto = new SelectionResultDTO()
                {
                    Code = 1,
                    Message = "OK"
                };
                try
                {
                    //获取请求参数
                    IHttpParams httpParams = e.Context.Request.Query;
                    /*  if (httpParams.TryGetValue("type", out var type))
                      {
                          LogMgr.Instance.Debug($"获取型号:[{type}]");
                      }*/
                    //获取请求头
                    IHttpHeader header = e.Context.Request.Headers;
                    string body = e.Context.Request.GetBody();
                    IHttpParams requestParams = e.Context.Request.Params;
                    if (body=="")
                    {
                        resultDto.Code = -1;
                        resultDto.Message = "请求Body为空";
                        await e.Context.Response.FromJson(resultDto.ToJsonString()).AnswerAsync();
                        return;
                    }
                    SelectionModelDTO modelDto = JsonConvert.DeserializeObject<SelectionModelDTO>(body);
                    LogMgr.Instance.Debug($"获取header:{header}");
                    LogMgr.Instance.Debug($"获取body:{body}");

                    //"http：//XXX:8090/workorder/issue/${产品型号ID}";
                    string relativeUrl = e.Context.Request.RelativeURL;
                    //返回响应信息  
                   
                    //TODO 这里去处理请求 等待结果
                    switch (SystemParams.Instance.Station)
                    {
                        case SystemParams.StationEnum.无:
                            selectHandle = new DefaultSelectionStrategy();
                            break;
                        case SystemParams.StationEnum.所有:
                            selectHandle = new DefaultSelectionStrategy();
                            break;
                        case SystemParams.StationEnum.OP10上料打码工站:
                            selectHandle = new OP10SelectionStrategy();
                            break;
                        case SystemParams.StationEnum.OP20机械手绕线工站:
                            selectHandle = new OP20SelectionStrategy();
                            break;
                        case SystemParams.StationEnum.OP30绕线检查工站:
                            selectHandle = new OP30SelectionStrategy();
                            break;
                        case SystemParams.StationEnum.OP40TIG电焊工站:
                            selectHandle = new OP40SelectionStrategy();
                            break;
                        case SystemParams.StationEnum.OP50电测工站:
                            selectHandle = new OP50SelectionStrategy();
                            break;
                        case SystemParams.StationEnum.OP60出料打码工站:
                            selectHandle = new OP60SelectionStrategy();
                            break;
                        default:
                            selectHandle = new DefaultSelectionStrategy();
                            break;
                    }
                    Task<SelectionResultDTO> task = selectHandle.ExecuteAsync(modelDto.ProductCode);
                    resultDto = task.Result;
                    string resJson = resultDto.ToJsonString();
                    LogMgr.Instance.Debug("响应内容:");
                    LogMgr.Instance.Debug(resJson);
                    //处理选型 
                    //默认状态码是200
                    await e.Context.Response.FromJson(resJson).AnswerAsync();
                    LogMgr.Instance.Debug("处理完毕");
                    return;
                }
                catch (Exception exception)
                {
                    LogMgr.Instance.Error("解析请求错误");
                    resultDto.Code = -1;
                    resultDto.Message = exception.Message;
                    string resJson = resultDto.ToJsonString();
                    LogMgr.Instance.Debug("响应内容:");
                    LogMgr.Instance.Debug(resJson);
                    //处理选型 
                    //默认状态码是200
                    await e.Context.Response.FromJson(resJson).AnswerAsync();
                    LogMgr.Instance.Debug("处理完毕");
                    return;
                }
            }
            else
            {
                //转到下一个请求
                await e.InvokeNext();

        /*        SelectionResultDTO resultDto = new SelectionResultDTO()
                {
                    Code = -1,
                    Message = "路径非法"
                };
                await e.Context.Response.FromJson(resultDto.ToJsonString()).AnswerAsync();*/
            }
        }
    }
}
