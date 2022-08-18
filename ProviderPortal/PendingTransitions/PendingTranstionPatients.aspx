<%@ Page Title="" Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master" AutoEventWireup="true" CodeFile="PendingTranstionPatients.aspx.cs" Inherits="ProviderPortal_PendingTranstionClaimList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    
    <script type="text/javascript" src="../../Scripts/Rizwan/PendingTransition.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="hdnPracticeId" runat="server" />
    <asp:HiddenField runat="server" ID="hdnTotalRows" />
    <div id="cover">  </div> 
    <h1 class="pagetitle">Patients Pending Transitions</h1> 

    <div id="divMesg" style="background-color:rgba(151, 255, 0, 0.73); margin-left:410px; width:20%; height:33px; border-radius:5px; text-align:center;display:none;">
       <label style="font-size:15px;top: 7px; position: relative;"><span>Record Updated succesfully</span></label> 
    </div>
     
    <div id="leftbar">

    </div>
    <div class="Grid" id="PatientContainer">
        <table>
            <thead>
                <tr>
                    <th style="width: 2%;">#
                    </th>
                    <th style="width: 8%;">Account Number
                    </th>
                    <th style="width: 8%;">Last Name
                    </th>
                    <th style="width: 8%;">First Name
                    </th>
                    <th style="width: 8%;">Gender
                    </th>
                    <th style="width: 8%;">DOB
                    </th>
                    <th style="width: 8%;">Phone
                    </th>
                    <th style="width: 16%;">Address
                    </th>
                    <th>Reasons
                    </th>
                </tr>
                <tr>
                    <th>
                        <span class="iconSearch"></span>
                    </th>
                    <th>
                        <input type="text" id="txtPatientId" onkeyup="FilterPatient(0,true);" onkeypress="return patientIdKeyPress(event);" />
                    </th>
                    <th>
                        <input type="text" id="txtLastName" onkeyup="FilterPatient(0,true);" />
                    </th>
                    <th>
                        <input type="text" id="txtFirstName" onkeyup="FilterPatient(0,true);" />
                    </th>
                    <th>
                        <select id="ddlGender" style="width: 100%;" onchange="FilterPatient(0,true);">
                            <option value=""></option>
                            <option value="Male">Male</option>
                            <option value="Female">Female</option>
                        </select>
                    </th>
                    <th>
                        <asp:TextBox runat="server" ID="txtDateOfBirth" onkeyup="FilterPatient(0,true);"></asp:TextBox>

                    </th>
                    <th>
                        <input type="text" id="txtPhone" onkeyup="FilterPatient(0,true);" />
                    </th>
                    <th style="width: 23%;">
                        <input type="text" id="txtAddress" onkeyup="FilterPatient(0,true);" />
                    </th>

                    <%-- PtlReasons start  --%>
   <th>
       <%-- <asp:DropDownList ID="ddlPtlReasons" runat="server" CssClass="select" Style="float: none;" onchange="RowsChange('FilterPatient');">  </asp:DropDownList>--%>
        <div class="dropdownMenuMultiCheckMainWrapper">
                                                        <select></select>
                                          <div class="div-dropdown-label-wrapper" onclick="HideShowPTLReasonDropDown(this);">
                                                            <span class="custom-drop-down-label"></span>
                                                        </div>
                                         <div class="dropdownMenuMultiCheck" style="top: 25px; width: 100%;">
                                                            <div class="div-drop-down" style="height: 150px;">
                                                                <ul id="ulPTLReasonFilterListPatient" style="text-align: left; overflow-x: hidden;">
                                                                    <li>
                                                                        <label>
                                                                            <input type="checkbox" class="chkPTLReasonsAll" onclick="SelectUnselectPTLReasons_All(this);" />
                                                                            All
                                                                        </label>
                                                                    </li>
                                                                    <asp:Repeater runat="server" ID="rptPTLReasonsPatient">
                                                                        <ItemTemplate>
                                                                            <li>
                                                                                <label>
                                                                                    <input type="checkbox" id='chkPatientPTLReasonsId<%#Eval("PTLReasonsId") %>' class="chkReason CheckReasons_RemoveingChk" onclick="SelectUnselectPTLReasons(this);" />
                                                                                    <span class="spnReason"><%#Eval("Reason")%></span>
                                                                                    
                                                                                    <input type="hidden" class="hdnPTLReasonsId" value='<%#Eval("PTLReasonsId") %>' />
                                                                                </label>
                                                                            </li>
                                                                        </ItemTemplate>
                                                                    </asp:Repeater>
                                                                </ul>
                                                            </div>
                                                            <div class="divBottom">
                                                                <input type="button" onclick="OkMultiCheckDropDownPTLReason(this, 'Patient');" value="OK" />
                                                            </div>
                                                        </div>
                                                    </div>

   </th>       

                     <%-- End PtlReasons  --%>
                </tr>
            </thead>
            <tbody id="tbodyPTLPatient">
                <asp:Repeater ID="rptPatients" runat="server">
                    <ItemTemplate>
                        <tr style="cursor: pointer" class="ptlid"  <%--onclick="PTLPatientDialog(' <%# Eval("PatientId") %>');"--%>>
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
                                <%# Eval("Cell") %>
                            </td>
                            <td>
                                <%# Eval("Address") %>
                            </td>
                            <td class="tdPTLReasons">
                                      <span><%# Eval("PTLReasons")%></span>
                                <input type="hidden" class="hdnPTLNotes" value='<%#Eval("PTLNotes") %>' />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
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
                </span><span style="float: left;">&nbsp;Entries per page</span>
            </div>
            <div class="PageButtons">
                <ul style="float: right; margin-right: 15px;">
                </ul>
            </div>
        </div>
    </div>

     <asp:HiddenField ID="PatientId" runat="server"></asp:HiddenField>
   
    
      <style>
       #cover{
    position:fixed;
    top:0;
    left:0;
    background:rgba(0,0,0,0.6);
    z-index:5;
    width:100%;
    height:100%;
    display:none;
}
   </style>
    <script type="text/javascript">




        $(document).ready(function () {


            var dateOfBirthMin = new Date();
            dateOfBirthMin.setYear(dateOfBirthMin.getFullYear() + 1);
            $("[id$='txtDateOfBirth']").datepicker({
                changeMonth: true,
                changeYear: true,
                maxDate: new Date(),
                yearRange: "-110:+0",
                onSelect: function (date, obj) {
                    FilterPatient(0, true);
                }
            }).mask("99/99/9999");

            GeneratePaging($("[id$='hdnTotalRows']").val(), $("#ddlPagingPatient").val(), "PatientContainer", "FilterPatient");
            if ($("[id$='hdnTotalRows']").val() > 0)
                $("#PatientContainer .spanInfo").html("Showing " + $("#tbodyPTLPatient tr:first").children().first().html() + " to " + $("#tbodyPTLPatient tr:last").children().first().html() + " of " + $("[id$='hdnTotalRows']").val() + " entries");
        });

    

      


    </script>

</asp:Content>

