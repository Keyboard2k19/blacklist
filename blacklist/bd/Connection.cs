using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace blacklist.bd
{
    class Connection
    {
        private static SqlConnection con;

        public static SqlConnection openConnection()
        {
            try
            {
                con = new SqlConnection("Data source = DONOVANACOSTA; Initial catalog =blacklist; Integrated Security=SSPI");
                con.Open();
            }
            catch(Exception ex)
            {
            }
            return con;
        }
    }
}
