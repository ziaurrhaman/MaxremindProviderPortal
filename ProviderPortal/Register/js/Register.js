function startAnimation(message) {
    $("#error-block").stop().fadeOut();
    $("#error-block").html('<strong>'+message+'</strong>').fadeIn(2000).fadeOut(15000);
}
function stopAnimation() {
    $('#error-block').css('display', 'none');
}
function RegisterErrorHandler(status, message) {
    if (status == "success") {
        startAnimation();
    } else if (status == "error") {
        startAnimation(message);
    }
}


$('#UserName').keypress(function (e) {
    
    var regex = new RegExp("^[A-Za-z0-9@#$_]+$");
    var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
    if (regex.test(str)) {
        return true;
    }

    e.preventDefault();
    RegisterErrorHandler("error", "Special characters is not allowed (e.g & , ( \" } % ? | ] )");
    return false;
});

//validation

function checker() {
    let check = true;
    let msg = null;
    let namepattern = /[A-Za-z]{3,100}/;
    let usernamepatter = /^[A-Za-z0-9@#$_]+$/;
    let emailpattern = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
    let passwordpattern = /[A-Za-z0-9_]{5,100}/;
    if ($('#FirstName').val().trim().match(namepattern)==null) {
        check = false;
        $('#FirstName').parent().addClass('invalid');
        if (msg == null) msg = "First Name Must at Least contain 3 characters and no special characters";
    } else $('#FirstName').parent().removeClass('invalid');


    if ($('#LastName').val().trim().match(namepattern) == null) {
        check = false;
        $('#LastName').parent().addClass('invalid');
        if (msg == null) msg = "Last Name Must at Least contain 3 characters and no special characters";
    } else $('#LastName').parent().removeClass('invalid');

    //user name validtation

  /*  if ($('#UserName').val().trim().match(usernamepatter) == null) {
        check = false;
        $('#UserName').parent().addClass('invalid');
        if (msg == null) msg = "Invalid user name";
    } else $('#UserName').parent().removeClass('invalid');*/
    //user name validtation end


    if ($('#Email').val().trim().match(emailpattern) == null) {
        check = false;
        $('#Email').parent().addClass('invalid');
        if (msg == null) msg = "Invalid Email";
    } else $('#Email').parent().removeClass('invalid');


  /*  if ($('#Password').val().trim().match(passwordpattern) == null) {
        check = false;
        $('#Password').parent().addClass('invalid');
        if (msg == null) msg = "Invalid Password";
    } else $('#Password').parent().removeClass('invalid');

    if ($('#C_Password').val().trim() != $('#Password').val().trim()) {
        check = false;
        $('#C_Password').parent().addClass('invalid');
        if (msg == null) msg = "Password Does not match";
    } else $('#C_Password').parent().removeClass('invalid'); */

    if ($('[id=NPI]').val().trim().length < 10 || $('[id=lNPI]').val() == 'False' || $('[id=lNPI]').val() == 'Exist') {
        check = false;
        $('#NPI').parent().addClass('invalid');
        if (msg == null) msg = "NPI is invalid or other user is already registered with same NPI";
    } else $('#NPI').parent().removeClass('invalid');


    return {valid:check,message:msg};
}

//validation end


//sending data from here

$('#Register').click(function (e) {

    let RegisterObject = new Object();
    RegisterObject.FirstName = $('#FirstName').val();
    RegisterObject.LastName = $('#LastName').val();
    RegisterObject.Email = $('#Email').val();
    // RegisterObject.Password = $('#Password').val();
    RegisterObject.Password = ((Math.floor((Math.random() * 1000000)) + 100000).toString()).slice(0, 6);
    console.log(RegisterObject.Password);
    RegisterObject.ProviderNPI = $('#NPI').val();
    // RegisterObject.UserName = $('#UserName').val();
    RegisterObject.UserName = ($('#Email').val()).slice(0, $('#Email').val().indexOf('@'));
    let validity = checker();
    if (validity.valid == false) {
        RegisterErrorHandler("error", validity.message);
    }
    else {
        PostData(RegisterObject);
    }
    e.preventDefault();
});
//sending data from here

function PostData(RegisterObject) {
    let _ReturnUrl = $(location)[0].origin + '/ProviderPortal/login.aspx';
    $.post("CallBacks/UserRegisterationHandler.aspx", { action: 'add', UserRegistration: JSON.stringify(RegisterObject), ReturnUrl: $(location)[0].origin + '/ProviderPortal/login.aspx' }).done(function (data) {
        
        debugger;
        let sp = data.indexOf('##validatestart##') + '##validatestart##'.length;
        let ep = data.indexOf('##validateend##');
        let ValidateUserName = data.slice(sp, ep).trim();
        $("#AlredyExistUsername").val(ValidateUserName);
        let Exist = ValidateUserName;
        if (Exist == "true") {
            RegisterErrorHandler("error", "Email Aready Exist Enter Different Email");
            $('#Email').parent().addClass('invalid');
        } else if (Exist == undefined || Exist == null) {
            RegisterErrorHandler("error", "Something Went Wrong");
            $('#Email').parent().addClass('invalid');
        } else {
            $("#form-panel").css('display', 'none');
            $("#message_panel").addClass('show');
            stopAnimation();
        }


       
    }).fail(function (xhr, status, error) {
        console.log(xhr);
        RegisterErrorHandler("error", "Something Went south status: " +status);
    });
}

/*function NameAlreadyExist(RegisterObject) {
    $.post('CallBacks/UserRegisterationHandler.aspx', { action: 'UserNameExist', UserName: JSON.stringify(RegisterObject.UserName) }).done(function (data) {
        let sp = data.indexOf('##validatestart##') + '##validatestart##'.length;
        let ep = data.indexOf('##validateend##');
        let data2 = $.parseHTML(data.slice(sp, ep));
        $("#AlredyExistUsername").val(data2[1].textContent);
        let Exist = data2[1].textContent;
        if (Exist == "true") {
            RegisterErrorHandler("error", "Email Aready Exist Enter Different Email");
            $('#Email').parent().addClass('invalid');
        }else if (Exist == undefined || Exist == null){
            RegisterErrorHandler("error", "Something Went Wrong");
            $('#Email').parent().addClass('invalid');
        }else {
            PostData(RegisterObject)
        }
    }) 
}*/

/*function sendEmail(RegisterObject) {
    debugger;
    $.post('CallBacks/UserRegisterationHandler.aspx', { action: 'SendEmail', Email: RegisterObject.Email, Password: RegisterObject.Password,ReturnUrl:$(location)[0].origin+'/ProviderPortal/login.aspx' }, function (data) {
        let rtrn = (data.slice(data.indexOf('###StartEmailSendVerification###') + '###StartEmailSendVerification###'.length, data.indexOf('###EndEmailSendVerification###'))).trim();
        if (rtrn == "True") {
            PostData(RegisterObject);
        } else {
            RegisterErrorHandler("error", "Something went wrong");
        }
    })
}
*/


function ChkValidNPI(elem) {
    if ($('[id=NPI]').val().length == 10) {
        $.post('CallBacks/UserRegisterationHandler.aspx', { action: 'ChkValidNPI', NPI: $('[id=NPI]').val() }, function (data) {
            let sp = data.indexOf('###startValidNPIChk###') + '###startValidNPIChk###'.length;
            let ep = data.indexOf('###endValidNPIChk###');
            let _data = data.slice(sp, ep);
            if (_data.trim() == 'Exist') {
                $('[id=lNPI]').val('Exist');
                $('.npi-back').css({ 'background-image': 'url(../../../images/delete.png)' });
                RegisterErrorHandler("error", "NPI already Registered Enter Different NPI");
            }
            else if (_data.trim() == 'False') {
                $('[id=lNPI]').val('False');
                $('.npi-back').css({ 'background-image': 'url(../../../images/delete.png)' });
                RegisterErrorHandler("error", "Please enter the valid NPI");
            }
            else if (_data.trim()=='True') {
                $('[id=lNPI]').val('True');
                $('#NPI').parent().removeClass('invalid');
                $('.npi-back').css({ 'background-image': 'url(../../../images/success.png)' });
            }
        });
    } else {
        $('.npi-back').css({ 'background-image': 'url(../../../images/circle14-01.png)' });
    }
}


/*npi vaidataions*/
$('#NPI').on('keydown keyup change paste', function (e) {
    if ($(this).val().length > 10
        && e.keyCode !== 46 // keycode for delete
        && e.keyCode !== 8 // keycode for backspace
       ) {
        e.preventDefault();
        $(this).val("");
    }
});


/*from common javascript*/
function showLoader() {
    $("#divLoading").show();
    $("#divOverlay").show();
    $("#divLoading").css("top", Math.max(0, (($(window).height() - $("#divLoading").outerHeight()) / 2) + $(window).scrollTop()) + "px");
    $("#divLoading").css("left", Math.max(0, (($(window).width() - $("#divLoading").outerWidth()) / 2) + $(window).scrollLeft()) + "px");
}
function hideLoader(event, xhr, settings) {
    $("#divLoading").hide(); $("#divOverlay").hide();
}


$('document').ready(function () {
    hideLoader();
    (function /*BindLoadingDiv*/() {
        $(document).ajaxStart(showLoader);

        $(document).ajaxComplete(function(event, xhr, settings) {
            $("#divLoading").hide(); $("#divOverlay").hide();
        });
    })();
    function UnBindLoadingDiv() {
        $(document).ajaxStart(hideLoader);
    }
})
