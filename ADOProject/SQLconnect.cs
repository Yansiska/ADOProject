using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ADOProject
{
    class SQLconnect
    {
        public static SqlConnection Connect = new SqlConnection("data source = ACER\\YANSISKASQL; initial catalog = dbProject; integrated security = true");
        //public static SqlConnection Connect = new SqlConnection("data soruce = ACER\\YANSISKASQL; Initial catalog = dbProject; UID=blabla; Password=blabla");
    }
}
