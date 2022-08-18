

var _DXCode = "";
var _HCPCSCode = "";

var _LcdId;



/*****Start Common Fuctions*/
function LCD_OpenForm(elem, Type, CallFrom) {
    var PagePath = "";
    
    if (Type == "DX") {
        PagePath = _ControlPath + "/LCDDiagnosis.aspx";

        if (CallFrom == "PatientChart") {
            _DXCode = $(elem).closest("tr").find(".DiagCode").val();
        }
        else if (CallFrom == "ClaimForm") {
            _DXCode = $.trim($(elem).closest("td").prev().find("input:text").val());
        }
    }
    else if (Type == "Procedure") {
        PagePath = _ControlPath + "/LCDProcedure.aspx";

        if (CallFrom == "PatientChart") {
            _HCPCSCode = $(elem).closest("tr").find(".hdnCPTCode").val();
        }
        else if (CallFrom == "ClaimForm") {
            _HCPCSCode = $(elem).closest("tr").find(".hdnCPTCode").val();
        }
        
        if (_HCPCSCode == "") {
            return;
        }
    }
    
    var params = {
        DXCode: _DXCode,
        HCPCSCode: _HCPCSCode,
        action: "LoadLCDForm"
    };

    $.post(PagePath, params, function (data) {
        if (!LCD_CheckCount(data)) {
            return;
        }

        var start = data.indexOf("###StartForm###") + 15;
        var end = data.indexOf("###EndForm###");
        var returnHtml = $.trim(data.substring(start, end));

        $("[id$='divDialogLCD']").html(returnHtml)
        .promise()
        .done(function () {
            LCD_OpenForm_Done();
        });
    });
}

function LCD_CheckCount(data) {
    var start = data.indexOf("###StartLCDCount###") + 19;
    var end = data.indexOf("###EndLCDCount###");
    var LcdCount = $.trim(data.substring(start, end));

    if (LcdCount == "") LcdCount = 0;
    LcdCount = parseInt(LcdCount);

    if (LcdCount == 0) {
        showErrorMessage("No Lcd for this code");
        return false;
    }
    
    return true;
}

function LCD_OpenForm_Done() {
    _LcdId = $("#ulPolicies li:first .hdnLcdId").val();

    var dialogHeight = parseInt(WindowHeight()) - 15;

    $("[id$='divDialogLCD']").dialog({
        title: "LCD",
        modal: true,
        width: 1020,
        height: 1100,
        close: function () {
            $("[id$='divDialogLCD']").dialog("destroy");
        }
    });
}

function LCD_SetPolicies(data) {
    var start = data.indexOf("###StartLcdPolicies###") + 22;
    var end = data.indexOf("###EndLcdPolicies###");
    var returnHtml = $.trim(data.substring(start, end));

    $("[id$='ulPolicies']").html(returnHtml);
}


function LCD_SetCommonData(data) {
    LCD_SetLcdTopDescription(data);
    LCD_SetLcdTitle(data);
    LCD_SetLcdDates(data);
    LCD_SetPolicyDescription(data);
}

function LCD_SetLcdTopDescription(data) {
    var start = data.indexOf("###StartLcdTopDescription###") + 28;
    var end = data.indexOf("###EndLcdTopDescription###");
    var returnHtml = $.trim(data.substring(start, end));
    
    $("[id$='spnTopDescription']").html(returnHtml);
}

function LCD_SetLcdTitle(data) {
    var start = data.indexOf("###StartLcdTitle###") + 19;
    var end = data.indexOf("###EndLcdTitle###");
    var returnHtml = $.trim(data.substring(start, end));

    $("[id$='spnLcdTitle']").html(returnHtml);
}

function LCD_SetLcdDates(data) {
    var start = data.indexOf("###StartLcdDates###") + 19;
    var end = data.indexOf("###EndLcdDates###");
    var returnHtml = $.trim(data.substring(start, end));

    $("[id$='spnLcdDates']").html(returnHtml);
}

function LCD_SetPolicyDescription(data) {
    var start = data.indexOf("###StartPolicyDescription###") + 28;
    var end = data.indexOf("###EndPolicyDescription###");
    var returnHtml = $.trim(data.substring(start, end));

    $("[id$='divPolicyDescription']").html(returnHtml);
}
/*****End Common Fuctions*/



