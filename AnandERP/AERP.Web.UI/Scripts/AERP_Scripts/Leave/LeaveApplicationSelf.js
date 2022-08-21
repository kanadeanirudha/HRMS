////this class contain methods related to nationality functionality
//var LeaveApplicationSelf = {
//    //Member variables
//    ActionName: null,
//    totHalfday: null,
//    HiddenBalanceLeave: 0,
//    HiddenLeaveSessionID: 0,
//    totalfullDaysLeave: 0,
//    DocumentCompulsoryFlag: null,
//    DocumentRequiredFlag: null,
//    DocumentRequiredID: 0,
//    SelectedIDs: null,
//    FileName_N: null,
//    //Class intialisation method
//    Initialize: function () {
//        //organisationStudyCentre.loadData();
//        LeaveApplicationSelf.constructor();
//        //LeaveApplicationSelf.initializeValidation();
//    },
//    //Attach all event of page
//    constructor: function () {

//        $('#LeaveMasterID').focus();

//        $("#reset").click(function () {

//            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
//            $('input:checkbox,input:radio').removeAttr('checked');
//            $('#LeaveMasterID').focus();
//            return false;
//        });

//        // Create new record
//        $('#CreateLeaveApplicationSelfRecord').on("click", function () {


//            var start = $("#FromDate").val();
//            var end = $("#UptoDate").val();
//            var leaveRuleMasterID = $('input[name=LeaveRuleMasterID]').val();
//            var SelectedLeaveMasterID = $('#LeaveMasterID').val();
//            var SelectedLeaveDescription = $('#LeaveMasterID :selected').text();


//            if (start != null && start != "" && end != null && end != "" && leaveRuleMasterID != 0 && SelectedLeaveMasterID != 0) {
//                LeaveApplicationSelf.ActionName = "Create";
//                LeaveApplicationSelf.AjaxCallLeaveApplicationSelf();
//            }
//            else if (SelectedLeaveMasterID == "") {
//                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectLeave", "SuccessMessage", "#FFCC80");
//                //$('#SuccessMessage').html("Please Select Leave Type.");
//                //$('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
//            }
//            else if (leaveRuleMasterID == 0) {
//                ajaxRequest.ErrorMessageWithOtherDateForJS("JsValidationMessages_NotAllotedToYou", "SuccessMessage", "#FFCC80", SelectedLeaveDescription, "left");
//                //$('#SuccessMessage').html(SelectedLeaveDescription + " Not Alloted To You.");
//                //$('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
//            }
//            else if (start == null || start == "") {
//                ajaxRequest.ErrorMessageForJS("JsValidationMessages_FromDateNotBlank", "SuccessMessage", "#FFCC80");
//                //$('#SuccessMessage').html("From Date should not be blank..");
//                //$('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
//            }
//            else if (end == null || end == "") {
//                ajaxRequest.ErrorMessageForJS("JsValidationMessages_UptoDateNotBlank", "SuccessMessage", "#FFCC80");
//                //$('#SuccessMessage').html("Upto Date should not be blank..");
//                //$('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
//            }

//        });


//        $('#CreateCompensatoryOffDayLeaveApplicationRecord').on("click", function () {
//            LeaveApplicationSelf.ActionName = "CreateCompOff";
//            LeaveApplicationSelf.getValueUsingParentTag_Check_UnCheck();
//            LeaveApplicationSelf.AjaxCallLeaveApplicationSelf();
//        });

//        $("#UserSearch").keyup(function () {
//            var oTable = $("#myDataTable").dataTable();
//            oTable.fnFilter(this.value);
//        });

//        $("#searchBtn").click(function () {
//            $("#UserSearch").focus();
//        });


//        $("#showrecord").change(function () {
//            var showRecord = $("#showrecord").val();
//            $("select[name*='myDataTable_length']").val(showRecord);
//            $("select[name*='myDataTable_length']").change();
//        });

//        $(".ajax").colorbox();

//        $('#FromDate').datepicker({
//            dateFormat: 'd-M-yy',
//            changeMonth: true,
//            changeYear: true,
//            onSelect: function (dateStr) {
//                var min = $(this).datepicker('getDate'); // Get selected date
//                $("#UptoDate").datepicker('option', 'minDate', min || '0'); // Set other min, default to today

//                var start = $("#FromDate").val();
//                var end = $("#UptoDate").val();
//                //  var LeaveMasterCode = $("#UptoDate").val();
//                var checkFlag = document.getElementById("IsSecondHalf").checked;
//                if (checkFlag == true) {
//                    if (start == end) {
//                        $('#IsFirstHalf').prop('checked', false);
//                        $('#IsSecondHalf').prop('checked', false);
//                    }
//                }

//                LeaveApplicationSelf.MyFunction();

//                $("#IsFirstHalf").removeAttr("disabled");
//                $("#UptoDate").removeAttr("disabled");
//            },
//            buttonImage: "/Content/images/calendar.gif",
//        });

//        $('#UptoDate').datepicker({

//            dateFormat: 'd-M-yy',
//            changeMonth: true,
//            changeYear: true,
//            onSelect: function (dateStr) {
//                var max = $(this).datepicker('getDate'); // Get selected date
//                $('#FromDate').datepicker('option', 'maxDate', max || '+1Y+6M'); // Set other max, default to +18 months

//                var start = $("#FromDate").val();
//                var end = $("#UptoDate").val();

//                var checkFlag = document.getElementById("IsSecondHalf").checked;
//                if (checkFlag == true) {
//                    if (start == end) {
//                        $('#IsFirstHalf').prop('checked', false);
//                        $('#IsSecondHalf').prop('checked', false);
//                    }
//                }

//                LeaveApplicationSelf.MyFunction();

//                $("#IsSecondHalf").removeAttr("disabled");
//                $("#CreateLeaveApplicationSelfRecord").show(true);

//            },
//            buttonImage: "/Content/images/calendar.gif",
//        });


//        $("#LeaveMasterID").change(function () {
//            $('#Div_DatesAndRemark').fadeOut();
//            var SelectedLeaveMasterID = $('#LeaveMasterID').val();
//            var SelectedLeaveDescription = $('#LeaveMasterID :selected').text();
//            var EmployeeID = $('input[name=EmployeeID]').val();
//            var LeaveSessionID = $('input[name=LeaveSessionID]').val();

//            //Clear Data
//            $("#CreateLeaveApplicationSelfRecord").hide(true);

//            $("#FromDate").val("");
//            $("#UptoDate").val("");
//            $("#LeaveReason").val("");
//            $('#ExtraLeave').val(0)
//            $('#IsFirstHalf').prop('checked', false);
//            $('#IsSecondHalf').prop('checked', false);

//            $("#UptoDate").attr("disabled", "disabled");
//            $("#IsFirstHalf").attr("disabled", "disabled");
//            $("#IsSecondHalf").attr("disabled", "disabled");

//            $('#totalLeaves').val("0");

//            if (SelectedLeaveMasterID != "") {
//                $.ajax(
//             {
//                 cache: false,
//                 type: "GET",
//                 data: { LeaveMasterID: SelectedLeaveMasterID, EmployeeID: EmployeeID, LeaveSessionID: LeaveSessionID },

//                 dataType: "html",
//                 url: '/LeaveApplicationSelf/GetLeaveDetailsByLeaveMaster_Employee_LeaveSessionID',

//                 success: function (result) {

//                     var aaa = result.replace('[', '');
//                     aaa = aaa.replace(']', '');
//                     var splitData = aaa.split(',');
//                     //Rebind Grid Data   

//                     $('#NumberOfLeaves').val(splitData[0]);
//                     $('#MaxLeaveAtTime').val(splitData[1]);
//                     $('#BalanceLeave').val(splitData[2]);
//                     $('#TotalBalanceLeaves').val(splitData[2]);
//                     $('#IsCompensatory').val(splitData[4]);
//                     if (splitData[8] == "0") {
//                         $("#FromDate").datepicker("option", "minDate", splitData[10]);
//                     }
//                     else {
//                         $("#FromDate").datepicker("option", "minDate", splitData[8]);
//                     }
//                     if (splitData[9] == "0") {
//                         $("#FromDate").datepicker("option", "maxDate", null);
//                         $("#UptoDate").datepicker("option", "maxDate", null);
//                     }
//                     else {
//                         $("#FromDate").datepicker("option", "maxDate", splitData[9]);
//                         $("#UptoDate").datepicker("option", "maxDate", splitData[9]);
//                     }
//                     if ($('#IsCompensatory').val() == 0) {

