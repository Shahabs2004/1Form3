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
		if (deleted_values == null)
{
    message = "خطا: اطلاعات رکورد برای حذف دریافت نشد";
    return false;
}

if (deleted_values["ID"] == null)
{
    message = "خطا: ID رکورد دریافت نشد";
    return false;
}

int fieldId = int.Parse(deleted_values["ID"].ToString());

dynamic fileId = DB.DBLookup(
    "SELECT TOP 1 ID " +
    "FROM OneForm_Fields " +
    "WHERE Group_ID = " + fieldId
);

if (fileId != null)
{
    message = "رکورد قابل حذف نیست - هنوز سوال مرتبط دارد";
    return false;
}
// No related records
return true;
		return true;
return null;
	}	}
	// Included file globals
	public partial class CommonFunctions
	{
	}
}
