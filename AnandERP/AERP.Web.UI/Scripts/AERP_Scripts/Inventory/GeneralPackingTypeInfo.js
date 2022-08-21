//this class contain methods related to nationality functionality
var GeneralPackingTypeInfo = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        GeneralPackingTypeInfo.constructor();
        //GeneralPackingTypeInfo.initializeValidation();
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

        $('#CreateGeneralPackingTypeInfoRecord').on("click", function () {
            
            GeneralPackingTypeInfo.ActionName = "Create";
            GeneralPackingTypeInfo.AjaxCallGeneralPackingTypeInfo();
        });

        $('#EditGeneralPackingTypeInfoRecord').on("click", function () {

            GeneralPackingTypeInfo.ActionName = "Edit";
            GeneralPackingTypeInfo.AjaxCallGeneralPackingTypeInfo();
        });

        $('#DeleteGeneralPackingTypeInfoRecord').on("click", function () {

            GeneralPackingTypeInfo.ActionName = "Delete";
            GeneralPackingTypeInfo.AjaxCallGeneralPackingTypeInfo();
        });

        $('#PackageType').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });


        $('#Height').on("keydown", function (e) {
            AMSValidation.AllowNumbersWithDecimalOnly(e);
        });

        $('#Length').on("keydown", function (e) {
            AMSValidation.AllowNumbersWithDecimalOnly(e);
        });
        $('#Width').on("keydown", function (e) {
            AMSValidation.AllowNumbersWithDecimalOnly(e);
        });
        $('#Weight').on("keydown", function (e) {
            AMSValidation.AllowNumbersWithDecimalOnly(e);
        });
        $('#Volume').on("keydown", function (e) {
            AMSValidation.AllowNumbersWithDecimalOnly(e);
        });
        $('#QuantityPerPackage').on("keydown", function (e) {
            AMSValidation.AllowNumbersWithDecimalOnly(e);
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
             url: '/GeneralPackingTypeInfo/List',
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
            url: '/GeneralPackingTypeInfo/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record

    AjaxCallGeneralPackingTypeInfo: function () {
        var GeneralPackingTypeInfoData = null;

        if (GeneralPackingTypeInfo.ActionName == "Create") {
            debugger;
            $("#FormCreateGeneralPackingTypeInfo").validate();
            if ($("#FormCreateGeneralPackingTypeInfo").valid()) {
                GeneralPackingTypeInfoData = null;
                GeneralPackingTypeInfoData = GeneralPackingTypeInfo.GetGeneralPackingTypeInfo();
                ajaxRequest.makeRequest("/GeneralPackingTypeInfo/Create", "POST", GeneralPackingTypeInfoData, GeneralPackingTypeInfo.Success, "CreateGeneralPackingTypeInfoRecord");
            }
        }
        else if (GeneralPackingTypeInfo.ActionName == "Edit") {
            $("#FormEditGeneralPackingTypeInfo").validate();
            if ($("#FormEditGeneralPackingTypeInfo").valid()) {
                GeneralPackingTypeInfoData = null;
                GeneralPackingTypeInfoData = GeneralPackingTypeInfo.GetGeneralPackingTypeInfo();
                ajaxRequest.makeRequest("/GeneralPackingTypeInfo/Edit", "POST", GeneralPackingTypeInfoData, GeneralPackingTypeInfo.Success);
            }
        }
        else if (GeneralPackingTypeInfo.ActionName == "Delete") {

            GeneralPackingTypeInfoData = null;
            //$("#FormCreateGeneralPackingTypeInfo").validate();
            GeneralPackingTypeInfoData = GeneralPackingTypeInfo.GetGeneralPackingTypeInfo();
            ajaxRequest.makeRequest("/GeneralPackingTypeInfo/Delete", "POST", GeneralPackingTypeInfoData, GeneralPackingTypeInfo.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetGeneralPackingTypeInfo: function () {
        var Data = {
        };

        if (GeneralPackingTypeInfo.ActionName == "Create" || GeneralPackingTypeInfo.ActionName == "Edit") {
            debugger
            Data.ID = $('#ID').val();
            Data.Height = $('#Height').val();
            Data.Length = $('#Length').val(); 
            Data.Width = $('#Width').val();
            Data.Weight = $('#Weight').val();
            Data.Volume = $('#Volume').val();
            Data.UomCode = $('#UomCode').val();
            Data.PackageTypeID = $('#PackageType').val();
            Data.QuantityPerPackage = $('#QuantityPerPackage').val();
            Data.ItemCodeID = $('#ItemCodeID').val();
            Data.UomCodeId = $('#UomCodeId').val();

        }
        else if (GeneralPackingTypeInfo.ActionName == "Delete") {

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
            GeneralPackingTypeInfo.ReloadList(splitData[0], splitData[1], splitData[2], splitData[3]);
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
//       GeneralPackingTypeInfo.ReloadList("Record Updated Sucessfully.", actionMode);
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
//        GeneralPackingTypeInfo.ReloadList("Record Deleted Sucessfully.");
//      //  alert("Record Deleted Sucessfully.");

//    } else {
//        parent.$.colorbox.close();
//       // alert("Record Not Deleted Sucessfully. Please Try Again..");
//    }


//},


