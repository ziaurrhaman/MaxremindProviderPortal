

var _dwtParamCheckInForm = {
    'productKey': '4254F831C08CB763EA98956EFEA23E39B65ACCCB591CC08377EBEC8E62A784C710000000',
    'containerID': 'dwtcontrolContainerCheckInForm',   //The ID of Dynamic Web TWAIN control div in HTML.This value is required.
    'isTrial': 'false',
    /*
    'isTrial': 'true',  
    isTrial is used to judge whether Dynamic Web TWAIN control is trial or full. This value is optional.
    The default value is 'TRUE', which means the control is a trial one. The value of isTrial is 'TRUE' or 'FALSE'.
    */

    /*
    'version': '9,2',   
    The version of Dynamic Web TWAIN control, which is used to judge the version when downloading CAB.
    This value is optional. The default value is '9,2'.
    */

    /*
    'resourcesPath': 'Resources',   
    The relative path of MSI, CAB and PKG.
    This value is optional. The default value is 'Resources'.
    */

    /*
    'width': 580,       //The width of Dynamic Web TWAIN control
    This value is optional. The default value is '580'.
    */

    /*
    'height': 600       //The height of  Dynamic Web TWAIN control
    This value is optional. The default value is '600'.
    */

    /*  These are events. The name of 'OnPostAllTransfer' shouldn't be changed, but the name of 'Dynamsoft_OnPostAllTransfers' can be modified. 
    Please pay attention, the name of 'Dynamsoft_OnPostAllTransfers' and 'function Dynamsoft_OnPostAllTransfers()' event must be coincident.
        
    Events are as follows. You can choose one or many according to you needs.
    Once an event is added, you must make sure the corresponding function is defined in your code.
        
    'onPostTransfer':Dynamsoft_OnPostTransferCheckInForm,
    'onPostAllTransfers':Dynamsoft_OnPostAllTransfersCheckInForm,  
    'onMouseClick':Dynamsoft_OnMouseClick,   
    'onPostLoad':Dynamsoft_OnPostLoadfunction,
    'onImageAreaSelected':Dynamsoft_OnImageAreaSelected,   
    'onMouseDoubleClick':Dynamsoft_OnMouseDoubleClick,   
    'onMouseRightClick':Dynamsoft_OnMouseRightClick,   
    'onTopImageInTheViewChanged':Dynamsoft_OnTopImageInTheViewChangedCheckInForm,   
    'onImageAreaDeSelected':Dynamsoft_OnImageAreaDeselected,    
    'onGetFilePath':Dynamsoft_OnGetFilePath  
    */

    'onPostTransfer': Dynamsoft_OnPostTransferCheckInForm,
    'onPostAllTransfers': Dynamsoft_OnPostAllTransfersCheckInForm,
    //'onPostLoad': Dynamsoft_OnPostLoadfunction,
    'onTopImageInTheViewChanged': Dynamsoft_OnTopImageInTheViewChangedCheckInForm
};


var gWebTwainCheckInForm;
var strHTTPServerCheckInForm, strHTTPPortCheckInForm, strActionPageCheckInForm;

//$(function () {
//    gWebTwainCheckInForm = new Dynamsoft.WebTwain(_dwtParamCheckInForm);
//});

var seed;
function onPageLoadCheckInForm() {
    //initInfo();            //Add guide info
    debugger;
    initParaCheckInForm();
    seed = setInterval(initControlCheckInForm, 500);
}


function initControlCheckInForm() {
    var DWObject = gWebTwainCheckInForm.getInstance();
    
    if (DWObject) {
        if (DWObject.ErrorCode == 0) {
            clearInterval(seed);
            DWObject.BrokerProcessType = 1;
        }
    }
}

function acquireImageCheckInForm() {
    var DWObject = gWebTwainCheckInForm.getInstance();
    //var DWObject = Dynamsoft.WebTwainEnv.GetWebTwain('dwtcontrolContainer');

    if (DWObject) {
        if (DWObject.SourceCount > 0) {
            DWObject.SelectSource();

            DWObject.CloseSource();
            DWObject.OpenSource();
            DWObject.Resolution = "100";
            DWObject.AcquireImage();
        }
        else {
            alert("No TWAIN compatible drivers detected.");
        }
    }
}

function Dynamsoft_OnPostTransferCheckInForm() {
    UploadScannedFileCheckInForm();
}

function Dynamsoft_OnPostAllTransfersCheckInForm() {
    UploadScannedFileCheckInForm();
}

function Dynamsoft_OnTopImageInTheViewChangedCheckInForm(index) {
    var DWObject = gWebTwainCheckInForm.getInstance();

    if (DWObject) {
        DWObject.CurrentImageIndexInBuffer = index;
    }
}

function initParaCheckInForm() {
    strHTTPServerCheckInForm = location.hostname; // For localhost & http://
    //strHTTPServerCheckInForm = window.location.protocol + "//" + location.hostname; // for https://

    strHTTPPortCheckInForm = location.port == "" ? 80 : location.port;

    if (location.hostname != "") {
        var CurrentPathName = unescape(location.pathname); // get current PathName in plain ASCII
        strActionPageCheckInForm = CurrentPathName.substring(0, CurrentPathName.lastIndexOf("/") + 1) + "SaveToFile.aspx"; //the ActionPage's file path
    }
    else {
        strActionPageCheckInForm = "SaveToFile.aspx"; //the ActionPage's file path
    }
}

function UploadScannedFileCheckInForm() {
    var DWObject = gWebTwainCheckInForm.getInstance();

    if (DWObject) {
        if (DWObject.HowManyImagesInBuffer == 0) {
            return;
        }

        DWObject.HTTPPort = strHTTPPortCheckInForm;

        DWObject.HTTPUserName = "administrator";
        DWObject.HTTPPassword = "admin";

        DWObject.SetCookie(_ServerCookies);

        strActionPageCheckInForm = _ControlPath + "/CheckInFormScan.ashx"; //the ActionPage's file path

        var uploadfilename = "WebTWAINImage.PNG";

        DWObject.HTTPUploadThroughPost(
            strHTTPServerCheckInForm,
            0,
            strActionPageCheckInForm,
            uploadfilename
        );

        /*
        DWObject.HTTPUploadThroughPostEx(
        strHTTPServerCheckInForm,
        DWObject.CurrentImageIndexInBuffer,
        strActionPageCheckInForm,
        uploadfilename
        );
        
        DWObject.HTTPUploadThroughPostAsMultiPageTIFF(
        strHTTPServerCheckInForm,
        strActionPageCheckInForm,
        uploadfilename
        );
        */

        SetScannedFile(DWObject.HTTPPostResponseString);
        
        DWObject.RemoveAllImages();
    }
}