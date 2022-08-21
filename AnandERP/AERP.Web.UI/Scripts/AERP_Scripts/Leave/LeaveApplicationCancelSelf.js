////this class contain methods related to nationality functionality
//var LeaveApplicationCancelSelf = {
//    //Member variables
//    ActionName: null,
//    LeaveApplicationApprocedPendingStatusDetailsIDs: null,
//    xmlParameterListCount :null,
//    //Class intialisation method
//    Initialize: function () {
//        //organisationStudyCentre.loadData();

//        LeaveApplicationCancelSelf.constructor();
//        //LeaveApplicationCancelSelf.initializeValidation();
//    },
//    //Attach all event of page
//    constructor: function () {




//        // Create new record
//        $('#CreateLeaveApplicationCancelSelfRecord').on("click", function () {

//            LeaveApplicationCancelSelf.ActionName = "Create";
//            LeaveApplicationCancelSelf.getValueUsingParentTag_Check_UnCheck();
//            if (LeaveApplicationCancelSelf.LeaveApplicationApprocedPendingStatusDetailsIDs.length > 6) {
//                LeaveApplicationCancelSelf.AjaxCallLeaveApplicationCancelSelf();
//            }
//            else {
//                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectLeave", "update-message", "#FFCC80");
//                //$('#update-message').html('Please Select Leave.');
//                //$('#update-message').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', '#FFCC80');
//            }


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
//        });

//        $("#CancelLeave").click(function () {
//            alert('Hi')
//        });


//    },


//    ////Load method is used to load *-Load-* page
//    LoadList: function () {
//        ;
//        var EmployeeID = $('input[name=EmployeeID]').val();
//        $.ajax(
//        {
//           cache: false,
//           type: "POST",
//           dataType: "html",
//           data: { "actionMode": null, EmployeeID: EmployeeID },
//           dataType: "html",
//           url: '/LeaveApplicationCancelSelf/List',
//           success: function (data) {
//               //Rebind Grid Data
//               $('#ListViewModel').html(data);
//       }
//        });
//    },
//    //ReloadList method is used to load List page
//    ReloadList: function (message, colorCode, actionMode) {

//        $.ajax(
//        {
//            cache: false,
//            type: "POST",
//            dataType: "html",
//            data: { "actionMode": actionMode },
//            url: '/LeaveApplicationCancelSelf/List',
//            success: function (data) {
//                //Rebind Grid Data
//                $("#ListViewModel").empty().append(data);
//                //twitter type notification
//                $('#SuccessMessage').html(message);
//                $('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
//            }
//        });
//    },



//    //Fire ajax call to insert update and delete record
//    AjaxCallLeaveApplicationCancelSelf: function () {
//        var LeaveApplicationCancelSelfData = null;
//        if (LeaveApplicationCancelSelf.ActionName == "Create") {
//            //$("#FormCreateLeaveApplicationCancelSelf").validate();
//            //if ($("#FormCreateLeaveApplicationCancelSelf").valid()) {
//                LeaveApplicationCancelSelfData = null;
//                LeaveApplicationCancelSelfData = LeaveApplicationCancelSelf.GetLeaveApplicationCancelSelf();
//                ajaxRequest.makeRequest("/LeaveApplicationCancelSelf/LeaveApplicationCancelSelf", "POST", LeaveApplicationCancelSelfData, LeaveApplicationCancelSelf.Success);
//          //  }
//        }

//    },
//    //Get properties data from the Create, Update and Delete page
//    GetLeaveApplicationCancelSelf: function () {
   
        
//        var Data = {
//        };
//        if (LeaveApplicationCancelSelf.ActionName == "Create") {
//            Data.LeaveApplicationApprocedPendingStatusDetails = LeaveApplicationCancelSelf.LeaveApplicationApprocedPendingStatusDetailsIDs;
//        }

//        return Data;
//    },
//    getValueUsingParentTag_Check_UnCheck: function () {
        
