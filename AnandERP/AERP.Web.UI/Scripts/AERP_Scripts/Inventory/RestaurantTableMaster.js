//this class contain methods related to nationality functionality
var RestaurantTableMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        RestaurantTableMaster.constructor();
        //RestaurantTableMaster.initializeValidation();
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

        $('#CreateRestaurantTableMasterRecord').on("click", function () {

            RestaurantTableMaster.ActionName = "Create";
            RestaurantTableMaster.AjaxCallRestaurantTableMaster();
        });

        $('#EditRestaurantTableMasterRecord').on("click", function () {
            debugger;
            RestaurantTableMaster.ActionName = "Edit";
            RestaurantTableMaster.AjaxCallRestaurantTableMaster();
        });

        $('#DeleteRestaurantTableMasterRecord').on("click", function () {

            RestaurantTableMaster.ActionName = "Delete";
            RestaurantTableMaster.AjaxCallRestaurantTableMaster();
        });

        $('#MinCapacity').on("keydown", function (e) {
            AMSValidation.NotAllowSpaces(e);
            AMSValidation.AllowNumbersOnly(e);
        });

        $('#MaxCapicity').on("keydown", function (e) {
            AMSValidation.NotAllowSpaces(e);
            AMSValidation.AllowNumbersOnly(e);
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
             url: '/RestaurantTableMaster_1/List',
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
            url: '/RestaurantTableMaster_1/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record

    AjaxCallRestaurantTableMaster: function () {
        var RestaurantTableMasterData = null;

        if (RestaurantTableMaster.ActionName == "Create") {
            debugger;
            $("#FormCreateRestaurantTableMaster").validate();
            if ($("#FormCreateRestaurantTableMaster").valid()) {
                RestaurantTableMasterData = null;
                RestaurantTableMasterData = RestaurantTableMaster.GetRestaurantTableMaster();
                ajaxRequest.makeRequest("/RestaurantTableMaster_1/Create", "POST", RestaurantTableMasterData, RestaurantTableMaster.Success, "CreateRestaurantTableMasterRecord");
            }
        }
        else if (RestaurantTableMaster.ActionName == "Edit") {
            $("#FormEditRestaurantTableMaster").validate();
            if ($("#FormEditRestaurantTableMaster").valid()) {
                RestaurantTableMasterData = null;
                RestaurantTableMasterData = RestaurantTableMaster.GetRestaurantTableMaster();
                ajaxRequest.makeRequest("/RestaurantTableMaster_1/Edit", "POST", RestaurantTableMasterData, RestaurantTableMaster.Success);
            }
        }
        else if (RestaurantTableMaster.ActionName == "Delete") {

            RestaurantTableMasterData = null;
            //$("#FormCreateRestaurantTableMaster").validate();
            RestaurantTableMasterData = RestaurantTableMaster.GetRestaurantTableMaster();
            ajaxRequest.makeRequest("/RestaurantTableMaster_1/Delete", "POST", RestaurantTableMasterData, RestaurantTableMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetRestaurantTableMaster: function () {
        var Data = {
        };

        if (RestaurantTableMaster.ActionName == "Create" || RestaurantTableMaster.ActionName == "Edit") {
            debugger;
            Data.ID = $('#ID').val();
            Data.Name = $('#Name').val();
            Data.TableNumber = $('#TableNumber').val();
            Data.Shape = $('#Shape').val();
            Data.MaxCapicity = $('#MaxCapicity').val();
            Data.MinCapacity = $('#MinCapacity').val();
        }
        else if (RestaurantTableMaster.ActionName == "Delete") {

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
            RestaurantTableMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
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
//       RestaurantTableMaster.ReloadList("Record Updated Sucessfully.", actionMode);
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
//        RestaurantTableMaster.ReloadList("Record Deleted Sucessfully.");
//      //  alert("Record Deleted Sucessfully.");

//    } else {
//        parent.$.colorbox.close();
//       // alert("Record Not Deleted Sucessfully. Please Try Again..");
//    }


//},


