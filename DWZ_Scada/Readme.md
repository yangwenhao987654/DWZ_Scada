﻿# 数据采集线体上位机

## OP10-OP70工站 7个工站

### 优化记录

#### 2024-12-03
 1.OP70软件左上角的名称修改

 2.修复OP60设备状态读取不对

 3.OP20中的绕线机状态颜色修改

 4.所有工站右上角设备状态灯展示

 5.优化所有工站界面布局，从右向左

 6.引入Nmodbus4 库 

 7.OP40工站 采用Nmodbus 读取不同站号的数据

 8.OP40优化：

	 1.优化MyModbus类的断线重连机制

	 2.界面布局优化，气体值表格显示

	 3.Modbus传感器采集线程增加try catch 防止一个异常导致另一个无法正常读取


#### 2024-12-04
1.增加基恩士KV上位链路协议 采用上位链路协议读取报警信息

2.增加报警信息和报警地址可填空

3.修复报错报警信息时添加空数据保存报错的问题，默认保存数组类型报警地址

4.优化基恩士KV上位链路协议的连接状态检测，完善断线重连机制,根据连接状态动态读取报警信息

5.所有PLC读写方法重新优化

#### 2024-12-05
1.增加自动更新程序，从服务器拉取最近的程序完成更新

#### 2024-12-12
1.绕线机状态监控修改，增加绕线开始和完成状态 报警状态等

2.增加隐藏点检功能 ,OP20没有点检

3.OP10检测界面修改

4.修复心跳地址写入错误的问题

5.完成所有工站自动升级程序部署

6.增加NModbus读取Int16类型有符号数据 

7.修复压力传感器负数读取失败问题

8.OP40增加压力上下限设定，界面监控报警提示


#### 2024-12-30
1.OP20绕线机 增加绕线开始时间，结束时间采集 绕线机名称，工位等
2.增加默认选中第一个工单


#### 2025-01-15
1.新增安规测试 测试数据项解析

