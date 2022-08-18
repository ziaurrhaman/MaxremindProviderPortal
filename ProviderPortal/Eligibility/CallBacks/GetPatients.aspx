<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GetPatients.aspx.cs" Inherits="ProviderPortal_Eligibility_CallBacks_GetPatients" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###Start###
            <script type="text/javascript">
        $(document).ready(function () {
            var dateOfBirthMin = new Date();
            dateOfBirthMin.setYear(dateOfBirthMin.getFullYear() + 1);
            $("[id$='txtDateOfBirthP']").datepicker({
                changeMonth: true,
                changeYear: true,
                maxDate: new Date(),
                yearRange: "-110:+0",
                dateFormat: 'dd/mm/yy',
                onSelect: function (date, obj) {
                    FilterPatient(0, true);
                }
            }).mask("99/99/9999");
          
            GeneratePaging($("[id$='hdnTotalRows']").val(), $("#ddlPagingPatient").val(), "PatientContainer", "FilterPatient");
            if ($("[id$='hdnTotalRows']").val() > 0)
                $("#PatientContainer .spanInfo").html("Showing " + $("#patientList tr:first").children().first().html() + " to " + $("#patientList tr:last").children().first().html() + " of " + $("[id$='hdnTotalRows']").val() + " entries");

        });
            </script>
         <asp:HiddenField ID="hdnPracticeId" runat="server" />
    <asp:HiddenField runat="server" ID="hdnTotalRows" />
    <h1 class="pagetitle">Select Patient</h1>
            <div  id="PatientContainer" >
    <div class="Grid" style="height: 312px; overflow-y:scroll;">
        <table>
            <thead>
                <tr> 
                    <th style="width: 1%;">#
                    </th>
                    <th style="width: 10%;">Patient Id
                    </th>
                    <th style="width: 12%;">Last Name
                    </th>
                    <th style="width: 12%;">First Name
                    </th>
                    <th style="width: 10%;">Gender
                    </th>
                    <th style="width: 10%;">DOB
                    </th>
                  <th style="width: 20%;">Pri Payer
                    </th>
                   
                </tr>
                 <tr>
                    <th>
                        <span class="iconSearch" onclick="FilterPatient(0,true)"></span>
                    </th>
                    <th>
                        <input type="text" id="txtPatientIdP" onkeyup="FilterPatientOnEnter(event);" onkeypress="return patientIdKeyPress(event);" />
                    </th>
                    <th>
                        <input type="text" id="txtLastNameP" onkeyup="FilterPatientOnEnter(event);" />
                    </th>
                    <th>
                        <input type="text" id="txtFirstNameP" onkeyup="FilterPatientOnEnter(event);" />
                    </th>
                    <th>
                        <select id="ddlGenderP" style="width: 100%;" onchange="FilterPatient(0,true);">
                            <option value=""></option>
                            <option value="Male">Male</option>
                            <option value="Female">Female</option>
                        </select>
                    </th>
                    <th>
                        <asp:TextBox runat="server" ID="txtDateOfBirthP" onkeyup="FilterPatient(0,true);"></asp:TextBox>

                    </th>
                     <th>
                        <asp:TextBox runat="server" ID="txtPriPayer" onkeyup="FilterPatientOnEnter(event);"></asp:TextBox>

                    </th>
                
                </tr>
            </thead>
            <tbody id="patientList">
                <asp:Repeater ID="rptPatients" runat="server">
                    <ItemTemplate>
                        <tr style="cursor: pointer" onclick="GetPatientRow('<%# Eval("PatientId") %>','<%# Eval("LastName") %>','<%# Eval("FirstName") %>','<%# Eval("Gender") %>','<%# Eval("DateOfBirth", "{0:d}") %>','<%# Eval("PolicyNumber") %>','<%# Eval("InsuranceId") %>')">
                           <td>
                                <i><%# Eval("RowNumber") %></i>
                            </td>
                            <td>
                                <%# Eval("PatientId") %>
                            </td>
                            <td>
                                <%# Eval("LastName") %>
                            </td>
                            <td>
                                <%# Eval("FirstName") %>
                            </td>
                            <td>
                                <%# Eval("Gender") %>
                            </td>
                            <td>
                                <%# Eval("DateOfBirth", "{0:d}") %>
                            </td>
                          <td>
                                <%# Eval("name") %>
                            </td>
                           
                           
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
       
    </div>
                <div class="Grid">
                 <div class="message">
            <span class="iconInfo" style="margin: 7px;"></span>
            <span class="spanInfo"></span>
        </div>
        <div class="pager">
            <div class="PageEntries">
                <span style="float: left;">
                    <select id="ddlPagingPatient" style="margin-top: 5px;" onchange="RowsChange('FilterPatient');">
                        
                        <option value="10">10</option>
                        <option value="25">25</option>
                        <option value="50">50</option>
                        <option value="75">75</option>
                        <option value="100">100</option>
                    </select>
                </span><%--<span style="float: left;">&nbsp;Entries per page</span>--%>
            </div>
            <div class="PageButtons">
                <ul style="float: right; margin-right: 15px;">
                </ul>
            </div>
        </div>
                    </div>
                </div>
###End###
        </div>
    </form>
</body>
</html>
