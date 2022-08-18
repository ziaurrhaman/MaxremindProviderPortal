<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChatMain.aspx.cs" Inherits="ProviderPortal_Chat_ChatMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" />
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js"></script>
    <style>
        .hide{
            display:none !important;
        }
    </style>
</head>
    
<body>
    <input type="hidden" id="hdnsername" />
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
  <a class="navbar-brand" href="#">Navbar</a>
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>
  <div class="collapse navbar-collapse" id="navbarNav">
    <ul class="navbar-nav">
      <li class="nav-item">
        <a class="nav-link nav-link-btn" target="ChatBox">Home</a>
      </li>
      <li class="nav-item  active">
        <a class="nav-link nav-link-btn" id="login-link" target="Login">Login <span class="sr-only">(current)</span></a>
      </li>
      <li class="nav-item">
        <a class="nav-link nav-link-btn" target="SignUp">SignUp</a>
      </li>
      <li class="nav-item">
        <a class="nav-link disabled" id="logout-link" href="#">Logout</a>
      </li>
    </ul>
  </div>
</nav>
        <div id="Login" class="card w-50 m-auto mt-2 cards active">
            <div class="card-body p-2">
                <div class="form">
                    <label>UserName:</label>
                    <input id="LoginUserName" class="form-control mb-1 rounded-0 shadow-none"/>
                    <label>Password:</label>
                    <input id="LoginPassword" class="form-control mb-1 rounded-0 shadow-none"/>
                    <input id="LoginButton" type="button" value="Login" class="btn btn-block btn-primary rounded-0 shadow-none"/>
                </div>
            </div>
        </div>
    <div id="SignUp" class="card w-50 m-auto mt-2  cards hide">
            <div class="card-body p-2">
                <div class="form">
                    <label>Name:</label>
                    <input id="SinUpUserName" class="form-control mb-1 rounded-0 shadow-none"/>
                    <label>Email:</label>
                    <input id="SinUpEmail" class="form-control mb-1 rounded-0 shadow-none"/>
                    <label>Password:</label>
                    <input id="SignUpPassword" class="form-control mb-1 rounded-0 shadow-none"/>
                    <label>Confirm Password:</label>
                    <input id="SignUpCPassword" class="form-control  mb-1 rounded-0 shadow-none"/>
                    <input id="SignUpButton" type="button" value="Signup" class="btn btn-block btn-primary rounded-0 shadow-none"/>
                </div>
            </div>
        </div>
    <div id="ChatBox" class="card w-50 m-auto mt-2 cards hide">
            <div class="card-body p-2">
                <div class="chat-list d-flex flex-column justify-content-end" style="max-height:200px;min-height:200px;overflow-y:scroll">
                    <ul id="messagelist" style="padding:0px;margin:0px;list-style-type:none;">
                    </ul>
                </div>
                <div class="send-dialog row no-gutters w-100">
                    <div class="col-9">
                        <input placeholder="MessageHere" id="message"  class="form-control rounded-0 shadow-none"/>
                    </div>
                    <div class="col-3 px-1">
                        <input type="button" id="send" class="btn btn-primary btn-block" value="Send" /> 
                    </div>
                </div>
            </div>
        </div>
    <div class="userlist bg-dark" style="width:25%;max-width:250px;position:fixed;right:0px;top:56px;bottom:0px;">
        <ul id="userlist" style="list-style-type:none;padding:0px;margin:0px;">
        </ul>
    </div>
    <div class="userlist bg-dark" style="width:25%;max-width:250px;position:fixed;left:0px;top:56px;bottom:0px;">
        <h3 class="text-white text-center">Selected User</h3>
        <ul id="selectedlist" style="list-style-type:none;padding:0px;margin:0px;">
        </ul>
    </div>
    <script src="https://www.gstatic.com/firebasejs/7.11.0/firebase-app.js"></script>
    <script src="https://www.gstatic.com/firebasejs/7.11.0/firebase-auth.js"></script>
    <script src="https://www.gstatic.com/firebasejs/7.11.0/firebase-messaging.js"></script>
    <script src="https://www.gstatic.com/firebasejs/7.11.0/firebase-database.js"></script>
    
</body>
    <script>
        function showRightFul() {
            $.each($('.cards'), function (e) {
                if (!$(this).hasClass('active'))
                    $(this).addClass('hide');
                else {
                    $(this).removeClass('hide');
                }
            })
        }
        $(document).ready(function () {
            $('.nav-link-btn').on('click', function(e){
                e.preventDefault();
                let target = '#' + $(this).attr('target');
                $.each($('.nav-link-btn'), function (e) {
                    $(this).closest('li').removeClass('active');
                });
                $(this).closest('li').addClass('active');
                $('.cards').removeClass('active');
                $(target).addClass('active');
                showRightFul();
            });
        });
    </script>
    <script src="js/ChatMain.js"></script>
</html>
