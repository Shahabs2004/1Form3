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
		public XVar v1()
		{
			try
			{
				dynamic action = null, dataSource = null, dc = null, eventsObject = null, keys = XVar.Array(), newRecordData = XVar.Array(), pageObj = null, ret = XVar.Array(), rs = null, sqlValues = XVar.Array(), usermessage = null;
				ProjectSettings pSet;
				GlobalVars.restApiCall = new XVar(true);
				CommonFunctions.add_nocache_headers();
				MVCFunctions.storeJSONDataFromRequest();
				if(XVar.Pack(!(XVar)(ProjectSettings.getProjectValue(new XVar("createRestAPI")))))
				{
					return MVCFunctions.GetBuferContentAndClearBufer();
				}
				MVCFunctions.Header("Content-Type", "application/json");
				if(XVar.Pack(!(XVar)(API.login())))
				{
					API.sendError(new XVar("Access denied"), new XVar(401));
				}
				XSession.Session.Abandon();
				GlobalVars.table = XVar.Clone(CommonFunctions.findTable((XVar)(MVCFunctions.postvalue(new XVar("table")))));
				if(XVar.Pack(!(XVar)(GlobalVars.table)))
				{
					API.sendError(new XVar("Unknown table name"), new XVar(403));
				}
				pSet = XVar.UnPackProjectSettings(new ProjectSettings((XVar)(GlobalVars.table)));
				eventsObject = XVar.Clone(CommonFunctions.getEventObject((XVar)(pSet)));
				GlobalVars.cipherer = XVar.Clone(new RunnerCipherer((XVar)(GlobalVars.table), (XVar)(pSet)));
				action = XVar.Clone(MVCFunctions.postvalue(new XVar("action")));
				if(XVar.Equals(XVar.Pack(action), XVar.Pack("list")))
				{
					dynamic order = null, srchObj = null;
					if(XVar.Pack(!(XVar)(pSet.pageTypeAvailable(new XVar("list")))))
					{
						API.sendError(new XVar("operation not supported"));
					}
					if(XVar.Pack(!(XVar)(Security.userCan(new XVar("S"), (XVar)(GlobalVars.table)))))
					{
						API.sendError(new XVar("operation not allowed"));
					}
					dataSource = XVar.Clone(CommonFunctions.getDataSource((XVar)(GlobalVars.table), (XVar)(pSet)));
					srchObj = XVar.Clone(SearchClause.getSearchObject((XVar)(GlobalVars.table)));
					dc = XVar.Clone(new DsCommand());
					dc.filter = XVar.Clone(DataCondition._And((XVar)(new XVar(0, Security.SelectCondition(new XVar("S"), (XVar)(pSet)), 1, srchObj.getSearchDataCondition()))));
					order = XVar.Clone(MVCFunctions.postvalue(new XVar("orderby")));
					if(XVar.Pack(order))
					{
						dynamic orderFields = XVar.Array(), projectFields = null;
						orderFields = XVar.Clone(MVCFunctions.explode(new XVar(";"), (XVar)(order)));
						projectFields = XVar.Clone(pSet.getFieldsList());
						dc.order.InitAndSetArrayItem(XVar.Array(), null);
						foreach (KeyValuePair<XVar, dynamic> f in orderFields.GetEnumerator())
						{
							dynamic dir = null, field = null;
							dir = XVar.Clone((XVar.Pack(MVCFunctions.substr((XVar)(f.Value), new XVar(0), new XVar(1)) == "d") ? XVar.Pack("desc") : XVar.Pack("asc")));
							field = XVar.Clone(MVCFunctions.trim((XVar)(MVCFunctions.substr((XVar)(f.Value), new XVar(1)))));
							if(XVar.Pack(MVCFunctions.in_array((XVar)(field), (XVar)(projectFields))))
							{
								dc.order.InitAndSetArrayItem(new XVar("column", field, "dir", dir), null);
							}
						}
					}
					if(XVar.Pack(MVCFunctions.postvalue(new XVar("skip"))))
					{
						dc.startRecord = XVar.Clone((int)MVCFunctions.postvalue(new XVar("skip")));
					}
					if(XVar.Pack(MVCFunctions.postvalue(new XVar("records"))))
					{
						dc.reccount = XVar.Clone((int)MVCFunctions.postvalue(new XVar("records")));
					}
					else
					{
						dc.reccount = new XVar(200);
					}
					rs = XVar.Clone(dataSource.getList((XVar)(dc)));
					if(XVar.Pack(!(XVar)(rs)))
					{
						API.sendError((XVar)(dataSource.lastError()));
					}
					API.sendResponse(new XVar(true), (XVar)(new XVar("data", API.readResult((XVar)(rs), (XVar)(pSet), (XVar)(dc.reccount)))));
				}
				if(XVar.Equals(XVar.Pack(action), XVar.Pack("view")))
				{
					if(XVar.Pack(!(XVar)(pSet.pageTypeAvailable(new XVar("view")))))
					{
						API.sendError(new XVar("operation not supported"));
					}
					if(XVar.Pack(!(XVar)(Security.userCan(new XVar("S"), (XVar)(GlobalVars.table)))))
					{
						API.sendError(new XVar("operation not allowed"));
					}
					dataSource = XVar.Clone(CommonFunctions.getDataSource((XVar)(GlobalVars.table), (XVar)(pSet)));
					dc = XVar.Clone(new DsCommand());
					dc.keys = XVar.Clone(API.keysFromRequest((XVar)(pSet)));
					dc.filter = XVar.Clone(Security.SelectCondition(new XVar("S"), (XVar)(pSet)));
					rs = XVar.Clone(dataSource.getSingle((XVar)(dc)));
					if(XVar.Pack(!(XVar)(rs)))
					{
						API.sendError((XVar)(dataSource.lastError()));
					}
					API.sendResponse(new XVar(true), (XVar)(new XVar("data", API.readRecord((XVar)(rs), (XVar)(pSet)))));
				}
				if(XVar.Equals(XVar.Pack(action), XVar.Pack("update")))
				{
					dynamic keyWhereClause = null, oldKeys = null, oldRecordData = null;
					if(XVar.Pack(!(XVar)(pSet.pageTypeAvailable(new XVar("edit")))))
					{
						API.sendError(new XVar("operation not supported"));
					}
					if(XVar.Pack(!(XVar)(Security.userCan(new XVar("E"), (XVar)(GlobalVars.table)))))
					{
						API.sendError(new XVar("operation not allowed"));
					}
					dataSource = XVar.Clone(CommonFunctions.getDataSource((XVar)(GlobalVars.table), (XVar)(pSet)));
					oldKeys = XVar.Clone(API.keysFromRequest((XVar)(pSet)));
					newRecordData = XVar.Clone(API.valuesFromRequest((XVar)(pSet)));
					oldRecordData = new XVar(null);
					if((XVar)(eventsObject.exists(new XVar("BeforeEdit")))  || (XVar)(eventsObject.exists(new XVar("AfterEdit"))))
					{
						dynamic fetchedArray = null;
						dc = XVar.Clone(new DsCommand());
						dc.filter = XVar.Clone(Security.SelectCondition(new XVar("E"), (XVar)(pSet)));
						dc.keys = XVar.Clone(oldKeys);
						fetchedArray = XVar.Clone(dataSource.getSingle((XVar)(dc)).fetchAssoc());
						oldRecordData = XVar.Clone(GlobalVars.cipherer.DecryptFetchedArray((XVar)(fetchedArray)));
					}
					sqlValues = XVar.Clone(XVar.Array());
					if(XVar.Pack(eventsObject.exists(new XVar("BeforeEdit"))))
					{
						dynamic beforeEdit = null;
						usermessage = new XVar("");
						keyWhereClause = XVar.Clone(CommonFunctions.KeyWhere((XVar)(oldKeys), (XVar)(GlobalVars.table)));
						pageObj = new XVar(null);
						beforeEdit = XVar.Clone(eventsObject.BeforeEdit((XVar)(newRecordData), (XVar)(sqlValues), (XVar)(keyWhereClause), (XVar)(oldRecordData), (XVar)(oldKeys), ref usermessage, new XVar(false), (XVar)(pageObj)));
						if(XVar.Pack(!(XVar)(beforeEdit)))
						{
							API.sendResponse(new XVar(false), (XVar)(new XVar("success", false, "error", usermessage)));
						}
					}
					dc = XVar.Clone(new DsCommand());
					dc.keys = XVar.Clone(oldKeys);
					dc.filter = XVar.Clone(Security.SelectCondition(new XVar("E"), (XVar)(pSet)));
					dc.values = XVar.Clone(newRecordData);
					dc.advValues = XVar.Clone(XVar.Array());
					foreach (KeyValuePair<XVar, dynamic> sqlValue in sqlValues.GetEnumerator())
					{
						dc.advValues.InitAndSetArrayItem(new DsOperand(new XVar(Constants.dsotSQL), (XVar)(sqlValue.Value)), sqlValue.Key);
					}
					ret = XVar.Clone(dataSource.updateSingle((XVar)(dc)));
					if((XVar)(ret)  && (XVar)(eventsObject.exists(new XVar("AfterEdit"))))
					{
						keys = XVar.Clone(oldKeys);
						foreach (KeyValuePair<XVar, dynamic> v in newRecordData.GetEnumerator())
						{
							if(XVar.Pack(keys.KeyExists(v.Key)))
							{
								keys.InitAndSetArrayItem(v.Value, v.Key);
							}
						}
						keyWhereClause = XVar.Clone(CommonFunctions.KeyWhere((XVar)(keys), (XVar)(GlobalVars.table)));
						pageObj = new XVar(null);
						eventsObject.AfterEdit((XVar)(newRecordData), (XVar)(keyWhereClause), (XVar)(oldRecordData), (XVar)(keys), new XVar(false), (XVar)(pageObj));
					}
					if(XVar.Pack(ret))
					{
						API.sendResponse(new XVar(true), (XVar)(new XVar("success", true)));
					}
					else
					{
						API.sendResponse(new XVar(false), (XVar)(new XVar("success", false, "error", dataSource.lastError())));
					}
					API.sendResponse((XVar)(ret["success"]), (XVar)(ret));
				}
				if(XVar.Equals(XVar.Pack(action), XVar.Pack("insert")))
				{
					if(XVar.Pack(!(XVar)(pSet.pageTypeAvailable(new XVar("add")))))
					{
						API.sendError(new XVar("operation not supported"));
					}
					if(XVar.Pack(!(XVar)(Security.userCan(new XVar("A"), (XVar)(GlobalVars.table)))))
					{
						API.sendError(new XVar("operation not allowed"));
					}
					newRecordData = XVar.Clone(API.valuesFromRequest((XVar)(pSet)));
					sqlValues = XVar.Clone(XVar.Array());
					if(XVar.Pack(eventsObject.exists(new XVar("BeforeAdd"))))
					{
						usermessage = new XVar("");
						pageObj = new XVar(null);
						if(XVar.Pack(!(XVar)(eventsObject.BeforeAdd((XVar)(newRecordData), (XVar)(sqlValues), ref usermessage, new XVar(false), (XVar)(pageObj)))))
						{
							API.sendResponse(new XVar(false), (XVar)(new XVar("success", false, "error", usermessage)));
						}
					}
					dataSource = XVar.Clone(CommonFunctions.getDataSource((XVar)(GlobalVars.table), (XVar)(pSet)));
					dc = XVar.Clone(new DsCommand());
					dc.values = XVar.Clone(newRecordData);
					dc.advValues = XVar.Clone(XVar.Array());
					foreach (KeyValuePair<XVar, dynamic> sqlValue in sqlValues.GetEnumerator())
					{
						dc.advValues.InitAndSetArrayItem(new DsOperand(new XVar(Constants.dsotSQL), (XVar)(sqlValue.Value)), sqlValue.Key);
					}
					ret = XVar.Clone(dataSource.insertSingle((XVar)(dc)));
					if((XVar)(ret)  && (XVar)(eventsObject.exists(new XVar("AfterAdd"))))
					{
						pageObj = new XVar(null);
						newRecordData = XVar.Clone(ret);
						keys = XVar.Clone(XVar.Array());
						foreach (KeyValuePair<XVar, dynamic> kf in pSet.getTableKeys().GetEnumerator())
						{
							keys.InitAndSetArrayItem(newRecordData[kf.Value], kf.Value);
						}
						eventsObject.AfterAdd((XVar)(newRecordData), (XVar)(keys), new XVar(false), (XVar)(pageObj));
					}
					if(!XVar.Equals(XVar.Pack(ret), XVar.Pack(false)))
					{
						API.sendResponse(new XVar(true), (XVar)(new XVar("success", true, "data", ret)));
					}
					else
					{
						API.sendResponse(new XVar(false), (XVar)(new XVar("success", false, "error", dataSource.lastError())));
					}
				}
				if(XVar.Equals(XVar.Pack(action), XVar.Pack("delete")))
				{
					dynamic deletedValues = null, userMessage = null, whereClause = null;
					if(XVar.Pack(!(XVar)(pSet.pageTypeAvailable(new XVar("list")))))
					{
						API.sendError(new XVar("operation not supported"));
					}
					if(XVar.Pack(!(XVar)(Security.userCan(new XVar("D"), (XVar)(GlobalVars.table)))))
					{
						API.sendError(new XVar("operation not allowed"));
					}
					dataSource = XVar.Clone(CommonFunctions.getDataSource((XVar)(GlobalVars.table), (XVar)(pSet)));
					dc = XVar.Clone(new DsCommand());
					dc.keys = XVar.Clone(API.keysFromRequest((XVar)(pSet)));
					dc.filter = XVar.Clone(Security.SelectCondition(new XVar("D"), (XVar)(pSet)));
					whereClause = new XVar("");
					deletedValues = XVar.Clone(XVar.Array());
					if((XVar)(eventsObject.exists(new XVar("BeforeDelete")))  || (XVar)(eventsObject.exists(new XVar("AfterDelete"))))
					{
						dynamic deletedResult = null;
						deletedResult = XVar.Clone(dataSource.getSingle((XVar)(dc)));
						if(XVar.Pack(deletedResult))
						{
							deletedValues = XVar.Clone(GlobalVars.cipherer.DecryptFetchedArray((XVar)(deletedResult.fetchAssoc())));
						}
						whereClause = XVar.Clone(CommonFunctions.KeyWhere((XVar)(dc.keys), (XVar)(GlobalVars.table)));
					}
					if(XVar.Pack(eventsObject.exists(new XVar("BeforeDelete"))))
					{
						userMessage = new XVar("");
						pageObj = new XVar(null);
						if(XVar.Pack(!(XVar)(eventsObject.BeforeDelete((XVar)(whereClause), (XVar)(deletedValues), ref userMessage, (XVar)(pageObj)))))
						{
							API.sendResponse(new XVar(false), (XVar)(new XVar("success", false, "error", userMessage)));
						}
					}
					ret = XVar.Clone(dataSource.deleteSingle((XVar)(dc)));
					if((XVar)(ret)  && (XVar)(eventsObject.exists(new XVar("AfterDelete"))))
					{
						userMessage = new XVar("");
						pageObj = new XVar(null);
						eventsObject.AfterDelete((XVar)(whereClause), (XVar)(deletedValues), ref userMessage, (XVar)(pageObj));
					}
					if(XVar.Pack(ret))
					{
						API.sendResponse(new XVar(true), (XVar)(new XVar("success", true)));
					}
					else
					{
						API.sendResponse(new XVar(false), (XVar)(new XVar("success", false, "error", dataSource.lastError())));
					}
				}
				API.sendError(new XVar("unknown operation"));
				return MVCFunctions.GetBuferContentAndClearBufer();
			}
			catch(RunnerRedirectException ex)
			{ return Redirect(ex.Message); }
		}
	}
}