//        var sList = "";
//        var xmlParamList = "<rows>"
//        $('#checkboxlist input[type=checkbox]').each(function () {
//            if ($(this).val() != "on") {
//                var sArray = [];
//                sArray = $(this).val().split("~");
//                if (this.checked == true) {
//                    xmlParamList = xmlParamList + "<row><LeaveApplicationID>" + sArray[0] + "</LeaveApplicationID><LeaveApplicationTransactionID>" + sArray[1] + "</LeaveApplicationTransactionID><LeaveSessionID>" + sArray[2] + "</LeaveSessionID><LeaveMasterID>" + sArray[3] + "</LeaveMasterID></row>"
//                }
//            }
//        });
       
//        if (xmlParamList.length > 6)
//            LeaveApplicationCancelSelf.LeaveApplicationApprocedPendingStatusDetailsIDs = xmlParamList + "</rows>";
//        else
//            LeaveApplicationCancelSelf.LeaveApplicationApprocedPendingStatusDetailsIDs = "0";

     
//    },
//    //  @sIDs= <rows><row><LeaveApplicationID></LeaveApplicationID><LeaveApplicationTransactionHistoryID></LeaveApplicationTransactionHistoryID><LeaveSessionID></LeaveSessionID><LeaveMasterID></LeaveMasterID></row></rows>

//    //this is used to for showing successfully record creation message and reload the list view
//    Success: function (data) {
//        ;
//        var splitData = data.split(',');
//        if (data != null) {
//            parent.$.colorbox.close();
//            LeaveApplicationCancelSelf.ReloadList(splitData[0], splitData[1], splitData[2]);
//        } else {
//            parent.$.colorbox.close();
//            LeaveApplicationCancelSelf.ReloadList(splitData[0], splitData[1], splitData[2]);
//        }

//    },

//};

/////////////////////////new js////////////////////////////////////////////

