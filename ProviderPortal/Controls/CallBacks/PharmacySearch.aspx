<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PharmacySearch.aspx.cs" Inherits="ProviderPortal_Controls_CallBacks_PharmacySearch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    ###StartPharmacySearch###
    <div>
        <asp:HiddenField runat="server" ID="hdnPharmacyTotalRows" />
        <div id="PharmacyContainer" style="float: left; margin: 1%; width: 98%;">
            <div class="Grid">
                <table>
                    <thead>
                        <tr>
                            <th>
                            </th>
                            <th>
                                Pharmacy Name
                            </th>
                            <th>
                                Address
                            </th>
                            <th>
                                City
                            </th>
                            <th>
                                State
                            </th>
                            <th>
                                Zip
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
                                <input id="txtStoreName" type="text" onkeyup="FilterPharmacy(0, true)" />
                            </th>
                            <th>
                                <input id="txtPharmacAddress" type="text" onkeyup="FilterPharmacy(0, true)" />
                            </th>
                            <th>
                                <input id="txtPharmacyCity" type="text" onkeyup="FilterPharmacy(0, true)" />
                            </th>
                            <th>
                                <asp:DropDownList ID="ddlPharmacyStates" runat="server" AppendDataBoundItems="true" onchange="FilterPharmacy(0, true)">
                                    <asp:ListItem Selected="True" Text="" Value=""></asp:ListItem>
                                </asp:DropDownList>
                            </th>
                            <th>
                                <input id="txtPharmacyZip" type="text" onkeyup="FilterPharmacy(0, true)" onkeypress="return allowCharacters(event,'1234567890')" />
                            </th>
                            <th>
                                <input id="txtPharmacyPhone" type="text" onkeyup="FilterPharmacy(0, true)" class="phone" />
                            </th>
                            <th>
                                <input id="txtPharmacyFax" type="text" onkeyup="FilterPharmacy(0, true)" class="phone" />
                            </th>
                            <th style="display:none">
                            </th>
                        </tr>
                    </thead>
                    <tbody id="PharmacyList">
                        <asp:Repeater ID="rptPharmacy" runat="server">
                            <ItemTemplate>
                                <tr id='<%# Eval("NCPDP") %>' style="cursor: pointer" onclick="SelectPharmacy(this)">
                                    <td>
                                        <i><%# Eval("RowNumber") %></i>
                                    </td>
                                    <td id="Name">
                                        <%# Eval("StoreName") %>
                                    </td>
                                    <td id="Address">
                                        <%# Eval("Address") %>
                                    </td>
                                    <td id="City">
                                        <%# Eval("City") %>
                                    </td>
                                    <td id="State">
                                        <%# Eval("StateName") %>
                                    </td>
                                    <td id="Zip">
                                        <%# Eval("Zip") %>
                                    </td>
                                    <td id="Phone">
                                        <%# Eval("Phone") %>
                                    </td>
                                    <td id="Fax">
                                        <%# Eval("Fax") %>
                                    </td>
                                    <td style="display:none">
                                        <input class="Email" value='<%# Eval("Email") %>' type="hidden" />
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <AlternatingItemTemplate>
                                <tr id='<%# Eval("NCPDP") %>' style="cursor: pointer" class="alternatingRow" onclick="SelectPharmacy(this)">
                                    <td>
                                        <i>
                                            <%# Eval("RowNumber") %></i>
                                    </td>
                                    <td id="Name">
                                        <%# Eval("StoreName") %>
                                    </td>
                                    <td id="Address">
                                        <%# Eval("Address") %>
                                    </td>
                                    <td id="City">
                                        <%# Eval("City") %>
                                    </td>
                                    <td id="State">
                                        <%# Eval("StateName") %>
                                    </td>
                                    <td id="Zip">
                                        <%# Eval("Zip") %>
                                    </td>
                                    <td id="Phone">
                                        <%# Eval("Phone") %>
                                    </td>
                                    <td id="Fax">
                                        <%# Eval("Fax") %>
                                    </td>
                                    <td style="display:none">
                                        <input class="Email" value='<%# Eval("Email") %>' type="hidden" />
                                    </td>
                                </tr>
                            </AlternatingItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
                <div class="message">
                    <span class="iconInfo" style="margin: 7px;"></span><span class="spanInfo">
                </div>
                <div class="pager">
                    <div class="PageEntries">
                        <span style="float: left; margin-left: 5px;">Show&nbsp;</span><span style="float: left;">
                            <select id="ddlPagingPharmacy" style="margin-top: 5px;" onchange="RowsChange('FilterPharmacy');">
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
    <script type="text/javascript">
        $(document).ready(function () {
            $(".phone").mask("(999) 999-9999");
            $(".txtSSN").mask("999-99-9999");

            $(".date").datepicker({
                changeMonth: true,
                changeYear: true,
                maxDate: new Date()
            }).mask("99/99/9999");

           // $(".time").timeEntry();
        });
        </script>

    <script type="text/javascript">
        $(document).ready(function () {
            GeneratePaging($("[id$='hdnPharmacyTotalRows']").val(), $("#ddlPagingPharmacy").val(), "PharmacyContainer", "FilterPharmacy");
            if ($("[id$='hdnPharmacyTotalRows']").val() > 0) {
                $("#PharmacyContainer .spanInfo").html("Showing " + $("#PharmacyList tr:first").children().first().html() + " to " + $("#PharmacyList tr:last").children().first().html() + " of " + $("[id$='hdnPharmacyTotalRows']").val() + " entries");
            }
        });

        function FilterPharmacy(pageNumber, paging) {
            var storeName = $("#txtStoreName").val();
            var address = $("#txtPharmacAddress").val();
            var city = $("#txtPharmacyCity").val();
            var state = $("[id$='ddlPharmacyStates']").val();
            var zip = $("#txtPharmacyZip").val();
            var phone = $("#txtPharmacyPhone").val();
            var fax = $("#txtPharmacyFax").val();

            $.post(_ControlPath + "/CallBacks/PharmacySearchHandler.aspx", { storeName: storeName, address: address, city: city, state: state, zip: zip, phone: phone, fax: fax, Rows: $("#ddlPagingPharmacy").val(), pageNumber: pageNumber, SortBy: "" }, function (data) {
                var returnHtml = data;
                var start = data.indexOf("###StartPharmacyFilter###") + 25;
                var end = data.indexOf("###EndPharmacyFilter###");
                $("#PharmacyList").html(returnHtml.substring(start, end));

                var startRowsCount = data.indexOf("###StartPharmacyRowsCount###") + 28;
                var endRowsCount = data.indexOf("###EndPharmacyRowsCount###");
                $("[id$='hdnPharmacyTotalRows']").val($.trim(returnHtml.substring(startRowsCount, endRowsCount)));

                if (paging == true) {
                    GeneratePaging($("[id$='hdnPharmacyTotalRows']").val(), $("#ddlPagingPharmacy").val(), "PharmacyContainer", "FilterPharmacy");
                }

                if ($("[id$='hdnPharmacyTotalRows']").val() > 0) {
                    $("#PharmacyContainer .spanInfo").html("Showing " + $("#PharmacyList tr:first").children().first().html() + " to " + $("#PharmacyList tr:last").children().first().html() + " of " + $("[id$='hdnPharmacyTotalRows']").val() + " entries");
                }
            });
        }

    </script>
    ###EndPharmacySearch###
    </form>
</body>
</html>