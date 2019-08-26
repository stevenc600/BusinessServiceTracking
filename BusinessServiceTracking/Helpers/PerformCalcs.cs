using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BusinessServiceTracking.Helpers
{
    public static class PerformCalcs
    {
        // Example how to call
        // PerformCalcs.GetTableCount("employees", "Null");

        public static int GetTableCount(string tableName)
        {
            string stmt = string.Format("SELECT COUNT(*) FROM {0}", tableName);
            string ConnectionString = null;

            // Connection string while only having the one database, if I have addtional databases will need to pass in the connection string
            ConnectionString = "data source=DESKTOP-RT89R4A\\sqlexpress;initial catalog=FinanceModelling;integrated security=True";

           
            int count = 0;
            try
            {

                using (SqlConnection thisConnection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmdCount = new SqlCommand(stmt, thisConnection))
                    {
                        thisConnection.Open();
                        count = (int)cmdCount.ExecuteScalar();
                    }
                }
                return count;
            }
            catch (Exception ex)
            {
                // VDBLogger.LogError(ex);
                return 0;
            }
        }


        // Create connection object to database
        public static object ConnectToDB()
        {
           // string stmt = string.Format("SELECT COUNT(*) FROM {0}", tablename);
            string ConnectionString = null;

            // Connection string while only having the one database, if I have addtional databases will need to pass in the connection string
            ConnectionString = "data source=DESKTOP-RT89R4A\\sqlexpress;initial catalog=FinanceModelling;integrated security=True";

                       
            try
            {

                using (SqlConnection thisConnection = new SqlConnection(ConnectionString))
                {

                    
                    return (thisConnection);
                }
                
            }
            catch (Exception ex)
            {
                // VDBLogger.LogError(ex);
                return 0;
            }
        }

        // used to add costs of table and column
        public static int ExecuteStoredProcedure(string ProcedureName)
        {
           // string stmt = string.Format("SELECT Sum(AnnualSalary) FROM {0}",tableName);
            string ConnectionString = null;

            // Connection string while only having the one database, if I have addtional databases will need to pass in the connection string
            ConnectionString = "data source=DESKTOP-RT89R4A\\sqlexpress;initial catalog=FinanceModelling;integrated security=True";

            decimal total = 0;
            try
            {

                using (SqlConnection thisConnection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(ProcedureName, thisConnection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@returnvalue", 1.00);

                        thisConnection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                if (reader.Read())
                                {
                                    //returns an array
                                    decimal EmpSalary = reader.GetDecimal(0);
                                }
                            }


                            thisConnection.Close();





                        };
                    }
                    return 1;
                }
            }
            catch (Exception ex)
            {
                // VDBLogger.LogError(ex);
                return 0;
            }
        }


    }
}