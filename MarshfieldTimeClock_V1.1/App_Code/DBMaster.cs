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
            string connStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            conn = new SqlConnection(connStr);
            conn.Open();
            return conn;
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
                // Create a command
                //this connection string is not safe. Use a stored procedure
                SqlCommand cmd = new SqlCommand(spName);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(spParameter, value + '%');
                cmd.Connection = this.getConnection();

                // read from db
                SqlDataReader reader = cmd.ExecuteReader();
                return reader;
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine("######### DBMASTER CATCH GETSPREADER" + e);

            }
            return null;
        }
        public void updateRecord(string clockOutValue, string dateOutValue, string workLunchBITValue, string employeeIdValue)
        {
            int rowsAffected = 0;
            try
            {
              
                //this connection string is not safe. Use a stored procedure
                SqlCommand cmd = new SqlCommand("spClockOutRecord");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ClockOut", clockOutValue);
                cmd.Parameters.AddWithValue("@DateOut", dateOutValue);
                cmd.Parameters.AddWithValue("@WorkLunch", workLunchBITValue);
                cmd.Parameters.AddWithValue("@EmployeeID", employeeIdValue);
                cmd.Connection = this.getConnection();
                rowsAffected = cmd.ExecuteNonQuery();
                closeConnection();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("######### DBMASTER CATCH UpdateRecord" + e);

            }
            System.Diagnostics.Debug.WriteLine("######### DBMASTER SQL Update rowsAffected: " + rowsAffected);
        }
        public void insertNewRecord(string workIdValue, string employeeIdValue, string clockInValue, string dateInValue)
        {
            int rowsAffected=0;
            try
            {
                // Create a command
                //this connection string is not safe. Use a stored procedure
                SqlCommand cmd = new SqlCommand("spInsertRecord");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@WorkID", workIdValue);
                cmd.Parameters.AddWithValue("@EmployeeID", employeeIdValue);
                cmd.Parameters.AddWithValue("@ClockIn", clockInValue);
                cmd.Parameters.AddWithValue("@DateIn", dateInValue);
                cmd.Connection = this.getConnection();
                rowsAffected = cmd.ExecuteNonQuery();
                closeConnection();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("######### DBMASTER CATCH InsertNewREcord" + e);

            }
            System.Diagnostics.Debug.WriteLine("######### DBMASTER SQL INSERT rowsAffected: " + rowsAffected);

        }

        /// <summary>
        /// Database Connection close
        /// </summary>
        public void closeConnection()
        {
            if (conn != null && conn.State == System.Data.ConnectionState.Open)
            {
                this.conn.Close();
            }
        }



    }
}