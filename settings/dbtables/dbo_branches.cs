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
		public static void dbtable_dbo_branches()
		{
			GlobalVars.runnerDbTableInfo.InitAndSetArrayItem(new XVar( "type", 0,
"foreignKeys", XVar.Array(),
"fields", new XVar( 0, new XVar( "name", "Code",
"type", 3,
"size", 10,
"scale", 0,
"typeName", "int",
"nullable", false,
"autoinc", false,
"defaultValueSQL", "",
"defaultValue", "" ),
1, new XVar( "name", "BrName",
"type", 202,
"size", 120,
"scale", null,
"typeName", "nvarchar",
"nullable", true,
"autoinc", false,
"defaultValueSQL", "",
"defaultValue", "" ),
2, new XVar( "name", "Email",
"type", 202,
"size", 510,
"scale", null,
"typeName", "nvarchar",
"nullable", true,
"autoinc", false,
"defaultValueSQL", "",
"defaultValue", "" ),
3, new XVar( "name", "DialUpPhone",
"type", 202,
"size", 50,
"scale", null,
"typeName", "nvarchar",
"nullable", true,
"autoinc", false,
"defaultValueSQL", "",
"defaultValue", "" ) ),
"primaryKeys", new XVar( 0, "Code" ),
"uniqueFields", XVar.Array(),
"name", "Branches",
"schema", "dbo" ), "dbo_branches");
		}
	}

}
