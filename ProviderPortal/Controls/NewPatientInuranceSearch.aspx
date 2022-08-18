<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewPatientInuranceSearch.aspx.cs" Inherits="ProviderPortal_Controls_NewPatientInuranceSearch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    ###StartInsuranceSearch###
        <%--<input id="Button1" type="button" onclick="ShowNewInsuranceDialog()" value="Add New Insurance" />--%>
        
        <div id="InsuranceContainer">
            <div class="Grid">
                <table>
                    <thead>
                        <tr>
                            <th style="width: 2%;">
                            </th>
                            <th>
                                Name
                            </th>
                            <th style="width: 10%;"> 
                                City
                            </th>
                            <th style="width: 12%;">
                                State
                            </th>
                            <th style="width: 10%;">
                                Zip
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
                        </tr>
                        <tr>
                            <th>
                                <span class="iconSearch"></span>
                            </th>
                            <th>
                                <input id="txtInsuranceName" runat="server" type="text" onkeyup="FilterInsurance(0,true)" />
                            </th>
                            <th>
                                <input id="txtInsuranceCity" type="text" onkeyup="FilterInsurance(0,true)" />
                            </th>
                            <th>
                                <asp:DropDownList ID="ddlInsuranceState" runat="server" onchange="FilterInsurance(0,true);">
                                </asp:DropDownList>
                            </th>
                            <th>
                                <input id="txtInsuranceZip" type="text" onkeyup="FilterInsurance(0,true)" />
                            </th>
                            <th>
                            </th>
                            <th>
                            </th>
                            <th>
                            </th>
                        </tr>
                    </thead>
                    <tbody id="ShowInsuranceResult">
                        <asp:Repeater ID="rptInsurance" runat="server">
                            <ItemTemplate>
                                <tr style="cursor: pointer" onclick="GetInsuranceNameNewPatient(this)">
                                    <td>
                                        <i>
                                            <%# Eval("RowNumber") %></i>
                                    </td>
                                    <td id='<%# Eval("ID") %>' class="insuranceName">
                                        <%# Eval("Name") %>
                                    </td>
                                    <td>
                                        <%# Eval("City") %>
                                    </td>
                                    <td>
                                        <%# Eval("State") %>
                                    </td>
                                    <td>
                                        <%# Eval("Zip") %>
                                    </td>
                                    <td>
                                        <%# Eval("Email") %>
                                    </td>
                                    <td>
                                        <%# Eval("Phone") %>
                                    </td>
                                    <td>
                                        <%# Eval("Fax") %>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
                <div class="message">
                    <span class="iconInfo" style="margin: 7px;"></span><span class="spanInfo">
                </div>
                <div class="pager">
                    <div class="PageEntries">
                        <span style="float: left;">Show&nbsp;</span><span style="float: left;">
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
        
        <asp:HiddenField runat="server" ID="hdnTotalRowsINS" />
        
        <script type="text/javascript">
            function AddNewInsurance() {

                if (!ValidateForm("InsuranceInformation")) {
                    showErrorMessage("");
                    return;
                }

                var Insurance = new Object();
                Insurance.Name = $("[id$='txtNewInsuranceName']").val();
                Insurance.TaxId = $("[id$='txtInsuranceTaxId']").val();
                Insurance.InsuranceType = $("[id$='ddlInsuranceType']").val();
                Insurance.HeadOfficeAddress = $("[id$='txtInsuranceAddress']").val();
                Insurance.Zip = $("[id$='txtNewInsuranceZip']").val();
                Insurance.City = $("[id$='txtNewInsuranceCity']").val();
                Insurance.State = $("[id$='ddlNewInsuranceState']").val();
                Insurance.ContactPerson = $("[id$='txtInsuranceContactPerson']").val();
                Insurance.Email = $("[id$='txtInsuranceEmail']").val();
                Insurance.Fax = $("[id$='txtInsuranceFax']").val();
                Insurance.Phone1 = $("[id$='txtInsurancePhone1']").val();
                Insurance.Phone2 = $("[id$='txtInsurancePhone2']").val();
                Insurance.Phone3 = $("[id$='txtInsurancePhone3']").val();

                var Address = new Array();

                $("#InsuranceAddress .NewRow").each(function () {
                    var NewAddress = new Object();
                    NewAddress.Department = $(this).children().eq(0).find('input').val();
                    NewAddress.Address = $(this).children().eq(1).find('input').val();
                    NewAddress.City = $(this).children().eq(2).find('input').val();
                    NewAddress.State = $(this).children().eq(3).find("select").val()
                    NewAddress.Zip = $(this).children().eq(4).find('input').val();
                    NewAddress.ContactPerson = $(this).children().eq(5).find('input').val();
                    NewAddress.Email = $(this).children().eq(6).find('input').val();
                    NewAddress.Fax = $(this).children().eq(7).find('input').val();
                    NewAddress.Phone1 = $(this).children().eq(8).find('input').val();
                    NewAddress.Phone2 = $(this).children().eq(9).find('input').val();
                    NewAddress.Phone3 = $(this).children().eq(10).find('input').val();
                    Address.push(NewAddress);
                });

                $.post(_ControlPath + "/CallBacks/AddEditNewPatientInsuranceHandler.aspx", { Insurance: JSON.stringify(Insurance), Address: JSON.stringify(Address) }, function (data) {
                    setInsuranceData(true, data);

                    $("#NewInsurance").dialog('close');
                    showSuccessMessage(_msg_Created);
                });
            }


            function AddMoreAddress() {
                $("#MoreAddress").show();
                $("#NewRow").html($("#clone").html());
                $('#InsuranceAddress tr:last').before("<tr class='NewRow'>" + $("#NewRow").html() + "</tr>");
                $(".phone").mask("(999) 999-9999");
                $(".DeleteAddress").attr("src", _RooTPath + "Images/btnRemove.png")
                $(".NewAddress").attr("src", _RooTPath + "Images/btnAdd.png")
            } 

            function NewAddress() {
                $("#NewRow").html($("#clone").html());
                $('#InsuranceAddress tr:last').before("<tr class='NewRow'>" + $("#NewRow").html() + "</tr>");
            }

            function RemoveAddress(elem) {
                $(elem).closest("tr").remove();
            }

            function FilterInsurance(pageNumber, paging) {
                debugger;
                var Name = $("#txtInsuranceName").val();
                var City = $("#txtInsuranceCity").val();
                var State = $("#ddlInsuranceState").val();
                var Zip = $("#txtInsuranceZip").val();
                $.post("../../ProviderPortal/Controls/NewPatientInsuranceSearchHandler.aspx", { Name: Name, City: City, State: State, Zip: Zip, Rows: $("#ddlPagingInsurance").val(), pageNumber: pageNumber, SortBy: "" }, function (data) {
                    var returnHtml = data;
                    setInsuranceData(paging, data);
                });
            }

            function setInsuranceData(paging, data) {
                var start = data.indexOf("###SearchInsuranceResult###") + 27;
                var end = data.indexOf("###EndInsuranceResult###");
                $("#ShowInsuranceResult").html(data.substring(start, end));
                var startRowsINS = data.indexOf("###StartInsuranceRowsCount###") + 29;
                var endRowsINS = data.indexOf("###EndInsuranceRowsCount###");
                $("[id$='hdnTotalRowsINS']").val($.trim(data.substring(startRowsINS, endRowsINS)));

                if (paging == true) {
                    GeneratePaging($("[id$='hdnTotalRowsINS']").val(), $("#ddlPagingInsurance").val(), "InsuranceSearchBox", "FilterInsurance");
                }

                if ($("[id$='hdnTotalRowsINS']").val() > 0) {
                    $("#InsuranceSearchBox .spanInfo").html("Showing " + $("#ShowInsuranceResult tr:first").children().first().html() + " to " + $("#ShowInsuranceResult tr:last").children().first().html() + " of " + $("[id$='hdnTotalRowsINS']").val() + " entries");
                }
            }

        </script>
        ###EndInsuranceSearch###
    </div>
    </form>
</body>
</html>
