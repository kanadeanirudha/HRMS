//this class contain methods related to nationality functionality
var GeneralItemMerchantiseCategory = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        GeneralItemMerchantiseCategory.constructor();
        //GeneralItemMerchantiseCategory.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

    
        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#MerchantiseCategoryName').focus();
            return false;
        });



        // Create new record

        $('#CreateGeneralItemMerchantiseCategoryRecord').on("click", function () {
            GeneralItemMerchantiseCategory.ActionName = "Create";
            GeneralItemMerchantiseCategory.AjaxCallGeneralItemMerchantiseCategory();
        });

        $('#EditGeneralItemMerchantiseCategoryRecord').on("click", function () {

            GeneralItemMerchantiseCategory.ActionName = "Edit";
            GeneralItemMerchantiseCategory.AjaxCallGeneralItemMerchantiseCategory();
        });

        $('#DeleteGeneralItemMerchantiseCategoryRecord').on("click", function () {

            GeneralItemMerchantiseCategory.ActionName = "Delete";
            GeneralItemMerchantiseCategory.AjaxCallGeneralItemMerchantiseCategory();
        });

        $('#MerchantiseCategoryName').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
        });

        $('#MerchantiseCategoryCode').on("keydown", function (e) {
            AERPValidation.NotAllowSpaces(e);

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
             url: '/GeneralItemMerchantiseCategory/List',
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
            url: '/GeneralItemMerchantiseCategory/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record

    AjaxCallGeneralItemMerchantiseCategory: function () {
        var GeneralItemMerchantiseCategoryData = null;

        if (GeneralItemMerchantiseCategory.ActionName == "Create") {
            debugger;
            $("#FormCreateGeneralItemMerchantiseCategory").validate();
            if ($("#FormCreateGeneralItemMerchantiseCategory").valid()) {
                GeneralItemMerchantiseCategoryData = null;
                GeneralItemMerchantiseCategoryData = GeneralItemMerchantiseCategory.GetGeneralItemMerchantiseCategory();
                ajaxRequest.makeRequest("/GeneralItemMerchantiseCategory/Create", "POST", GeneralItemMerchantiseCategoryData, GeneralItemMerchantiseCategory.Success, "CreateGeneralItemMerchantiseCategoryRecord");
            }
        }
        else if (GeneralItemMerchantiseCategory.ActionName == "Edit") {
            $("#FormEditGeneralItemMerchantiseCategory").validate();
            if ($("#FormEditGeneralItemMerchantiseCategory").valid()) {
                GeneralItemMerchantiseCategoryData = null;
                GeneralItemMerchantiseCategoryData = GeneralItemMerchantiseCategory.GetGeneralItemMerchantiseCategory();
                ajaxRequest.makeRequest("/GeneralItemMerchantiseCategory/Edit", "POST", GeneralItemMerchantiseCategoryData, GeneralItemMerchantiseCategory.Success);
            }
        }
        else if (GeneralItemMerchantiseCategory.ActionName == "Delete") {

            GeneralItemMerchantiseCategoryData = null;
            //$("#FormCreateGeneralItemMerchantiseCategory").validate();
            GeneralItemMerchantiseCategoryData = GeneralItemMerchantiseCategory.GetGeneralItemMerchantiseCategory();
            ajaxRequest.makeRequest("/GeneralItemMerchantiseCategory/Delete", "POST", GeneralItemMerchantiseCategoryData, GeneralItemMerchantiseCategory.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetGeneralItemMerchantiseCategory: function () {
        var Data = {
        };

        if (GeneralItemMerchantiseCategory.ActionName == "Create" || GeneralItemMerchantiseCategory.ActionName == "Edit") {
            debugger
            Data.ID = $('#ID').val();
            Data.MerchantiseCategoryName = $('#MerchantiseCategoryName').val();
            Data.MerchantiseCategoryCode = $('#MerchantiseCategoryCode').val();
          

        }
        else if (GeneralItemMerchantiseCategory.ActionName == "Delete") {

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
            GeneralItemMerchantiseCategory.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};