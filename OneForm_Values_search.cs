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
	public partial class OneForm_ValuesController : BaseController
	{
		public ActionResult search()
		{
			try
			{
				dynamic cname = null, id = null, pageMode = null, pageObject = null, rname = null, templatefile = null, var_params = XVar.Array();
				XTempl xt;
				GlobalVars.requestTable = new XVar("dbo.OneForm_Values");
				GlobalVars.strTableName = new XVar("dbo.OneForm_Values");
				CommonFunctions.add_nocache_headers();
				GlobalVars.requestTable = new XVar("dbo.OneForm_Values");
				GlobalVars.strTableName = new XVar("dbo.OneForm_Values");
				GlobalVars.requestPage = new XVar("search");
				if(XVar.Pack(Security.hasLogin()))
				{
					dynamic accessGranted = null;
					Security.processLogoutRequest();
					if(XVar.Pack(!(XVar)(CommonFunctions.isLogged())))
					{
						Security.saveRedirectURL();
						CommonFunctions.redirectToLogin();
					}
					accessGranted = XVar.Clone(CommonFunctions.CheckTablePermissions((XVar)(GlobalVars.strTableName), new XVar("S")));
					if(XVar.Pack(!(XVar)(accessGranted)))
					{
						MVCFunctions.HeaderRedirect(new XVar("menu"));
					}
				}
				xt = XVar.UnPackXTempl(new XTempl());
				pageMode = XVar.Clone(SearchPage.readSearchModeFromRequest());
				var_params = XVar.Clone(XVar.Array());
				var_params.InitAndSetArrayItem(xt, "xt");
				var_params.InitAndSetArrayItem(CommonFunctions.postvalue_number(new XVar("id")), "id");
				var_params.InitAndSetArrayItem(pageMode, "mode");
				var_params.InitAndSetArrayItem(GlobalVars.strTableName, "tName");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("page")), "pageName");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("returnPage")), "returnPage");
				var_params.InitAndSetArrayItem(Constants.PAGE_SEARCH, "pageType");
				var_params.InitAndSetArrayItem(cname, "chartName");
				var_params.InitAndSetArrayItem(rname, "reportName");
				var_params.InitAndSetArrayItem(templatefile, "templatefile");
				var_params.InitAndSetArrayItem(CommonFunctions.GetTableURL((XVar)(GlobalVars.strTableName)), "shortTableName");
				var_params.InitAndSetArrayItem((XVar.Pack(MVCFunctions.postvalue(new XVar("searchControllerId"))) ? XVar.Pack(MVCFunctions.postvalue(new XVar("searchControllerId"))) : XVar.Pack(id)), "searchControllerId");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("ctrlField")), "ctrlField");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("isNeedSettings")), "needSettings");
				if(pageMode == Constants.SEARCH_DASHBOARD)
				{
					var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("table")), "dashTName");
					var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("dashelement")), "dashElementName");
					var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("dashPage")), "dashPage");
				}
				var_params.InitAndSetArrayItem(SearchPage.getExtraPageParams(), "extraPageParams");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("mastertable")), "masterTable");
				if(XVar.Pack(var_params["masterTable"]))
				{
					var_params.InitAndSetArrayItem(RunnerPage.readMasterKeysFromRequest(), "masterKeysReq");
				}
				if(CommonFunctions.GetEntityType((XVar)(GlobalVars.strTableName)) == Constants.titDASHBOARD)
				{
					GlobalVars.pageObject = XVar.Clone(new SearchPageDash((XVar)(var_params)));
				}
				else
				{
					GlobalVars.pageObject = XVar.Clone(new SearchPage((XVar)(var_params)));
				}
				if(pageMode == Constants.SEARCH_LOAD_CONTROL)
				{
					GlobalVars.pageObject.displaySearchControl();
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				GlobalVars.pageObject.init();
				GlobalVars.pageObject.process();
				if((XVar)(ProjectSettings.ext() == "aspx")  && (XVar)(pageMode == Constants.SEARCH_DASHBOARD))
				{
					MVCFunctions.Echo(new XVar(""));
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				return null;
			}
			catch(RunnerRedirectException ex)
			{ return Redirect(ex.Message); }
		}
	}
}
