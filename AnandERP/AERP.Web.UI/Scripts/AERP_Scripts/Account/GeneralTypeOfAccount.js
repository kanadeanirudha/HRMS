//this class contain methods related to nationality functionality
var GeneralTypeOfAccount = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        GeneralTypeOfAccount.constructor();
        //GeneralTypeOfAccount.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#Name').focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#Name').focus();
            return false;
        });



        // Create new record

        $('#CreateGeneralTypeOfAccountRecord').on("click", function () {
            debugger;
            GeneralTypeOfAccount.ActionName = "Create";
            GeneralTypeOfAccount.AjaxCallGeneralTypeOfAccount();
        });

        $('#EditGeneralTypeOfAccountRecord').on("click", function () {
            debugger;
            GeneralTypeOfAccount.ActionName = "Edit";
            GeneralTypeOfAccount.AjaxCallGeneralTypeOfAccount();
        });

        $('#DeleteGeneralTypeOfAccountRecord').on("click", function () {

            GeneralTypeOfAccount.ActionName = "Delete";
            GeneralTypeOfAccount.AjaxCallGeneralTypeOfAccount();
        });

        $('#Name').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
        });

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
             url: '/GeneralTypeOfAccount/List',
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
            url: '/GeneralTypeOfAccount/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record

    AjaxCallGeneralTypeOfAccount: function () {
        var GeneralTypeOfAccountData = null;

        if (GeneralTypeOfAccount.ActionName == "Create") {

            $("#FormCreateGeneralTypeOfAccount").validate();
            if ($("#FormCreateGeneralTypeOfAccount").valid()) {
                GeneralTypeOfAccountData = null;
                GeneralTypeOfAccountData = GeneralTypeOfAccount.GetGeneralTypeOfAccount();
                ajaxRequest.makeRequest("/GeneralTypeOfAccount/Create", "POST", GeneralTypeOfAccountData, GeneralTypeOfAccount.Success, "CreateGeneralTypeOfAccountRecord");
            }
        }
        else if (GeneralTypeOfAccount.ActionName == "Edit") {
            debugger;
            $("#FormEditGeneralTypeOfAccount").validate();
            if ($("#FormEditGeneralTypeOfAccount").valid()) {
                GeneralTypeOfAccountData = null;
                GeneralTypeOfAccountData = GeneralTypeOfAccount.GetGeneralTypeOfAccount();
                ajaxRequest.makeRequest("/GeneralTypeOfAccount/Edit", "POST", GeneralTypeOfAccountData, GeneralTypeOfAccount.Success, "EditGeneralTypeOfAccountRecord");
         
            }
        }
        else if (GeneralTypeOfAccount.ActionName == "Delete") {

            GeneralTypeOfAccountData = null;
            //$("#FormCreateGeneralTypeOfAccount").validate();
            GeneralTypeOfAccountData = GeneralTypeOfAccount.GetGeneralTypeOfAccount();
            ajaxRequest.makeRequest("/GeneralTypeOfAccount/Delete", "POST", GeneralTypeOfAccountData, GeneralTypeOfAccount.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetGeneralTypeOfAccount: function () {
    
        var Data = {
        };

        if (GeneralTypeOfAccount.ActionName == "Create" || GeneralTypeOfAccount.ActionName == "Edit") {
            debugger;
            Data.ID = $('#ID').val();
            Data.Name = $('#Name').val();
            Data.IsActive = $('input[id=IsActive]:checked').val() ? true : false;
            //General Type Of Account Map With Account
            Data.GeneralTypeOfAccountMapWithAccountID = $('#GeneralTypeOfAccountMapWithAccountID').val();
            Data.GeneralTypeOfAccountId = $('input[name=GeneralTypeOfAccountId]').val();
            Data.AccountMasterId = $('#AccountMasterId').val();
            Data.AccountName = $('#AccountName').val();
            Data.DisplayFor = $('#DisplayFor').val();
           
        }
        else if (GeneralTypeOfAccount.ActionName == "Delete") {

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
            GeneralTypeOfAccount.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            //$("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
            $.magnificPopup.close()
            GeneralTypeOfAccount.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },

};

