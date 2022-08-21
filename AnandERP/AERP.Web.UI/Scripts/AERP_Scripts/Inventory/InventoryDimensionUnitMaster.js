//this class contain methods related to nationality functionality
var InventoryDimensionUnitMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        InventoryDimensionUnitMaster.constructor();
        //InventoryDimensionUnitMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#DimensionCode').focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#DimensionCode').focus();
            return false;
        });



        // Create new record

        $('#CreateInventoryDimensionUnitMasterRecord').on("click", function () {
            InventoryDimensionUnitMaster.ActionName = "Create";
            InventoryDimensionUnitMaster.AjaxCallInventoryDimensionUnitMaster();
        });

        $('#EditInventoryDimensionUnitMasterRecord').on("click", function () {

            InventoryDimensionUnitMaster.ActionName = "Edit";
            InventoryDimensionUnitMaster.AjaxCallInventoryDimensionUnitMaster();
        });

        $('#DeleteInventoryDimensionUnitMasterRecord').on("click", function () {

            InventoryDimensionUnitMaster.ActionName = "Delete";
            InventoryDimensionUnitMaster.AjaxCallInventoryDimensionUnitMaster();
        });

        $('#DimensionDescription').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#SIUnit').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#SIDescription').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
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
             url: '/InventoryDimensionUnitMaster/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);

             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode,reloadParam) {

        $.ajax(
        {

            cache: false,
            type: "POST",
            dataType: "html",
            data: { actionMode: actionMode },
            url: '/InventoryDimensionUnitMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record

    AjaxCallInventoryDimensionUnitMaster: function () {
        var InventoryDimensionUnitMasterData = null;

        if (InventoryDimensionUnitMaster.ActionName == "Create") {
            $("#FormCreateInventoryDimensionUnitMaster").validate();
            if ($("#FormCreateInventoryDimensionUnitMaster").valid()) {
                InventoryDimensionUnitMasterData = null;
                InventoryDimensionUnitMasterData = InventoryDimensionUnitMaster.GetInventoryDimensionUnitMaster();
                ajaxRequest.makeRequest("/InventoryDimensionUnitMaster/Create", "POST", InventoryDimensionUnitMasterData, InventoryDimensionUnitMaster.Success, "CreateInventoryDimensionUnitMasterRecord");
            }
        }
        else if (InventoryDimensionUnitMaster.ActionName == "Edit") {
            $("#FormEditInventoryDimensionUnitMaster").validate();
            if ($("#FormEditInventoryDimensionUnitMaster").valid()) {
                InventoryDimensionUnitMasterData = null;
                InventoryDimensionUnitMasterData = InventoryDimensionUnitMaster.GetInventoryDimensionUnitMaster();
                ajaxRequest.makeRequest("/InventoryDimensionUnitMaster/Edit", "POST", InventoryDimensionUnitMasterData, InventoryDimensionUnitMaster.Success);
            }
        }
        else if (InventoryDimensionUnitMaster.ActionName == "Delete") {
            debugger
            InventoryDimensionUnitMasterData = null;
            //$("#FormCreateInventoryDimensionUnitMaster").validate();
            InventoryDimensionUnitMasterData = InventoryDimensionUnitMaster.GetInventoryDimensionUnitMaster();
            ajaxRequest.makeRequest("/InventoryDimensionUnitMaster/Delete", "POST", InventoryDimensionUnitMasterData, InventoryDimensionUnitMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetInventoryDimensionUnitMaster: function () {
        var Data = {
        };

        if (InventoryDimensionUnitMaster.ActionName == "Create" || InventoryDimensionUnitMaster.ActionName == "Edit") {
            
            Data.ID = $('#ID').val();
            Data.DimensionCode = $('#DimensionCode').val();
            Data.DimensionDescription = $('#DimensionDescription').val();
            Data.SIUnit = $('#SIUnit').val();
            Data.SIDescription = $('#SIDescription').val();


        }
        else if (InventoryDimensionUnitMaster.ActionName == "Delete") {
            debugger
            Data.ID = $('#ID').val();
            // Data.ID = $('input[name=ID]').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {

        debugger;
        debugger;
        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            InventoryDimensionUnitMaster.ReloadList(splitData[0], splitData[1], splitData[2], splitData[2]);
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
//       InventoryDimensionUnitMaster.ReloadList("Record Updated Sucessfully.", actionMode);
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
//        InventoryDimensionUnitMaster.ReloadList("Record Deleted Sucessfully.");
//      //  alert("Record Deleted Sucessfully.");

//    } else {
//        parent.$.colorbox.close();
//       // alert("Record Not Deleted Sucessfully. Please Try Again..");
//    }


//},