//                         LeaveApplicationSelf.HiddenBalanceLeave = splitData[2];
//                         if (splitData.length == 11) {
//                             $('input[name=LeaveRuleMasterID]').val(splitData[3]);
//                             $('#Div_DatesAndRemark').fadeIn();
//                             $('.content-wizard').fadeIn();
//                             $('#divCompensatoryOffDay').fadeOut();
//                             $('#btnSubmit').fadeIn();
//                             LeaveApplicationSelf.DocumentCompulsoryFlag = splitData[5];
//                             LeaveApplicationSelf.DocumentRequiredFlag = splitData[6];
//                             LeaveApplicationSelf.DocumentRequiredID = splitData[7];
//                             if (LeaveApplicationSelf.DocumentRequiredFlag > 0) {
//                                 $('#divAttachedDocument').fadeIn();
//                             }
//                             else {
//                                 $('#divAttachedDocument').fadeOut();
//                             }
//                         }
//                         else if (splitData.length == 10) {
//                             $('input[name=LeaveRuleMasterID]').val(0);
//                             $('#Div_DatesAndRemark').fadeOut();
//                             ajaxRequest.ErrorMessageWithOtherDateForJS("JsValidationMessages_NotAllotedToYou", "SuccessMessage", "#FFCC80", SelectedLeaveDescription, "left");
//                             $('#divCompensatoryOffDay').fadeOut();
//                             $('#btnSubmit').fadeIn();
//                             LeaveApplicationSelf.DocumentCompulsoryFlag = 0;
//                             LeaveApplicationSelf.DocumentRequiredFlag = 0;
//                             LeaveApplicationSelf.DocumentRequiredID = splitData[7];
//                         }
//                     }
//                     else {

//                         $('.content-wizard').fadeOut();
//                         $('#divbtnCreate').fadeOut();
//                         $('#divCompensatoryOffDay').fadeIn();
//                         var EmployeeID = $('input[name=EmployeeID]').val();
//                         var LeaveSessionID = $('input[name=LeaveSessionID]').val();
//                         $.ajax(
//                          {
//                              cache: false,
//                              type: "GET",
//                              dataType: "html",
//                              data: { EmployeeID: EmployeeID, LeaveSessionID: LeaveSessionID },
//                              dataType: "html",
//                              url: '/LeaveApplicationSelf/GetCompensatoryDayData',
//                              success: function (data) {
//                                  //Rebind Grid Data
//                                  $('#btnSubmit').fadeOut();
//                                  $('#divCompensatoryOffDay').html(data);

//                                  var table1 = $('#tblCompensatoryWorkDay').DataTable();
//                                  table1.$('input[type=text]').attr("disabled", "disabled");
//                                  if ($('#IsHalfDay').attr('checked') == 'checked') {
//                                      $("#tblCompensatoryWorkDay th").removeClass('hideColumn');

//                                  }
//                                  else {
//                                      table1.$('input[type=radio]').attr("disabled", "disabled");

//                                  }
//                                  $('#tblCompensatoryWorkDay_paginate').hide(true);
//                                  $('#tblCompensatoryWorkDay_info').hide(true);

//                              }
//                          });
//                         LeaveApplicationSelf.DocumentCompulsoryFlag = 0;
//                         LeaveApplicationSelf.DocumentRequiredFlag = 0;
//                         LeaveApplicationSelf.DocumentRequiredID = splitData[7];
//                     }
//                 }

//             });
//            }
//            else {
//                $('#Div_DatesAndRemark').fadeOut();
//                $('#divCompensatoryWorkDay').fadeOut('slow');
//                $('#CreateCompensatoryOffDayLeaveApplicationRecord').fadeOut('slow');

//            }
//        });

//        $("#IsFirstHalf").click(function () {

//            var start = $("#FromDate").val();
//            var end = $("#UptoDate").val();

//            var checkFlag = document.getElementById("IsFirstHalf").checked;
//            if (checkFlag == true) {
//                if (start == end) {
//                    $('#IsSecondHalf').prop('checked', false);
//                }
//            }
//            LeaveApplicationSelf.MyFunction();

//        });

//        $("#IsSecondHalf").click(function () {

//            var start = $("#FromDate").val();
//            var end = $("#UptoDate").val();

//            var checkFlag = document.getElementById("IsSecondHalf").checked;
//            if (checkFlag == true) {
//                if (start == end) {
//                    $('#IsFirstHalf').prop('checked', false);

//                }
//            }
//            LeaveApplicationSelf.MyFunction();

//        });

//        $('.ComensatoryOffDayDate').datepicker({
//            dateFormat: 'd-M-yy',
//        });

//        $("#tblCompensatoryWorkDay tbody tr td .displayStatus").click(function () {
//            if ($(this).prop("checked") == true) {
//                $("#tblCompensatoryWorkDay th").removeClass('hideColumn');
//                $("#tblCompensatoryWorkDay td").removeClass('hideColumn');
//                $(this).closest('tr').find('td').eq(4).find('div#displayRadio').removeClass('hideColumn');
//                $(this).closest('tr').find('td').eq(4).find('input[type=Radio]').removeAttr("disabled");
//                // document.getElementById("_first").checked = true;
//                $("#_first").prop("checked", true);
//            }
//            else {
//                $(this).closest('tr').find('td').eq(4).find('div#displayRadio').addClass('hideColumn');
//                $(this).closest('tr').find('td').eq(4).find('input[type=Radio]').removeAttr("checked");
//                $("#_first").prop("checked", false);
//            }
//        });

//        $("#tblCompensatoryWorkDay tbody tr td .enablerow").click(function () {
//            if ($(this).prop("checked") == true) {
//                $(this).closest('tr').find('td').eq(2).find('input[type=text]').removeAttr("disabled");
//                $(this).closest('tr').find('td').eq(5).find('input[type=text]').removeAttr("disabled");
//                if ($(this).closest('tr').find('td').eq(3).find('input[type=checkbox]').val().split('~')[2] == 0) {
//                    $(this).closest('tr').find('td').eq(3).find('input[type=checkbox]').removeAttr("disabled");
//                }
//            }
//            else {
//                $(this).closest('tr').find('td').eq(2).find('input[type=text]').attr("disabled", "disabled");
//                $(this).closest('tr').find('td').eq(5).find('input[type=text]').attr("disabled", "disabled");
//                $(this).closest('tr').find('td').eq(3).find('input[type=checkbox]').attr("disabled", "disabled");


//                if ($(this).closest('tr').find('td').eq(3).find('input[type=checkbox]').val().split('~')[2] == 0) {
//                    $(this).closest('tr').find('td').eq(3).find('input[type=checkbox]').removeAttr("checked");
//                    $(this).closest('tr').find('td').eq(4).find('div#displayRadio').addClass('hideColumn');
//                }
//            }
//        });

//        //var boxes = $('input[type=checkbox]').attr('disabled', true);                                //----Commented by Rajashri as it creates probelm at the time of Leave Against Compensatory Off Day Application
//        //What happens if the File changes?
//        $('#MyFile').change(function (evt) {



//            var f = evt.target.files[0];
//            var reader = new FileReader();
//            var image = new Image();
//            var maxSize = LeaveApplicationSelf.ValidateFileUpload();

//            if (maxSize == 1) {
//                //alert("Maximum file size exceeds,Your photo size should be less than 50 kb");
//                ajaxRequest.GeneralMessageAlertForJS("JsAlertMessages_MaximumFilesizeexceed");

//            }
//            else {


//            }
//            var currentdate = new Date();
//            var MyFileName = $('#MyFile').val().split('.');
//            $('input[name=FileName]').val($('input[name=EmployeeID]').val() + "/"
//                            + currentdate.getMinutes() + ":"
//                            + currentdate.getSeconds() + ":" + currentdate.getMilliseconds() + '.' + MyFileName[1]);

//        });


//    },

//    MyFunction: function () {
//        ;
//        var start = $("#FromDate").val();
//        var end = $("#UptoDate").val();
//        var checkFlag = document.getElementById("IsSecondHalf").checked;
//        if (checkFlag == true) {
//            if (start == end) {
//                $('#IsFirstHalf').prop('checked', false);
//            }
//        }

//        var checkValueFirstHalf = 0, checkValueSecondHalf = 0;
//        var days = 1, balanceLeave = 0, totalLeaves = 0;
//        //-------------------------------------------------------------------
//        var checkFlagIsFirstHalf = document.getElementById("IsFirstHalf").checked;
//        var checkFlagIsSecondHalf = document.getElementById("IsSecondHalf").checked;
//        //-------------------------------------------------------------------

//        LeaveApplicationSelf.totHalfday = 0;
//        if (checkFlagIsFirstHalf == true) {
//            checkValueFirstHalf = 0.5;
//            LeaveApplicationSelf.totHalfday = LeaveApplicationSelf.totHalfday + 1;
//        }
//        else {
//            checkValueFirstHalf = 0;
//            LeaveApplicationSelf.totHalfday = LeaveApplicationSelf.totHalfday + 0;
//        }
//        if (checkFlagIsSecondHalf == true) {
//            checkValueSecondHalf = 0.5;
//            LeaveApplicationSelf.totHalfday = LeaveApplicationSelf.totHalfday + 1;
//        }
//        else {
//            checkValueSecondHalf = 0;
//            LeaveApplicationSelf.totHalfday = LeaveApplicationSelf.totHalfday + 0;
//        }


//        var start = $("#FromDate").datepicker("getDate");
//        var end = $("#UptoDate").datepicker("getDate");

//        if (end != null && end != "") {
//            days = (end - start) / (1000 * 60 * 60 * 24);
//            if (start != end) {
//                days = days + 1;
//            }
//        }

//        totalLeaves = days - checkValueFirstHalf - checkValueSecondHalf;
//        balanceLeave = LeaveApplicationSelf.HiddenBalanceLeave - totalLeaves;
//        LeaveApplicationSelf.totalfullDaysLeave = totalLeaves - checkValueFirstHalf - checkValueSecondHalf;

