using Dependency_Inversion_SQL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace Dependency_Inversion_SQL.Classes
{
    public class SQLDatabase : IDatabase
    {
        #region Variables
        private readonly string _SqlServer = "Integrated Security=true;Initial Catalog=Test;Server=localhost\\localhost;";
        private SqlConnection _SqlConnection;
        private SqlCommand _SqlCommand;
        private SqlDataAdapter _SqlDataAdapter;
        private DataSet _DataSet;
        #endregion

        #region Properties
        public string SqlServer
        {
            get
            {
                return _SqlServer;
            }
        }
        #endregion

        #region Constructors
        public SQLDatabase(SqlConnection sqlConnection, SqlDataAdapter sqlDataAdapter, DataSet dataSet)
        {
            _SqlConnection = sqlConnection;
            _SqlConnection.ConnectionString = _SqlServer;
            _SqlCommand = _SqlConnection.CreateCommand();
            _SqlDataAdapter = sqlDataAdapter;
            _DataSet = dataSet;
        }
        #endregion

        #region Methods
        public void AddParameters((string name, object value)[] parameters)
        {
            for (var i = 0; i < parameters.Length; i++)
            {
                _SqlCommand.Parameters.AddWithValue(parameters[i].name, parameters[i].value);
            }
        }

        public System.Data.DataSet GetData(string commandText, System.Data.CommandType commandType = System.Data.CommandType.Text, string sourceTable = null)
        {
            if (sourceTable == null)
            {
                sourceTable = "someName";
            }
            _DataSet.Clear();
            _SqlCommand.CommandText = commandText;
            _SqlCommand.CommandType = commandType;
            _SqlDataAdapter.SelectCommand = _SqlCommand;
            _SqlDataAdapter.SelectCommand.Connection.Open();
            _SqlDataAdapter.Fill(_DataSet, sourceTable);
            _SqlDataAdapter.SelectCommand.Connection.Close();
            _SqlCommand.Parameters.Clear();
            _SqlCommand.CommandText = string.Empty;
            return _DataSet;
        }
        #endregion
    }
}
