//this class contain methods related to nationality functionality
var GeneralCounterMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        GeneralCounterMaster.constructor();
        //GeneralCounterMaster.initializeValidation();
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

        $('#CreateGeneralCounterMasterRecord').on("click", function () {
            debugger
            GeneralCounterMaster.ActionName = "Create";
            GeneralCounterMaster.AjaxCallGeneralCounterMaster();
        });

        $('#EditGeneralCounterMasterRecord').on("click", function () {

            GeneralCounterMaster.ActionName = "Edit";
            GeneralCounterMaster.AjaxCallGeneralCounterMaster();
        });

        $('#CounterCode').on("keydown", function (e) {
            AMSValidation.NotAllowSpaces(e);

        });
        $('#DeleteGeneralCounterMasterRecord').on("click", function () {

            GeneralCounterMaster.ActionName = "Delete";
            GeneralCounterMaster.AjaxCallGeneralCounterMaster();
        });

        //$('#GroupDescription').on("keydown", function (e) {
        //    AMSValidation.AllowCharacterOnly(e);
        //});

        //$('#MarchandiseGroupCode').on("keydown", function (e) {
        //    AMSValidation.NotAllowSpaces(e);

        //});

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
             url: '/GeneralCounterMaster/List',
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
            url: '/GeneralCounterMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record

    AjaxCallGeneralCounterMaster: function () {
        var GeneralCounterMasterData = null;

        if (GeneralCounterMaster.ActionName == "Create") {
            debugger;
            $("#FormCreateGeneralCounterMaster").validate();
            if ($("#FormCreateGeneralCounterMaster").valid()) {
                GeneralCounterMasterData = null;
                GeneralCounterMasterData = GeneralCounterMaster.GetGeneralCounterMaster();
                ajaxRequest.makeRequest("/GeneralCounterMaster/Create", "POST", GeneralCounterMasterData, GeneralCounterMaster.Success, "CreateGeneralCounterMasterRecord");
            }
        }
        else if (GeneralCounterMaster.ActionName == "Edit") {
            $("#FormEditGeneralCounterMaster").validate();
            if ($("#FormEditGeneralCounterMaster").valid()) {
                GeneralCounterMasterData = null;
                GeneralCounterMasterData = GeneralCounterMaster.GetGeneralCounterMaster();
                ajaxRequest.makeRequest("/GeneralCounterMaster/Edit", "POST", GeneralCounterMasterData, GeneralCounterMaster.Success, "EditGeneralCounterMasterRecord");
            }
        }
        else if (GeneralCounterMaster.ActionName == "Delete") {

            GeneralCounterMasterData = null;
            //$("#FormCreateGeneralCounterMaster").validate();
            GeneralCounterMasterData = GeneralCounterMaster.GetGeneralCounterMaster();
            ajaxRequest.makeRequest("/GeneralCounterMaster/Delete", "POST", GeneralCounterMasterData, GeneralCounterMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetGeneralCounterMaster: function () {
        var Data = {
        };

        if (GeneralCounterMaster.ActionName == "Create" || GeneralCounterMaster.ActionName == "Edit") {

            Data.ID = $('#ID').val();
            Data.CounterName = $('#CounterName').val();
            Data.CounterCode = $('#CounterCode').val();


        }
        else if (GeneralCounterMaster.ActionName == "Delete") {

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
            GeneralCounterMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
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
//       GeneralCounterMaster.ReloadList("Record Updated Sucessfully.", actionMode);
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
//        GeneralCounterMaster.ReloadList("Record Deleted Sucessfully.");
//      //  alert("Record Deleted Sucessfully.");

//    } else {
//        parent.$.colorbox.close();
//       // alert("Record Not Deleted Sucessfully. Please Try Again..");
//    }


//},


