using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Runtime.Remoting.Contexts;
using System.Windows.Markup;

namespace WPF_LoginForm.Repositories
{
    public abstract class RepositoryBase
    {
        private readonly string _connectionString;
        public RepositoryBase()
        {
            //  _connectionString = "Server=EOZAN-LAP\\ENFADATABASE; Database=ENFAPRJDB; Integrated Security=true";
            _connectionString = "Data Source=EOZAN-LAP\\ENFADATABASE;Initial Catalog=ENFAPRJDB;Integrated Security=true;Column Encryption Setting=enabled;";
             }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }


}
