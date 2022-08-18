<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Insurances.aspx.cs" Inherits="EMR_Settings_CallBacks_Insurances" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    ###StartInsurance###
    <div id="divInsurances">
        <div class="SettingWrapperAction">
            <%--<a href="javascript:void(0);" class="themeButton" style="padding-left: 25px;" onclick="AddNewInsurance();">
                <span class="span-settings-sprite span-settings-Insurance"></span>Add Insurance
            </a>--%>
        </div>

        <div class="Grid" style="display:none" id="divInsuranceGrid">
            <table>
                <thead>
                    <tr>
                        <th style="width: 2%;">
                        </th>
                        <th>
                            Name
                        </th>
                        <th>
                            Type
                        </th>
                       
                         <th>
                            City
                        </th>
                        <th>
                            State
                        </th>
                        <th>
                            Email
                        </th>
                        <th>
                            Phone
                        </th>
                        <th>
                            Fax
                        </th>
                        <th style="width: 50px;">
                            Action
                        </th>
                    </tr>
                </thead>
                <tbody id="InsuranceList">
                    <asp:Repeater ID="rptInsurances" runat="server" 
                        onitemdatabound="rptInsurances_ItemDataBound">
                        <ItemTemplate>
                            <tr style="cursor: default" class="<%#setClass(Convert.ToInt32(Eval("PracticeId")))%>">
                                <td style="color: #444 ">
                                    <%# Eval("RowNumber") %>
                                </td>
                                <td>
                                    <%# Eval("Name")%>
                                </td>
                                <td>
                                    <%# Eval("InsuranceType")%>
                                </td>
                                
                                <td>
                                    <%# Eval("City")%>
                                </td>
                                <td>
                                    <%# Eval("InsuranceStateName")%>
                                </td>
                                <td>
                                    <%# Eval("Email")%>
                                </td>
                                <td style="white-space: nowrap;">
                                    <%# Eval("Phone1")%>
                                </td>
                               <td style="white-space: nowrap;">
                                    <%# Eval("Fax")%>
                                </td>
                                <td class="action" style="white-space:nowrap; text-align: center;">
                                    <asp:Label ID="lblAction" runat="server"></asp:Label>
                                </td>
                                <td style="display: none;">
                                    <%# Eval("TaxId")%>
                                    |
                                    <%# Eval("InsuranceType")%>
                                    |
                                    <%# Eval("InsuranceCategory")%>
                                    |
                                    <%# Eval("InsuranceCategoryId")%>
                                    |
                                    <%# Eval("Zip")%>
                                    |
                                    <%# Eval("Phone2")%>
                                    |
                                    <%# Eval("Phone3")%>
                                    |
                                    <%# Eval("InsuranceStateCode")%> 
                                    |
                                    <%# Eval("HeadOfficeAddress")%>
                                                                 
                                </td>
                                <td style="display:none;">
                                <asp:Label ID="lblPracticeId" Text='<%# Eval("PracticeId")%>' runat="server"></asp:Label>
                                <asp:Label ID="lblInsuranceId" Text='<%# Eval("InsuranceId")%>' runat="server"></asp:Label>                                
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr style="cursor: default" class="alternatingRow <%#setClass(Convert.ToInt32(Eval("PracticeId")))%>" >
                                <td style="color: #444 ">
                                    <%# Eval("RowNumber") %>
                                </td>
                                <td>
                                    <%# Eval("Name")%>
                                </td>
                                <td>
                                    <%# Eval("InsuranceType")%>
                                </td>
                                
                                <td>
                                    <%# Eval("City")%>
                                </td>
                                <td>
                                    <%# Eval("InsuranceStateName")%>
                                </td>
                                <td>
                                    <%# Eval("Email")%>
                                </td>
                               <td style="white-space: nowrap;">
                                    <%# Eval("Phone1")%>
                                </td>
                               <td style="white-space: nowrap;">
                                    <%# Eval("Fax")%>
                                </td>
                                <td class="action" style=" text-align: center;">
                                   <asp:Label ID="lblAction" runat="server"></asp:Label>
                                </td>
                                <td style="display: none;">
                                    <%# Eval("TaxId")%>
                                    |
                                    <%# Eval("InsuranceType")%>
                                    |
                                    <%# Eval("InsuranceCategory")%>
                                    |
                                    <%# Eval("InsuranceCategoryId")%>
                                    |
                                    <%# Eval("Zip")%>
                                    |
                                    <%# Eval("Phone2")%>
                                    |
                                    <%# Eval("Phone3")%>
                                    |
                                    <%# Eval("InsuranceStateCode")%>   
                                    | 
                                    <%# Eval("HeadOfficeAddress")%>
                                                                                                      
                                </td>
                                 <td style="display:none;">
                                <asp:Label ID="lblPracticeId" Text='<%# Eval("PracticeId")%>' runat="server"></asp:Label>
                                <asp:Label ID="lblInsuranceId" Text='<%# Eval("InsuranceId")%>' runat="server"></asp:Label>                                
                                </td>
                            </tr>
                        </AlternatingItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
            <div class="message">
                <span class="iconInfo" style="margin: 7px;"></span><span class="spanInfo"></span>
            </div>
            <div class="pager">
                <div class="PageEntries">
                    <span style="float: left; margin-left: 5px;">Show&nbsp;</span><span style="float: left;">
                        <select id="ddlPagingInsurance" style="margin-top: 5px;" onchange="RowsChange('FilterInsurance');">
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
    <div id="divInsuranceDetailView" class="tableView" style="display: none;">
        <div style="height:32px" class="action-button-wrapper" >
            <%--<a href="javascript:void(0)" id="A4" onclick="insuranceBack_Click();" class="themeButton" style="padding-left: 24px;">
                <span class="span-action-sprite span-cancel-sprite"></span>Cancel </a>    
            <a href="javascript:void(0)" id="btnEditInsurance" onclick="insuranceEdit_Click();" class="themeButton" style="padding-left: 24px;">
                <span class="span-action-sprite span-edit-sprite"></span>Edit </a>--%>

                
        </div>
        <div class="clearboth">
        <table style="width: 100%;">
            <tr>
                <td style="width: 48%;">
                    <table style="width: 100%;">
                        <tr>
                            <td colspan="2">
                                <div class="header">
                                    General Information</div>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 30%;">
                                Name 
                            </td>
                            <td>
                                <label id="lblInsuranceName"></label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Tax Id
                            </td>
                            <td>
                                <label id="lblInsuranceTaxId"></label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Insurance Type
                            </td>
                            <td>
                               <label id="lblInsuranceTypeName"></label>                               
                            </td>
                        </tr>
                        <tr>
                            <td style="white-space: nowrap;">
                                Insurance Category
                            </td>
                            <td>
                                <label id="lblInsuranceCategoryName"></label>                                
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 4%;">
                </td>
                <td style="width: 48%;">
                    <table style="width: 100%;">
                        <tr>
                            <td colspan="2">
                                <div class="header">
                                    Address Information</div>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 30%;">
                                Address
                            </td>
                            <td>
                               <label id="lblInsuranceAddress"></label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                City
                            </td>
                            <td>
                               <label id="lblInsuranceCity"></label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                State
                            </td>
                            <td>
                               <label id="lblInsuranceStateName"></label>                               
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Zip
                            </td>
                            <td>
                              <label id="lblInsuranceZip"></label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table style="width: 100%;">
                        <tr>
                            <td colspan="2">
                                <div class="header">
                                    Contact Information</div>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 30%;">
                                Phone 1
                            </td>
                            <td>
                              <label id="lblInsurancePhone1"></label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Phone 2
                            </td>
                            <td>
                               <label id="lblInsurancePhone2"></label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Phone 3
                            </td>
                            <td>
                                <label id="lblInsurancePhone3"></label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Fax
                            </td>
                            <td>
                               <label id="lblInsuranceFax"></label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Email 
                            </td>
                            <td>
                               <label id="lblInsuranceEmail"></label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        </div>
    </div>
    <div id="divInsuranceAddEdit" class="tableEdit" style="display: none;">
        <div style="float: right;"  class="action-button-wrapper">
            <a href="javascript:void(0)" id="A3" onclick="cancelSaveInsurance();" class="themeButton" style="padding-left: 24px;">
                <span class="span-action-sprite span-cancel-sprite"></span>Cancel </a>
            <a href="javascript:void(0)" id="A2" onclick="saveInsurance();" class="themeButton" style="padding-left: 24px;">
                <span class="span-action-sprite span-save-sprite"></span>Save </a>
        </div>
        <div class="clearboth">
            <table id="tblInsurance" style="width: 100%;">
                <tr>
                    <td style="width: 48%;">
                        <table style="width: 100%;">
                            <tr>
                                <td colspan="2">
                                    <div class="header">
                                        General Information</div>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 30%;">
                                    Name: <span class="spnError">*</span>
                                </td>
                                <td>
                                    <input type="text" id="txtInsuranceName" maxlength="100"  class="required" onkeypress="return allowCharacters(event,' abcdefghijklmnopqrstuvwxyz\'\ ')" style="width: 86%;" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Tax Id:
                                </td>
                                <td>
                                    <input type="text" id="txtInsuranceTaxId" maxlength="25" style="width: 52%;" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Insurance Type:
                                </td>
                                <td>
                                   <asp:DropDownList ID="ddlInsuranceType" runat="server">
                                        <asp:ListItem Value="Government">Government</asp:ListItem>
                                        <asp:ListItem Value="Private">Private</asp:ListItem>
                                        </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="white-space: nowrap;">
                                    Insurance Category
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlInsuranceCategory" runat="server" Style="width: 56.6%;"></asp:DropDownList>
                                </td>
                            </tr>
                       
                        </table>
                    </td>
                    <td style="width: 4%;"></td>
                    <td style="width: 48%;">
                        <table style="width: 100%;">
                            <tr>
                                <td colspan="2">
                                    <div class="header">
                                        Address Information</div>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 30%;">
                                    Address:
                                </td>
                                <td>
                                    <%--<input type="text" id="txtInsuranceAddress" maxlength="100" style="width: 86%;" />--%>
                                    <textarea id="txtInsuranceAddress" maxlength="100" style="width: 86%;resize: none;" ></textarea>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Zip:
                                </td>
                                <td>
                                    <input type="text" id="txtInsuranceZip" onkeypress="return allowCharacters(event,'0123456789')" maxlength="7" onblur="getStateCity('txtInsuranceZip','txtInsuranceCity','ddlInsuranceStates');"  style="width: 50%;" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    City:
                                </td>
                                <td>
                                    <input type="text" id="txtInsuranceCity" style="width: 50%;" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    State:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlInsuranceStates" runat="server" Style="width: 54.6%;">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table style="width: 100%;">
                            <tr>
                                <td colspan="2">
                                    <div class="header">
                                        Contact Information</div>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 30%;">
                                    Phone 1
                                </td>
                                <td>
                                    <input type="text" id="txtInsurancePhone1" class="phone" style="width: 52%;" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Phone 2
                                </td>
                                <td>
                                    <input type="text" id="txtInsurancePhone2" class="phone" style="width: 52%;" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Phone 3
                                </td>
                                <td>
                                    <input type="text" id="txtInsurancePhone3" class="phone" style="width: 52%;" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Fax
                                </td>
                                <td>
                                    <input type="text" id="txtInsuranceFax" class="phone" style="width: 52%;" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Email
                                </td>
                                <td>
                                    <input type="text" id="txtInsuranceEmail" style="width: 52%;" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <asp:HiddenField runat="server" ID="hdnInsurancesTotalCount" />
    ###EndInsurance###
    </form>
</body>
</html>
