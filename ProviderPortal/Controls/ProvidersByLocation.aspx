<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProvidersByLocation.aspx.cs" Inherits="EMR_Controls_ProvidersByLocation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    ###StartProvidersList###
    <asp:Repeater runat="server" ID="rptServiceProviders">
        <ItemTemplate>
            <div class="divMultiCheckInsideDropdown">
                <label>
                    <input type="checkbox" class="cbServiceProviders" checked="checked" />
                    <span class="spnServiceProviders"><%#Eval("Name")%></span>
                    <input type="hidden" class="hdnPracticeStaffId" value='<%#Eval("PracticeStaffId") %>' />
                </label>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    ###EndProvidersList###
    ###StartProviderDropdown###
    <asp:Repeater runat="server" ID="rptServiceProvidersDropDown">
        <ItemTemplate>
            <option selected="selected" value='<%#Eval("PracticeStaffId") %>'><%#Eval("Name")%></option>
        </ItemTemplate>
    </asp:Repeater>
    ###EndProviderDropdown###
    
    ###StartPracticeRooms###
    <asp:DropDownList runat="server" ID="ddlPracticeRooms" CssClass="required"></asp:DropDownList>
    ###EndPracticeRooms###
    </div>
    </form>
</body>
</html>
