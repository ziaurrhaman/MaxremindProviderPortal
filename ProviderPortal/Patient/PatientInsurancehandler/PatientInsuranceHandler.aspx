<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PatientInsuranceHandler.aspx.cs" Inherits="ProviderPortal_Patient_PatientInsurancehandler_PatientInsuranceHandler" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   
    <title></title>
      <script src="../../Scripts/Rizwan/Demographics.js"></script> 
    


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

   

</style>
      
<script>
 
   

</script>
</head>
<body>
    <form id="form1" runat="server">
            <asp:HiddenField runat="server" ID="hdnInshuranecType"/>
<%--<asp:Label runat="server" ID="label"></asp:Label>--%>
    <div id="main "> 
        <div id="InsuranceUpdate">
          
    
              
      <%--  showing the drop down of insurance types --%>
                  <div id="Updateinsu_Type" style="margin-top:8px; height:40px;"> 
              
      <table>   


       
      <asp:HiddenField runat="server" ID="HiddenField1"/>
             

        <tr>
           <td style="font-size:16px; width: 15%;">
            Insurance Type:
           </td>            
    <td> 
        <asp:DropDownList ID="UpdateddInsurance" style=" width:160px;display:block"  CssClass="DropDown"  runat ="server" onchange="focusoutInsurance();">
             <asp:ListItem Value="Select"> Select </asp:ListItem>
             <asp:ListItem  Value="P">Primary</asp:ListItem>
              <asp:ListItem Value="S">Secondary</asp:ListItem>
           <asp:ListItem Value="o">Other</asp:ListItem>
              </asp:DropDownList>
 </td>
        </tr>            

      </table>
            
          
     </div>
<%-- End drop down of insurance types  --%>   

        
         
    
        <div id="Info" style="margin-top:8px; width:100%;float:left">
            
<div id="G_Info" style="width: 32%;float:left; margin-left:18px;" >
<div style="border-bottom:1px solid silver; width:98%; margin-bottom:8px;" > General Information</div>
   
    <table>
        <tbody> 
        <tr>
<td> <div style="font-size:15px;" ><span>Name:</span> <span style="color:red;font-size:11px;">*</span> </div>

        </td>            
    <td > 
       <div style="margin-left:0"> <asp:DropDownList ID="ddName" style="" onchange="focusoutInsurance();"  CssClass="DropDown required" runat ="server"> </asp:DropDownList></div></td>
        </tr>
         <tr>
<td><div> <span style="font-size:15px;">Police No:</span> <span style="color:red;font-size:11px;">*</span> </div>

        </td>            
    <td > <div>
        <%--<asp:TextBox ID="txtPoliceNo" style=""  CssClass="TextBox required" runat ="server">  </asp:TextBox>--%>
        <input type="text" class="TextBox required" id="txtPoliceNo" runat="server" onblur="focusoutInsurance();" />
          </div></td>
        </tr>
               <tr>
<td><div> <span style="font-size:15px; ;">Group No:</span> </div> 

        </td>            
    <td > <div>
        <asp:TextBox ID="txtGroupNo" style=""  CssClass="TextBox" runat ="server">  </asp:TextBox></div></td>
        </tr>
               <tr>
                   
<td> <div><span style="font-size:14px;"> Group Name:</span> </div>

        </td>            
    <td > 
         <div><asp:TextBox ID="txtGroupName" style=""  CssClass="TextBox" runat ="server">  </asp:TextBox></div></td>
        </tr>
             <tr>
<td> <div><span style="font-size:14px; ">Effective Date:</span> </div>

        </td>           
    <td > 
      <div> <asp:TextBox ID="txtEffectiveDate" style=""  CssClass="TextBox" runat ="server">  </asp:TextBox></div>  </td>
        </tr>
       <tr>
<td>     <div> <span style="font-size:14px;">Termination Date:</span></div> 

        </td>            
    <td > 
       <div> <asp:TextBox ID="txtTerminationDate" style=""  CssClass="TextBox" runat ="server">  </asp:TextBox></div>
       
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
        <asp:TextBox ID="txtCopay" style=""  CssClass="TextBox" runat ="server" onkeypress="return ValidateNumber(event)">  </asp:TextBox></td>
        </tr>

        <tr >
<td> <span style="font-size:15px; ">Copay Type:</span> 

        </td>            
    <td > 
        <asp:DropDownList ID="ddCopay" style=""  CssClass="DropDownF" runat ="server">
       <asp:ListItem > </asp:ListItem>
       <asp:ListItem  Value="Percentage">Percentage</asp:ListItem>
      <asp:ListItem Value="Amount">Amount</asp:ListItem>
     
        </asp:DropDownList></td>
        </tr>
        
               <tr>
<td> <span style="font-size:15px; ">Coinsurance:</span>

        </td>            
    <td > 
        <asp:TextBox ID="txtCoinsurance" style=""  CssClass="TextBox" runat ="server" onkeypress="return ValidateNumber(event)">  </asp:TextBox></td>
        </tr>
                <tr >
<td> <span style="font-size:15px; ">Coinsurance Type:</span> 

        </td>            
    <td > 
        <asp:DropDownList ID="ddCoinsurance" style=""  CssClass="DropDownF" runat ="server">
       <asp:ListItem > </asp:ListItem>
       <asp:ListItem  Value="Percentage">Percentage</asp:ListItem>
      <asp:ListItem Value="Amount">Amount</asp:ListItem>
     
        </asp:DropDownList></td>
        </tr>
             <tr>
<td> <span style="font-size:14px; ">Deductable:</span> 

        </td>            
    <td > 
        <asp:TextBox ID="txtDeductable" style=""  CssClass="TextBox" runat ="server" onkeypress="return ValidateNumber(event)">  </asp:TextBox> </td>
        </tr>
              <tr >
<td> <span style="font-size:15px;">Deductable Type:</span> 

        </td>            
    <td > 
        <asp:DropDownList ID="ddDeductable" style=""  CssClass="DropDownF" runat ="server">
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

        <asp:DropDownList ID="ddRelationship" style="height:27px;width:153px" onchange="SubscriberChange(this)"  runat ="server">
        <%--<asp:ListItem > </asp:ListItem>--%>
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
    
    </form>
   
</body>


</html>
