//this class contain methods related to nationality functionality
var LeaveLateMarkRulesDetails = {
    //Member variables
    ActionName: null,
    SelectedLeaveID1: null,
    SelectedLeaveID2: null,
    SelectedLeaveID3: null,
    SelectedLeaveID4: null,
    SelectedLeaveID5: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        LeaveLateMarkRulesDetails.constructor();
        //generalCountryMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#LateMarkRuleName').focus();

        $("#reset").click(function () {
            debugger;
            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#LateMarkRuleName').focus();
            $('#LateMarkCount').val("1");
            $('#NumberLeaveDeducted').val("0.5");

            $('#LeaveID1').val('');
            $('#LeaveID2').val('');
            $('#LeaveID3').val('');
            $('#LeaveID4').val('');
            $('#LeaveID5').val('');
            
            $('#LeaveID2').prop("disabled", true);
            $('#LeaveID3').prop("disabled", true);
            $('#LeaveID4').prop("disabled", true);
            $('#LeaveID5').prop("disabled", true);
     
           
            return false;
        });

        // Create new record
        $('#CreateLeaveLateMarkRulesDetailsRecord').on("click", function () {
         
            LeaveLateMarkRulesDetails.ActionName = "Create";
            if ($("#LateMarkRuleName").val() == "" || $("#LateMarkRuleName").val() == null) {
                $("#displayErrorMessage p").text("Please select Rule Name.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            else if ($("#LeaveID1").val() == "") {
                $("#displayErrorMessage p").text("Please select Leave Type.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            LeaveLateMarkRulesDetails.AjaxCallLeaveLateMarkRulesDetails();
        });

        $('#EditLeaveLateMarkRulesDetailsRecord').on("click", function () {
                LeaveLateMarkRulesDetails.ActionName = "Edit";
                LeaveLateMarkRulesDetails.AjaxCallLeaveLateMarkRulesDetails();
            
        });

        $('#DeleteLeaveLateMarkRulesDetailsRecord').on("click", function () {

            LeaveLateMarkRulesDetails.ActionName = "Delete";
            LeaveLateMarkRulesDetails.AjaxCallLeaveLateMarkRulesDetails();
        });
        $('#LateMarkRuleName').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $("#UserSearch").keyup(function () {
            debugger;
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


        $("#CentreList").change(function () {
            $('#myDataTable').html("");
            $('#myDataTable_info').text("No entries to show");
            //$('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
            $('#DisplayName_AddNew').hide(true);
        });

        $("#ShowList").click(function () {
            debugger;
            var SelectedCentreCode = $('#CentreList').val();
            var SelectedCentreName = $('#CentreList :selected').text();

            if (SelectedCentreCode != "") {
                $.ajax(
             {
                 cache: false,
                 type: "POST",
                 data: { actionMode: null, centerCode: SelectedCentreCode, centreName: SelectedCentreName },

                 dataType: "html",
                 url: '/LeaveLateMarkRulesDetails/List',
                 success: function (result) {
                     //Rebind Grid Data                
                     $('#ListViewModel').html(result);
                     $('#DisplayName_AddNew').show(true);

                 }
             });
            }
            else {
                notify("Please select centre", "warning");
            }
        });




        $("#LeaveID1").change(function () {
          
            $("#LeaveID2").val('');
            $("#LeaveID3").val('');
            $("#LeaveID4").val('');
            $("#LeaveID5").val('');
            $('#LeaveID2').attr("disabled", false);
            var SelectedLeaveID = $('#LeaveID1').val() + "~" + $('#LeaveID1 :selected').text();
            if (SelectedLeaveID == LeaveLateMarkRulesDetails.SelectedLeaveID2) {
                LeaveLateMarkRulesDetails.SelectedLeaveID2 = null;
            }
            if (SelectedLeaveID == LeaveLateMarkRulesDetails.SelectedLeaveID3) {
                LeaveLateMarkRulesDetails.SelectedLeaveID3 = null;
            }
            if (SelectedLeaveID == LeaveLateMarkRulesDetails.SelectedLeaveID4) {
                LeaveLateMarkRulesDetails.SelectedLeaveID4 = null;
            }
            if (SelectedLeaveID == LeaveLateMarkRulesDetails.SelectedLeaveID5) {
                LeaveLateMarkRulesDetails.SelectedLeaveID5 = null;
            }
            if (LeaveLateMarkRulesDetails.SelectedLeaveID1 != null) {
                var aaa = LeaveLateMarkRulesDetails.SelectedLeaveID1.split('~');

                $("#LeaveID2 option[value='" + aaa[0] + "']").remove();
                $("#LeaveID3 option[value='" + aaa[0] + "']").remove();
                $("#LeaveID4 option[value='" + aaa[0] + "']").remove();
                $("#LeaveID5 option[value='" + aaa[0] + "']").remove();

                $("#LeaveID2").append($('<option></option>').val(aaa[0]).html(aaa[1]));
                $("#LeaveID3").append($('<option></option>').val(aaa[0]).html(aaa[1]));
                $("#LeaveID4").append($('<option></option>').val(aaa[0]).html(aaa[1]));
                $("#LeaveID5").append($('<option></option>').val(aaa[0]).html(aaa[1]));
            }

            if ($('#LeaveID1').val() != "") {
                $("#LeaveID2 option[value='" + $('#LeaveID1').val() + "']").remove();
                $("#LeaveID3 option[value='" + $('#LeaveID1').val() + "']").remove();
                $("#LeaveID4 option[value='" + $('#LeaveID1').val() + "']").remove();
                $("#LeaveID5 option[value='" + $('#LeaveID1').val() + "']").remove();
            }
            if ($('#LeaveID1').val() != "") {
                LeaveLateMarkRulesDetails.SelectedLeaveID1 = SelectedLeaveID;
            }
            else {
                LeaveLateMarkRulesDetails.SelectedLeaveID1 = null;
            }

        });

        $("#LeaveID2").change(function () {
            $("#LeaveID3").val('');
            $("#LeaveID4").val('');
            $("#LeaveID5").val('');
            $('#LeaveID3').attr("disabled", false);
            var SelectedLeaveID = $('#LeaveID2').val() + "~" + $('#LeaveID2 :selected').text();
            if (SelectedLeaveID == LeaveLateMarkRulesDetails.SelectedLeaveID3) {
                LeaveLateMarkRulesDetails.SelectedLeaveID3 = null;
            }
            if (SelectedLeaveID == LeaveLateMarkRulesDetails.SelectedLeaveID4) {
                LeaveLateMarkRulesDetails.SelectedLeaveID4 = null;
            }
            if (SelectedLeaveID == LeaveLateMarkRulesDetails.SelectedLeaveID5) {
                LeaveLateMarkRulesDetails.SelectedLeaveID5 = null;
            }
            if (LeaveLateMarkRulesDetails.SelectedLeaveID2 != null) {
                var aaa = LeaveLateMarkRulesDetails.SelectedLeaveID2.split('~');
                
                $("#LeaveID3 option[value='" + aaa[0] + "']").remove();
                $("#LeaveID4 option[value='" + aaa[0] + "']").remove();
                $("#LeaveID5 option[value='" + aaa[0] + "']").remove();

                $("#LeaveID3").append($('<option></option>').val(aaa[0]).html(aaa[1]));
                $("#LeaveID4").append($('<option></option>').val(aaa[0]).html(aaa[1]));
                $("#LeaveID5").append($('<option></option>').val(aaa[0]).html(aaa[1]));
            }

            if ($('#LeaveID2').val() != "") {
                //$("#LeaveID1 option[value='" + $('#LeaveID2').val() + "']").remove();
                $("#LeaveID3 option[value='" + $('#LeaveID2').val() + "']").remove();
                $("#LeaveID4 option[value='" + $('#LeaveID2').val() + "']").remove();
                $("#LeaveID5 option[value='" + $('#LeaveID2').val() + "']").remove();
            }
            if ($('#LeaveID2').val() != "") {
                LeaveLateMarkRulesDetails.SelectedLeaveID2 = SelectedLeaveID;
            }
            else {
                LeaveLateMarkRulesDetails.SelectedLeaveID2 = null;
            }

        });

        $("#LeaveID3").change(function () {
           
            $("#LeaveID4").val('');
            $("#LeaveID5").val('');
            $('#LeaveID4').attr("disabled", false);
            var SelectedLeaveID = $('#LeaveID3').val() + "~" + $('#LeaveID3 :selected').text();
            if (SelectedLeaveID == LeaveLateMarkRulesDetails.SelectedLeaveID4) {
                LeaveLateMarkRulesDetails.SelectedLeaveID4 = null;
            }
            if (SelectedLeaveID == LeaveLateMarkRulesDetails.SelectedLeaveID5) {
                LeaveLateMarkRulesDetails.SelectedLeaveID5 = null;
            }
            if (LeaveLateMarkRulesDetails.SelectedLeaveID3 != null) {
                var aaa = LeaveLateMarkRulesDetails.SelectedLeaveID3.split('~');
                $("#LeaveID4 option[value='" + aaa[0] + "']").remove();
                $("#LeaveID5 option[value='" + aaa[0] + "']").remove();
                $("#LeaveID4").append($('<option></option>').val(aaa[0]).html(aaa[1]));
                $("#LeaveID5").append($('<option></option>').val(aaa[0]).html(aaa[1]));
            }

            if ($('#LeaveID3').val() != "") {
                //$("#LeaveID1 option[value='" + $('#LeaveID3').val() + "']").remove();
                //$("#LeaveID2 option[value='" + $('#LeaveID3').val() + "']").remove();
                $("#LeaveID4 option[value='" + $('#LeaveID3').val() + "']").remove();
                $("#LeaveID5 option[value='" + $('#LeaveID3').val() + "']").remove();
            }
            if ($('#LeaveID3').val() != "") {
                LeaveLateMarkRulesDetails.SelectedLeaveID3 = SelectedLeaveID;
            }
            else {
                LeaveLateMarkRulesDetails.SelectedLeaveID3 = null;
            }
        });
        $("#LeaveID4").change(function () {
            $("#LeaveID5").val('');
            $('#LeaveID5').attr("disabled", false);
            var SelectedLeaveID = $('#LeaveID4').val() + "~" + $('#LeaveID4 :selected').text();
            if (SelectedLeaveID == LeaveLateMarkRulesDetails.SelectedLeaveID5) {
                LeaveLateMarkRulesDetails.SelectedLeaveID5 = null;
            }
            if (LeaveLateMarkRulesDetails.SelectedLeaveID4 != null) {
                var aaa = LeaveLateMarkRulesDetails.SelectedLeaveID4.split('~');
                $("#LeaveID5 option[value='" + aaa[0] + "']").remove();
                $("#LeaveID5").append($('<option></option>').val(aaa[0]).html(aaa[1]));
            }

            if ($('#LeaveID4').val() != "") {
                //$("#LeaveID1 option[value='" + $('#LeaveID4').val() + "']").remove();
                //$("#LeaveID2 option[value='" + $('#LeaveID4').val() + "']").remove();
                //$("#LeaveID3 option[value='" + $('#LeaveID4').val() + "']").remove();
                $("#LeaveID5 option[value='" + $('#LeaveID4').val() + "']").remove();
            }
            if ($('#LeaveID4').val() != "") {
                LeaveLateMarkRulesDetails.SelectedLeaveID4 = SelectedLeaveID;
            }
            else {
                LeaveLateMarkRulesDetails.SelectedLeaveID4 = null;
            }
        });
        $("#LeaveID5").change(function () {
          //  $('#LeaveID5').attr("disabled", false);
            var SelectedLeaveID = $('#LeaveID5').val() + "~" + $('#LeaveID5 :selected').text();
           // alert(LeaveLateMarkRulesDetails.SelectedLeaveID5);
            if (LeaveLateMarkRulesDetails.SelectedLeaveID5 != null) {
                var aaa = LeaveLateMarkRulesDetails.SelectedLeaveID5.split('~');
                //$("#LeaveID1").append($('<option></option>').val(aaa[0]).html(aaa[1]));
                //$("#LeaveID2").append($('<option></option>').val(aaa[0]).html(aaa[1]));
                //$("#LeaveID3").append($('<option></option>').val(aaa[0]).html(aaa[1]));
                //$("#LeaveID4").append($('<option></option>').val(aaa[0]).html(aaa[1]));
            }

            if ($('#LeaveID5').val() != "") {
                //$("#LeaveID1 option[value='" + $('#LeaveID5').val() + "']").remove();
                //$("#LeaveID2 option[value='" + $('#LeaveID5').val() + "']").remove();
                //$("#LeaveID3 option[value='" + $('#LeaveID5').val() + "']").remove();
                //$("#LeaveID4 option[value='" + $('#LeaveID5').val() + "']").remove();
            }
            if ($('#LeaveID5').val() != "") {
                LeaveLateMarkRulesDetails.SelectedLeaveID5 = SelectedLeaveID;
            }
            else {
                LeaveLateMarkRulesDetails.SelectedLeaveID5 = null;
            }
        });


    },



    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax(

         {

             cache: false,
             type: "POST",

             dataType: "html",
             url: '/LeaveLateMarkRulesDetails/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList:  function (message, colorCode, actionMode) {
       
        var SelectedCentreCode = $('#CentreList').val();
        var SelectedCentreName = $('#CentreList :selected').text();
        //parent.$.colorbox.close();
        $.magnificPopup.close();
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { actionMode: actionMode, centerCode: SelectedCentreCode, centreName: SelectedCentreName },
            url: '/LeaveLateMarkRulesDetails/List',
            success: function (data) {
                //Rebind Grid Data

                $("#ListViewModel").empty().append(data);
                $('#DisplayName_AddNew').show(true);
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', colorCode);
                notify(message,colorCode);
            }
        });
    },

    //myFunction: function (ProirityLevel) {

    //   
    //    if (ProirityLevel == 1) { $('#LeaveID2').attr("disabled", false); }
    //    if (ProirityLevel == 2) { $('#LeaveID3').attr("disabled", false); }
    //    if (ProirityLevel == 3) { $('#LeaveID4').attr("disabled", false); }
    //    if (ProirityLevel == 4) { $('#LeaveID5').attr("disabled", false); }

    //    var SelectedLeaveID = $('#LeaveID' + ProirityLevel).val() + "~" + $('#LeaveID' + ProirityLevel + ':selected').text();

    //    var ppp = LeaveLateMarkRulesDetails.SelectedLeaveID + ProirityLevel;

    //    if (ppp != null) {
    //        var aaa = ppp.split('~');
    //        $("#LeaveID" + ProirityLevel + 1).append($('<option></option>').val(aaa[0]).html(aaa[1]));
    //        $("#LeaveID" + ProirityLevel + 1).append($('<option></option>').val(aaa[0]).html(aaa[1]));
    //        $("#LeaveID" + ProirityLevel + 1).append($('<option></option>').val(aaa[0]).html(aaa[1]));
    //        $("#LeaveID" + ProirityLevel + 1).append($('<option></option>').val(aaa[0]).html(aaa[1]));
    //    }

    //    if ($('#LeaveID' + ProirityLevel).val() != "") {
    //        $("#LeaveID" + ProirityLevel + "option[value='" + $("#LeaveID" + ProirityLevel).val() + "']").remove();
    //        $("#LeaveID" + ProirityLevel + "option[value='" + $("#LeaveID" + ProirityLevel).val() + "']").remove();
    //        $("#LeaveID" + ProirityLevel + "option[value='" + $("#LeaveID" + ProirityLevel).val() + "']").remove();
    //        $("#LeaveID" + ProirityLevel + "option[value='" + $("#LeaveID" + ProirityLevel).val() + "']").remove();
    //    }
    //    if ($('#LeaveID' + ProirityLevel).val() != "") {

    //        if (ProirityLevel == 1)
    //            LeaveLateMarkRulesDetails.SelectedLeaveID1 = SelectedLeaveID;
    //        else if (ProirityLevel == 2)
    //            LeaveLateMarkRulesDetails.SelectedLeaveID2 = SelectedLeaveID;
    //        else if(ProirityLevel == 3)
    //            LeaveLateMarkRulesDetails.SelectedLeaveID3 = SelectedLeaveID;
    //        else if(ProirityLevel == 4)
    //            LeaveLateMarkRulesDetails.SelectedLeaveID4 = SelectedLeaveID;
    //        else if(ProirityLevel == 5)
    //            LeaveLateMarkRulesDetails.SelectedLeaveID5 = SelectedLeaveID;
    //    }
    //    else {
    //        if (ProirityLevel == 1)
    //            LeaveLateMarkRulesDetails.SelectedLeaveID1 = null;
    //        else if (ProirityLevel == 2)
    //            LeaveLateMarkRulesDetails.SelectedLeaveID2 = null;
    //        else if (ProirityLevel == 3)
    //            LeaveLateMarkRulesDetails.SelectedLeaveID3 = null;
    //        else if (ProirityLevel == 4)
    //            LeaveLateMarkRulesDetails.SelectedLeaveID4 = null;
    //        else if (ProirityLevel == 5)
    //            LeaveLateMarkRulesDetails.SelectedLeaveID5 = null;
    //    }

    //},

    //Fire ajax call to insert update and delete record
    AjaxCallLeaveLateMarkRulesDetails: function () {
        var LeaveLateMarkRulesDetailsData = null;
        if (LeaveLateMarkRulesDetails.ActionName == "Create") {
            $("#FormCreateLeaveLateMarkRulesDetails").validate();
            if ($("#FormCreateLeaveLateMarkRulesDetails").valid()) {
                LeaveLateMarkRulesDetailsData = null;
                LeaveLateMarkRulesDetailsData = LeaveLateMarkRulesDetails.GetLeaveLateMarkRulesDetails();
                ajaxRequest.makeRequest("/LeaveLateMarkRulesDetails/Create", "POST", LeaveLateMarkRulesDetailsData, LeaveLateMarkRulesDetails.Success);
            }
        }
        else if (LeaveLateMarkRulesDetails.ActionName == "Edit") {
            debugger;
            $("#FormEditLeaveLateMarkRulesDetails").validate();
            if ($("#FormEditLeaveLateMarkRulesDetails").valid()) {
                LeaveLateMarkRulesDetailsData = null;
                LeaveLateMarkRulesDetailsData = LeaveLateMarkRulesDetails.GetLeaveLateMarkRulesDetails();
                ajaxRequest.makeRequest("/LeaveLateMarkRulesDetails/Edit", "POST", LeaveLateMarkRulesDetailsData, LeaveLateMarkRulesDetails.Success);
            }
        }
        else if (LeaveLateMarkRulesDetails.ActionName == "Delete") {
            LeaveLateMarkRulesDetailsData = null;
            //$("#FormCreateLeaveLateMarkRulesDetails").validate();
            LeaveLateMarkRulesDetailsData = LeaveLateMarkRulesDetails.GetLeaveLateMarkRulesDetails();
            ajaxRequest.makeRequest("/LeaveLateMarkRulesDetails/Delete", "POST", LeaveLateMarkRulesDetailsData, LeaveLateMarkRulesDetails.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetLeaveLateMarkRulesDetails: function () {
        debugger;
        var Data = {
        };
        if (LeaveLateMarkRulesDetails.ActionName == "Create" || LeaveLateMarkRulesDetails.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.LateMarkRuleName = $('#LateMarkRuleName').val();
            Data.CentreCode = $('#CentreList').val();
            Data.LateMarkCount = $('#LateMarkCount').val();
            Data.NumberLeaveDeducted = $('#NumberLeaveDeducted').val();
            Data.LeaveID1 = $("#LeaveID1").val();
            Data.LeaveID2 = $("#LeaveID2").val();
            Data.LeaveID3 = $("#LeaveID3").val();
            Data.LeaveID4 = $("#LeaveID4").val();
            Data.LeaveID5 = $("#LeaveID5").val();
            //Data.IsActive = $('input[name=IsActive]:checked').val() ? true : false;
            Data.IsActive = $('#IsActive').is(":checked") ? "true" : "false";
        }
            
        else if (LeaveLateMarkRulesDetails.ActionName == "Delete") {
            Data.ID = $('#ID').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
       
        var splitData = data.split(',');
        if (data != null) {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            LeaveLateMarkRulesDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            LeaveLateMarkRulesDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },

};

