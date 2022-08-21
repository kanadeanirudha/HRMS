//this class contain methods related to nationality functionality
var AddCentreOpeningBalanceForInventory = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        AddCentreOpeningBalanceForInventory.constructor();
        //AddCentreOpeningBalanceForInventory.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#MarchandiseBaseCategoryName').focus();
            return false;
        });

        $("#btnShowListforList").unbind('click').click(function () {
            debugger;
            var SelectedGeneralLocationList = $('#GeneralLocationList :selected').val();
            if (SelectedGeneralLocationList == '') {
                notify('Please select Location', 'warning');
                return false;
            }
            AddCentreOpeningBalanceForInventory.LoadList();
        });

        // Create new record

        $('#CreateAddCentreOpeningBalanceForInventoryRecord').on("click", function () {
            debugger;
            AddCentreOpeningBalanceForInventory.ActionName = "Create";
            AddCentreOpeningBalanceForInventory.GetXmlData();
          
            AddCentreOpeningBalanceForInventory.AjaxCallAddCentreOpeningBalanceForInventory();
        });

        $('#EditAddCentreOpeningBalanceForInventoryRecords').on("click", function () {
            debugger;
            AddCentreOpeningBalanceForInventory.ActionName = "Edit";
            AddCentreOpeningBalanceForInventory.AjaxCallAddCentreOpeningBalanceForInventory();
        });

        $('#DeleteAddCentreOpeningBalanceForInventoryRecord').on("click", function () {

            AddCentreOpeningBalanceForInventory.ActionName = "Delete";
            AddCentreOpeningBalanceForInventory.AjaxCallAddCentreOpeningBalanceForInventory();
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
             url: '/AddCentreOpeningBalanceForInventory/List',
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
            url: '/AddCentreOpeningBalanceForInventory/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },

    GetXmlData: function () {
        var DataArray = [];
        var TotalRecord = 0;
        var table = $('#myDataTable').DataTable();
        var data = table.$('input').each(function () {
            DataArray.push($(this).val());
        });
        TotalRecord = DataArray.length;
        
        var ParameterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 4) {
            if (DataArray[i + 0] != 0 && DataArray[i + 3] == "False") {
                ParameterXml = ParameterXml + "<row><ID>" + 0 + "</ID><StockMasterID>" + DataArray[i + 2] + "</StockMasterID><ItemNumber>" + DataArray[i + 1] + "</ItemNumber><OpeningBalanceQty>" + DataArray[i + 0] + "</OpeningBalanceQty></row>";

            }
            
            if (ParameterXml.length > 10)
                AddCentreOpeningBalanceForInventory.ParameterXml = ParameterXml + "</rows>";

            else
                AddCentreOpeningBalanceForInventory.ParameterXml = "";
            //alert(BOMAndRecipeDetails.ParameterXml)
        }
    },

    //Fire ajax call to insert update and delete record

    AjaxCallAddCentreOpeningBalanceForInventory: function () {
        var AddCentreOpeningBalanceForInventoryData = null;

        if (AddCentreOpeningBalanceForInventory.ActionName == "Create") {
                AddCentreOpeningBalanceForInventoryData = null;
                AddCentreOpeningBalanceForInventoryData = AddCentreOpeningBalanceForInventory.GetAddCentreOpeningBalanceForInventory();
                ajaxRequest.makeRequest("/AddCentreOpeningBalanceForInventory/Create", "POST", AddCentreOpeningBalanceForInventoryData, AddCentreOpeningBalanceForInventory.Success, "CreateAddCentreOpeningBalanceForInventoryRecord");
            
        }
        else if (AddCentreOpeningBalanceForInventory.ActionName == "Edit") {
            $("#FormEditAddCentreOpeningBalanceForInventory").validate();
            if ($("#FormEditAddCentreOpeningBalanceForInventory").valid()) {
                AddCentreOpeningBalanceForInventoryData = null;
                AddCentreOpeningBalanceForInventoryData = AddCentreOpeningBalanceForInventory.GetAddCentreOpeningBalanceForInventory();
                ajaxRequest.makeRequest("/AddCentreOpeningBalanceForInventory/Edit", "POST", AddCentreOpeningBalanceForInventoryData, AddCentreOpeningBalanceForInventory.Success);
            }
        }
        else if (AddCentreOpeningBalanceForInventory.ActionName == "Delete") {

            AddCentreOpeningBalanceForInventoryData = null;
            //$("#FormCreateAddCentreOpeningBalanceForInventory").validate();
            AddCentreOpeningBalanceForInventoryData = AddCentreOpeningBalanceForInventory.GetAddCentreOpeningBalanceForInventory();
            ajaxRequest.makeRequest("/AddCentreOpeningBalanceForInventory/Delete", "POST", AddCentreOpeningBalanceForInventoryData, AddCentreOpeningBalanceForInventory.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetAddCentreOpeningBalanceForInventory: function () {
        var Data = {
        };

        if (AddCentreOpeningBalanceForInventory.ActionName == "Create" || AddCentreOpeningBalanceForInventory.ActionName == "Edit") {

            Data.ID = $('#ID').val();
            Data.XMLstring = AddCentreOpeningBalanceForInventory.ParameterXml;
            Data.InventoryLocationMasterID = $('#GeneralLocationList').val();
        }
        else if (AddCentreOpeningBalanceForInventory.ActionName == "Delete") {

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
            AddCentreOpeningBalanceForInventory.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};
