<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserDetail.aspx.cs" MasterPageFile="~/ProviderPortal/BillingMaster.master" Inherits="ProviderPortal_Register_Details_UserDetail" %>

<asp:Content ContentPlaceHolderID="head" ID="Content1" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="css/UserDetail.css" />
    <div class="container">
        <asp:Label ID="check" Text="" runat="server" />
        <div class="tab-panel-container">
            <input type="hidden" runat="server" value="" ClientIDMode="Static" id="Image_Retained_Name" />
            <asp:Label ID="ID" CssClass="display-none" ClientIDMode="Static" Text="-1" runat="server" />
            <asp:Label ID="Image_Path" CssClass="display-none" ClientIDMode="Static" runat ="server" />
            <!-- <ul class="tabs">
                <li class="tab">
                   <a href="#" id="Detail" class="tab-link active-panel">Detail Information</a>
                </li>
            </ul>-->
            <div class="main-tab-pane">
                <!-- Header -->
                <div class="main-tab-header">
                    <h3 class="heading">My Profile</h3>
                    <div class="progress-bar-container">
                        <div class="progress"></div>
                        <div class="left"><span>25% Complete</span></div>
                    </div>
                </div>
               

                                            <!-- Indicators -->
            <!--    <ul class="indicators">

                    <li class="indicator-item">
                        <a href="#" id="1" target-tab="tab_1" class="indicator-link active-indicator">
                        </a>
                    </li>

                     <li class="indicator-item">
                        <a href="#" id="2" target-tab="tab_2" class="indicator-link">
                        </a>
                    </li>
                    <li class="indicator-item">
                        <a href="#" id="3" target-tab="tab_3" class="indicator-link">
                        </a>
                    </li>

                </ul>
                          -->
              <!--  <div class="detail-dropdown">
                    <a id="password-toggle">Reset Password</a>
                    <div class="detail-dropdown-panel hide">
                        <label>Old Password</label>
                        <input type="password" id="OldPassword" />
                        <small class="text-danger error-msg">Password not match with old password</small>
                        <label>New Password</label>
                        <input type="password" id="NewPassword" />
                        <button id="reset-password">Reset</button>
                        <div class="clear-fix"></div>
                    </div>
                </div> -->

                <div class="detail-dropdown">
                    <a id="password-toggle">Reset Password</a>
                </div>

                <div class="password-modal-back hide">
                    <div class="password-modal-container">
                        <div class="password-modal hide">
                            <div class="password-modal-header">
                                <h4>Change Password</h4><span class="close-modal">X</span>
                            </div>
                        <div class="password-modal-body">
                         <label>Old Password</label>
                        <input type="password" id="OldPassword" />
                        <small class="text-danger error-msg">Password not match with old password</small>
                        <label>New Password</label>
                        <input type="password" id="NewPassword" />    
                        <button class="close-modal" id ="close-modal">Close</button>
                        <button id="reset-password">Reset</button>
                        <div class="clear-fix"></div>
                        </div>

                        </div>
                    </div>
                </div>

                <!-- Body -->
                <ul class="tab-panel">
                    <!-- Panel 1 -->
                    <li id="tab_1" class="pane hide show">
                        <div class="tab-row">
                            <div class="tab-col-4 padding-top">
                                <figure class="img-box">
                                    <img id="User_image_Box" src="/PracticeDocuments/1000/Users/" runat="server" class="User_image_Box"/>
                                </figure>
                                <div class="center relative">
                                    <button class="btn-primary">Upload Photo</button>
                                    <input type="file" id="User_Image" class="file-btn" />
                                </div>
                            </div>


                            <div class="vertical-line border-right"></div>


                            <div class="tab-col-8"> 
                                <div class="input-row margin-bottom">
                                    <div class="col-6 input-margin-right">
                                        <label><h3 class="margin-bottom-5px">First Name</h3></label>
                                        <asp:TextBox ClientIDMode="Static" ID ="First_Name" CssClass="required NameField Name" runat="server"/>
                                    </div>
                                    <div class="col-6">
                                        <label><h3 class="margin-bottom-5px">Last Name</h3></label>
                                        <asp:TextBox ClientIDMode="Static" ID ="Last_Name" CssClass="required NameField Name" runat="server"/>
                                    </div>
                                </div>
                                <div class="input-row margin-bottom">
                                    <div class="col-6 input-margin-right">
                                        <label><h3 class="margin-bottom-5px">Email</h3></label>
                                        <asp:TextBox ClientIDMode="Static" ID ="Email" CssClass="required useremail" runat="server"/>
                                    </div>
                                    <div class="col-6">
                                        <label><h3 class="margin-bottom-5px">Practice Name</h3></label>
                                        <asp:TextBox ClientIDMode="Static" ID ="Practice_Name" CssClass="PracticeName" runat="server"/>
                                    </div>
                                </div>
                                <div class="input-row margin-bottom">
                                    <div class="col-6 input-margin-right">
                                        <label><h3 class="margin-bottom-5px">TaxID</h3></label>
                                        <asp:TextBox ClientIDMode="Static"  ID ="TaxID" CssClass="Name" runat="server" />
                                    </div>
                                    <div class="col-6">
                                        <label><h3 class="margin-bottom-5px">GroupNPI</h3></label>
                                        <asp:TextBox ClientIDMode="Static" ID ="GroupNPI" CssClass="Name" runat="server"/>
                                    </div>
                                </div>
                                <div class="input-row margin-bottom">
                                    <div class="col-6 input-margin-right">
                                       <label><h3 class="margin-bottom-5px">Provider NPI</h3></label>
                                    <asp:TextBox ClientIDMode="Static" ID="_Provider_NPI" CssClass="required Name" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="navigation">
                             <button  id="Save" class="btn-primary right" >Update</button>
                          <!--  <button target-tab="tab_2" next="2" class="btn-primary right nav">Next</button> -->
                            <div class="clear-fix"></div>
                        </div> 
                    </li>
                     <!-- Panel 1 -->

                     <!-- Panel 2 -->
              <!--      <li id="tab_2" class="pane hide">

                           <div class="input-row margin-bottom">
                               <div class="col-4 input-margin-right-2">
                                   <label><h3 class="margin-bottom-5px">Medical Provider</h3></label>
                                   <asp:TextBox ClientIDMode="Static" ID ="Medical_Provider" CssClass="required Name" runat="server"/>
                               </div>
                                <div class="col-4 input-margin-right-2">
                                   <label><h3 class="margin-bottom-5px">Servicing Provider Name</h3></label>
                                    <asp:TextBox ClientIDMode="Static" ID="Servicing_Provider_Name" CssClass="required Name" runat="server"/>
                               </div>
                                <div class="col-4">
                                   <label><h3 class="margin-bottom-5px">Provider NPI</h3></label>
                                    <asp:TextBox ClientIDMode="Static" ID="Provider_NPI" CssClass="required Name" runat="server" />
                               </div>
                           </div>

                       <div class="input-row margin-bottom">
                               <div class="col-4 input-margin-right-2">
                                   <label><h3 class="margin-bottom-5px">Provider Taxonomy Code</h3></label>
                                   <asp:TextBox ClientIDMode="Static" ID="PT_Code" CssClass="required Name" runat="server"/>
                               </div>
                                <div class="col-4 input-margin-right-2">
                                   <label><h3 class="margin-bottom-5px">Stat Licence Number</h3></label>
                                    <asp:TextBox ClientIDMode="Static" ID ="Stat_License_Number" CssClass="required Name" runat="server"/>
                               </div>
                                <div class="col-4">
                                   <label><h3 class="margin-bottom-5px">Medical Group</h3></label>
                                    <asp:TextBox ClientIDMode="Static" ID ="Medical_Group" CssClass="required Name" runat="server"/>
                               </div>
                           </div>

                        <div class="input-row margin-bottom">
                               <div class="col-4 input-margin-right-2">
                                   <label><h3 class="margin-bottom-5px">Group NPI Medicare Group PTANN</h3></label>
                                   <asp:TextBox ClientIDMode="Static" ID ="Group_NPI_Medicare_Group_PTAN" CssClass="Name" runat="server"/>
                               </div>
                                <div class="col-4 input-margin-right-2">
                                   <label><h3 class="margin-bottom-5px">Medicare Provider PTANN</h3></label>
                                    <asp:TextBox ClientIDMode="Static" ID="Medicare_Provider_PTAN" CssClass="Name" runat="server"/>
                               </div>
                           </div>
                       
                        <div class="navigation">
                            <button target-tab="tab_3" next="3" class="btn-primary right nav">Next</button>
                            <button target-tab="tab_1" next="1" class="btn-primary margin-right-5 right nav">Back</button>
                            <div class="clear-fix"></div>
                        </div>
                        
                         
                    </li>-->
                     <!-- Panel 2 -->

                     <!-- Panel 3 -->
              <!--      <li id="tab_3" class="pane hide">
                        <div class="input-row margin-bottom">
                            <div class="col-6 input-margin-right">
                                <label><h3 class="margin-bottom-5px">Physical Address</h3></label>
                                <asp:TextBox ClientIDMode="Static" ID="Physical_Address" runat="server" CssClass="textarea-additional required" cols="60" rows="5" TextMode="MultiLine"/>
                            </div>
                            <div class="col-6">
                                <label><h3 class="margin-bottom-5px">Mailing Address</h3></label>
                                <asp:TextBox ClientIDMode="Static" ID="Mailing_Address" runat="server" CssClass="textarea-additional required" cols="60" rows="5" TextMode="MultiLine"/>
                            </div>
                        </div>

                        <h3 class="margin-bottom-5px">Contact Details<span class="text-muted">(For Billing/Enrollment Quest)</span></h3>
                        <hr class="horizontal-line" />

                        <div class="input-row">
                            <div class="col-4 input-margin-right-2">
                                <label><h3 class="margin-bottom-5px">Name</h3></label>
                                <asp:TextBox ClientIDMode="Static" ID="Name" runat="server" ReadOnly="true" CssClass="required"/>
                            </div>
                            <div class="col-4 input-margin-right-2">
                                <label><h3 class="margin-bottom-5px">Phone</h3></label>
                                <asp:TextBox ClientIDMode="Static" ID="Phone" runat="server" CssClass="required"/>
                            </div>
                            <div class="col-4">
                                <label><h3 class="margin-bottom-5px">Email</h3></label>
                                <asp:TextBox ClientIDMode="Static" ID="Email_2" runat="server" CssClass="required useremail"/>
                            </div>
                        </div>

                        <div class="input-row">
                            <div class="col-4 input-margin-right-2">
                                <label><h3 class="margin-bottom-5px">Fax</h3></label>
                                <asp:TextBox ClientIDMode="Static" ID="Fax" CssClass="" runat="server" />
                            </div>
                             <div class="col-4">
                                <label><h3 class="margin-bottom-5px">Password</h3></label>
                                <asp:TextBox ClientIDMode="Static" ID="Password" CssClass="required" runat="server" />
                            </div>
                        </div>
                       
                       
                        <div class="navigation bottom">
                            <button  id="Save" class="btn-primary right" >Update</button>
                            <button target-tab="tab_2" next="2" class="btn-primary right margin-right-5 nav">Back</button>
                             <div class="clear-fix"></div>
                        </div>
                    </li> -->
                     <!-- Panel 3 -->
                </ul>


                <!-- Footer -->
                <div class="footer">
                   
                </div>

            </div>




        </div>
    </div>
    <script src="js/UserDetails.js"></script>
    <script>
    </script>
</asp:Content>
    