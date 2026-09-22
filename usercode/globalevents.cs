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
	public partial class class_GlobalEvents : GlobalEventsBase
	{
		protected static bool skipclass_GlobalEventsCtor = false;
		public override XVar init()
		{
			this.events = new XVar(new XVar( "pageEvents", new XVar(  ),
"onScreenEvents", new XVar(  ),
"dashboardEvents", new XVar(  ),
"buttons", new XVar(  ),
"maps", new XVar(  ),
"tablePermissions", new XVar(  ),
"recordEditable", new XVar(  ) ));

			return null;
		}
		public virtual XVar fieldEvent_22751(dynamic _param__params)
		{
			#region pass-by-value parameters
			dynamic _params = XVar.Clone(_param__params);
			#endregion

			dynamic ajax = null, button = null, keys = null, parameters = null, result = null;
			result = XVar.Clone(XVar.Array());
			button = XVar.Clone(this.prepareButtonContext((XVar)(_params)));
			ajax = XVar.Clone(button);
			keys = XVar.Clone(button.getKeys());
			parameters = XVar.Clone(_params);
						string id = parameters["id"].ToString();

result["Fields_Desc"] = tDAL.DBLookup(
    "SELECT Fields_Desc FROM OneForm_Fields WHERE ID = '" + id.Replace("'", "''") + "'"
);			RunnerContext.pop();
			MVCFunctions.Echo(MVCFunctions.runner_json_encode((XVar)(result)));
			button.deleteTempFiles();

			return null;
		}
	}
}