/*****Start Diagnosis Fuctions*/
function LCD_FilterPolicies_Dx(elem) {
    var PolicyTitle = $.trim($(elem).val());
    
    var PagePath = _ControlPath + "/CallBacks/LCDDiagnosisActionHandler.aspx";
    
    var params = {
        DXCode: _DXCode,
        PolicyTitle: PolicyTitle,
        action: "FilterLcdPolicies"
    };
    
    $.post(PagePath, params, function (data) {
        LCD_SetPolicies(data);
    });
}

function LCD_ClickLCD_DX(elem) {
    _LcdId = $(elem).closest("li").find(".hdnLcdId").val();
    
    var PagePath = _ControlPath + "/CallBacks/LCDDiagnosisActionHandler.aspx";
    
    var params = {
        LcdId: _LcdId,
        DXCode: _DXCode,
        action: "LoadLcdDetail"
    };

    $.post(PagePath, params, function (data) {
        LCD_SetCommonData(data);
        
        LCD_SetProcedureSupported(data);
    });
}

function LCD_FilterProcedure(elem) {
    var Procedure = $.trim($(elem).val());

    var PagePath = _ControlPath + "/CallBacks/LCDDiagnosisActionHandler.aspx";

    var params = {
        LcdId: _LcdId,
        DXCode: _DXCode,
        Procedure: Procedure,
        action: "FilterProcedureSupported"
    };

    $.post(PagePath, params, function (data) {
        LCD_SetProcedureSupported(data);
    });
}

function LCD_SetProcedureSupported(data) {
    var start = data.indexOf("###StartProcedureSupported###") + 29;
    var end = data.indexOf("###EndProcedureSupported###");
    var returnHtml = $.trim(data.substring(start, end));

    $("[id$='tbodyProcedureSupported']").html(returnHtml);
}
/*****End Diagnosis Fuctions*/




/*****Start Procedure Fuctions*/
function LCD_FilterPolicies_Pr(elem) {
    var PolicyTitle = $.trim($(elem).val());

    var PagePath = _ControlPath + "/CallBacks/LCDProcedureActionHandler.aspx";
    
    var params = {
        HCPCSCode: _HCPCSCode,
        PolicyTitle: PolicyTitle,
        action: "FilterLcdPolicies"
    };

    $.post(PagePath, params, function (data) {
        LCD_SetPolicies(data);
    });
}

function LCD_ClickLCD_Pr(elem) {
    _LcdId = $(elem).closest("li").find(".hdnLcdId").val();

    var PagePath = _ControlPath + "/CallBacks/LCDProcedureActionHandler.aspx";

    var params = {
        LcdId: _LcdId,
        HCPCSCode: _HCPCSCode,
        action: "LoadLcdDetail"
    };
    
    $.post(PagePath, params, function (data) {
        LCD_SetCommonData(data);
    });
}

function LCD_FilterDiagnosisSupported(elem) {
    var Diagnose = $.trim($(elem).val());
    
    var PagePath = _ControlPath + "/CallBacks/LCDProcedureActionHandler.aspx";
    
    var params = {
        LcdId: _LcdId,
        HCPCSCode: _HCPCSCode,
        Diagnose: Diagnose,
        action: "FilterDiagnosisSupported"
    };
    
    $.post(PagePath, params, function (data) {
        LCD_SetDiagnosisSupported(data);
    });
}

function LCD_FilterDiagnosisNotSupported(elem) {
    var Diagnose = $.trim($(elem).val());
    
    var PagePath = _ControlPath + "/CallBacks/LCDProcedureActionHandler.aspx";
    
    var params = {
        LcdId: _LcdId,
        HCPCSCode: _HCPCSCode,
        Diagnose: Diagnose,
        action: "FilterDiagnosisNotSupported"
    };
    
    $.post(PagePath, params, function (data) {
        LCD_SetDiagnosisNotSupported(data);
    });
}

function LCD_SetDiagnosisSupported(data) {
    var start = data.indexOf("###StartDiagnosisSupported###") + 29;
    var end = data.indexOf("###EndDiagnosisSupported###");
    var returnHtml = $.trim(data.substring(start, end));
    
    $("[id$='tbodyDiagnosisSupported']").html(returnHtml);
}

function LCD_SetDiagnosisNotSupported(data) {
    var start = data.indexOf("###StartDiagnosisNotSupported###") + 32;
    var end = data.indexOf("###EndDiagnosisNotSupported###");
    var returnHtml = $.trim(data.substring(start, end));
    
    $("[id$='tbodyDiagnosisNotSupported']").html(returnHtml);
}
/*****End Procedure Fuctions*/
