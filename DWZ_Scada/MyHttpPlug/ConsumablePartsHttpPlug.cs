﻿using DWZ_Scada.ProcessControl.DTO;
using DWZ_Scada.ProcessControl.RequestSelectModel;
using LogTool;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DWZ_Scada.ProcessControl;
using TouchSocket.Core;
using TouchSocket.Http;
using DWZ_Scada.Pages.StationPages.OP40;
using Sunny.UI;
using DWZ_Scada.ProcessControl.Damageable;

namespace DWZ_Scada.MyHttpPlug
{
    /// <summary>
    /// 易损易耗件 请求接口
    /// </summary>
    class ConsumablePartsHttpPlug: PluginBase,IHttpPlugin<IHttpSocketClient>
    {
        public async Task OnHttpRequest(IHttpSocketClient client, HttpContextEventArgs e)
        {
            if ((URLConstants.ConsumablePartsUrl).Equals(e.Context.Request.RelativeURL))
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
                    if (body == "")
                    {
                        resultDto.Code = -1;
                        resultDto.Message = "请求Body为空";
                        await e.Context.Response.FromJson(resultDto.ToJsonString()).AnswerAsync();
                        return;
                    }
                    DamageableResultDto dto = JsonConvert.DeserializeObject<DamageableResultDto>(body);
                    LogMgr.Instance.Debug($"获取body:{body}");

                    //"http：//XXX:8090/workorder/issue/${产品型号ID}";
                    string relativeUrl = e.Context.Request.RelativeURL;
                    //返回响应信息  

                    //TODO 从请求参数中获取站别
                    // 不同的站别 获取到不同的易损易耗件 信息 
                    DamageStrategyBase damageStrategy;
                    switch (SystemParams.Instance.Station)
                    {

                        case SystemParams.StationEnum.OP10上料打码工站:
                            //selectHandle = new OP10SelectionStrategy();
                            break;
                        case SystemParams.StationEnum.OP20机械手绕线工站:
                            //selectHandle = new OP20SelectionStrategy();
                            break;
                        case SystemParams.StationEnum.OP30绕线检查工站:
                            //selectHandle = new OP30SelectionStrategy();
                            break;
                        case SystemParams.StationEnum.OP40TIG电焊工站:
                            //damageStrategy = new OP40DamageStrategy();
                            break;
                        case SystemParams.StationEnum.OP60电测工站:
                            //selectHandle = new OP50SelectionStrategy();
                            break;
                        case SystemParams.StationEnum.OP70出料打码工站:
                            //selectHandle = new OP60SelectionStrategy();
                            break;
                        default:
                            //selectHandle = new DefaultSelectionStrategy();
                            break;
                    }
                    if (dto.maxRunNumber == dto.runNumber)
                    {
                        //ＴＯＤＯ　通过事件通知　
                        GlobalOP40.IsAllow= false;
                        LogMgr.Instance.Info($"{dto.type}:{dto.name}达到最大使用次数:{dto.maxRunNumber} ,阻止进站");
                        UIMessageBox.ShowError($"{dto.type}:{dto.name}达到最大使用次数:{dto.maxRunNumber} ,请立即更换");
                    }
                    if (dto.earlyWarningNumber==dto.runNumber)
                    {
                        LogMgr.Instance.Info($"{dto.type}:{dto.name}达到预警使用次数:{dto.maxRunNumber}");
                    }
                    string resJson = resultDto.ToJsonString();
                    LogMgr.Instance.Debug("响应内容:");
                    LogMgr.Instance.Debug(resJson);
                    //处理选型 
                    //默认状态码是200
                    await e.Context.Response.FromJson(resJson).AnswerAsync();
                    LogMgr.Instance.Debug("Mes换件请求处理完毕");
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
                    LogMgr.Instance.Debug("Mes换件请求处理完毕");
                    return;
                }
            }
            else
            {
                //转到下一个请求
                await e.InvokeNext();
            }
        }
    }
}
