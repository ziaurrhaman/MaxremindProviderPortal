<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ICDSearch.aspx.cs" Inherits="ProviderPortal_Controls_ICDSearch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        ###StartICDSearch###
<%--    <div onclick="closeICDSearch(this)" class="spnclose">
        <img alt="" src="../../Images/close_icon.png" style="border-radius: 100px; float: right; margin-right: 6px;" width="25" height="25" />
    </div>--%>
        <div class="Grid" style="width: 99%;">
            <table>
                <thead>
                    <tr>
                        <th>Code
                        </th>
                        <th>
                            <div onclick="closeICDSearch(this)" class="spnclose">
                                <img alt="" src="../../Images/close_icon.png" style="border-radius: 100px; float: right; margin-right: 6px;" width="25" height="25" />
                            </div>
                            Description

                        </th>
                    </tr>
                </thead>
                <tbody id="IcdsSearchedList">
                    <asp:Repeater ID="rptICDCodeSearch" runat="server">
                        <ItemTemplate>
                            <tr onclick="SelectICD(this);" style="cursor: pointer; background-color: <%# Eval("icdBackColor") %>">
                                <td class="hdnCode">
                                    <%# Eval("Code")%>
                                </td>
                                <td class="hdnDescription">
                                    <%# Eval("ShorterDescription")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
        <script type="text/javascript">
            function closeICDSearch(elem) {
                debugger
                $(elem).parentsUntil().find("#divICDsSearched").css("display", "none")

            }
        </script>
        ###EndICDSearch###
    </form>
</body>
</html>
