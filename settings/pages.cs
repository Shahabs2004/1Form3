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
		public static void pages()
		{
			GlobalVars.runnerPageInfo = new XVar(new XVar( "allPages", new XVar( "dbo.Branches", new XVar( "list", new XVar( 0, "list" ),
"masterlist", new XVar( 0, "masterlist" ),
"masterprint", new XVar( 0, "masterprint" ) ),
"dbo.OneForm_Fields", new XVar( "add", new XVar( 0, "add" ),
"edit", new XVar( 0, "edit" ),
"list", new XVar( 0, "list" ),
"masterlist", new XVar( 0, "masterlist" ),
"masterprint", new XVar( 0, "masterprint" ) ),
"dbo.OneForm_Fields_Groups", new XVar( "add", new XVar( 0, "add" ),
"edit", new XVar( 0, "edit" ),
"list", new XVar( 0, "list" ),
"masterlist", new XVar( 0, "masterlist" ),
"masterprint", new XVar( 0, "masterprint" ) ),
"dbo.OneForm_Values", new XVar( "add", new XVar( 0, "add" ),
"export", new XVar( 0, "export" ),
"import", new XVar( 0, "import" ),
"edit", new XVar( 0, "edit" ),
"view", new XVar( 0, "view" ),
"list", new XVar( 0, "list" ),
"print", new XVar( 0, "print" ),
"search", new XVar( 0, "search" ) ),
"<global>", new XVar( "menu", new XVar( 0, "menu" ),
"login", new XVar( 0, "login" ),
"admin_rights_list", new XVar( 0, "admin_rights_list" ),
"admin_admembers_list", new XVar( 0, "admin_admembers_list" ) ) ),
"tableMasks", new XVar( "dbo.Branches", "ADES",
"dbo.OneForm_Fields", "ADES",
"dbo.OneForm_Values", "ADESPIM",
"dbo.OneForm_Fields_Groups", "ADES",
"<global>", "S" ) ));
		}
	}

}
