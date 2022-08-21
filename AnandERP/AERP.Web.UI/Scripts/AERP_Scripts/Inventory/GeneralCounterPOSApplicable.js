//this class contain methods related to nationality functionality
var GeneralCounterPOSApplicable = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        GeneralCounterPOSApplicable.constructor();
        //GeneralCounterPOSApplicable.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

       

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');

            return false;
        });
        //$('#ItemDescription').on("keydown", function (e) {
        //    AMSValidation.AllowAlphaNumericOnly(e);
        //    if (e.keyCode == 8 || e.keyCode == 46) {
               
        //        $("#ItemNumber").val("");
        //        $("#UoMGroupCode").val("");
        //        $("#UomCode").val("");
        //        $("#BarCode").val("");
        //        $('#IsDefault').removeAttr('checked');
        //        $('#IsBaseUom').removeAttr('checked');
        //    }
        //});


        // Create new record
        $("#DateFrom").datetimepicker({
            format: 'DD MMM YYYY',
            maxDate: moment(),
        });

        $("#DateFrom").on("keydown", function () {
            var keycode = (e.keyCode ? e.keyCode : e.which);
            if (keycode != 9) {
                return false;
            }
        });
        $("#DateUpto").datetimepicker({
            format: 'DD MMM YYYY',
        });

        $("#btnShowList").unbind("click").on("click", function () {
            var CentreCode = $('#CentreCode :selected').val();
            if (CentreCode != "") {
                GeneralCounterPOSApplicable.LoadList(CentreCode);
            }
            else if (CentreCode == "") {
                notify("Please select Centre Code", 'warning');
            }
        });

        $("#CentreCode").change(function () {
            var selectedItem = [];
            var selectedItem = $(this).val();
            var abc = selectedItem.split(':');
            var selectedcentrecode = abc[0];
            var $ddlGeneralUnitsID = $("#GeneralUnitsID");
            var $GeneralUnitsIDProgress = $("#GeneralUnitsID-loading-progress");
            $GeneralUnitsIDProgress.show();
            if ($("#CentreCode").val() !== "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: '/GeneralCounterPOSApplicable/GetGeneralUnitsForItemmasterList',
                    data: { "centreCode": selectedcentrecode },
                    success: function (data) {
                        $ddlGeneralUnitsID.html('');
                        $ddlGeneralUnitsID.append('<option value="">-------Select Unit------</option>');
                        $.each(data, function (id, option) {

                            $ddlGeneralUnitsID.append($('<option></option>').val(option.id).html(option.name));
                        });
                        $GeneralUnitsIDProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve GeneralUnitsID.');
                        $GeneralUnitsIDProgress.hide();
                    }
                });
            }
            else {
                $('#GeneralUnitsID').find('option').remove().end().append('<option value>-------Select General Unit------</option>');
            }

        });


        $('#CreateGeneralCounterPOSApplicableRecord').on("click", function () {
            debugger;
            GeneralCounterPOSApplicable.ActionName = "Create";
            GeneralCounterPOSApplicable.AjaxCallGeneralCounterPOSApplicable();
        });

        $('#EditGeneralCounterPOSApplicableRecord').on("click", function () {
            debugger;
            GeneralCounterPOSApplicable.ActionName = "Edit";
            if ($("#DateUpto").val() == "" || $("#DateUpto").val() == null)
            {
                $("#displayErrorMessage p").text("Please Enter Upto Date.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            GeneralCounterPOSApplicable.AjaxCallGeneralCounterPOSApplicable();
        });

        $('#DeleteGeneralCounterPOSApplicableRecord').on("click", function () {

            GeneralCounterPOSApplicable.ActionName = "Delete";
            GeneralCounterPOSApplicable.AjaxCallGeneralCounterPOSApplicable();
        });

     

        InitAnimatedBorder();

        CloseAlert();

        //   $('#CountryName').on("keydown", function (e) {
        //AMSValidation.AllowCharacterOnly(e);
        // });
        //  $('#ContryCode').on("keydown", function (e) {
        //   AMSValidation.AllowCharacterOnly(e);
        //  if (e.keyCode == 32) {
        //       return false;
        // }
        // });
        //$("#UserSearch").keyup(function () {
        //    var oTable = $("#myDataTable").dataTable();
        //    oTable.fnFilter(this.value);
        //});

        //$("#searchBtn").click(function () {
        //    $("#UserSearch").focus();
        //});


        //$("#showrecord").change(function () {
        //    var showRecord = $("#showrecord").val();
        //    $("select[name*='myDataTable_length']").val(showRecord);
        //    $("select[name*='myDataTable_length']").change();
        //});

        // $(".ajax").colorbox();


    },
    //LoadList method is used to load List page
    LoadList: function (CentreCode) {
        debugger;
        $.ajax(
         {
             cache: false,
             type: "POST",
             data: {CentreCode: CentreCode },
             dataType: "html",
             url: '/GeneralCounterPOSApplicable/List',
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
            data: { actionMode: actionMode },
            url: '/GeneralCounterPOSApplicable/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record

    AjaxCallGeneralCounterPOSApplicable: function () {
        var GeneralCounterPOSApplicableData = null;

        if (GeneralCounterPOSApplicable.ActionName == "Create") {
            debugger;
            $("#FormCreateGeneralCounterPOSApplicable").validate();
            if ($("#FormCreateGeneralCounterPOSApplicable").valid()) {
                GeneralCounterPOSApplicableData = null;
                GeneralCounterPOSApplicableData = GeneralCounterPOSApplicable.GetGeneralCounterPOSApplicable();
                ajaxRequest.makeRequest("/GeneralCounterPOSApplicable/Create", "POST", GeneralCounterPOSApplicableData, GeneralCounterPOSApplicable.Success, "CreateGeneralCounterPOSApplicableRecord");
            }
        }
        else if (GeneralCounterPOSApplicable.ActionName == "Edit") {
            $("#FormEditGeneralCounterPOSApplicable").validate();
            if ($("#FormEditGeneralCounterPOSApplicable").valid()) {
                GeneralCounterPOSApplicableData = null;
                GeneralCounterPOSApplicableData = GeneralCounterPOSApplicable.GetGeneralCounterPOSApplicable();
                ajaxRequest.makeRequest("/GeneralCounterPOSApplicable/Edit", "POST", GeneralCounterPOSApplicableData, GeneralCounterPOSApplicable.Success, "EditGeneralCounterPOSApplicableRecord");
            }
        }
        else if (GeneralCounterPOSApplicable.ActionName == "Delete") {

            GeneralCounterPOSApplicableData = null;
            //$("#FormCreateGeneralCounterPOSApplicable").validate();
            GeneralCounterPOSApplicableData = GeneralCounterPOSApplicable.GetGeneralCounterPOSApplicable();
            ajaxRequest.makeRequest("/GeneralCounterPOSApplicable/Delete", "POST", GeneralCounterPOSApplicableData, GeneralCounterPOSApplicable.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetGeneralCounterPOSApplicable: function () {
        var Data = {
        };
        debugger;
        if (GeneralCounterPOSApplicable.ActionName == "Create" || GeneralCounterPOSApplicable.ActionName == "Edit") {
            debugger;
            Data.ID = $('#ID').val();
            Data.GeneralUnitsID = $('#GeneralUnitsID').val();
            Data.GeneralCounterMasterId = $('#GeneralCounterMasterId').val();
            Data.GeneralPOSMasterId = $('#GeneralPOSMasterId').val();
            Data.DateFrom = $('#DateFrom').val();
            Data.DateUpto = $('#DateUpto').val();
        }
        else if (GeneralCounterPOSApplicable.ActionName == "Delete") {

            Data.ID = $('#ID').val();
            // Data.ID = $('input[name=ID]').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {

        debugger;
        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            GeneralCounterPOSApplicable.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};

//this is used to for showing successfully record updation message and reload the list view
// editSuccess: function (data) {



// if (data == "True") {

//        parent.$.colorbox.close();
//    var actionMode = "1";
//       GeneralCounterPOSApplicable.ReloadList("Record Updated Sucessfully.", actionMode);
//        //  alert("Record Created Sucessfully.");

//    } else {
//        parent.$.colorbox.close();
//        // alert("Record Not Updated Sucessfully. Please Try Again..");
//    }

//},
////this is used to for showing successfully record deletion message and reload the list view
//deleteSuccess: function (data) {


//    if (data == "True") {

//        parent.$.colorbox.close();
//        GeneralCounterPOSApplicable.ReloadList("Record Deleted Sucessfully.");
//      //  alert("Record Deleted Sucessfully.");

//    } else {
//        parent.$.colorbox.close();
//       // alert("Record Not Deleted Sucessfully. Please Try Again..");
//    }


//},


