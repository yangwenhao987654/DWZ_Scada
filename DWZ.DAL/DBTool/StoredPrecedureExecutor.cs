using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace AutoTF
{
    public class StoredPrecedureExecutor
    {
        private string connectionString;
        public StoredPrecedureExecutor(string connectionString)
        {
            this.connectionString = connectionString;
        }
 
       /// <summary>
       /// 执行失败返回-1
       /// </summary>
       /// <param name="storedProcedureName"></param>
       /// <param name="parameters"></param>
       /// <returns></returns>
        public static int Execute(string storedProcedureName,out string msg, SqlParameter[] parameters = null)
        {
            try
            {
                msg = "";
                using(SqlConnection connection = new SqlConnection(DbConfigManager.ConnectionStr))
                {
                    using(SqlCommand command = new SqlCommand(storedProcedureName, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        if(parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }
                        connection.Open();
                        return command.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception e)
            {
                msg = e.Message;
                return -1;
            }
        }
    }
}