//        if (balanceLeave < 0) {
//            var extraLeave = totalLeaves - LeaveApplicationSelf.HiddenBalanceLeave;
//            $('#BalanceLeave').val(0)
//            $('#ExtraLeave').val(extraLeave)

//        }
//        else {
//            $('#BalanceLeave').val(balanceLeave)
//            $('#ExtraLeave').val(0)
//        }

//        $('#totalLeaves').val(totalLeaves)

//    },
//    ////Load method is used to load *-Load-* page
//    LoadList: function () {

//        var EmployeeID = $('input[name=EmployeeID]').val();
//        var LeaveSessionID = $('input[name=LeaveSessionID]').val();
//        $.ajax(
//         {
//             cache: false,
//             type: "POST",
//             dataType: "html",
//             data: { "actionMode": null, EmployeeID: EmployeeID, LeaveSessionID: LeaveSessionID },
//             dataType: "html",
//             url: '/LeaveApplicationSelf/List',
//             success: function (data) {
//                 //Rebind Grid Data
//                 $('#ListViewModel').html(data);
//             }
//         });
//    },

//    //ReloadList method is used to load List page
//    ReloadList: function (message, colorCode, actionMode) {
//        var EmployeeID = $('input[name=EmployeeID]').val();
//        var LeaveSessionID = $('input[name=LeaveSessionID]').val();
//        $.ajax(
//        {
//            cache: false,
//            type: "POST",
//            dataType: "html",
//            data: { "actionMode": null, EmployeeID: EmployeeID, LeaveSessionID: LeaveSessionID },
//            url: '/LeaveApplicationSelf/List',
//            success: function (data) {
//                //Rebind Grid Data
//                $("#ListViewModel").empty().append(data);
//                //twitter type notification
//                $('#SuccessMessage').html(message);
//                $('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', colorCode);


//            }
//        });
//    },

//    //Fire ajax call to insert update and delete record
//    AjaxCallLeaveApplicationSelf: function () {
//        var LeaveApplicationSelfData = null;
//        if (LeaveApplicationSelf.ActionName == "Create") {
//            $("#FormCreateLeaveApplicationSelf").validate();
//            if ($("#FormCreateLeaveApplicationSelf").valid()) {
//                LeaveApplicationSelfData = null;
//                LeaveApplicationSelfData = LeaveApplicationSelf.GetLeaveApplicationSelf();
//                ajaxRequest.makeRequest("/LeaveApplicationSelf/Create", "POST", LeaveApplicationSelfData, LeaveApplicationSelf.Success);
//                if ($('#MyFile').val() != null) {
//                    $('#FormCreateLeaveApplicationSelf').submit();
//                }
//            }
//        }
//        else if (LeaveApplicationSelf.ActionName == "CreateCompOff") {
//            if ($("#FormCreateLeaveApplicationSelf").valid()) {
//                LeaveApplicationSelfData = null;
//                LeaveApplicationSelfData = LeaveApplicationSelf.GetLeaveApplicationSelf();
//                ajaxRequest.makeRequest("/LeaveApplicationSelf/Create", "POST", LeaveApplicationSelfData, LeaveApplicationSelf.Success);
//            }
//        }
//    },

//    //Get properties data from the Create, Update and Delete page
//    GetLeaveApplicationSelf: function () {
//        ;

//        var Data = {
//        };
//        if (LeaveApplicationSelf.ActionName == "Create") {
//            Data.EmployeeID = $('input[name=EmployeeID]').val();
//            Data.LeaveMasterID = $('#LeaveMasterID').val();
//            Data.FromDate = $('#FromDate').val();
//            Data.UptoDate = $('#UptoDate').val();
//            Data.TotalHalfDayLeave = LeaveApplicationSelf.totHalfday;
//            Data.TotalfullDaysLeave = LeaveApplicationSelf.totalfullDaysLeave;

//            Data.IsFirstHalf = document.getElementById("IsFirstHalf").checked;
//            Data.IsSecondHalf = document.getElementById("IsSecondHalf").checked;


//            //  Data.HalfLeaveStatus = LeaveApplicationSelf.HalfLeaveStatus;
//            Data.LeaveReason = $('#LeaveReason').val();
//            Data.LeaveSessionID = $('input[name=LeaveSessionID]').val();
//            Data.CentreCode = $('input[name=CentreCode]').val();
//            Data.LeaveRuleMasterID = $('input[name=LeaveRuleMasterID]').val();
//            Data.SelectedIDs = '';
//            Data.FileName = $('input[name=FileName]').val();
//            if (Data.FileName != "") {
//                Data.DocumentRequiredID = LeaveApplicationSelf.DocumentRequiredID;
//            }
//            else {
//                Data.DocumentRequiredID = 0;
//            }

//        }
//        else if (LeaveApplicationSelf.ActionName == "CreateCompOff") {

//            Data.EmployeeID = $('input[name=EmployeeID]').val();
//            Data.LeaveMasterID = $('#LeaveMasterID').val();
//            Data.LeaveSessionID = $('input[name=LeaveSessionID]').val();
//            Data.CentreCode = $('input[name=CentreCode]').val();
//            Data.LeaveRuleMasterID = $('#_LeaveRuleMasterID').val();
//            Data.SelectedIDs = LeaveApplicationSelf.SelectedIDs;

//            Data.FromDate = '';
//            Data.UptoDate = '';
//            Data.TotalHalfDayLeave = 0;
//            Data.TotalfullDaysLeave = 0;
//            Data.IsFirstHalf = 0;
//            Data.IsSecondHalf = 0;
//            Data.LeaveReason = '';
//            Data.DocumentRequiredID = LeaveApplicationSelf.DocumentRequiredID;
//            Data.FileName = '';

//        }

//        return Data;
//    },

//    //this is used to for showing successfully record creation message and reload the list view
//    Success: function (data) {
//        ;
//        var splitData = data.split(',');
//        if (data != null) {
//            //parent.$.colorbox.close();
//            LeaveApplicationSelf.ReloadList(splitData[0], splitData[1], splitData[2]);
//            LeaveApplicationSelf.Reset();
//        } else {
//            //parent.$.colorbox.close();
//            LeaveApplicationSelf.ReloadList(splitData[0], splitData[1], splitData[2]);
//        }

//    },

//    Reset: function () {

//        $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
//        $('input:checkbox,input:radio').removeAttr('checked');
//        $('#LeaveMasterID').focus();
//        $('#LeaveMasterID').val("");
//        $('#NumberOfLeaves').val(0);
//        $('#MaxLeaveAtTime').val(0);
//        $('#totalLeaves').val(0);
//        $('#BalanceLeave').val(0);
//        $('#ExtraLeave').val(0);
//        $('#Div_DatesAndRemark').fadeOut('slow');
//        $('#divCompensatoryWorkDay').fadeOut('slow');
//        $('#CreateCompensatoryOffDayLeaveApplicationRecord').fadeOut('slow');
//    },

//    getValueUsingParentTag_Check_UnCheck: function () {

//        var AllDataArray = [];
//        var table = $('#tblCompensatoryWorkDay').DataTable();
//        var data = table.$('input,select,input tag').each(function () {
//            AllDataArray.push($(this).val());
//        });

//        var sList = "";
//        var xmlParamList = "<rows>";
//        var DataArray = [];
//        var CheckArray = [];
//        var UnCheckArray = [];
//        var sArray = [];
//        var radioArray = [];
//        var DatatableData, TotalRecord, TotalRow;
//        $('#tblCompensatoryWorkDay input[type=checkbox]').each(function () {
//            if ($(this).val() != "on") {
//                var a = $(this).val();
//                sArray = $(this).val().split("~");
//                if (this.checked == true) {
//                    //xmlInsert code here                    
//                    if (a.length == 1) {
//                        CheckArray = CheckArray + ',' + a + '~' + 'T';
//                    }
//                }
//                else if (this.checked == false) {
//                    //xmlUpdate code here
//                    UnCheckArray = UnCheckArray + ',' + a + '~' + 'F';
//                }
//            }
//        });

//        $('#tblCompensatoryWorkDay input[type=radio]').each(function () {
//            if ($(this).val() != "on") {
//                var a = $(this).val();               
//                var splited_a = $(this).val().split("~");
//                if (this.checked == true) {
//                    //xmlInsert code here
//                    var y = 1;
//                    for (; y <= CheckArray.length;) {
//                        if (splited_a[0] == CheckArray[y]) {
//                            radioArray = radioArray + ',' + a;
//                            //  alert(CheckArray);
//                        }
//                        y = y + 4;
//                    }
//                }
//            }
//        });

//        sArray = CheckArray.split(',');
//        TotalRecord = sArray.length;


//        TotalRecordForDataArray = AllDataArray.length;

//        var splitedArray = [];
//        var splitedArrayForReq = [];
//        var splitedArrayForHalfDay = [];
//        var splitedArrayForRadio = [];
//        var i = 1;
//        var j = 2;
//        var k = 3;
//        var p = 2;
//        var q = 1;
//        var r = 6;
//        var x = 0;

