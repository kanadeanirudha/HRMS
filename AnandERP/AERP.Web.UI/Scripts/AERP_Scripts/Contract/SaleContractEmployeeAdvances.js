//this class contain methods related to nationality functionality
var SaleContractEmployeeAdvances = {
    //Member variables
    ActionName: null,
    map: {},
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        SaleContractEmployeeAdvances.constructor();
        //SaleContractEmployeeAdvances.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        // Create new record
        $('#CreateSaleContractEmployeeAdvancesRecord').on("click", function () {
            SaleContractEmployeeAdvances.ActionName = "Create";
            SaleContractEmployeeAdvances.AjaxCallSaleContractEmployeeAdvances();
        });

        $("#btnShowList").unbind("click").click(function () {
            if ($("#ContractEmployeeMasterID").val() == "" || $("#ContractEmployeeMasterID").val() == "0") {
                notify('Please select Employee', 'warning');
                return false;
            }
            SaleContractEmployeeAdvances.LoadList();
        });

        InitAnimatedBorder();
        CloseAlert();
    },
    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax({
             cache: false,
             type: "POST",
             dataType: "html",
             url: '/SaleContractEmployeeAdvances/List',
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
            url: '/SaleContractEmployeeAdvances/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                notify(message,colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallSaleContractEmployeeAdvances: function () {
        var SaleContractEmployeeAdvancesData = null;
        if (SaleContractEmployeeAdvances.ActionName == "Create") {
            $("#FormCreateSaleContractEmployeeAdvances").validate();
            if ($("#FormCreateSaleContractEmployeeAdvances").valid()) {
                SaleContractEmployeeAdvancesData = null;
                SaleContractEmployeeAdvancesData = SaleContractEmployeeAdvances.GetSaleContractEmployeeAdvances();
                ajaxRequest.makeRequest("/SaleContractEmployeeAdvances/Create", "POST", SaleContractEmployeeAdvancesData, SaleContractEmployeeAdvances.Success);
            }
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetSaleContractEmployeeAdvances: function () {
        var Data = {
        };
        if (SaleContractEmployeeAdvances.ActionName == "Create") {
            Data.ContractEmployeeMasterID = $('#ContractEmployeeMasterID').val();
            Data.ContractEmployeeMasterName = $('#ContractEmployeeMasterName').val();
            Data.TransactionDate = $('#TransactionDate').val();
            Data.AdvanceAmount = $('#AdvanceAmount').val();
            Data.PaymentMode = $('#PaymentMode').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {

        var splitData = data.split(',');
        if (data != null) {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            SaleContractEmployeeAdvances.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            SaleContractEmployeeAdvances.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
};

