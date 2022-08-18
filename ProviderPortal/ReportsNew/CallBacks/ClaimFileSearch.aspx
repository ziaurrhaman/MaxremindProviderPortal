<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClaimFileSearch.aspx.cs" Inherits="ProviderPortal_ReportsNew_CallBacks_ClaimFileSearch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

 ###StartSearchFile###
      
       
        <div style="float:right; margin-right:20px;" onclick="CloseFileSearchDiv()">
    <asp:Image ID="closediv" style="height:15px;width:15px;  position:absolute" runat="server"  ImageUrl="~/Images/close_icon.png" />
        </div>
    <div class="Grid" style="width: 99%;">
    
            <table id="searchTable">
            <thead>
                <tr >
                    <th style="text-align:center">
                        Id
                        </th>
                    <th style="text-align:center">
                        Name              
                   </th>
                    <th style="text-align:center">
                        Date
                    </th>
                </tr>
            </thead>
            <tbody id="IcdsSearchedList">
                <asp:Repeater ID="rptFileSearch" runat="server">
                    <ItemTemplate>
                            <tr onclick="selectedFile(this)" style="cursor: pointer;">
                         
                            <td class="hdnid">
                                <%# Eval("UploadFilesId")%>
                                
                            </td>
                                 <td class="hdnname"  >
                                <%# Eval("FileName")%>
                                
                            </td>
                              
                                 <td style="width:10%">
                                <%# Eval("uploaddate")%>

                              </td>
                            <td style="display:none">
                               <%-- <input type="hidden" id="hdnfilelocationId" value="<%# Eval("FileLocation")%>" />--%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
    ###EndSearchFile####
    
    </form>

</body>
</html>
