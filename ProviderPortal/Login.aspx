<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="EMR_Login" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="../../Scripts/jquery-1.9.0.js"></script>
   
   <link href="https://opensource.keycdn.com/fontawesome/4.7.0/font-awesome.min.css" rel="stylesheet">
     <title></title>

    <style type="text/css">
        body
        {
            font-family: Arial, Verdana,Sans-Serif, Helvatica !important;
            margin: 0px;
            padding: 0px;
            border: 0px;
            outline: 0px;
            vertical-align: baseline;
            background-color: #439abf;
            font-size: 12px;
            color: #444;
        }
       
        
        
        /*input[type="text"], input[type="password"], input[type="email"], textarea, select
        {
            outline: none;
            -moz-border-radius: 2px;
            -webkit-border-radius: 2px;
            -moz-border-radius: 2px;
            border-radius: 2px;
            font: 13px "HelveticaNeue" , "Helvetica Neue" , Helvetica, Arial, sans-serif;
            background: #fff;
            box-shadow: 0px 0px 0px 4px #f2f5f7;
            width: 244px;
            padding: 9px;
            color: #aeaeae;
            border: 1px solid #bec2c4;
        }
        
       input[type="text"]:focus, input[type="password"]:focus
        {
            -webkit-box-shadow: 0px 0px 4px rgba(0,0,0,0.3);
            -moz-box-shadow: 0px 0px 4px rgba(0,0,0,0.3);
            box-shadow: 0px 0px 4px rgba(0,0,0,0.3);
            border-color: #91B4DA;
        }*/
        
       /*input[type="submit"]
        {
            float: right;
            
            border-left: 1px solid #e6e6e6;
            border-right: 1px solid #e6e6e6;
            border-top: 1px solid #e6e6e6;
            border-bottom: 1px solid #a2a2a2;
            color: #53595F;
            border-radius: 3px;
            font-size: 12px;
            padding: 6px;
            cursor: pointer;
            width: 88px;
            font-weight: bold;
            margin-bottom: 0;
            background: rgb(255,255,255);
            background: -moz-linear-gradient(top, rgba(255, 255, 255, 1) 0%, rgba(246, 246, 246, 1) 47%, rgba(237, 237, 237, 1) 100%);
            background: -webkit-gradient(linear, left top, left bottom, color-stop(0%, rgba(255, 255, 255, 1)), color-stop(47%, rgba(246, 246, 246, 1)), color-stop(100%, rgba(237, 237, 237, 1)));
            background: -webkit-linear-gradient(top, rgba(255, 255, 255, 1) 0%, rgba(246, 246, 246, 1) 47%, rgba(237, 237, 237, 1) 100%);
            background: -o-linear-gradient(top, rgba(255, 255, 255, 1) 0%, rgba(246, 246, 246, 1) 47%, rgba(237, 237, 237, 1) 100%);
            background: -ms-linear-gradient(top, rgba(255, 255, 255, 1) 0%, rgba(246, 246, 246, 1) 47%, rgba(237, 237, 237, 1) 100%);
            background: linear-gradient(to bottom, rgba(255, 255, 255, 1) 0%, rgba(246, 246, 246, 1) 47%, rgba(237, 237, 237, 1) 100%);
            filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#ffffff', endColorstr='#ededed', GradientType=0 );
            text-align: center;
            text-shadow: 0 1px 1px rgba(255, 255, 255, 0.75);
            vertical-align: middle;
            background-color: #f5f5f5;
            background-repeat: repeat-x;
            -webkit-border-radius: 4px;
            -moz-border-radius: 4px;
            border-radius: 4px;
            -webkit-box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.2), 0 1px 2px rgba(0, 0, 0, 0.05);
            -moz-box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.2), 0 1px 2px rgba(0, 0, 0, 0.05);
            box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.2), 0 1px 2px rgba(0, 0, 0, 0.05);
            background-image: linear-gradient(to bottom, #ffffff, #e6e6e6);
        }*/
        
        
       /*input[type="submit"]:hover
        {
            -moz-box-shadow: 0 0 3px #91B4DA;
            -webkit-box-shadow: 0 0 3px #91B4DA;
            box-shadow: 0 0 3px #91B4DA;
        }            
        
        
        label
        {
            display: inline;
            vertical-align: middle;
        }
        
        label span
        {
            color: #555555;
            font-size: 12px;
        }
        
        /*Start Widget*/
        /*.Widget
        {
            float: left;
            background: #FFF;
            padding: 1px;
            border-radius: 5px;
            -webkit-border-radius: 5px;
            -o-border-radius: 5px;
            -moz-border-radius: 5px;
            box-shadow: 4px 5px 5px -1px lightgray;
            width: 100%;
        }
        .WidgetContent
        {
            float: left;
            width: 98%;
            padding: 1%;
        }
        .WidgetContent-side-bar
        {
            padding: 5px 3%;
            width: 94%;
            float: left;
        }
        .WidgetMainContent
        {
            background-color: #F2F2F2;
            padding: 10px 1%;
            width: 98%;
            float: left;
        }

        .WidgetTitle
        {
            background: url('../Images/theme/widget-title-bg.png') repeat-x;
            padding: 16px 0;
            font-size: 14px;
            border-top-left-radius: 5px;
            border-top-right-radius: 5px;
            height: 15px;
            color: #FFF;
        }
        .WidgetTitle span
        {
            float:left;
            padding: 0 0 0 50px;
            height: 33px;
            margin: -10px 0 0 10px;
        }
        .widget-services-icon
        {
            background: url('../Images/theme/services.png') no-repeat;
        }*/
         .container
        {
            
             
              width: 565px;
             
              z-index: 15;
              top: 50%;
              left: 50%;
              /*margin: -200px 0 0 -262px;*/
             margin:120px auto;
              height:380px;
             }
        .logo{
         background-image: url('../Images/logo_maxremind.png');
         width: 250px;
         height: 35px;
         float: left;
         background-repeat: no-repeat;
      
        }

        .div_logo{
            height: 50px;
            padding: 20px 0 0 85px;
            box-sizing: border-box;
            margin-top:23px;
        }

        .div_logo_title
        {
                height: 30px;
                padding-left: 104px;
                padding-top: 4px;
                box-sizing: border-box;
        }
        .div_logo_title  .title
        {
            font-size: 18px;
        }
        .align{
            text-align:center;

        }
        .input_text
        {
                width: 74%;
                border-top: none;
                border-left: none;
                border-right: none;
                border-bottom: #d2d9e0 2px solid;
                height: 33px;
                padding:5px;
                /*background-color: #eeeff0 !important;*/
        }
        input:focus{
            /*background-color:red !important;*/
               border-top: none !important;
                border-left: none !important;
                border-right: none !important;
                border-bottom: slategray 1px solid !important;
                outline:none !important;
        }

                 input:-webkit-autofill,
            input:-webkit-autofill:hover,
            input:-webkit-autofill:focus,
            input:-webkit-autofill:active {
            transition: background-color 50000s ease-in-out 0s, color 5000s ease-in-out 0s;
            }
        /*#txtUserName
            {
           

            }*/
        #txtpas{
            background: url('../Images/icon-sprite_regular(16x16).png') -25px -525px  ;
            padding-right: 17px;
            position: relative;
                    z-index: 1;
    left: -25px;
    top: 1px;
    color: #7B7B7B;
    cursor: pointer;
    width: 0;
        }
          #txtpas1{
            background: url('../Images/icon-sprite_regular(16x16).png')-25px -550px  ;
            padding-right: 17px;
            position: relative;
            z-index: 1;
        left: -25px;
                top: 1px;
                color: #7B7B7B;
                cursor: pointer;
                width: 0;        
        }
          #txtbtn{
              background: url('../Images/icon-sprite_regular(16x16).png')-25px -500px  ;
            padding-right: 17px;
            position: relative;
            z-index: 1;
            left: -25px;
                top: 1px;
                color: #7B7B7B;
                
                width: 0;    

          }
          .div_left{
            width: 60%;
              height: 380px;
              float: left;
           background-color: white;      
              }

             .div_right{
            width: 40%;
              height: 380px;
              float: right;
           background-color: #dadbdc;
        padding-left:10px;
        padding-right:10px;
        box-sizing:border-box;
       
              }
             #btnLogin{

                     width: 75%;
                    height: 40px;
                    border: none;
                    background-color: #15688f;
                    color: white;
                    border-radius: 3px;
                    font-size: 16px;
                    box-sizing:border-box;
                    cursor:pointer;
             }
             .content_hippa{
                 padding-left: 0px;
                 height: 100%;
                 line-height: 1.5;
                 font-size: 14px;
             }
   label input {
       /* <-- hide the default checkbox, the rest is to hide and alllow tabbing, which display:none prevents */
  /*visibility: hidden;
  display:block;
  height:0;
  width:0;
  position:absolute;
     
  overflow:hidden;*/
  display:none;
}
label span {/* <-- style the artificial checkbox */
  height: 12px;
  width: 12px;
  border: 2px solid #15688f;
  display: inline-block;
  position: relative;
}
[type=checkbox]:checked + span:before {/* <-- style its checked state..with a ticked icon */
  content: '\2714';
  position: absolute;
  top: -5px;
  left: 0;
}
.alert-danger {
            margin-top: 10px;
            width: 100%;
            float: left;
            text-align: center;
            color: #a94442;
            background-color: #f2dede;
            border: 1px solid #ebccd1;
            border-radius: 3px;
            height: 30px;
        }
