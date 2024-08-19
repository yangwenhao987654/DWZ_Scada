using System;
using AutoTF;
using System.Windows.Forms;

namespace DWZ_Scada
{

    public partial class DataClasses1DataContext : System.Data.Linq.DataContext
    {
        /// <summary>
        /// ���ع��췽�� ��ֹ�Զ����ɴ���
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
                MessageBox.Show("���ݿ����Ӵ���" + e.Message);
            }
        }
    }
}
