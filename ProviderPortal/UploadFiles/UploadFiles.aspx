<%@ Page Title="" Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master" AutoEventWireup="true" CodeFile="UploadFiles.aspx.cs" Inherits="ProviderPortal_UploadFiles_UploadFiles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:HiddenField runat="server" ID="hdnTotalRows" />
     <h1>Upload Files</h1>
    <div class="Grid" id="UploadFileContainer">
        <table>
            <thead>
                <tr>
                    <th style="width: 2%;">#
                    </th>
                    <th style="width: 10%;">Created Date
                    </th>
                    <th style="width: 12%;">File Name
                    </th>
                    <th style="width: 12%;">File Status
                    </th>
                    <th style="width: 10%;">File Type
                    </th>
                    <th style="width: 10%;">Patients
                    </th>
                    <th style="width: 10%;">Claims
                    </th>
                   
                   
                </tr>
                <tr>
                    <th>
                        <span class="iconSearch"></span>
                    </th>
                    <th>
                        <input type="text" id="txtCreatedDate" onkeyup="FilterUploadFiles(0,true);" />
                    </th>
                    <th>
                        <input type="text" id="txtFileName" onkeyup="FilterUploadFiles(0,true);" />
                    </th>
                    <th>
                       <select id="ddlFileStatus" style="width: 100%;" onchange="FilterUploadFiles(0,true);">
                            <option value=""></option>
                            <option value="Received">Received</option>
                            <option value="In process">In Process</option>
                            <option value="Processed">Processed</option>
                            <option value="On hold">On Hold</option>
                            <option value="Rejected">Rejected</option>
                            <option value="Other">Other</option>                           
                          </select>
                    </th>
                    <th>
                        <select id="ddlSubmissionMethod" style="width: 100%;" onchange="FilterUploadFiles(0,true);">
                            <option value=""></option>
                            <option value="HCFA">HCFA</option>
                            <option value="Billing File">Billing File</option>
                            <option value="EDI 837 Billing File">EDI 837 Billing File</option>
                            <option value="Drop Box">Drop Box</option>
                            <option value="Credentialing info">Credentialing info</option>
                            <option value="Enrollment Packet">Enrollment Packet</option>
                            <option value="Practice Info">Practice Info</option>
                            <option value="Provider Info">Provider Info</option>
                            <option value="Patient Profile">Patient Profile</option>
                            <option value="ERA">ERA</option>
                            <option value="EOB">EOB</option>
                            <option value="Payment Check">Payment Check</option>
                            <option value="Misc">Misc</option>
                            <option value="Progress Notes">Progress Notes</option>
                         
                        </select>
                    </th>
                    <th>
                     
                           <input type="text" id="txtPatients" onkeyup="FilterUploadFiles(0,true);" />

                    </th>
                    <th>
                        <input type="text" id="txtClaims" onkeyup="FilterUploadFiles(0,true);" />
                    </th>
                    
                
                </tr>
            </thead>
            <tbody id="UploadFileList">
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
            </tbody>
        </table>
        <div class="message">
            <span class="iconInfo" style="margin: 7px;"></span>
            <span class="spanInfo"></span>
        </div>
        <div class="pager">
            <div class="PageEntries">
                <span style="float: left;">
                    <select id="ddlPagingUploadFile" style="margin-top: 5px;" onchange="RowsChange('FilterUploadFiles');">
                        
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



    <script type="text/javascript">

        $(document).ready(function () {
            var dateOfBirthMin = new Date();
            dateOfBirthMin.setYear(dateOfBirthMin.getFullYear() + 1);
            $("[id$='txtCreatedDate']").datepicker({
                changeMonth: true,
                changeYear: true,
                maxDate: new Date(),
                yearRange: "-110:+0",
                onSelect: function (date, obj) {
                    FilterUploadFiles(0, true);
                }
            }).mask("99/99/9999");

            GeneratePaging($("[id$='hdnTotalRows']").val(), $("#ddlPagingUploadFile").val(), "UploadFileContainer", "FilterUploadFiles");
            if ($("[id$='hdnTotalRows']").val() > 0)
                $("#UploadFileContainer .spanInfo").html("Showing " + $("#UploadFileList tr:first").children().first().html() + " to " + $("#UploadFileList tr:last").children().first().html() + " of " + $("[id$='hdnTotalRows']").val() + " entries");
        });


        function FilterUploadFiles(pageNumber, paging) {

            debugger;


          

            var CreatedDate = $.trim($("#txtCreatedDate").val());
            var FileName = $.trim($("#txtFileName").val());
            var FileStatus = $.trim($("#ddlFileStatus").val());
            var SubmissionMethod = $.trim($("#ddlSubmissionMethod").val());
            var Patients = $.trim($("#txtPatients").val());
            var Claims = $.trim($("#txtClaims").val());
            

            $.post("../UploadFiles/CallsBack/UploadFilesHandler.aspx", { CreatedDate: (isDate(CreatedDate) ? CreatedDate : ""), FileName: FileName, FileStatus: FileStatus, SubmissionMethod: SubmissionMethod, Patients: Patients, Claims: Claims, Rows: $("#ddlPagingUploadFile").val(), PageNumber: pageNumber }, function (data) {
                var returnHtml = data;
                var start = data.indexOf("###Start###") + 11;
                var end = data.indexOf("###End###");
                $("#UploadFileList").html(returnHtml.substring(start, end));
                debugger;
                var startRowsCount = data.indexOf("###StartPatientRowsCount###") + 30;
                var endRowsCount = data.indexOf("###EndPatientRowsCount###");
                $("[id$='hdnTotalRows']").val($.trim(returnHtml.substring(startRowsCount, endRowsCount)));

                if (paging == true) {
                    GeneratePaging($("[id$='hdnTotalRows']").val(), $("#ddlPagingUploadFile").val(), "UploadFileContainer", "FilterUploadFiles");
                }

                if ($("[id$='hdnTotalRows']").val() > 0)
                    $("#UploadFileContainer .spanInfo").html("Showing " + $("#UploadFileList tr:first").children().first().html() + " to " + $("#UploadFileList tr:last").children().first().html() + " of " + $("[id$='hdnTotalRows']").val() + " entries");
            });
        }



    </script>
</asp:Content>