.InValidCharacter{
             padding: 8px 0px 0px 112px;
             float: left;
     }
    </style>

    <script>
       

        $(document).ready(function () {
        
            $('#txtUserName').keypress(function (e) {
                var regex = new RegExp("^[A-Za-z0-9@#$_]+$");
                var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
                if (regex.test(str)) {
                    return true;
                }

                e.preventDefault();
                $(".alert-danger").show();
                setTimeout(function () {
                    $(".alert-danger").fadeOut(1500);
                }, 3000);
                return false;
            });
            $('#txtPassword').keypress(function (e) {
                var regex = new RegExp("^[A-Za-z0-9@#$_]+$");
                var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
                if (regex.test(str)) {
                    return true;
                }
                var a = event.which || event.keyCode;
                if (a == 13) {
                    return true;
                }

                e.preventDefault();
                $(".alert-danger").show();
                setTimeout(function () {
                    $(".alert-danger").fadeOut(1500);
                }, 3000);
                return false;
            });
        });
      
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="container">
             <div style="width: 328px; margin: 0 auto 5px;">
                <asp:Label runat="server" ID="lblModulesWarning" Text="" Visible="false" ForeColor="Red"></asp:Label>
            </div>

         
           <div class="div_left">
                                  <div class="header" style="width:100%; height:123px;">
                <div class="div_logo">
                      <span class="logo"></span>
                </div>
              <div class="div_logo_title">
                    <span class="title">Provider Portal</span>
              </div>
              
            </div>

            <div class="content">
                <table style="width:100%; height:182px">
                    <tbody>
                        <tr class="align">
                           <td><asp:TextBox runat="server" placeholder="Username" ID="txtUserName" CssClass="input_text required"></asp:TextBox>
                                 <span id="txtpas1"></span>
                             <br/>  <asp:RequiredFieldValidator style="font-size:10px;color:red" runat="server" ID="RFVUserName" ControlToValidate="txtUserName" ErrorMessage="Please enter username!"/>
                           </td> 
                        </tr>
                        <tr class="align">
                           <td> <asp:TextBox runat="server"  placeholder="Password" ID="txtPassword" TextMode="Password" CssClass="input_text required">  </asp:TextBox>
                             <span id="txtpas"></span>
                            <br/>  <asp:RequiredFieldValidator style="font-size:10px;color:red" runat="server" ID="RFVPass" ControlToValidate="txtPassword" ErrorMessage="Please enter Password!"/>   
                               
                           </td> 
                        </tr>
                        <tr >
                            <td style="padding-left: 32px;">
                                <div style="   float: left; padding-left: 4px;">
                                         <label for="remember">
                                    <input type="checkbox" id="remember" value="remember" class="chk" />
                                    <span ></span>
                                 
                                </label>
                                </div>
                                  
                             
                             <div style="float: right; margin-right: 90px; padding-top: 2px;">
                                     <span style="font-size:13px">Remember me on this computer</span>
                             </div>

                            </td>
                            
                        </tr>
                        <tr>
                            <td  style="padding-left: 62px;">
                                <asp:Label runat="server" ID="lblErrorMessage" style="color:Red;"></asp:Label>
                            </td>
                        </tr>
                        <tr class="align">
                            <td>
                              <%-- <input type="button" class="button" onclick="chkRequiredFields()" value="Login">--%>
                                <asp:Button runat="server" ID="btnLogin"  OnClick="btnLogin_Click" Text="Login" class="button" />
                                   <span id="txtbtn"></span>
                            </td>
                        </tr>
                    </tbody>
                </table>
  
 
                   
               
                    
            </div>
           </div>
         <div class="div_right">
             <div style="margin-top:73px">
                 <span style="font-size:18px"> <span style="border-bottom: 1px solid; border-bottom-color: #15688f;">HIPAA</span> Protected! </span>
             </div>
             <div style="margin-top: 20px;height: 200px;">
                 <span class="content_Hippa">
                     This system and all its components and contents (collectively, the "System") are intended for authorized business use only. 
                     All data within is considered confidential and proprietary. Unauthorized access, use, modification, destruction, 
                     disclosure or copy of this system is prohibited and will result in prosecution.
                 </span>
             </div>
         </div>

          <%--Alert Area--%>
                <div class="alert alert-danger" runat="server" id="alertdanger" style="display:none;">
                  <strong class="InValidCharacter">Special characters is not allowed (e.g & , ( " } % ? | ] )</strong> 
                </div>
          <%--Alert Area--%>   
        </div>
    </div>
    </form>
</body>
</html>
