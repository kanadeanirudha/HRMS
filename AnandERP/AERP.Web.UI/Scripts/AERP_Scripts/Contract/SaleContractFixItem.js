//this class contain methods related to nationality functionality
var SaleContractFixItem = {
    //Member variables
    ActionName: null,
    map: {},
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        SaleContractFixItem.constructor();
        //SaleContractFixItem.initializeValidation();
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
        $('#CreateSaleContractFixItemRecord').on("click", function () {
            SaleContractFixItem.ActionName = "Create";
            SaleContractFixItem.AjaxCallSaleContractFixItem();
        });

        $('#EditSaleContractFixItemRecord').on("click", function () {

            SaleContractFixItem.ActionName = "Edit";
            SaleContractFixItem.AjaxCallSaleContractFixItem();
        });

        $('#DeleteSaleContractFixItemRecord').on("click", function () {

            SaleContractFixItem.ActionName = "Delete";
            SaleContractFixItem.AjaxCallSaleContractFixItem();
        });

        var getData = function () {
            return function findMatches(q, cb) {

                var matches, substringRegex;

                // an array that will be populated with substring matches
                matches = [];

                // regex used to determine if a string contains the substring `q`
                substrRegex = new RegExp(q, 'i');
                
                $.ajax({
                    url: "/SaleContractFixItem/GetItemSearchList",
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
                                SaleContractFixItem.map[response.ItemDescription] = response;
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
            $("#ItemNumber").val(SaleContractFixItem.map[item].ItemNumber);
            $("#ItemDescription").val(SaleContractFixItem.map[item].ItemDescription);
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
             url: '/SaleContractFixItem/List',
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
            url: '/SaleContractFixItem/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                notify(message,colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallSaleContractFixItem: function () {
        var SaleContractFixItemData = null;
        if (SaleContractFixItem.ActionName == "Create") {
            $("#FormCreateSaleContractFixItem").validate();
            if ($("#FormCreateSaleContractFixItem").valid()) {
                SaleContractFixItemData = null;
                SaleContractFixItemData = SaleContractFixItem.GetSaleContractFixItem();
                ajaxRequest.makeRequest("/SaleContractFixItem/Create", "POST", SaleContractFixItemData, SaleContractFixItem.Success);
            }
        }
        else if (SaleContractFixItem.ActionName == "Edit") {
            $("#FormEditSaleContractFixItem").validate();
            if ($("#FormEditSaleContractFixItem").valid()) {
                SaleContractFixItemData = null;
                SaleContractFixItemData = SaleContractFixItem.GetSaleContractFixItem();
                ajaxRequest.makeRequest("/SaleContractFixItem/Edit", "POST", SaleContractFixItemData, SaleContractFixItem.Success);
            }
        }
        else if (SaleContractFixItem.ActionName == "Delete") {
            SaleContractFixItemData = null;
            //$("#FormCreateSaleContractFixItem").validate();
            SaleContractFixItemData = SaleContractFixItem.GetSaleContractFixItem();
            ajaxRequest.makeRequest("/SaleContractFixItem/Delete", "POST", SaleContractFixItemData, SaleContractFixItem.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetSaleContractFixItem: function () {
        var Data = {
        };
        if (SaleContractFixItem.ActionName == "Create" || SaleContractFixItem.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.ItemNumber = $('#ItemNumber').val();
            Data.Name = $('#Name').val();
            Data.SaleContractManPowerItemID = $('#SaleContractManPowerItemID').val();
        }
        else if (SaleContractFixItem.ActionName == "Delete") {
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
            SaleContractFixItem.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            SaleContractFixItem.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
};

