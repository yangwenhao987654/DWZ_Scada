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
using LogTool;
using Sunny.UI;
using UtilYwh.AlarmNotify;

namespace DWZ_Scada.Pages
{
    public partial class Manual_Debug : UIForm
    {
        Label percentageLabel = new Label();
        public Manual_Debug()
        {
            InitializeComponent();
            // 订阅AlarmEvent事件  
            AlarmManager.AlarmEvent += HandleAlarmEvent;
        }

        private void ClearAlarm()
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(
                        new Action(ClearAlarm));

                }
                else
                {
                    if (uiListBox1.Items.Count <= 0)
                    {
                        return;
                    }
                    uiListBox1.Items.Clear();
                }
            }
            catch { }


        }

        private void HandleAlarmEvent(string msg, AlarmManager.AlarmEnum alarmType)
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
                uiListBox1.Invoke(
                    new Action(() =>
                    {
                        AddInfo(msg);
                    }));
                return;
            }
            if (uiListBox1.Items.Contains(msg))
            {

            }
            else
            {
                uiListBox1.ForeColor = Color.Green;
                uiListBox1.Items.Add(msg);
            }
        }

        private void AddAlarm(string msg)
        {
            if (InvokeRequired)
            {
                uiListBox1.Invoke(
                    new Action(() =>
                    {
                        AddAlarm(msg);
                    }));
                return;
            }

            if (uiListBox1.Items.Contains(msg))
            {

            }
            else
            {
                uiListBox1.ForeColor = Color.Red;
                uiListBox1.Items.Add(msg);
            }
        }

        /// <summary>
        /// 持续监控设备状态
        /// </summary>
        private void ReflashStatus()
        {
            while (true)
            {
                ClearAlarm();
                if (Global.IsPlc_Connected)
                {

                }
                else
                {
                    //UpdateLight(false);
                    AddAlarm("PLC连接断开");
                }
                Thread.Sleep(1000);
            }
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
    }
}
