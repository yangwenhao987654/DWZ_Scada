﻿using System;
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
using DWZ_Scada;
using DWZ_Scada.Pages;
using Timer = System.Threading.Timer;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DWZ_Scada.Pages
{
    public partial class ZCForm : UIForm
    {
        private Timer timer;
        public ZCForm()
        {
            InitializeComponent();
        }

        private void ZCForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //ESC 键  会触发退出
            timer?.Dispose();
        }

        private void ZCForm_Load(object sender, EventArgs e)
        {
            timer = new Timer(TimerElapsed, null, 0, 100);
            // 设置KeyPreview为true以捕获键盘事件
            this.KeyPreview = true;
            // 添加事件处理程序
            this.KeyDown += new KeyEventHandler(Formula_set_KeyDown);
            this.KeyDown += new KeyEventHandler(Manual_Debug_KeyDown);
            this.KeyDown += new KeyEventHandler(Form_set_PLC_KeyDown);
            this.KeyDown += new KeyEventHandler(FormCustom_KeyDown);
            this.KeyDown += new KeyEventHandler(SystemParams_KeyDown); 
            this.KeyDown -= new KeyEventHandler(SystemParams_KeyDown);
        }


        private void TimerElapsed(object state)
        {
            if (lblTime.InvokeRequired)
            {
                int id = Thread.CurrentThread.ManagedThreadId;
                lblTime.Invoke(new Action(() =>
                {
                    TimerElapsed(id);
                }));
                return;
            }
            lblTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff");
            lblLoginName.Text = "调用线程ID:" + state.ToString();
        }

        private void uiButton6_Click(object sender, EventArgs e)
        {
            bool flag = SystemParams.Instance.OpLvl == 0;
            if (!flag)
            {
                UIMessageBox.ShowError("當前登錄賬號權限不足！");
                return;
            }
            new PageProperty(SystemParams.Instance).ShowDialog();
        }
        private void SystemParams_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F11)
            {
                uiButton6_Click(sender, e);
            }
        }

        private void uiButton7_Click(object sender, EventArgs e)
        {
            Form_set_PLC form_set_plc = new Form_set_PLC();
            form_set_plc.Show();
        }
        private void Form_set_PLC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                uiButton7_Click(sender, e);
            }
        }
        private void uiButton5_Click(object sender, EventArgs e)
        {
            FormCustom formCustom = new FormCustom();
            formCustom.Show();
        }
        private void FormCustom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F10)
            {
                uiButton5_Click(sender, e);
            }
        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            Formula_set formula_set = new Formula_set();
            formula_set.Show();
        }
        private void Formula_set_KeyDown(object sender, KeyEventArgs e)
        {
            // 检查按下的是否是F3键
            if (e.KeyCode == Keys.F3)
            {
                // 打开特定窗口
                uiButton3_Click(sender, e);
            }
        }
        private void uiButton4_Click(object sender, EventArgs e)
        {
            Manual_Debug manual_Debug = new Manual_Debug();
            manual_Debug.Show();
        }
        private void Manual_Debug_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                uiButton4_Click(sender, e);
            }
        }
    }
}
