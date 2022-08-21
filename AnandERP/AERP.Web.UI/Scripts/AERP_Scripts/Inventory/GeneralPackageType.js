//this class contain methods related to nationality functionality
var GeneralPackageType = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        GeneralPackageType.constructor();
        //GeneralPackageType.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#PackageType').focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#GroupDescription').focus();
            return false;
        });



        // Create new record

        $('#CreateGeneralPackageTypeRecord').on("click", function () {
            debugger;
            GeneralPackageType.ActionName = "Create";
            GeneralPackageType.AjaxCallGeneralPackageType();
        });

        $('#EditGeneralPackageTypeRecord').on("click", function () {

            GeneralPackageType.ActionName = "Edit";
            GeneralPackageType.AjaxCallGeneralPackageType();
        });

        $('#DeleteGeneralPackageTypeRecord').on("click", function () {

            GeneralPackageType.ActionName = "Delete";
            GeneralPackageType.AjaxCallGeneralPackageType();
        });

        $('#PackageType').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
        });


        $('#Height').on("keydown", function (e) {
            AERPValidation.AllowNumbersWithDecimalOnly(e);
        });

        $('#Length').on("keydown", function (e) {
            AERPValidation.AllowNumbersWithDecimalOnly(e);
        });
        $('#Width').on("keydown", function (e) {
            AERPValidation.AllowNumbersWithDecimalOnly(e);
        });
        $('#Weight').on("keydown", function (e) {
            AERPValidation.AllowNumbersWithDecimalOnly(e);
        });
        $('#Volume').on("keydown", function (e) {
            AERPValidation.AllowNumbersWithDecimalOnly(e);
        });

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
             url: '/GeneralPackageType/List',
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
            url: '/GeneralPackageType/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record

    AjaxCallGeneralPackageType: function () {
        var GeneralPackageTypeData = null;

        if (GeneralPackageType.ActionName == "Create") {
            debugger;
            $("#FormCreateGeneralPackageType").validate();
            if ($("#FormCreateGeneralPackageType").valid()) {
                GeneralPackageTypeData = null;
                GeneralPackageTypeData = GeneralPackageType.GetGeneralPackageType();
                ajaxRequest.makeRequest("/GeneralPackageType/Create", "POST", GeneralPackageTypeData, GeneralPackageType.Success, "CreateGeneralPackageTypeRecord");
            }
        }
        else if (GeneralPackageType.ActionName == "Edit") {
            $("#FormEditGeneralPackageType").validate();
            if ($("#FormEditGeneralPackageType").valid()) {
                GeneralPackageTypeData = null;
                GeneralPackageTypeData = GeneralPackageType.GetGeneralPackageType();
                ajaxRequest.makeRequest("/GeneralPackageType/Edit", "POST", GeneralPackageTypeData, GeneralPackageType.Success);
            }
        }
        else if (GeneralPackageType.ActionName == "Delete") {

            GeneralPackageTypeData = null;
            //$("#FormCreateGeneralPackageType").validate();
            GeneralPackageTypeData = GeneralPackageType.GetGeneralPackageType();
            ajaxRequest.makeRequest("/GeneralPackageType/Delete", "POST", GeneralPackageTypeData, GeneralPackageType.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetGeneralPackageType: function () {
        var Data = {
        };

        if (GeneralPackageType.ActionName == "Create" || GeneralPackageType.ActionName == "Edit") {
            debugger
            Data.ID = $('#ID').val();
            Data.PackageType = $('#PackageType').val();
            Data.Height = $('#Height').val();
            Data.Length = $('#Length').val();
            Data.Width = $('#Width').val();
            Data.Weight = $('#Weight').val();
            Data.Volume = $('#Volume').val();

        }
        else if (GeneralPackageType.ActionName == "Delete") {

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
            GeneralPackageType.ReloadList(splitData[0], splitData[1], splitData[2], splitData[3]);
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
//       GeneralPackageType.ReloadList("Record Updated Sucessfully.", actionMode);
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
//        GeneralPackageType.ReloadList("Record Deleted Sucessfully.");
//      //  alert("Record Deleted Sucessfully.");

//    } else {
//        parent.$.colorbox.close();
//       // alert("Record Not Deleted Sucessfully. Please Try Again..");
//    }


//},


