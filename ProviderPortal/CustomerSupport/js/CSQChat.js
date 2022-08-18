var months    = ['Jan','Feb','Mar','Apr','May','Jun','Jul','Aug','Sep','Oct','Nov','Dec'];

function sendMessage() {
    let tempid = 'mes-'+Math.floor((Math.random()*1000000%1000));
    let html = `<div class="send-msg mb-2" id="${tempid}">
                                        <div class="row no-gutters w-100">
                                            <i class="fa fa-user-circle-o pl-2 pt-1" style="color: #439abf"></i>
                                          <div class="col-8 border-colr pl-3 colr-white ml-auto">
                                               <p style="margin-bottom: 3px">${$('#messageinput').val()}</p>
                                              <hr class="p-0 m-0 bg-white"/>
                                              <p class ="p-0 mb-1">${new Date().toLocaleTimeString()} | ${months[new Date().getMonth()]}</p>
                                          </div>
                                          <div class ='col-1'><p style='font-size:8px;white-space:wrap;color:black;text-align:center;'>Me</p></div>
                                        </div>
                                        </div>`;
    $('.message-box').html($('.message-box').html() + html);
    $('.message-box').scrollTop($('.message-box').prop('scrollHeight'));
    new ChatHTTP('Callbacks/ChatHandler.ashx').Send({
        Action: 'SentMessage', userid: $('[id$="hdnuserid"]').val(), username:$('[id$="hdnusername"]').val(),
        ticketid: $('[id$="lblTitleNo"]').text().trim(), message: $('#messageinput').val(), replymsgid: $('#hdnreplymsgid').val()||""
        ,messageid:tempid
    }, function (c) {
        $('#messageinput').val("");
        $('#hdnreplymsgid').val("");
        if (c.status == "success") {
            $('#' + c.messageid).attr('id', c.rmessageid);
        }
    })
    
}
function initChat(id) {
    new ChatHTTP('Callbacks/ChatHandler.ashx').getAll({ Action: 'GetAll', ticketid: id }, function (res) {
        let Res = res || [];
        let userid = $('[id$="hdnuserid"]').val();
        let html = "";
        Res.forEach(function (element) {
            let date = 'new ' + (element.CreatedDate.replace(/[\/]/g, function (c) {
                return "";
            }));
            date = eval(date);
            debugger;
            let rmsg = element.ReferenceMessageId;
            let rMsg = Res.filter(function (e) { return e.ChatId == rmsg });
            rMsg = (rMsg.length > 0) ? rMsg[0].Message : "Hide by Admin";
            if (element.UserId == userid) {
                if (rmsg != null) {
                    html += `<div class="row mr-0 mt-3 mb-2" id='${element.ChatId}'>
                                    <div class="col-3"></div>
                                    <div class ="col-8 border-colr colr-white">
                                        <div class="row no-gutters w-100">
                                            <div class ="col-12 p-1 border-colr colr-white" style="background-color:#306a82 !important">
                                                <p style="" class ='font-italic m-0'>${rMsg}</p>
                                            </div>
                                        </div>
                                        <div class ="row no-gutters w-100">
                                            <i class="fa fa-user-circle-o pl-2 pt-1" style="color: #439abf"></i>
                                            <div class="col-8 border-colr colr-white">
                                                <p class='p-0' style="margin-bottom: 3px;">${element.Message}</p>
                                            </div>
                                        </div>
                                        <hr class ="p-0 m-0 bg-white"/>
                                       <div class ="row no-gutters w-100">
                                            <div class="col-12 text-light">
                                                <small class ="text-light pl-2">${date.toLocaleTimeString()} | ${months[date.getMonth()]}</small>
                                            </div>
                                        </div>
                                    </div>
                                    <div class ='col-1'><p style='font-size:8px;white-space:wrap;color:black;text-align:center;'>Me</p></div>
                                </div>`
                } else {
                    html += `<div class="send-msg mb-2" id="${element.ChatId}">
                                        <div class="row no-gutters w-100">
                                            <i class ="fa fa-user-circle-o pl-2 pt-1" style="color: #439abf"></i>
                                          <div class="col-8 border-colr pl-3 colr-white ml-auto">
                                               <p style="margin-bottom: 3px">${element.Message}</p>
                                              <hr class="p-0 m-0 bg-white"/>
                                              <p class ="p-0 mb-1">${date.toLocaleTimeString()} | ${months[date.getMonth()]}</p>
                                          </div>
                                          <div class ='col-1'><p style='font-size:8px;white-space:wrap;color:black;text-align:center;'>Me</p></div>
                                        </div>
                                        </div>`;
                }

            } else {
                if (rmsg != null) {
                    html += `<div class="row mr-0 mt-3" id="${element.ChatId}">
                        <div class ='col-1'><p style='font-size:8px;white-space:wrap;color:black;text-align:center;'>Me</p></div>
                                    <div class ="col-8 border-colr colr-white">
                                        <div class ="row no-gutters w-100">
                                            <div class ="col-12 p-1 border-colr colr-white" style="background-color:#306a82 !important">
                                                <p style="" class ='font-italic m-0'>${rMsg}</p>
                                            </div>
                                        </div>
                                        <div class ="row no-gutters w-100">
                                            <i class ="fa fa-user-circle-o pl-2 pt-1" style="color: #439abf"></i>
                                            <div class ="col-8 border-colr colr-white">
                                                <p class ='p-0' style="margin-bottom: 3px;">${element.Message}</p>
                                            </div>
                                        </div>
                                        <hr class ="p-0 m-0 bg-white"/>
                                       <div class ="row no-gutters w-100">
                                            <div class ="col-12 text-light">
                                                <small class ="text-light pl-2">${date.toLocaleTimeString()} | ${months[date.getMonth()]}</small>
                                            </div>
                                        </div>
                                    </div>
                                </div>`
                } else {
                    html += `<div class="send-msg mb-2" id="${element.ChatId}">
                                        <div class="row no-gutters w-100">
                                            <i class ="fa fa-user-circle-o pl-2 pt-1" style="color: #439abf"></i>
                                          <div class ='col-1'><p style='font-size:8px;white-space:wrap;color:black;text-align:center;'>${element.UserName}</p></div>
                                          <div class="col-8 border-colr pl-3 colr-white">
                                               <p style="margin-bottom: 3px">${element.Message}</p>
                                              <hr class="p-0 m-0 bg-white"/>
                                              <p class ="p-0 mb-1">${date.toLocaleTimeString()} | ${months[date.getMonth()]}</p>
                                          </div>
                                        </div>
                                        </div>`;
                }
            }
        });
        $('.message-box').html(html);
    })
}


class ChatHTTP {
    // the server to call
    constructor(serveraddr) {
        this.http = new XMLHttpRequest();
        this.http.open('POST', serveraddr, true);
        this.http.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded, multipart/form-data');
        this.http.responseType='json';
    }
    Send(object, callback) {
        let that = this.http;
        this.http.send($.param(object));
        this.http.onload = function (data) {
            if (that.status == 200 && this.readyState) {
                callback(that.response);
            }
        }
    } 
    getAll(object, callback) {
        let that = this.http;
        this.http.send($.param(object));
        this.http.onload = function (data) {
            if (that.status == 200 && this.readyState) {
                callback(that.response);
            }
        }
    }
}