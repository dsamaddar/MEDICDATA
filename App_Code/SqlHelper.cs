using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.IO;
using System.Xml;

public class SqlHelper
{
    private static void AttachParameters(SqlCommand command, SqlParameter[] commandParameters)
    {
        foreach (SqlParameter p in commandParameters)
        {
            if ((p.Direction == ParameterDirection.InputOutput) && (p.Value == null))
            {
                p.Value = DBNull.Value;
            }
            command.Parameters.Add(p);
        }
    }
    private static void AssignParameterValues(SqlParameter[] commandParameters, object[] parameterValues)
    {
        if ((commandParameters == null) || (parameterValues == null))
        {
            return;
        }
        if (commandParameters.Length != parameterValues.Length)
        {
            throw new ArgumentException("Parameter count does not match Parameter Value count.");
        }
        for (int i = 0, j = commandParameters.Length; i < j; i++)
        {
            commandParameters[i].Value = parameterValues[i];
        }
    }
    private static void PrepareCommand(SqlCommand command, SqlConnection connection, SqlTransaction transaction, CommandType commandType, string commandText, SqlParameter[] commandParameters)
    {
        if (connection.State != ConnectionState.Open)
        {
            connection.Open();
        }
        command.Connection = connection;
        command.CommandText = commandText;
        if (transaction != null)
        {
            command.Transaction = transaction;
        }
        command.CommandType = commandType;
        if (commandParameters != null)
        {
            AttachParameters(command, commandParameters);
        }
        return;
    }

    #region ExecuteNonQuery
    public static int ExecuteNonQuery(string connectionString, CommandType commandType, string commandText)
    {
        return ExecuteNonQuery(connectionString, commandType, commandText, (SqlParameter[])null);
    }

