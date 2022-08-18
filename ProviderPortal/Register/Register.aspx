<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="ProviderPortal_Register_Register" EnableEventValidation="true"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../StyleSheets/Common.css" rel="stylesheet"  type="text/css"/>
    <link rel="stylesheet" href="css/Register.css"/>
    
    
    
    <script src='<%= ResolveUrl("~/Scripts/jquery-1.9.0.js") %>' type="text/javascript"></script>
    
      
    <title>Register</title>
</head>

<body>
    <form runat="server">
        <input type="hidden" value="false" id="AlredyExistUsername" />
        <input type="hidden" value="False" id="lNPI" />
    <div class="container">
        <div id="form-panel" style="margin: 0 auto 5px;">
            <div class="resgistration-form">
                <div class="resgistration-form-header">
                    <div class="sign-up-logo"></div>
                   <%-- <h3 class="sign-up-header-text">Provider Portal</h3>--%>
                </div>
                <div class="resgistration-form-body">
                    <form action="/" id="formal" method="post">
                        <div class="registration-form-control-group required-input" >
                            <input type="text"  placeholder="First Name*" id="FirstName" name="FirstName" />
                            <span class="user-back icon"></span>
                        </div>
                        <div class="registration-form-control-group required-input">
                            <input type="text" placeholder="Last Name*" id="LastName" name="LastName" />
                            <span class="user-back icon"></span>
                        </div>
                      <!--  <div class="registration-form-control-group required-input">
                            <input type="text" placeholder="UserName*" id="UserName" name="LastName" />
                            <span class="user-back icon"></span>
                        </div>-->
                        <div class="registration-form-control-group required-input">
                            <input type="email"  placeholder="Email*" id="Email" name="Email" />
                            <span class="email-back icon"></span>
                        </div>
                      <!-- <div class="registration-form-control-group required-input">
                            <input type="password"  placeholder="Password*" id="Password" name="Password" />
                            <span class="password-back icon"></span>
                        </div>
                        <div class="registration-form-control-group required-input">
                            <input type="password"  placeholder="confirm Password*" id="C_Password" name="C_Password"  />
                            <span class="c-password-back icon"></span>
                        </div>            -->                       
                        <div class="registration-form-control-group required-input">
                            <input type="text"  placeholder="NPI*" id="NPI" name="ProviderNPI"  maxlength="10" onchange="ChkValidNPI(this)" />
                            <span class="npi-back icon"></span>
                        </div>
                        <button id="Register" value="Register Now">Sign Up </button>
                    </form>
                    <div class="AlreadyExixtAccount">
                        <span>Already have account</span>&nbsp;<a href="/ProviderPortal/Login.aspx">sign In</a>
                    </div>
                </div>
            </div>
            <div class="text-panel">
             <div class="text-panel-header">
                 <span> <span class="text-important">HIPAA</span> Protected! </span>
             </div>
             <div class="text-panel-body">
                 <span class="text-panel-text">
                     This system and all its components and contents (collectively, the "System") are intended for authorized business use only. 
                     All data within is considered confidential and proprietary. Unauthorized access, use, modification, destruction, 
                     disclosure or copy of this system is prohibited and will result in prosecution.
                 </span>
             </div>
            </div>
            <div class="clear-fix"></div>
        </div>
        <div id="message_panel" class="message_panel">
            <div class="message-card">
                <h2 class="message">You have successfully registered.<br/> Please check your email for credentials.</h2>
                <a href="/providerportal/login.aspx">Go to Login page</a>
            </div>
        </div>
        <div id="error-block" class="error-block">
        </div>
    </div>
        <div class="ui-widget-overlay ui-front" style="display: none;" id="divOverlay"></div>
        <div id="divLoading" style="display:none;">
            <img src='<%= ResolveUrl("~/Images/spinner.gif") %>'>
        </div>
        </form>
    
    <%--<script src="../../Scripts/jquery-1.9.0.js"></script>--%>
    <script src="js/Register.js"></script>
      <%--<script src="../../Scripts/Common.js"></script>--%>
</body>
</html>
