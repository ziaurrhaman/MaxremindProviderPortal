using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

/// <summary>
/// Summary description for DBManager
/// </summary>
public class DBManager
{
    public static SqlConnection _connection;
    public static SqlCommand _command;
    public static SqlDataReader _reader;
    public static SqlDataAdapter _dataAdapter;
    public List<SqlParameter> Parameters = new List<SqlParameter>();
    public static string _connectionString = "DefaultConnectionString";
    SqlTransaction _sqlTransaction;
     
    public DBManager()
    {
        //
        // TODO: Add constructor logic here
        //
    }

	public DBManager(SqlTransaction sqlTransaction = null)
	{
        _sqlTransaction = sqlTransaction;
    }

    public DBManager(string connectionStringName, SqlTransaction sqlTransaction = null)
    {
        _connectionString = connectionStringName;
        _sqlTransaction = sqlTransaction;
    }

    public static void CreateConnection()
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings[_connectionString].ConnectionString;
        _connection = new SqlConnection(ConnectionString);
        _connection.Open();
    }

    public static void CloseConnection()
    {
        _connection.Close();
        _connection.Dispose();
    }

    public void AddParameter(string parameterName, object value, SqlDbType sqlDbType, int size)
    {
            SqlParameter parameter = new SqlParameter(parameterName, sqlDbType, size);
            parameter.Value = value;

            Parameters.Add(parameter);      
    }

    public void AddParameter(string parameterName, object value, SqlDbType sqlDbType, int size,ParameterDirection parameterDirection)
    {
        SqlParameter parameter = new SqlParameter(parameterName, sqlDbType, size);
        parameter.Value = value;
        parameter.Direction = parameterDirection;
        Parameters.Add(parameter);
    }

    public void AddParameter(string parameterName, object value)
    {
        SqlParameter parameter = new SqlParameter(parameterName,value);
        Parameters.Add(parameter);
    }


    public int ExecuteNonQuery(string procedureName)
    {
        int result = 0;

        try
        {
            CreateConnection();
            _command = new SqlCommand(procedureName, _connection);
            if (Parameters.Count != 0)
            {
                for (int i = 0; i < Parameters.Count; i++)
                {
                    _command.Parameters.Add(Parameters[i]);
                }

            }
            _command.CommandType = CommandType.StoredProcedure;
            result = _command.ExecuteNonQuery();
            CloseConnection();
            _command.Dispose();
        }
        catch (Exception)
        {
            CloseConnection();
            _command.Dispose();
            throw;
        }

        return result;
    }

    public SqlDataReader ExecuteReader(string procedureName)
    {
        

        SqlDataReader reader;

        try
        {
            CreateConnection();
            _command = new SqlCommand(procedureName, _connection);
            if (Parameters.Count != 0)
            {
                for (int i = 0; i < Parameters.Count; i++)
                {
                    _command.Parameters.Add(Parameters[i]);
                }

            }
            _command.CommandType = CommandType.StoredProcedure;
            reader = _command.ExecuteReader(CommandBehavior.CloseConnection);
            CloseConnection();
            _command.Dispose();
        }
        catch (Exception)
        {
            CloseConnection();
            _command.Dispose();
            throw;
        }

        return reader;
    }


    public DataSet ExecuteDataSet(string procedureName)
    {
        

        DataSet dataSet = new DataSet();

        try
        {
            CreateConnection();
            _command = new SqlCommand(procedureName, _connection);
            if (Parameters.Count != 0)
            {
                for (int i = 0; i < Parameters.Count; i++)
                {
                    _command.Parameters.Add(Parameters[i]);    
                }
                
            }
            _command.CommandType = CommandType.StoredProcedure;
            _dataAdapter = new SqlDataAdapter(_command);
            _dataAdapter.Fill(dataSet);
            CloseConnection();
            _command.Dispose();
            _dataAdapter.Dispose();
        }
        catch (Exception)
        {
            CloseConnection();
            _dataAdapter.Dispose();
            _command.Dispose();
            throw;
        }

        return dataSet;
    }

    public DataTable ExecuteDataTable(string procedureName)
    {
              

        DataTable dataTable = new DataTable();

        try
        {
            CreateConnection();
            _command = new SqlCommand(procedureName, _connection);
            if (Parameters.Count != 0)
            {
                for (int i = 0; i < Parameters.Count; i++)
                {
                    _command.Parameters.Add(Parameters[i]);
                }

            }
            _command.CommandType = CommandType.StoredProcedure;
            _dataAdapter = new SqlDataAdapter(_command);
            _dataAdapter.Fill(dataTable);
            CloseConnection();
            _command.Dispose();
            _dataAdapter.Dispose();
        }
        catch (Exception)
        {
            CloseConnection();
            _dataAdapter.Dispose();
            _command.Dispose();
            throw;
        }

        return dataTable;
    }


    public string ExecuteScalar(string procedureName)
    {
        string result = "";

        try
        {
            CreateConnection();
            _command = new SqlCommand(procedureName, _connection);
            if (Parameters.Count != 0)
            {
                for (int i = 0; i < Parameters.Count; i++)
                {
                    _command.Parameters.Add(Parameters[i]);
                }

            }
            _command.CommandType = CommandType.StoredProcedure;
            result = _command.ExecuteScalar().ToString();
            CloseConnection();
            _command.Dispose();
        }
        catch (Exception)
        {
            CloseConnection();
            _command.Dispose();
            throw;
        }

        return result;
    }


    


}