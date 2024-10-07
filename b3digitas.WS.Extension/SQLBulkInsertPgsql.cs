using Npgsql;


public class SqlBulkInsertPgsql
{
    private string _connectionString = "Server=127.0.0.1;Port=5432;Database=b3digitas;User Id=postgres;Password=123;";

    public async Task Send<T>(List<T> data)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            try
            {
                connection.Open();

                using (var writer = connection.BeginBinaryImport("COPY \"Orders\" FROM STDIN (FORMAT BINARY)"))
                {
                    foreach (var item in data)
                    {
                        writer.StartRow();

                        foreach (var prop in item.GetType().GetProperties())
                        {
                            writer.Write(prop.GetValue(item));
                        }
                    }
                    writer.Complete();

                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }
        }
    }
}
