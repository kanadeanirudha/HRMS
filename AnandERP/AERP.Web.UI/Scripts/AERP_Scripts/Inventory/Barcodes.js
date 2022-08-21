//this class contain methods related to nationality functionality
var Barcodes = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        Barcodes.constructor();
        //Barcodes.initializeValidation();
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

        $('#CreateBarcodesRecord').on("click", function () {
            debugger;
            Barcodes.ActionName = "Create";
            Barcodes.AjaxCallBarcodes();
        });

        $('#EditBarcodesRecord').on("click", function () {

            Barcodes.ActionName = "Edit";
            Barcodes.AjaxCallBarcodes();
        });

        $('#DeleteBarcodesRecord').on("click", function () {

            Barcodes.ActionName = "Delete";
            Barcodes.AjaxCallBarcodes();
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
    LoadList: function () {

        $.ajax(
         {
             cache: false,
             type: "POST",

             dataType: "html",
             url: '/Barcodes/List',
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
            url: '/Barcodes/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record

    AjaxCallBarcodes: function () {
        var BarcodesData = null;

        if (Barcodes.ActionName == "Create") {
            debugger;
            $("#FormCreateBarcodes").validate();
            if ($("#FormCreateBarcodes").valid()) {
                BarcodesData = null;
                BarcodesData = Barcodes.GetBarcodes();
                ajaxRequest.makeRequest("/Barcodes/Create", "POST", BarcodesData, Barcodes.Success, "CreateBarcodesRecord");
            }
        }
        else if (Barcodes.ActionName == "Edit") {
            $("#FormEditBarcodes").validate();
            if ($("#FormEditBarcodes").valid()) {
                BarcodesData = null;
                BarcodesData = Barcodes.GetBarcodes();
                ajaxRequest.makeRequest("/Barcodes/Edit", "POST", BarcodesData, Barcodes.Success);
            }
        }
        else if (Barcodes.ActionName == "Delete") {

            BarcodesData = null;
            //$("#FormCreateBarcodes").validate();
            BarcodesData = Barcodes.GetBarcodes();
            ajaxRequest.makeRequest("/Barcodes/Delete", "POST", BarcodesData, Barcodes.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetBarcodes: function () {
        var Data = {
        };

        if (Barcodes.ActionName == "Create" || Barcodes.ActionName == "Edit") {
            debugger;
            Data.GeneralItemMasterID = $('#GeneralItemMasterID').val();
            Data.GeneralItemCodeID = $('#GeneralItemCodeID').val();
            Data.ItemNumber = $('#ItemNumber').val();
            Data.ItemDescription = $('#ItemDescription').val();
            Data.UomCode = $('#UomCode').val();
            Data.UoMGroupCode = $('#UoMGroupCode').val();
            Data.BarCode = $('#BarCode').val();
            Data.IsDefault = $("#IsDefault").is(":checked") ? "true" : "false";
            Data.IsBaseUom = $("#IsBaseUom").is(":checked") ? "true" : "false";


        }
        else if (Barcodes.ActionName == "Delete") {

            Data.ID = $('#ID').val();
            // Data.ID = $('input[name=ID]').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {


        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            Barcodes.ReloadList(splitData[0], splitData[1], splitData[2]);
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
//       Barcodes.ReloadList("Record Updated Sucessfully.", actionMode);
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
//        Barcodes.ReloadList("Record Deleted Sucessfully.");
//      //  alert("Record Deleted Sucessfully.");

//    } else {
//        parent.$.colorbox.close();
//       // alert("Record Not Deleted Sucessfully. Please Try Again..");
//    }


//},


