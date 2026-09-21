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
		public static void dbtable_dbo_hwflow_sql2019_audit()
		{
			GlobalVars.runnerDbTableInfo.InitAndSetArrayItem(new XVar( "type", 0,
"foreignKeys", XVar.Array(),
"fields", new XVar( 0, new XVar( "name", "id",
"type", 3,
"size", 10,
"scale", 0,
"typeName", "int",
"nullable", false,
"autoinc", true,
"defaultValueSQL", "",
"defaultValue", "" ),
1, new XVar( "name", "datetime",
"type", 135,
"size", 16,
"scale", 3,
"typeName", "datetime",
"nullable", false,
"autoinc", false,
"defaultValueSQL", "",
"defaultValue", "" ),
2, new XVar( "name", "ip",
"type", 200,
"size", 40,
"scale", null,
"typeName", "varchar",
"nullable", false,
"autoinc", false,
"defaultValueSQL", "",
"defaultValue", "" ),
3, new XVar( "name", "user",
"type", 200,
"size", 300,
"scale", null,
"typeName", "varchar",
"nullable", true,
"autoinc", false,
"defaultValueSQL", "",
"defaultValue", "" ),
4, new XVar( "name", "table",
"type", 200,
"size", 300,
"scale", null,
"typeName", "varchar",
"nullable", true,
"autoinc", false,
"defaultValueSQL", "",
"defaultValue", "" ),
5, new XVar( "name", "action",
"type", 200,
"size", 250,
"scale", null,
"typeName", "varchar",
"nullable", false,
"autoinc", false,
"defaultValueSQL", "",
"defaultValue", "" ),
6, new XVar( "name", "description",
"type", 201,
"size", 2147483647,
"scale", null,
"typeName", "text",
"nullable", true,
"autoinc", false,
"defaultValueSQL", "",
"defaultValue", "" ) ),
"primaryKeys", new XVar( 0, "id" ),
"uniqueFields", XVar.Array(),
"name", "HWFlow_SQL2019_audit",
"schema", "dbo" ), "dbo_hwflow_sql2019_audit");
		}
	}

}
