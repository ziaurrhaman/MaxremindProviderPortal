
// document ready function Start

$('document').ready(function () {
    $("[id$='Phone']").mask("(99) 9999*-9999");
    checker();

    // toggler
    $('#password-toggle').click(function (e) {
        $('.password-modal-back').toggleClass('hide');
        $('.password-modal').toggleClass('hide');
        e.preventDefault();
    });

    $('.close-modal').click(function (e) {
        $('.password-modal-back').addClass('hide');
        $('.password-modal').addClass('hide');
        $('.error-msg').css('display', 'none');
        $('#OldPassword').css('border-color', '#0376AF');
        $('#OldPassword').css('margin-bottom', '10px');
        $('#NewPassword').css('border-color', '#0376AF');
        $('#OldPassword').val("");
        $('#NewPassword').val("");
        e.preventDefault();
    })
    //toggler

    /*  $('.indicator-link').click(function (e) {
          checker();
          var target = $(this).attr('target-tab');
          $('.indicator-link').removeClass('active-indicator');
          $(this).addClass('active-indicator');
          $("#Name").val(($('#First_Name').val() + " " + $('#Last_Name').val()).trim());
          $(".pane").removeClass('show');
          $('#' + target).addClass('show');
          e.preventDefault();
      });*/

    /* $('.nav').click(function (e) {
         checker();
         var next = $(this).attr('next');
         var target = $(this).attr('target-tab');
         $('.indicator-link').removeClass('active-indicator');
         $('#' + next).addClass('active-indicator');
         $("#Name").val(($('#First_Name').val() + " " + $('#Last_Name').val()).trim());
         $(".pane").removeClass('show');
         $('#' + target).addClass('show');
         e.preventDefault();
     });*/

    $('#Save').click(function (e) {
        let regid = $('#ID').text();
        console.log($('#ID'));
        let subval = submit();
        if (subval == 100 && regid != "-1") {
            var objUser = new Object();
            objUser.UserRegistrationId = parseInt(regid);
            objUser.FirstName = $('#First_Name').val();
            objUser.LastName = $('#Last_Name').val();
            objUser.Email = $('#Email').val();
            objUser.UserName = $('#Email').val().trim().slice(0, $("#Email").val().indexOf('@'));
            objUser.PracticeName = $('#Practice_Name').val();
            objUser.TaxID = $('#TaxID').val();
            objUser.GroupNPI = $('#GroupNPI').val();
            //objUser.MedicaidProvider = $('#Medical_Provider').val();
            //objUser.ServicingProviderName = $('#Servicing_Provider_Name').val();
            //objUser.ProviderNPI = $('#_Provider_NPI').val();
            /*objUser.ProviderTaxonomyCode = $('#PT_Code').val();
            objUser.StateLicenseNumber = $('#Stat_License_Number').val();
            objUser.MedicaidGroup = $('#Medical_Group').val();
            objUser.GroupNPIMedicareGroupPTAN = $('#Group_NPI_Medicare_Group_PTAN').val();
            objUser.MedicareProviderPTAN = $('#Medicare_Provider_PTAN').val();
            objUser.Phone=$('#Phone').val();
            objUser.Fax = $('#Fax').val();
            objUser.PhysicalAddress = $('[id="Physical_Address"]').val();
            objUser.MailingAddress = $('[id="Mailing_Address"]').val();
            objUser.Password = $('#Password').val();*/
            objUser.UserImage = $('#Image_Retained_Name').val();
            $.post('CallBacks/UserRegisterationHandler.aspx', { action: 'update', UpdatedData: JSON.stringify(objUser) }).done(function (data) {
                showSuccessMessage("Your Profile Updated Successfully");
                $('[id=lblUsername]').text(objUser.LastName + ', ' + objUser.FirstName);
                //let src = $('#ContentPlaceHolder1_User_image_Box').attr('src');
                //if (src.trim() != "") {
                //    $('#imgProfielPicture').attr('src',src);
               // }
            }).fail(function (xhr, status, error) {
                showErrorMessage("SomeThing Went Wrong Status: " + status);
            });
        } else {
            let emailpat = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
            if (!emailpat.test($('#Email').val()) && subval >= 75) {
                showErrorMessage("Enter a valid email address");
            } else {
                showErrorMessage("Fill All Required Fields");
            }
        }
        e.preventDefault();
    });
    function picture() {
        new AjaxUpload("#User_Image", {
            action: 'CallBacks/ProfilePictureHandler.ashx',
            dataType: 'json',
            contentType: "application/json; charset=uft-8",
            data: {
                UserId: $("[id$='ID']").val(),
                PracticeId: $("[id$='ID']").val()
            },
            onSubmit: function (file, ext, fileSize) {
                console.log('I am called');
                if (!(ext && /^(jpg|png|jpeg|gif)$/.test(ext))) {
                    // callDialog("Sorry! the file is invalid.", "Invalid File");
                    return false;
                }
                if (fileSize > 25) {
                    // callDialog("This file exceeds the 5MB attachment limit.", "Attachment Limit");
                    return false;
                }
            },
            onComplete: function (file, response) {

                var serverResponse = $.parseJSON($(response).html());
                $('#Image_Retained_Name').val(serverResponse.fileName);
                var userImagePath = '/PracticeDocuments' + "/" + '1000' + "/Users/" + serverResponse.fileName;
                $(".User_image_Box").attr("src", userImagePath);
            }
        });
    }
    picture();
});

