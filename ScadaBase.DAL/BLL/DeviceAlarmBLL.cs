using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScadaBase.DAL.Entity;

namespace ScadaBase.DAL.BLL
{
    public interface IDeviceAlarmBLL
   {
       List<DeviceAlarmEntity> SelectAll();

       List<DeviceAlarmEntity> SelectByName(string alarmName);

       /// <summary>
       /// 查询某天的报警信息
       /// </summary>
       /// <param name="dateStr"></param>
       /// <returns></returns>
       List<DeviceAlarmEntity> SelectByDate(string dateStr);

        /// <summary>
        /// 查询某天的报警信息
        /// </summary>
        /// <param name="dateStr">报警日期</param>
        /// <param name="deviceName">设备名称</param>
        /// <returns></returns>
        List<DeviceAlarmEntity> SelectByDate(string dateStr,string deviceName);

        /// <summary>
        /// 根据开始时间和结束时间查询报警信息
        /// </summary>
        /// <param name="startDt">开始时间</param>
        /// <param name="endDt">结束时间</param>
        /// <returns></returns>
        List<DeviceAlarmEntity> SelectByStartDate(DateTime startDt, DateTime endDt);

        /// <summary>
        /// 根据报警日期和报警名称查询报警信息
        /// </summary>
        /// <param name="dateStr">报警日期</param>
        /// <param name="alarmName">报警名称</param>
        /// <returns></returns>
        List<DeviceAlarmEntity> SelectByDateANDAlarmName(string dateStr, string alarmName);

        /// <summary>
        /// 按照报警开始时间和结束时间查询
        /// </summary>
        /// <param name="startDt">开始时间</param>
        /// <param name="endDt">结束时间</param>
        /// <returns></returns>
        List<DeviceAlarmEntity> SelectByDate(string deviceName,DateTime startDt, DateTime endDt);

       /// <summary>
       /// 按照报警类型查询
       /// </summary>
       /// <returns></returns>
       List<DeviceAlarmEntity> SelectByType(string alarmType);


       /// <summary>
       /// 按照设备名称查询
       /// </summary>
       /// <returns></returns>
       List<DeviceAlarmEntity> SelectByDevice(string deviceName);

    }

   public class DeviceAlarmBLL:IDeviceAlarmBLL
    {


        private readonly IDeviceAlarmDAL _deviceAlarmDAL;
        public DeviceAlarmBLL(IDeviceAlarmDAL deviceAlarmDal)
        {
            _deviceAlarmDAL =deviceAlarmDal;
        }
        public List<DeviceAlarmEntity> SelectAll()
        {
            return _deviceAlarmDAL.SelectAll();
        }

        public List<DeviceAlarmEntity> SelectByName(string alarmName)
        {
            return _deviceAlarmDAL.SelectByName(alarmName);
        }

        public List<DeviceAlarmEntity> SelectByDate(string dateStr)
        {
            return _deviceAlarmDAL.SelectByDate(dateStr);
        }

        public List<DeviceAlarmEntity> SelectByDate(string dateStr, string deviceName)
        {
            return _deviceAlarmDAL.SelectByDate(dateStr, deviceName);
        }
        public List<DeviceAlarmEntity> SelectByStartDate(DateTime startDt, DateTime endDt)
        {
            return _deviceAlarmDAL.SelectByStartDate( startDt, endDt);
        }
        public List<DeviceAlarmEntity> SelectByDateANDAlarmName(string dateStr, string alarmName)
        {
            return _deviceAlarmDAL.SelectByDateANDAlarmName(dateStr, alarmName);
        }
        public List<DeviceAlarmEntity> SelectByDate(string deviceName, DateTime startDt, DateTime endDt)
        {
            return _deviceAlarmDAL.SelectByDate(deviceName, startDt, endDt);
        }

        public List<DeviceAlarmEntity> SelectByType(string alarmType)
        {
            return _deviceAlarmDAL.SelectByType(alarmType);
        }

        public List<DeviceAlarmEntity> SelectByDevice(string deviceName)
        {
            return _deviceAlarmDAL.SelectByDevice(deviceName);
        }
    }
}
