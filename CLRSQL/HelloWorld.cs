using System;
using System.Data;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Data.SqlClient;

namespace CLRSQL
{
    public class HelloWorld
    {
        [Microsoft.SqlServer.Server.SqlProcedure]

        public static void FirstProc(out string text)
        {
            SqlContext.Pipe.Send("Hello World!!!" + Environment.NewLine);
            text = "Hello World!";

            SqlConnection con = new SqlConnection("context connection=true");
            using (con)
            {
                con.Open();
                using (var sqlTrans = con.BeginTransaction()) //one transaction instead of many from each insert implicit
                {
                    string cmdText = @"if object_id(N'dbo.test_clr',N'U') is null
                    	create table dbo.test_clr (
	                    	col1 int
	                    	,col2 nvarchar(100)
	                        )";
                    using (var cmd01 = new SqlCommand(cmdText, con, sqlTrans))
                    {
                        cmd01.ExecuteNonQuery();
                    }

                    cmdText = @"INSERT INTO dbo.test_clr ([col1],[col2]) VALUES (@a,@b)";
                    using (var cmd = new SqlCommand(cmdText, con, sqlTrans))
                    {
                        var aField = cmd.Parameters.Add("@a", SqlDbType.Int);
                        var bField = cmd.Parameters.Add("@b", SqlDbType.NVarChar, 100);

                        //same for all
                        aField.Value = 307;
                        bField.Value = "bFld-66";
                        cmd.ExecuteNonQuery();
                    }
                    sqlTrans.Commit();
                }
                con.Close();
            }

        }
    }
}
