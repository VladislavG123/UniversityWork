using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityApp.DataAccess
{
    public abstract class EntityService<T>
    {
        protected string _providerName;
        protected string _connectionString;
        protected DbDataAdapter _adapter;

        public EntityService()
        {
            _providerName = ConfigurationManager.ConnectionStrings["appConnection"].ProviderName;
            _connectionString = ConfigurationManager.ConnectionStrings["appConnection"].ConnectionString;
        }

    }
}
