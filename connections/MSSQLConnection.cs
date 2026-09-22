using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Data.Common;
using runnerDotNet;

namespace runnerDotNet
{
	public class MSSQLConnection : Connection
	{
		public MSSQLConnection(XVar parameters) : base(parameters)
		{ }

		protected override DbCommand GetCommand()
		{
			return new System.Data.SqlClient.SqlCommand();
		}

		protected override ConnectionsPool GetConnectionsPool(string connStr)
		{
			return new MSSqlConnectionPool(connStr);
		}

		protected override DBFunctions GetDbFunctions(XVar extraParams)
		{
			return new MSSQLFunctions( extraParams );
		}

		protected override DBInfo GetDbInfo()
		{
			return new MSSQLInfo(this);
		}


		public override void db_multipleInsertQuery(XVar qstringArray, XVar table = null, XVar isIdentityOffNeeded = null)
        {
            try
			{
				DbConnection connection = connectionsPool.FreeConnection;
				if (connection.State != System.Data.ConnectionState.Open)
				{
					connection.Open();
				}

				DbCommand cmd = GetCommand();
				cmd.Connection = connection;

				if (isIdentityOffNeeded)
				{
					cmd.CommandText = "SET IDENTITY_INSERT " + table.ToString() + " ON";
					cmd.ExecuteNonQuery();
				}
				foreach (var qstring in qstringArray.GetEnumerator())
				{

					if (GlobalVars.dDebug)
						MVCFunctions.EchoToOutput(qstring.Value.ToString() + "<br />");

					GlobalVars.strLastSQL = qstring.Value;

					cmd.CommandText = qstring.Value.ToString();

					cmd.ExecuteNonQuery();
				}
				if (isIdentityOffNeeded)
				{
					cmd.CommandText = "SET IDENTITY_INSERT " + table.ToString() + " OFF";
					cmd.ExecuteNonQuery();
				}
				else
				{
					cmd.CommandText = "select @@IDENTITY as indent";
					RunnerDBReader rdr = cmd.ExecuteReader();
					rdr.Connection = cmd.Connection;
					if (rdr.Read())
					{
						lastInsertedID = new XVar(rdr["indent"]);
					}
				}
				connection.Close();
			}
			catch(Exception e)
			{
				if( !silentMode )
				{
					throw e;
				}
			}
        }
	}
}