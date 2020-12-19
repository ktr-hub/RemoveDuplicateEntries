using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace adoDemo
{
    public class AdoNet
    {
        
         public static string connectionString = @"Data Source=(LocalDb)\Ktr;Initial Catalog=AddressBookSystem;Integrated Security=True";
         public static SqlConnection connection = new SqlConnection(connectionString);
         

        public static void selectUniqueRecords()
        {
            using (connection)
            {
                try
                {
                    string query = "select * from duplicateEntry";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                    sqlDataAdapter.SelectCommand = command;
                    
                    DataSet ds = new DataSet();
                    sqlDataAdapter.Fill(ds);
                    sqlDataAdapter.Dispose();
                    command.Dispose();

                    
                    for(int i=0;i<ds.Tables[0].Rows.Count;i++)
                    {
                        Console.WriteLine(ds.Tables[0].Rows[i].ItemArray[0]+" "+ ds.Tables[0].Rows[i].ItemArray[1]+" "+ ds.Tables[0].Rows[i].ItemArray[2]);
                    }

                    query = "delete from duplicateEntry";
                    command = new SqlCommand(query, connection);
                    int y = command.ExecuteNonQuery();
                   

                    Console.WriteLine("Unique");
                    string[] columns = { "name", "address", "email" };
                    DataTable dataTable = ds.Tables[0].DefaultView.ToTable(true,columns);

                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        Console.WriteLine(dataTable.Rows[i].ItemArray[0] + " " + dataTable.Rows[i].ItemArray[1] + " " + dataTable.Rows[i].ItemArray[2]);
                        query = @"insert into duplicateEntry(name,address,email) values('"+dataTable.Rows[i].ItemArray[0].ToString()+"','"+dataTable.Rows[i].ItemArray[1].ToString()+"','"+dataTable.Rows[i].ItemArray[2].ToString()+"')";
                        command = new SqlCommand(query, connection);
                        int x= command.ExecuteNonQuery();
                    }


                    


                }
                catch(Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }

    }
}
