using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAAutoFramework.Helpers
{
    public static class DataHelperExtensions
    {
        public static SqlConnection BDConnect(this SqlConnection sqlConnection, string connectionString)
        {
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                return sqlConnection;
            }
            catch(Exception e)
            {
               throw;
            }

            return null;
        }

        public static void BDClose(this SqlConnection sqlConnection)
        {
            try
            {
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public static DataTable ExecuteQuery(this SqlConnection sqlConnection, string queryString)
        {
            DataSet dataset;
            try
            {
                if (sqlConnection == null || ((sqlConnection != null && (sqlConnection.State == ConnectionState.Closed || sqlConnection.State == ConnectionState.Broken))))
                {
                    sqlConnection.Open();
                }

                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = new SqlCommand(queryString, sqlConnection);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;

                dataset = new DataSet();
                dataAdapter.Fill(dataset, "table");
                sqlConnection.Close();
                return dataset.Tables["table"];

            }
            catch (Exception e)
            {
                dataset = null;
                sqlConnection.Close();
                return null;
                throw;
            }

            finally
            {
                sqlConnection.Close();
                dataset = null;
            }


        }

    }


}
