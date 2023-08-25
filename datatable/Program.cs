using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datatable
{
    public class Program
    {
        static void Main(string[] args)
        {/*
            try 
            {

                DataTable dt = new DataTable("employees");

                DataColumn col = new DataColumn("id");
                col.Caption = "Emp_ID";
                col.DataType = typeof(int);
                col.AllowDBNull = false;
                dt.Columns.Add(col);    

                DataColumn col2 = new DataColumn("name");
                col2.Caption = "Emp_name";
                col2.DataType = typeof(string);
               col2.MaxLength = 50;
                dt.Columns.Add(col2);


                DataRow dr = dt.NewRow();
                dr["id"] = 1;
                dr["name"] = "virat";
                dt.Rows.Add(dr);
                dt.Rows.Add(2,"Rohit");
                dt.Rows.Add(3,"Gill");

                foreach (DataRow row in dt.Rows) 
                {
                    Console.WriteLine(row[0] +" " + row[1]);
                }
            }
            catch (Exception ex) { 
             
            Console.WriteLine(ex.Message);
            }*/
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConnection"].ConnectionString))
            using (var cmd = new SqlCommand("spData", con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                da.Fill(table);
            }
         foreach (DataRow dr in table.Rows) { Console.WriteLine("{0} {1}", dr[0], dr[1]); }
        }
    }
}
