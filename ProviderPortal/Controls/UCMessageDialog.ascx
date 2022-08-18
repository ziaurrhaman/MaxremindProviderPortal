<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UCMessageDialog.ascx.cs" Inherits="EMR_Controls_UCMessageDialog" %>
<div id="divComposeMessage" style="display: none; margin-top:10px;" title="New Message">
        <table cellpadding="0" cellspacing="0" style="width: 100%;">
            <tr>
                <td style="width: 129px;">
                    <input type="button" value="To" id="btnTo" onclick="ShowUserList();" />
                    <div id="divUserSelection" class="divUsers">
                        <div class="Grid SelectionGrid" id="">
                            <div class="GridTableSelection" style="">
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
                            </div>
                        
                            <div class="divBottom">
                                <input type="button" onclick="PopulateMsgUsers()" value="OK" />
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
                        <div class="Grid SelectionGrid">
                              <div class="GridTableSelection" style="">
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
                              </div>
                        
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
                    External Email To:
                </td>
                <td>
                    <input type="text" id="txtExternalEmail" style="width: 95%;" placeholder="use , to sperate emails" />
                </td>
            </tr>
            <tr>
                <td>
                    External Email CC :
                </td>
                <td>
                    <input type="text" id="txtExternalCC" style="width: 95%;" placeholder="use , to sperate emails" />
                </td>
            </tr>
            <tr>
                <td>
                    Subject:
                </td>
                <td>
                    <input type="text" id="txtSubject" style="width: 95%;" />
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
    </div>