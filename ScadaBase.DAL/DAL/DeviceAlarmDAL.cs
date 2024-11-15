using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogTool;
using ScadaBase.DAL.DBContext;
using ScadaBase.DAL.Entity;

namespace ScadaBase.DAL.BLL
{
    public interface IDeviceAlarmDAL
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
        /// 根据开始时间和结束时间查询
        /// </summary>
        /// <param name="startDt">开始时间</param>
        /// <param name="endDt">结束时间</param>
        /// <returns></returns>
        List<DeviceAlarmEntity> SelectByStartDate(DateTime startDt, DateTime endDt);

        /// <summary>
        /// 根据报警日期和报警名称查询
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

       Task<bool> Insert(DeviceAlarmEntity entity);

   }

   public class DeviceAlarmDAL: IDeviceAlarmDAL
    {
        public List<DeviceAlarmEntity> SelectAll()
        {
            List<DeviceAlarmEntity> list = new List<DeviceAlarmEntity>();
            using (MyDbContext db = new MyDbContext())
            {
                list =  db.tbDeviceAlarms.ToList();
            }

            return list;
        }

        public List<DeviceAlarmEntity> SelectByName(string alarmName)
        {
            List<DeviceAlarmEntity> list = new List<DeviceAlarmEntity>();
            using (MyDbContext db = new MyDbContext())
            {
                list = db.tbDeviceAlarms
                    .Where(r=>r.AlarmInfo==alarmName)
                    .ToList();
            }

            return list;
        }

        public List<DeviceAlarmEntity> SelectByDate(string dateStr)
        {
            List<DeviceAlarmEntity> list = new List<DeviceAlarmEntity>();
            using (MyDbContext db = new MyDbContext())
            {
                list = db.tbDeviceAlarms
                    .Where(r => r.AlarmDateStr == dateStr)
                    .ToList();
            }

            return list;
        }

        public List<DeviceAlarmEntity> SelectByDate(string dateStr, string deviceName)
        {
            List<DeviceAlarmEntity> list = new List<DeviceAlarmEntity>();
            using (MyDbContext db = new MyDbContext())
            {
                list = db.tbDeviceAlarms
                    .Where(r => r.AlarmDateStr == dateStr && r.DeviceName==deviceName)
                    .ToList();
            }

            return list;
        }

        public List<DeviceAlarmEntity> SelectByStartDate(DateTime startDt, DateTime endDt)
        {
            List<DeviceAlarmEntity> list = new List<DeviceAlarmEntity>();
            using (MyDbContext db = new MyDbContext())
            {
                list = db.tbDeviceAlarms
                    .Where(r =>  r.AlarmTime > startDt && r.AlarmTime < endDt)
                    .ToList();
            }

            return list;
        }

        public List<DeviceAlarmEntity> SelectByDateANDAlarmName(string dateStr, string alarmName)
        {
            List<DeviceAlarmEntity> list = new List<DeviceAlarmEntity>();
            using (MyDbContext db = new MyDbContext())
            {
                list = db.tbDeviceAlarms
                    .Where(r => r.AlarmDateStr == dateStr && r.AlarmInfo == alarmName)
                    .ToList();
            }

            return list;
        }

        public List<DeviceAlarmEntity> SelectByDate(string deviceName, DateTime startDt, DateTime endDt)
        {
            List<DeviceAlarmEntity> list = new List<DeviceAlarmEntity>();
            using (MyDbContext db = new MyDbContext())
            {
                list = db.tbDeviceAlarms
                    .Where(r => r.DeviceName == deviceName && r.AlarmTime>startDt && r.AlarmTime<endDt)
                    .ToList();
            }

            return list;
        }

        public List<DeviceAlarmEntity> SelectByType(string alarmType)
        {
            List<DeviceAlarmEntity> list = new List<DeviceAlarmEntity>();
            using (MyDbContext db = new MyDbContext())
            {
                list = db.tbDeviceAlarms
                    .Where(r => r.AlarmType == alarmType )
                    .ToList();
            }

            return list;
        }

        public List<DeviceAlarmEntity> SelectByDevice(string deviceName)
        {
            List<DeviceAlarmEntity> list = new List<DeviceAlarmEntity>();
            using (MyDbContext db = new MyDbContext())
            {
                list = db.tbDeviceAlarms
                    .Where(r => r.DeviceName == deviceName)
                    .ToList();
            }
            return list;
        }

        public async Task<bool> Insert(DeviceAlarmEntity entity)
        {
            try
            {
                using (MyDbContext db = new MyDbContext())
                {
                    db.tbDeviceAlarms.Add(entity);
                    await db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
               LogMgr.Instance.Error($"插入报警信息错误:{ex.Message}");
               return false;
            }

            return true;
        }
    }
}
