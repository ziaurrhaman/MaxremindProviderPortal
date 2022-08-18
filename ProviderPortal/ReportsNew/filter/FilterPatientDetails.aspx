<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterPatientDetails.aspx.cs" Inherits="EMR_ReportsNew_filter_FilterPatientDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###Start###
            <style>
                .patient-rpt-outer table tr:nth-child(odd) {
                    background: none !important;
                }

                #tbodyReportList tr:nth-child(odd) {
                    background: none !important;
                }
            </style>
            <div class="PatientDetails">


            <asp:Repeater ID="rptReportData" runat="server">
                <HeaderTemplate>
                    <div class="" id="printableArea" style="overflow-x: hidden;">


                        <%--
                           <table>
                               <thead>
                                   <tr>
                                       <th>#</th>
                                       <th>
                                           <span class="report-column-title">Patient Id</span>
                                       </th>
                                       <th>
                                           <span class="report-column-title">Patient Name</span>
                                       </th>
                                       <th>
                                           <span class="report-column-title">Social Security No.</span>
                                       </th>
                                       <th>
                                           <span class="report-column-title">Marital Status</span>
                                       </th>
                                       <th>
                                           <span class="report-column-title">Date Of Birth</span>
                                       </th>
                                       <th>
                                           <span class="report-column-title">Gender</span>
                                       </th>
                                       <th>
                                           <span class="report-column-title">Patient Address</span>
                                       </th>
                                       <th>
                                           <span class="report-column-title">Home Phone</span>
                                       </th>
                                       <th>
                                           <span class="report-column-title">Work Phone</span>
                                       </th>
                                       <th>
                                           <span class="report-column-title">Email</span>
                                       </th>
                                   </tr>
                               </thead>
                               <tbody>--%>
                </HeaderTemplate>

                <ItemTemplate>
                    <div class="patient-rpt-outer">

                        <div class="row">
                            <div class="col-lg-8 offset-md-2 p-0">
                                <table>
                                    <tr>
                                        <td>

                                            <table>
                                                <tr>
                                                    <th colspan="4" rowspan="2">
                                                         <h2 class="text-center pReport-heading">Patient Details</h2>
                                                    </th>
                                                </tr>

                                            </table>

                                            <table>
                                                <tr>
                                                    <td colspan="4" class="CustomStyle" style="border-bottom: 1px solid #C4C4C4 !important; width: 1053px;">
                                                       <div class="patient-info-head" style="padding-bottom: 0 !important; border-bottom: 0 !important;"><strong> General Information</strong></div>
                                                    </td>
                                                </tr>


                                            </table>


                                            <table class="patient-info-table">

                                                <tr>
                                                    <td>
                                                        <label><b>Patient Id:</b></label>
                                                    </td>
                                                    <td><%# Eval("PatientId")%></td>
                                                    <td>
                                                        <label><b>Patient Name:</b><label>
                                                    </td>
                                                    <td><%# Eval("PatientName")%></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <label><b>Social Security No.:</b><label>
                                                    </td>
                                                    <td><%# Eval("SSN")%></td>
                                                    <td>
                                                        <label><b>Marital Status:</b><label>
                                                    </td>
                                                    <td><%# Eval("MaritalStatus")%></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <label><b>Date Of Birth:</b><label>
                                                    </td>
                                                    <td><%# Eval("DateOfBirth")%></td>
                                                    <td>
                                                        <label><b>Gender:</b><label>
                                                    </td>
                                                    <td><%# Eval("Gender")%></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <label><b>Patient Address:</b><label>
                                                    </td>
                                                    <td><%# Eval("PatientAddress")%></td>
                                                    <td>
                                                        <label><b>Home Phone:</b><label>
                                                    </td>
                                                    <td><%# Eval("HomePhone")%></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <label><b>Work Phone:</b><label>
                                                    </td>
                                                    <td><%# Eval("WorkPhone")%></td>
                                                    <td>
                                                        <label><b>Email:</b><label>
                                                    </td>
                                                    <div><%# Eval("Email")%></div>



                                                </tr>


                                            </table>
                                        </td>
                                    </tr>

                                </table>


                                <%--<div class="row">
                                       <div class="col-lg-12">
                                           <div class="text-center">
                                               <h2>Patient Details</h2>
                                           </div>
                                       </div>
                                       <div class="col-lg-12 patient-info-head p-0">
                                           
                                       </div>
                                       <td>
                                           <label>Patient Id</label>
                                       </td>
                                       <td><%# Eval("PatientId")%></td>
                                       <td>
                                           <label>Patient Name</label>
                                       </td>
                                       <td><%# Eval("PatientName")%></td>
                                       <td>
                                           <label>Social Security No.</label>
                                       </td>
                                       <td><%# Eval("SSN")%></td>
                                       <td>
                                           <label>Marital Status</label>
                                       </td>
                                       <td><%# Eval("MaritalStatus")%></td>
                                       <td>
                                           <label>Date Of Birth</label>
                                       </td>
                                       <td><%# Eval("DateOfBirth")%></td>
                                       <td>
                                           <label>Gender</label>
                                       </td>
                                       <td><%# Eval("Gender")%></td>
                                       <td>
                                           <label>Patient Address</label>
                                       </td>
                                       <td><%# Eval("PatientAddress")%></td>
                                       <td>
                                           <label>Home Phone</label>
                                       </td>
                                       <td><%# Eval("HomePhone")%></td>
                                       <td>
                                           <label>Work Phone</label>
                                       </td>
                                       <td><%# Eval("WorkPhone")%></td>
                                       <td>
                                           <label>Email</label>
                                       </td>
                                       <div><%# Eval("Email")%></div>








                                   </div>--%>
                            </div>
                        </div>

                    </div>


                    <%--<tr>
                           <td class="center"><%# Container.ItemIndex + 1 %></td>

                           <td>
                               <%# Eval("PatientId")%>
                           </td>
                           <td>
                               <%# Eval("PatientName")%>
                           </td>
                           <td>
                               <%# Eval("SSN")%>
                           </td>
                           <td>
                               <%# Eval("MaritalStatus")%>
                           </td>
                           <td>
                               <%# Eval("DateOfBirth")%>
                           </td>
                           <td>
                               <%# Eval("Gender")%>
                           </td>
                           <td>
                               <%# Eval("PatientAddress")%>
                           </td>
                           <td>
                               <%# Eval("HomePhone")%>
                           </td>
                           <td>
                               <%# Eval("WorkPhone")%>
                           </td>
                           <td>
                               <%# Eval("Email")%>
                           </td>
                       </tr>--%>
                </ItemTemplate>

                <FooterTemplate>
                    <%-- </tbody>
                                    </table>--%>
                            </div>
                </FooterTemplate>

            </asp:Repeater>
            <asp:Repeater ID="rptPatientInsurance" runat="server">
                <HeaderTemplate>
                    <div class="" id="printableArea1" style="overflow-x: hidden; max-height: 100% !important;">
                        <%-- <table>
                            <thead>
                                <tr>
                                    <th>#</th>

                                    <th>
                                        <span class="report-column-title">Patient Insurance Id</span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">Patient Id</span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">Insurance Id</span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">Insurance Type</span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">Insurance Name</span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">Policy Number</span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">Effective Date</span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">Group Number</span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">Insurance Address</span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">Phone No.</span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">Fax</span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">Relation Ship</span>
                                    </th>
                                </tr>
                            </thead>
                            <tbody id="tbodyReportList">--%>
                </HeaderTemplate>

                <ItemTemplate>
                    <div class="patient-rpt-outer">

                        <div class="row">
                            <div class="col-lg-8 offset-md-2 p-0">
                                <table>
                                    <tr>
                                        <td>

                                            <table>
                                                <tr>
                                                    <td colspan="4" style="border-bottom: 1px solid #C4C4C4 !important; width: 1053px;">
                                                       <div class="patient-info-head" style="padding-bottom: 0 !important; border-bottom: 0 !important;"><strong> <%# Eval("InsuranceName")%></strong></div>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table class="patient-info-table">
                                                <tr>
                                                    <td>
                                                        <label><b>Patient Insurance Id:</b><label>
                                                    </td>



                                                    <td><%# Eval("PatientInsuranceId")%></td>
                                                    <td>
                                                        <label><b>Patient Id:</b><label>
                                                    </td>
                                                    <td><%# Eval("PatientId")%></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <label><b>Insurance Id:</b><label>
                                                    </td>
                                                    <td><%# Eval("InsuranceId")%></td>
                                                    <td>
                                                        <label><b>Insurance Type:</b><label>
                                                    </td>
                                                    <td><%# Eval("PriSecOthType")%></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <label><b>Insurance Name:</b><label>
                                                    </td>
                                                    <td><%# Eval("InsuranceName")%></td>
                                                    <td>
                                                        <label><b>Policy Number:</b><label>
                                                    </td>
                                                    <td><%# Eval("PolicyNumber")%></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <label><b>Effective Date:</b><label>
                                                    </td>
                                                    <td><%# Eval("EffectiveDate")%></td>
                                                    <td>
                                                        <label><b>Group Number:</b><label>
                                                    </td>
                                                    <td><%# Eval("GroupNumber")%></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <label><b>Insurance Address:</b><label>
                                                    </td>
                                                    <td><%# Eval("InsuranceAddress")%></td>
                                                    <td>
                                                        <label><b>Phone No.:</b><label>
                                                    </td>
                                                    <td><%# Eval("phone")%></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <label><b>Fax:</b><label>
                                                    </td>
                                                    <td><%# Eval("Fax")%></td>
                                                    <td>
                                                        <label><b>Relation Ship:</b><label>
                                                    </td>
                                                    <td><%# Eval("Relationship")%></td>
                                                </tr>
                                            </table>




                                        </td>
                                    </tr>
                                </table>




                                <%--
                                <div class="row">

                                    <div class="col-lg-12 patient-info-head p-0">
                                        <span></span>
                                    </div>

                                    <div class="col-lg-3">
                                        <label>Patient Insurance Id</label>
                                    </div>
                                    <div class="col-lg-3"><%# Eval("PatientInsuranceId")%></div>
                                    <div class="col-lg-3">
                                        <label>Patient Id</label>
                                    </div>
                                    <div class="col-lg-3"><%# Eval("PatientId")%></div>
                                    <div class="col-lg-3">
                                        <label>Insurance Id</label>
                                    </div>
                                    <div class="col-lg-3"><%# Eval("InsuranceId")%></div>
                                    <div class="col-lg-3">
                                        <label>Insurance Type</label>
                                    </div>
                                    <div class="col-lg-3"><%# Eval("PriSecOthType")%></div>
                                    <div class="col-lg-3">
                                        <label>Insurance Name</label>
                                    </div>
                                    <div class="col-lg-3"><%# Eval("InsuranceName")%></div>
                                    <div class="col-lg-3">
                                        <label>Policy Number</label>
                                    </div>
                                    <div class="col-lg-3"><%# Eval("PolicyNumber")%></div>
                                    <div class="col-lg-3">
                                        <label>Effective Date</label>
                                    </div>
                                    <div class="col-lg-3"><%# Eval("EffectiveDate")%></div>
                                    <div class="col-lg-3">
                                        <label>Group Number</label>
                                    </div>
                                    <div class="col-lg-3"><%# Eval("GroupNumber")%></div>
                                    <div class="col-lg-3">
                                        <label>Insurance Address</label>
                                    </div>
                                    <div class="col-lg-3"><%# Eval("InsuranceAddress")%></div>
                                    <div class="col-lg-3">
                                        <label>Phone No.</label>
                                    </div>
                                    <div class="col-lg-3"><%# Eval("phone")%></div>
                                    <div class="col-lg-3">
                                        <label>Fax</label>
                                    </div>
                                    <div class="col-lg-3"><%# Eval("Fax")%></div>
                                    <div class="col-lg-3">
                                        <label>Relation Ship</label>
                                    </div>
                                    <div class="col-lg-3"><%# Eval("Relationship")%></div>






                                </div>--%>
                            </div>
                        </div>

                    </div>




                    <%-- <tr>
                        <td class="center"><%# Container.ItemIndex + 1 %></td>

                        <td>
                            <%# Eval("PatientInsuranceId")%>
                        </td>
                        <td>
                            <%# Eval("PatientId")%>
                        </td>
                        <td>
                            <%# Eval("InsuranceId")%>
                        </td>
                        <td>
                            <%# Eval("PriSecOthType")%>
                        </td>
                        <td>
                            <%# Eval("InsuranceName")%>
                        </td>
                        <td>
                            <%# Eval("PolicyNumber")%>
                        </td>
                        <td>
                            <%# Eval("EffectiveDate")%>
                        </td>
                        <td>
                            <%# Eval("GroupNumber")%>
                        </td>
                        <td>
                            <%# Eval("InsuranceAddress")%>
                        </td>
                        <td>
                            <%# Eval("phone")%>
                        </td>
                        <td>
                            <%# Eval("Fax")%>
                        </td>
                        <td>
                            <%# Eval("Relationship")%>
                        </td>
                    </tr>--%>
                </ItemTemplate>

                <FooterTemplate>
                    <%-- </tbody>
                                    </table>--%>
                            </div>
                </FooterTemplate>

            </asp:Repeater>
                            </div>
            <asp:HiddenField ID="hdnPatientId" runat="server" />
            ###End###
    
    ###StartTotal###
    <asp:Literal runat="server" ID="ltrTotalRows"></asp:Literal>
            ###EndTotal###


        </div>
    </form>
</body>
</html>
