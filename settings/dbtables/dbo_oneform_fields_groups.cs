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
		public static void dbtable_dbo_oneform_fields_groups()
		{
			GlobalVars.runnerDbTableInfo.InitAndSetArrayItem(new XVar( "type", 0,
"foreignKeys", XVar.Array(),
"fields", new XVar( 0, new XVar( "name", "ID",
"type", 2,
"size", 5,
"scale", 0,
"typeName", "smallint",
"nullable", false,
"autoinc", true,
"defaultValueSQL", "",
"defaultValue", "" ),
1, new XVar( "name", "Group_Name",
"type", 202,
"size", 100,
"scale", null,
"typeName", "nvarchar",
"nullable", false,
"autoinc", false,
"defaultValueSQL", "",
"defaultValue", "" ) ),
"primaryKeys", new XVar( 0, "ID" ),
"uniqueFields", XVar.Array(),
"name", "OneForm_Fields_Groups",
"schema", "dbo" ), "dbo_oneform_fields_groups");
		}
	}

}
