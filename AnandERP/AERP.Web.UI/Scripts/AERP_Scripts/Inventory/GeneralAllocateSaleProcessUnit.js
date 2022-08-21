//this class contain methods related to nationality functionality
var GeneralAllocateSaleProcessUnit = {
    //Member variables
    ActionName: null,

    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        GeneralAllocateSaleProcessUnit.constructor();
        //generalCountryMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            return false;
        });



        // Create new record
        $('#CreateGeneralAllocateSaleProcessUnitRecord').on("click", function () {
            debugger;
            debugger;
            GeneralAllocateSaleProcessUnit.ActionName = "Create";
            GeneralAllocateSaleProcessUnit.AjaxCallGeneralAllocateSaleProcessUnit();
        });


        $('#EditGeneralAllocateSaleProcessUnitRecord').on("click", function () {
            GeneralAllocateSaleProcessUnit.ActionName = "Edit";

            GeneralAllocateSaleProcessUnit.AjaxCallGeneralAllocateSaleProcessUnit();
        });

        $('#DeleteGeneralAllocateSaleProcessUnitRecord').on("click", function () {

            GeneralAllocateSaleProcessUnit.ActionName = "Delete";
            GeneralAllocateSaleProcessUnit.AjaxCallGeneralAllocateSaleProcessUnit();
        });
        $("#SelectedCentreCode").change(function () {
            var valuCentreCode = $('#SelectedCentreCode :selected').val();
            if (valuCentreCode == "" || valuCentreCode == null)
            {
                $('#myDataTable').html("");
            }

        });
        $('#btnShowList').unbind('click').click(function () {
            debugger;
            var valuCentreCode = $('#SelectedCentreCode :selected').val();
            // var valuDepartmentID = $('#SelectedDepartmentID :selected').val();

            if (valuCentreCode == "") {

                notify("Please select Centre", 'warning');
            }
                //else if (valuDepartmentID == "") {
                //    notify("Please select Department", 'warning');
                //}
            else {
                GeneralAllocateSaleProcessUnit.LoadList(valuCentreCode);
                //GeneralUnits.LoadList(valuCentreCode, valuDepartmentID);
            }

        });
        $('#UnitName').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
        });

        InitAnimatedBorder();

        CloseAlert();

    },



    //LoadList method is used to load List page
    LoadList: function (SelectedCentreCode) {
        $.ajax(
         {
             cache: false,
             type: "POST",
             data: { centerCode: SelectedCentreCode},
             dataType: "html",
             url: '/GeneralAllocateSaleProcessUnit/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        var SelectedCentreCode = $('#SelectedCentreCode :selected').val();
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { "centerCode": SelectedCentreCode,"actionMode": actionMode },
            url: '/GeneralAllocateSaleProcessUnit/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallGeneralAllocateSaleProcessUnit: function () {
        var GeneralAllocateSaleProcessUnitData = null;
        if (GeneralAllocateSaleProcessUnit.ActionName == "Create") {
            $("#FormCreateGeneralAllocateSaleProcessUnit").validate();
            if ($("#FormCreateGeneralAllocateSaleProcessUnit").valid()) {
                debugger;
                GeneralAllocateSaleProcessUnitData = null;
                GeneralAllocateSaleProcessUnitData = GeneralAllocateSaleProcessUnit.GetGeneralAllocateSaleProcessUnit();

                ajaxRequest.makeRequest("/GeneralAllocateSaleProcessUnit/Create", "POST", GeneralAllocateSaleProcessUnitData, GeneralAllocateSaleProcessUnit.Success, "CreateGeneralAllocateSaleProcessUnitRecord");
            }


        }
        else if (GeneralAllocateSaleProcessUnit.ActionName == "Edit") {
            $("#FormEditGeneralAllocateSaleProcessUnit").validate();
            if ($("#FormEditGeneralAllocateSaleProcessUnit").valid()) {
                GeneralAllocateSaleProcessUnitData = null;

                GeneralAllocateSaleProcessUnitData = GeneralAllocateSaleProcessUnit.GetGeneralAllocateSaleProcessUnit();

                ajaxRequest.makeRequest("/GeneralAllocateSaleProcessUnit/Edit", "POST", GeneralAllocateSaleProcessUnitData, GeneralAllocateSaleProcessUnit.Success);

            }
        }
        else if (GeneralAllocateSaleProcessUnit.ActionName == "Delete") {
            GeneralAllocateSaleProcessUnitData = null;
            //$("#FormCreateGeneralAllocateSaleProcessUnit").validate();
            GeneralAllocateSaleProcessUnitData = GeneralAllocateSaleProcessUnit.GetGeneralAllocateSaleProcessUnit();
            ajaxRequest.makeRequest("/GeneralAllocateSaleProcessUnit/Delete", "POST", GeneralAllocateSaleProcessUnitData, GeneralAllocateSaleProcessUnit.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetGeneralAllocateSaleProcessUnit: function () {

        var Data = {
        };
        if (GeneralAllocateSaleProcessUnit.ActionName == "Create" || GeneralAllocateSaleProcessUnit.ActionName == "Edit") {
            debugger;
            debugger;
            Data.SalesUnitID = $('input[name=SalesUnitID]').val();
            Data.UnitName = $('#UnitName').val();
            Data.SalesUnitProssessID = $('#SalesUnitProssessID').val();
            Data.AllocatedFromDate = $('#AllocatedFromDate').val();
            Data.AllocatedUptoDate = $('#AllocatedUptoDate').val();
        }
        else if (GeneralAllocateSaleProcessUnit.ActionName == "Delete") {
            Data.GeneralAllocateSaleProcessUnitID = $('input[name=GeneralAllocateSaleProcessUnitID]').val();

        }
        return Data;
    },




    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            GeneralAllocateSaleProcessUnit.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};

