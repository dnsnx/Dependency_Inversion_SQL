using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_Inversion_SQL.Interfaces
{
    public interface IDatabase
    {
        void AddParameters((string name, object value)[] parameters);

        System.Data.DataSet GetData(string commandText, System.Data.CommandType commandType = System.Data.CommandType.Text, string sourceTable = null);
    }
}
