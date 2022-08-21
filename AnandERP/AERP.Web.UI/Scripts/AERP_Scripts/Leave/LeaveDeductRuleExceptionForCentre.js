

var LeaveDeductRuleExceptionForCentre = {
    //Member variables
    ActionName: null,

    //Class intialisation method
    Initialize: function () {
        LeaveDeductRuleExceptionForCentre.constructor();
    },

    //Attach all event of page
    constructor: function () {        

        $("#dropCenterCode").hide();

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

        $(".ajax").colorbox();

        $("#HoCoRoScFlag").on("change", function () {
            if ($('#HoCoRoScFlag').val() == 2) {
                $("#dropCenterCode").show();
            }
            else if($('#HoCoRoScFlag').val() != 2)
            {
                $("#dropCenterCode").hide();
            }
        });

        $("#ShowList").click(function () {
            
            var selectedCentreCode = $('#CentreCode').val();
            var hoCoRoScFlag = $('#HoCoRoScFlag').val(); 

            if (hoCoRoScFlag == 1) {
                $.ajax({
                    cache: false,
                    type: "POST",
                    data: { actionMode: null, centerCode: null, hoCoRoScFlag: hoCoRoScFlag },
                    dataType: "html",
                    url: '/LeaveDeductRuleExceptionForCentre/List',
                    success: function (result) {
                        //Rebind Grid Data                        
                        $('#ListViewModel').html(result);
                    }
                });
            }
            else if (hoCoRoScFlag == 2 && selectedCentreCode != "")
            {
                $("#dropCenterCode").show();

                $.ajax({
                    cache: false,
                    type: "POST",
                    data: { actionMode: null, centerCode: selectedCentreCode, hoCoRoScFlag: hoCoRoScFlag },
                    dataType: "html",
                    url: '/LeaveDeductRuleExceptionForCentre/List',
                    success: function (result) {
                        //Rebind Grid Data                       
                        
                        $("#dropCenterCode").show();
                        $('#ListViewModel').html(result);
                    }
                });
                $("#dropCenterCode").show();
            }
            else {

                $('#SuccessMessage').html("Please select center.");
                $('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
                return false;
            }
        });

    },

    ////ShowList is use to load list page.
    //ShowList: function () {
    //    alert($("#CentreCode").val());
    //    $.ajax({
    //        cache: false,
    //        type: "GET",
    //        data: { "actionMode": null, "centerCode": $("#CentreCode").val() },
    //        dataType: "html",
    //        url: '/LeaveDeductRuleExceptionForCentre/List',
    //        success: function (data) {
    //            //Rebind Grid Data
    //            $('#ListViewModel').html(data);
    //        }
    //    });
    //},

    //LoadList method is used to load List page
    LoadList: function () {
               
        //var hoCoRoScFlag=$('#HoCoRoScFlag').val();
        //if (hoCoRoScFlag != null && hoCoRoScFlag != "") {
            $.ajax({
                cache: false,
                type: "GET",
                data: { "actionMode": null, "centerCode": null, "hoCoRoScFlag": null },
                dataType: "html",
                url: '/LeaveDeductRuleExceptionForCentre/List',
                success: function (data) {
                    //Rebind Grid Data                  
                    $('#ListViewModel').html(data);
                }
            });
        //}
        //else {

        //    $('#SuccessMessage').html("Please select center.");
        //    $('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
        //    return false;
        //}
    },


    ReloadList: function (message, colorCode, actionMode) {
        var balancesheet = $("#selectedBalsheetID").val();
        $.ajax(
        {
            cache: false,
            type: "GET",
            data: { "actionMode": null, "centerCode": null, "hoCoRoScFlag": null },
            dataType: "html",
            url: '/LeaveDeductRuleExceptionForCentre/List',
            success: function (data) {
                //Rebind Grid Data
                $('#ListViewModel').html(data);

                $('#SuccessMessage').html(message);
                $('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', colorCode);
            }
        });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallLeaveDeductRuleExceptionForCentre: function () {
        var LeaveDeductRuleExceptionForCentreData = null;
        if (LeaveDeductRuleExceptionForCentre.ActionName == "Create") {
            $("#FormCreateLeaveDeductRuleExceptionForCentre").validate();
            if ($("#FormCreateLeaveDeductRuleExceptionForCentre").valid()) {
                LeaveDeductRuleExceptionForCentreData = null;
                LeaveDeductRuleExceptionForCentreData = LeaveDeductRuleExceptionForCentre.GetLeaveDeductRuleExceptionForCentre();
                ajaxRequest.makeRequest("/LeaveDeductRuleExceptionForCentre/Create", "POST", LeaveDeductRuleExceptionForCentreData, LeaveDeductRuleExceptionForCentre.Success);
            }
        }
    },

    //Get properties data from the Create, Update and Delete page
    GetLeaveDeductRuleExceptionForCentre: function () {
        var Data = {
        };



        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        parent.$.colorbox.close();
        LeaveDeductRuleExceptionForCentre.ReloadList("Record created successfully", "#9FEA7A", "0");
    }

};