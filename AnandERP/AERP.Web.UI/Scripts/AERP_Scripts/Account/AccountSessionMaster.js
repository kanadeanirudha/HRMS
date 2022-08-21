//this class contain methods related to nationality functionality
var AccountSessionMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        AccountSessionMaster.constructor();
    },
    //Attach all event of page
    constructor: function () {
        //Reset button click event function to reset all controls of form

        //$("#SessionStartDatetime").datepicker({

        //    numberOfMonths: 1,
        //    dateFormat: 'd M yy',
        //    onSelect: function (selected) {
        //        var now = new Date(selected);
        //        var duedate = new Date(now);
        //        duedate.setDate(now.getDate() + 364);
        //        var str = duedate.toString();
        //        str = str.split(' ');
        //        $("#SessionEndDatetime").datepicker("option", "minDate", selected)
        //       }
        //});
        //$("#SessionEndDatetime").datepicker({
        //    numberOfMonths: 1,
        //    dateFormat: 'd M yy',
        //    onSelect: function (selected) {
        //        $("#SessionStartDatetime").datepicker("option", "maxDate", selected)
        //    }
        //});

        $('#SessionStartDatetime').datetimepicker({
            format: 'DD MMMM YYYY',
            ignoreReadonly: true,
            //maxDate: moment(),
        });

        $('#SessionEndDatetime').datetimepicker({
            format: 'DD MMMM YYYY',
            ignoreReadonly: true,
        });

        $("#SessionStartDatetime").on("dp.hide", function (e) {
            var minDate = new Date(e.date.valueOf());
            minDate.setDate(minDate.getDate() - 1);
            var months = ["January", "February", "March", "April", "May", "June",
               "July", "August", "September", "October", "November", "December"];
            var selectedMonthName = months[minDate.getMonth()];
            var selectedDate = minDate.getDate();
            var selectedYear = minDate.getFullYear() + 1;
            var conDate = selectedDate + ' ' + selectedMonthName + ' ' + selectedYear;
            var conDateConvert = new Date(conDate);
            $('#SessionEndDatetime').data("DateTimePicker").minDate(conDateConvert);
            $('#SessionEndDatetime').val(conDate);

            //$('#LeaveSessionUptoDate').val(minDate);

        });

        $("#SessionEndDatetime").on("dp.hide", function (e) {
            var maxDate = new Date(e.date.valueOf());
            maxDate.setDate(maxDate.getDate());
            $('#SessionStartDatetime').data("DateTimePicker").maxDate(maxDate);
        });

        $('#CreateAccountSessionMasterRecord').on("click", function () {

            AccountSessionMaster.ActionName = "Create";
            AccountSessionMaster.AjaxCallAccountSessionMaster();
        });

        $('#EditAccountSessionMasterRecord').on("click", function () {

            AccountSessionMaster.ActionName = "Edit";
            AccountSessionMaster.AjaxCallAccountSessionMaster();
        });

        $('#DeleteAccountSessionMasterRecord').on("click", function () {

            AccountSessionMaster.ActionName = "Delete";
            AccountSessionMaster.AjaxCallAccountSessionMaster();
        });

        $("#UserSearch").on("keyup", function () {
            var oTable = $("#myDataTable").dataTable();
            oTable.fnFilter(this.value);
        });

        $("#searchBtn").on("click", function () {
            $("#UserSearch").focus();
        });

        $("#showrecord").on("change", function () {
            var showRecord = $("#showrecord").val();
            $("select[name*='myDataTable_length']").val(showRecord);
            $("select[name*='myDataTable_length']").change();
        });

        //$(".ajax").colorbox();
        InitAnimatedBorder();
        CloseAlert();

        $('#reset').on("click", function () {
            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input[name="IsActive"]').removeAttr('checked');
            $('#SessionStartDatetime').focus();
            $('#Account_System').val("Cash");
            //$('input:checkbox').removeAttr('checked');
            return false;
        });

        

    },
    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax(
         {
             cache: false,
             type: "POST",
             dataType: "html",
             url: '/AccountSessionMaster/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        debugger;
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { "actionMode": actionMode },
            url: '/AccountSessionMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
                notify(message,colorCode);
            }
        });
    },
    //Fire ajax call to insert update and delete record
    AjaxCallAccountSessionMaster: function () {
        var AccountSessionMasterData = null;
        if (AccountSessionMaster.ActionName == "Create") {
            $("#FormCreateAccountSessionMaster").validate();
            if ($("#FormCreateAccountSessionMaster").valid()) {
                AccountSessionMasterData = null;
                AccountSessionMasterData = AccountSessionMaster.GetAccountSessionMaster();
                ajaxRequest.makeRequest("/AccountSessionMaster/Create", "POST", AccountSessionMasterData, AccountSessionMaster.Success);
            }
        }
        else if (AccountSessionMaster.ActionName == "Edit") {
            $("#FormEditAccountSessionMaster").validate();
            if ($("#FormEditAccountSessionMaster").valid()) {
                AccountSessionMasterData = null;
                AccountSessionMasterData = AccountSessionMaster.GetAccountSessionMaster();
                ajaxRequest.makeRequest("/AccountSessionMaster/Edit", "POST", AccountSessionMasterData, AccountSessionMaster.Success);
            }
        }
        else if (AccountSessionMaster.ActionName == "Delete") {
            AccountSessionMasterData = null;
            AccountSessionMasterData = AccountSessionMaster.GetAccountSessionMaster();
            ajaxRequest.makeRequest("/AccountSessionMaster/Delete", "POST", AccountSessionMasterData, AccountSessionMaster.Success);
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetAccountSessionMaster: function () {
        var Data = {
        };

        if (AccountSessionMaster.ActionName == "Create" || AccountSessionMaster.ActionName == "Edit") {
            Data.ID = $('input[name=ID]').val();
            Data.SessionStartDatetime = $('#SessionStartDatetime').val();
            Data.SessionEndDatetime = $('#SessionEndDatetime').val();
            Data.Account_System = $('#Account_System').val();
            //Data.IsActive = $('input[name=IsActive]:checked').val() ? true : false;
            Data.IsActive = $('input[id=IsActive]:checked').val() ? true : false;


        }
        else if (AccountSessionMaster.ActionName == "Delete") {
            Data.ID = $('input[name=ID]').val();
        }
        return Data;
    },
    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        //parent.$.colorbox.close();
        $.magnificPopup.close();
        AccountSessionMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
    },
};