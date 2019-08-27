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

        // used to return calculations in Decimal (Money) of any stored procedure as a single return value
        public static decimal StoredProcedureRetDecimal(string ProcedureName)
        {
            string ConnectionString = null;
            decimal ReturnDecimal = 0;

            // Connection string while only having the one database, if I have addtional databases will need to pass in the connection string
            ConnectionString = "data source=DESKTOP-RT89R4A\\sqlexpress;initial catalog=FinanceModelling;integrated security=True";

            
            try
            {

                using (SqlConnection thisConnection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(ProcedureName, thisConnection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        //not required
                       // command.Parameters.AddWithValue("@returnvalue", 1.00);

                        thisConnection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                if (reader.Read())
                                {
                                    //returns an array
                                    ReturnDecimal = reader.GetDecimal(0);
                                }
                            }


                            thisConnection.Close();





                        };
                    }
                    return ReturnDecimal;
                }
            }
            catch (Exception ex)
            {
                // VDBLogger.LogError(ex);
                return 0;
            }
        }

        // get both the service and the cost based on a stored procedure
        public static decimal StoredProcedureReturnServiceAndCost(string ProcedureName)
        {
            string ConnectionString = null;
            decimal ReturnDecCost = 0;
            string ReturnService;

            // Connection string while only having the one database, if I have addtional databases will need to pass in the connection string
            ConnectionString = "data source=DESKTOP-RT89R4A\\sqlexpress;initial catalog=FinanceModelling;integrated security=True";


            try
            {

                using (SqlConnection thisConnection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(ProcedureName, thisConnection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        //not required.
                       // command.Parameters.AddWithValue("@returnvalue", 1.00);

                        thisConnection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            int counter = 4;

                           // while (reader.Read())
                            //{
                                //get rows
                              //  counter++;
                            //}
                            
                            string[,] RetrunArray = new string[counter,2];



                            
                            


                            int innerCounter = 0;
                            while (reader.Read())
                            {
                                
                                    //returns an array
                                    ReturnService = reader.GetString(0);
                                    ReturnDecCost = reader.GetDecimal(1);
                                    
                                    string ReturnStringCost = Convert.ToString(ReturnDecCost);

                                    RetrunArray[innerCounter,innerCounter] = ReturnService;
                                    RetrunArray[innerCounter, 1] = ReturnStringCost;


                                innerCounter++;

                                // need to add to viewbag




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