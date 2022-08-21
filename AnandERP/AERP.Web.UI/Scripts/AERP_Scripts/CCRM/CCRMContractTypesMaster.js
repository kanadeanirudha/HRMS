//this class contain methods related to nationality functionality
var CCRMContractTypesMaster = {
    //Member variables
    ActionName: null,
    SelectedCategoryMasterIDs: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        CCRMContractTypesMaster.constructor();
        //CCRMContractTypesMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {



        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');

            return false;
        });



        // Create new record

        $('#CreateCCRMContractTypesMasterRecord').on("click", function () {
            debugger;
            CCRMContractTypesMaster.ActionName = "Create";
            CCRMContractTypesMaster.getValueUsingParentTag_Check_UnCheck();
           // if (CCRMContractTypesMaster.SelectedCategoryMasterIDs != "" && CCRMContractTypesMaster.SelectedCategoryMasterIDs != null) {
                CCRMContractTypesMaster.AjaxCallCCRMContractTypesMaster();
           // }
            
        });

        $('#EditCCRMContractTypesMasterRecord').on("click", function () {
            debugger;
            CCRMContractTypesMaster.ActionName = "Edit";
            CCRMContractTypesMaster.getValueUsingParentTag_Check_UnCheck();
            CCRMContractTypesMaster.AjaxCallCCRMContractTypesMaster();
        });

        $('#DeleteCCRMContractTypesMasterRecord').on("click", function () {

            CCRMContractTypesMaster.ActionName = "Delete";
            CCRMContractTypesMaster.AjaxCallCCRMContractTypesMaster();
        });






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
             url: '/CCRMContractTypesMaster/List',
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
            url: '/CCRMContractTypesMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record

    AjaxCallCCRMContractTypesMaster: function () {
        var CCRMContractTypesMasterData = null;

        if (CCRMContractTypesMaster.ActionName == "Create") {

            $("#FormCreateCCRMContractTypesMaster").validate();
            if ($("#FormCreateCCRMContractTypesMaster").valid()) {
                CCRMContractTypesMasterData = null;
                CCRMContractTypesMasterData = CCRMContractTypesMaster.GetCCRMContractTypesMaster();
                ajaxRequest.makeRequest("/CCRMContractTypesMaster/Create", "POST", CCRMContractTypesMasterData, CCRMContractTypesMaster.Success, "CreateCCRMContractTypesMasterRecord");
            }
        }
        

        else if (CCRMContractTypesMaster.ActionName == "Edit") {
            $("#FormEditCCRMContractTypesMaster").validate();
            if ($("#FormEditCCRMContractTypesMaster").valid()) {
                CCRMContractTypesMasterData = null;
                CCRMContractTypesMasterData = CCRMContractTypesMaster.GetCCRMContractTypesMaster();
                ajaxRequest.makeRequest("/CCRMContractTypesMaster/Edit", "POST", CCRMContractTypesMasterData, CCRMContractTypesMaster.Success);
            }
        }
        else if (CCRMContractTypesMaster.ActionName == "Delete") {

            CCRMContractTypesMasterData = null;
            //$("#FormCreateCCRMContractTypesMaster").validate();
            CCRMContractTypesMasterData = CCRMContractTypesMaster.GetCCRMContractTypesMaster();
            ajaxRequest.makeRequest("/CCRMContractTypesMaster/Delete", "POST", CCRMContractTypesMasterData, CCRMContractTypesMaster.Success);

        }
    },

    getValueUsingParentTag_Check_UnCheck: function () {
        debugger;
        var sList = "";
        //var taxMasterID = 0;
        var xmlParamList = "<rows>"
        //alert();
        //$('#checkboxlist input[type=checkbox]').each(function () {
        $('#checkboxlist option').each(function () {

            if ($(this).val() != "on") {
               // ItemCategoryCode = $(this).val();
                ItemCategoryCode = $(this).val().split("~");
                if (this.selected == true) {

                    //xmlInsert code here
                    xmlParamList = xmlParamList + "<row>" + "<ID>" + ItemCategoryCode[1] + "</ID>" + "<ItemCategoryCodeID>" + ItemCategoryCode[0] + "</ItemCategoryCodeID></row>";
                }
               

            }

        });
        if (xmlParamList.length > 6)
            CCRMContractTypesMaster.SelectedCategoryMasterIDs = xmlParamList + "</rows>";
        else
            CCRMContractTypesMaster.SelectedCategoryMasterIDs = "";
        // alert(GeneralTaxGroupMaster.SelectedTaxMaterIDs);
    },

    //Get properties data from the Create, Update and Delete page
    GetCCRMContractTypesMaster: function () {
        var Data = {
        };

        if (CCRMContractTypesMaster.ActionName == "Create"  || CCRMContractTypesMaster.ActionName == "Edit") {

            Data.ID = $('#ID').val();
            Data.ContractCode = $('#ContractCode').val();
            Data.ContractName = $('#ContractName').val();
            Data.ContractType = $('#ContractType').val();
            Data.IsSpares = $('#IsSpares').is(":checked") ? "true" : "false";
            Data.IsConsumables = $('#IsConsumables').is(":checked") ? "true" : "false";
            Data.ISService = $('#ISService').is(":checked") ? "true" : "false";
            Data.IsRentMachine = $('#IsRentMachine').is(":checked") ? "true" : "false";
            Data.ItemCategoryMasterID = $('#ItemCategoryMasterID').val();
            Data.ItemCategoryCode = $('#ItemCategoryCode').val();
            Data.SelectedCategoryMasterIDs = CCRMContractTypesMaster.SelectedCategoryMasterIDs;
        }
        else if (CCRMContractTypesMaster.ActionName == "Delete") {

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
            CCRMContractTypesMaster.ReloadList(splitData[0], splitData[1], splitData[2], splitData[3]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};