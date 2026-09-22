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
		public static void dbtables()
		{
			GlobalVars.runnerDbTables = new XVar(new XVar( 0, new XVar( "connId", "conn",
"table", "OneForm2_settings",
"schema", "dbo",
"filename", "dbo_oneform2_settings" ),
1, new XVar( "connId", "conn",
"table", "OneForm_uggroups",
"schema", "dbo",
"filename", "dbo_oneform_uggroups" ),
2, new XVar( "connId", "conn",
"table", "OneForm_ugrights",
"schema", "dbo",
"filename", "dbo_oneform_ugrights" ),
3, new XVar( "connId", "conn",
"table", "OneForm_ugmembers",
"schema", "dbo",
"filename", "dbo_oneform_ugmembers" ),
4, new XVar( "connId", "conn",
"table", "Oneform_locking",
"schema", "dbo",
"filename", "dbo_oneform_locking" ),
5, new XVar( "connId", "conn",
"table", "HWFlow_SQL2019_audit",
"schema", "dbo",
"filename", "dbo_hwflow_sql2019_audit" ),
6, new XVar( "connId", "conn",
"table", "Branches",
"schema", "dbo",
"filename", "dbo_branches" ),
7, new XVar( "connId", "conn",
"table", "OneForm_Values_Images",
"schema", "dbo",
"filename", "dbo_oneform_values_images" ),
8, new XVar( "connId", "conn",
"table", "OneForm_Fields_Groups",
"schema", "dbo",
"filename", "dbo_oneform_fields_groups" ),
9, new XVar( "connId", "conn",
"table", "OneForm_Value_Files",
"schema", "dbo",
"filename", "dbo_oneform_value_files" ),
10, new XVar( "connId", "conn",
"table", "OneForm_Fields",
"schema", "dbo",
"filename", "dbo_oneform_fields" ),
11, new XVar( "connId", "conn",
"table", "OneForm_Values",
"schema", "dbo",
"filename", "dbo_oneform_values" ) ));
		}
	}

}
