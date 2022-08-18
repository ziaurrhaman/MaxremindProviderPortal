<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddSubscriberHandler.aspx.cs" Inherits="ProviderPortal_Controls_CallBacks_AddSubscriberHandler" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###AddSubscriberStart###
        <asp:HiddenField runat="server" ID="hdnSubscriberId" Value="0" />
            <style type="text/css">
                .tblPatientDemographics .tdLabel {
                    text-align: right;
                    height: 35px;
                    padding-right: 15px;
                }

                .tblPatientDemographics input[type="text"] {
                    width: 70%;
                }

                .tblPatientDemographics select {
                    width: 75%;
                }

               .themeButton {
                    /*border-left: 1px solid #e6e6e6;         border-right: 1px solid #e6e6e6;         border-top: 1px solid #e6e6e6;         border-bottom: 1px solid #a2a2a2;*/
                    border-left: 1px solid #FCFCFC;
                    border-right: 1px solid #FBF8F8;
                    border-top: 1px solid #FCF8F8;
                    border-bottom: 1px solid #a1daff;
                    color: #53595F;
                    border-radius: 3px;
                    font-size: 12px;
                    padding: 6px;
                    cursor: pointer;
                    min-width: 88px;
                    font-weight: bold;
                    margin-bottom: 0;
                    filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#ffffff', endColorstr='#ededed', GradientType=0 );
                    text-align: center;
                    vertical-align: middle;
                    background-color: #f5f5f5;
                    background-repeat: repeat-x;
                    -webkit-border-radius: 4px;
                    -moz-border-radius: 4px;
                    border-radius: 4px;
                    -webkit-box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.2), 0 1px 2px rgba(0, 0, 0, 0.05);
                    -moz-box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.2), 0 1px 2px rgba(0, 0, 0, 0.05);
                    box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.2), 0 1px 2px rgba(0, 0, 0, 0.05); /*background-image: linear-gradient(to bottom, #FFF, #C0C0C0);*/
                    background-image: linear-gradient(to bottom, #b9e4ff, #a1daff);
                }

                .spnError {
                    color: Red;
                }
            </style>
            <table id="tblAddSubscriber" class="tblPatientDemographics" width="100%">
                <tr style="width: 100%">
                    <td style="width: 33%; vertical-align: top;">
                        <div class="header">
                            General Information
                        </div>
                        <div style="width: 100%; float: left;">
                            <table width="100%" cellspacing="0" cellpadding="0" class="tblContent">
                                <tr>
                                    <td class="tdLabel" style="width: 40%;">
                                        <span id="Span1" class="spanTitle" runat="server">First Name: </span><span class="spnError">*</span>
                                    </td>
                                    <td class="tdDataField" style="width: 60%;">
                                        <input id="txtAddSubscriberFirstName" maxlength="25" onkeypress="return allowCharacters(event,'abcdefghijklmnopqrstuvwxyz ')"
                                            class="required" runat="server" type="text" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdLabel">
                                        <span id="Span2" class="spanTitle" runat="server">Middle Name:</span>
                                    </td>
                                    <td class="tdDataField">
                                        <input id="txtAddSubscriberMiddleName" maxlength="25" onkeypress="return allowCharacters(event,'abcdefghijklmnopqrstuvwxyz ')"
                                            runat="server" type="text" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdLabel">
                                        <span id="Span3" class="spanTitle" runat="server">Last Name: </span><span class="spnError">*</span>
                                    </td>
                                    <td class="tdDataField">
                                        <input id="txtAddSubscriberLastName" maxlength="25" onkeypress="return allowCharacters(event,'abcdefghijklmnopqrstuvwxyz ')"
                                            class="required" runat="server" type="text" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdLabel">
                                        <span id="Span4" class="spanTitle" runat="server">Date of Birth:</span> <span class="spnError">*</span>
                                    </td>
                                    <td class="tdDataField">
                                        <input id="txtAddSubscriberDOB" runat="server" class="required date1" type="text" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdLabel">
                                        <span id="Span5" class="spanTitle" runat="server">SSN:</span>
                                    </td>
                                    <td class="tdDataField">
                                        <input id="txtAddSubscriberSSN" onkeypress="return ValidateNumber(event)" maxlength="15" runat="server"
                                            type="text" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdLabel">
                                        <span id="Span6" class="spanTitle" runat="server">Gender:</span>
                                    </td>
                                    <td class="tdDataField">
                                        <asp:DropDownList ID="ddlAddSubscriberGender" runat="server">
                                            <asp:ListItem Value="Male">Male</asp:ListItem>
                                            <asp:ListItem Value="Female">Female</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdLabel">
                                        <span id="Span7" class="spanTitle" runat="server">Marital Status:</span>
                                    </td>
                                    <td class="tdDataField">
                                        <asp:DropDownList ID="ddlAddSubscriberMaritalStatus" runat="server">
                                            <asp:ListItem Value="Single">Single</asp:ListItem>
                                            <asp:ListItem Value="Married">Married</asp:ListItem>
                                            <asp:ListItem Value="Divorced">Divorced</asp:ListItem>
                                            <asp:ListItem Value="Separated">Separated</asp:ListItem>
                                            <asp:ListItem Value="Widowed">Widowed</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                    <td style="width: 33%; vertical-align: top;">
                        <div class="header">
                            Addres Information
                        </div>
                        <div style="width: 100%; float: left;">
                            <table style="width: 100%" class="tblContent" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="tdLabel" style="width: 30%;">
                                        <span id="Span8" class="spanTitle" runat="server">Address:</span> <span class="spnError">*</span>
                                    </td>
                                    <td class="tdDataField" style="width: 70%;">
                                        <input id="txtAddSubscriberAddress" maxlength="100" class="required" runat="server" type="text" />
                                    </td>
                                </tr>
                                <%--edited by shahid kazmi 2/8/2018--%>
                                <tr>
                                    <td class="tdLabel">
                                        <span id="Span9" class="spanTitle" runat="server">ZIP:</span>
                                    </td>
                                    <td class="tdDataField">
                                        <%--<input id="txtAddSubscriberdZip" maxlength="9" onkeypress="return ValidateNumber(event)" onblur="getStateCity('txtAddSubscriberdZip','txtAddSubscriberCity','ddlAddSubscriberState');" runat="server" type="text" />--%>
                                        <input id="txtAddSubscriberdZip" maxlength="9" onkeypress="return ValidateNumber(event)" onkeyup="getZipCityState(this,'txtAddSubscriberdZip','txtAddSubscriberCity','ddlAddSubscriberState');" runat="server" type="text" class="zip" />
                                        <div class="inline-search-wrapper" style="top: 595px; width: 230px;">
                                            <div class="divZipCityResult" style="width: 35%; position: absolute; z-index: 10; max-height: 152px; overflow-x: hidden; overflow-y: scroll">
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdLabel">
                                        <span id="Span10" class="spanTitle" runat="server">City:</span> <span class="spnError">*</span>
                                    </td>
                                    <td class="tdDataField">
                                        <%--<input id="txtAddSubscriberCity" maxlength="25" class="required" runat="server" type="text"  />--%>
                                        <input id="txtAddSubscriberCity" maxlength="25" class="required" onkeyup="getZipCityState(this,'txtAddSubscriberdZip','txtAddSubscriberCity','ddlAddSubscriberState');" runat="server" type="text">
                                        <div class="inline-search-wrapper" style="top: 595px; width: 230px;">
                                            <div class="divZipCityResult" style="width: 35%; position: absolute; z-index: 10; max-height: 152px; overflow-x: hidden; overflow-y: scroll">
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdLabel">
                                        <span id="Span11" class="spanTitle" runat="server">State:</span>
                                    </td>
                                    <td class="tdDataField">
                                        <asp:DropDownList ID="ddlAddSubscriberState" AppendDataBoundItems="true" runat="server" Enabled="false">
                                            <asp:ListItem Text="" Value=""></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <%--end shahid kazmi 2/8/2018--%>
                                <tr>
                                    <td class="tdLabel">
                                        <span id="Span12" class="spanTitle" runat="server">Home Phone:</span>
                                    </td>
                                    <td class="tdDataField">
                                        <input id="txtAddSubscriberHomePhone" maxlength="13" runat="server" type="text" class="phone" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdLabel">
                                        <span id="Span13" class="spanTitle" runat="server">Cell:</span>
                                    </td>
                                    <td class="tdDataField">
                                        <input id="txtAddSubscriberCell" maxlength="13" runat="server" type="text" class="phone" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdLabel">
                                        <span id="Span14" class="spanTitle" runat="server">Work Phone:</span>
                                    </td>
                                    <td class="tdDataField">
                                        <input id="txtAddSubscriberWorkPhone" maxlength="13" runat="server" type="text" class="phone" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdLabel">
                                        <span id="Span15" class="spanTitle" runat="server">Ext:</span>
                                    </td>
                                    <td class="tdDataField">
                                        <input id="txtAddSubscriberExt" runat="server" type="text" maxlength="5" onkeypress="return ValidateNumber(event)" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdLabel">
                                        <span id="Span16" class="spanTitle" runat="server">E-mail:</span>
                                    </td>
                                    <td class="tdDataField">
                                        <input id="txtAddSubscriberEmail" maxlength="50" runat="server" onkeypress="validateEmail" type="text" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: right; border-top: 1px solid #DDDDDD;">
                        <div class="action-button-wrapper" style="height: 30px !important; margin-top: 7px;">
                            <a href="javascript:void(0)" onclick="SaveSubscriber();" style="padding-left: 24px; text-decoration:  none;" class="themeButton">
                                <span class="span-action-sprite span-save-sprite"></span>Save </a>
                            <a href="javascript:void(0)" onclick="CloseSubscriberAddDialog();" style="padding-left: 24px; text-decoration:  none;" class="themeButton">
                                <span class="span-action-sprite span-cancel-sprite"></span>Cancel </a>
                        </div>
                    </td>
                </tr>
            </table>
            ###AddSubscriberEnd###
        </div>
    </form>
</body>
</html>

