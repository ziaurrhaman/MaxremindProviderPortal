<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ProviderPortal/BillingMaster.master" CodeFile="CustomerSupportProviderView.aspx.cs" Inherits="ProviderPortal_CustomerSupport_CallBacks_CustomerSupportProviderView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
 
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     ###StartModel###

        <style>
            .container{

    overflow: hidden; 
            }
        textarea {
            resize: none;
        }

        body {
            background-color: #eeefef;
        }

        .support-btn {
            background-color: #006291;
            height: 28px;
            color: white;
            outline: 1px solid #006291;
            border: 1px solid #006291;
        }

        .border-colr {
            border: 1px solid #439abf;
            border-radius: 30px;
            background-color: #439abf;
            line-height: 1.0;
            padding-top: 3px;
        }

        .colr-white {
            color: white;
        }

        @media only screen and (min-width: 786px) {
            body {
                overflow: hidden;
            }
        }

        .border1 {
            border: 1px solid #faf6f6;
            border-radius: 30px;
            line-height: 1.0;
            padding-top: 3px;
            background-color: #faf6f6;
        }

        .border2 {
            border: 1px solid #faf6f6;
            border-radius: 30px;
            line-height: 1.0;
            background-color: #faf6f6;
        }

        .star-colr {
            color: #dcd4d4;
            font-size: 15px;
        }

        .shadow-lg {
            box-shadow: 3px 3px 3px 3px #d7d7d7;
        }
        .input {
  position: absolute;
  font-size: 50px;
  opacity: 0;
  right: 0;
  top: 0;
}
            .rmspace {
                white-space: nowrap;
            }
.star-rating {
  line-height:32px;
  font-size:1.25em;
}

