using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;

namespace MarshfieldTimeClock_V1._1
{
    public class DBMaster
    {
        
        private SqlConnection conn;
        

        /// <summary>
        /// Database connection
        ///     gets connection, opens and returns connection
        /// </summary>
        /// <returns></returns>
        public SqlConnection getConnection()
        {
            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                conn = new SqlConnection(connStr);
                conn.Open();
                return conn;
            }
            catch(Exception exc)
            {
                System.Diagnostics.Debug.WriteLine("######### DBMASTER getConnection():  " + exc.Message);
                throw;
            }
        }


        /// <summary>
        /// Creates a command
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public SqlDataReader getSpReader(string spName, string spParameter, string value)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(spName);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(spParameter, value + '%');
                cmd.Connection = getConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                return reader;
            }
            catch(Exception exc)
            {
                System.Diagnostics.Debug.WriteLine("######### DBMASTER getSpReader():  " + exc.Message);
                throw;
            }
        }
        public void updateRecord(string clockOutValue, string dateOutValue, string workLunchBITValue, string employeeIdValue)
        {
            int rowsAffected = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("spClockOutRecord");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ClockOut", clockOutValue);
                cmd.Parameters.AddWithValue("@DateOut", dateOutValue);
                cmd.Parameters.AddWithValue("@WorkLunch", workLunchBITValue);
                cmd.Parameters.AddWithValue("@EmployeeID", employeeIdValue);
                cmd.Connection = getConnection();
                rowsAffected = cmd.ExecuteNonQuery();
                System.Diagnostics.Debug.WriteLine("######### DBMASTER SQL Update rowsAffected: " + rowsAffected);
                closeConnection();
            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine("######### DBMASTER updateRecord():  " + exc.Message);
                throw;
            }
        }
        public void insertNewRecord(string workIdValue, string employeeIdValue,string roleValue, string clockInValue, string dateInValue)
        {
            int rowsAffected=0;
            try
            {
                SqlCommand cmd = new SqlCommand("spInsertRecord");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@WorkID", workIdValue);
                cmd.Parameters.AddWithValue("@EmployeeID", employeeIdValue);
                cmd.Parameters.AddWithValue("@Role", roleValue);
                cmd.Parameters.AddWithValue("@ClockIn", clockInValue);
                cmd.Parameters.AddWithValue("@DateIn", dateInValue);
                cmd.Connection = getConnection();
                rowsAffected = cmd.ExecuteNonQuery();
                System.Diagnostics.Debug.WriteLine("######### DBMASTER SQL INSERT rowsAffected: " + rowsAffected);
                closeConnection();
            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine("######### DBMASTER insertNewRecord():  " + exc.Message);
                throw;
            }
        }

        /// <summary>
        /// Database Connection close
        /// </summary>
        public void closeConnection()
        {
            try
            {
                if (conn != null && conn.State == System.Data.ConnectionState.Open)
                {
                    this.conn.Close();
                }
            }
            catch(Exception exc)
            {
                System.Diagnostics.Debug.WriteLine("######### DBMASTE closeConnection():  " + exc.Message);
                throw;
            }

        }
        



    }
}