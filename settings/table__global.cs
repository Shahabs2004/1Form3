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
		public static void table__global()
		{
			GlobalVars.runnerTableSettings.InitAndSetArrayItem(new XVar( "name", "<global>",
"type", 5,
"shortName", "_global",
"advancedSecurityType", 0,
"pagesByType", new XVar( "menu", new XVar( 0, "menu" ),
"login", new XVar( 0, "login" ),
"admin_rights_list", new XVar( 0, "admin_rights_list" ),
"admin_admembers_list", new XVar( 0, "admin_admembers_list" ) ),
"pageTypes", new XVar( "menu", "menu",
"login", "login",
"admin_rights_list", "admin_rights_list",
"admin_admembers_list", "admin_admembers_list" ),
"defaultPages", new XVar( "menu", "menu",
"login", "login",
"admin_rights_list", "admin_rights_list",
"admin_admembers_list", "admin_admembers_list" ),
"originalPagesByType", new XVar( "menu", new XVar( 0, "menu" ),
"login", new XVar( 0, "login" ),
"admin_rights_list", new XVar( 0, "admin_rights_list" ),
"admin_admembers_list", new XVar( 0, "admin_admembers_list" ) ),
"originalPageTypes", new XVar( "menu", "menu",
"login", "login",
"admin_rights_list", "admin_rights_list",
"admin_admembers_list", "admin_admembers_list" ),
"originalDefaultPages", new XVar( "menu", "menu",
"login", "login",
"admin_rights_list", "admin_rights_list",
"admin_admembers_list", "admin_admembers_list" ),
"hasJsEvents", false ), Constants.GLOBAL_PAGES);
			if(XVar.Equals(XVar.Pack(CommonFunctions.mlang_getcurrentlang()), XVar.Pack("Farsi")))
			{
				GlobalVars.runnerTableLabels.InitAndSetArrayItem(new XVar( "pageTitles", new XVar(  ) ), Constants.GLOBAL_PAGES);
			}
		}
	}

}
