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
		public ActionResult login()
		{
			try
			{
				dynamic pageObject = null, var_params = XVar.Array();
				XTempl xt;
				CommonFunctions.add_nocache_headers();
				xt = XVar.UnPackXTempl(new XTempl());
				var_params = XVar.Clone(XVar.Array());
				var_params.InitAndSetArrayItem(CommonFunctions.postvalue_number(new XVar("id")), "id");
				var_params.InitAndSetArrayItem(xt, "xt");
				var_params.InitAndSetArrayItem(Constants.PAGE_LOGIN, "pageType");
				var_params.InitAndSetArrayItem(Constants.GLOBAL_PAGES, "pageTable");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("page")), "pageName");
				var_params.InitAndSetArrayItem(false, "needSearchClauseObj");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("value_captcha_1")), "captchaValue");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("remember_password")), "rememberPassword");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("remember_machine")), "rememberMachine");
				var_params.InitAndSetArrayItem(LoginPage.readLoginModeFromRequest(), "mode");
				var_params.InitAndSetArrayItem(LoginPage.readActionFromRequest(), "action");
				var_params.InitAndSetArrayItem(LoginPage.readMethodFromRequest(), "twoFactorMethod");
				var_params.InitAndSetArrayItem(MVCFunctions.runner_htmlspecialchars((XVar)(MVCFunctions.postvalue(new XVar("message")))), "message");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("username")), "var_pUsername");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("password")), "var_pPassword");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("return")), "redirectAfterLogin");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("2fcode")), "twoFactorCode");
				var_params.InitAndSetArrayItem(Constants.GLOBAL_PAGES, "tName");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("restore")), "restore");
				var_params.InitAndSetArrayItem(MVCFunctions.postvalue(new XVar("provider")), "providerCode");
				GlobalVars.pageObject = XVar.Clone(new LoginPage((XVar)(var_params)));
				GlobalVars.pageObject.init();
				GlobalVars.pageObject.process();
				return null;
			}
			catch(RunnerRedirectException ex)
			{ return Redirect(ex.Message); }
		}
	}
}
