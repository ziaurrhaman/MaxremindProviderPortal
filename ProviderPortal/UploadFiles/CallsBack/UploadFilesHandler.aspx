<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UploadFilesHandler.aspx.cs" Inherits="ProviderPortal_UploadFiles_UploadFilesHandler" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
      <div>
    ###Start###
    <asp:Repeater ID="rptUploadedFiles" runat="server">
        <ItemTemplate>
           <tr>
      <td>
                      <%# Eval("RowNumber") %>
                    </td>
                <td>
           <%# Eval("CreatedDate","{0:d}")%>
                                               
            </td>
            <td>
          <%# Eval("FileName")%>
            </td>
          <td>
             <%# Eval("FileStatus")%>
               </td>
           <td>
           <%# Eval("FileType")%>
             </td>
              <td>
                   <%# Eval("Patients")%>
                    </td>
                <td>
                      <%# Eval("Claims")%>
                     </td>
                           
                        </tr>
        </ItemTemplate>
    </asp:Repeater>
    ###End###
    ###StartPatientRowsCount###
    <asp:Literal runat="server" ID="ltrlUploadFilesRowsCount"></asp:Literal>
    ###EndPatientRowsCount###
    </div>
    </form>
</body>
</html>
