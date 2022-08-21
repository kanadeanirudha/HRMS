//this class contain methods related to nationality functionality
var InventoryAttributeMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        InventoryAttributeMaster.constructor();
        //InventoryAttributeMaster.initializeValidation();
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

        $('#CreateInventoryAttributeMasterRecord').on("click", function () {
            debugger;
            InventoryAttributeMaster.ActionName = "Create";
            InventoryAttributeMaster.AjaxCallInventoryAttributeMaster();
        });

        $('#EditInventoryAttributeMasterRecord').on("click", function () {

            InventoryAttributeMaster.ActionName = "Edit";
            InventoryAttributeMaster.AjaxCallInventoryAttributeMaster();
        });

        $('#DeleteInventoryAttributeMasterRecord').on("click", function () {

            InventoryAttributeMaster.ActionName = "Delete";
            InventoryAttributeMaster.AjaxCallInventoryAttributeMaster();
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
        debugger;
        $.ajax(
         {
             cache: false,
             type: "POST",

             dataType: "html",
             url: '/InventoryAttributeMaster/List',
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
            data: { actionMode: null },
            url: '/InventoryAttributeMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record

    AjaxCallInventoryAttributeMaster: function () {
        var InventoryAttributeMasterData = null;

        if (InventoryAttributeMaster.ActionName == "Create") {

            $("#FormCreateInventoryAttributeMaster").validate();
            if ($("#FormCreateInventoryAttributeMaster").valid()) {
                InventoryAttributeMasterData = null;
                InventoryAttributeMasterData = InventoryAttributeMaster.GetInventoryAttributeMaster();
                ajaxRequest.makeRequest("/InventoryAttributeMaster/Create", "POST", InventoryAttributeMasterData, InventoryAttributeMaster.Success, "CreateInventoryAttributeMasterRecord");
            }
        }
        else if (InventoryAttributeMaster.ActionName == "Edit") {
            debugger;
            $("#FormEditInventoryAttributeMaster").validate();
            if ($("#FormEditInventoryAttributeMaster").valid()) {
                InventoryAttributeMasterData = null;
                InventoryAttributeMasterData = InventoryAttributeMaster.GetInventoryAttributeMaster();
                ajaxRequest.makeRequest("/InventoryAttributeMaster/Edit", "POST", InventoryAttributeMasterData, InventoryAttributeMaster.Success);
            }
        }
        else if (InventoryAttributeMaster.ActionName == "Delete") {

            InventoryAttributeMasterData = null;
            //$("#FormCreateInventoryAttributeMaster").validate();
            InventoryAttributeMasterData = InventoryAttributeMaster.GetInventoryAttributeMaster();
            ajaxRequest.makeRequest("/InventoryAttributeMaster/Delete", "POST", InventoryAttributeMasterData, InventoryAttributeMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetInventoryAttributeMaster: function () {
        debugger;
        var Data = {
        };

        if (InventoryAttributeMaster.ActionName == "Create" || InventoryAttributeMaster.ActionName == "Edit") {

            Data.InventoryAttributeMasterID = $('#InventoryAttributeMasterID').val();
            Data.AttributeName = $('#AttributeName').val();

        }
        else if (InventoryAttributeMaster.ActionName == "Delete") {

            Data.InventoryAttributeMasterID = $('#ID').val();
            // Data.ID = $('input[name=ID]').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {

      
        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            InventoryAttributeMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            //$("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
            $.magnificPopup.close()
            InventoryAttributeMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },

};

//this is used to for showing successfully record updation message and reload the list view
// editSuccess: function (data) {



// if (data == "True") {

//        parent.$.colorbox.close();
//    var actionMode = "1";
//       InventoryAttributeMaster.ReloadList("Record Updated Sucessfully.", actionMode);
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
//        InventoryAttributeMaster.ReloadList("Record Deleted Sucessfully.");
//      //  alert("Record Deleted Sucessfully.");

//    } else {
//        parent.$.colorbox.close();
//       // alert("Record Not Deleted Sucessfully. Please Try Again..");
//    }


//},


