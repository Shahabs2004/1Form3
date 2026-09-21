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
	public partial class API : XClass
	{
		public static XVar sendError(dynamic _param_text, dynamic _param_responseCode = null)
		{
			#region default values
			if(_param_responseCode as Object == null) _param_responseCode = new XVar(500);
			#endregion

			#region pass-by-value parameters
			dynamic text = XVar.Clone(_param_text);
			dynamic responseCode = XVar.Clone(_param_responseCode);
			#endregion

			API.sendResponse(new XVar(false), (XVar)(new XVar("error", text)), (XVar)(responseCode));

			return null;
		}
		public static XVar sendResponse(dynamic _param_success, dynamic _param_data, dynamic _param_responseCode = null)
		{
			#region default values
			if(_param_responseCode as Object == null) _param_responseCode = new XVar(0);
			#endregion

			#region pass-by-value parameters
			dynamic success = XVar.Clone(_param_success);
			dynamic data = XVar.Clone(_param_data);
			dynamic responseCode = XVar.Clone(_param_responseCode);
			#endregion

			if(XVar.Pack(!(XVar)(responseCode)))
			{
				responseCode = XVar.Clone((XVar.Pack(success) ? XVar.Pack(200) : XVar.Pack(500)));
			}
			CommonFunctions.http_response_code((XVar)(responseCode));
			data.InitAndSetArrayItem(success, "success");
			MVCFunctions.Echo(MVCFunctions.runner_json_encode((XVar)(data)));
			MVCFunctions.ob_flush();
			HttpContext.Current.Response.End();
			throw new RunnerInlineOutputException();

			return null;
		}
		public static XVar readRecord(dynamic _param_result, dynamic _param_pSet_packed)
		{
			#region packeted values
			ProjectSettings _param_pSet = XVar.UnPackProjectSettings(_param_pSet_packed);
			#endregion

			#region pass-by-value parameters
			dynamic result = XVar.Clone(_param_result);
			ProjectSettings pSet = XVar.Clone(_param_pSet);
			#endregion

			dynamic data = XVar.Array();
			data = XVar.Clone(result.fetchAssoc());
			if(XVar.Pack(!(XVar)(data)))
			{
				return null;
			}
			foreach (KeyValuePair<XVar, dynamic> f in MVCFunctions.array_keys((XVar)(data)).GetEnumerator())
			{
				if((XVar)(CommonFunctions.IsBinaryType((XVar)(pSet.getFieldType((XVar)(f.Value)))))  && (XVar)(ProjectSettings.getProjectValue(new XVar("restAPIReturnEncodedBinary "))))
				{
					data.InitAndSetArrayItem(MVCFunctions.base64_encode((XVar)(data[f.Value])), f.Value);
				}
			}
			return data;
		}
		public static XVar readResult(dynamic _param_result, dynamic _param_pSet_packed, dynamic _param_recordLimit = null)
		{
			#region packeted values
			ProjectSettings _param_pSet = XVar.UnPackProjectSettings(_param_pSet_packed);
			#endregion

			#region default values
			if(_param_recordLimit as Object == null) _param_recordLimit = new XVar(0);
			#endregion

			#region pass-by-value parameters
			dynamic result = XVar.Clone(_param_result);
			ProjectSettings pSet = XVar.Clone(_param_pSet);
			dynamic recordLimit = XVar.Clone(_param_recordLimit);
			#endregion

			dynamic data = null, ret = XVar.Array();
			ret = XVar.Clone(XVar.Array());
			while((XVar)((XVar)(!(XVar)(recordLimit))  || (XVar)(MVCFunctions.count(ret) < recordLimit))  && (XVar)(data = XVar.Clone(API.readRecord((XVar)(result), (XVar)(pSet)))))
			{
				ret.InitAndSetArrayItem(data, null);
			}
			return ret;
		}
		public static XVar login()
		{
			dynamic authType = null;
			if(XVar.Pack(!(XVar)(Security.hasLogin())))
			{
				return true;
			}
			authType = XVar.Clone(ProjectSettings.getProjectValue(new XVar("restAPIAuthType")));
			if(authType == Constants.REST_BASIC)
			{
				dynamic password = null, username = null;
				username = new XVar("");
				password = new XVar("");
				if(ProjectSettings.ext() == "php")
				{
					username = XVar.Clone(MVCFunctions.GetServerVariable("PHP_AUTH_USER"));
					password = XVar.Clone(MVCFunctions.GetServerVariable("PHP_AUTH_PW"));
				}
				if(XVar.Pack(!(XVar)(username)))
				{
					dynamic colonPos = null, loginHeader = null, token = null;
					loginHeader = XVar.Clone(MVCFunctions.Concat(MVCFunctions.getHttpHeader(new XVar("Authorization")), ""));
					if(!XVar.Equals(XVar.Pack(MVCFunctions.substr((XVar)(loginHeader), new XVar(0), new XVar(6))), XVar.Pack("Basic ")))
					{
						MVCFunctions.Header("WWW-Authenticate", "Basic realm=\"REST API\"");
						return false;
					}
					token = XVar.Clone(MVCFunctions.base64_decode((XVar)(MVCFunctions.substr((XVar)(loginHeader), new XVar(6)))));
					colonPos = XVar.Clone(MVCFunctions.strpos((XVar)(token), new XVar(":")));
					if(XVar.Equals(XVar.Pack(colonPos), XVar.Pack(false)))
					{
						return false;
					}
					username = XVar.Clone(MVCFunctions.substr((XVar)(token), new XVar(0), (XVar)(colonPos)));
					password = XVar.Clone(MVCFunctions.substr((XVar)(token), (XVar)(colonPos + 1)));
				}
				return Security.login((XVar)(username), (XVar)(password), new XVar(false), new XVar(true));
			}
			if(authType == Constants.REST_APIKEY)
			{
				dynamic APIkey = null, cipherer = null, dataSource = null, dc = null, loginSet = null, rs = null, userData = XVar.Array();
				APIkey = new XVar("");
				if(XVar.Pack(MVCFunctions.SERVERKeyExists("HTTP_X_AUTH_TOKEN")))
				{
					APIkey = XVar.Clone(MVCFunctions.GetServerVariable("HTTP_X_AUTH_TOKEN"));
				}
				else
				{
					APIkey = XVar.Clone(MVCFunctions.postvalue(new XVar("apikey")));
				}
				if(XVar.Pack(!(XVar)(MVCFunctions.strlen((XVar)(APIkey)))))
				{
					return false;
				}
				if(XVar.Pack(Security.hardcodedLogin()))
				{
					if(ProjectSettings.getProjectValue(new XVar("restAPIKey")) == APIkey)
					{
						Security.createHardcodedSession();
						return true;
					}
					return false;
				}
				dataSource = XVar.Clone(CommonFunctions.getLoginDataSource());
				dc = XVar.Clone(new DsCommand());
				dc.filter = XVar.Clone(DataCondition.FieldEquals((XVar)(ProjectSettings.getProjectValue(new XVar("restAPIKeyField"))), (XVar)(APIkey)));
				rs = XVar.Clone(dataSource.getSingle((XVar)(dc)));
				if(XVar.Pack(!(XVar)(rs)))
				{
					return false;
				}
				loginSet = XVar.Clone(ProjectSettings.getForLogin());
				cipherer = XVar.Clone(RunnerCipherer.getForLogin((XVar)(loginSet)));
				userData = XVar.Clone(cipherer.DecryptFetchedArray((XVar)(rs.fetchAssoc())));
				return Security.login((XVar)(userData[Security.usernameField()]), (XVar)(userData[Security.passwordField()]), new XVar(true), new XVar(true));
			}
			return false;
		}
		public static XVar keysFromRequest(dynamic _param_pSet_packed)
		{
			#region packeted values
			ProjectSettings _param_pSet = XVar.UnPackProjectSettings(_param_pSet_packed);
			#endregion

			#region pass-by-value parameters
			ProjectSettings pSet = XVar.Clone(_param_pSet);
			#endregion

			dynamic keys = XVar.Array();
			keys = XVar.Clone(XVar.Array());
			foreach (KeyValuePair<XVar, dynamic> k in pSet.getTableKeys().GetEnumerator())
			{
				keys.InitAndSetArrayItem(MVCFunctions.postvalue((XVar)(MVCFunctions.Concat("editid", k.Key + 1))), k.Value);
			}
			return keys;
		}
		public static XVar valuesFromRequest(dynamic _param_pSet_packed)
		{
			#region packeted values
			ProjectSettings _param_pSet = XVar.UnPackProjectSettings(_param_pSet_packed);
			#endregion

			#region pass-by-value parameters
			ProjectSettings pSet = XVar.Clone(_param_pSet);
			#endregion

			dynamic values = XVar.Array();
			values = XVar.Clone(XVar.Array());
			foreach (KeyValuePair<XVar, dynamic> f in pSet.getFieldsList().GetEnumerator())
			{
				dynamic value = null;
				value = XVar.Clone(MVCFunctions.postvalue((XVar)(f.Value)));
				if((XVar)((XVar)(value)  || (XVar)(XVar.Equals(XVar.Pack(value), XVar.Pack("0"))))  || (XVar)(MVCFunctions.GetUploadedFileName((XVar)(f.Value))))
				{
					values.InitAndSetArrayItem(API.processRequestValue((XVar)(f.Value), (XVar)(value), (XVar)(pSet)), f.Value);
				}
			}
			return values;
		}
		protected static XVar processRequestValue(dynamic _param_fieldName, dynamic _param_value, dynamic _param_pSet_packed)
		{
			#region packeted values
			ProjectSettings _param_pSet = XVar.UnPackProjectSettings(_param_pSet_packed);
			#endregion

			#region pass-by-value parameters
			dynamic fieldName = XVar.Clone(_param_fieldName);
			dynamic value = XVar.Clone(_param_value);
			ProjectSettings pSet = XVar.Clone(_param_pSet);
			#endregion

			if(XVar.Pack(CommonFunctions.IsBinaryType((XVar)(pSet.getFieldType((XVar)(fieldName))))))
			{
				if((XVar)(value)  && (XVar)(ProjectSettings.getProjectValue(new XVar("restAPIAcceptEncodedBinary"))))
				{
					dynamic decodedValue = null;
					decodedValue = XVar.Clone(MVCFunctions.base64_decode_binary((XVar)(value)));
					if(XVar.Pack(!(XVar)(decodedValue)))
					{
						API.sendError((XVar)(MVCFunctions.Concat("Unable to decode ", fieldName, " value from base64")));
					}
					return decodedValue;
				}
				if(XVar.Pack(MVCFunctions.GetUploadedFileName((XVar)(fieldName))))
				{
					return MVCFunctions.GetUploadedFileContents((XVar)(fieldName));
				}
			}
			return value;
		}
	}
}
