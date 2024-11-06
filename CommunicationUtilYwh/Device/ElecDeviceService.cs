using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using log4net;
using LogTool;
using TouchSocket.Core;
using static System.Windows.Forms.AxHost;

namespace CommunicationUtilYwh.Device
{
    public class ElecDeviceService
    {
        public TcpDevice1 Device { get; set; }

        public bool IsTimeOut { get; set; }
        public ElecDeviceService(TcpDevice1 device)
        {
            Device = device;
        }


        public async Task<int> GetTestStateWithTimeout( int timeoutMilliseconds)
        {
            var cancellationTokenSource = new CancellationTokenSource();
            IsTimeOut = false;
            // 创建一个任务来执行 GetTestState
            var getTestStateTask = Task.Run(() => GetTestState(Device), cancellationTokenSource.Token);

            // 设置超时时间
            var completedTask = await Task.WhenAny(getTestStateTask, Task.Delay(timeoutMilliseconds, cancellationTokenSource.Token));

            if (completedTask == getTestStateTask)
            {
                LogMgr.Instance.Debug($"[{Device.Name}]测试完成");
                // 如果 GetTestState 任务完成，返回结果
                cancellationTokenSource.Cancel(); // 停止 Task.Delay 任务
                return await getTestStateTask;
            }
            else
            {
                LogMgr.Instance.Debug($"[{Device.Name}]测试超时");
                // 如果超时，返回 null 或其他超时处理
                cancellationTokenSource.Cancel(); // 停止 GetTestState 任务
                IsTimeOut =true;
                return 10;
            }
        }


        private int GetTestState(TcpDevice1 device)
        {
            int state = -1;
            try
            {
                while (!IsTimeOut)
                {
                    LogMgr.Instance.Debug($"GetTestState->:QueryTestStatus()");
                    string testStatusStr = device.QueryTestStatus();
                    if (string.IsNullOrEmpty(testStatusStr))
                    {
                        LogMgr.Instance.Debug($"GetTestState->nothing!");
                        Thread.Sleep(1000);
                        continue;
                    }
                    try
                    {
                        //2. 解析测试状态
                        state = device.ParseTestState(testStatusStr);
                        if (state == 2)
                        {
                            //测试结束有结果
                            break;
                        }

                        if (state == 3)
                        {
                            //测试结束没有结果
                            break;
                        }

                        if (state == 0)
                        {
                            //未测试
                            break;
                        }

                        if (state == 1)
                        {
                            //测试中
                            Thread.Sleep(1000);
                            continue;
                        }
                        LogMgr.Instance.Debug($"[{Device.Name}]测试状态：[{state}]");
                    }
                    catch (Exception e)
                    {
                        LogMgr.Instance.Error("解析测试状态错误:" + e.Message);
                        LogMgr.Instance.Debug(testStatusStr);
                    }
                }
            }
            catch (Exception ex)
            {
                LogMgr.Instance.Error($"执行测试错误:Device:[{device.Name}]" + ex.Message);
            }
            return state;
        }
    }
}
