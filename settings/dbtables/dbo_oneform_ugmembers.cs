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
		public static void dbtable_dbo_oneform_ugmembers()
		{
			GlobalVars.runnerDbTableInfo.InitAndSetArrayItem(new XVar( "type", 0,
"foreignKeys", XVar.Array(),
"fields", new XVar( 0, new XVar( "name", "UserName",
"type", 200,
"size", 100,
"scale", null,
"typeName", "varchar",
"nullable", false,
"autoinc", false,
"defaultValueSQL", "",
"defaultValue", "" ),
1, new XVar( "name", "GroupID",
"type", 3,
"size", 10,
"scale", 0,
"typeName", "int",
"nullable", false,
"autoinc", false,
"defaultValueSQL", "",
"defaultValue", "" ),
2, new XVar( "name", "Provider",
"type", 200,
"size", 10,
"scale", null,
"typeName", "varchar",
"nullable", false,
"autoinc", false,
"defaultValueSQL", "''",
"defaultValue", "" ) ),
"primaryKeys", new XVar( 0, "UserName",
1, "GroupID",
2, "Provider" ),
"uniqueFields", XVar.Array(),
"name", "OneForm_ugmembers",
"schema", "dbo" ), "dbo_oneform_ugmembers");
		}
	}

}
