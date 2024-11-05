using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LogTool;

namespace CommunicationUtilYwh.Device
{
    public class ElecDeviceService
    {
        public TcpDevice1 Device { get; set; }
        public ElecDeviceService(TcpDevice1 device)
        {
            Device = device;
        }


        public async Task<int> GetTestStateWithTimeout( int timeoutMilliseconds)
        {
            var cancellationTokenSource = new CancellationTokenSource();

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
                return 10;
            }
        }


        private int GetTestState(TcpDevice1 device)
        {
            string testStatusStr = device.QueryTestStatus();
            int state = -1;
            try
            {
                //2. 解析测试状态
                state = device.ParseTestState(testStatusStr);
                if (state == 2)
                {
                    //测试结束有结果
                }

                if (state == 3)
                {
                    //测试结束没有结果
                }

                if (state == 0)
                {
                    //未测试
                }

                if (state == 1)
                {
                    //测试中
                    Thread.Sleep(1000);
                    GetTestState(device);
                }
                LogMgr.Instance.Debug($"[{Device.Name}]测试状态：[{state}]");
            }
            catch (Exception e)
            {
                LogMgr.Instance.Error("解析测试状态错误:"+e.Message);
                LogMgr.Instance.Debug(testStatusStr);
            }
            return state;
        }
    }
}
