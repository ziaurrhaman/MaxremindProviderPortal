using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public class DB
{
    
    public static SqlConnection MyConnection;
    public static SqlCommand MyCommand;
    public static SqlDataReader MyReader;
    public static SqlDataAdapter da;
    /// <summary>
    /// Connect
    /// </summary>
    /// <returns></returns>
    public static void Connect()
    {
       
        string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;
        MyConnection = new SqlConnection(ConnectionString);
        MyConnection.Open();
    }
    
    
    ///Execute
    ///
    public static bool executeQuery(string query)
    {
        try
        {
            Connect();

            MyCommand = MyConnection.CreateCommand();
            MyCommand.CommandText = query;
            MyCommand.CommandType = CommandType.Text;
            int result = MyCommand.ExecuteNonQuery();
            MyConnection.Close();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public static SqlDataReader GetData(string query)
    {
        try
        {
            Connect();

            MyCommand = MyConnection.CreateCommand();
            MyCommand.CommandText = query;
            MyCommand.CommandType = CommandType.Text;

            return MyCommand.ExecuteReader(CommandBehavior.CloseConnection);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public static object GetValue(string query)
    {
        try
        {
            Connect();

            MyCommand = MyConnection.CreateCommand();
            MyCommand.CommandText = query;
            MyCommand.CommandType = CommandType.Text;

            object value = MyCommand.ExecuteScalar();
            MyConnection.Close();
            if (value == null)
            {
                value = "";
            }
            return value;

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public static int GetLastID(string tableName, string idColumnName)
    {
        try
        {
            Connect();

            string query = "Select Top 1 " + idColumnName + " From " + tableName + " Order By " + idColumnName + " desc";

            MyCommand = MyConnection.CreateCommand();
            MyCommand.CommandText = query;
            MyCommand.CommandType = CommandType.Text;

            object value = MyCommand.ExecuteScalar();
            MyConnection.Close();
            return Convert.ToInt32(value);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public static bool varifyRecord(string query)
    {
        try
        {
            Connect();
            MyCommand = MyConnection.CreateCommand();
            MyCommand.CommandText = query;
            MyCommand.CommandType = CommandType.Text;
            int result = Convert.ToInt32(MyCommand.ExecuteScalar());
            MyConnection.Close();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public static long GetTotalRecords(string query)
    {
        try
        {
            Connect();
            MyCommand = MyConnection.CreateCommand();
            MyCommand.CommandText = query;
            MyCommand.CommandType = CommandType.Text;

            SqlDataReader dr = MyCommand.ExecuteReader(CommandBehavior.CloseConnection);
            long total = 0;

            if (dr.Read())
            {
                total = Convert.ToInt64(dr[0].ToString());
                dr.Close();
            }
            return total;

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}