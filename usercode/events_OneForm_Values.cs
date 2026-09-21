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
			this.events = new XVar(new XVar(  ));
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
public XVar custom_RecordDate_vfview( dynamic value, dynamic data ) {
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
