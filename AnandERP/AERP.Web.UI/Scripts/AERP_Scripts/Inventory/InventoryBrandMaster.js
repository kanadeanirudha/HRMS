//this class contain methods related to nationality functionality
var InventoryBrandMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        InventoryBrandMaster.constructor();
        //InventoryBrandMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#MarchandiseBaseCategoryName').focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#MarchandiseBaseCategoryName').focus();
            return false;
        });



        // Create new record

        $('#CreateInventoryBrandMasterRecord').on("click", function () {
            debugger;
            InventoryBrandMaster.ActionName = "Create";
            InventoryBrandMaster.AjaxCallInventoryBrandMaster();
        });

        $('#EditInventoryBrandMasterRecords').on("click", function () {
            debugger;
            InventoryBrandMaster.ActionName = "Edit";
            InventoryBrandMaster.AjaxCallInventoryBrandMaster();
        });

        $('#DeleteInventoryBrandMasterRecord').on("click", function () {

            InventoryBrandMaster.ActionName = "Delete";
            InventoryBrandMaster.AjaxCallInventoryBrandMaster();
        });

        //$('#MarchandiseBaseCategoryName').on("keydown", function (e) {
        //    AERPValidation.AllowCharacterOnly(e);
        //});

        //$('#MarchandiseBaseCategoryCode').on("keydown", function (e) {
        //    AERPValidation.NotAllowSpaces(e);

        //});

        InitAnimatedBorder();

        CloseAlert();

        //   $('#CountryName').on("keydown", function (e) {
        //AERPValidation.AllowCharacterOnly(e);
        // });
        //  $('#ContryCode').on("keydown", function (e) {
        //   AERPValidation.AllowCharacterOnly(e);
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
             url: '/InventoryBrandMaster/List',
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
            url: '/InventoryBrandMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record

    AjaxCallInventoryBrandMaster: function () {
        var InventoryBrandMasterData = null;

        if (InventoryBrandMaster.ActionName == "Create") {

            $("#FormCreateInventoryBrandMaster").validate();
            if ($("#FormCreateInventoryBrandMaster").valid()) {
                InventoryBrandMasterData = null;
                InventoryBrandMasterData = InventoryBrandMaster.GetInventoryBrandMaster();
                ajaxRequest.makeRequest("/InventoryBrandMaster/Create", "POST", InventoryBrandMasterData, InventoryBrandMaster.Success, "CreateInventoryBrandMasterRecord");
            }
        }
        else if (InventoryBrandMaster.ActionName == "Edit") {
            $("#FormEditInventoryBrandMaster").validate();
            if ($("#FormEditInventoryBrandMaster").valid()) {
                InventoryBrandMasterData = null;
                InventoryBrandMasterData = InventoryBrandMaster.GetInventoryBrandMaster();
                ajaxRequest.makeRequest("/InventoryBrandMaster/Edit", "POST", InventoryBrandMasterData, InventoryBrandMaster.Success);
            }
        }
        else if (InventoryBrandMaster.ActionName == "Delete") {

            InventoryBrandMasterData = null;
            //$("#FormCreateInventoryBrandMaster").validate();
            InventoryBrandMasterData = InventoryBrandMaster.GetInventoryBrandMaster();
            ajaxRequest.makeRequest("/InventoryBrandMaster/Delete", "POST", InventoryBrandMasterData, InventoryBrandMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetInventoryBrandMaster: function () {
        var Data = {
        };

        if (InventoryBrandMaster.ActionName == "Create" || InventoryBrandMaster.ActionName == "Edit") {

            Data.ID = $('#ID').val();
            Data.BrandName = $('#BrandName').val();
            


        }
        else if (InventoryBrandMaster.ActionName == "Delete") {

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
            InventoryBrandMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
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
//       InventoryBrandMaster.ReloadList("Record Updated Sucessfully.", actionMode);
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
//        InventoryBrandMaster.ReloadList("Record Deleted Sucessfully.");
//      //  alert("Record Deleted Sucessfully.");

//    } else {
//        parent.$.colorbox.close();
//       // alert("Record Not Deleted Sucessfully. Please Try Again..");
//    }


//},


