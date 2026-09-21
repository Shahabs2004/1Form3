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
	public partial class eventclass_OneForm_Fields_Groups : TableEventsBase
	{
		protected static bool skipeventclass_OneForm_Fields_GroupsCtor = false;
		public override XVar init()
		{
			this.events = new XVar(new XVar( "BeforeDelete", true ));
			this.fieldValues = new XVar(new XVar( "filterLimit", new XVar(  ),
"mapIcon", new XVar(  ),
"viewCustom", new XVar(  ),
"lookupWhere", new XVar(  ),
"viewFileText", new XVar(  ),
"defaultValue", new XVar(  ),
"autoUpdateValue", new XVar(  ),
"uploadFolder", new XVar(  ),
"viewPluginInit", new XVar(  ),
"editPluginInit", new XVar(  ) ));

			return null;
		}

public XVar BeforeDelete( dynamic where, dynamic deleted_values, ref dynamic message, dynamic pageObject ) {
		// Place event code here.
// Use "Add Action" button to add code snippets.
dynamic rs = DB.Query("select * from OneForm_Fields where Group_ID="+deleted_values["ID"]); 
dynamic data = rs.fetchAssoc(); 
if(data) {  
    message = "رکورد قابل حذف نیست-سوالهای مرتبط دارد"; 
    return false;
} else {  
    // if dont exist do something else 
return true;
}
		return true;
return null;
	}	}
	// Included file globals
	public partial class CommonFunctions
	{
	}
}
