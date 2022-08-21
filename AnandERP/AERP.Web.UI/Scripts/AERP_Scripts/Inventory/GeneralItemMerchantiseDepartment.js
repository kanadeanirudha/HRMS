//this class contain methods related to nationality functionality
var GeneralItemMerchantiseDepartment = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        GeneralItemMerchantiseDepartment.constructor();
        //GeneralItemMerchantiseDepartment.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#MerchantiseDepartmentName').focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#GroupDescription').focus();
            return false;
        });



        // Create new record

        $('#CreateGeneralItemMerchantiseDepartmentRecord').on("click", function () {
            GeneralItemMerchantiseDepartment.ActionName = "Create";
            GeneralItemMerchantiseDepartment.AjaxCallGeneralItemMerchantiseDepartment();
        });

        $('#EditGeneralItemMerchantiseDepartmentRecord').on("click", function () {

            GeneralItemMerchantiseDepartment.ActionName = "Edit";
            GeneralItemMerchantiseDepartment.AjaxCallGeneralItemMerchantiseDepartment();
        });

        $('#DeleteGeneralItemMerchantiseDepartmentRecord').on("click", function () {

            GeneralItemMerchantiseDepartment.ActionName = "Delete";
            GeneralItemMerchantiseDepartment.AjaxCallGeneralItemMerchantiseDepartment();
        });

        $('#MerchantiseDepartmentName').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
        });

        $('#MerchantiseDepartmentCode').on("keydown", function (e) {
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
             url: '/GeneralItemMerchantiseDepartment/List',
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
            url: '/GeneralItemMerchantiseDepartment/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record

    AjaxCallGeneralItemMerchantiseDepartment: function () {
        var GeneralItemMerchantiseDepartmentData = null;

        if (GeneralItemMerchantiseDepartment.ActionName == "Create") {
            debugger;
            $("#FormCreateGeneralItemMerchantiseDepartment").validate();
            if ($("#FormCreateGeneralItemMerchantiseDepartment").valid()) {
                GeneralItemMerchantiseDepartmentData = null;
                GeneralItemMerchantiseDepartmentData = GeneralItemMerchantiseDepartment.GetGeneralItemMerchantiseDepartment();
                ajaxRequest.makeRequest("/GeneralItemMerchantiseDepartment/Create", "POST", GeneralItemMerchantiseDepartmentData, GeneralItemMerchantiseDepartment.Success, "CreateGeneralItemMerchantiseDepartmentRecord");
            }
        }
        else if (GeneralItemMerchantiseDepartment.ActionName == "Edit") {
            $("#FormEditGeneralItemMerchantiseDepartment").validate();
            if ($("#FormEditGeneralItemMerchantiseDepartment").valid()) {
                GeneralItemMerchantiseDepartmentData = null;
                GeneralItemMerchantiseDepartmentData = GeneralItemMerchantiseDepartment.GetGeneralItemMerchantiseDepartment();
                ajaxRequest.makeRequest("/GeneralItemMerchantiseDepartment/Edit", "POST", GeneralItemMerchantiseDepartmentData, GeneralItemMerchantiseDepartment.Success);
            }
        }
        else if (GeneralItemMerchantiseDepartment.ActionName == "Delete") {

            GeneralItemMerchantiseDepartmentData = null;
            //$("#FormCreateGeneralItemMerchantiseDepartment").validate();
            GeneralItemMerchantiseDepartmentData = GeneralItemMerchantiseDepartment.GetGeneralItemMerchantiseDepartment();
            ajaxRequest.makeRequest("/GeneralItemMerchantiseDepartment/Delete", "POST", GeneralItemMerchantiseDepartmentData, GeneralItemMerchantiseDepartment.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetGeneralItemMerchantiseDepartment: function () {
        var Data = {
        };

        if (GeneralItemMerchantiseDepartment.ActionName == "Create" || GeneralItemMerchantiseDepartment.ActionName == "Edit") {
            debugger
            Data.ID = $('#ID').val();
            Data.MerchantiseDepartmentName = $('#MerchantiseDepartmentName').val();
            Data.MerchantiseDepartmentCode = $('#MerchantiseDepartmentCode').val();
          
        }
        else if (GeneralItemMerchantiseDepartment.ActionName == "Delete") {

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
            GeneralItemMerchantiseDepartment.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};