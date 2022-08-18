<%@ Page Title="" Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master"
    AutoEventWireup="true" CodeFile="Messages.aspx.cs" Inherits="HomeHealth_Messages_Messages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../../jQueryPlugins/tinymce/jscripts/tiny_mce/tiny_mce.js" type="text/javascript"></script>
    <script src="../../jQueryPlugins/FileUpload/ajaxupload.js" type="text/javascript"></script>
    <link href="../../StyleSheets/customFileUpload.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/Messages.js" type="text/javascript"></script>
    <script type="text/javascript">



        $(document).ready(function () {
            $("#_messages").addClass("active");
        });


        $(function () {
            GeneratePaging($("[id$='hdnTotalRows']").val(), $("#ddlPaging").val(), "divMessagesList", "FilterRecord");
            if ($("[id$='hdnTotalRows']").val() > 0)
                $("#spnInfo").html("Showing " + $("#messageList tr:first").children().first().html() + " to " + $("#messageList tr:last").children().first().html() + " of " + $("[id$='hdnTotalRows']").val() + " entries");
            else
                $("#spnInfo").html("No more messages.");
            CheckedAllOnCheck();
            initializeMessageFileUpload();
        });

        function GetMessageDetail(messageId) {
            $("#" + messageId).find(".iconUnReadMessage").addClass("iconReadMessage").removeClass("iconUnReadMessage");
            $("#" + messageId).removeAttr("style");
            $.post("CallBacks/GetMessageDetailHandler.aspx", { MessageId: messageId },
                function (data) {
                    var returnHtml = data;
                    var start = data.indexOf("###Start###") + 11;
                    var end = data.indexOf("###End###");
                    $("#divHeader").html(returnHtml.substring(start, end));

                    var bodyStart = data.indexOf("###BodyStart###") + 15;
                    var bodyEnd = data.indexOf("###BodyEnd###");
                    var body = returnHtml.substring(bodyStart, bodyEnd);

                    body = decodeURI(body);
                    $("#divBody").html(body);

                    $("#divMessagesList").hide();
                    $("#btnBackToInbox").show();
                    $("#divMessageActions").show();
                    $("#divMessageDetail").show();
                    $("#hidnMsgId").val(messageId);

                    start = data.indexOf("###StartUnreadCount###") + 22;
                    end = data.indexOf("###EndUnreadCount###");
                    $(".lblUnreadMessageCount, [id$='lblUnreadMessageCount']").html($.trim(returnHtml.substring(start, end)));
                });
        }

        function BackToInbox() {
            $("#divMessagesList").show();
            $("#divMessageDetail").hide();
            $("#btnBackToInbox").hide();
            $("#divMessageActions").hide();
        }

        function ShowMessages(obj) {
            $("#divEMRMessages").show();
            $("#divPHRMessages").hide();
            $("#divMessagesList").show();
            $("#divMessageDetail").hide();
            $("#btnBackToInbox").hide();
            $("#divMessageActions").hide();
            $(obj).siblings().removeClass("selected");
            $(obj).addClass("selected");
            FilterRecord(0, true);
        }

        function SearchRecord() {
            FilterRecord(0, true);
        }
        function FilterRecord(pageNumber, paging) {
            var SearchValue = $("#txtSearchMessage").val();
            $.post("CallBacks/MessageListingHandler.aspx", { SearchValue: SearchValue, Rows: $("#ddlPaging").val(), PageNumber: pageNumber, SortBy: "", IsInbox: $("#liInbox").hasClass("selected"), IsDraft: $("#liDraft").hasClass("selected"), IsSentMessages: $("#liIsSent").hasClass("selected"), IsDeleted: $("#liDelete").hasClass("selected") },
            function (data) {
                var returnHtml = data;
                var start = data.indexOf("###MessageListStart###") + 22;
                var end = data.indexOf("###MessageListEnd###");

                var startRowsCount = data.indexOf("###RowCountStart###") + 19;
                var endRowsCount = data.indexOf("###RowCountEnd###");
                $("[id$='hdnTotalRows']").val($.trim(returnHtml.substring(startRowsCount, endRowsCount)));

                if ($("#liIsSent").hasClass("selected")) {
                    $("#sentMessagesList").html(returnHtml.substring(start, end));
                    $("#tblSentMessageList").show();
                    $("#tblMessageList").hide();

                    if ($("[id$='hdnTotalRows']").val() > 0)
                        $("#spnInfo").html("Showing " + $("#sentMessagesList tr:first").children().first().html() + " to " + $("#sentMessagesList tr:last").children().first().html() + " of " + $("[id$='hdnTotalRows']").val() + " entries");
                    else
                        $("#spnInfo").html("No more messages.");
                }
                else {
                    $("#messageList").html(returnHtml.substring(start, end));
                    $("#tblSentMessageList").hide();
                    $("#tblMessageList").show();

                    if ($("[id$='hdnTotalRows']").val() > 0)
                        $("#spnInfo").html("Showing " + $("#messageList tr:first").children().first().html() + " to " + $("#messageList tr:last").children().first().html() + " of " + $("[id$='hdnTotalRows']").val() + " entries");
                    else
                        $("#spnInfo").html("No more messages.");
                }

                if (paging == true) {
                    GeneratePaging($("[id$='hdnTotalRows']").val(), $("#ddlPaging").val(), "divMessagesList", "FilterRecord");
                }
                CheckedAllOnCheck();
            });
        }

        function CheckedAllOnCheck() {
            $("table:visible tbody .chkBox").click(function () {
                if ($('table:visible tbody .chkBox:checked').length == $('table:visible tbody .chkBox').length) {
                    $("table:visible #chkMarkAll").prop('checked', true);
                } else {
                    $("table:visible #chkMarkAll").prop('checked', false);
                }
            });
        }

        function CheckAll(obj) {
            if ($(obj).is(":checked"))
                $("#messageList input:checkbox").prop('checked', true);
            else
                $("#messageList input:checkbox").prop('checked', false);
        }
        function CheckAllSent(obj) {

            if ($(obj).is(":checked"))
                $("#sentMessagesList input:checkbox").prop('checked', true);
            else
                $("#sentMessagesList input:checkbox").prop('checked', false);
        }

        function ReloadMessages() {
            var pageNo = $("li.current").index() < 0 ? 0 : $("li.current").index() - 2;
            FilterRecord(pageNo, true);
        }

        function CustomerSupprots() {
            $(".nav-list li").removeClass("selected");
            $("#divEMRMessages").hide();
            $("#divPHRMessages").show();
            generatePatientMessagesPagging();
        }

        function generatePatientMessagesPagging() {
            GeneratePaging($("[id$='hdnPatientMessageTotalRows']").val(), $("#ddlPagingPatientMessage").val(), "gridPatientMessages", "FilterPatientMessages");
            if ($("[id$='hdnPatientMessageTotalRows']").val() > 0)
                $("#gridPatientMessages .spanInfo").html("Showing " + $("#listPatientMessages tr:first").children().first().html() + " to " + $("#listPatientMessages tr:last").children().first().html() + " of " + $("[id$='hdnPatientMessageTotalRows']").val() + " entries");
            else
                addNoRecordFoundMessage();
        }
        var _IsPatientIdValidated = true;
        function patientIdKeyPress(evt) {
            _IsPatientIdValidated = true;
            var isValidate = ValidateOnlyNumber(evt);
            if (!isValidate) {
                _IsPatientIdValidated = false;
            }

            return _IsPatientIdValidated;
        }
        function FilterPatientMessages(pageNumber, paging) {
            if (!_IsPatientIdValidated) {
                return false;
            }
            var PatientId = $.trim($("#txtPatientIdFilter").val()) == "" ? 0 : $.trim($("#txtPatientIdFilter").val());
            var PatientName = $.trim($(".txtPatientNameFilter").val());
            var _Subject = $.trim($(".txtSubjectFilter").val());
            var _Priority = $.trim($("[id$='ddlPriorityFilter']").val());
            $.post("CallBacks/CustomerSupportHandler.aspx", { Subject: _Subject, PatientName: PatientName, Priority: _Priority, PatientId: PatientId, Rows: $("#ddlPagingPatientMessage").val(), PageNumber: pageNumber, SortBy: "", action: "Filter" }, function (data) {
                var start = data.indexOf("###StartPatientMessage###") + 25;
                var end = data.indexOf("###EndPatientMessage###");
                $("#listPatientMessages").html($.trim(data.substring(start, end)));
                if (paging == true) {
                    generatePatientMessagesPagging();
                }

                if ($("[id$='hdnPatientMessageTotalRows']").val() > 0)
                    $("#gridPatientMessages .spanInfo").html("Showing " + $("#listPatientMessages tr:first").children().first().html() + " to " + $("#listPatientMessages tr:last").children().first().html() + " of " + $("[id$='hdnPatientMessageTotalRows']").val() + " entries");
                else
                    addNoRecordFoundMessage();
            });
        }

        function viewMessage(elem) {
            var currentRow = $(elem).closest("tr");
            $("[id$='lblCity']").html(currentRow.find(".hndPatientCity").val());
            $("[id$='lblPatientName']").html(currentRow.find(".hndPatientName").val());
            $("[id$='lblEmail']").html(currentRow.find(".hndcontactPatientEmail").val());
            $("[id$='lblPriority']").html(currentRow.find(".hndPriority").val());
            $("[id$='lblSubject']").html(currentRow.find(".hndcontactSubject").val());
            $("[id$='lblMessageDetail']").html(currentRow.find(".hndcontactMessage").val());
            var reply = currentRow.find(".hndcontactMessageReply").val();
            if (reply != "") {
                $(".trReply").show();
                $("[id$='lblMessageReply']").html(reply);
            }
            if (currentRow.find("td:eq(2)").find("span").hasClass("iconUnReadMessage")) {
                ReadMessage(currentRow.find(".hndPatientContactMessagesId").val());
            }

            $("#divCustomerMessageDetail").dialog({
                resizable: false,
                height: '500',
                width: '700',
                title: 'Patient Message',
                modal: true,
                close: function () {
                    $(this).dialog("destroy");
                }
            });
        }
        function CancelViewMessage() {
            $("#divCustomerMessageDetail").dialog("close");
        }
        var currentRow = null;
        function ReplyContactMessage(elem) {
            currentRow = $(elem).closest("tr");
            $("[id$='txtReply']").val(currentRow.find(".hndcontactMessageReply").val());
            $("#divPatientReply").dialog({
                resizable: false,
                height: '400',
                width: '500',
                title: 'Reply to Patient',
                modal: true,
                close: function () {
                    $(this).dialog("destroy");
                }
            });
        }

        function replyPatient() {
            if (!ValidateForm("divPatientReply")) {
                showErrorMessage("");
                return;
            }

            var objPatientMessage = new Object();
            objPatientMessage.PatientContactMessagesId = currentRow.find(".hndPatientContactMessagesId").val();
            objPatientMessage.PatientId = currentRow.find(".hndPatientId").val();
            objPatientMessage.PatientEmail = currentRow.find(".hndcontactPatientEmail").val();
            objPatientMessage.Priority = currentRow.find(".hndPriority").val();
            objPatientMessage.Subject = currentRow.find(".hndcontactSubject").val();
            objPatientMessage.Message = currentRow.find(".hndcontactMessage").val();
            objPatientMessage.MessageReply = $("[id$='txtReply']").val();
            $.post("CallBacks/CustomerSupportHandler.aspx", { objPatientMessage: JSON.stringify(objPatientMessage), action: "Reply" }, function (data) {
                var start = data.indexOf("###StartPatientMessage###") + 25;
                var end = data.indexOf("###EndPatientMessage###");
                $("#listPatientMessages").html($.trim(data.substring(start, end)));
                generatePatientMessagesPagging();
                showSuccessMessage(_msg_Updated);
                CancelreplyPatient();
            });
        }
        function deleteContactMessage(contactMessageId) {
            $.post("CallBacks/CustomerSupportHandler.aspx", { contactMessageId: contactMessageId, action: "Delete" }, function (data) {
                var start = data.indexOf("###StartPatientMessage###") + 25;
                var end = data.indexOf("###EndPatientMessage###");
                $("#listPatientMessages").html($.trim(data.substring(start, end)));
                generatePatientMessagesPagging();
                showSuccessMessage(_msg_Deleted);
            });
        }

        function ReadMessage(contactMessageId) {
            $.post("CallBacks/CustomerSupportHandler.aspx", { contactMessageId: contactMessageId, action: "Read" }, function (data) {
                var start = data.indexOf("###StartPatientMessage###") + 25;
                var end = data.indexOf("###EndPatientMessage###");
                $("#listPatientMessages").html($.trim(data.substring(start, end)));
                generatePatientMessagesPagging();
            });
        }

        function CancelreplyPatient() {
            $("[id$='txtReply']").val("");
            $("#divPatientReply").dialog("close");
        }
        function addNoRecordFoundMessage() {
            var html = "<span style='color: red; font-size: 14px; font-weight: bold; font-style: italic;'>No Record Found</span>";
            $("#gridPatientMessages div.message").find(".spanInfo").html(html);

        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-content">
        <asp:HiddenField runat="server" ID="hdnTotalRows" />
        <h1 class="pagetitle">Messages</h1>


        <div style="width: 100%; float: left;" id="divMessages">
            <div class="leftPanel" style="margin-left: 10px;">
                <input type="button" id="btnComposeMessage" onclick="ComposeNewMessage();" value="Compose"
                    style="width: 150px;" />
                <ul class="nav-list">
                    <li id="liInbox" onclick="ShowMessages(this);" class="selected" style="position: relative;">
                        <a>Inbox</a>
                        <asp:Label ID="lblUnreadMessageCount1" runat="server" CssClass="lblUnreadMessageCount" Text="" Style="position: absolute; right: 6px; top: 0px; color: white;"></asp:Label>
                    </li>
                    <li id="liDraft" onclick="ShowMessages(this);"><a>Draft</a></li>
                    <li id="liIsSent" onclick="ShowMessages(this);"><a>Sent Item</a></li>
                    <li id="liDelete" onclick="ShowMessages(this);"><a>Deleted</a></li>
                </ul>
               <%-- <div>
                    <input type="button" onclick="CustomerSupprots();" value="Customer Support" style="width: 150px;" />
                </div>--%>
            </div>
            <div class="rightPanel">
                <div id="divEMRMessages">
                    <div id="divMessageHeader">
                        <div style="float: left;">
                            <a class="btn" style="margin-right: 6px; display: none;" onclick="BackToInbox();"
                                title="Back" id="btnBackToInbox"><span class="iconBackToInbox"></span></a><a class="btn"
                                    onclick="ReloadMessages();" title="Refresh"><span class="iconRefresh"></span>
                                </a><a class="btn" style="margin-left: 7px;" onclick="DeleteMessage();" title="Delete">
                                    <span class="iconDelete"></span></a>
                            <div class="btn-group" id="divMessageActions" style="display: none;">
                                <a class="btn"><span class="iconReply" onclick="Reply();" title="Reply"></span></a>
                                <a class="btn" onclick="ReplyAll();" title="Reply All"><span class="iconReplyAll"></span>
                                </a><a class="btn" onclick="Forward();" title="Forward"><span class="iconForward"></span>
                                </a>
                            </div>
                        </div>
                        <div id="divSearch">
                            <span style="float: left;">
                                <input type="text" id="txtSearchMessage" style="width: 210px;" placeholder="search message" /></span> <span class="iconSearchMessage"
                                    onclick="SearchRecord();"></span>
                        </div>
                    </div>
                    <div id="divMessagesList" class="Grid" style="width: 99%;">
                        <table border="0" cellpadding="0" cellspacing="0" id="tblMessageList">
                            <thead>
                                <tr>
                                    <th style="width: 5%;">
                                        <input type="checkbox" id="chkMarkAll" onclick="CheckAll(this);" />
                                    </th>
                                    <th></th>
                                    <th style="width: 20%;">From
                                    </th>
                                    <th style="width: 50%; text-align: center;">Subject
                                    </th>
                                    <th style="width: 25%; text-align: center;">Date
                                    </th>
                                </tr>
                            </thead>
                            <tbody id="messageList">
                                <asp:Repeater runat="server" ID="rptMessageList" OnItemDataBound="rptMessageList_ItemDataBound">
                                    <ItemTemplate>
                                        <tr id='<%#Eval("MessagesId")%>' style='font-weight: <%#Eval("MessageStatus").ToString()=="Read"?"":"bold"%>;'>
                                            <td style="display: none;">
                                                <%#Eval("RowNumber")%>
                                            </td>
                                            <td style="text-align: center">
                                                <input type="checkbox" id='<%#Eval("MessagesId")%>' class="chkBox" />
                                            </td>
                                            <td onclick="GetMessageDetail('<%#Eval("MessagesId")%>')" style="cursor: pointer;">
                                                <span class='<%#Eval("MessageStatus").ToString()=="Read"?"iconReadMessage":"iconUnReadMessage"%>'></span>
                                            </td>
                                            <td onclick="GetMessageDetail('<%#Eval("MessagesId")%>')" style="cursor: pointer;">
                                                <%#Eval("Name")%>
                                            </td>
                                            <td onclick="GetMessageDetail('<%#Eval("MessagesId")%>')" style="cursor: pointer;">
                                                <span style="margin-right: 5px;">
                                                    <asp:Image runat="server" ID="imgPriority" />
                                                </span>
                                                <%#Eval("Subject")%>
                                                <span style="float: right" class='<%#int.Parse(Eval("Attachment").ToString()) > 0 ?"iconAttachment":""%>'></span>
                                            </td>
                                            <td style="text-align: center; cursor: pointer;" onclick="GetMessageDetail('<%#Eval("MessagesId")%>')">
                                                <%#Eval("CreatedDate")%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <AlternatingItemTemplate>
                                        <tr id='<%#Eval("MessagesId")%>' style='font-weight: <%#Eval("MessageStatus").ToString()=="Read"?"":"bold"%>;'
                                            class="alternatingRow">
                                            <td style="display: none;">
                                                <%#Eval("RowNumber")%>
                                            </td>
                                            <td style="text-align: center;">
                                                <input type="checkbox" id='<%#Eval("MessagesId")%>' class="chkBox" />
                                            </td>
                                            <td onclick="GetMessageDetail('<%#Eval("MessagesId")%>')" style="cursor: pointer;">
                                                <span class='<%#Eval("MessageStatus").ToString()=="Read"?"iconReadMessage":"iconUnReadMessage"%>'></span>
                                            </td>
                                            <td onclick="GetMessageDetail('<%#Eval("MessagesId")%>')" style="cursor: pointer;">
                                                <%#Eval("Name")%>
                                            </td>
                                            <td onclick="GetMessageDetail('<%#Eval("MessagesId")%>')" style="cursor: pointer;">
                                                <span style="margin-right: 5px;">
                                                    <asp:Image runat="server" ID="imgPriority" />
                                                </span>
                                                <%#Eval("Subject")%>
                                                <span style="float: right" class='<%#int.Parse(Eval("Attachment").ToString()) > 0 ?"iconAttachment":""%>'></span>
                                            </td>
                                            <td style="text-align: center;" onclick="GetMessageDetail('<%#Eval("MessagesId")%>')"
                                                style="cursor: pointer;">
                                                <%#Eval("CreatedDate")%>
                                            </td>
                                        </tr>
                                    </AlternatingItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                        <table border="0" cellpadding="0" cellspacing="0" id="tblSentMessageList" style="display: none;">
                            <thead>
                                <tr>
                                    <th>
                                        <input type="checkbox" onclick="CheckAllSent(this);" id="chkMarkAll" />
                                    </th>
                                    <th style="width: 25%;">To
                                    </th>
                                    <th style="width: 50%; text-align: center;">Subject
                                    </th>
                                    <th style="width: 25%; text-align: center;">Date
                                    </th>
                                </tr>
                            </thead>
                            <tbody id="sentMessagesList">
                            </tbody>
                        </table>
                        <div class="message">
                            <span class="iconInfo" style="margin: 7px;"></span><span id="spnInfo"></span>
                        </div>
                        <div class="pager">
                            <div class="PageEntries">
                                <span style="float: left; margin-left: 5px;">Show&nbsp;</span><span style="float: left;">
                                    <select id="ddlPaging" style="margin-top: 5px;" onchange="RowsChange('FilterRecord');">
                                        <option value="10">10</option>
                                        <option value="25">25</option>
                                        <option value="50">50</option>
                                        <option value="75">75</option>
                                        <option value="100">100</option>
                                    </select>
                                </span><span style="float: left;">&nbsp;entries</span>
                            </div>
                            <div class="PageButtons">
                                <ul style="float: right; margin-right: 15px;">
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div id="divMessageDetail" style="display: none;">
                        <div id="divHeader">
                        </div>
                        <div id="divBody">
                        </div>
                    </div>
                </div>
                <div id="divPHRMessages" style="display: none">
                    <h2>Customer Messages</h2>
                    <div class="Grid" id="gridPatientMessages">
                        <div style="height: 350px; overflow: auto;">
                            <table>
                                <thead>
                                    <tr>
                                        <th style="width: 4%"></th>
                                        <th style="width: 2%;"></th>
                                        <th style="width: 9%">Patient Id</th>
                                        <th style="width: 14%">Patient</th>
                                        <th style="width: 14%">Priority</th>
                                        <th style="width: 21%">Subject</th>
                                        <th>Message</th>
                                        <th style="width: 7%;">Action</th>
                                    </tr>
                                    <tr>
                                        <th><span class="iconSearch"></span></th>
                                        <th></th>
                                        <th>
                                            <input type="text" class="txtPatientIdFilter" onkeypress="patientIdKeyPress()" /></th>
                                        <th>
                                            <input type="text" class="txtPatientNameFilter" onkeypress="FilterPatientMessages(0, true)" /></th>
                                        <th>
                                            <asp:DropDownList ID="ddlPriorityFilter" runat="server" onchange="FilterPatientMessages(0, true)">
                                                <asp:ListItem Selected="True" Value="" Text=""></asp:ListItem>
                                                <asp:ListItem Value="High" Text="High"></asp:ListItem>
                                                <asp:ListItem Value="Normal" Text="Normal"></asp:ListItem>
                                                <asp:ListItem Value="Low" Text="Low"></asp:ListItem>
                                            </asp:DropDownList>
                                        </th>
                                        <th>
                                            <input type="text" class="txtSubjectFilter" onkeypress="FilterPatientMessages(0, true)" /></th>
                                        <th></th>
                                        <th></th>
                                    </tr>
                                </thead>
                                <tbody id="listPatientMessages">
                                    <asp:Repeater ID="rptPatientMessages" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <%# Eval("RowNumber")%>
                                                </td>
                                                <td>
                                                    <span class='<%# Eval("ReadStatus")%>'></span>
                                                </td>
                                                <td>
                                                    <%# Eval("PatientId")%>
                                                </td>
                                                <td>
                                                    <%# Eval("PatientName")%>
                                                        
                                                </td>
                                                <td>
                                                    <%# Eval("Priority")%>
                                                </td>
                                                <td>
                                                    <%# Eval("SubjectEHR")%>
                                                        
                                                </td>
                                                <td>
                                                    <%# Eval("MessageEHR")%>
                                                    <input type="hidden" class="hndcontactMessageReply" value='<%# Eval("MessageReply")%>' />
                                                    <input type="hidden" class="hndcontactMessage" value='<%# Eval("Message")%>' />
                                                    <input type="hidden" class="hndcontactSubject" value='<%# Eval("Subject")%>' />
                                                    <input type="hidden" class="hndcontactPatientEmail" value='<%# Eval("PatientEmail")%>' />
                                                    <input type="hidden" class="hndPatientContactMessagesId" value='<%# Eval("PatientContactMessagesId")%>' />
                                                    <input type="hidden" class="hndPriority" value='<%# Eval("Priority")%>' />
                                                    <input type="hidden" class="hndPatientName" value='<%# Eval("PatientName")%>' />
                                                    <input type="hidden" class="hndPatientId" value='<%# Eval("PatientId")%>' />
                                                    <input type="hidden" class="hndPatientCity" value='<%# Eval("City")%>' />
                                                </td>
                                                <td class="action">
                                                    <span class="spnview" title="View Reply" onclick="viewMessage(this);"></span>
                                                    <span class="iconReply" title="Edit" onclick="ReplyContactMessage(this);"></span>
                                                    <span class="spndelete" title="Delete" onclick="deleteContactMessage(<%# Eval("PatientContactMessagesId")%>);"></span>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <asp:HiddenField ID="hdnPatientMessageTotalRows" runat="server" />
                                </tbody>
                            </table>
                        </div>
                        <div class="message">
                            <span class="iconInfo" style="margin: 7px;"></span><span class="spanInfo"></span>
                        </div>
                        <div class="pager">
                            <div class="PageEntries">
                                <span style="float: left; margin-left: 5px;">Show&nbsp;</span><span style="float: left;">
                                    <select id="ddlPagingPatientMessage" style="margin-top: 5px;" onchange="RowsChange('FilterPatientMessages');">
                                        <option value="10">10</option>
                                        <option value="25">25</option>
                                        <option value="50">50</option>
                                        <option value="75">75</option>
                                        <option value="100">100</option>
                                    </select>
                                </span><span style="float: left;">&nbsp;entries</span>
                            </div>
                            <div class="PageButtons">
                                <ul style="float: right; margin-right: 15px;"></ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <DG:MessageDialog runat="server" />
        <%--<div id="divComposeMessage" style="display: none;" title="New Message">
            <table cellpadding="0" cellspacing="0" style="width: 100%;">
                <tr>
                    <td style="width: 100px;">
                        <input type="button" value="To" id="btnTo" onclick="ShowUserList();" />
                        <div id="divUserSelection" class="divUsers">
                            <div class="Grid">
                                <table>
                                    <asp:Repeater runat="server" ID="rptUserList">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <label id='<%#Eval("UserId") %>'>
                                                        <asp:CheckBox runat="server" ID="chkSelectPatient" /><span><%#Eval("Name") %>
                                                            (<%#Eval("UserName") %>)</span></label>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <AlternatingItemTemplate>
                                            <tr class="alternatingRow">
                                                <td>
                                                    <label id='<%#Eval("UserId") %>'>
                                                        <asp:CheckBox runat="server" ID="chkSelectPatient" /><span><%#Eval("Name") %>
                                                            (<%#Eval("UserName") %>)</span></label>
                                                </td>
                                            </tr>
                                        </AlternatingItemTemplate>
                                    </asp:Repeater>
                                </table>
                                <div class="divBottom">
                                    <input type="button" onclick="PopulateUsers()" value="OK" />
                                    <input type="button" onclick="ResetUsers()" value="Cancel" style="margin-right: 5px;" />
                                </div>
                            </div>
                        </div>
                    </td>
                    <td style="width: 550px;">
                        <div class="tagsinput" id="divToUsers">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <input type="button" value="Cc" id="btnCc" onclick="ShowCcUsers()" />
                        <div id="divCcUserSelection" class="divUsers">
                            <div class="Grid">
                                <table>
                                    <asp:Repeater runat="server" ID="rptUserCcList">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <label id='<%#Eval("UserId") %>'>
                                                        <asp:CheckBox runat="server" ID="chkSelectPatient" /><span><%#Eval("Name") %>
                                                            (<%#Eval("UserName") %>)</span></label>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <AlternatingItemTemplate>
                                            <tr class="alternatingRow">
                                                <td>
                                                    <label id='<%#Eval("UserId") %>'>
                                                        <asp:CheckBox runat="server" ID="chkSelectPatient" /><span><%#Eval("Name") %>
                                                            (<%#Eval("UserName") %>)</span></label>
                                                </td>
                                            </tr>
                                        </AlternatingItemTemplate>
                                    </asp:Repeater>
                                </table>
                                <div class="divBottom">
                                    <input type="button" onclick="PopulateCcUsers()" value="OK" />
                                    <input type="button" onclick="ResetCcUsers()" value="Cancel" style="margin-right: 5px;" />
                                </div>
                            </div>
                        </div>
                    </td>
                    <td>
                        <div class="tagsinput" id="divCcUsers">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        Subject:
                    </td>
                    <td>
                        <input type="text" id="txtSubject" style="width: 97%;" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Priority:
                    </td>
                    <td>
                        <select id="ddPriority">
                            <option value="L">Low</option>
                            <option value="N" selected="selected">Normal</option>
                            <option value="H">High</option>
                        </select>
                    </td>
                </tr>
                <tr class="tr-upload-file-messages">
                    <td>
                    </td>
                    <td>
                        <div class="attachment-wrapper-messages">
                            <div id="divUploadMessages">
                                <input type="file" value="Upload" id="btnUploadMessageAttachments" size="1" />
                                <a href="javascript:void(0);" id="attach-link-messages">Attach file</a>
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <textarea id="elm1" name="mailContents" rows="15" cols="80" style="width: 100%; resize: none;"></textarea>
                    </td>
                </tr>
            </table>
        </div>--%>
        <div id="confirm_delete" style="display: none;" title="Delete Message">
            <p>
                Are you sure you want to delete this message?
            </p>
        </div>
        <div id="divCustomerMessageDetail" style="display: none; overflow: auto; line-height: 25px;">
            <table style="width: 100%" id="tblNewContact">
                <tr>
                    <td colspan="2" style="text-align: right; padding-right: 3%;">
                        <input type="button" value="Cancel" onclick="CancelViewMessage()" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 15%; font-weight: bold;">Name:
                    </td>
                    <td>
                        <asp:Label ID="lblPatientName" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 15%; font-weight: bold;">City:
                    </td>
                    <td>
                        <asp:Label ID="lblCity" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold;">Email:
                    </td>
                    <td>
                        <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold;">Priority:
                    </td>
                    <td>
                        <asp:Label ID="lblPriority" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold;">Subject:
                    </td>
                    <td>
                        <asp:Label ID="lblSubject" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold; vertical-align: top">Message:
                    </td>
                    <td>
                        <asp:Label ID="lblMessageDetail" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr class="trReply" style="display: none;">
                    <td style="font-weight: bold; vertical-align: top">Reply:
                    </td>
                    <td>
                        <asp:Label ID="lblMessageReply" runat="server" Text=""></asp:Label>
                    </td>
                </tr>

            </table>
        </div>
        <div id="divPatientReply" style="display: none">
            <table>
                <tr>
                    <td style="font-weight: bold; vertical-align: top">Reply:
                    </td>
                    <td>
                        <asp:TextBox ID="txtReply" TextMode="MultiLine" Style="resize: none; width: 95%" Rows="17" Columns="50" runat="server" CssClass="required"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: right; padding-right: 3%;">
                        <input type="button" value="Reply" onclick="replyPatient()" />
                        <input type="button" value="Cancel" onclick="CancelreplyPatient()" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
