using System;
using AutoTF;
using System.Windows.Forms;

namespace DWZ_Scada
{

    public partial class DataClasses1DataContext : System.Data.Linq.DataContext
    {
        /// <summary>
        /// 重载构造方法 防止自动生成代码
        /// </summary>
        /// <param name="a"></param>
        public DataClasses1DataContext(int a = 1)
            : base(DbConfigManager.ConnectionStr, mappingSource)
        {
            try
            {
                OnCreated();
                CommandTimeout = 3;
            }
            catch (Exception e)
            {
                MessageBox.Show("数据库连接错误：" + e.Message);
            }
        }
    }
}