//        for (; i < TotalRecord ;) {
//            splitedArrayForReq = sArray[i].split('~');
//            if (i + 1 <= TotalRecord) {
//                if (splitedArrayForHalfDay.length > 0) {
//                    splitedArrayForHalfDay = sArray[i].split('~');                                  //  splitedArrayForHalfDay = sArray[i+1].split('~');
//                }
//                else {
//                    splitedArrayForHalfDay[2] = 'F'
//                }
//                if (splitedArrayForReq.length == 2) {
//                    if (splitedArrayForHalfDay[2] == 'T') {
//                        splitedArrayForRadio = radioArray.split(',');
//                        if ((splitedArrayForRadio[q].split('~'))[0] == splitedArrayForReq[0]) {
//                            if ((splitedArrayForRadio[q].split('~'))[1] == 'First') {
//                                xmlParamList = xmlParamList + "<row>" + "<ID>" + splitedArrayForReq[0] + "</ID>" + "<FromDate>" + AllDataArray[p] + "</FromDate>" + "<UptoDate>" + AllDataArray[p] + "</UptoDate>" + "<IsFirstHalf>" + 1 + "</IsFirstHalf>" + "<IsSecondHalf>" + 0 + "</IsSecondHalf>" + "<LeaveReason>" + AllDataArray[p + 4] + "</LeaveReason><TotalHalfDayLeave>" + 1 + "</TotalHalfDayLeave><TotalfullDaysLeave>" + 0 + "</TotalfullDaysLeave>" + "</row>";
//                            }
//                            else {
//                                xmlParamList = xmlParamList + "<row>" + "<ID>" + splitedArrayForReq[0] + "</ID>" + "<FromDate>" + AllDataArray[p] + "</FromDate>" + "<UptoDate>" + AllDataArray[p] + "</UptoDate>" + "<IsFirstHalf>" + 0 + "</IsFirstHalf>" + "<IsSecondHalf>" + 1 + "</IsSecondHalf>" + "<LeaveReason>" + AllDataArray[p + 4] + "</LeaveReason><TotalHalfDayLeave>" + 1 + "</TotalHalfDayLeave><TotalfullDaysLeave>" + 0 + "</TotalfullDaysLeave>" + "</row>";
//                            }
//                        }
//                    }
//                    else {

//                        if (radioArray.length > 0) {
//                            var splitedArrayForRadio1 = radioArray.split(',');
//                            splitedArrayForRadio = splitedArrayForRadio1[q].split('~');
//                            if (splitedArrayForRadio[0] == splitedArrayForReq[0]) {                                         //(splitedArrayForRadio[q - 1] == splitedArrayForReq[0])
//                                for (; x < AllDataArray.length;) {
//                                    if (AllDataArray[x] == splitedArrayForReq[0]) {
//                                        if (splitedArrayForRadio[1] == 'First') {
//                                            xmlParamList = xmlParamList + "<row>" + "<ID>" + splitedArrayForReq[0] + "</ID>" + "<FromDate>" + AllDataArray[p] + "</FromDate>" + "<UptoDate>" + AllDataArray[p] + "</UptoDate>" + "<IsFirstHalf>" + 1 + "</IsFirstHalf>" + "<IsSecondHalf>" + 0 + "</IsSecondHalf>" + "<LeaveReason>" + AllDataArray[p + 4] + "</LeaveReason><TotalHalfDayLeave>" + 1 + "</TotalHalfDayLeave><TotalfullDaysLeave>" + 0 + "</TotalfullDaysLeave>" + "</row>";
//                                        }
//                                        else {
//                                            xmlParamList = xmlParamList + "<row>" + "<ID>" + splitedArrayForReq[0] + "</ID>" + "<FromDate>" + AllDataArray[p] + "</FromDate>" + "<UptoDate>" + AllDataArray[p] + "</UptoDate>" + "<IsFirstHalf>" + 0 + "</IsFirstHalf>" + "<IsSecondHalf>" + 1 + "</IsSecondHalf>" + "<LeaveReason>" + AllDataArray[p + 4] + "</LeaveReason><TotalHalfDayLeave>" + 1 + "</TotalHalfDayLeave><TotalfullDaysLeave>" + 0 + "</TotalfullDaysLeave>" + "</row>";
//                                        }
//                                    }
//                                    else {
//                                        p = p + 8;
//                                    }
//                                    x = x + 8;
//                                }
//                                var p = 2;
//                            }
//                        }
//                        else {

//                            for (; x < AllDataArray.length;) {
//                                if (AllDataArray[x] == splitedArrayForReq[0]) {
//                                    xmlParamList = xmlParamList + "<row>" + "<ID>" + splitedArrayForReq[0] + "</ID>" + "<FromDate>" + AllDataArray[p] + "</FromDate>" + "<UptoDate>" + AllDataArray[p] + "</UptoDate>" + "<IsFirstHalf>" + 0 + "</IsFirstHalf>" + "<IsSecondHalf>" + 0 + "</IsSecondHalf>" + "<LeaveReason>" + AllDataArray[p + 4] + "</LeaveReason><TotalHalfDayLeave>" + 0 + "</TotalHalfDayLeave><TotalfullDaysLeave>" + 1 + "</TotalfullDaysLeave>" + "</row>";
//                                }
//                                else {
//                                    p = p + 8;
//                                }
//                                x = x + 8;
//                            }

//                        }
//                    }
//                }
//            }
//            else {
//                for (; x < AllDataArray.length;) {

//                    if (AllDataArray[x] == splitedArrayForReq[0]) {
//                        xmlParamList = xmlParamList + "<row>" + "<ID>" + splitedArrayForReq[0] + "</ID>" + "<FromDate>" + AllDataArray[p] + "</FromDate>" + "<UptoDate>" + AllDataArray[p] + "</UptoDate>" + "<IsFirstHalf>" + 0 + "</IsFirstHalf>" + "<IsSecondHalf>" + 0 + "</IsSecondHalf>" + "<LeaveReason>" + AllDataArray[p + 4] + "</LeaveReason><TotalHalfDayLeave>" + 0 + "</TotalHalfDayLeave><TotalfullDaysLeave>" + 1 + "</TotalfullDaysLeave>" + "</row>";
//                    }
//                    else {
//                        p = p + 8;
//                    }
//                    x = x + 8;
//                }
//            }
//            i = i + 1;
//            q = q + 1;
//            j = j + 2;
//            p = 2;
//            x = 0;
//        }
//        LeaveApplicationSelf.SelectedIDs = xmlParamList + "</rows>";
//        //alert(LeaveApplicationSelf.SelectedIDs);

//    },

//    ValidateFileUpload: function () {

//        var fuData = document.getElementById('MyFile');
//        var FileUploadPath = fuData.value;


//        if (FileUploadPath == '') {
//            // alert("Please upload an image");
//            ajaxRequest.GeneralMessageAlertForJS("JsAlertMessages_PleaseUploadimage");

//        } else {
//            var Extension = FileUploadPath.substring(FileUploadPath.lastIndexOf('.') + 1).toLowerCase();



//            if (Extension == "pdf" || Extension == "gif" || Extension == "png" || Extension == "bmp"
//                        || Extension == "jpeg" || Extension == "jpg") {


//                if (fuData.files && fuData.files[0]) {

//                    var size = fuData.files[0].size;
//                    //alert(size);

//                    if (size > 400000) {
//                        return 1;
//                    } else {
//                        var reader = new FileReader();

//                        reader.onload = function (e) {
//                            $('#blah').attr('src', e.target.result);
//                        }

//                        reader.readAsDataURL(fuData.files[0]);
//                    }
//                }

//            }


//            else {
//                //alert("Photo only allows file types of GIF, PNG, JPG, JPEG and BMP. ");
//                ajaxRequest.GeneralMessageAlertForJS("JsAlertMessages_PhotoOnlyallowfiletypeof");
//                FileUploadPath = '';
//                $('#MyFile').val('');
//            }
//        }
//    },
//    //Check one of the checkboxes



//};

