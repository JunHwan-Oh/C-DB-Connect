using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("asdf");

            string svrName = "your_ip";
            string userId = "your_id";
            string userPw = "your_pw";

            // Description
            // this is normally setting Oracle SE version. if you have used XE version, you have to change SERVICE_NAME orcl to XE.

            string connectionString = string.Format("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={0})(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));User Id={1};Password={2};", svrName, userId, userPw);
            //string connectionString = string.Format("user id={0};password={1}; data source={2}:1521/orcl", userId, userPw, svrName);

            using (OracleConnection oracleConnection =
                new OracleConnection(connectionString))
            {
                oracleConnection.Open();

                // Select - DataTable
                DataSet ds = new DataSet();
                OracleDataAdapter da = new OracleDataAdapter("SELECT * FROM test1", oracleConnection);
                da.Fill(ds, "test1");

                DataTable dt = ds.Tables["test1"];
                foreach (DataRow dr in dt.Rows)
                {
                    Console.WriteLine(string.Format("NUM = {0}, FIRST = {1}, SECOND = {2}", dr["NUM"], dr["FIRST"], dr["SECOND"]));
                }



                #region Insert, Update, Delete, Select - ExecuteScalar
                /*

                // Create
                OracleCommand insertCommand = new OracleCommand();
                insertCommand.Connection = oracleConnection;
                insertCommand.CommandText = "INSERT INTO mytable(id, NAME, age, DESCRIPTION) VALUES (:id, :NAME, :age, :DESCRIPTION)";

                insertCommand.Parameters.Add("id", OracleDbType.Int32);
                insertCommand.Parameters.Add("NAME", OracleDbType.Varchar2, 50);
                insertCommand.Parameters.Add("age", OracleDbType.Int32);
                insertCommand.Parameters.Add("DESCRIPTION", OracleDbType.Varchar2, 150);

                string nameValue = "Name" + Guid.NewGuid().ToString();
                insertCommand.Parameters[0].Value = (int)DateTime.Now.Ticks;
                insertCommand.Parameters[1].Value = nameValue;
                insertCommand.Parameters[2].Value = 10;
                insertCommand.Parameters[3].Value = nameValue + "_Description";

                int affected = insertCommand.ExecuteNonQuery();
                Console.WriteLine("# of affected row: " + affected);


                // Update
                OracleCommand updateCommand = new OracleCommand();
                updateCommand.Connection = oracleConnection;
                updateCommand.CommandText = "UPDATE mytable SET DESCRIPTION = :DESCRIPTION WHERE NAME = :NAME";

                updateCommand.Parameters.Add("NAME", OracleDbType.Varchar2, 50);
                updateCommand.Parameters.Add("DESCRIPTION", OracleDbType.Varchar2, 150);

                updateCommand.Parameters[0].Value = nameValue;
                updateCommand.Parameters[1].Value = nameValue + "_Description2";

                affected = updateCommand.ExecuteNonQuery();
                Console.WriteLine("# of affected row: " + affected);


                // Select - ExecuteScalar
                OracleCommand selectCommand = new OracleCommand();
                selectCommand.Connection = oracleConnection;
                selectCommand.CommandText = "SELECT count(*) FROM mytable";

                object result = selectCommand.ExecuteScalar();
                Console.WriteLine("# of records: " + result);


                // Delete
                OracleCommand deleteCommand = new OracleCommand();
                deleteCommand.Connection = oracleConnection;
                deleteCommand.CommandText = "DELETE FROM mytable WHERE NAME = :NAME";

                deleteCommand.Parameters.Add("NAME", OracleDbType.Varchar2, 50);
                deleteCommand.Parameters[0].Value = nameValue;

                affected = deleteCommand.ExecuteNonQuery();
                Console.WriteLine("# of affected row: " + affected);

                */

                #endregion
            }
        }
    }
}