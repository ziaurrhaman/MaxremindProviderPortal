<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddNewEOBHandler.aspx.cs" Inherits="HomeHealth_EpisodeClaims_CallBacks_AddNewEOBHandler" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        ###StartResult###
        <asp:Literal ID="ltrResult" runat="server"></asp:Literal>
        ###EndResult###
        ###StartIfCheckExists###
             <asp:Literal runat="server" ID="ltrIfCheckExists" Text="false"></asp:Literal>
          ###EndIfCheckExists###


    </div>
    </form>
</body>
</html>
