//this class contain methods related to nationality functionality
var CCRMCustomerSegement = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        CCRMCustomerSegement.constructor();
        //CCRMCustomerSegement.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {
        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#SelectedRegionID').focus();
            $('#SelectedRegionID').val('');
        });

        // Create new record
        $('#CreateCCRMCustomerSegementRecord').on("click", function () {
            CCRMCustomerSegement.ActionName = "Create";
            CCRMCustomerSegement.AjaxCallCCRMCustomerSegement();
        });

        $('#EditCCRMCustomerSegementRecord').on("click", function () {

            CCRMCustomerSegement.ActionName = "Edit";
            CCRMCustomerSegement.AjaxCallCCRMCustomerSegement();
        });

        $('#DeleteCCRMCustomerSegementRecord').on("click", function () {

            CCRMCustomerSegement.ActionName = "Delete";
            CCRMCustomerSegement.AjaxCallCCRMCustomerSegement();
        });
        $('#SegementName').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
        });
        $("#UserSearch").keyup(function () {
            oTable = $("#myDataTable").dataTable();
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

    },
    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax({
             cache: false,
             type: "POST",
             dataType: "html",
             url: '/CCRMCustomerSegement/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {

        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { actionMode: actionMode },
            url: '/CCRMCustomerSegement/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', colorCode);
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallCCRMCustomerSegement: function () {
        var CCRMCustomerSegementData = null;
        if (CCRMCustomerSegement.ActionName == "Create") {
            $("#FormCreateCCRMCustomerSegement").validate();
            if ($("#FormCreateCCRMCustomerSegement").valid()) {
                CCRMCustomerSegementData = null;
                CCRMCustomerSegementData = CCRMCustomerSegement.GetCCRMCustomerSegement();
                ajaxRequest.makeRequest("/CCRMCustomerSegement/Create", "POST", CCRMCustomerSegementData, CCRMCustomerSegement.Success);
            }
        }
        else if (CCRMCustomerSegement.ActionName == "Edit") {
            $("#FormEditCCRMCustomerSegement").validate();
            if ($("#FormEditCCRMCustomerSegement").valid()) {
                CCRMCustomerSegementData = null;
                CCRMCustomerSegementData = CCRMCustomerSegement.GetCCRMCustomerSegement();
                ajaxRequest.makeRequest("/CCRMCustomerSegement/Edit", "POST", CCRMCustomerSegementData, CCRMCustomerSegement.Success);
            }
        }
        else if (CCRMCustomerSegement.ActionName == "Delete") {
            CCRMCustomerSegementData = null;
            //$("#FormCreateCCRMCustomerSegement").validate();
            CCRMCustomerSegementData = CCRMCustomerSegement.GetCCRMCustomerSegement();

            ajaxRequest.makeRequest("/CCRMCustomerSegement/Delete", "POST", CCRMCustomerSegementData, CCRMCustomerSegement.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetCCRMCustomerSegement: function () {

        var Data = {
        };
        if (CCRMCustomerSegement.ActionName == "Create" || CCRMCustomerSegement.ActionName == "Edit") {
            Data.ID = $('#ID').val();
         
            Data.SegementName = $('#SegementName').val();
           
            

        }
        else if (CCRMCustomerSegement.ActionName == "Delete") {
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

            CCRMCustomerSegement.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();

            CCRMCustomerSegement.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    //this is used to for showing successfully record updation message and reload the list view
    //editSuccess: function (data) {

    //  
    //  
    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        var actionMode = "1";
    //        CCRMCustomerSegement.ReloadList("Record Updated Sucessfully.", actionMode);
    //        //  alert("Record Created Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //        // alert("Record Not Updated Sucessfully. Please Try Again..");
    //    }

    //},
    ////this is used to for showing successfully record deletion message and reload the list view
    //deleteSuccess: function (data) {

    //  
    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        CCRMCustomerSegement.ReloadList("Record Deleted Sucessfully.");
    //        //  alert("Record Deleted Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //        // alert("Record Not Deleted Sucessfully. Please Try Again..");
    //    }


    //},
};

