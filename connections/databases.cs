using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Reflection;
using runnerDotNet;
namespace runnerDotNet
{
	public static partial class RunnerSettings
	{
		public static void Databases()
		{
			GlobalVars.runnerDatabases = new XVar(new XVar( "conn", new XVar( "connId", "conn",
"connName", "Mekanizeh at 10.7.1.42",
"dbType", 2,
"connStringType", "mssql",
"connInfo", new XVar( 0, "10.7.1.42",
1, "sa",
2, "Admin@Sql",
3, "Mekanizeh",
4, "0",
5, "0" ) ) ));
			GlobalVars.runnerRestConnections = new XVar(new XVar(  ));
		}
	}

}
