using LogTool;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaBase.DAL.Interceptor
{
    public class MyDbCommandInterceptor : DbCommandInterceptor
    {

        public override ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result, CancellationToken cancellationToken = default)
        {

            // 打印SQL语句
            var sql = command.CommandText;

            // 构造参数信息
            foreach (DbParameter parameter in command.Parameters)
            {
                sql += $"\nParameter: {parameter.ParameterName} = {parameter.Value} (Type: {parameter.DbType})";
            }

            // 输出到日志
            LogMgr.Instance.AddSQLLog($"SQL: {sql}");
            return base.ReaderExecutingAsync(command, eventData, result, cancellationToken);
        }
        public override ValueTask<InterceptionResult<int>> NonQueryExecutingAsync(DbCommand command, CommandEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            LogMgr.Instance.AddSQLLog($"SQL:{command.CommandText}");
            return base.NonQueryExecutingAsync(command, eventData, result, cancellationToken);
        }

        public override InterceptionResult<int> NonQueryExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<int> result)
        {
            // 打印SQL语句
            var sql = command.CommandText;

            // 构造参数信息
            foreach (DbParameter parameter in command.Parameters)
            {
                sql += $"\nParameter: {parameter.ParameterName} = {parameter.Value} (Type: {parameter.DbType})";
            }

            // 输出到日志
            LogMgr.Instance.AddSQLLog($"SQL: {sql}");
            return base.NonQueryExecuting(command, eventData, result);
        }

        public override int NonQueryExecuted(DbCommand command, CommandExecutedEventData eventData, int result)
        {
            // 打印SQL语句
            var sql = command.CommandText;

            // 构造参数信息
            foreach (DbParameter parameter in command.Parameters)
            {
                sql += $"\nParameter: {parameter.ParameterName} = {parameter.Value} (Type: {parameter.DbType})";
            }

            // 输出到日志
            LogMgr.Instance.AddSQLLog($"SQL: {sql}");
            return base.NonQueryExecuted(command, eventData, result);
        }

        public override InterceptionResult<DbDataReader> ReaderExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result)
        {
            var sql = command.CommandText;

            // 构造参数信息
            foreach (DbParameter parameter in command.Parameters)
            {
                sql += $"\nParameter: {parameter.ParameterName} = {parameter.Value} (Type: {parameter.DbType})";
            }

            // 输出到日志
            LogMgr.Instance.AddSQLLog($"SQL: {sql}");
            return base.ReaderExecuting(command, eventData, result);
        }
    }
}
