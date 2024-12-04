using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoTF;
using DWZ_Scada.Pages.PLCAlarm;
using DWZ_Scada.Pages.StationPages;
using DWZ_Scada.Pages.StationPages.OP10;
using LogTool;
using ScadaBase.DAL.Entity;
using Sunny.UI;
using UtilYwh.AlarmNotify;
using CSharpFormApplication;

namespace DWZ_Scada.Pages
{
    public partial class DeviceControlPage : UIPage
    {
        private static DeviceControlPage _instance;
        public static DeviceControlPage Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (typeof(DeviceControlPage))
                    {
                        if (_instance == null)
                        {
                            _instance = new DeviceControlPage();
                        }
                    }
                }
                return _instance;
            }
        }
        //1.声明自适应类实例
        AutoResizeForm asc = new AutoResizeForm();

        public static bool IsLoad { get; set; } = false;

        public delegate void UpdateDeviceEvent(List<DeviceAlarmEntity> list);

        public static event UpdateDeviceEvent DeviceUpdated;

        private bool isLoad = false;
        private CancellationTokenSource _cts = new CancellationTokenSource();


        #region 缓存界面更新委托实例
        private readonly Action<string> _addAlarmDelegate;

        private readonly Action _clearAlarmDelegate;

        private List<string> list = new List<string>();

        BindingSource bs = new BindingSource();
        #endregion

        private DeviceControlPage()
        {

            InitializeComponent();
            // 订阅AlarmEvent事件  
            AlarmManager.RunningLogEvent += HandleRunningLogEvent;

            AlarmManager.DeviceAlarmEvent += AlarmManager_DeviceAlarmEvent;
            //DeviceUpdated += DeviceControlPage_DeviceUpdated;
            IsLoad = true;
            _addAlarmDelegate = new Action<string>(AddAlarm);
            _clearAlarmDelegate = new Action(ClearAlarm);

        }

        private void DeviceControlPage_DeviceUpdated(List<DeviceAlarmEntity> list)
        {
            LogMgr.Instance.Debug("触发更新报警事件");
            UpdateAlarm(list);
        }

        public static void TriggerDeviceAlarmEvent(List<DeviceAlarmEntity> list)
        {
            DeviceUpdated?.Invoke(list);
        }

        private void AlarmManager_DeviceAlarmEvent(string msg)
        {
            AddAlarm(msg);
        }

        private void ClearAlarm()
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(_clearAlarmDelegate);
                }
                else
                {
                    if (lbx_Alarm.Items.Count <= 0)
                    {
                        return;
                    }
                    lbx_Alarm.Items.Clear();
                }
            }
            catch { }
        }

        private void HandleRunningLogEvent(string msg, AlarmManager.AlarmEnum alarmType)
        {
            if (msg.IsNullOrEmpty())
            {
                return;
            }
            else
            {
                msg = $"{DateTime.Now:yyyy-MM-dd:hh-mm-ss fff}:{msg}";
            }

            if (alarmType == AlarmManager.AlarmEnum.Info)
            {
                AppendLogInfo(msg);
            }
            else if (alarmType == AlarmManager.AlarmEnum.Alarm)
            {
                AppendLogAlarm(msg);
            }
            else
            {
                AppendLogErr(msg);
            }
        }
        private void AppendLogInfo(string msg)
        {
            if (InvokeRequired)
            {
                uiListBox2.Invoke(
                    new Action(() =>
                    {
                        AppendLogInfo(msg);
                    }));
                return;
            }
            if (uiListBox2.Items.Contains(msg))
            {

            }
            else
            {
                //uiListBox2.ForeColor = Color.Green;

                uiListBox2.Items.Add(msg);
                //int count = uiListBox2.Items.Count;
            }
        }

        private void AppendLogAlarm(string msg)
        {
            if (InvokeRequired)
            {
                uiListBox2.Invoke(
                    new Action(() =>
                    {
                        AppendLogAlarm(msg);
                    }));
                return;
            }
            if (uiListBox2.Items.Contains(msg))
            {

            }
            else
            {
                //uiListBox2.ForeColor = Color.Yellow;
                uiListBox2.Items.Add(msg);
            }
        }

        private void AppendLogErr(string msg)
        {
            if (InvokeRequired)
            {
                uiListBox2.Invoke(
                    new Action(() =>
                    {
                        AppendLogErr(msg);
                    }));
                return;
            }
            if (uiListBox2.Items.Contains(msg))
            {

            }
            else
            {
                //uiListBox2.ForeColor = Color.Red;
                uiListBox2.Items.Add(msg);
            }
        }

        /// <summary>
        /// 初始化完成
        /// </summary>
        public bool IsFirstFinishInit = true;

        /// <summary>
        /// 任务完成
        /// </summary>
        public bool IsTaskFinish = true;

        /// <summary>
        /// 设备停止中
        /// </summary>
        public bool IsFirstStop = true;


        private void AddInfo(string msg)
        {
            if (InvokeRequired)
            {
                lbx_Alarm.Invoke(
                    new Action(() =>
                    {
                        AddInfo(msg);
                    }));
                return;
            }
            if (lbx_Alarm.Items.Contains(msg))
            {

            }
            else
            {
                lbx_Alarm.ForeColor = Color.Green;
                lbx_Alarm.Items.Add(msg);
            }
        }

        private void AddAlarm(string msg)
        {
            if (InvokeRequired)
            {
                lbx_Alarm.Invoke(_addAlarmDelegate, msg);
                return;
            }
            if (lbx_Alarm.Items.Contains(msg))
            {

            }
            else
            {
                lbx_Alarm.ForeColor = Color.Red;
                lbx_Alarm.Items.Add(msg);
            }
        }

        public void UpdateAlarm(List<DeviceAlarmEntity> CurrentAlarmList)
        {
            /* if (!IsHandleCreated)
             {
                 LogMgr.Instance.Debug("页面未加载完成");
                 return;
             }*/
            //LogMgr.Instance.Debug("页面已经加载完成");



            ClearAlarm();
            foreach (var data in CurrentAlarmList)
            {
                AddAlarm($"{data.AlarmTime:yyyy-MM-dd hh:mm:ss fff}:{data.AlarmInfo}");
            }

            lbx_Alarm.DataSource = CurrentAlarmList;

        }

        public void UpdateAlarm(List<string> alarmlist)
        {
            /* if (!IsHandleCreated)
             {
                 LogMgr.Instance.Debug("页面未加载完成");
                 return;
             }*/
            //LogMgr.Instance.Debug("页面已经加载完成");


            //list.Add("456");
            //lbx_Alarm.DataSource =list;
            //reflashList();
            //lbx_Alarm.Refresh();
            list = alarmlist;
            reflashList();
        }

        private void reflashList()
        {
            if (InvokeRequired)
            {
                lbx_Alarm.Invoke(reflashList);
                return;
            }

            if (list.Any())
            {
                list.Insert(0,$"{DateTime.Now:yyyy:MM:dd hh:mm:ss}");
            }
            lbx_Alarm.DataSource = null;
            lbx_Alarm.DataSource = list;
            lbx_Alarm.ClearSelected();
        }

        //初始化
        private void uiButton3_Click(object sender, EventArgs e)
        {
            IsFirstFinishInit = true;
            if (Global.IsPlc_Connected)
            {
                try
                {
                    //bool b = Global.SiemensPLC.WriteInt16(PLCAddress.InitSingal, 1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("控制失败，" + ex.Message);
                }
            }
        }

        //复位
        private void uiButton2_Click(object sender, EventArgs e)
        {
            //这个操作很快
            if (Global.IsPlc_Connected)
            {
                try
                {
                    //上位机复位按钮
                    // Global.SiemensPLC.WriteInt16(PLCAddress.DeviceReset, 1);
                    Thread.Sleep(100);
                    // Global.SiemensPLC.WriteInt16(PLCAddress.DeviceReset, 0);
                    SpeckMessage.SpeakAsync("复位完成");
                    // IsFull = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("复位失败，" + ex.Message);
                }
            }
        }

        private void uiButton3_MouseDown(object sender, MouseEventArgs e)
        {
            if (Global.IsPlc_Connected)
            {
                try
                {
                    //上位机复位按钮
                    //  bool b = Global.SiemensPLC.WriteBool(PLCAddress.InitSingal, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("初始化失败，" + ex.Message);
                }
            }
        }

        private void uiButton3_MouseUp(object sender, MouseEventArgs e)
        {
            if (Global.IsPlc_Connected)
            {
                try
                {
                    //上位机复位按钮
                    Thread.Sleep(100);
                    //bool b = Global.SiemensPLC.WriteBool(PLCAddress.InitSingal, false);
                    UIMessageTip.Show("正在初始化...");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("初始化失败，" + ex.Message);
                }
            }
        }

        private void Manual_Debug_FormClosing(object sender, FormClosingEventArgs e)
        {
            DeviceControlPage.Instance?.Dispose();
        }

        private void DeviceControlPage_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
            /*  Thread t = new Thread(ReflashStatus);
              t.Start();*/
            //this.Show();
            //isLoad =true;
        }

        private void uiButton2_Click_1(object sender, EventArgs e)
        {
            /*lbx_Alarm.DataSource = null;
            lbx_Alarm.DataSource = list;*/


        }

        private void DeviceControlPage_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }
    }
}
