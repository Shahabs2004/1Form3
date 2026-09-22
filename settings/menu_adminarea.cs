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
		public static void menu_adminarea()
		{
			GlobalVars.runnerMenus.InitAndSetArrayItem(new XVar( "name", "main",
"id", "adminarea",
"treeLike", true,
"root", new XVar( "id", "main",
"parent", "",
"children", new XVar( 0, new XVar( "id", "admin_rights_list",
"parent", "main",
"children", XVar.Array(),
"data", new XVar( "name", new XVar( "tag", "AA_PERMISSIONS",
"type", 2 ),
"comments", new XVar( "text", "",
"type", 0 ),
"style", "",
"href", "",
"params", "",
"pageId", "",
"itemType", 2,
"linkType", 0,
"openType", 0,
"iconType", 0,
"iconName", "",
"iconStyle", 0,
"showIconType", 1,
"linkToAnotherApp", false,
"table", -1,
"pageType", "admin_rights_list" ) ) ),
"data", new XVar( "name", new XVar( "text", "",
"type", 0 ),
"comments", new XVar( "text", "",
"type", 0 ),
"style", "",
"href", "",
"params", "",
"pageId", "",
"itemType", 0,
"linkType", 2,
"openType", 0,
"iconType", 0,
"iconName", "",
"iconStyle", 0,
"showIconType", 1,
"linkToAnotherApp", false ) ) ), "adminarea");
		}
	}

}
