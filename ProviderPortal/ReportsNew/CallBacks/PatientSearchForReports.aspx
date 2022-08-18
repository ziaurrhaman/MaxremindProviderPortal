<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PatientSearchForReports.aspx.cs" Inherits="ProviderPortal_Controls_PatientSearchForReports" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        ###Start###
    <div class="Grid" style="/* float: left; */
    max-height: 163px; overflow-y: auto; width: 24%; /* margin-top: 3px; */
    background: white; position: relative; z-index: 999; border: 1px solid #ccc; margin-left: -5px; padding: 0px 5px;">
        <table id="PatientSerachtdBody">
            <thead>
                <tr>
                    <th>PatientID
                    </th>
                    <th>Patient    
                        <div onclick="closePatientSearched(this)" class="spnclose">
                            <img alt="" src="../../Images/close_icon.png" style="border-radius: 100px; float: left; margin-top: -21px; margin-left: 230px; position: absolute;" />
                        </div>
                    </th>
                </tr>
            </thead>
            <tbody id="">
                <asp:Repeater ID="rptPatientSearch" runat="server">
                    <ItemTemplate>
                        <tr style="cursor: pointer;" onclick="SelectPatientId(this)" class="">
                            <td class="hdnCode">
                                <%# Eval("PatientId")%>
                            </td>
                            <td class="hdnCode">
                                <%# Eval("Patient")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
        ###End###
                ###StartCustomizePatient###
    <div class="Grid" style="/* float: left; */
    max-height: 163px; overflow-y: auto; width: 24%; /* margin-top: 3px; */
    background: white; position: relative; z-index: 999; border: 1px solid #ccc; margin-left: -5px; padding: 0px 5px; position: absolute;">
        <table id="PatientSerachtdBodyCustomize">
            <thead>
                <tr>
                    <th>PatientID
                    </th>
                    <th>Patient                       
                        <div onclick="closePatientSearchedCustomize(this)" class="spnclose">
                            <img alt="" src="../../Images/close_icon.png" style="border-radius: 100px; float: left; margin-top: -21px; margin-left: 230px; position: absolute;" />
                        </div>
                    </th>
                </tr>
            </thead>
            <tbody id="">
                <asp:Repeater ID="CustomizePatient" runat="server">
                    <ItemTemplate>
                        <tr style="cursor: pointer;" onclick="SelectCustomizePatientId(this)" class="">
                            <td class="hdnCode">
                                <%# Eval("PatientId")%>
                            </td>
                            <td class="hdnCode">
                                <%# Eval("Patient")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
        ###EndCustomizePatient###
    </form>
</body>
</html>
