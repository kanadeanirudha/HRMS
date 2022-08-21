

//this class contain methods related to Itemwise consumption report functionality

var CurrentStockReport = {
    ActionName: null,
    SelectedLocationIDs: null,
    //Class intialisation method
    Initialize: function () {
        CurrentStockReport.constructor();
    },
    //Attach all event of page
    constructor: function () {
        //Reset button click event function to reset all controls of form
       

        $('#btnShowList').on("click", function () {
            debugger;
            //if ($("#BalancesheetID").val() != null && $("#BalancesheetID").val() > 0) {
                CurrentStockReport.GetSelectedLocationListXML();
                //$("#AccountBalsheetMstID").val($("#selectedBalsheetID").val());
                $("#IsPosted").val(true);
            //}
            //else {
            //    //ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectBalancesheet", "SuccessMessage", "#FFCC80");
                
            //}
        });
       
    },

    //Genrate XML for item list.
    GetSelectedLocationListXML: function () {
        debugger;
        var DataArray = "";
        var selectedLocation = $("select[name=Location]").val().toString();

        if ($("#LocationID").val() != null && $("#LocationID").val() != "") {
            DataArray = selectedLocation.split(',');
        }

        var TotalRecord = selectedLocation.split(',').length;
        //alert(TotalRecord)
        var selectedLocationXML = "<rows>";

        for (var i = 0; i < TotalRecord; i++) {
            debugger;
            //EmployeeScheduleXML = EmployeeScheduleXML + "<row><ID>0</ID><EmployeeID>3</EmployeeID></row>";

            if (DataArray[i] != "") {
                selectedLocationXML = selectedLocationXML + "<row><ID>0</ID><LocationID>" + DataArray[i] + "</LocationID></row>";
            }
        }
       // alert(selectedLocationXML)
        if (selectedLocationXML.length > 6) {
            CurrentStockReport.SelectedLocationIDs = selectedLocationXML + "</rows>";
            $("#LocationNameListXml").val(CurrentStockReport.SelectedLocationIDs);
        }
        else {
            $("#LocationNameListXml").val('');
        }
      //  alert($("#LocationNameListXml").val())
    },
};