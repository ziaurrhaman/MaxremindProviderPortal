<%@ Page Title="" Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master" AutoEventWireup="true" CodeFile="SendMessage.aspx.cs" Inherits="ProviderPortal_CustomerSupport_SendMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
     <link type="text/css" href="css/Support.css" rel="stylesheet" />
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    ###StartModel###
     <script src='https://www.google.com/recaptcha/api.js'></script>
     <script src="https://www.google.com/recaptcha/api.js?onload=renderRecaptcha&render=explicit" async defer></script>
     <script type="text/javascript" src="js/bootstrap.min.js"></script>
     <script src="../../Scripts/jquery.maskedinput.js"></script>
    <script type="text/javascript" src="js/SendMessage.js"></script>
 <div class="divmainMessageArea">
    <div class="col-md-3"></div>
     <div class="col-md-12">
          <span onclick="closeEmbedOpenmainPage()" id="mainpagecross"  style="float: right;color: black;font-size: 11px;margin-right: -11px;cursor:pointer;">
                   <i class="fa fa-window-close" aria-hidden="true"></i>
                     </span>
              <div class="divSendMessage">
                  <div class="col-md-12 ContactUs px-0">
                    <div class="CU">
                        <h5>Email Us </h5>
                    </div>
                  </div>
                  <div class="col-md-12" style="display:none;">
                    <div class="form-group">
                      <strong class="LeaveMessage">Leave Message</strong>
                    </div>
                  </div>
                  <div class="col-md-6">
                      <div class="form-group">
                          <strong class="lblName"> Your Name</strong>
                          <input type="text" id="txtUserName" placeholder="Enter Your Name"/>
                      </div>
                  </div>
                   <div class="col-md-6">
                      <div class="form-group">
                          <strong class="lblName">Email*</strong>
                          <input type="email" id="txtEmail" placeholder="Enter Email"/>
                      </div>
                  </div>
                  <div class="col-md-6">
                      <div class="form-group">
                          <strong class="lblName">Phone No.*</strong>
                         <input type="text" id="txtPhoneNumber" placeholder="Phone Number"/></div>
                  </div>
                   <div class="col-md-6">
                      <div class="form-group">
                          <strong class="lblName">Subject*</strong>
                          <input type="text" id="txtSubject" placeholder="Enter Subject"/>
                      </div>
                  </div>
                  <div class="col-md-12">
                      <div class="form-group">
                         <textarea cols="3" rows="5" id="txtMessage" style="width:96% !important;" placeholder="Enter Message"></textarea>
                      </div>
                  </div>
                  <div class="col-md-12">
                          <div class="col-md-2" style="text-align:left">
                            <div class="form-group">
                                <strong class="lblName">Attach Files</strong>
                            </div>
                          </div>
                 <div class="col-md-4" style="text-align:left">
                       <div class="form-group">
                            <span class="float-left" title="Attach Files"><a id="linkUploadFiles" class="iconAttachment"></a></span>
                            <div class="attachmentlist div-drop-down clear-l" style="height:auto;width:100%;float:left;">
                            <table>
                                <tbody class="SendMessageList">
                                </tbody>
                            </table>
                            </div>
                      </div>
                  </div>
                  <div class="col-md-12" style="display:none;">
                    <div class="form-group">
                      <div class="recaptcha-wrapper">
                          <div id="ReCaptchContainer" class="g-recaptcha" data-type="image" data-sitekey="6LdmfJsUAAAAAN7s28HQBYUNK6L1QBqyeCEIYFWw"></div>
                          <label class="recaptcha-label" id="CapchaMessage"></label>
                         <%-- <p class="recaptcha-label">@ViewBag.CapchaMessage</p>--%>
                     </div>
                    </div>
                  </div>
                  <div class="col-md-12">
                    <div class="form-group SendMessage">
                       <%--<asp:Button runat="server" ID="btnSendMessage" OnClick="btnSendMessager_Click" Text="Send Message" class="button btnSendMessage"/>--%>
                        <input type="button" id="btnSendMessage" value="Send Email" onclick="SendMessage()"/>
                    </div>
                  </div>
              </div>
          </div>        
           <div class="col-md-3"></div>
        </div>
     <div class="col-md-12">
            <div class="container">
                <div class="divShowMessage" style="display:none">
                    <div class="alert alert-success">
                      <strong>Your Email has been send successfully. We will contact you as soon as possible.</strong>
                    </div>
                </div>
           </div>
        </div>
     <div class="col-md-3"></div>   
     <div class="col-md-6">
            <div class="containers">
                <div class="divErrorShowMessage" style="display:none">
                    <div class="alert alert-danger">
                      <strong>Almost done! please verify that you are human.</strong>
                    </div>
                </div>
           </div>
        </div>
     <div class="col-md-3"></div> 
     <div style="display:none">
        ###Start###
          <asp:Literal ID="ltrerrorMessage" runat="server"></asp:Literal>
        ###End###
    </div> 
  </div> 
###EndModel###
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