    public static int ExecuteNonQuery(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
    {
        using (SqlConnection cn = new SqlConnection(connectionString))
        {
            //                cn.Open();
            return ExecuteNonQuery(cn, commandType, commandText, commandParameters);
        }
    }
    public static int ExecuteNonQuery(string connectionString, string spName, params object[] parameterValues)
    {
        if ((parameterValues != null) && (parameterValues.Length > 0))
        {
            SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connectionString, spName);
            AssignParameterValues(commandParameters, parameterValues);
            return ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName, commandParameters);
        }
        else
        {
            return ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName);
        }
    }
    public static int ExecuteNonQuery(SqlConnection connection, CommandType commandType, string commandText)
    {
        return ExecuteNonQuery(connection, commandType, commandText, (SqlParameter[])null);
    }
    public static int ExecuteNonQuery(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
    {
        SqlCommand cmd = new SqlCommand();
        PrepareCommand(cmd, connection, (SqlTransaction)null, commandType, commandText, commandParameters);
        int retval = cmd.ExecuteNonQuery();
        cmd.Parameters.Clear();
        return retval;
    }
    public static int ExecuteNonQuery(SqlConnection connection, string spName, params object[] parameterValues)
    {
        if ((parameterValues != null) && (parameterValues.Length > 0))
        {
            SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connection.ConnectionString, spName);
            AssignParameterValues(commandParameters, parameterValues);
            return ExecuteNonQuery(connection, CommandType.StoredProcedure, spName, commandParameters);
        }
        else
        {
            return ExecuteNonQuery(connection, CommandType.StoredProcedure, spName);
        }
    }
    public static int ExecuteNonQuery(SqlTransaction transaction, CommandType commandType, string commandText)
    {
        return ExecuteNonQuery(transaction, commandType, commandText, (SqlParameter[])null);
    }
    public static int ExecuteNonQuery(SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
    {
        SqlCommand cmd = new SqlCommand();
        PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters);
        int retval = cmd.ExecuteNonQuery();
        cmd.Parameters.Clear();
        return retval;
    }

    public static int ExecuteNonQuery(SqlTransaction transaction, string spName, params object[] parameterValues)
    {
        if ((parameterValues != null) && (parameterValues.Length > 0))
        {
            SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(transaction.Connection.ConnectionString, spName);
            AssignParameterValues(commandParameters, parameterValues);
            return ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName, commandParameters);
        }
        else
        {
            return ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName);
        }
    }


    #endregion ExecuteNonQuery
    #region ExecuteDataSet
    public static DataSet ExecuteDataset(string connectionString, CommandType commandType, string commandText)
    {
        return ExecuteDataset(connectionString, commandType, commandText, (SqlParameter[])null);
    }
    public static DataSet ExecuteDataset(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
    {
        using (SqlConnection cn = new SqlConnection(connectionString))
        {
            //                cn.Open();
            return ExecuteDataset(cn, commandType, commandText, commandParameters);
        }
    }
    public static DataSet ExecuteDataset(string connectionString, string spName, params object[] parameterValues)
    {
        if ((parameterValues != null) && (parameterValues.Length > 0))
        {
            SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connectionString, spName);
            AssignParameterValues(commandParameters, parameterValues);
            return ExecuteDataset(connectionString, CommandType.StoredProcedure, spName, commandParameters);
        }
        else
        {
            return ExecuteDataset(connectionString, CommandType.StoredProcedure, spName);
        }
    }
    public static DataSet ExecuteDataset(SqlConnection connection, CommandType commandType, string commandText)
    {
        return ExecuteDataset(connection, commandType, commandText, (SqlParameter[])null);
    }
    public static DataSet ExecuteDataset(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
    {
        SqlCommand cmd = new SqlCommand();
        PrepareCommand(cmd, connection, (SqlTransaction)null, commandType, commandText, commandParameters);

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds);
        }
        catch { }
        cmd.Parameters.Clear();
        //Changes
        //connection.Close();
        return ds;
    }
    public static DataSet ExecuteDataset(SqlConnection connection, string spName, params object[] parameterValues)
    {
        if ((parameterValues != null) && (parameterValues.Length > 0))
        {
            SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connection.ConnectionString, spName);
            AssignParameterValues(commandParameters, parameterValues);
            return ExecuteDataset(connection, CommandType.StoredProcedure, spName, commandParameters);
        }
        else
        {
            return ExecuteDataset(connection, CommandType.StoredProcedure, spName);
        }
    }
    public static DataSet ExecuteDataset(SqlTransaction transaction, CommandType commandType, string commandText)
    {
        return ExecuteDataset(transaction, commandType, commandText, (SqlParameter[])null);
    }
    public static DataSet ExecuteDataset(SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
    {
        SqlCommand cmd = new SqlCommand();
        PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        cmd.Parameters.Clear();
        //transaction.Connection.Close();
        return ds;
    }
    public static DataSet ExecuteDataset(SqlTransaction transaction, string spName, params object[] parameterValues)
    {
        if ((parameterValues != null) && (parameterValues.Length > 0))
        {
            SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(transaction.Connection.ConnectionString, spName);
            AssignParameterValues(commandParameters, parameterValues);
            return ExecuteDataset(transaction, CommandType.StoredProcedure, spName, commandParameters);
        }
        else
        {
            return ExecuteDataset(transaction, CommandType.StoredProcedure, spName);
        }
    }
    #endregion ExecuteDataSet
    #region ExecuteReader
    private enum SqlConnectionOwnership
    {
        Internal,
        External
    }

    private static SqlDataReader ExecuteReader(SqlConnection connection, SqlTransaction transaction, CommandType commandType, string commandText, SqlParameter[] commandParameters, SqlConnectionOwnership connectionOwnership)
    {
        SqlCommand cmd = new SqlCommand();
        PrepareCommand(cmd, connection, transaction, commandType, commandText, commandParameters);
        SqlDataReader dr;
        if (connectionOwnership == SqlConnectionOwnership.External)
        {
            dr = cmd.ExecuteReader();
        }
        else
        {
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        cmd.Parameters.Clear();
        //connection.Close();
        return dr;
    }

    public static SqlDataReader ExecuteReader(string connectionString, CommandType commandType, string commandText)
    {
        return ExecuteReader(connectionString, commandType, commandText, (SqlParameter[])null);
    }

    public static SqlDataReader ExecuteReader(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
    {
        SqlConnection cn = new SqlConnection(connectionString);
        cn.Open();
        try
        {
            return ExecuteReader(cn, null, commandType, commandText, commandParameters, SqlConnectionOwnership.Internal);
        }
        catch
        {
            //                cn.Close();
            throw;
        }
    }

    public static SqlDataReader ExecuteReader(string connectionString, string spName, params object[] parameterValues)
    {
        if ((parameterValues != null) && (parameterValues.Length > 0))
        {
            SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connectionString, spName);
            AssignParameterValues(commandParameters, parameterValues);
            return ExecuteReader(connectionString, CommandType.StoredProcedure, spName, commandParameters);
        }
        else
        {
            return ExecuteReader(connectionString, CommandType.StoredProcedure, spName);
        }
    }

    public static SqlDataReader ExecuteReader(SqlConnection connection, CommandType commandType, string commandText)
    {
        return ExecuteReader(connection, commandType, commandText, (SqlParameter[])null);
    }

    public static SqlDataReader ExecuteReader(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
    {
        return ExecuteReader(connection, (SqlTransaction)null, commandType, commandText, commandParameters, SqlConnectionOwnership.External);
    }

    public static SqlDataReader ExecuteReader(SqlConnection connection, string spName, params object[] parameterValues)
    {
        if ((parameterValues != null) && (parameterValues.Length > 0))
        {
            SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connection.ConnectionString, spName);
            AssignParameterValues(commandParameters, parameterValues);
            return ExecuteReader(connection, CommandType.StoredProcedure, spName, commandParameters);
        }
        else
        {
            return ExecuteReader(connection, CommandType.StoredProcedure, spName);
        }
    }

    public static SqlDataReader ExecuteReader(SqlTransaction transaction, CommandType commandType, string commandText)
    {
        return ExecuteReader(transaction, commandType, commandText, (SqlParameter[])null);
    }

    public static SqlDataReader ExecuteReader(SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
    {
        return ExecuteReader(transaction.Connection, transaction, commandType, commandText, commandParameters, SqlConnectionOwnership.External);
    }

    public static SqlDataReader ExecuteReader(SqlTransaction transaction, string spName, params object[] parameterValues)
    {
        if ((parameterValues != null) && (parameterValues.Length > 0))
        {
            SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(transaction.Connection.ConnectionString, spName);
            AssignParameterValues(commandParameters, parameterValues);
            return ExecuteReader(transaction, CommandType.StoredProcedure, spName, commandParameters);
        }
        else
        {
            return ExecuteReader(transaction, CommandType.StoredProcedure, spName);
        }
    }

    #endregion ExecuteReader
    #region ExecuteScalar
    public static object ExecuteScalar(string connectionString, CommandType commandType, string commandText)
    {
        return ExecuteScalar(connectionString, commandType, commandText, (SqlParameter[])null);
    }

    public static object ExecuteScalar(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
    {
        using (SqlConnection cn = new SqlConnection(connectionString))
        {
            cn.Open();
            return ExecuteScalar(cn, commandType, commandText, commandParameters);
        }
    }

    public static object ExecuteScalar(string connectionString, string spName, params object[] parameterValues)
    {
        if ((parameterValues != null) && (parameterValues.Length > 0))
        {
            SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connectionString, spName);
            AssignParameterValues(commandParameters, parameterValues);
            return ExecuteScalar(connectionString, CommandType.StoredProcedure, spName, commandParameters);
        }
        else
        {
            return ExecuteScalar(connectionString, CommandType.StoredProcedure, spName);
        }
    }

    public static object ExecuteScalar(SqlConnection connection, CommandType commandType, string commandText)
    {
        return ExecuteScalar(connection, commandType, commandText, (SqlParameter[])null);
    }

    public static object ExecuteScalar(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
    {
        SqlCommand cmd = new SqlCommand();
        PrepareCommand(cmd, connection, (SqlTransaction)null, commandType, commandText, commandParameters);
        object retval = cmd.ExecuteScalar();
        cmd.Parameters.Clear();
        //connection.Close();
        return retval;

    }

    public static object ExecuteScalar(SqlConnection connection, string spName, params object[] parameterValues)
    {
        if ((parameterValues != null) && (parameterValues.Length > 0))
        {
            SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connection.ConnectionString, spName);
            AssignParameterValues(commandParameters, parameterValues);
            return ExecuteScalar(connection, CommandType.StoredProcedure, spName, commandParameters);
        }
        else
        {
            return ExecuteScalar(connection, CommandType.StoredProcedure, spName);
        }
    }

    public static object ExecuteScalar(SqlTransaction transaction, CommandType commandType, string commandText)
    {
        return ExecuteScalar(transaction, commandType, commandText, (SqlParameter[])null);
    }

    public static object ExecuteScalar(SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
    {
        SqlCommand cmd = new SqlCommand();
        PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters);
        object retval = cmd.ExecuteScalar();
        cmd.Parameters.Clear();
        return retval;
    }

    public static object ExecuteScalar(SqlTransaction transaction, string spName, params object[] parameterValues)
    {
        if ((parameterValues != null) && (parameterValues.Length > 0))
        {
            SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(transaction.Connection.ConnectionString, spName);
            AssignParameterValues(commandParameters, parameterValues);
            return ExecuteScalar(transaction, CommandType.StoredProcedure, spName, commandParameters);
        }
        else
        {
            return ExecuteScalar(transaction, CommandType.StoredProcedure, spName);
        }
    }

    #endregion ExecuteScalar
    #region ExecuteXmlReader
    public static XmlReader ExecuteXmlReader(SqlConnection connection, CommandType commandType, string commandText)
    {
        return ExecuteXmlReader(connection, commandType, commandText, (SqlParameter[])null);
    }

    public static XmlReader ExecuteXmlReader(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
    {
        SqlCommand cmd = new SqlCommand();
        PrepareCommand(cmd, connection, (SqlTransaction)null, commandType, commandText, commandParameters);
        XmlReader retval = cmd.ExecuteXmlReader();
        cmd.Parameters.Clear();
        //connection.Close();
        return retval;

    }

    public static XmlReader ExecuteXmlReader(SqlConnection connection, string spName, params object[] parameterValues)
    {
        if ((parameterValues != null) && (parameterValues.Length > 0))
        {
            SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connection.ConnectionString, spName);
            AssignParameterValues(commandParameters, parameterValues);
            return ExecuteXmlReader(connection, CommandType.StoredProcedure, spName, commandParameters);
        }
        else
        {
            return ExecuteXmlReader(connection, CommandType.StoredProcedure, spName);
        }
    }

    public static XmlReader ExecuteXmlReader(SqlTransaction transaction, CommandType commandType, string commandText)
    {
        return ExecuteXmlReader(transaction, commandType, commandText, (SqlParameter[])null);
    }

    public static XmlReader ExecuteXmlReader(SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
    {
        SqlCommand cmd = new SqlCommand();
        PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters);
        XmlReader retval = cmd.ExecuteXmlReader();
        cmd.Parameters.Clear();
        //transaction.Connection.Close();
        return retval;
    }

    public static XmlReader ExecuteXmlReader(SqlTransaction transaction, string spName, params object[] parameterValues)
    {
        if ((parameterValues != null) && (parameterValues.Length > 0))
        {
            SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(transaction.Connection.ConnectionString, spName);
            AssignParameterValues(commandParameters, parameterValues);
            return ExecuteXmlReader(transaction, CommandType.StoredProcedure, spName, commandParameters);
        }
        else
        {
            return ExecuteXmlReader(transaction, CommandType.StoredProcedure, spName);
        }
    }


    #endregion ExecuteXmlReader
}
public sealed class SqlHelperParameterCache
{
    #region private methods, variables, and constructors
    private SqlHelperParameterCache() { }
    private static Hashtable paramCache = Hashtable.Synchronized(new Hashtable());
    private static SqlParameter[] DiscoverSpParameterSet(string connectionString, string spName, bool includeReturnValueParameter)
    {
        using (SqlConnection cn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(spName, cn))
        {
            //                cn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            SqlCommandBuilder.DeriveParameters(cmd);
            if (!includeReturnValueParameter)
            {
                cmd.Parameters.RemoveAt(0);
            }
            SqlParameter[] discoveredParameters = new SqlParameter[cmd.Parameters.Count]; ;
            cmd.Parameters.CopyTo(discoveredParameters, 0);
            return discoveredParameters;
        }
    }

    private static SqlParameter[] CloneParameters(SqlParameter[] originalParameters)
    {
        SqlParameter[] clonedParameters = new SqlParameter[originalParameters.Length];
        for (int i = 0, j = originalParameters.Length; i < j; i++)
        {
            clonedParameters[i] = (SqlParameter)((ICloneable)originalParameters[i]).Clone();
        }

        return clonedParameters;
    }

    #endregion private methods, variables, and constructors
    #region caching functions
    public static void CacheParameterSet(string connectionString, string commandText, params SqlParameter[] commandParameters)
    {
        string hashKey = connectionString + ":" + commandText;
        paramCache[hashKey] = commandParameters;
    }

    public static SqlParameter[] GetCachedParameterSet(string connectionString, string commandText)
    {
        string hashKey = connectionString + ":" + commandText;
        SqlParameter[] cachedParameters = (SqlParameter[])paramCache[hashKey];
        if (cachedParameters == null)
        {
            return null;
        }
        else
        {
            return CloneParameters(cachedParameters);
        }
    }

    #endregion caching functions
    #region Parameter Discovery Functions

    public static SqlParameter[] GetSpParameterSet(string connectionString, string spName)
    {
        return GetSpParameterSet(connectionString, spName, false);
    }
    public static SqlParameter[] GetSpParameterSet(string connectionString, string spName, bool includeReturnValueParameter)
    {
        string hashKey = connectionString + ":" + spName + (includeReturnValueParameter ? ":include ReturnValue Parameter" : "");
        SqlParameter[] cachedParameters;
        cachedParameters = (SqlParameter[])paramCache[hashKey];
        if (cachedParameters == null)
        {
            cachedParameters = (SqlParameter[])(paramCache[hashKey] = DiscoverSpParameterSet(connectionString, spName, includeReturnValueParameter));
        }
        return CloneParameters(cachedParameters);
    }
    #endregion Parameter Discovery Functions
}