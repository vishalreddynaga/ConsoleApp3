/*
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.IO;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            String line;
            List<string> a = new List<string>();
            StreamWriter sw = new StreamWriter(@"C:\Users\vnaga\Videos\MoshVideos\GetValuesFromTables.txt");
            StreamReader sr = new StreamReader(@"C:\Users\vnaga\Videos\MoshVideos\ListOfTables.txt");
          
            while ((line = sr.ReadLine()) != null)
            {
                a.Add(line);
            }
            SqlConnection cnn = new SqlConnection("Data Source=VISHALSURFACEBO;Initial Catalog=AdventureWorksDW2019;User ID=sa;Password=Saibaba123@");

            List<string> aaa = new List<string>();
            List<string> g = new List<string>();
            foreach (string aa in a)
            {
                aaa.Add(aa);

                cnn.Open();
                String ab = "select top 1 * from " + aa + "";
                SqlCommand command = new SqlCommand(ab, cnn);

            SqlDataReader datareaderr = command.ExecuteReader();
                while (datareaderr.Read())
                { 
                        for (int iiii = 0; iiii <= datareaderr.FieldCount - 1; iiii++)
                        {
                            aaa.Add(datareaderr.GetValue(iiii).ToString());
                        }
                }
                command.Dispose();
                cnn.Close();
            }
            foreach (string qw in aaa)
              
            {
                sw.WriteLine(qw);
            }
            sr.Close();
            sw.Close();
        }

    }
}
*/





using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp3
{


    class Program
    {
        static void Main(string[] args)
        {
            String line;
            List<string> a = new List<string>();
            StreamWriter sw = new StreamWriter(@"C:\Users\vnaga\Videos\MoshVideos\GetValuesFromTablesss.txt");
            StreamReader sr = new StreamReader(@"C:\Users\vnaga\Videos\MoshVideos\ListOfTables.txt");

            while ((line = sr.ReadLine()) != null)
            {
                a.Add(line);
            }
            foreach (string aa in a)
            {
                var sortedNames = GetColumnNames("Data Source=VISHALSURFACEBO;Initial Catalog=AdventureWorksDW2019;User ID=sa;Password=Saibaba123@", aa);
               Console.WriteLine("TableNme "+aa);
                // Console.WriteLine("");
                foreach (var columnName in sortedNames)
                {
                   Console.WriteLine(columnName);
                  //  sw.WriteLine(columnName);
                }
             //  Console.WriteLine("");

               

            }
            Console.ReadKey();

            sr.Close();
            sw.Close();


            IEnumerable<string> GetColumnNames(string conStr, string tableName)
            {
                var result = new List<string>();
                using (var sqlCon = new SqlConnection(conStr))
                {

                    sqlCon.Open();
                    var sqlCmd = sqlCon.CreateCommand();
                    sqlCmd.CommandText = "select * from " + tableName + " where 1=0";  // No data wanted, only schema
                    sqlCmd.CommandType = CommandType.Text;

                    var sqlDR = sqlCmd.ExecuteReader();
                    var dataTable = sqlDR.GetSchemaTable();

                    foreach (DataRow row in dataTable.Rows)
                    {
                        result.Add(row.Field<string>("ColumnName"));
                      
                    }

                    
                }

                return result;
            }
           
        }
    }
}
