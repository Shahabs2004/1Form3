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
	public partial class GlobalController : BaseController
	{
		public ActionResult admin_rights_list()
		{
			try
			{
				dynamic lang = null, options = XVar.Array(), pageMask = null, pageObject = null, tables = XVar.Array();
				XTempl xt;
				MVCFunctions.Header("Expires", "Thu, 01 Jan 1970 00:00:01 GMT");
				if(XVar.Pack(!(XVar)(Security.processAdminPageSecurity(new XVar(false)))))
				{
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				tables = XVar.Clone(XVar.Array());
				lang = XVar.Clone(CommonFunctions.mlang_getcurrentlang());
				foreach (KeyValuePair<XVar, dynamic> _table in ProjectSettings.getProjectTables().GetEnumerator())
				{
					dynamic caption = null, shortTable = null, tableName = null;
					tableName = XVar.Clone(_table.Value["name"]);
					shortTable = XVar.Clone(_table.Value["shortName"]);
					if(XVar.Pack(Security.isAdminTable((XVar)(tableName))))
					{
						continue;
					}
					caption = XVar.Clone(_table.Value["caption"][lang]);
					tables.InitAndSetArrayItem(new XVar(0, shortTable, 1, MVCFunctions.Concat(" ", caption)), tableName);
				}
				tables.InitAndSetArrayItem(new XVar(0, Constants.GLOBAL_PAGES_SHORT, 1, MVCFunctions.Concat(" ", Constants.GLOBAL_PAGES)), Constants.GLOBAL_PAGES);
				MVCFunctions._loadTablePages();
				pageMask = XVar.Clone(GlobalVars.runnerPageInfo["tableMasks"]);
				xt = XVar.UnPackXTempl(new XTempl());
				options = XVar.Clone(XVar.Array());
				options.InitAndSetArrayItem("admin_rights_list", "pageType");
				options.InitAndSetArrayItem(Constants.GLOBAL_PAGES, "pageTable");
				options.InitAndSetArrayItem((XVar.Pack(CommonFunctions.postvalue_number(new XVar("id"))) ? XVar.Pack(CommonFunctions.postvalue_number(new XVar("id"))) : XVar.Pack(1)), "id");
				options.InitAndSetArrayItem(Constants.RIGHTS_PAGE, "mode");
				options.InitAndSetArrayItem(xt, "xt");
				options.InitAndSetArrayItem(CommonFunctions.postvalue_number(new XVar("goto")), "requestGoto");
				options.InitAndSetArrayItem(tables, "tables");
				options.InitAndSetArrayItem(pageMask, "pageMasks");
				GlobalVars.pageObject = XVar.Clone(ListPage.createListPage(new XVar(Constants.GLOBAL_PAGES), (XVar)(options)));
				if(MVCFunctions.postvalue(new XVar("a")) == "saveRights")
				{
					dynamic modifiedRights = null;
					if(XVar.Pack(!(XVar)(CommonFunctions.isPostRequest())))
					{
						return MVCFunctions.GetBuferContentAndClearBufer();
					}
					modifiedRights = XVar.Clone(MVCFunctions.runner_json_decode((XVar)(MVCFunctions.postvalue(new XVar("data")))));
					GlobalVars.pageObject.saveRights((XVar)(modifiedRights));
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				GlobalVars.pageObject.addButtonHandlers();
				GlobalVars.pageObject.prepareForBuildPage();
				GlobalVars.pageObject.showPage();
				return null;
			}
			catch(RunnerRedirectException ex)
			{ return Redirect(ex.Message); }
		}
	}
}
