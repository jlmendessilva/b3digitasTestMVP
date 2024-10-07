using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b3digitas.WS.Extension
{
    public class SQLBulkCopySqlServer
    {
        private readonly string _connectionString;

        public SQLBulkCopySqlServer()
        {
                _connectionString = "Server=DESKTOP-E5BC7VQ\\SQLEXPRESS;Database=b3digitas;Integrated Security=SSPI;TrustServerCertificate=True;";
        }

        public void BulkInsert(DataTable dataTable, string destinationTableName)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                {
                    bulkCopy.DestinationTableName = destinationTableName;

                    try
                    {
                        bulkCopy.WriteToServer(dataTable);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error during bulk insert: {ex.Message}");
                    }
                }
            }
        }

        public async Task Send<T>(List<T> Object)
        {
            try
            {
                DataTable order = new DataTable();
                var SQLBulk = new SQLBulkCopySqlServer();

                // Definindo colunas
                order.Columns.Add("Id", typeof(Guid));
                order.Columns.Add("Quantity", typeof(string));
                order.Columns.Add("Price", typeof(string));
                order.Columns.Add("Type", typeof(string));
                order.Columns.Add("Symbol", typeof(string));
                order.Columns.Add("Money", typeof(string));
                order.Columns.Add("DateCreated", typeof(DateTime));

                for (int i = 0; i < Object.Count; i++)
                {
                    DataRow row = order.NewRow();

                    var obj = Object[i];

                    row["Id"] = obj.GetType().GetProperty("Id")?.GetValue(obj);
                    row["Quantity"] = obj.GetType().GetProperty("Quantity")?.GetValue(obj);
                    row["Price"] = obj.GetType().GetProperty("Price")?.GetValue(obj);
                    row["Type"] = obj.GetType().GetProperty("Type")?.GetValue(obj);
                    row["Symbol"] = obj.GetType().GetProperty("Symbol")?.GetValue(obj);
                    row["Money"] = obj.GetType().GetProperty("Money")?.GetValue(obj);
                    row["DateCreated"] = obj.GetType().GetProperty("DateCreated")?.GetValue(obj);

                    order.Rows.Add(row);

                }

                BulkInsert(order, "dbo.Orders");

            }
            catch (Exception ex)
            {
                //Console.WriteLine($"Error parsing JSON: {ex.Message}");
            }


        }
    }
}
