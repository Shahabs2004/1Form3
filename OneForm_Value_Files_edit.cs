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
	public partial class OneForm_Value_FilesController : BaseController
	{
		public ActionResult edit()
		{
			try
			{
				dynamic id = null, keyFields = XVar.Array(), keys = XVar.Array(), pageMode = null, pageObject = null, var_params = XVar.Array();
				XTempl xt;
				GlobalVars.requestTable = new XVar("dbo.OneForm_Value_Files");
				GlobalVars.strTableName = new XVar("dbo.OneForm_Value_Files");
				GlobalVars.requestPage = new XVar("edit");
				keyFields = new XVar(new XVar( 0, "ID" ));
				CommonFunctions.add_nocache_headers();
				if(XVar.Pack(Security.hasLogin()))
				{
					if(XVar.Pack(!(XVar)(EditPage.processEditPageSecurity((XVar)(GlobalVars.strTableName)))))
					{
						return MVCFunctions.GetBuferContentAndClearBufer();
					}
				}
				EditPage.handleBrokenRequest();
				pageMode = XVar.Clone(EditPage.readEditModeFromRequest());
				xt = XVar.UnPackXTempl(new XTempl());
				id = XVar.Clone(CommonFunctions.postvalue_number(new XVar("id")));
				id = XVar.Clone((XVar.Pack(MVCFunctions.intval((XVar)(id)) == 0) ? XVar.Pack(1) : XVar.Pack(id)));
				keys = XVar.Clone(XVar.Array());
				foreach (KeyValuePair<XVar, dynamic> f in keyFields.GetEnumerator())
				{
					keys.InitAndSetArrayItem(MVCFunctions.postvalue((XVar)(MVCFunctions.Concat("editid", f.Key + 1))), f.Value);
				}
				var_params = XVar.Clone(XVar.Array());
				var_params.InitAndSetArrayItem(id, "id");
				var_params.InitAndSetArrayItem(xt, "xt");
				var_params.InitAndSetArrayItem(keys, "keys");
				var_params.InitAndSetArrayItem(pageMode, "mode");
				var_params.InitAndSetArrayItem(Constants.PAGE_EDIT, "pageType");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("page")), "pageName");
				var_params.InitAndSetArrayItem(GlobalVars.strTableName, "tName");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("a")), "action");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("fields")), "selectedFields");
				var_params.InitAndSetArrayItem(Constants.CaptchaId, "captchaName");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue((XVar)(MVCFunctions.Concat("value_", Constants.CaptchaId, "_", id))), "captchaValue");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("selection")), "selection");
				var_params.InitAndSetArrayItem(MVCFunctions.runner_json_decode((XVar)(MVCFunctions.postvalue(new XVar("rowIds")))), "rowIds");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("mastertable")), "masterTable");
				if(XVar.Pack(var_params["masterTable"]))
				{
					var_params.InitAndSetArrayItem(RunnerPage.readMasterKeysFromRequest(), "masterKeysReq");
				}
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("action")), "lockingAction");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("sid")), "lockingSid");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("keys")), "lockingKeys");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("startEdit")), "lockingStart");
				if(pageMode == Constants.EDIT_INLINE)
				{
					var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("screenWidth")), "screenWidth");
					var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("screenHeight")), "screenHeight");
					var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("orientation")), "orientation");
				}
				if(pageMode == Constants.EDIT_DASHBOARD)
				{
					var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("dashelement")), "dashElementName");
					var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("table")), "dashTName");
					var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("dashPage")), "dashPage");
					if(XVar.Pack(MVCFunctions.postvalue(new XVar("mapRefresh"))))
					{
						var_params.InitAndSetArrayItem(true, "mapRefresh");
						var_params.InitAndSetArrayItem(MVCFunctions.runner_json_decode((XVar)(MVCFunctions.postvalue(new XVar("vpCoordinates")))), "vpCoordinates");
					}
				}
				if((XVar)((XVar)(pageMode == Constants.EDIT_POPUP)  || (XVar)(pageMode == Constants.EDIT_INLINE))  && (XVar)(MVCFunctions.postvalue(new XVar("dashTName"))))
				{
					var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("dashTName")), "dashTName");
					var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("dashelement")), "dashElementName");
					var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("dashPage")), "dashPage");
				}
				if(pageMode == Constants.EDIT_ONTHEFLY)
				{
					var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("table")), "lookupTable");
					var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("field")), "lookupField");
					var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("pageType")), "lookupPageType");
					if(XVar.Pack(MVCFunctions.postvalue(new XVar("parentsExist"))))
					{
						var_params.InitAndSetArrayItem(MVCFunctions.runner_json_decode((XVar)(MVCFunctions.postvalue(new XVar("parentCtrlsData")))), "parentCtrlsData");
					}
				}
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("spreadsheetGrid")), "forSpreadsheetGrid");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("hostPageName")), "hostPageName");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("listPage")), "listPage");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("gantt")), "gantt");
				GlobalVars.pageObject = XVar.Clone(EditPage.EditPageFactory((XVar)(var_params)));
				if(XVar.Pack(GlobalVars.pageObject.isLockingRequest()))
				{
					GlobalVars.pageObject.doLockingAction();
					MVCFunctions.Echo(new XVar(""));
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				GlobalVars.pageObject.init();
				GlobalVars.pageObject.process();
				return null;
			}
			catch(RunnerRedirectException ex)
			{ return Redirect(ex.Message); }
		}
	}
}