//this class contain methods related to nationality functionality
var LeaveApplicationCancelSelf = {
    //Member variables
    ActionName: null,
    LeaveApplicationApprocedPendingStatusDetailsIDs: null,
    xmlParameterListCount: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        LeaveApplicationCancelSelf.constructor();
        //LeaveApplicationCancelSelf.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {




        // Create new record
        $('#CreateLeaveApplicationCancelSelfRecord').on("click", function () {
            //alert();
            LeaveApplicationCancelSelf.ActionName = "Create";
            LeaveApplicationCancelSelf.getValueUsingParentTag_Check_UnCheck(); 
            if (LeaveApplicationCancelSelf.LeaveApplicationApprocedPendingStatusDetailsIDs.length > 6) {
                LeaveApplicationCancelSelf.AjaxCallLeaveApplicationCancelSelf();
            }
            else {
                
                //ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectLeave", "update-message", "#FFCC80");
                //$("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
                $("#displayErrorMessage p").text('Please Select Leave').closest('div').fadeIn().closest('div').addClass('alert-' + 'warning');
            }


        });


        $("#UserSearch").keyup(function () {
            var oTable = $("#myDataTable").dataTable();
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

        //$(".ajax").colorbox();
        InitAnimatedBorder();
        CloseAlert();


        //$('#FromDate').datepicker({
        //    dateFormat: 'd-M-yy',
        //});

        //$('#FromDate').datetimepicker({
        //    format: 'DD MMMM YYYY',
        //    //minDate: moment(),
        //    ignoreReadonly: true,
        //})

        $("#CancelLeave").click(function () {
            
        });


    },


    ////Load method is used to load *-Load-* page
    LoadList: function () {
        ;
        var EmployeeID = $('input[name=EmployeeID]').val();
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { "actionMode": null, EmployeeID: EmployeeID },
            dataType: "html",
            url: '/LeaveApplicationCancelSelf/List',
            success: function (data) {
                //Rebind Grid Data
                $('#ListViewModel').html(data);
            }
        });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {

        var EmployeeID = $('input[name=EmployeeID]').val();
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { "actionMode": actionMode, EmployeeID: EmployeeID },
            url: '/LeaveApplicationCancelSelf/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
                notify(message,'success');
            }
        });
    },



    //Fire ajax call to insert update and delete record
    AjaxCallLeaveApplicationCancelSelf: function () {
        var LeaveApplicationCancelSelfData = null;
        if (LeaveApplicationCancelSelf.ActionName == "Create") {
            //$("#FormCreateLeaveApplicationCancelSelf").validate();
            //if ($("#FormCreateLeaveApplicationCancelSelf").valid()) {
            LeaveApplicationCancelSelfData = null;
            LeaveApplicationCancelSelfData = LeaveApplicationCancelSelf.GetLeaveApplicationCancelSelf();
            ajaxRequest.makeRequest("/LeaveApplicationCancelSelf/LeaveApplicationCancelSelf", "POST", LeaveApplicationCancelSelfData, LeaveApplicationCancelSelf.Success);
            //  }
        }

    },
    //Get properties data from the Create, Update and Delete page
    GetLeaveApplicationCancelSelf: function () {


        var Data = {
        };
        if (LeaveApplicationCancelSelf.ActionName == "Create") {
            Data.LeaveApplicationApprocedPendingStatusDetails = LeaveApplicationCancelSelf.LeaveApplicationApprocedPendingStatusDetailsIDs;
        }

        return Data;
    },
    getValueUsingParentTag_Check_UnCheck: function () {
        debugger;
        //var sList = "";
        //var xmlParamList = "<rows>"
        //$('#checkboxlist input[type=checkbox]').each(function () {
        //    if ($(this).val() != "on") {
        //        var sArray = [];
        //        sArray = $(this).val().split("~");
        //        if (this.checked == true) {
        //            xmlParamList = xmlParamList + "<row><LeaveApplicationID>" + sArray[0] + "</LeaveApplicationID><LeaveApplicationTransactionID>" + sArray[1] + "</LeaveApplicationTransactionID><LeaveSessionID>" + sArray[2] + "</LeaveSessionID><LeaveMasterID>" + sArray[3] + "</LeaveMasterID></row>";
        //        }
        //    }
        //});

        //if (xmlParamList.length > 6)
        //    LeaveApplicationCancelSelf.LeaveApplicationApprocedPendingStatusDetailsIDs = xmlParamList + "</rows>";
        //else
        //    LeaveApplicationCancelSelf.LeaveApplicationApprocedPendingStatusDetailsIDs = "";


        var selectedItem = $("#LeaveApplicationApprocedPendingStatusDetails").val();
        var xmlParamList = "<rows>";
       
        if (selectedItem != null) {
           
            for (var i = 0; i < selectedItem.length; i++) {
               
                xmlParamList = xmlParamList + "<row>" + "<LeaveApplicationID>" + String(selectedItem).split(',')[i].split('~')[0] + "</LeaveApplicationID>" + "<LeaveApplicationTransactionID>" + String(selectedItem).split(',')[i].split('~')[1] + "</LeaveApplicationTransactionID>" + "<LeaveSessionID>" + String(selectedItem).split(',')[i].split('~')[2] + "</LeaveSessionID>" + "<LeaveMasterID>" + String(selectedItem).split(',')[i].split('~')[3] + "</LeaveMasterID>" + "</row>";
            }         
        }
       
        if (xmlParamList.length > 6)
            LeaveApplicationCancelSelf.LeaveApplicationApprocedPendingStatusDetailsIDs = xmlParamList + "</rows>";
        else
            LeaveApplicationCancelSelf.LeaveApplicationApprocedPendingStatusDetailsIDs = "";

    
    },
    //  @sIDs= <rows><row><LeaveApplicationID></LeaveApplicationID><LeaveApplicationTransactionHistoryID></LeaveApplicationTransactionHistoryID><LeaveSessionID></LeaveSessionID><LeaveMasterID></LeaveMasterID></row></rows>

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        
        var splitData = data.split(',');
        if (data != null) {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            LeaveApplicationCancelSelf.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            LeaveApplicationCancelSelf.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },

};

