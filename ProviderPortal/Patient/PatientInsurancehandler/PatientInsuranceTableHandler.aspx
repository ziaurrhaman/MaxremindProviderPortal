<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PatientInsuranceTableHandler.aspx.cs" Inherits="ProviderPortal_Patient_PatientInsurancehandler_PatientInsuranceTableHandler" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>


                  

             <table class="data-table" >
                        <thead>
                            <tr>
                               
                                <th>
                                    Payer Type
                                </th>
                                <th>
                                    Payer Name
                                </th>
                                <th>
                                    Policy No
                                </th>
                                <th>
                                    Group No
                                </th>
                                <th>
                                    Group Name
                                </th>
                                <th>
                                    Copay
                                </th>
                                <th>
                                    Co-Insurance
                                </th>
                                <th>
                                    Relationship
                                </th>
                                <th>
                                    Subscriber Name
                                </th>
                                <th>
                                    Effective Date
                                </th>
                                <th>
                                    Termination Date
                                </th>
                                <th>
                                    Edit
                                </th>
                            </tr>
                        </thead>
                         <tbody>
                     
                <asp:Repeater ID="RptInsurance" runat="server">
                    <ItemTemplate>
                        <tr style="background-color:white">
                             <td style="display:none">
                              
                               <%# Eval("PatientInsuranceId") %>
                            </td>
                            <td>
                              
                               <%# Eval("InsuranceType") %>
                            </td>
                            <td>
                                <%# Eval("Name") %>
                            </td>
                            <td>
                                <%# Eval("PolicyNumber") %>
                            </td>
                            <td>
                                <%# Eval("GroupName") %>
                            </td>
                            <td>
                                <%# Eval("GroupNumber") %>

                            </td>

                             <td>
                                <%# Eval("CoPay") %>
                            </td>
                            <td>
                                <%# Eval("CoInsurance") %>
                            </td>
                            <td>
                                <%# Eval("Relationship")%>
                            </td>

                             <td>
                                <%# Eval("SubscriberName") %>
                            </td>
                            <td>
                                <%# Eval("EffectiveDate","{0:d}") %>
                            </td>
                            <td>
                                <%# Eval("TerminationDate","{0:d}")%>
                            </td>
                            <td>
                              <input type="button" id="InsEdit" class="Edit"/> 
                            </td>
                           
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                               
            </tbody>
                    </table> 
              

</body>
</html>
<script>

    $(".Edit").on('click', function () {

        $("#cover").css("display", "block");
        $("#cover").css("opacity", "2");
        $("#Demographics").css("position", "fixed");

        var currentRow = $(this).closest("tr");
        debugger;
        col = currentRow.find("td:eq(1)").html();


        if (col = "O") {

            $("[id$=txtinsurancetype]").val("Other");
        }
        else if (col = "P") {
            $("[id$=txtinsurancetype]").val("Primary");
        }
        else {

            $("[id$=txtinsurancetype]").val("Secondary");
        }


        var currentRow = $(this).closest("tr");
        debugger;
        var col2 = currentRow.find("td:eq(0)").html();
        $("[id$=Insuranceid]").val(col2);





        InsuranceId = $("[id$=Insuranceid]").val();
        var title = $("[id$=lblLastName]").val() + ' ' + $("[id$=lblFirstName]").val();
        $("#Upatient").text(title);
        $("#UpdateInsuranceDiv").css("display", "block");
        $.post("PatientInsurancehandler/PatientInsuranceUpdateHandler.aspx", { id: InsuranceId }, function (data) {

            $("[id$='UcallbackDiv']").html(data)


        });



    });

</script>