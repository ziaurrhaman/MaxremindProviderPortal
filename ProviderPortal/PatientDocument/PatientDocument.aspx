<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PatientDocument.aspx.cs" Inherits="ProviderPortal_PatientDocument_PatientDocument" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###StartDocument###
        <link type="text/css" rel="stylesheet" href="../../StyleSheets/customFileUpload.css" />
            <link type="text/css" rel="stylesheet" href="../../StyleSheets/Documents.css" />
            <script type="text/javascript" src="../../Scripts/PatientDocuments.js"></script>
            <script type="text/javascript" src="../../Scripts/DocumentsCommon.js"></script>
            <%--<script type="text/javascript" src="../../Scripts/dynamsoft.webtwain.initiate2.js"></script>--%>
            <%--<script type="text/javascript" src="../../Resources/dynamsoft.webtwain.initiate.js"></script>
        <script type="text/javascript" src="../../Resources/dynamsoft.webtwain.config.js"></script>
            --%>
            <style type="text/css">
                .inline-icons {
                    margin: 0 8px 0;
                    float: left;
                }

                #tbodyDocumentCategory tr {
                    cursor: pointer;
                }

                .row-selected {
                    background-color: #D0E6FB !important;
                }

                #divDocumentUpload {
                    position: absolute;
                    background-color: white;
                    top: 29px;
                    left: 62px;
                    width: 400px;
                }

                    #divDocumentUpload tr:hover {
                        background-color: transparent;
                    }

                    #divDocumentUpload td {
                        border: none !important;
                    }

                #PatientDocumentsList tr td:nth-child(n+3):not(:nth-last-child(-n+1)) {
                    cursor: pointer;
                }

                #divDialogDocumentsViewer img {
                    max-width: 100%;
                }

                #divDialogDocumentsViewer embed {
                    width: 100%;
                    height: 1068px;
                }

                .spandelete {
                    background: url('../../Images/cross.png');
                    background-repeat: no-repeat;
                    height: 23px;
                    background-position: left;
                    padding-left: 18px;
                    cursor: pointer;
                }

                .spanupload {
                    background-image: url('../../Images/uploadIcon.png');
                    background-repeat: no-repeat;
                    height: 16px;
                    background-position: left;
                    padding-left: 18px;
                    cursor: pointer;
                }

                .spanscan {
                    background-image: url('../../Images/scan.png');
                    background-repeat: no-repeat;
                    height: 16px;
                    background-position: left;
                    padding-left: 18px;
                    cursor: pointer;
                }

                .spneye {
                    background-image: url('../../Images/view1.png');
                    background-repeat: no-repeat;
                    width: 18px;
                    height: 18px;
                    float: left;
                    background-position: left;
                    cursor: pointer;
                }

                .spnedit {
                    background-image: url('../../Images/edit.png');
                    background-repeat: no-repeat;
                    width: 18px;
                    height: 18px;
                    float: left;
                    background-position: left;
                    cursor: pointer;
                }

                .spndelete {
                    width: 18px;
                    height: 18px;
                    float: left;
                    background: url('../../Images/recycleBin.png');
                    cursor: pointer;
                    background-repeat: no-repeat;
                    background-position: left;
                }

                .spndownload {
                    width: 18px;
                    height: 18px;
                    float: left;
                    background: url('../../Images/download.png');
                    cursor: pointer;
                    background-repeat: no-repeat;
                    background-position: left;
                }
            </style>
            <script type="text/javascript">
                function UploadPatientDocument1() {
                    debugger;
                    ActionDocument = "Upload";
                    OpenDocumentForm1(0);
                    $("[id$='hdnPatientIdDoc']").val(0);
                }
                function OpenDocumentForm1(DocumentId) {

                    debugger;
                    $.post(_EMRPath + "/PatientDocument/CallBacks/PatientDocumentForm.aspx", { DocumentId: DocumentId }, function (data) {
                        var start = data.indexOf("###Start###") + 11;
                        var end = data.indexOf("###End###");

                        var returnHtml = $.trim(data.substring(start, end));

                        $("#divDialogDocumentForm").html(returnHtml)
                        .promise()
                        .done(function () {
                            PatientDocumentFormReady();
                            PatientDocumentFormReadyCommon();

                            if (DocumentId != 0) {
                                $("[id$='txtPatientNameDoc']").val(_DocumentPatientName);
                            }

                            $("#divDialogDocumentForm").dialog({
                                resizable: false,
                                title: 'Scan Document',
                                width: 800,
                                modal: true,
                                buttons: {
                                    "Scan": function () {
                                        showErrorMessage("Scaner is not connected!!!");
                                        //return false;
                                    },
                                    "Cancel": function () {
                                        $(this).dialog("destroy");
                                    }
                                },
                                beforeClose: function () {
                                    ResetDivEditFields();
                                },
                                close: function () {
                                    showDocuments();
                                    $(this).dialog("destroy");
                                }
                            });
                        });
                    });
                }
            </script>
            <asp:HiddenField runat="server" ID="hdnPracticeDocumentPath" />
            <asp:HiddenField runat="server" ID="hdnPatientIdDoc" Value="0" />

            <div class="float-left-100">
                <span class="inline-icons spandelete" style="height: 16px; width: 30px; padding-left: 18px" onclick="DeleteMultipleDocuments();">Delete
                </span>
                <span class="inline-icons spanupload" onclick="UploadPatientDocument();">Upload
                </span>
                <span class="inline-icons spanscan" onclick="UploadPatientDocument1();">Scan
                </span>
                <span style="display: none" class="inline-icons spanemail" onclick="PracticeDocumentEmail();">Email</span>
                <%--<span style="float: left; cursor: pointer;" onclick="">Sign</span>--%>
            </div>
            <div id="divPatientDocumentContainer" class="float-left-100" style="margin-top: 10px;padding:7px 7px 7px 7px;">
                <div class="Grid Widget" style="width: 100%;box-sizing: border-box;margin-bottom:7px;">
                    <table id="tblPatientDocuments">
                        <thead>
                            <tr>
                                <th></th>
                                <th></th>
                                <th>Date
                                </th>
                                <th>Document
                                </th>
                                <th>Document Type
                                </th>
                                <th>Provider
                                </th>
                                <th>Action
                                </th>
                            </tr>
                            <tr>
                                <th align="center">
                                    <span class="iconSearch"></span>
                                </th>
                                <th>
                                    <input type="checkbox" id="cbDocumentsAll" onclick="checkUncheckAllDocuments(this);" />
                                </th>
                                <th>
                                    <input type="text" id="txtSearchByDate" onkeyup="FilterPatientDocuments(0,true);"  onclick="GetdatePicker();"/>
                                </th>
                                <th>
                                    <input type="text" id="txtSearchByName" onkeyup="FilterPatientDocuments(0,true);" />
                                </th>
                                <th>
                                    <asp:DropDownList ID="ddlCategory" runat="server" Onchange="FilterPatientDocuments(0,true);"></asp:DropDownList>
                                </th>
                                <th>
                                    <input type="text" id="txtSearchByProvider" onkeyup="FilterPatientDocuments(0,true);" />
                                </th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody id="PatientDocumentsList">
                            <asp:Repeater ID="rptPatientDocuments" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td align="center">
                                            <i><%# Eval("RowNumber") %></i>
                                        </td>
                                        <td align="center">
                                            <input type="hidden" class="DocumentId" value='<%# Eval("DocumentId") %>'>
                                            <input type="checkbox" class="CheckUncheckDoc" />
                                        </td>
                                        <td onclick="EditPatientDocument(this)">
                                            <span class="spnCurrentDocDate">
                                                <%# Eval("DocumentDate") %>
                                            </span>
                                        </td>
                                        <td onclick="EditPatientDocument(this)">
                                            <%# Eval("DocumentName") %>
                                        </td>
                                        <td onclick="EditPatientDocument(this)">
                                            <%# Eval("CategoryName") %>
                                        </td>
                                       <%-- <td>
                                            <span class="EditPatientName" style="cursor: pointer; color: blue; text-decoration: underline;"
                                                onclick="AssignDocumentToPatient(this);">
                                                <%# Eval("PatientName")%></span>
                                        </td>--%>
                                        <td onclick="EditPatientDocument(this)">
                                            <%# Eval("ProviderName")%>
                                        </td>
                                        <td class="action">
                                            <div>
                                                <span class="spneye" onclick="ViewPatientDocument(this)" title="View"></span>
                                                <span class="spnedit" onclick="EditPatientDocument(this)" title="Edit"></span>
                                                <span class="spndelete" onclick="DeletePatientDocument(this)" title="Delete"></span>
                                                <span class="spndownload" onclick="DownloadPatientDocumentFileAll(this)" title="Download"></span>

                                                <input type="hidden" class="hdnDocumentId" value='<%#Eval("DocumentId") %>' />
                                                <input type="hidden" class="hdnPatientId" value='<%# Eval("PatientId") %>' />
                                                <input type="hidden" class="hdnPatientName" value='<%# Eval("PatientName") %>' />
                                            </div>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                    <div class="table-footer">
                    <div class="message">
                        <span class="iconInfo" style="margin: 7px;"></span><span class="spanInfo"></span>
                    </div>
                    <div class="pager" style="box-sizing:border-box;">
                        <div class="PageEntries">
                            <span style="float: left; margin-left: 5px;">Show&nbsp;</span><span style="float: left;">
                                <select id="ddlPagingPatientDocument" style="margin-top: 5px;" onchange="RowsChange('FilterPatientDocuments');">
                                    <option value="10">10</option>
                                    <option value="25">25</option>
                                    <option value="50">50</option>
                                    <option value="75">75</option>
                                    <option value="100">100</option>
                                </select>
                            </span><span style="float: left;">&nbsp;entries</span>
                        </div>
                        <div class="PageButtons">
                            <ul style="float: right; margin-right: 15px;">
                            </ul>
                        </div>
                    </div>
                    </div>

                </div>
            </div>



            <style>
                body {
                    background: #f1f1f1;
                }

                #content {
                    width: 705px;
                    height: 710px;
                    padding: 50px 40px 40px;
                    margin: 0 auto;
                    border: solid 1px #ccc;
                    background: #fff;
                }

                #group1 {
                    height: 40px;
                    margin-bottom: 45px;
                }

                #group2 {
                    height: 40px;
                }

                #source {
                    height: 40px;
                    width: 310px;
                    outline: none;
                    border-radius: 3px;
                    font-size: 18px;
                    padding-left: 5px;
                }

                input.btn {
                    width: 60px;
                    height: 40px;
                    margin-left: 18px;
                    background: #f8f8f8;
                    border: solid 1px #ccc;
                    border-radius: 3px;
                    outline: none;
                    cursor: pointer;
                }

                input.upload {
                    width: 80px;
                }

                #group2 label {
                    margin: 10px 25px 0 0;
                }

                #group2 input[type='radio'] {
                    height: 18px;
                    width: 18px;
                    vertical-align: sub;
                }

                #dwtcontrolContainer {
                    max-width: 700px;
                    max-height: 560px;
                    border: solid 1px #ccc;
                    border-radius: 3px;
                    margin-top: 20px;
                    outline: none;
                    padding: 3px 0 0 5px;
                    font-size: 16px;
                }

                .fl {
                    float: left;
                }

                .fr {
                    float: right;
                }
            </style>

            <div id="wrapper" style="display: none;">
                <div class="container">
                    <div id="main">
                        <div id="content">
                            <form>
                                <disv id="group1">

                            <select id="source" class="fl"></select>
                            <input class="btn fl" type="button" value="Scan" onclick="AcquireImage();" />
                            <input class="btn fl" type="button" value="Load" onclick="LoadImage();" />
                        </disv>
                                <br />
                                <div id="group2">
                                    <input class="btn upload fr" type="button" value="Upload" onclick="UploadImage();" />
                                    <label class="fr" for="imgTypepdf">
                                        <input type="checkbox" value="quiet" name="quietScan" id="quietScan" />Quiet
                                    </label>
                                    <label class="fr" for="imgTypejpeg">
                                        <input type="radio" value="jpg" name="ImageType" id="imgTypejpeg" checked="checked" />JPEG
                                    </label>
                                    <label class="fr" for="imgTypetiff">
                                        <input type="radio" value="tif" name="ImageType" id="imgTypetiff" />TIFF
                                    </label>
                                    <label class="fr" for="imgTypepdf">
                                        <input type="radio" value="pdf" name="ImageType" id="imgTypepdf" />PDF
                                    </label>
                                    <div class="fr" style="width: 200px;" id="uploadedFile"></div>
                                </div>
                                <!-- dwtcontrolContainer is the default div id for Dynamic Web TWAIN control.
                        If you need to rename the id, you should also change the id in the dynamsoft.webtwain.config.js accordingly. -->
                                <div id="dwtcontrolContainer"></div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
            <script type="text/javascript">
                //Dynamsoft.WebTwainEnv.RegisterEvent('OnWebTwainReady', Dynamsoft_OnReady); // Register OnWebTwainReady event. This event fires as soon as Dynamic Web TWAIN is initialized and ready to be used

                var DWObject, CurrentPath, strHTTPServer;
                var strHTTPPort, strActionPage;

                //function Dynamsoft_OnReady() {
                //    strHTTPServer = window.location.protocol + "//" + location.hostname; // for https://

                //    var CurrentPathName = unescape(location.pathname);
                //    CurrentPath = CurrentPathName.substring(0, CurrentPathName.lastIndexOf("/") + 1);
                //    DWObject = Dynamsoft.WebTwainEnv.GetWebTwain('dwtcontrolContainer'); // Get the Dynamic Web TWAIN object that is embeded in the div with id 'dwtcontrolContainer'
                //    if (DWObject) {
                //        DWObject.Height = 553;
                //        DWObject.Width = 693;
                //        DWObject.RegisterEvent('OnInternetTransferPercentage', function (sPercentage) {
                //            console.log(sPercentage);
                //        });
                //        var count = DWObject.SourceCount; // Populate how many sources are installed in the system
                //        for (var i = 0; i < count; i++)
                //            document.getElementById("source").options.add(new Option(DWObject.GetSourceNameItems(i), i));  // Add the sources in a drop-down list
                //        document.getElementById("imgTypejpeg").checked = true;
                //    }

                //    DWObject.RegisterEvent('OnPostAllTransfers', function () {
                //        //alert(DWObject.HowManyImagesInBuffer);
                //        btnUpload_onclick();
                //    });
                //}

                function acquireImage() {
                    debugger;
                    if (DWObject) {
                        //DWObject.SelectSourceByIndex(document.getElementById("source").selectedIndex);
                        DWObject.SelectSource();

                        DWObject.CloseSource();
                        DWObject.OpenSource();
                        DWObject.IfDisableSourceAfterAcquire = true;	// Scanner source will be disabled/closed automatically after the scan.
                        DWObject.AcquireImage();
                    }
                }



                //Callback functions for async APIs
                function OnSuccess() {
                    //console.log('successful');
                    //alert("OnSuccess");

                }

                function OnFailure(errorCode, errorString) {
                    alert(errorString);
                }

                function LoadImage() {
                    if (DWObject) {
                        DWObject.IfShowFileDialog = true; // Open the system's file dialog to load image
                        DWObject.LoadImageEx("", EnumDWT_ImageType.IT_ALL, OnSuccess, OnFailure); // Load images in all supported formats (.bmp, .jpg, .tif, .png, .pdf). sFun or fFun will be called after the operation
                    }
                }

                function OnHttpUploadSuccess() {
                    //console.log('successful');
                    //alert("OnHttpUploadSuccess");
                    btnUpload_onclick();
                }

                function OnHttpServerReturnedSomething(errorCode, errorString, sHttpResponse) {
                    var textFromServer = sHttpResponse;
                    if (textFromServer.indexOf('DWTBarcodeUploadSuccess') != -1) {
                        var url = 'http://' + location.hostname + ':' + location.port + CurrentPath + 'UploadedImages/' + textFromServer.substr(24);
                        document.getElementById('uploadedFile').innerHTML = "Uploaded File: <a href='" + url + "' target='_blank'>" + textFromServer.substr(24) + "</a>";
                    }
                }

                function UploadImage() {
                    if (DWObject) {
                        // If no image in buffer, return the function
                        DWObject.IfShowCancelDialogWhenImageTransfer = !document.getElementById('quietScan').checked;
                        if (DWObject.HowManyImagesInBuffer == 0)
                            return;
                        var strActionPage = CurrentPath + "SaveToFile.aspx";
                        DWObject.IfSSL = false; // Set whether SSL is used
                        DWObject.HTTPPort = location.port == "" ? 80 : location.port;

                        var Digital = new Date();
                        var uploadfilename = Digital.getMilliseconds(); // Uses milliseconds according to local time as the file name

                        // Upload the image(s) to the server asynchronously
                        if (document.getElementById("imgTypejpeg").checked == true) {
                            DWObject.HTTPUploadThroughPost(strHTTPServer, DWObject.CurrentImageIndexInBuffer, strActionPage, uploadfilename + ".jpg", OnHttpUploadSuccess, OnHttpServerReturnedSomething);
                        }
                        else if (document.getElementById("imgTypetiff").checked == true) {
                            DWObject.HTTPUploadAllThroughPostAsMultiPageTIFF(strHTTPServer, strActionPage, uploadfilename + ".tif", OnHttpUploadSuccess, OnHttpServerReturnedSomething);
                        }
                        else if (document.getElementById("imgTypepdf").checked == true) {
                            DWObject.HTTPUploadAllThroughPostAsPDF(strHTTPServer, strActionPage, uploadfilename + ".pdf", OnHttpUploadSuccess, OnHttpServerReturnedSomething);
                        }
                    }
                }

                function initPara() {

                    //strHTTPServer = location.hostname; // For localhost & http://
                    //strHTTPServer = window.location.protocol + "//" + location.hostname; // for https://
                    strHTTPServer = "https://www.nubsoft.com/";
                    debugger;

                    strHTTPPort = location.port == "" ? 80 : location.port;

                    if (location.hostname != "") {
                        var CurrentPathName = unescape(location.pathname); // get current PathName in plain ASCII
                        strActionPage = CurrentPathName.substring(0, CurrentPathName.lastIndexOf("/") + 1) + "SaveToFile.aspx"; //the ActionPage's file path
                    }
                    else {
                        strActionPage = "SaveToFile.aspx"; //the ActionPage's file path
                    }
                }

                function btnUpload_onclick() {
                    //var DWObject = gWebTwain.getInstance();

                    debugger;

                    if (DWObject) {
                        if (DWObject.HowManyImagesInBuffer == 0) {
                            return;
                        }

                        DWObject.HTTPPort = strHTTPPort;

                        DWObject.HTTPUserName = "administrator";
                        DWObject.HTTPPassword = "admin";

                        DWObject.SetCookie(_ServerCookies);

                        strActionPage = _PatientDocumentCallBacksPath + "/ScanFileUpload.ashx"; //the ActionPage's file path

                        var uploadfilename = "WebTWAINImage.pdf";

                        DWObject.HTTPUploadAllThroughPostAsPDF(
                            strHTTPServer,
                            strActionPage,
                            uploadfilename
                        );

                        /*
                        DWObject.HTTPUploadThroughPostEx(
                            strHTTPServer,
                            DWObject.CurrentImageIndexInBuffer,
                            strActionPage,
                            uploadfilename
                        );
                        
                        DWObject.HTTPUploadThroughPostAsMultiPageTIFF(
                            strHTTPServer,
                            strActionPage,
                            uploadfilename
                        );
                        */

                        var filePath = _PracticeId + "/" + "Patients/Documents/" + DWObject.HTTPPostResponseString;

                        AppendUploadedFile(DWObject.HTTPPostResponseString, filePath, DWObject.HTTPPostResponseString);

                        DWObject.RemoveAllImages();
                    }
                }
                /*******added by shahid kazmi 2/6/2018 for bug id =7200******/
                function GetdatePicker()
                {
                    debugger;
                    $("#txtSearchByDate").datepicker({
                        changeMonth: true,
                        changeYear: true
                    }).mask("99/99/9999");
                }
                /**********end shahid kazmi 2/6/2028********/
            </script>


            <div id="divDialogConfirmation" title="Confirmation!" style="display: none;"></div>
            <div id="divConfirmSaveChanges" style="display: none;">
                <p>
                    Do you want to save pending changes of document category first?
                </p>
            </div>

            <div id="divSearchPatient" style="display: none;">
                /div>
        
        <asp:HiddenField runat="server" ID="hdnTotalDocRows" />
                <input type="hidden" id="hdnNewPatientId" />
                <asp:HiddenField ID="hdnChartId" runat="server" />
                <input type="hidden" id="hdnDocumentName" />
                <input type="hidden" id="hdnOriginalName" />
                <input type="hidden" id="hdnEditDocument" />
                <asp:HiddenField ID="hdnDocumentFilesPath" runat="server" />

                <div id="ConfirmDeleteion" style="display: none">
                    Are you sure you want to delete it?
                </div>

                <div id="divPopup" style="display: none;"></div>
                <script src="../Settings/Setting.js" type="text/javascript"></script>

                <script type="text/javascript">
                    $(document).ready(function () {
                        forDocumentReady();
                    });
                </script>

                <style type="text/css">
                    #EditUpload {
                        height: 18px;
                        left: 0;
                        opacity: 0;
                        position: absolute;
                        top: 0;
                        width: 67px;
                        z-index: 1;
                    }

                    #Edit-Attach-Link {
                        color: #1155CC !important;
                        text-decoration: none;
                        left: 2px;
                        position: absolute;
                        top: 1px;
                        z-index: 0;
                    }

                    .tdEditDoc {
                        text-align: left;
                    }
                </style>

                <div id="divDialogDocumentForm" style="display: none;"></div>
                <div id="divPatientAttachmentsMainWrapper" style="display: none;"></div>

                <div id="divFilePaths" style="display: none;"></div>
                <div id="divDialogDocumentsViewer" style="display: none;"></div>
                ###EndDocument###
            </div>
    </form>
</body>
</html>
