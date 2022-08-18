<%@ Page Title="" Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master" AutoEventWireup="true" CodeFile="Settings.aspx.cs" Inherits="ProviderPortal_Settings_Settings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../StyleSheets/EHRdefaultCSS.css" rel="stylesheet" />
    <link href="../../StyleSheets/UserRolesRights.css" rel="stylesheet" />
    <script src="../../Scripts/Tickets.js"></script>
    <script src="../../Scripts/InsuranceCredentialing.js"></script>
    <script src="../InsuranceEnrollment/js/InsuranceEnrollment.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <label id="title"></label>
    <div id="main">
        <div class="settings-sidenav">
            <div onclick="showPractiseUsers(); " class="_btn">
                <div id="img1" class="settings-icon">
                    <img src="../../Images/Patients.png" class="settings-icon-img" />
                </div>


                <span id="" class="span">Users</span>
            </div>
            <div onclick="OpenUserRoles(); " class="_btn">

                <div id="img2" class="settings-icon">
                    <img src="../../Images/role.png" class="settings-icon-img" />
                </div>


                <span id="" class="span">Users Role</span>

            </div>
            <div onclick="OpenUserRights(); " class="_btn">
                <div id="" class="settings-icon">
                    <img src="../../Images/right.jpg" class="settings-icon-img" />
                </div>


                <span id="" class="span">Users Rights</span>
            </div>
            <div class="_btn" onclick="OpenTicketingForm()">
                <div id="" class="settings-icon">
                    <img src="../../Images/Tickets.png" class="settings-icon-img" />
                </div>


                <span id="" class="span">Ticketing</span>
            </div>
            <div class="_btn" onclick="ShowInsuranceCredentialing()">
                <div id="img5" class="settings-icon">
                    <img src="../../Images/InsuCredentiling.png" class="settings-icon-img" />
                </div>
                <span id="" class="span">Insurance Credentialing</span>
            </div>
            <div onclick="ShowInsuranceEnrollment(); " class="_btn">
                <div id="" class="settings-icon">
                    <img src="../../Images/EDIERA.png" class="settings-icon-img" />
                </div>
                <span id="" class="span">EDI/ERA User</span>
            </div>
        </div>

        <div style="width: 80%; float: right" class="settings_right">
            <div id="UserRolesDiv"></div>
            <div id="divUsersMain"></div>
            <div id="divTicketing"></div>
            <div id="divInsuranceCredentialingWrapperId" style="display: none"></div>
            <div id="divInsuranceEnrollment" style="display: none"></div>
        </div>
        <div class="divUserAddEdit" style="width: 95%; margin: 0 auto; display: none; margin-top: 10px;"></div>

    </div>



    <script>
        $(document).ready(function () {
            debugger;
            $("#_settings").addClass("active");
            showPractiseUsers();

        });
    </script>

    <style>
        

        #title {
            font-size: 17px;
            font-weight: bold;
            margin-top: 5px !important;
            position: fixed;
        }
    </style>

</asp:Content>

