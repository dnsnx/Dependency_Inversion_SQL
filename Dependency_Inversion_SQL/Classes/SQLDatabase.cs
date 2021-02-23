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
        private DataTable _DataTable;
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
        public SQLDatabase(SqlConnection sqlConnection, SqlDataAdapter sqlDataAdapter, DataTable dataTable)
        {
            _SqlConnection = sqlConnection;
            _SqlConnection.ConnectionString = _SqlServer;
            _SqlCommand = _SqlConnection.CreateCommand();
            _SqlDataAdapter = sqlDataAdapter;
            _DataTable = dataTable;
        }
        #endregion

        #region Methods
        public void AddParameters(string[] parameter, object[] values)
        {
            for (var i = 0; i < parameter.Length; i++)
            {
                _SqlCommand.Parameters.Add(parameter[i]);
                _SqlCommand.Parameters[parameter[i]].Value = values[i];
            }
        }

        public System.Data.DataTable GetData(string commandText)
        {
            _SqlCommand.CommandText = commandText;
            _SqlDataAdapter.SelectCommand = _SqlCommand;
            _SqlDataAdapter.SelectCommand.Connection.Open();
            _SqlDataAdapter.Fill(_DataTable);
            _SqlDataAdapter.SelectCommand.Connection.Close();
            return _DataTable;
        }
        #endregion
    }
}
