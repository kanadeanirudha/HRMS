//this class contain methods related to nationality functionality
var SaleContractMachineMaster = {
    //Member variables
    ActionName: null,
    map: {},
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        SaleContractMachineMaster.constructor();
        //SaleContractMachineMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#SelectedCentreCode').focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#CountryName').focus();
            return false;
        });

        // Create new record
        $('#CreateSaleContractMachineMasterRecord').on("click", function () {
            SaleContractMachineMaster.ActionName = "Create";
            SaleContractMachineMaster.AjaxCallSaleContractMachineMaster();
        });

        $('#EditSaleContractMachineMasterRecord').on("click", function () {

            SaleContractMachineMaster.ActionName = "Edit";
            SaleContractMachineMaster.AjaxCallSaleContractMachineMaster();
        });

        $('#DeleteSaleContractMachineMasterRecord').on("click", function () {

            SaleContractMachineMaster.ActionName = "Delete";
            SaleContractMachineMaster.AjaxCallSaleContractMachineMaster();
        });
        
        $("#btnShowList").unbind('click').click(function () {
            var SelectedCentreCode = $("#SelectedCentreCode").val();
            if (SelectedCentreCode == "") {
                notify("Please select Centre", 'warning');
                return false;
            }
            SaleContractMachineMaster.LoadList();
        });
        $("#SelectedCentreCode").unbind('change').change(function () {
            var SelectedCentreCode = $(this).val();
            if (SelectedCentreCode == "") {
                $("ul.actions").hide();
                return false;
            }
            var href = $("#btnCreateList").attr('href');
            href = '/SaleContractMachineMaster/Create?CentreCode=' + SelectedCentreCode
            $("#btnCreateList").attr('href', href);
            $("ul.actions").show();

        });

        $('#PurchaseDate').datetimepicker({
            format: 'DD MMMM YYYY',
            maxDate: moment(),
            ignoreReadonly: true,
        })

        $('#NextMaintanceDate').datetimepicker({
            format: 'DD MMMM YYYY',
            minDate: moment(),
            ignoreReadonly: true,
        })

        var getData = function () {
            return function findMatches(q, cb) {

                var matches, substringRegex;

                // an array that will be populated with substring matches
                matches = [];

                // regex used to determine if a string contains the substring `q`
                substrRegex = new RegExp(q, 'i');
                
                $.ajax({
                    url: "/SaleContractMachineMaster/GetItemSearchList",
                    type: "POST",
                    data: { term: q },
                    dataType: "json",
                    success: function (data) {

                        // iterate through the pool of strings and for any string that
                        // contains the substring `q`, add it to the `matches` array
                        //alert(data);
                        //console.log(data);
                        $.each(data, function (i, response) {

                            if (substrRegex.test(response.ItemDescription)) {
                                SaleContractMachineMaster.map[response.ItemDescription] = response;
                                matches.push(response.ItemDescription);

                            }

                        });

                    },
                    async: false
                })
                cb(matches);
            };

        };

        $("#ItemDescription").typeahead({
            hint: true,
            highlight: true,
            minLength: 1
        }, {
            source: getData()
        }).on("typeahead:selected", function (obj, item) {
            $("#ItemNumber").val(SaleContractMachineMaster.map[item].ItemNumber);
            $("#ItemDescription").val(SaleContractMachineMaster.map[item].ItemDescription);
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
             url: '/SaleContractMachineMaster/List',
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
            url: '/SaleContractMachineMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                notify(message,colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallSaleContractMachineMaster: function () {
        var SaleContractMachineMasterData = null;
        if (SaleContractMachineMaster.ActionName == "Create") {
            $("#FormCreateSaleContractMachineMaster").validate();
            if ($("#FormCreateSaleContractMachineMaster").valid()) {
                SaleContractMachineMasterData = null;
                SaleContractMachineMasterData = SaleContractMachineMaster.GetSaleContractMachineMaster();
                ajaxRequest.makeRequest("/SaleContractMachineMaster/Create", "POST", SaleContractMachineMasterData, SaleContractMachineMaster.Success);
            }
        }
        else if (SaleContractMachineMaster.ActionName == "Edit") {
            $("#FormEditSaleContractMachineMaster").validate();
            if ($("#FormEditSaleContractMachineMaster").valid()) {
                SaleContractMachineMasterData = null;
                SaleContractMachineMasterData = SaleContractMachineMaster.GetSaleContractMachineMaster();
                ajaxRequest.makeRequest("/SaleContractMachineMaster/Edit", "POST", SaleContractMachineMasterData, SaleContractMachineMaster.Success);
            }
        }
        else if (SaleContractMachineMaster.ActionName == "Delete") {
            SaleContractMachineMasterData = null;
            //$("#FormCreateSaleContractMachineMaster").validate();
            SaleContractMachineMasterData = SaleContractMachineMaster.GetSaleContractMachineMaster();
            ajaxRequest.makeRequest("/SaleContractMachineMaster/Delete", "POST", SaleContractMachineMasterData, SaleContractMachineMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetSaleContractMachineMaster: function () {
        var Data = {
        };
        if (SaleContractMachineMaster.ActionName == "Create" || SaleContractMachineMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.CentreCode = $('#SelectedCentreCode').val();
            Data.ItemNumber = $('#ItemNumber').val();
            Data.Name = $('#Name').val();
            Data.SerialNumber = $('#SerialNumber').val();
            Data.PurchaseDate = $('#PurchaseDate').val();
            Data.NextMaintanceDate = $("#NextMaintanceDate").val();
            Data.MachineType = $('#MachineType').val();
            Data.MachineUseFor = $('#MachineUseFor').val();
            Data.ModelNumber = $('#ModelNumber').val();
            Data.MakeBy = $("#MakeBy").val();
            Data.PurchaseCost = $("#PurchaseCost").val();
        }
        else if (SaleContractMachineMaster.ActionName == "Delete") {
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
            SaleContractMachineMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            SaleContractMachineMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
};