.fa-star{color: #006291;}
.modelcommentbox{
    height:50px;
} 
.starclx{
    display: inline-block;
    font: normal normal normal 14px/1 FontAwesome;
    font-size: inherit;
    text-rendering: auto;
    -webkit-font-smoothing: antialiased;
}
    </style>

    <div class="container" style="width: 98%">
        <div class="row  ml-1">
            <div class="col-12 ml-2 mt-2 shadow-lg" style="background-color: white">
                <div class="row shadow-lg border pt-2 pb-1">
                    <div class="col-1">
                        <b>Ticket#</b>
                    </div>
                    <div class="col-1" style="flex: 0 0 5.333333%">
                        <asp:Label ID="lblTitleNo" runat="server" CssClass="rmspace" Text="New Ticket"></asp:Label>
                    </div>
                    <div class="col-1">
                        <b>Status</b>
                    </div>
                    <div class="col-6" style="padding: 0px">
                    
                        <asp:DropDownList runat="server" ID="ddlstatus"  CssClass=" d-inline-block select" style="width: 20%; height: 26px; padding: 0px">
                        </asp:DropDownList>
                    </div>
                    <div class="col-1" style="flex: 0 0 13.666667%">
                        <b>All Tickets</b>
                    </div>
                    <div class="col-2" style="padding: 0px">
                        <asp:DropDownList runat="server" ID="ddlallticket"  onchange="ddlAllTicket();"  CssClass=" d-inline-block select" style="width: 60%; height: 26px; padding: 0px;">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row  pt-2 pb-2 shadow-lg mt-1" style="background-color: #f3f2f2">
                    <div class="col-1">
                        <b>Subject</b>
                    </div>
                    <div class="col-2" style="padding: 0px">
                        <asp:TextBox runat="server" ID ="subject1" style="width: 100%; height: 26px;"></asp:TextBox>
                       
                    </div>
                    <div class="col-8"></div>
                    <div class="col-1 pl-0">
                         <select style="width: 100%; height: 26px; padding: 0px" class="select">
                            <option>Supervisor</option>
                            <option>CS Officer</option>
                            
                        </select>
                        
                    </div>
                </div>
                <div class="row mt-2">
                    <div class="col mr-3">
                        <div class="row mt-0 shadow-lg">
                            <div class="col-12">
                                <div class="row" style="color: white; background-color: #006291; text-align: center">
                                    <div class="col-12">
                                        <b>Query</b>
                                    </div>
                                </div>
                                <div class="row pt-2 pb-4 border">
                                    <div class="col-12 ml-2">
                                        <asp:TextBox id="description1" TextMode="multiline" Columns="50" Rows="4" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row mt-0 shadow-lg">
                            <div class="col-12">
                                <div class="row mt-2" style="color: white; background-color: #006291; text-align: center">
                                    <div class="col-12">
                                        <b>Response</b>
                                    </div>
                                </div>
                                <div class="row pt-2 pb-4 border">
                                    <div class="col-12 ml-2">
                                        <textarea rows="4" style="width: 99%" runat="server" id="response" disabled="disabled">Waiting For Response</textarea>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row pt-4 pb-2">
                            <div class="col-3">
                                <span class="pl-3 pr-3" style="border-radius: 30px; border: 1px solid #439abf">
                                    <small>Attach file</small>
                                    <i class="fa fa-paperclip pl-1 pt-1"></i>
                                 <input class="input attachments"   id="fileuploader" type="file" name="file"/>
                                <input type="hidden" id="filename" />
                                <input type="hidden" id="filepath" />

                                </span>
                            </div>
                            <div class="col-3">
                                  
                                <%--<b>Customer Feedback</b>
                                <i class="fa fa-star star-colr pl-1"></i>
                                <i class="fa fa-star star-colr"></i>
                                <i class="fa fa-star star-colr"></i>
                                <i class="fa fa-star star-colr"></i>
                                <i class="fa fa-star star-colr"></i>--%>
                            </div>
                            <div class="col-3">

                            </div>
                            <div class="col-3">
                                <button type="button" class="support-btn pr-1 pl-2" onclick="AddNewTickets()">Submit </button>
                                <button type="button" class="support-btn pr-1 pl-2 ml-1" onclick="closediv()">Cancel</button>
                            </div>
                        </div>
                    </div>
                    <div class="col-6 shadow-lg">
                       <%-- <div class="row mb-2 mt-2">
                            <div class="col-12" style="padding-left: 2px">
                                <button type="button" class="support-btn pr-1 pl-1 ">Supervisor </button>
                                <button type="button" class="support-btn pr-1 pl-1 ml-1">CS Officer</button>
                            </div>
                        </div>--%>
                        <div class="row mr-0 chatmain" style="height: 356px; overflow: hidden; background-color: white;position:relative;">
                            <div class="col-12 border p-0">
                                <div id="CSQ-Chat-hider" style="position:absolute;width:100%;height:100%; background:rgba(0, 0, 0, 0.00);z-index:2;box-sizing:border-box;" class="hide">
       <div style="position:absolute;width:100%;height:240px;background:white;z-index:3;display:flex;flex-direction:column;justify-content:center;
        align-items:center;box-shadow:0px 0px 1px 1px silver;
        ">
           <span>Discussion start after generate ticket</span>
       </div>
   </div>
                                <div class="message-box" style="height:275px;max-height:275px;overflow-y:auto; background:white;">
                                   
                                </div>
                                <%-- Recieved msg --%>
                               <%-- <div class="row">
                                    <i class="fa fa-user-circle-o pl-2 pt-1" style="color: #439abf"></i>
                                    <div class="col-8 border-colr ml-3 colr-white">
                                        <p style="margin-bottom: 3px">Lorem Ipsum is simply dummy text</p>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-8 ml-4">
                                        <small class="text-muted">06/03/2020  12:13</small>
                                    </div>
                                </div>
                                <div class="row mr-1">
                                    <div class="col-4"></div>
                                    <div class="col-8 border1" style="color: #439abf">
                                        <p style="padding-top: 5px; margin-bottom: 3px">Lorem Ipsum is simply dummy text</p>
                                    </div>
                                </div>
                                <div class="row mr-1">
                                    <div class="col-4"></div>
                                    <div class="col-8" style="text-align: right">
                                        <small class="text-muted">06/03/2020  12:13</small>
                                    </div>
                                </div>
                                <div class="row">
                                    <i class="fa fa-user-circle-o pl-2 pt-1" style="color: #439abf"></i>
                                    <div class="col-8 border-colr ml-3 colr-white">
                                        <p style="margin-bottom: 3px">Lorem Ipsum is simply dummy text</p>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-8 ml-4">
                                        <small class="text-muted">06/03/2020  12:13</small>
                                    </div>
                                </div>--%>
                                 <%--<div class="row mr-0 mt-3">
                                    <div class="col-4"></div>
                                    <div class="col-8 border2">
                                        
                                       <div class="row">
                                            <div class="col-12">
                                                <small class="text-muted">06/03/2020  12:13</small>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-12" style="border-top: 1px solid black; color: #439abf">
                                                <p style="margin-bottom: 3px; padding-bottom: 7px; padding-top: 7px">Lorem Ipsum is simply dummy text</p>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <i class="fa fa-user-circle-o pl-2 pt-1" style="color: #439abf"></i>
                                            <div class="col-8 border-colr ml-3 colr-white">
                                                <p style="margin-bottom: 3px">Lorem Ipsum is simply dummy text</p>
                                            </div>
                                        </div>
                                       <div class="row">
                                            <div class="col-12">
                                                <small class="text-muted">06/03/2020  12:13</small>
                                            </div>
                                        </div>
                                    </div>
                                </div>--%>
                                <%--some chat--%>
           <%--                    <div class="row mr-0 mt-3">
                                    <div class="col-4"></div>
                                    <div class="col-8 border2">
                                        <div class="row" style="border-radius: 30px">
                                            <div class="col-12 pl-4">
                                                <i class="fa fa-quote-left" aria-hidden="true"></i>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-12 text-muted">
                                                <i style="margin-bottom: 3px">Lorem Ipsum is simply dummy text</i>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-12">
                                                <small class="text-muted">06/03/2020  12:13</small>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-12" style="border-top: 1px solid black; color: #439abf">
                                                <p style="margin-bottom: 3px; padding-bottom: 7px; padding-top: 7px">Lorem Ipsum is simply dummy text</p>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <i class="fa fa-user-circle-o pl-2 pt-1" style="color: #439abf"></i>
                                            <div class="col-8 border-colr ml-3 colr-white">
                                                <p style="margin-bottom: 3px">Lorem Ipsum is simply dummy text</p>
                                            </div>
                                        </div>
                                    </div>
                                </div>--%>
                                <div class="row  border-top pt-3">
                                    <div class="col-12">
                                        <input type="hidden" id="hdnreplymsgid" />
                                        <input type="text" id="messageinput" placeholder="Write Message" style="width: 86%; border: none; outline: none" />
                                        <i class="fa fa-paperclip pl-3"></i>
                                        <i class="fa fa-paper-plane pb-2 pl-3" style="color: #006ebd" onclick="sendMessage()"></i>
                                    </div>
                                </div>
                                
                            </div>
                        </div>
                       <%-- <div class="row mr-0 chathide" style="height: 356px; overflow: auto; background-color: white;display:none;">
                            <span style="font-size:30px;margin-top:20%;text-align:center;margin-left:34%;color:#006291; display:flex;"> Discussion start after creating ticket</span>
                        </div>--%>
                    </div>
                </div>
            </div>
        </div>
    </div>

      <!--Start Modal -->

<div class="modal fade" id="feedback" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
  <div class="modal-dialog modal-dialog-centered" role="document">
    <div class="modal-content" style="width:50%; margin-left:25%;">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLongTitle">FeedBack</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close" onclick="closefeedbackModal();">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
      <div class="row">
    <div class="col-lg-3">
      <div class="star-rating">
        <span class="fa fa-star-o starclx" data-rating="1"></span>
        <span class="fa fa-star-o starclx" data-rating="2"></span>
        <span class="fa fa-star-o starclx" data-rating="3"></span>
        <span class="fa fa-star-o starclx" data-rating="4"></span>
        <span class="fa fa-star-o starclx" data-rating="5"></span>
        <input type="hidden" name="whatever1" class="rating-value" id="starrating" value="2">
      </div>
    </div>
          <div class="col-7">
              <asp:TextBox ID="comment" CssClass="modelcommentbox"  runat="server" placeholder="Comment"></asp:TextBox>
          </div>
  </div>

      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal" onclick="closefeedbackModal();">Close</button>
        <button type="button" class="btn btn-primary" onclick="SaveFeedback();">Save</button>
      </div>
    </div>
  </div>
</div>
      <!--End Modal -->
    <script>
        $(document).ready(function () {
            var $star_rating = $('.star-rating .fa');

            var SetRatingStar = function () {
                return $star_rating.each(function () {
                    if (parseInt($star_rating.siblings('input.rating-value').val()) >= parseInt($(this).data('rating'))) {
                        return $(this).removeClass('fa-star-o').addClass('fa-star');
                    } else {
                        return $(this).removeClass('fa-star').addClass('fa-star-o');
                    }
                });
            };

            $star_rating.on('click', function () {
                $star_rating.siblings('input.rating-value').val($(this).data('rating'));
                return SetRatingStar();
            });

            SetRatingStar();
            $(document).ready(function () {

            });


        })

     
    </script>
    ###EndModel###

</asp:Content>
