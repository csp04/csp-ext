using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Csp.Extensions;

namespace cspSqlExtTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new SQLiteConnection(@"DataSource=D:\Project Lab\Local Databases\data.db");
            db.OpenQuery("SELECT * FROM NameValue")
                 //.Each(item => Console.WriteLine(item.Name + " " + item.Value));
                .Each(row =>
                {
                    foreach (var cell in row)
                    {
                        Console.WriteLine(cell.name + " " + cell.value);
                    }
                });
               
        }

        public class NameValue
        {
            public string Name { get; set; }
            public string Value { get; set; }

        }
    }
}
