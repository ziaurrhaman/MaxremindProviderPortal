<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DynamicLocationProviderDDL.aspx.cs" Inherits="ProviderPortal_ReportsNew_CallBacks_DynamicLocationProviderDDL" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###Providers###
            <ul>
                <li style="float: left; width: 100%;">
                    <label style="float: left;">
                        <input type="checkbox" checked="checked" class="chk-multi-checkboxes-all AddDynamicFunctionsAllProviders" />
                        <span>All Providers</span>
                        <input type="hidden" value="0" />
                    </label>
                </li>
                <asp:Repeater runat="server" ID="DynamicProviders">
                    <ItemTemplate>
                        <li style="float: left; width: 100%;">
                            <label style="float: left;">
                                <input type="checkbox" checked="checked" class="AddDynamicFunctionsProviders chk-multi-checkboxes" value='<%#Eval("NPI") %>' />
                                <span class="PracticeStaff"><%#Eval("PracticeStaff") %></span>
                                <input type="hidden" value='<%#Eval("NPI") %>' class="StaffNPI" />
                                <%--<input type="hidden" value='<%#Eval("PracticeStaffId") %>' />
                                <input type="hidden" value='<%#Eval("name") %>' class="locationname" />
                                <input type="hidden" value='<%#Eval("PracticeLocationsId") %>' class="PracticeLocationsId" />--%>


                            </label>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>

            ###ProvidersEND###
                ###Locations###
            <ul>
                <li style="float: left; width: 100%;">
                    <label style="float: left;">
                        <input type="checkbox" checked="checked" class="chk-multi-checkboxes-all AddDynamicFunctionsAllLocations" />
                        <span>All</span>
                        <input type="hidden" value="0" />
                    </label>
                </li>
                <asp:Repeater runat="server" ID="DynamicLocations">
                    <ItemTemplate>
                        <li style="float: left; width: 100%;">
                            <label style="float: left;">
                                <input type="checkbox" checked="checked" onclick="ReportAlert(this)" class="AddDynamicFunctionsLocations chk-multi-checkboxes" value='<%#Eval("PracticeLocationsId") %>' />
                                <span><%#Eval("Name") %></span>
                                <input type="hidden" value='<%#Eval("PracticeLocationsId") %>' class="PracticeLocationsId" />
                            </label>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>

            ###LocationsEND###
        ###StartFilterLocation###
            <ul>
                <li style="float: left; width: 100%;">
                    <label style="float: left;">
                        <input type="checkbox" class="chk-multi-checkboxes-all" />
                        <span>All</span>
                        <input type="hidden" value="0" />
                    </label>
                </li>

                <asp:Repeater runat="server" ID="rptLocation">
                    <ItemTemplate>
                        <li style="float: left; width: 100%;">
                            <label style="float: left;">
                                <input type="checkbox" value='<%#Eval("PracticeLocationsId") %>' class="chk-multi-checkboxes" />
                                <span><%#Eval("Name") %></span>
                                <input type="hidden" value='<%#Eval("PracticeLocationsId") %>' class="PracticeLocationsId" />
                            </label>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>


            ###EndFilterLocation###

        ###StartFilterProvider###
            
            <ul>
                <li style="float: left; width: 100%;">
                    <label style="float: left;">
                        <input type="checkbox" class="chk-multi-checkboxes-all" />
                        <span>All Providers</span>
                        <input type="hidden" value="0" />
                    </label>
                </li>
                <asp:Repeater runat="server" ID="rptProviders">
                    <ItemTemplate>
                        <li style="float: left; width: 100%;">
                            <label style="float: left;">
                                <input type="checkbox" value='<%#Eval("StaffNPI") %>' class="StaffNPI chk-multi-checkboxes" />
                                <span><%#Eval("StaffName") %></span>
                                <input type="hidden" value='<%#Eval("PracticeStaffId") %>' class="PracticeStaffId" />

                            </label>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>

            </ul>



            ###EndFilterProvider###


        </div>
    </form>
</body>
</html>
