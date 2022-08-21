//this class contain methods related to nationality functionality
var GeneralItemMarchandiseBaseCategory = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        GeneralItemMarchandiseBaseCategory.constructor();
        //GeneralItemMarchandiseBaseCategory.initializeValidation();
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

        $('#CreateGeneralItemMarchandiseBaseCategoryRecord').on("click", function () {
            debugger;
            GeneralItemMarchandiseBaseCategory.ActionName = "Create";
            GeneralItemMarchandiseBaseCategory.AjaxCallGeneralItemMarchandiseBaseCategory();
        });

        $('#EditGeneralItemMarchandiseBaseCategoryRecord').on("click", function () {

            GeneralItemMarchandiseBaseCategory.ActionName = "Edit";
            GeneralItemMarchandiseBaseCategory.AjaxCallGeneralItemMarchandiseBaseCategory();
        });

        $('#DeleteGeneralItemMarchandiseBaseCategoryRecord').on("click", function () {

            GeneralItemMarchandiseBaseCategory.ActionName = "Delete";
            GeneralItemMarchandiseBaseCategory.AjaxCallGeneralItemMarchandiseBaseCategory();
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
             url: '/GeneralItemMarchandiseBaseCategory/List',
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
            url: '/GeneralItemMarchandiseBaseCategory/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record

    AjaxCallGeneralItemMarchandiseBaseCategory: function () {
        var GeneralItemMarchandiseBaseCategoryData = null;

        if (GeneralItemMarchandiseBaseCategory.ActionName == "Create") {
            
            $("#FormCreateGeneralItemMarchandiseBaseCategory").validate();
            if ($("#FormCreateGeneralItemMarchandiseBaseCategory").valid()) {
                GeneralItemMarchandiseBaseCategoryData = null;
                GeneralItemMarchandiseBaseCategoryData = GeneralItemMarchandiseBaseCategory.GetGeneralItemMarchandiseBaseCategory();
                ajaxRequest.makeRequest("/GeneralItemMarchandiseBaseCategory/Create", "POST", GeneralItemMarchandiseBaseCategoryData, GeneralItemMarchandiseBaseCategory.Success, "CreateGeneralItemMarchandiseBaseCategoryRecord");
            }
        }
        else if (GeneralItemMarchandiseBaseCategory.ActionName == "Edit") {
            $("#FormEditGeneralItemMarchandiseBaseCategory").validate();
            if ($("#FormEditGeneralItemMarchandiseBaseCategory").valid()) {
                GeneralItemMarchandiseBaseCategoryData = null;
                GeneralItemMarchandiseBaseCategoryData = GeneralItemMarchandiseBaseCategory.GetGeneralItemMarchandiseBaseCategory();
                ajaxRequest.makeRequest("/GeneralItemMarchandiseBaseCategory/Edit", "POST", GeneralItemMarchandiseBaseCategoryData, GeneralItemMarchandiseBaseCategory.Success);
            }
        }
        else if (GeneralItemMarchandiseBaseCategory.ActionName == "Delete") {

            GeneralItemMarchandiseBaseCategoryData = null;
            //$("#FormCreateGeneralItemMarchandiseBaseCategory").validate();
            GeneralItemMarchandiseBaseCategoryData = GeneralItemMarchandiseBaseCategory.GetGeneralItemMarchandiseBaseCategory();
            ajaxRequest.makeRequest("/GeneralItemMarchandiseBaseCategory/Delete", "POST", GeneralItemMarchandiseBaseCategoryData, GeneralItemMarchandiseBaseCategory.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetGeneralItemMarchandiseBaseCategory: function () {
        var Data = {
        };

        if (GeneralItemMarchandiseBaseCategory.ActionName == "Create" || GeneralItemMarchandiseBaseCategory.ActionName == "Edit") {
            
            Data.ID = $('#ID').val();
            Data.MarchandiseBaseCategoryName = $('#MarchandiseBaseCategoryName').val();
            Data.MarchandiseBaseCategoryCode = $('#MarchandiseBaseCategoryCode').val();
            

        }
        else if (GeneralItemMarchandiseBaseCategory.ActionName == "Delete") {

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
            GeneralItemMarchandiseBaseCategory.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};
