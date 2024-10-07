using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b3digitas.Infra.SQL.Queries
{
    public static class OrderQueries
    {
        public static string GetBetweenDates => @"SELECT * FROM ""Orders"" WHERE ""DateCreated"" >= @Date1 AND ""DateCreated"" <= @Date2 AND ""Symbol"" = @symbol AND ""Type"" = @type";
    }
}