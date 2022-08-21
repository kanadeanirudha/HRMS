//this class contain methods related to nationality functionality
var SaleContractJobWorkItem = {
    //Member variables
    ActionName: null,
    map: {},
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        SaleContractJobWorkItem.constructor();
        //SaleContractJobWorkItem.initializeValidation();
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
        $('#CreateSaleContractJobWorkItemRecord').on("click", function () {
            SaleContractJobWorkItem.ActionName = "Create";
            SaleContractJobWorkItem.AjaxCallSaleContractJobWorkItem();
        });

        $('#EditSaleContractJobWorkItemRecord').on("click", function () {

            SaleContractJobWorkItem.ActionName = "Edit";
            SaleContractJobWorkItem.AjaxCallSaleContractJobWorkItem();
        });

        $('#DeleteSaleContractJobWorkItemRecord').on("click", function () {

            SaleContractJobWorkItem.ActionName = "Delete";
            SaleContractJobWorkItem.AjaxCallSaleContractJobWorkItem();
        });

        var getData = function () {
            return function findMatches(q, cb) {

                var matches, substringRegex;

                // an array that will be populated with substring matches
                matches = [];

                // regex used to determine if a string contains the substring `q`
                substrRegex = new RegExp(q, 'i');
                
                $.ajax({
                    url: "/SaleContractJobWorkItem/GetItemSearchList",
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
                                SaleContractJobWorkItem.map[response.ItemDescription] = response;
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
            $("#ItemNumber").val(SaleContractJobWorkItem.map[item].ItemNumber);
            $("#ItemDescription").val(SaleContractJobWorkItem.map[item].ItemDescription);
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
             url: '/SaleContractJobWorkItem/List',
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
            url: '/SaleContractJobWorkItem/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                notify(message,colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallSaleContractJobWorkItem: function () {
        var SaleContractJobWorkItemData = null;
        if (SaleContractJobWorkItem.ActionName == "Create") {
            $("#FormCreateSaleContractJobWorkItem").validate();
            if ($("#FormCreateSaleContractJobWorkItem").valid()) {
                SaleContractJobWorkItemData = null;
                SaleContractJobWorkItemData = SaleContractJobWorkItem.GetSaleContractJobWorkItem();
                ajaxRequest.makeRequest("/SaleContractJobWorkItem/Create", "POST", SaleContractJobWorkItemData, SaleContractJobWorkItem.Success);
            }
        }
        else if (SaleContractJobWorkItem.ActionName == "Edit") {
            $("#FormEditSaleContractJobWorkItem").validate();
            if ($("#FormEditSaleContractJobWorkItem").valid()) {
                SaleContractJobWorkItemData = null;
                SaleContractJobWorkItemData = SaleContractJobWorkItem.GetSaleContractJobWorkItem();
                ajaxRequest.makeRequest("/SaleContractJobWorkItem/Edit", "POST", SaleContractJobWorkItemData, SaleContractJobWorkItem.Success);
            }
        }
        else if (SaleContractJobWorkItem.ActionName == "Delete") {
            SaleContractJobWorkItemData = null;
            //$("#FormCreateSaleContractJobWorkItem").validate();
            SaleContractJobWorkItemData = SaleContractJobWorkItem.GetSaleContractJobWorkItem();
            ajaxRequest.makeRequest("/SaleContractJobWorkItem/Delete", "POST", SaleContractJobWorkItemData, SaleContractJobWorkItem.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetSaleContractJobWorkItem: function () {
        var Data = {
        };
        if (SaleContractJobWorkItem.ActionName == "Create" || SaleContractJobWorkItem.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.ItemNumber = $('#ItemNumber').val();
            Data.Name = $('#Name').val();
            Data.Rate = $('#Rate').val();
        }
        else if (SaleContractJobWorkItem.ActionName == "Delete") {
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
            SaleContractJobWorkItem.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            SaleContractJobWorkItem.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
};

