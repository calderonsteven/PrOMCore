using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;
using System.Data;

namespace PrOMCore.DataAccess
{
    public class SqlCeHelper
    {
        private static SqlCeHelper m_SqlCeHelper;
        private System.Data.SqlServerCe.SqlCeConnection m_SqlCeConnection;

        public System.Data.SqlServerCe.SqlCeConnection Connection
        {
            get { return m_SqlCeConnection; }
            set { m_SqlCeConnection = value; }
        }

        private SqlCeHelper()
        {

        }

        public static SqlCeHelper GetInstance()
        {
            try
            {
                if (!PrOMCore.Core.Manager.Session.ContainsKey("CONNECTIONSTRING") || PrOMCore.Core.Manager.Session["CONNECTIONSTRING"] == null)
                {
                    throw new Exception("PrOMManager no ha encontrado asignada la variable de sesión CONNECTIONSTRING, asigne a Manager.Session[CONNECTIONSTRING] un dato válido.");
                }

                if (m_SqlCeHelper == null)
                {
                    m_SqlCeHelper = new SqlCeHelper();
                    m_SqlCeHelper.Connection = new SqlCeConnection((string)PrOMCore.Core.Manager.Session["CONNECTIONSTRING"]);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return m_SqlCeHelper;
        }

        public void Disconnect()
        {

        }

        public System.Data.SqlServerCe.SqlCeCommand PrepareCommand(string commandText, params object[] parameters)
        {
            System.Data.SqlServerCe.SqlCeCommand sqlCeCommand = null;
            System.Data.SqlServerCe.SqlCeParameter sqlCeParameter = null;
            try
            {
                if (m_SqlCeConnection.State != System.Data.ConnectionState.Open)
                {
                    m_SqlCeConnection.Open();
                }
                sqlCeCommand = new SqlCeCommand();
                sqlCeCommand.Connection = m_SqlCeConnection;
                sqlCeCommand.CommandText = commandText;

                for (int i = 0; parameters != null && i < parameters.Length; i++)
                {
                    if (parameters[i] == null)
                    {
                        sqlCeParameter = new SqlCeParameter("@p" + (i + 1), System.DBNull.Value);
                    }
                    else
                    {
                        if (parameters[i] is string)
                            parameters[i] = parameters[i].ToString().Replace("'", "´");

                        sqlCeParameter = new SqlCeParameter("@p" + (i + 1), parameters[i]);
                    }
                    sqlCeCommand.Parameters.Add(sqlCeParameter);
                }

            }
            catch (Exception exception)
            {
                throw exception;
            }

            return sqlCeCommand;
        }

        public object GetScalar(string commandText, params object[] parameters)
        {
            System.Data.SqlServerCe.SqlCeCommand sqlCeCommand;
            try
            {
                sqlCeCommand = this.PrepareCommand(commandText, parameters);
                return sqlCeCommand.ExecuteScalar();
            }
            catch (Exception exception)
            {
                throw exception;
            }


        }

        public System.Data.DataTable GetDataTable(string commandText, params object[] parameters)
        {
            System.Data.SqlServerCe.SqlCeCommand sqlCeCommand;
            System.Data.SqlServerCe.SqlCeDataAdapter sqlCeDataAdapter = null;
            System.Data.DataTable dataTable = null;
            try
            {
                sqlCeCommand = this.PrepareCommand(commandText, parameters);
                sqlCeDataAdapter = new SqlCeDataAdapter(sqlCeCommand);
                dataTable = new System.Data.DataTable();
                sqlCeDataAdapter.Fill(dataTable);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                if (sqlCeDataAdapter != null && sqlCeDataAdapter.SelectCommand != null) sqlCeDataAdapter.SelectCommand.Dispose();
                if (sqlCeDataAdapter != null && sqlCeDataAdapter.UpdateCommand != null) sqlCeDataAdapter.UpdateCommand.Dispose();
                if (sqlCeDataAdapter != null && sqlCeDataAdapter.DeleteCommand != null) sqlCeDataAdapter.DeleteCommand.Dispose();
                if (sqlCeDataAdapter != null && sqlCeDataAdapter.InsertCommand != null) sqlCeDataAdapter.InsertCommand.Dispose();
                if (sqlCeDataAdapter != null) sqlCeDataAdapter.Dispose();
            }

            return dataTable;
        }

        public System.Data.DataRow GetRecordRow(string commandText, params object[] parameters)
        {
            DataTable dataTable = this.GetDataTable(commandText, parameters);
            if (dataTable.Rows.Count > 0)
            {
                return dataTable.Rows[0];
            }
            return null;
        }

        public void ReplicateDataTableInDB(System.Data.DataTable dataTable)
        {
            System.Data.SqlServerCe.SqlCeCommand sqlCeCommand;
            System.Data.SqlServerCe.SqlCeDataAdapter sqlCeDataAdapter;
            try
            {
                sqlCeCommand = this.PrepareCommand("");
                sqlCeDataAdapter = new SqlCeDataAdapter(sqlCeCommand);
                System.Data.SqlServerCe.SqlCeCommandBuilder sqlCeCommandBuilder = new System.Data.SqlServerCe.SqlCeCommandBuilder(sqlCeDataAdapter);
                sqlCeDataAdapter.Update(dataTable);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public int ExecuteNonQuery(string commandText, SqlCeTransaction trns, params object[] parameters )
        {
            //ExecuteUpdate
            int recordsAfected = 0;
            System.Data.SqlServerCe.SqlCeCommand sqlCeCommand;
            try
            {
                //para lo del manejo de las comillas
                //commandText = commandText.Replace("'", "´");
                sqlCeCommand = this.PrepareCommand(commandText, parameters);
                sqlCeCommand.Transaction = trns;
                recordsAfected = sqlCeCommand.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return recordsAfected;
        }

        public int ExecuteNonQuery(string commandText, params object[] parameters)
        {
            //ExecuteUpdate
            int recordsAfected = 0;
            System.Data.SqlServerCe.SqlCeCommand sqlCeCommand;
            try
            {
                //para lo del manejo de las comillas
                //commandText = commandText.Replace("'", "´");
                sqlCeCommand = this.PrepareCommand(commandText, parameters);
                recordsAfected = sqlCeCommand.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return recordsAfected;
        }

        public SqlCeDataReader ExecuteReader(string commandText, params object[] parameters)
        {
            System.Data.SqlServerCe.SqlCeCommand sqlCeCommand;
            try
            {
                sqlCeCommand = this.PrepareCommand(commandText, parameters);
                return sqlCeCommand.ExecuteReader();
            }
            catch (Exception exception)
            {
                throw exception;
            }

        }

        /// <summary>
        /// Para mantener compatibilidad con Pocket Access este metodo permite actualizar el valor de los campos que contengan NULL reemplazandolo por un caracter en blanco
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public void ManageNullFields(string tableName)
        {
            System.Data.SqlServerCe.SqlCeCommand sqlCeCommand;
            try
            {
                string commandText = "SELECT * FROM " + tableName;

                SqlCeDataReader sqlCeDataReader = this.ExecuteReader(commandText);
                DataTable dataTable = sqlCeDataReader.GetSchemaTable();
                sqlCeDataReader.Close();
                Type tipo;
                foreach(System.Data.DataRow dataRow in dataTable.Rows ) 
                {
                    tipo = (Type)dataRow["DataType"];
                    if (tipo != typeof(string))
                        continue;

                    commandText = "UPDATE " + tableName + " SET " + dataRow["ColumnName"].ToString() + " = '' WHERE " + dataRow["ColumnName"].ToString() + " IS NULL";
                    sqlCeCommand = this.PrepareCommand(commandText);
                    sqlCeCommand.ExecuteNonQuery();
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }

        }

    }
}
