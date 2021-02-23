using Dependency_Inversion_SQL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_Inversion_SQL.Classes
{
    class Car : ICar
    {
        IDatabase _Database;

        public Car(IDatabase database)
        {
            _Database = database;
        }

        public string GetCarName()
        {
            var result = _Database.GetData("SELECT 'Audi R8' as CarName");
            return result.Rows[0].ItemArray[0].ToString();
        }
    }
}
