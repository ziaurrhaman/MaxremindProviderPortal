<%@ Page Title="" Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master" AutoEventWireup="true" CodeFile="InsurancesList.aspx.cs" Inherits="ProviderPortal_Insurances_InsurancesList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <div id="divInsurances">
            <h1 class="pagetitle">Payers</h1>
            <div id="Search" style="float:right;margin-bottom:10px;margin-right:15px;">
            <span style="float: left;">
              <input name="txtInsuranceSearch" type="text" id="txtInsuranceSearch" style="width: 205px;line-height: 20px;padding-left: 5px;" placeholder="Search Insurance Name"/>
            </span>
            <span class="fa fa-search" style="cursor: pointer; width: 30px;font-size: 16px; background:#439abf; color:#fff; height: 32px; text-align:center; float: right;padding-top: 7px;box-sizing: border-box;border-top-right-radius: 3px;border-bottom-right-radius: 3px;" onclick="FilterInsuranceList(0,true);"></span>
        </div>
        <div class="Grid " id="divInsuranceGrid">
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
                        <th style="width: 50px;display:none;">
                            Action
                        </th>
                    </tr>


<%--                             <tr>
                    <th>
                        <span class="iconSearch"></span>
                    </th>
                  
                    <th>
                        <input type="text" id="txtInsuranceName" onkeyup="FilterInsuranceList(0,true);" />
                    </th>
                     <th>
                        <select id="ddlType" style="width: 100%;" onchange="FilterInsuranceList(0,true);">
                            <option value=""></option>
                            <option value="Male">Government</option>
                            <option value="Female">Private</option>
                        </select>
                    </th>
                    <th>
                        <input type="text" id="txtcity" onkeyup="FilterInsuranceList(0,true);" />
                    </th>
                   
                    <th>
                      <input type="text" id="txtstate" onkeyup="FilterInsuranceList(0,true);" />

                    </th>
                       <th>
                      <input type="text" id="txtEmail" onkeyup="FilterInsuranceList(0,true);" />

                    </th>
                    <th>
                        <input type="text" id="txtPhone" onkeyup="FilterInsuranceList(0,true);" />
                    </th>
                    <th style="width: 23%;">
                        <input type="text" id="txtfax" onkeyup="FilterInsuranceList(0,true);" />
                    </th>
                <th></th>
                </tr>--%>

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
                                <td style="white-space: nowrap;" class="txtalign-cntr">
                                    <%# Eval("Phone1")%>
                                </td>
                               <td style="white-space: nowrap;" class="txtalign-cntr">
                                    <%# Eval("Fax")%>
                                </td>
                                <td class="action" style="white-space:nowrap; text-align: center;display:none;">
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
                               <td style="white-space: nowrap;" class="txtalign-cntr">
                                    <%# Eval("Phone1")%>
                                </td>
                               <td style="white-space: nowrap;" class="txtalign-cntr">
                                    <%# Eval("Fax")%>
                                </td>
                                <td class="action" style=" text-align: center;display:none;">
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
            <div class="table-footer">
            <div class="message">
                <span class="iconInfo" style="margin: 7px;"></span><span class="spanInfo"></span>
            </div>
            <div class="pager">
                <div class="PageEntries">
                    <span style="float: left; margin-left: 5px;">Show&nbsp;</span><span style="float: left;">
                        <select id="ddlPagingInsurance" style="margin-top: 5px;" onchange="RowsChange('FilterInsuranceList');">
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
                                    <input type="text" id="txtInsuranceNam" maxlength="100"  class="required" onkeypress="return allowCharacters(event,' abcdefghijklmnopqrstuvwxyz\'\ ')" style="width: 86%;" />
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




    <script type="text/javascript">

        $(document).ready(function () {
          debugger
            GeneratePaging($("[id$='hdnInsurancesTotalCount']").val(), $("#ddlPagingInsurance").val(), "divInsuranceGrid", "FilterInsuranceList");

            if ($("[id$='hdnInsurancesTotalCount']").val() > 0)
                $("#divInsuranceGrid .spanInfo").html("Showing " + $("#InsuranceList tr:first").children().first().html() + " to " + $("#InsuranceList tr:last").children().first().html() + " of " + $("[id$='hdnInsurancesTotalCount']").val() + " entries");

            $('#txtInsuranceSearch').keypress(function (e) {
                debugger;
                if (e.which == 13) {//Enter key pressed
                    FilterInsuranceList(0, true);
                }
            });
        });


       

        function FilterInsuranceList(pageNumber, paging) {

            debugger;
            var InsuranceName = $("#txtInsuranceSearch").val();
            $.post(_ResolveUrl + "../../ProviderPortal/Insurances/CallBacks/InsurancesListHandler.aspx", { Rows: $("#ddlPagingInsurance").val(), PageNumber: pageNumber, SortBy: "Name", InsuranceName: InsuranceName }, function (data) {
                var returnHtml = data;
                var start = data.indexOf("###Start###") + 11;
                var end = data.indexOf("###End###");
                $("#InsuranceList").html(returnHtml.substring(start, end));
                debugger;

                if (paging == true) {
                    GeneratePaging($("[id$='hdnInsurancesTotalCount']").val(), $("#ddlPagingInsurance").val(), "divInsuranceGrid", "FilterInsuranceList");
                }
              
                
                if ($("[id$='hdnInsurancesTotalCount']").val() > 0)
                    $("#divInsuranceGrid .spanInfo").html("Showing " + $("#InsuranceList tr:first").children().first().html() + " to " + $("#InsuranceList tr:last").children().first().html() + " of " + $("[id$='hdnInsurancesTotalCount']").val() + " entries");
            });
        }



    </script>

</asp:Content>

