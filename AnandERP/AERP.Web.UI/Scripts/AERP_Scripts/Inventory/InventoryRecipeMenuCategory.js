//this class contain methods related to nationality functionality
var InventoryRecipeMenuCategory = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        InventoryRecipeMenuCategory.constructor();
        //InventoryRecipeMenuCategory.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#GroupDescription').focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#GroupDescription').focus();
            return false;
        });



        // Create new record

        $('#CreateInventoryRecipeMenuCategoryRecord').on("click", function () {

            InventoryRecipeMenuCategory.ActionName = "Create";
            InventoryRecipeMenuCategory.AjaxCallInventoryRecipeMenuCategory();
        });

        $('#EditInventoryRecipeMenuCategoryRecord').on("click", function () {

            InventoryRecipeMenuCategory.ActionName = "Edit";
            InventoryRecipeMenuCategory.AjaxCallInventoryRecipeMenuCategory();
        });

        $('#DeleteInventoryRecipeMenuCategoryRecord').on("click", function () {

            InventoryRecipeMenuCategory.ActionName = "Delete";
            InventoryRecipeMenuCategory.AjaxCallInventoryRecipeMenuCategory();
        });

        $('#MenuCategory').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#MenuCategoryCode').on("keydown", function (e) {
            AMSValidation.NotAllowSpaces(e);
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
             url: '/InventoryRecipeMenuCategory/List',
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
            url: '/InventoryRecipeMenuCategory/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record

    AjaxCallInventoryRecipeMenuCategory: function () {
        var InventoryRecipeMenuCategoryData = null;

        if (InventoryRecipeMenuCategory.ActionName == "Create") {
            debugger;
            $("#FormCreateInventoryRecipeMenuCategory").validate();
            if ($("#FormCreateInventoryRecipeMenuCategory").valid()) {
                InventoryRecipeMenuCategoryData = null;
                InventoryRecipeMenuCategoryData = InventoryRecipeMenuCategory.GetInventoryRecipeMenuCategory();
                ajaxRequest.makeRequest("/InventoryRecipeMenuCategory/Create", "POST", InventoryRecipeMenuCategoryData, InventoryRecipeMenuCategory.Success, "CreateInventoryRecipeMenuCategoryRecord");
            }
        }
        else if (InventoryRecipeMenuCategory.ActionName == "Edit") {
            $("#FormEditInventoryRecipeMenuCategory").validate();
            if ($("#FormEditInventoryRecipeMenuCategory").valid()) {
                InventoryRecipeMenuCategoryData = null;
                InventoryRecipeMenuCategoryData = InventoryRecipeMenuCategory.GetInventoryRecipeMenuCategory();
                ajaxRequest.makeRequest("/InventoryRecipeMenuCategory/Edit", "POST", InventoryRecipeMenuCategoryData, InventoryRecipeMenuCategory.Success);
            }
        }
        else if (InventoryRecipeMenuCategory.ActionName == "Delete") {

            InventoryRecipeMenuCategoryData = null;
            //$("#FormCreateInventoryRecipeMenuCategory").validate();
            InventoryRecipeMenuCategoryData = InventoryRecipeMenuCategory.GetInventoryRecipeMenuCategory();
            ajaxRequest.makeRequest("/InventoryRecipeMenuCategory/Delete", "POST", InventoryRecipeMenuCategoryData, InventoryRecipeMenuCategory.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetInventoryRecipeMenuCategory: function () {
        var Data = {
        };

        if (InventoryRecipeMenuCategory.ActionName == "Create" || InventoryRecipeMenuCategory.ActionName == "Edit") {
            debugger;
            Data.ID = $('#ID').val();
            Data.MenuCategory = $('#MenuCategory').val();
            Data.MenuCategoryCode = $('#MenuCategoryCode').val();
            Data.CategoryType = $('#CategoryType').val();
            Data.ItemCategoryCode = $('#ItemCategoryCode').val();
            Data.IsActive = $('#IsActive').is(":checked") ? "true" : "false";

        }
        else if (InventoryRecipeMenuCategory.ActionName == "Delete") {
                
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
            InventoryRecipeMenuCategory.ReloadList(splitData[0], splitData[1], splitData[2]);
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
//       InventoryRecipeMenuCategory.ReloadList("Record Updated Sucessfully.", actionMode);
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
//        InventoryRecipeMenuCategory.ReloadList("Record Deleted Sucessfully.");
//      //  alert("Record Deleted Sucessfully.");

//    } else {
//        parent.$.colorbox.close();
//       // alert("Record Not Deleted Sucessfully. Please Try Again..");
//    }


//},


