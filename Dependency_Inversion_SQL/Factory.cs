using Dependency_Inversion_SQL.Classes;
using Dependency_Inversion_SQL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_Inversion_SQL
{
    public static class Factory
    {
        public static ICar CreateCar()
        {
            return new Car(CreateDatabase());
        }

        public static IDatabase CreateDatabase()
        {
            return new SQLDatabase(CreateDatabaseConnection(), CreateDatabaseAdapater(), CreateDatabaseDataTable());
        }

        public static System.Data.SqlClient.SqlConnection CreateDatabaseConnection()
        {
            return new System.Data.SqlClient.SqlConnection();
        }

        public static System.Data.SqlClient.SqlDataAdapter CreateDatabaseAdapater()
        {
            return new System.Data.SqlClient.SqlDataAdapter();
        }

        public static System.Data.DataTable CreateDatabaseDataTable()
        {
            return new System.Data.DataTable();
        }
    }
}
