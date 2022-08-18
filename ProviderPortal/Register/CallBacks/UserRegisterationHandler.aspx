<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserRegisterationHandler.aspx.cs" Inherits="ProviderPortal_Register_CallBacks_UserRegisterationHandler" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        ##validatestart##
        <asp:Literal runat="server" ID="AlredyExistUsername" />
        ##validateend##
        ###startValidNPIChk###
        <asp:Literal runat="server" ID="lNPI" />
        ###endValidNPIChk###
        ###StartEmailSendVerification###
        <asp:Literal runat="server" ID="EmailVerification" />
        ###EndEmailSendVerification###
        ##SatrtPasswordVerification##
        <asp:Literal runat="server" ID="PasswordUpdateStatus" />
        ##EndPasswordVerification##

        ##StartAddProfile##
        <asp:Literal runat="server" Text="True" ID="AddProfile" />
        ##EndAddProfile##

    </div>
    </form>
</body>
</html>
