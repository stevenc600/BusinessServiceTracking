﻿using System;
using System.Collections;
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
        public static void ConnectToDB(Action<SqlConnection> connectionCallBack)
        {
           // string stmt = string.Format("SELECT COUNT(*) FROM {0}", tablename);
            string ConnectionString = null;
            SqlConnection thisConnection = null;

            // Connection string while only having the one database, if I have addtional databases will need to pass in the connection string
            ConnectionString = "data source=DESKTOP-RT89R4A\\sqlexpress;initial catalog=FinanceModelling;integrated security=True";

            try
            {

                thisConnection = new SqlConnection(ConnectionString);
                connectionCallBack(thisConnection);

            }
            catch (Exception ex)
            {
                // VDBLogger.LogError(ex);
                string ErrorString = ex.Message;
                throw;              
            }
            finally
            {

                if (thisConnection != null)
                    thisConnection.Dispose(); //will close the connection
            }
        }

        // used to return calculations in Decimal (Money) of any stored procedure as a single return value
        public static decimal StoredProcedureRetDecimal(string ProcedureName,int? RecordId)
        {
            //string ConnectionString = null;
            decimal ReturnDecimal = 0;

           // object test;
           // SqlConnection thisConnection = new SqlConnection();
           // test = ConnectToDB();

            ConnectToDB(delegate (SqlConnection thisConnection)
                {

                    try
                    {

                        using (SqlCommand command = new SqlCommand(ProcedureName, thisConnection))
                        {

                            if (RecordId != 0)
                            {
                                command.Parameters.Add("@RecordID", SqlDbType.VarChar).Value = RecordId;
                            }
                            command.CommandType = CommandType.StoredProcedure;

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
                    }
                    catch (Exception ex)
                    {
                        // VDBLogger.LogError(ex);
                        
                    }

                }
                );
            return ReturnDecimal;

        }

        // get both the service and the cost based on a stored procedure
        public static List<String> StoredProcedureReturnServiceAndCost(string ProcedureName)
        {
           
            decimal ReturnDecCost = 0;
            string ReturnService;
            List<string> resultList = new List<string>();
                                  

           // SqlConnection thisConnection = ConnectToDB(delegate (SqlConnection thisConnection);
            ConnectToDB(delegate (SqlConnection thisConnection)
            {
                try
                {


                    using (SqlCommand command = new SqlCommand(ProcedureName, thisConnection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        thisConnection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {



                            int innerCounter = 0;
                            while (reader.Read())
                            {

                                //returns an array
                                ReturnService = reader.GetString(0);
                                ReturnDecCost = reader.GetDecimal(1);

                                string ReturnStringCost = Convert.ToString(ReturnDecCost);

                                // build list to return
                                resultList.Add(ReturnService);
                                resultList.Add(ReturnStringCost);


                                innerCounter++;


                            }

                            thisConnection.Close();

                        };
                    }
                    

                }
                catch (Exception ex)
                {
                    // VDBLogger.LogError(ex);
                    
                }

            });

            return resultList;
        }
    }
}