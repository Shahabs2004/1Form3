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
	public partial class eventclass_OneForm_Fields : TableEventsBase
	{
		protected static bool skipeventclass_OneForm_FieldsCtor = false;
		public override XVar init()
		{
			this.events = new XVar(new XVar( "BeforeDelete", true ));
			this.fieldValues = new XVar(new XVar( "filterLimit", new XVar(  ),
"mapIcon", new XVar(  ),
"viewCustom", new XVar(  ),
"lookupWhere", new XVar(  ),
"viewFileText", new XVar(  ),
"defaultValue", new XVar( "Fields_Desc", new XVar( "edit", true ) ),
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
    "FROM OneForm_Values " +
    "WHERE Field_ID = " + fieldId
);

if (fileId != null)
{
    message = "رکورد قابل حذف نیست - هنوز پاسخ مرتبط دارد";
    return false;
}
// No related records
return true;
		return true;
return null;
	}public XVar default_Fields_Desc_efedit(  ) {
	var defaultValue =  @"متن کوتاه :
متن بلند:
چک باکس:
مقدار عددی:";;
return XVar.Pack( defaultValue );
}	}
	// Included file globals
	public partial class CommonFunctions
	{
	}
}
