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
		public static void dbtable_dbo_oneform2_settings()
		{
			GlobalVars.runnerDbTableInfo.InitAndSetArrayItem(new XVar( "type", 0,
"foreignKeys", XVar.Array(),
"fields", new XVar( 0, new XVar( "name", "ID",
"type", 3,
"size", 10,
"scale", 0,
"typeName", "int",
"nullable", false,
"autoinc", true,
"defaultValueSQL", "",
"defaultValue", "" ),
1, new XVar( "name", "TYPE",
"type", 3,
"size", 10,
"scale", 0,
"typeName", "int",
"nullable", true,
"autoinc", false,
"defaultValueSQL", "",
"defaultValue", "" ),
2, new XVar( "name", "NAME",
"type", 202,
"size", 600,
"scale", null,
"typeName", "nvarchar",
"nullable", true,
"autoinc", false,
"defaultValueSQL", "",
"defaultValue", "" ),
3, new XVar( "name", "USERNAME",
"type", 202,
"size", 600,
"scale", null,
"typeName", "nvarchar",
"nullable", true,
"autoinc", false,
"defaultValueSQL", "",
"defaultValue", "" ),
4, new XVar( "name", "COOKIE",
"type", 202,
"size", 1000,
"scale", null,
"typeName", "nvarchar",
"nullable", true,
"autoinc", false,
"defaultValueSQL", "",
"defaultValue", "" ),
5, new XVar( "name", "SEARCH",
"type", 203,
"size", 2147483646,
"scale", null,
"typeName", "ntext",
"nullable", true,
"autoinc", false,
"defaultValueSQL", "",
"defaultValue", "" ),
6, new XVar( "name", "TABLENAME",
"type", 202,
"size", 600,
"scale", null,
"typeName", "nvarchar",
"nullable", true,
"autoinc", false,
"defaultValueSQL", "",
"defaultValue", "" ) ),
"primaryKeys", new XVar( 0, "ID" ),
"uniqueFields", XVar.Array(),
"name", "OneForm2_settings",
"schema", "dbo" ), "dbo_oneform2_settings");
		}
	}

}
