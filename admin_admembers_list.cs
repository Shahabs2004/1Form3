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
		public ActionResult admin_admembers_list()
		{
			try
			{
				dynamic options = XVar.Array(), pageObject = null;
				XTempl xt;
				MVCFunctions.Header("Expires", "Thu, 01 Jan 1970 00:00:01 GMT");
				if(XVar.Pack(!(XVar)(Security.processAdminPageSecurity(new XVar(true)))))
				{
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				xt = XVar.UnPackXTempl(new XTempl());
				options = XVar.Clone(XVar.Array());
				options.InitAndSetArrayItem(Constants.PAGE_ADMIN_ADMEMBERS, "pageType");
				options.InitAndSetArrayItem(CommonFunctions.postvalue_number(new XVar("id")), "id");
				options.InitAndSetArrayItem(Constants.GLOBAL_PAGES, "pageTable");
				options.InitAndSetArrayItem(Constants.MEMBERS_PAGE, "mode");
				options.InitAndSetArrayItem(Constants.stAD, "providerType");
				options.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("provider")), "providerCode");
				options.InitAndSetArrayItem(xt, "xt");
				options.InitAndSetArrayItem(CommonFunctions.postvalue_number(new XVar("goto")), "requestGoto");
				GlobalVars.pageObject = XVar.Clone(ListPage.createListPage(new XVar(Constants.GLOBAL_PAGES), (XVar)(options)));
				if(MVCFunctions.postvalue(new XVar("a")) == "addgr")
				{
					dynamic data = XVar.Array(), dataSource = null, dc = null, label = null, providerCode = null, returnJSON = XVar.Array();
					if(XVar.Pack(!(XVar)(CommonFunctions.isPostRequest())))
					{
						return MVCFunctions.GetBuferContentAndClearBufer();
					}
					returnJSON = XVar.Clone(XVar.Array());
					label = XVar.Clone(MVCFunctions.postvalue(new XVar("name")));
					providerCode = XVar.Clone(MVCFunctions.postvalue(new XVar("provider")));
					dc = XVar.Clone(new DsCommand());
					dc.values.InitAndSetArrayItem(label, "Label");
					if((XVar)(!(XVar)(Security.ADonlyLogin()))  || (XVar)(CommonFunctions.storageGet(new XVar("groups_provider_field"))))
					{
						dc.values.InitAndSetArrayItem(providerCode, "Provider");
					}
					dataSource = XVar.Clone(Security.getUgGroupsDatasource());
					data = XVar.Clone(dataSource.insertSingle((XVar)(dc)));
					if(XVar.Pack(!(XVar)(data)))
					{
						returnJSON.InitAndSetArrayItem(false, "success");
						returnJSON.InitAndSetArrayItem(dataSource.lastError(), "message");
						MVCFunctions.Echo(CommonFunctions.printJSON((XVar)(returnJSON)));
						MVCFunctions.Echo(new XVar(""));
						return MVCFunctions.GetBuferContentAndClearBufer();
					}
					returnJSON.InitAndSetArrayItem(data["GroupID"], "id");
					if(XVar.Pack(!(XVar)(data["GroupID"])))
					{
						dynamic dataMax = XVar.Array(), dcMax = null, rsMax = null;
						dcMax = XVar.Clone(new DsCommand());
						dcMax.totals.InitAndSetArrayItem(new XVar("alias", "maxid", "field", "GroupID", "total", "max"), null);
						rsMax = XVar.Clone(dataSource.getTotals((XVar)(dcMax)));
						if(XVar.Pack(!(XVar)(rsMax)))
						{
							returnJSON.InitAndSetArrayItem(false, "success");
							returnJSON.InitAndSetArrayItem(dataSource.lastError(), "message");
							MVCFunctions.Echo(CommonFunctions.printJSON((XVar)(returnJSON)));
							MVCFunctions.Echo(new XVar(""));
							return MVCFunctions.GetBuferContentAndClearBufer();
						}
						dataMax = XVar.Clone(rsMax.fetchAssoc());
						returnJSON.InitAndSetArrayItem(dataMax["maxid"], "id");
					}
					if(XVar.Pack(!(XVar)(Security.ADonlyLogin())))
					{
						dynamic provider = XVar.Array(), providerLabel = null;
						provider = XVar.Clone(Security.findProvider((XVar)(providerCode)));
						providerLabel = XVar.Clone(CommonFunctions.GetMLString((XVar)(provider["label"])));
						if(XVar.Pack(providerLabel))
						{
							label = XVar.Clone(MVCFunctions.Concat(providerLabel, ":", label));
						}
					}
					returnJSON.InitAndSetArrayItem(label, "label");
					returnJSON.InitAndSetArrayItem(true, "success");
					MVCFunctions.Echo(CommonFunctions.printJSON((XVar)(returnJSON)));
					MVCFunctions.Echo(new XVar(""));
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				GlobalVars.pageObject.prepareForBuildPage();
				GlobalVars.pageObject.showPage();
				return null;
			}
			catch(RunnerRedirectException ex)
			{ return Redirect(ex.Message); }
		}
	}
}
