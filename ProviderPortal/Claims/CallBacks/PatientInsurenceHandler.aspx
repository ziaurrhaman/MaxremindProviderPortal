<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PatientInsurenceHandler.aspx.cs" Inherits="EMR_Claims_CallBacks_PatientInsurenceHandler" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    ###StartPrimaryInsurances###
    <asp:DropDownList ID="ddlPrimaryInsurance" runat="server" CssClass="required"></asp:DropDownList>
    ###EndPrimaryInsurances###
    ###StartSecondaryInsurances###
    <asp:DropDownList ID="ddlSecondaryInsurance" runat="server"></asp:DropDownList>
    ###EndSecondaryInsurances###
    ###StartOtherInsurances###
    <asp:DropDownList ID="ddlOtherInsurance" runat="server"></asp:DropDownList>
    ###EndOtherInsurances###
    ###StartPatientAppintmentsDate###
    <%--<asp:DropDownList ID="ddlDos" runat="server" class="required"></asp:DropDownList>--%>
    ###EndPatientAppintmentsDate###
    </div>
    </form>
</body>
</html>
