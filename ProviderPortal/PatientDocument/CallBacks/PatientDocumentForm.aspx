<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PatientDocumentForm.aspx.cs" Inherits="ProviderPortal_PatientDocument_CallBacks_PatientDocumentForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../Scripts/jquery-1.9.0.js" type="text/javascript"></script>


</head>
<body>
    <form id="form1" runat="server">
        ###Start###
    <div>
        <asp:HiddenField runat="server" ID="hdnPatientDocumentId" Value="0" />
        <asp:HiddenField runat="server" ID="hdnUserName" Value="0" />
        <style type="text/css">
            .header {
                height: 25px; /*color:#454545;*/
                color: #666;
                font-weight: bold;
                border-bottom: 1px solid #B7BAbC;
                width: 95%;
                float: left;
                font-size: 13px;
                margin-bottom: 5px;
            }
        </style>
        <div id="divPatientDocumentsForm" style="width: 50%">
            <table id="tblEdit" class="tblPatientDemographics" style="width: 98% !important;">
                <tr>
                    <td style="vertical-align: top;">
                        <div class="header">
                            Details
                        </div>
                        <div class="float-left-100">
                            <table width="98%" cellspacing="0" cellpadding="0" style="margin-left: 18px; width:98% !important;">
                                <tr>
                                    <td>Document Name:<span class="spnError">*</span>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtDocumentName" CssClass="required"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdEditDoc">
                                        <span>Document Type:</span><span class="spnError">*</span>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlPatientDocumentType" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdEditDoc">
                                        <span>Date:</span><span class="spnError">*</span>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtPatientDocumentDate" CssClass="Date required IsDate"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr id="trPatientDocumentPatientInfo" style="display: none;">
                                    <td>
                                        <span>Patient:</span>
                                    </td>
                                    <td>
                                        <input type="text" value="" id="txtPatientNameDoc" disabled="disabled" placeholder="Search Patient"
                                            style="width: 96px; float: left; margin: 0; font-size: 11px; height: 16px;" onclick="SearchPatient();" />
                                        <span style="float: left"><span class="spnAdd" id="AddPrimary" onclick="SearchPatient();"></span>&nbsp;<span class="spnRemove" onclick="$('#txtPatientNameDoc').val('');"></span></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdEditDoc" style="height: 25px;">
                                        <span>Confidental:</span>
                                    </td>
                                    <td>
                                        <asp:CheckBox runat="server" ID="chkPatientDocumentIsConfedential" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="float-left-100">
                            <div class="header">
                                Comments
                            </div>
                            <table width="100%" cellspacing="0" cellpadding="0" style="margin-left: 18px;">
                                <tr>
                                    <td class="tdEditDoc" style="vertical-align: top">Comments
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtPatientDocumentComments" TextMode="MultiLine" Style="margin-right: 15px; width: 245px; height: 69px; border-width: 1px; border-color: #c4c4c4"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdEditDoc">
                                        <span>Provider:</span>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlPatientDocumentPracticeUsers" runat="server" Style="width: 165px;"></asp:DropDownList>

                                        <span id="spnAssignMeDoc" runat="server" style="position: relative; left: 11px; top: 9px;">
                                            <a href="#" id="btnAssignMeDoc" onclick="AssignMeDoc();" style="color: #1155CC;">Assign to me</a>
                                        </span>
                                        <asp:HiddenField runat="server" ID="hdnLoggedProvideId" Value="0" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
        </div>

        <div id="divPatientDocumentsFiles">
            <div class="header">
                Attachment(s)
                <div style="float: right;">

                    <a href="javascript:void(0);" id="linkUploadFiles" style="color: #1155CC; ">Upload file(s)</a>

                    <a href="javascript:void(0);" onclick="acquireImage();" class="scan-link" style="color: #1155CC; padding: 0 7px; border-right: 1px solid; display: none;" >Scan file(s)</a>
                    <%--<a href="javascript:void(0);" onclick="btnUpload_onclick();" class="scan-link" style="color: #1155CC;">Upload</a>--%>

                    <%--<div id="dwtcontrolContainer" class="DWTContainer" style="width: 0; height: 0;"></div>--%>
                </div>
            </div>

            <div id="divPatientDocumentsFilesInner">
                <asp:Repeater ID="rptDocumentAttachments" runat="server"
                    OnItemDataBound="rptDocumentAttachments_ItemDataBound">
                    <ItemTemplate>
                        <div class="patient-document-files-wrapper">
                            <%--<img src='<%#Eval("DocumentPath") %>'>--%>
                            <span class="spnFileLink"></span>
                            <input type="hidden" class="hdnPatientDocumentAttachmentsId" value='<%#Eval("PatientDocumentAttachmentsId") %>' />
                            <input type="hidden" class="hdnDocumentPath" value='<%#Eval("DocumentPath") %>' />
                            <input type="hidden" class="hdnOriginalFileName" value="<%#Eval("OriginalFileName") %>" />
                            <input type="hidden" class="hdnDeleted" value="false" />
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>

        <%--<script type="text/javascript" src="../../Scripts/ScanControl.js"></script>--%>
        <%--<script type="text/javascript" src="../../Scripts/ScanControl2.js"></script>--%>



        <script type="text/javascript">
            $(function () {
                SetFileLink();
            });

            $(document).on("mouseenter", ".patient-document-files-wrapper", function () {
                $(this).find(".hover-action-div").show();
            });

            $(document).on("mouseleave", ".patient-document-files-wrapper", function () {
                $(this).find(".hover-action-div").hide();
            });

            function SetFileLink() {
                $("#divPatientDocumentsFilesInner .patient-document-files-wrapper").each(function () {
                    var OriginalFileName = $(this).find(".hdnOriginalFileName").val();
                    var path = $(this).find(".hdnDocumentPath").val();

                    $(this).find(".spnFileLink").replaceWith(GetFileLink(OriginalFileName, path));
                });
            }
        </script>

        <style type="text/css">
            #dwtcontrolContainer_NonInstallCID > div {
                display: block;
                border: none !important;
                text-align: center !important;
                width: 382px !important;
                height: 246px !important;
                position: absolute !important;
                right: 16px !important;
                top: 40px !important;
                background: #fff !important;
                z-index: 99999 !important;
            }

            #dwtcontrolContainer_NonInstallCID a {
                text-decoration: underline;
                color: blue;
            }

            #dwtcontrolContainer_Obj {
                width: 0 !important;
                height: 0 !important;
            }

            #dwtcontrolContainer_CID {
                width: 0 !important;
                height: 0 !important;
            }
        </style>
        ###End###
    </form>
</body>
</html>

