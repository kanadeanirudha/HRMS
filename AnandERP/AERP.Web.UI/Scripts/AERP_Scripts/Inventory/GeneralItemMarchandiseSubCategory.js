//this class contain methods related to nationality functionality
var GeneralItemMarchandiseSubCategory = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        GeneralItemMarchandiseSubCategory.constructor();
        //GeneralItemMarchandiseSubCategory.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#MarchantiseSubCategoryName').focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#MarchantiseSubCategoryName').focus();
            return false;
        });



        // Create new record

        $('#CreateGeneralItemMarchandiseSubCategoryRecord').on("click", function () {
            debugger;
            GeneralItemMarchandiseSubCategory.ActionName = "Create";
            GeneralItemMarchandiseSubCategory.AjaxCallGeneralItemMarchandiseSubCategory();
        });

        $('#EditGeneralItemMarchandiseSubCategoryRecord').on("click", function () {

            GeneralItemMarchandiseSubCategory.ActionName = "Edit";
            GeneralItemMarchandiseSubCategory.AjaxCallGeneralItemMarchandiseSubCategory();
        });

        $('#DeleteGeneralItemMarchandiseSubCategoryRecord').on("click", function () {

            GeneralItemMarchandiseSubCategory.ActionName = "Delete";
            GeneralItemMarchandiseSubCategory.AjaxCallGeneralItemMarchandiseSubCategory();
        });

        $('#MarchantiseSubCategoryName').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
        });

        $('#MarchantiseSubCategoryCode').on("keydown", function (e) {
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
             url: '/GeneralItemMarchandiseSubCategory/List',
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
            url: '/GeneralItemMarchandiseSubCategory/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record

    AjaxCallGeneralItemMarchandiseSubCategory: function () {
        var GeneralItemMarchandiseSubCategoryData = null;

        if (GeneralItemMarchandiseSubCategory.ActionName == "Create") {
            debugger;
            $("#FormCreateGeneralItemMarchandiseSubCategory").validate();
            if ($("#FormCreateGeneralItemMarchandiseSubCategory").valid()) {
                GeneralItemMarchandiseSubCategoryData = null;
                GeneralItemMarchandiseSubCategoryData = GeneralItemMarchandiseSubCategory.GetGeneralItemMarchandiseSubCategory();
                ajaxRequest.makeRequest("/GeneralItemMarchandiseSubCategory/Create", "POST", GeneralItemMarchandiseSubCategoryData, GeneralItemMarchandiseSubCategory.Success, "CreateGeneralItemMarchandiseSubCategoryRecord");
            }
        }
        else if (GeneralItemMarchandiseSubCategory.ActionName == "Edit") {
            $("#FormEditGeneralItemMarchandiseSubCategory").validate();
            if ($("#FormEditGeneralItemMarchandiseSubCategory").valid()) {
                GeneralItemMarchandiseSubCategoryData = null;
                GeneralItemMarchandiseSubCategoryData = GeneralItemMarchandiseSubCategory.GetGeneralItemMarchandiseSubCategory();
                ajaxRequest.makeRequest("/GeneralItemMarchandiseSubCategory/Edit", "POST", GeneralItemMarchandiseSubCategoryData, GeneralItemMarchandiseSubCategory.Success);
            }
        }
        else if (GeneralItemMarchandiseSubCategory.ActionName == "Delete") {

            GeneralItemMarchandiseSubCategoryData = null;
            //$("#FormCreateGeneralItemMarchandiseSubCategory").validate();
            GeneralItemMarchandiseSubCategoryData = GeneralItemMarchandiseSubCategory.GetGeneralItemMarchandiseSubCategory();
            ajaxRequest.makeRequest("/GeneralItemMarchandiseSubCategory/Delete", "POST", GeneralItemMarchandiseSubCategoryData, GeneralItemMarchandiseSubCategory.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetGeneralItemMarchandiseSubCategory: function () {
        var Data = {
        };

        if (GeneralItemMarchandiseSubCategory.ActionName == "Create" || GeneralItemMarchandiseSubCategory.ActionName == "Edit") {
            debugger
            Data.ID = $('#ID').val();
            Data.MarchantiseSubCategoryName = $('#MarchantiseSubCategoryName').val();
            Data.MarchantiseSubCategoryCode = $('#MarchantiseSubCategoryCode').val();
           

        }
        else if (GeneralItemMarchandiseSubCategory.ActionName == "Delete") {

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
            GeneralItemMarchandiseSubCategory.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};