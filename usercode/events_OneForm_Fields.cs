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
			this.events = new XVar(new XVar(  ));
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
public XVar default_Fields_Desc_efedit(  ) {
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
