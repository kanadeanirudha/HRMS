// the class to work with all the ajax request and
var ajaxRequest =
{
    makeRequest: function (requestUrl, type, contextData, successCallback,  buttonId ,errorCallback, dataType, isasync ) {

        if (dataType == null) {
            dataType = "json";
        }
        if (isasync == null) {
            isasync = true;
        }
        //ajaxRequest.showBusyIndicator();
        switch (type) {
            case "GET":
                $("#" + buttonId).attr("disabled", true);
                $.ajax({
                    type: "GET",
                    cache: false,
                    async: isasync,
                    contentType: "application/json; charset=utf-8",
                    url: requestUrl,
                    data: contextData,
                    dataType: dataType,
                    success: function (response) { if (successCallback) { successCallback(response); } },
                    error: function (response) {
                    },
                    complete: function (jqXHR, textStatus) {
                        ajaxRequest.hideBusyIndicator();
                        $("#" + buttonId).attr("disabled", false);
                    }
                });
                break;

            case "POST":
              
                // Make POST http ajax request
                $("#" + buttonId).attr("disabled", true);
                $.ajax({
                    type: "POST",
                    cache: false,
                    contentType: "application/json; charset=utf-8",
                    url: requestUrl,
                    data: JSON.stringify(contextData),
                    dataType: dataType,
                    success: function (response) {
                        if (successCallback) {
                            successCallback(response);
                        }
                    },
                    error: function (response) { },
                    statusCode:
                    {
                        400: function (data) {
                            var validationResult = $.parseJSON(data.responseText);
                            $.publish("ShowValidationError", [validationResult]);
                        }
                    },
                    complete: function (jqXHR, textStatus) {
                        ajaxRequest.hideBusyIndicator();
                        $("#" + buttonId).attr("disabled", false);
                    }
                });
                break;

        }
    },

    showBusyIndicator: function () {
        //        $.blockUI({
        //            message: '<img style="" src="/asset/busy.gif" />',
        //            css: { backgroundColor: "transparent", border: 'none' }
        //        }); ;
    },

    hideBusyIndicator: function () {
        //$.unblockUI();
    },

    ErrorMessageForJS: function (keyName, divId, colorCode) {
        $.ajax(
                {
                    cache: false,
                    type: "GET",
                    data: { keyName: keyName },
                    url: '/Base/ErrorMessageForJS', // Base = BaseControler
                    success: function (data) {
                        $('#' + divId + '').html(data);
                        $('#' + divId + '').delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', colorCode);
                    }
                });
    },

    GeneralMessageForJS: function (keyName) {
        var message = "";
        $.ajax(
                {
                    cache: false,
                    type: "GET",
                    data: { keyName: keyName },
                    url: '/Base/GeneralMessageForJS', // Base = BaseControler
                    success: function (data) {
                        message=data;
                       // return data
                    }
                });
       // alert(message+"212");
        return message;
    },

    GeneralMessageAlertForJS: function (keyName) {
        var message = "";
        $.ajax(
                {
                    cache: false,
                    type: "GET",
                    data: { keyName: keyName },
                    url: '/Base/GeneralMessageForJS', // Base = BaseControler
                    success: function (data) {
                        alert(data);
                        // return data
                    }
                });
       
    },

    ErrorMessageWithOtherDateForJS: function (keyName, divId, colorCode, staticText, staticTextPosition) {
        $.ajax(
                {
                    cache: false,
                    type: "GET",
                    data: { keyName: keyName },
                    url: '/Base/ErrorMessageForJS', // Base = BaseControler
                    success: function (data) {
                        if (staticTextPosition == "left") {
                            $('#' + divId + '').html(staticText + " " + data);
                        }
                        else {
                            $('#' + divId + '').html(data + " " + staticText);
                        }
                        $('#' + divId + '').delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', colorCode);
                    }
                });
    },
};
// the class to work with all the ajax request and
var ajaxRequest =
{
    makeRequest: function (requestUrl, type, contextData, successCallback, buttonId, errorCallback, dataType, isasync) {

        if (dataType == null) {
            dataType = "json";
        }
        if (isasync == null) {
            isasync = true;
        }
        //ajaxRequest.showBusyIndicator();
        switch (type) {
            case "GET":
                $("#" + buttonId).attr("disabled", true);
                $.ajax({
                    type: "GET",
                    cache: false,
                    async: isasync,
                    contentType: "application/json; charset=utf-8",
                    url: requestUrl,
                    data: contextData,
                    dataType: dataType,
                    success: function (response) { if (successCallback) { successCallback(response); } },
                    error: function (response) {
                    },
                    complete: function (jqXHR, textStatus) {
                        ajaxRequest.hideBusyIndicator();
                        $("#" + buttonId).attr("disabled", false);
                    }
                });
                break;

            case "POST":
              
                // Make POST http ajax request
                $("#" + buttonId).attr("disabled", true);
                $.ajax({
                    type: "POST",
                    cache: false,
                    contentType: "application/json; charset=utf-8",
                    url: requestUrl,
                    data: JSON.stringify(contextData),
                    dataType: dataType,
                    success: function (response) {
                        if (successCallback) {
                            successCallback(response);
                        }
                    },
                    error: function (response) { },
                    statusCode:
                    {
                        400: function (data) {
                            var validationResult = $.parseJSON(data.responseText);
                            $.publish("ShowValidationError", [validationResult]);
                        }
                    },
                    complete: function (jqXHR, textStatus) {
                        ajaxRequest.hideBusyIndicator();
                        $("#" + buttonId).attr("disabled", false);
                    }
                });
                break;

        }
    },

    showBusyIndicator: function () {
        //        $.blockUI({
        //            message: '<img style="" src="/asset/busy.gif" />',
        //            css: { backgroundColor: "transparent", border: 'none' }
        //        }); ;
    },

    hideBusyIndicator: function () {
        //$.unblockUI();
    },

    ErrorMessageForJS: function (keyName, divId, colorCode) {
        $.ajax(
                {
                    cache: false,
                    type: "GET",
                    data: { keyName: keyName },
                    url: '/Base/ErrorMessageForJS', // Base = BaseControler
                    success: function (data) {
                        $('#' + divId + '').html(data);
                        $('#' + divId + '').delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', colorCode);
                    }
                });
    },

    GeneralMessageForJS: function (keyName) {
        var message = "";
        $.ajax(
                {
                    cache: false,
                    type: "GET",
                    data: { keyName: keyName },
                    url: '/Base/GeneralMessageForJS', // Base = BaseControler
                    success: function (data) {
                        message = data;
                        // return data
                    }
                });
        // alert(message+"212");
        return message;
    },

    GeneralMessageAlertForJS: function (keyName) {
        var message = "";
        $.ajax(
                {
                    cache: false,
                    type: "GET",
                    data: { keyName: keyName },
                    url: '/Base/GeneralMessageForJS', // Base = BaseControler
                    success: function (data) {
                        alert(data);
                        // return data
                    }
                });

    },

    ErrorMessageWithOtherDateForJS: function (keyName, divId, colorCode, staticText, staticTextPosition) {
        $.ajax(
                {
                    cache: false,
                    type: "GET",
                    data: { keyName: keyName },
                    url: '/Base/ErrorMessageForJS', // Base = BaseControler
                    success: function (data) {
                        if (staticTextPosition == "left") {
                            $('#' + divId + '').html(staticText + " " + data);
                        }
                        else {
                            $('#' + divId + '').html(data + " " + staticText);
                        }
                        $('#' + divId + '').delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', colorCode);
                    }
                });
    },
};
