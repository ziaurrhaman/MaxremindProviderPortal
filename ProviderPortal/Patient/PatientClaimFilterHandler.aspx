<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PatientClaimFilterHandler.aspx.cs" Inherits="ProviderPortal_Patient_PatientClaimFilterHandler" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    ###Start###
    <asp:Repeater ID="rptclaims" runat="server">
        <ItemTemplate>
            <tr>
                            <td>
                             <%#Eval("RowNumber") %> 
                            </td>
                            <td>
                                <%# Eval("ClaimId") %>
                            </td>
                            <td>
                                <%# Eval("DOS","{0:d}") %>
                            </td>
                            <td>
                                <%# Eval("ClaimTotal","{0:c}") %>
                            </td>
                            <td>
                                <%# Eval("AmountPaid","{0:c}") %>
                            </td>
                            <td>
                                <%# Eval("Adjustment","{0:c}") %>

                            </td>

                             <td>
                                <%# Eval("AmountDue","{0:c}") %>
                            </td>
                            <td>
                                <%# Eval("Name") %>
                            </td>
                            <td>
                                <%# Eval("SubmissionStatus")%>
                            </td>

                            <td class="tdPTLReasons">
                                <span><%# Eval("PTLReasons") %></span>
                                <input type="hidden" class="hdnPTLNotes" value='<%#Eval("PTLNotes") %>' />
                            </td>
                           
                            <td style="text-align: center;">
                                    <asp:CheckBox runat="server" ID="chkPTL" Enabled="false" style="display:none;"/>
                                     <a title="View" onclick="ClaimOpenForView(<%# Eval("ClaimId")%>,<%# Eval("PatientId")%>,'<%# Eval("SubmissionStatus")%>')">
                                      <img src="../../Images/view1.png" />
                                    </a>
                            </td>
                        </tr>
        </ItemTemplate>
    </asp:Repeater>
         <%--Added By Syed Sajid Ali Date:8/30/2011--%>
        <script type="text/javascript">
            //var PTLType = "ClaimsList"
            $(document).ready(function () {
                SetPTLReasons("ClaimsList");
            });
            function SetPTLReasons(PTLType) {
                debugger;
                var PTLReason, strPTLReasons = "", arrPTLReasons;

                $("#" + PTLType + " .tdPTLReasons").each(function () {
                    debugger;
                    strPTLReasons = $.trim($(this).find("span").html());

                    if (strPTLReasons != "") {
                        arrPTLReasons = strPTLReasons.split(',');

                        strPTLReasons = "";

                        for (var i = 0; i < arrPTLReasons.length; i++) {
                            PTLReason = $.trim($("[id$='chk" + PTLType + "PTLReasonsId" + arrPTLReasons[i] + "']").parent().find(".spnReason").html());

                            strPTLReasons += PTLReason + ", ";
                        }

                        if (strPTLReasons.length > 1) {
                            strPTLReasons = strPTLReasons.slice(0, -2);
                        }
                    }
                    else {
                        strPTLReasons = $.trim($(this).find(".hdnPTLNotes").val());
                    }

                    $(this).html(strPTLReasons);
                });
            }
        </script>
       <%--Added By Syed Sajid Ali Date:8/30/2011--%>
    ###End###
    ###StartPatientRowsCount###
    <asp:Literal runat="server" ID="ltrlPatientRowsCount"></asp:Literal>
    ###EndPatientRowsCount###
    </div>
    </form>
</body>
</html>
