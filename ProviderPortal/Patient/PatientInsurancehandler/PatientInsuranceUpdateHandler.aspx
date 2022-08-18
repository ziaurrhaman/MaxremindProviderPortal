<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PatientInsuranceUpdateHandler.aspx.cs" Inherits="ProviderPortal_Patient_PatientInsurancehandler_PatientInsuranceUpdateHandler" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   
    <title></title>
    
   <script src="../../Scripts/Rizwan/Demographics.js"></script> 
    <script type="text/javascript">
        function SubscriberChangeUpdate(elem) {
            debugger;
            var CurrentTable = $(elem).closest("table");
            var Relationship = $("[id$='ddRelationshipU']").val();
            if (Relationship == 'Self') {
                var fName = $("[id$=lblFirstName]").val();
                $("[id$='txtFirstName']").val(fName);
                var lName = $("[id$=lblLastName]").val();
                $("[id$='txtLastName']").val(lName);
                $(".iconSearchSmall").css("display", "none");
            }
            else {
                CurrentTable.find(".iconSearchSmall").show();

                $("[id$='txtFirstName']").val("");
                $("[id$='txtLastName']").val("");
            }
        }
      
    </script>

<style>

    #main{
  
        height:210px;
        background-color:white;
        width:100%;
       
       
    }
   .DropDown
   {
      width: 83%;
    height: 27px;
    border-radius: 3px;
   }
    .DropDownF
   {
      width: 83%;
    height: 27px;
    border-radius: 3px;
   }
   .TextBox
   {
width:78% !important;
 height: 14px;
  
    
   }
   .TextBoxS
   {
width:39% !important;
 height: 14px;
  
    
   }

   .Fbtn{
       margin:4px 2px 0 2px;
   }

   #ddinsubtn{
      background-image:url("../../Images/btnAdd.png") !important;
      height:25px; 
      min-width:22px;
      border-bottom: 1px solid white;
  }

</style>
      
<script>

    

</script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="main"> 
 <div id="InsuranceUpdate">
       
                    <%--  showing the drop down of insurance types --%>
                  <div id="Updateinsu_Type" style="margin-top:8px; height:40px;"> 
              
      <table>   


       
      <asp:HiddenField runat="server" ID="hdnInshuranecType"/>
             

        <tr>
           <td style="width:13%">
               <div style="font-size:16px; margin-left: 6px;">
            Insurance Type:
                   </div>
           </td>            
    <td style="width:1%"> 
        <div>
        <asp:DropDownList ID="UpdateddInsurance" style="width:203px;display:none"  CssClass="DropDown required clsUpdateddInsurance"  runat ="server" onchange="focusoutInsurance();">
            <asp:ListItem ></asp:ListItem>
            <asp:ListItem  Value="P">Primary</asp:ListItem>
              <asp:ListItem Value="S">Secondary</asp:ListItem>
           <asp:ListItem Value="O">Other</asp:ListItem>
              </asp:DropDownList>
            </div>
      <div>  <asp:label ID="InsurancesName" style="font-size:18px"   runat ="server"></asp:label></div>
     

 </td>
            <td>
                   <div><input type="button" id="ddinsubtn" /></div>
            </td>
        </tr>            

      </table>
            
          
     </div>
<%-- End drop down of insurance types  --%>   

        
         
    
        <div id="Info" style="margin-top:8px; background-color:aliceblue;">
            
<div id="G_Info" style="width: 32%;float:left; margin-left:18px;" >
<div style="border-bottom:1px solid silver; width:98%; margin-bottom:8px;" > General Information</div>
   
    <table>
        <tbody> 
        <tr>
<td> <div style="font-size:15px;" ><span>Name:</span> <span style="color:red;font-size:11px;">*</span> </div>

        </td>            
    <td > 
       <div style="margin-left:0"> <asp:DropDownList ID="ddNameU" style="" onchange="focusoutInsurance();"  CssClass="DropDown required" runat ="server"> </asp:DropDownList></div></td>
        </tr>
         <tr>
<td><div> <span style="font-size:15px;">Police No:</span> <span style="color:red;font-size:11px;">*</span> </div>

        </td>            
    <td > <div>
      <%--  <asp:TextBox ID="txtPoliceNoU " style=""  CssClass="" runat ="server">  </asp:TextBox>--%>
        <input type="text" class="TextBox required" id="txtPoliceNoU" runat="server" onblur=" focusoutInsurance();"/>

          </div></td>
        </tr>
               <tr>
<td><div> <span style="font-size:15px; ;">Group No:</span> </div> 

        </td>            
    <td > <div>
        <asp:TextBox ID="txtGroupNoU" style=""  CssClass="TextBox" runat ="server">  </asp:TextBox></div></td>
        </tr>
               <tr>
                   
<td> <div><span style="font-size:14px;"> Group Name:</span> </div>

        </td>            
    <td > 
         <div><asp:TextBox ID="txtGroupNameU" style=""  CssClass="TextBox" runat ="server">  </asp:TextBox></div></td>
        </tr>
             <tr>
<td> <div><span style="font-size:14px; ">Effective Date:</span> </div>

        </td>           
    <td > 
      <div> <asp:TextBox ID="txtEffectiveDateU" style=""  CssClass="TextBox" runat ="server">  </asp:TextBox></div>  </td>
        </tr>
       <tr>
