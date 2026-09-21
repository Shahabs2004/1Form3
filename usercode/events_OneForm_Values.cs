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
	public partial class eventclass_OneForm_Values : TableEventsBase
	{
		protected static bool skipeventclass_OneForm_ValuesCtor = false;
		public override XVar init()
		{
			this.events = new XVar(new XVar( "BeforeDelete", true ));
			this.fieldValues = new XVar(new XVar( "filterLimit", new XVar(  ),
"mapIcon", new XVar(  ),
"viewCustom", new XVar( "RecordDate", new XVar( "view", true ) ),
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


// Check Files
dynamic fileId = DB.DBLookup(
    "SELECT TOP 1 ID " +
    "FROM OneForm_Value_Files " +
    "WHERE OneForm_Value_ID = " + fieldId
);

if (fileId != null)
{
    message = "رکورد قابل حذف نیست - هنوز فایل مرتبط دارد";
    return false;
}


// Check Images
dynamic imageId = DB.DBLookup(
    "SELECT TOP 1 ID " +
    "FROM OneForm_Values_Images " +
    "WHERE OneForm_Value_ID = " + fieldId
);

if (imageId != null)
{
    message = "رکورد قابل حذف نیست - هنوز تصویر مرتبط دارد";
    return false;
}


// No related records
return true;
		return true;
return null;
	}public XVar custom_RecordDate_vfview( dynamic value, dynamic data ) {
	if (value == null || value == DBNull.Value)
    return "";

DateTime date;

if (value is DateTime)
{
    date = (DateTime)value;
}
else if (!DateTime.TryParse(value.ToString(), out date))
{
    return "";
}

System.Globalization.PersianCalendar pc =
    new System.Globalization.PersianCalendar();

return String.Format("{0:0000}/{1:00}/{2:00}",
    pc.GetYear(date),
    pc.GetMonth(date),
    pc.GetDayOfMonth(date));;
return value;
}	}
	// Included file globals
	public partial class CommonFunctions
	{
	}
}
