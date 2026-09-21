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
		public static void dbtable_dbo_oneform_values_images()
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
1, new XVar( "name", "OneForm_Value_ID",
"type", 3,
"size", 10,
"scale", 0,
"typeName", "int",
"nullable", false,
"autoinc", false,
"defaultValueSQL", "",
"defaultValue", "" ),
2, new XVar( "name", "Image_Data",
"type", 205,
"size", 2147483647,
"scale", null,
"typeName", "image",
"nullable", false,
"autoinc", false,
"defaultValueSQL", "",
"defaultValue", "" ),
3, new XVar( "name", "thumbnails",
"type", 205,
"size", 2147483647,
"scale", null,
"typeName", "image",
"nullable", false,
"autoinc", false,
"defaultValueSQL", "",
"defaultValue", "" ) ),
"primaryKeys", new XVar( 0, "ID" ),
"uniqueFields", XVar.Array(),
"name", "OneForm_Values_Images",
"schema", "dbo" ), "dbo_oneform_values_images");
		}
	}

}