/////////////////////////////////////////////new js//////////////////////////////////
//this class contain methods related to nationality functionality
var LeaveApplicationSelf = {
    //Member variables
    ActionName: null,
    totHalfday: null,
    HiddenBalanceLeave: 0,
    HiddenLeaveSessionID: 0,
    totalfullDaysLeave: 0,
    DocumentCompulsoryFlag: null,
    DocumentRequiredFlag: null,
    DocumentRequiredID: 0,
    SelectedIDs: null,
    FileName_N: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();
        LeaveApplicationSelf.constructor();
        //LeaveApplicationSelf.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#LeaveMasterID').focus();
        $("#reset").click(function () {
            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked'); .0
            $('#LeaveMasterID').focus();
            return false;
        });
        // Create new record
        $('#CreateLeaveApplicationSelfRecord').on("click", function () {
            var start = $("#FromDate").val();
            var end = $("#UptoDate").val();
            var leaveRuleMasterID = $('input[name=LeaveRuleMasterID]').val();
            var SelectedLeaveMasterID = $('#LeaveMasterID').val();
            var SelectedLeaveDescription = $('#LeaveMasterID :selected').text();


            if (start != null && start != "" && end != null && end != "" && leaveRuleMasterID != 0 && SelectedLeaveMasterID != 0) {

                LeaveApplicationSelf.ActionName = "Create";
                LeaveApplicationSelf.AjaxCallLeaveApplicationSelf();
            }
            else if (SelectedLeaveMasterID == "") {
                notify("Please Select Leave Type.", "danger");
            }
            else if (leaveRuleMasterID == 0) {
                notify(SelectedLeaveDescription + "Not Alloted To You.", "danger");
            }
            else if (start == null || start == "") {
                notify("Date should not be blank.", "danger");
            }
            else if (end == null || end == "") {
                notify("Upto Date should not be blank.", "danger");
            }

        });
        $('#CreateCompensatoryOffDayLeaveApplicationRecord').on("click", function () {
            LeaveApplicationSelf.ActionName = "CreateCompOff";
            LeaveApplicationSelf.getValueUsingParentTag_Check_UnCheck();
            LeaveApplicationSelf.AjaxCallLeaveApplicationSelf();
        });

        $("#UserSearch").keyup(function () {
            var oTable = $("#myDataTable").DataTable();
            oTable.fnFilter(this.value);
        });

        $("#searchBtn").click(function () {
            $("#UserSearch").focus();
        });
        $("#showrecord").change(function () {
            var showRecord = $("#showrecord").val();
            $("select[name*='myDataTable_length']").val(showRecord);
            $("select[name*='myDataTable_length']").change();
        });
        InitAnimatedBorder();
        CloseAlert();

        $(function () {
            $('#FromDate').datetimepicker({
                format: 'DD MMMM YYYY',
                //maxDate: moment(),
                ignoreReadonly: true,
                //defaultDate: new Date(),
            });

            $('#UptoDate').datetimepicker({
                format: 'DD MMMM YYYY',
                ignoreReadonly: true,
            });
            //used dp.hide instead of dp.change
            $('#FromDate').on("dp.hide", function (e) {
                var minDate = new Date(e.date.valueOf());
                minDate.setDate(minDate.getDate());

                $('#UptoDate').data("DateTimePicker").minDate(minDate);
                var start = $("#FromDate").val();
                var end = $("#UptoDate").val();
                var checkFlag = document.getElementById("IsSecondHalf").checked;
                if (checkFlag == true) {
                    if (start == end) {
                        $('#IsFirstHalf').prop('checked', false);
                        $('#IsSecondHalf').prop('checked', false);
                    }
                }
                LeaveApplicationSelf.MyFunction();
                $("#IsFirstHalf").removeAttr("disabled");
                $("#UptoDate").removeAttr("disabled");
            });


            //used dp.hide instead of dp.change
            $("#UptoDate").on("dp.hide", function (e) {
                var maxDate = new Date(e.date.valueOf());
                maxDate.setDate(maxDate.getDate());
                $('#FromDate').data("DateTimePicker").maxDate(maxDate);

                var start = $("#FromDate").val();
                var end = $("#UptoDate").val();

                var checkFlag = document.getElementById("IsSecondHalf").checked;
                if (checkFlag == true) {
                    if (start == end) {
                        $('#IsFirstHalf').prop('checked', false);
                        $('#IsSecondHalf').prop('checked', false);
                    }
                }

                LeaveApplicationSelf.MyFunction();
                $("#IsSecondHalf").removeAttr("disabled");
                $("#CreateLeaveApplicationSelfRecord").show(true);
            });
        });
        //$('#UptoDate').datepicker({

        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    onSelect: function (dateStr) {
        //        var max = $(this).datepicker('getDate'); // Get selected date
        //        $('#FromDate').datepicker('option', 'maxDate', max || '+1Y+6M'); // Set other max, default to +18 months

        //        var start = $("#FromDate").val();
        //        var end = $("#UptoDate").val();

        //        var checkFlag = document.getElementById("IsSecondHalf").checked;
        //        if (checkFlag == true) {
        //            if (start == end) {
        //                $('#IsFirstHalf').prop('checked', false);
        //                $('#IsSecondHalf').prop('checked', false);
        //            }
        //        }

        //        LeaveApplicationSelf.MyFunction();

        //        $("#IsSecondHalf").removeAttr("disabled");
        //        $("#CreateLeaveApplicationSelfRecord").show(true);

        //    },
        //    buttonImage: "/Content/images/calendar.gif",
        //});






        $("#LeaveMasterID").change(function () {
            //$('#Div_DatesAndRemark').fadeIn();
            $('#Div_DatesAndRemark').fadeOut();
            var SelectedLeaveMasterID = $('#LeaveMasterID').val();
            var SelectedLeaveDescription = $('#LeaveMasterID :selected').text();
            var EmployeeID = $('input[name=EmployeeID]').val();
            var LeaveSessionID = $('input[name=LeaveSessionID]').val();
            //Clear Data
            $("#CreateLeaveApplicationSelfRecord").hide(true);
            $("#FromDate").val("");
            $("#UptoDate").val("");
            $("#LeaveReason").val("");
            $('#ExtraLeave').val(0)
            $('#IsFirstHalf').prop('checked', false);
            $('#IsSecondHalf').prop('checked', false);
            $("#UptoDate").attr("disabled", "disabled");
            $("#IsFirstHalf").attr("disabled", "disabled");
            $("#IsSecondHalf").attr("disabled", "disabled");
            $('#totalLeaves').val("0");
            if (SelectedLeaveMasterID != "") {
                $.ajax(
             {
                 cache: false,
                 type: "GET",
                 data: { LeaveMasterID: SelectedLeaveMasterID, EmployeeID: EmployeeID, LeaveSessionID: LeaveSessionID },

                 dataType: "html",
                 url: '/LeaveApplicationSelf/GetLeaveDetailsByLeaveMaster_Employee_LeaveSessionID',
                 success: function (result) {
                     var aaa = result.replace('[', '');
                     aaa = aaa.replace(']', '');
                     var splitData = aaa.split(',');
                     //Rebind Grid Data   
                     $('#NumberOfLeaves').val(splitData[0]);
                     $('#MaxLeaveAtTime').val(splitData[1]);
                     $('#BalanceLeave').val(splitData[2]);
                     $('#TotalBalanceLeaves').val(splitData[2]);
                     $('#IsCompensatory').val(splitData[4]);
                     //if (splitData[8] == "0") {
                     //    ////$("#FromDate").datepicker("option", "minDate", splitData[10]);
                     //    var minDate = new Date();
                     //    var minDateScope = parseInt(minDate.getDate()) + parseInt(splitData[10]);
                     //    //minDate.setDate(minDate.getDate() - (-splitData[10]));
                     //    minDate.setDate(minDateScope);
                     //    $('#FromDate').data("DateTimePicker").minDate(minDate);
                     //    //alert(minDate + "min date")
                     //    ////var minDate = new Date(splitData[10]);
                     //    ////minDate.setDate(minDate.getDate());

                     //}
                     //else {
                     //    //$("#FromDate").datepicker("option", "minDate", splitData[8]);
                     //    var minDate = new Date();
                     //    var scopedate = parseInt(minDate.getDate()) + parseInt(splitData[8]);
                     //    //minDate.setDate(minDate.getDate() - splitData[8]);
                     //    minDate.setDate(scopedate);
                     //    $('#FromDate').data("DateTimePicker").minDate(minDate);

                     //    //var minDate = new Date(splitData[8]);
                     //    //minDate.setDate(minDate.getDate());
                     //    //$('#FromDate').data("DateTimePicker").minDate(minDate);
                     //}
                     //if (splitData[9] == "0") {

                     //    //$("#FromDate").datepicker("option", "maxDate", null);
                     //    //$("#UptoDate").datepicker("option", "maxDate", null);
                     //    $('#FromDate').data("DateTimePicker").maxDate(null);
                     //    $('#UptoDate').data("DateTimePicker").maxDate(null);
                     //}
                     //else {
                     //    //$("#FromDate").datepicker("option", "maxDate", splitData[9]);
                     //    //$("#UptoDate").datepicker("option", "maxDate", splitData[9]);
                     //    var maxDate = new Date();
                     //    maxDate.setDate(maxDate.getDate() + splitData[9]);
                     //    $('#FromDate').data("DateTimePicker").maxDate(maxDate);
                     //    $('#UptoDate').data("DateTimePicker").maxDate(maxDate);
                     //}
                     //-------------------------New code for validation on date ----------------------------
                     if (splitData[8] == "0" && splitData[9] != "0") {
                         debugger;
                             var minDate = new Date();
                             var maxDate = new Date();
                             var minDate1 = minDate.getDate();
                             maxDate.setDate(minDate1);
                             var minDateScope = parseInt(minDate.getDate())-parseInt(splitData[10]);
                             minDate.setDate(minDateScope);
                             $('#FromDate').data("DateTimePicker").minDate(minDate);
                             $('#UptoDate').data("DateTimePicker").minDate(minDate);
                             $('#FromDate').data("DateTimePicker").maxDate(maxDate);
                             $('#UptoDate').data("DateTimePicker").maxDate(maxDate);
                           
                         }
                      
                     if (splitData[8] != "0" && splitData[9] != "0") {
                         debugger;
                             var minDate = new Date();
                             var maxDate = new Date();
                             var minDateScope = parseInt(minDate.getDate()) - parseInt(splitData[10]);
                             minDate.setDate(minDateScope);
                             $('#FromDate').data("DateTimePicker").minDate(minDate);
                             $('#UptoDate').data("DateTimePicker").minDate(minDate);
                             var maxScope = parseInt(minDate.getDate()) + parseInt(splitData[12]);
                             maxDate.setDate(maxScope);
                             $('#FromDate').data("DateTimePicker").maxDate(maxDate);
                             $('#UptoDate').data("DateTimePicker").maxDate(maxDate);
                          
                         }
                       
                     if (splitData[8] != "0" && splitData[9] == "0") {
                         debugger;
                         var minDate = new Date();
                         var maxDate = new Date();
                         var minDateScope = parseInt(minDate.getDate()) + parseInt(splitData[8]);
                         minDate.setDate(minDateScope);
                         var maxScope = parseInt(maxDate.getDate()) + parseInt(splitData[8]);
                         maxDate.setDate(maxScope);
                       /*  $('#FromDate').data("DateTimePicker").maxDate(maxDate);
                         $('#UptoDate').data("DateTimePicker").maxDate(maxDate);*/
                         $('#FromDate').data("DateTimePicker").minDate(minDate);
                         $('#UptoDate').data("DateTimePicker").minDate(minDate);
                         
                     }

                     if ($('#IsCompensatory').val() == 0) {
                         LeaveApplicationSelf.HiddenBalanceLeave = splitData[2];
                         if (splitData.length == 13) {
                             $('input[name=LeaveRuleMasterID]').val(splitData[3]);
                             $('#Div_DatesAndRemark').fadeIn();
                             $('.content-wizard').fadeIn();
                             $('#divCompensatoryOffDay').fadeOut();
                             $('#btnSubmit').fadeIn();
                             LeaveApplicationSelf.DocumentCompulsoryFlag = splitData[5];
                             LeaveApplicationSelf.DocumentRequiredFlag = splitData[6];
                             LeaveApplicationSelf.DocumentRequiredID = splitData[7];
                             if (LeaveApplicationSelf.DocumentRequiredFlag > 0) {
                                 $('#divAttachedDocument').fadeIn();
                             }
                             else {
                                 $('#divAttachedDocument').fadeOut();
                             }
                         }
                         else if (splitData.length == 12) {
                             $('input[name=LeaveRuleMasterID]').val(0);
                             $('#Div_DatesAndRemark').fadeOut();
                             ajaxRequest.ErrorMessageWithOtherDateForJS("JsValidationMessages_NotAllotedToYou", "SuccessMessage", "#FFCC80", SelectedLeaveDescription, "left");
                             $('#divCompensatoryOffDay').fadeOut();
                             $('#btnSubmit').fadeIn();
                             LeaveApplicationSelf.DocumentCompulsoryFlag = 0;
                             LeaveApplicationSelf.DocumentRequiredFlag = 0;
                             LeaveApplicationSelf.DocumentRequiredID = splitData[7];
                         }
                     }
                     else {

                         $('.content-wizard').fadeOut();
                         $('#divbtnCreate').fadeOut();
                         $('#divCompensatoryOffDay').fadeIn();
                         var EmployeeID = $('input[name=EmployeeID]').val();
                         var LeaveSessionID = $('input[name=LeaveSessionID]').val();
                         $.ajax(
                          {
                              cache: false,
                              type: "GET",
                              dataType: "html",
                              data: { EmployeeID: EmployeeID, LeaveSessionID: LeaveSessionID },
                              dataType: "html",
                              url: '/LeaveApplicationSelf/GetCompensatoryDayData',
                              success: function (data) {
                                  //Rebind Grid Data
                                  $('#btnSubmit').fadeOut();
                                  $('#divCompensatoryOffDay').html(data);

                                  var table1 = $('#tblCompensatoryWorkDay').DataTable();
                                  table1.$('input[type=text]').attr("disabled", "disabled");
                                  if ($('#IsHalfDay').attr('checked') == 'checked') {
                                      $("#tblCompensatoryWorkDay th").removeClass('hideColumn');
                                  }
                                  else {
                                      table1.$('input[type=radio]').attr("disabled", "disabled");

                                  }
                                  $('#tblCompensatoryWorkDay_paginate').hide(true);
                                  $('#tblCompensatoryWorkDay_info').hide(true);
                              }
                          });
                         LeaveApplicationSelf.DocumentCompulsoryFlag = 0;
                         LeaveApplicationSelf.DocumentRequiredFlag = 0;
                         LeaveApplicationSelf.DocumentRequiredID = splitData[7];
                     }
                 }
             });
            }
            else {
                $('#Div_DatesAndRemark').fadeOut();
                $('#divCompensatoryWorkDay').fadeOut('slow');
                $('#CreateCompensatoryOffDayLeaveApplicationRecord').fadeOut('slow');
            }
        });

        $("#IsFirstHalf").click(function () {
            var start = $("#FromDate").val();
            var end = $("#UptoDate").val();
            var checkFlag = document.getElementById("IsFirstHalf").checked;
            if (checkFlag == true) {
                if (start == end) {
                    $('#IsSecondHalf').prop('checked', false);
                }
            }
            LeaveApplicationSelf.MyFunction();
        });

        $("#IsSecondHalf").click(function () {
            var start = $("#FromDate").val();
            var end = $("#UptoDate").val();
            var checkFlag = document.getElementById("IsSecondHalf").checked;
            if (checkFlag == true) {
                if (start == end) {
                    $('#IsFirstHalf').prop('checked', false);

                }
            }
            LeaveApplicationSelf.MyFunction();

        });
        $('.ComensatoryOffDayDate').datetimepicker({
            format: 'DD MMMM YYYY',
            //minDate: moment(),
            ignoreReadonly: true,
            //onSelectDate: function () { }
        });
        $("#tblCompensatoryWorkDay tbody tr td .displayStatus").click(function () {
            var displayStatus = ($(this).closest('tr').find('td .displayStatus').val());
            var aa = displayStatus;
            var bb = aa.split('~');
            var displayRadio = ($(this).closest('tr').find('div#displayRadio').val());
            //if($(this).prop("checked") == true){
            //    //alert($(this).closest('tr').find('td').eq(4).find('div label input[id="_first"]'))
            //    displayStatus = $(this).closest('tr').find('td').eq(4).find('div label input[id="_first"]').prop('checked', true);
            //}

            var $this = $(this);
            if ($this.is(":checked")) {
                $(this).closest("tr").find('td input[id="_first"]').attr("disabled", false).prop('checked', true);
                $(this).closest("tr").find('td input[id="_second"]').attr("disabled", false);
            }
            else {
                $(this).closest("tr").find('td input[id="_first"]').prop('checked', false);
                $(this).closest("tr").find('td input[id="_first"]').attr("disabled", true);
                $(this).closest("tr").find('td input[id="_second"]').prop('checked', false);
                $(this).closest("tr").find('td input[id="_second"]').attr("disabled", true);
            }
        });

        $("#tblCompensatoryWorkDay tbody tr td .enablerow").click(function () {
            if ($(this).prop("checked") == true) {
                $(this).closest('tr').find('td').eq(2).find('input[type=text]').removeAttr("disabled");
                $(this).closest('tr').find('td').eq(5).find('input[type=text]').removeAttr("disabled");
                if ($(this).closest('tr').find('td').eq(3).find('input[type=checkbox]').val().split('~')[2] == 1) {
                    //$(this).closest('tr').find('td').eq(3).find('input[type=checkbox]').removeAttr("disabled");
                    $(this).closest('tr').find('td').eq(4).find('div#displayRadio').removeClass('hideColumn');
                    $(this).closest('tr').find('td').eq(4).find('input[type=radio]').removeAttr("disabled", "disabled");
                }
            }
            else {
                $(this).closest('tr').find('td').eq(2).find('input[type=text]').attr("disabled", "disabled").val('');
                $(this).closest('tr').find('td').eq(5).find('input[type=text]').attr("disabled", "disabled").val('');
                $(this).closest('tr').find('td').eq(3).find('input[type=checkbox]').attr("disabled", "disabled");
                $(this).closest('tr').find('td').eq(4).find('input[type=radio]').attr("disabled", "disabled");
                if ($(this).closest('tr').find('td').eq(3).find('input[type=checkbox]').val().split('~')[2] == 0) {
                    $(this).closest('tr').find('td').eq(3).find('input[type=checkbox]').removeAttr("checked");
                    $(this).closest('tr').find('td').eq(4).find('div#displayRadio').addClass('hideColumn');
                }
            }
        });
        //var boxes = $('input[type=checkbox]').attr('disabled', true);                                //----Commented by Rajashri as it creates probelm at the time of Leave Against Compensatory Off Day Application
        //What happens if the File changes?
        $('#MyFile').change(function (evt) {
            var f = evt.target.files[0];
            var reader = new FileReader();
            var image = new Image();
            var maxSize = LeaveApplicationSelf.ValidateFileUpload();
            if (maxSize == 1) {
                //alert("Maximum file size exceeds,Your photo size should be less than 50 kb");
                ajaxRequest.GeneralMessageAlertForJS("JsAlertMessages_MaximumFilesizeexceed");

            }
            else {
            }
            var currentdate = new Date();
            var MyFileName = $('#MyFile').val().split('.');
            $('input[name=FileName]').val($('input[name=EmployeeID]').val() + "/"
                            + currentdate.getMinutes() + ":"
                            + currentdate.getSeconds() + ":" + currentdate.getMilliseconds() + '.' + MyFileName[1]);

        });
    },
    MyFunction: function () {
        var start = $("#FromDate").val();
        var end = $("#UptoDate").val();
        var checkFlag = document.getElementById("IsSecondHalf").checked;
        if (checkFlag == true) {
            if (start == end) {
                $('#IsFirstHalf').prop('checked', false);
            }
        }
        var checkValueFirstHalf = 0, checkValueSecondHalf = 0;
        var days = 1, balanceLeave = 0, totalLeaves = 0;
        //-------------------------------------------------------------------
        var checkFlagIsFirstHalf = document.getElementById("IsFirstHalf").checked;
        var checkFlagIsSecondHalf = document.getElementById("IsSecondHalf").checked;
        //-------------------------------------------------------------------

        LeaveApplicationSelf.totHalfday = 0;
        if (checkFlagIsFirstHalf == true) {
            checkValueFirstHalf = 0.5;
            LeaveApplicationSelf.totHalfday = LeaveApplicationSelf.totHalfday + 1;
        }
        else {
            checkValueFirstHalf = 0;
            LeaveApplicationSelf.totHalfday = LeaveApplicationSelf.totHalfday + 0;
        }
        if (checkFlagIsSecondHalf == true) {
            checkValueSecondHalf = 0.5;
            LeaveApplicationSelf.totHalfday = LeaveApplicationSelf.totHalfday + 1;
        }
        else {
            checkValueSecondHalf = 0;
            LeaveApplicationSelf.totHalfday = LeaveApplicationSelf.totHalfday + 0;
        }

        var start = $("#FromDate").val();
        var end = $("#UptoDate").val();

        if (end != null && end != "") {
            //days = (end - start) / (1000 * 60 * 60 * 24);
            //days = Math.abs((end - start) / (1000 * 60 * 60 * 24));
            var endDate = new Date(end);
            var startDate = new Date(start);
            var timeDiff = String(endDate - startDate);
            //var days = Math.round(timeDiff / (1000 * 3600 * 24));
            var days = ((endDate - startDate) / (1000 * 60 * 60 * 24));
            if (startDate != endDate) {
                days = days + 1;
            }
        }

        //alert('--timeDiff--'+ timeDiff +'--days--'+days);

        totalLeaves = days - checkValueFirstHalf - checkValueSecondHalf;
        balanceLeave = LeaveApplicationSelf.HiddenBalanceLeave - totalLeaves;
        LeaveApplicationSelf.totalfullDaysLeave = totalLeaves - checkValueFirstHalf - checkValueSecondHalf;

        if (balanceLeave < 0) {
            var extraLeave = totalLeaves - LeaveApplicationSelf.HiddenBalanceLeave;
            $('#BalanceLeave').val(0)
            $('#ExtraLeave').val(extraLeave)

        }
        else {
            $('#BalanceLeave').val(balanceLeave)
            $('#ExtraLeave').val(0)
        }

        $('#totalLeaves').val(totalLeaves)

    },
    ////Load method is used to load *-Load-* page
    LoadList: function () {
        var EmployeeID = $('input[name=EmployeeID]').val();
        var LeaveSessionID = $('input[name=LeaveSessionID]').val();
        $.ajax(
         {
             cache: false,
             type: "POST",
             dataType: "html",
             data: { "actionMode": null, EmployeeID: EmployeeID, LeaveSessionID: LeaveSessionID },
             dataType: "html",
             url: '/LeaveApplicationSelf/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },

    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        debugger
        var EmployeeID = $('input[name=EmployeeID]').val();
        var LeaveSessionID = $('input[name=LeaveSessionID]').val();
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { "actionMode": null, EmployeeID: EmployeeID, LeaveSessionID: LeaveSessionID },
            url: '/LeaveApplicationSelf/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                notify(message, 'success');
            }
        });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallLeaveApplicationSelf: function () {
        var LeaveApplicationSelfData = null;
        if (LeaveApplicationSelf.ActionName == "Create") {
            $("#FormCreateLeaveApplicationSelf").validate();
            if ($("#FormCreateLeaveApplicationSelf").valid()) {
                LeaveApplicationSelfData = null;
                LeaveApplicationSelfData = LeaveApplicationSelf.GetLeaveApplicationSelf();
                ajaxRequest.makeRequest("/LeaveApplicationSelf/Create", "POST", LeaveApplicationSelfData, LeaveApplicationSelf.Success);
                if ($('#MyFile').val() != null) {
                    $('#FormCreateLeaveApplicationSelf').submit();
                }
            }
        }
        else if (LeaveApplicationSelf.ActionName == "CreateCompOff") {
            if ($("#FormCreateLeaveApplicationSelf").valid()) {
                LeaveApplicationSelfData = null;
                LeaveApplicationSelfData = LeaveApplicationSelf.GetLeaveApplicationSelf();
                ajaxRequest.makeRequest("/LeaveApplicationSelf/Create", "POST", LeaveApplicationSelfData, LeaveApplicationSelf.Success);
            }
        }
    },

    //Get properties data from the Create, Update and Delete page
    GetLeaveApplicationSelf: function () {
        ;

        var Data = {
        };
        if (LeaveApplicationSelf.ActionName == "Create") {

            Data.EmployeeID = $('input[name=EmployeeID]').val();
            Data.LeaveMasterID = $('#LeaveMasterID').val();
            Data.FromDate = $('#FromDate').val();
            Data.UptoDate = $('#UptoDate').val();
            Data.TotalHalfDayLeave = LeaveApplicationSelf.totHalfday;
            Data.TotalfullDaysLeave = LeaveApplicationSelf.totalfullDaysLeave;

            Data.IsFirstHalf = document.getElementById("IsFirstHalf").checked;
            Data.IsSecondHalf = document.getElementById("IsSecondHalf").checked;
            //  Data.HalfLeaveStatus = LeaveApplicationSelf.HalfLeaveStatus;
            Data.LeaveReason = $('#LeaveReason').val();
            Data.LeaveSessionID = $('input[name=LeaveSessionID]').val();
            Data.CentreCode = $('input[name=CentreCode]').val();
            Data.LeaveRuleMasterID = $('input[name=LeaveRuleMasterID]').val();
            Data.SelectedIDs = '';
            Data.FileName = $('input[name=FileName]').val();
            if (Data.FileName != "") {
                Data.DocumentRequiredID = LeaveApplicationSelf.DocumentRequiredID;
            }
            else {
                Data.DocumentRequiredID = 0;
            }

        }
        else if (LeaveApplicationSelf.ActionName == "CreateCompOff") {


            Data.EmployeeID = $('input[name=EmployeeID]').val();
            Data.LeaveMasterID = $('#LeaveMasterID').val();
            Data.LeaveSessionID = $('input[name=LeaveSessionID]').val();
            Data.CentreCode = $('input[name=CentreCode]').val();
            Data.LeaveRuleMasterID = $('#_LeaveRuleMasterID').val();
            Data.SelectedIDs = LeaveApplicationSelf.SelectedIDs;
            Data.FromDate = '';
            Data.UptoDate = '';
            Data.TotalHalfDayLeave = 0;
            Data.TotalfullDaysLeave = 0;
            Data.IsFirstHalf = 0;
            Data.IsSecondHalf = 0;
            Data.LeaveReason = $('#Reason').val();
            Data.DocumentRequiredID = LeaveApplicationSelf.DocumentRequiredID;
            Data.FileName = '';

        }

        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        debugger
        var splitData = data.split(',');
        if (data != null) {
            //parent.$.colorbox.close();
            LeaveApplicationSelf.ReloadList(splitData[0], splitData[1], splitData[2]);
            //LeaveApplicationSelf.Reset();
        } else {
            //parent.$.colorbox.close();
            LeaveApplicationSelf.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },

    Reset: function () {

        $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
        $('input:checkbox,input:radio').removeAttr('checked');
        $('#LeaveMasterID').focus();
        $('#LeaveMasterID').val("");
        $('#NumberOfLeaves').val(0);
        $('#MaxLeaveAtTime').val(0);
        $('#totalLeaves').val(0);
        $('#BalanceLeave').val(0);
        $('#ExtraLeave').val(0);
        $('#Div_DatesAndRemark').fadeOut('slow');
        $('#divCompensatoryWorkDay').fadeOut('slow');
        $('#CreateCompensatoryOffDayLeaveApplicationRecord').fadeOut('slow');
        $('#tblCompensatoryWorkDay').hide();

    },

    getValueUsingParentTag_Check_UnCheck: function () {
        var AllDataArray = [];
        var table = $('#tblCompensatoryWorkDay').DataTable();
        var data = table.$('input,select,input tag').each(function () {
            AllDataArray.push($(this).val());
        });

        var sList = "";
        var xmlParamList = "<rows>";
        var DataArray = [];
        var CheckArray = "";
        var UnCheckArray = [];
        var sArray = [];
        var radioArray = [];
        var DatatableData, TotalRecord, TotalRow;
        $('#tblCompensatoryWorkDay input[class="enablerow"]').each(function () {//input: checkbox.enablerow
            if ($(this).val() != "on") {
                var a = $(this).val();

                sArray = $(this).val().split("~");
                if (this.checked == true) {
                    //xmlInsert code here  

                    if (a.length >= 1) {
                        CheckArray = CheckArray + ',' + a + '~' + 'T';
                    }
                }
                else if (this.checked == false) {
                    //xmlUpdate code here
                    UnCheckArray = UnCheckArray + ',' + a + '~' + 'F';
                }
            }
        });

        $('#tblCompensatoryWorkDay input[type=radio]').each(function () {
            if ($(this).val() != "on") {
                var a = $(this).val();
                var splited_a = $(this).val().split("~");
                if (this.checked == true) {
                    //xmlInsert code here
                    var y = 1;
                    for (; y <= CheckArray.split(',').length - 1;) {
                        if (splited_a[0] == CheckArray.split(',')[y].split('~')[0]) {
                            radioArray = radioArray + ',' + a;
                            //  alert(CheckArray);
                        }
                        y = y + 1;
                    }
                }
            }
        });



        sArray = CheckArray.split(',');
        TotalRecord = sArray.length;


        TotalRecordForDataArray = AllDataArray.length;

        var splitedArray = [];
        var splitedArrayForReq = [];
        var splitedArrayForHalfDay = [];
        var splitedArrayForRadio = [];
        var i = 1;
        var j = 2;
        var k = 3;
        var p = 2;
        var q = 1;
        var r = 6;
        var x = 0;

        for (; i < TotalRecord ;) {
            splitedArrayForReq = sArray[i].split('~');
            if (i + 1 <= TotalRecord) {
                if (splitedArrayForHalfDay.length > 0) {
                    splitedArrayForHalfDay = sArray[i].split('~');                                  //  splitedArrayForHalfDay = sArray[i+1].split('~');
                }
                else {
                    splitedArrayForHalfDay[2] = 'F'
                }
                if (splitedArrayForReq.length == 2) {
                    if (splitedArrayForHalfDay[2] == 'T') {
                        splitedArrayForRadio = radioArray.split(',');
                        if ((splitedArrayForRadio[q].split('~'))[0] == splitedArrayForReq[0]) {
                            if ((splitedArrayForRadio[q].split('~'))[1] == 'First') {
                                xmlParamList = xmlParamList + "<row>" + "<ID>" + splitedArrayForReq[0] + "</ID>" + "<FromDate>" + AllDataArray[p] + "</FromDate>" + "<UptoDate>" + AllDataArray[p] + "</UptoDate>" + "<IsFirstHalf>" + 1 + "</IsFirstHalf>" + "<IsSecondHalf>" + 0 + "</IsSecondHalf>" + "<LeaveReason>" + AllDataArray[p + 4] + "</LeaveReason><TotalHalfDayLeave>" + 1 + "</TotalHalfDayLeave><TotalfullDaysLeave>" + 0 + "</TotalfullDaysLeave>" + "</row>";
                            }
                            else {
                                xmlParamList = xmlParamList + "<row>" + "<ID>" + splitedArrayForReq[0] + "</ID>" + "<FromDate>" + AllDataArray[p] + "</FromDate>" + "<UptoDate>" + AllDataArray[p] + "</UptoDate>" + "<IsFirstHalf>" + 0 + "</IsFirstHalf>" + "<IsSecondHalf>" + 1 + "</IsSecondHalf>" + "<LeaveReason>" + AllDataArray[p + 4] + "</LeaveReason><TotalHalfDayLeave>" + 1 + "</TotalHalfDayLeave><TotalfullDaysLeave>" + 0 + "</TotalfullDaysLeave>" + "</row>";
                            }
                        }
                    }
                    else {

                        if (radioArray.length > 0) {
                            var splitedArrayForRadio1 = radioArray.split(',');
                            splitedArrayForRadio = splitedArrayForRadio1[q].split('~');
                            if (splitedArrayForRadio[0] == splitedArrayForReq[0]) {                                         //(splitedArrayForRadio[q - 1] == splitedArrayForReq[0])
                                for (; x < AllDataArray.length;) {
                                    if (AllDataArray[x] == splitedArrayForReq[0]) {
                                        if (splitedArrayForRadio[1] == 'First') {
                                            xmlParamList = xmlParamList + "<row>" + "<ID>" + splitedArrayForReq[0] + "</ID>" + "<FromDate>" + AllDataArray[p] + "</FromDate>" + "<UptoDate>" + AllDataArray[p] + "</UptoDate>" + "<IsFirstHalf>" + 1 + "</IsFirstHalf>" + "<IsSecondHalf>" + 0 + "</IsSecondHalf>" + "<LeaveReason>" + AllDataArray[p + 4] + "</LeaveReason><TotalHalfDayLeave>" + 1 + "</TotalHalfDayLeave><TotalfullDaysLeave>" + 0 + "</TotalfullDaysLeave>" + "</row>";
                                        }
                                        else {
                                            xmlParamList = xmlParamList + "<row>" + "<ID>" + splitedArrayForReq[0] + "</ID>" + "<FromDate>" + AllDataArray[p] + "</FromDate>" + "<UptoDate>" + AllDataArray[p] + "</UptoDate>" + "<IsFirstHalf>" + 0 + "</IsFirstHalf>" + "<IsSecondHalf>" + 1 + "</IsSecondHalf>" + "<LeaveReason>" + AllDataArray[p + 4] + "</LeaveReason><TotalHalfDayLeave>" + 1 + "</TotalHalfDayLeave><TotalfullDaysLeave>" + 0 + "</TotalfullDaysLeave>" + "</row>";
                                        }
                                    }
                                    else {
                                        p = p + 8;
                                    }
                                    x = x + 8;
                                }
                                var p = 2;
                            }
                        }
                        else {

                            for (; x < AllDataArray.length;) {
                                if (AllDataArray[x] == splitedArrayForReq[0]) {
                                    xmlParamList = xmlParamList + "<row>" + "<ID>" + splitedArrayForReq[0] + "</ID>" + "<FromDate>" + AllDataArray[p] + "</FromDate>" + "<UptoDate>" + AllDataArray[p] + "</UptoDate>" + "<IsFirstHalf>" + 0 + "</IsFirstHalf>" + "<IsSecondHalf>" + 0 + "</IsSecondHalf>" + "<LeaveReason>" + AllDataArray[p + 4] + "</LeaveReason><TotalHalfDayLeave>" + 0 + "</TotalHalfDayLeave><TotalfullDaysLeave>" + 1 + "</TotalfullDaysLeave>" + "</row>";
                                }
                                else {
                                    p = p + 8;
                                }
                                x = x + 8;
                            }

                        }
                    }
                }
            }
            else {
                for (; x < AllDataArray.length;) {

                    if (AllDataArray[x] == splitedArrayForReq[0]) {
                        xmlParamList = xmlParamList + "<row>" + "<ID>" + splitedArrayForReq[0] + "</ID>" + "<FromDate>" + AllDataArray[p] + "</FromDate>" + "<UptoDate>" + AllDataArray[p] + "</UptoDate>" + "<IsFirstHalf>" + 0 + "</IsFirstHalf>" + "<IsSecondHalf>" + 0 + "</IsSecondHalf>" + "<LeaveReason>" + AllDataArray[p + 4] + "</LeaveReason><TotalHalfDayLeave>" + 0 + "</TotalHalfDayLeave><TotalfullDaysLeave>" + 1 + "</TotalfullDaysLeave>" + "</row>";
                    }
                    else {
                        p = p + 8;
                    }
                    x = x + 8;
                }
            }
            i = i + 1;
            q = q + 1;
            j = j + 2;
            p = 2;
            x = 0;
        }
        LeaveApplicationSelf.SelectedIDs = xmlParamList + "</rows>";
        //alert(LeaveApplicationSelf.SelectedIDs);

    },

    ValidateFileUpload: function () {

        var fuData = document.getElementById('MyFile');
        var FileUploadPath = fuData.value;


        if (FileUploadPath == '') {
            // alert("Please upload an image");
            ajaxRequest.GeneralMessageAlertForJS("JsAlertMessages_PleaseUploadimage");

        } else {
            var Extension = FileUploadPath.substring(FileUploadPath.lastIndexOf('.') + 1).toLowerCase();



            if (Extension == "pdf" || Extension == "gif" || Extension == "png" || Extension == "bmp"
                        || Extension == "jpeg" || Extension == "jpg") {


                if (fuData.files && fuData.files[0]) {

                    var size = fuData.files[0].size;
                    //alert(size);

                    if (size > 400000) {
                        return 1;
                    } else {
                        var reader = new FileReader();

                        reader.onload = function (e) {
                            $('#blah').attr('src', e.target.result);
                        }

                        reader.readAsDataURL(fuData.files[0]);
                    }
                }

            }


            else {
                //alert("Photo only allows file types of GIF, PNG, JPG, JPEG and BMP. ");
                ajaxRequest.GeneralMessageAlertForJS("JsAlertMessages_PhotoOnlyallowfiletypeof");
                FileUploadPath = '';
                $('#MyFile').val('');
            }
        }
    },
    //Check one of the checkboxes



};



