//this class contain methods related to nationality functionality
var BankMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        BankMaster.constructor();
        //BankMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#CountryName').focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#CountryName').focus();
            return false;
        });

        // Create new record
        $('#CreateBankMasterRecord').on("click", function () {
            BankMaster.ActionName = "Create";
            BankMaster.AjaxCallBankMaster();
        });

        $('#EditBankMasterRecord').on("click", function () {

            BankMaster.ActionName = "Edit";
            BankMaster.AjaxCallBankMaster();
        });

        $('#DeleteBankMasterRecord').on("click", function () {

            BankMaster.ActionName = "Delete";
            BankMaster.AjaxCallBankMaster();
        });
        $('#CountryName').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
        });
        $('#ContryCode').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
            if (e.keyCode == 32) {
                return false;
            }
        });
        $("#UserSearch").keyup(function () {
            var oTable = $("#myDataTable").dataTable();
            oTable.fnFilter(this.value);
        });

        $("#searchBtn").click(function () {
            $("#UserSearch").focus();
        });


        $("#showrecord").change(function () {
            var showRecord = $("#showrecord").val();
            $("select[name*='myDataTable_length']").val(showRecord);
            $("select[name*='myDataTable_length']").change();
        });

        //$(".ajax").colorbox();
        InitAnimatedBorder();
        CloseAlert();



    },
    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax(

         {

             cache: false,
             type: "POST",

             dataType: "html",
             url: '/BankMaster/List',
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
            data: { "actionMode": actionMode },
            url: '/BankMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
                notify(message,colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallBankMaster: function () {
        var BankMasterData = null;
        if (BankMaster.ActionName == "Create") {
            $("#FormCreateBankMaster").validate();
            if ($("#FormCreateBankMaster").valid()) {
                BankMasterData = null;
                BankMasterData = BankMaster.GetBankMaster();
                ajaxRequest.makeRequest("/BankMaster/Create", "POST", BankMasterData, BankMaster.Success);
            }
        }
        else if (BankMaster.ActionName == "Edit") {
            $("#FormEditBankMaster").validate();
            if ($("#FormEditBankMaster").valid()) {
                BankMasterData = null;
                BankMasterData = BankMaster.GetBankMaster();
                ajaxRequest.makeRequest("/BankMaster/Edit", "POST", BankMasterData, BankMaster.Success);
            }
        }
        else if (BankMaster.ActionName == "Delete") {
            BankMasterData = null;
            //$("#FormCreateBankMaster").validate();
            BankMasterData = BankMaster.GetBankMaster();
            ajaxRequest.makeRequest("/BankMaster/Delete", "POST", BankMasterData, BankMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetBankMaster: function () {
        var Data = {
        };
        if (BankMaster.ActionName == "Create" || BankMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.BankName = $('#BankName').val();
            Data.BankIFSCCode = $('#BankIFSCCode').val();
            Data.AccountNumber = $('#AccountNumber').val();
        }
        else if (BankMaster.ActionName == "Delete") {
            Data.ID = $('#ID').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {

        var splitData = data.split(',');
        if (data != null) {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            BankMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            BankMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },

};

