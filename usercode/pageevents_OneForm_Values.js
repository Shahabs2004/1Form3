



Runner.registerFieldEvent( 
	'22751', 
	function( params, ctrl, pageObj, ajax, pageid ) {
		params["id"] = this.getValue();
if (!params["id"])
    return false;
	}, 
	function( result, ctrl, pageObj, ajax, params, pageid ) {
		var description = result["Fields_Desc"] &&
                  result["Fields_Desc"]["Fields_Desc"]
    ? result["Fields_Desc"]["Fields_Desc"]
    : "بدون شرح";

$("#field_id_info").remove();

$("#value_Field_ID_27").closest(".r-integrated-field").after(
    $("<div>", {
        id: "field_id_info",
        class: "form-group",
        css: {
            "margin-top": "6px",
            "color": "blue",
            "font-weight": "bold",
            "whiteSpace": "pre-line"
        },
        text: description
    })
);
	}
);




