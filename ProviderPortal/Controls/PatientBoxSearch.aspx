<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PatientBoxSearch.aspx.cs"
    Inherits="ProviderPortal_Controls_PatientBoxSearch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        ###Start###
        <asp:Repeater ID="rptPatients" runat="server">
            <ItemTemplate>
                <tr onclick="ClickPatientBoxSearchRow(this, event);">
                    <td>
                        <span class="spnLastName"><%# Eval("LastName")%></span>
                        
                        <input type="hidden" class="hdnPatientId" value='<%# Eval("PatientId")%>' />

                        <input type="hidden" class="hdnLastName" value='<%# Eval("LastName")%>' />
                        <input type="hidden" class="hdnFirstName" value='<%# Eval("FirstName")%>' />
                        <input type="hidden" class="hdnPatientName" value='<%# Eval("PatientName")%>' />
                        <input type="hidden" class="hdnDateOfBirth" value='<%# Eval("DateOfBirth")%>' />
                        <input type="hidden" class="hdnGender" value='<%# Eval("Gender")%>' />
                        <input type="hidden" class="hdnMaritalStatus" value='<%# Eval("MaritalStatus")%>' />
                        <input type="hidden" class="hdnCell" value='<%# Eval("Cell")%>' />
                        <input type="hidden" class="hdnHomePhone" value='<%# Eval("HomePhone")%>' />
                        <input type="hidden" class="hdnWorkPhone" value='<%# Eval("WorkPhone")%>' />
                        <input type="hidden" class="hdnCity" value='<%# Eval("City")%>' />
                        <input type="hidden" class="hdnState" value='<%# Eval("State")%>' />
                        <input type="hidden" class="hdnZip" value='<%# Eval("Zip")%>' />
                        <input type="hidden" class="hdnAddress" value='<%# Eval("Address")%>' />
                        <input type="hidden" class="hdnImagePath" value='<%# Eval("ImagePath")%>' />

                        <input type="hidden" class="hdnPatientDeathDate" value='<%# Eval("DeathDate")%>' />
                    </td>
                    <td>
                        <span class="spnFirstName"><%# Eval("FirstName")%></span>
                    </td>
                    <td>
                        <span class="spnPhone"><%# Eval("Cell")%></span>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        ###End###
    </div>
    </form>
</body>
</html>