// document ready end here


// validation


function validate(e) {
    if (e == "") return false;
    else return true;
}


function checker() {
    let counter = 0;
    $('.required').each(function (ele) {
        if (validate($(this).val())) {
            $(this).removeClass('invalid');
            counter++;
        }
    }, $('.required'));
    //counter += emailValidation();
    let percentage = Math.floor((counter / $('.required').length) * 100);
    $('.progress').css('width', percentage + '%');
    //$('.progress-bar-container .left').css('width', (100 - percentage) + '%');
    $('.progress-bar-container .left span').text(percentage + '% complete');
}
function submit() {
    let counter = 0;
    $('.required').each(function (ele) {
        if (validate($(this).val())) {
            $(this).removeClass('invalid');
            counter++;
        } else {
            $(this).addClass('invalid');
        }
    }, $('.required'));

    counter += emailValidation();

    let percentage = Math.floor((counter / $('.required').length) * 100);
    $('.progress').css('width', percentage + '%');
    //$('.progress-bar-container .left').css('width', (100 - percentage) + '%');
    $('.progress-bar-container .left span').text(percentage + '% complete');
    return percentage;
}

function emailValidation() {
    let counter = 0;
    let regex = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    let email = $("#Email").val().trim();
    if (email != "") {
        if (!regex.test(email)) {
            counter--;
            $("#Email").addClass('invalid');
        } else {
            $("#Email").removeClass('invalid');
        }
    }

    return counter;
}

// validation End


// key press events

$('.Name').keypress(function (e) {
    var regex = new RegExp("^[A-Za-z0-9@#$_]+$");
    var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
    if (regex.test(str)) {
        return true;
    }

    e.preventDefault();
    showErrorMessage("Special characters is not allowed (e.g & , ( \" } % ? | ] )");
    return false;
});
$('.PracticeName').keypress(function (e) {
    var regex = new RegExp("^[A-Za-z0-9@#$_]+$");
    var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
    if (regex.test(str) || e.keyCode == 32) {
        return true;
    }

    e.preventDefault();
    showErrorMessage("Special characters is not allowed (e.g & , ( \" } % ? | ] )");
    return false;
});

$('.NameField').on('keydown', function (e) {
    let pattern = /[a-zA-Z]/;
    if (pattern.test(e.key)) {
        return;
    }
    else {
        e.preventDefault();
    }
});
// Key press events End


// reset password//

$('#reset-password').click(function (e) {

    let regid = $('#ID').text();
    var objUser = new Object();
    objUser.UserRegistrationId = regid;
    objUser.Password = $('#NewPassword').val()
    $('#NewPassword').css('border-color', '#0376AF');
    //$.ajaxSetup({ async: false });
    if ($('#NewPassword').val().trim().length < 5 || $('#OldPassword').val().trim().length < 5) {
        if ($('#NewPassword').val().trim().length < 5) {
            $('#NewPassword').css('border-color', 'red');

        } else {
            $('#NewPassword').css('border-color', '#0376AF');
        }

        if ($('#OldPassword').val().trim().length < 5) {
            $('#OldPassword').css('border-color', 'red');
        } else {
            $('#OldPassword').css('border-color', '#0376AF');
        }
        showErrorMessage("Minimum 5 characters");
    }
    else {
        $.post('CallBacks/UserRegisterationHandler.aspx', { action: "UpdatePassword", UpdatePasswordData: JSON.stringify(objUser), OldPassword: $('#OldPassword').val() }, function (data) {
            let sp = data.indexOf('##SatrtPasswordVerification##') + '##SatrtPasswordVerification##'.length;
            let ep = data.indexOf('##EndPasswordVerification##');
            let value = data.slice(sp, ep).trim();
            if (value == "True") {
                showSuccessMessage("Your Password Is Updated Successfully");
                $('.error-msg').css('display', 'none');
                $('#OldPassword').css('border-color', '#0376AF');
                $('#OldPassword').css('margin-bottom', '10px');
                $('.password-modal-back').addClass('hide');
                $('.password-modal').addClass('hide');
                $('#OldPassword').val("");
                $('#NewPassword').val("");

            }
            else {
                $('#OldPassword').css('border-color', 'red');
                $('#OldPassword').css('margin-bottom', '0px');
                $('.error-msg').css('display', 'block');
                $('.error-msg').css('margin-bottom', '10px');
                showErrorMessage("Wrong Old Password");
            }

        })
    }

    //$.ajaxSetup({ async: true });
    e.preventDefault();

});