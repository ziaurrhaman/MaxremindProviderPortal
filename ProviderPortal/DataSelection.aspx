<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DataSelection.aspx.cs" Inherits="ProviderPortal_DataSelection" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <title>Maxremind</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
    <style>
        .bs-example {
            margin: 20px;
            margin-top: 30px;
            margin-left: 350px;
        }
        .shadow-card:hover{
            cursor:pointer;
            box-shadow:0 0 6px 1px silver;
        }
        .c-dropdown{
            position:absolute;
            list-style:none;
            padding:0px;
            width:70%;
            background:white;
            top:150%;
            box-shadow:0px 1.5px 3px 0.5px silver;
            right:0px;
        }
        .c-dropdown li{
            width:100%;
        }
        .c-dropdown li a{
            text-align:center;
            display:block;
            padding:2px 5px;
            cursor:pointer;
            text-decoration:none;
            color:black;
        }
        .dropdown-cursor {
            display: inline-block;
            width: 20px;
            height: 20px;
            background-image: url(../Images/down-arrow-iconBlack.jpg);
            background-position:center center;
            background-size:cover;
            background-repeat:no-repeat;
        }
        .hide{
            display:none;
        }
    </style>
</head>
<body>
    <div style="margin-left: 5px; margin-right: 25px">
        <div class="row" style="border-bottom: 1px solid #c8c4c4; padding-bottom: 10px; margin-top: 15px">
            <div class="col-7">
                <span class="ml-5">
                    <img src="../../Images/logo_maxremind.png" /></span>
            </div>
            <div class="col-5">
                <span style="float: right; margin-right: 20px;position:relative;">
                    <img src="../../Images/maleIcon.png" style="width: 20px; height: 20px; margin-right: 10px" />
                    <b>Friends James</b>
                    <span class="dropdown-cursor" onclick="togglelist();">
                    </span>
                     <ul id="profile-list" class="c-dropdown hide">
                        <li><a href="Logout.ashx">Logout</a></li>
                    </ul>
                </span>
               
            </div>
        </div>
        <div class="row bs-example">
            <div class="col-1"></div>
            <div  class="col-2">
                <a href="DataSelection.aspx?IsImported=0" class="card text-decoration-none text-dark shadow-card" style="width: 130px; height:150px">
                    <span style="width: 30%;margin:auto; margin-top:21px"><img src="../Images/All Data.png" style="" class="card-img-top"></span>
                    <div class="card-body text-center">
                        <h6 class="card-title">All Data</h6>
                    </div>
                </a>
            </div>
            <div  class="col-2">
                <a href="DataSelection.aspx?IsImported=1" class="card text-decoration-none text-dark shadow-card" style="width: 130px; height:150px">
                    <span style="width: 30%;margin:auto; margin-top:21px"><img src="../Images/MaxRemind Data.png" class="card-img-top"></span>
                    <div class="card-body text-center">
                        <h6 class="card-title">MaxRemind Data</h6>
                    </div>
                </a>
            </div>
            <div  class="col-2">
                <a href="DataSelection.aspx?IsImported=2" class="card text-decoration-none text-dark shadow-card" style="width: 130px; height:150px">
                     <span style="width: 30%;margin:auto; margin-top:21px"><img src="../Images/Imported Data.png" class="card-img-top" style=""></span>
                    <div class="card-body text-center">
                        <h6 class="card-title">Imported Data</h6>
                    </div>
                </a>
            </div>
        </div>
    </div>
</body>
    <script>
        var list = document.getElementById('profile-list');
        function togglelist() {
            list.classList.toggle('hide');
        }
    </script>
</html>

