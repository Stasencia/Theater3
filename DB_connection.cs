using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theater
{
    class DB_connection
    {
        public static string connectionString = @"Data Source=STASIAV570\SQLEXPRESS;Initial Catalog=DB_Theater;Integrated Security=True;Pooling=False";
        public static string current_directory = Environment.CurrentDirectory + "\\";
    }
}
