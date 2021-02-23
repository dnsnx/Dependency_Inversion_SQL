﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_Inversion_SQL.Interfaces
{
    public interface IDatabase
    {
        void AddParameters(string[] parameter, object[] values);

        System.Data.DataTable GetData(string commandText);
    }
}
