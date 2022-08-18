<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PatientInsuranceDetail.aspx.cs" Inherits="ProviderPortal_Eligibility_CallBacks_PatientInsuranceDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    ###Start###
    <script src="../../Scripts/Eligibility.js"></script>
    <script type="text/javascript">
            $(".date").datepicker({
                changeMonth: true,
                changeYear: true,
                //minDate: new Date(1999, 10 - 1, 25)
            }).mask("99/99/9999");
    </script>
    <form id="form1" runat="server">
        <div style="margin-top: 10px; float: left; width: 100%; padding: 80px">
            <%--<asp:Repeater ID="RptInsurance" runat="server">           
                    <ItemTemplate>
                        <tr>
                            <td>
                                <input type="text" value="<%# Eval("Name") %>" style="width:100%;float:left;font-weight:bold;cursor:pointer;font-size:12px;box-sizing:border-box;" readonly onclick="CheckPatientEligibility_RowCount('Demographics',<%# Eval("InsuranceId") %>,'<%# Eval("PolicyNumber") %>');"/>
                                <input type="hidden" id="PolicyNumber" value="<%# Eval("PolicyNumber") %>" />                              
                            </td>             
                        </tr>
                    </ItemTemplate>
        </asp:Repeater>--%>
            <div>
                <div>
                    <span>Payer:
                    </span>
                    <asp:DropDownList runat="server" ID="ddlInsurance" Width="70%" style="float:none;margin-left:20px"></asp:DropDownList>

                </div>
                <div style="margin-top:15px">
                    <span>DOS:</span>

                    <asp:TextBox runat="server" ID="txtEligibilityDOS" Width="65.6%" style="float:none;margin-left:26px" CssClass="date"></asp:TextBox>

                    <asp:Literal runat="server" ID="ltrHiddenFields"></asp:Literal>

                </div>
            </div>

        </div>
        <asp:HiddenField ID="Policy_Number" runat="server" />
    </form>
    ###End###
</body>
</html>