<td>     <div> <span style="font-size:14px;">Termination Date:</span></div> 

        </td>            
    <td > 
       <div> <asp:TextBox ID="txtTerminationDateU" style=""  CssClass="TextBox" runat ="server">  </asp:TextBox></div>
       
       </td>
        </tr>
            </tbody>
    </table>
  
</div>


<div id="F_Info" style="margin-left:30px;  width: 32%;float:left;">
<div style="border-bottom:1px solid silver; width:98%; margin-bottom:8px" > Financial Information</div>
   <table>
        <tbody> 

             <tr>
<td> <span style="font-size:15px;">Copay:</span> 

        </td>            
    <td > 
        <asp:TextBox ID="txtCopayU" style=""  CssClass="TextBox" runat ="server" onkeypress="return ValidateNumber(event)">  </asp:TextBox></td>
        </tr>

        <tr >
<td> <span style="font-size:15px; ">Copay Type:</span> 

        </td>            
    <td > 
        <asp:DropDownList ID="ddCopayU" style=""  CssClass="DropDownF" runat ="server">
       <asp:ListItem > </asp:ListItem>
       <asp:ListItem  Value="Percentage">Percentage</asp:ListItem>
      <asp:ListItem Value="Amount">Amount</asp:ListItem>
     
        </asp:DropDownList></td>
        </tr>
        
               <tr>
<td> <span style="font-size:15px; ">Coinsurance:</span>

        </td>            
    <td > 
        <asp:TextBox ID="txtCoinsuranceU" style=""  CssClass="TextBox" runat ="server" onkeypress="return ValidateNumber(event)">  </asp:TextBox></td>
        </tr>
                <tr >
<td> <span style="font-size:15px; ">Coinsurance Type:</span> 

        </td>            
    <td > 
        <asp:DropDownList ID="ddCoinsuranceU" style=""  CssClass="DropDownF" runat ="server">
       <asp:ListItem > </asp:ListItem>
       <asp:ListItem  Value="Percentage">Percentage</asp:ListItem>
      <asp:ListItem Value="Amount">Amount</asp:ListItem>
     
        </asp:DropDownList></td>
        </tr>
             <tr>
<td> <span style="font-size:14px; ">Deductable:</span> 

        </td>            
    <td > 
        <asp:TextBox ID="txtDeductableU" style=""  CssClass="TextBox" runat ="server" onkeypress="return ValidateNumber(event)">  </asp:TextBox> </td>
        </tr>
              <tr >
<td> <span style="font-size:15px;">Deductable Type:</span> 

        </td>            
    <td > 
        <asp:DropDownList ID="ddDeductableU" style=""  CssClass="DropDownF" runat ="server">
        <asp:ListItem > </asp:ListItem>
       <asp:ListItem  Value="Percentage">Percentage</asp:ListItem>
      <asp:ListItem Value="Amount">Amount</asp:ListItem>
     
        </asp:DropDownList></td>
        </tr>
            </tbody>
    </table>
   
</div>

<div style="width: 28%;float:right;" id="S_Info" >

    <div style="border-bottom:1px solid silver; width:93%; margin-bottom:8px" > Subscriber</div>
   <table>
        <tbody> 
        <tr>
<td> <span style="font-size:15px; ">Relationship:</span>

        </td>            
    <td > <div style="margin-right: 200px !important;">

        <asp:DropDownList ID="ddRelationshipU" onchange="SubscriberChangeUpdate(this)"  style="height:27px;width:153px"   runat ="server">
        <asp:ListItem > </asp:ListItem>
       <asp:ListItem  Value="Self">Self</asp:ListItem>
      <asp:ListItem Value="Spouse">Spouse</asp:ListItem>
      <asp:ListItem Value="Children">Children</asp:ListItem>
      <asp:ListItem Value="Other">Other</asp:ListItem>
        </asp:DropDownList></div></td>
        </tr>
         <tr>
<td><div> <span style="font-size:15px; ">First Name:</span>  </div>

        </td>            
    <td > <div>
        <asp:TextBox ID="txtFirstName" style="" disabled="disabled"  CssClass="TextBoxS txtSubscriberLastName" runat ="server">  </asp:TextBox>
         <input type="hidden" runat="server" id="hdnPrimarySubscriberId" class="hdnSubscriberId" value="0" />
          <span class="iconSearchSmall" style="display: none; float: right; margin-right: 48%; cursor:pointer;" onclick="ClickSubscriberIcon(this);"></span>
          </div></td>
        </tr>
               <tr>
<td><div> <span style="font-size:15px;" >Last Name:</span></div>

        </td>            
    <td > 
        <div>
        <asp:TextBox ID="txtLastName" style="" disabled="disabled"  CssClass="TextBoxS txtSubscriberFirstName" runat ="server">  </asp:TextBox></div></td>
        </tr>
              
           
            </tbody>
    </table>
</div>
 
            
            
        </div>

   </div>      

</div>
    <%--<div style="height:40px; background-color:#439abf;  border-radius:4px; text-align:center;">
        
                <asp:Button Text="Save" runat="server" OnClick="Add_PatientInsurance" CssClass="Fbtn" />   
                <input type="reset" value="Cancel" class="themeButton Fbtn"/>
          
        </div>--%>
    </form>
</body>


</html>
