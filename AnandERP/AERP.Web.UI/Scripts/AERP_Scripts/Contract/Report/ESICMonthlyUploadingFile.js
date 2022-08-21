//this class contain methods related to nationality functionality
var ESICMonthlyUploadingFile = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        ESICMonthlyUploadingFile.constructor();
        //ESICMonthlyUploadingFile.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            return false;
        });

        $("#btnShowDetails").unbind('click').click(function () {
            debugger;
            var MonthName = $('#MonthName').val();
            var MonthYear = $('#MonthYear').val();
            if ((MonthName > 0) &&( MonthYear >0))
            {
                debugger;
                $("#UploadFile").show(true);
                $("#UploadFilelink").attr("href", "ESICMonthlyUploadingFile/DownloadExcel?MonthName=" + MonthName + "&MonthYear=" + MonthYear)
             //   ESICMonthlyUploadingFile.LoadList(MonthName, MonthYear);
            }
           
            else if (MonthName == '' ||MonthName == 0) {
                notify('Please select Month', 'warning');
                $("#UploadFile").hide(true);
                //$("#tblDataPRQ tbody tr").remove();
                //return false;
            }
            else if(MonthYear==''||MonthYear==0)
            {
                notify('Please select Year', 'warning');
                $("#UploadFile").hide(true);
                //$("#tblDataPRQ tbody tr").remove();
                //return false;
            }
           
          
        });

        // Create new record

        $('#CreateESICMonthlyUploadingFileRecord').on("click", function () {
            debugger;
            if ($("#ChallanRemmittanceDate").val() == "" || $("#ChallanRemmittanceDate").val() == null)
            {
                notify('Please select Challan Remmittance Date', 'warning');
                return false;
            }
            else if ($("#PaymentMode").val() == "" || $("#PaymentMode").val() == 0)
            {
                notify('Please select Payement Mode', 'warning');
                return false;
            } 
            else if ($("#ReferenceNumber").val() == "" || $("#ReferenceNumber").val() == null) {
                notify('Please Enter Reference Number', 'warning');
                return false;
            }
            else{
            
            ESICMonthlyUploadingFile.ActionName = "Create";
            ESICMonthlyUploadingFile.AjaxCallESICMonthlyUploadingFile();
            }
        });


        InitAnimatedBorder();
        CloseAlert();

    },
    //LoadList method is used to load List page
    LoadList: function (MonthName,MonthYear) {
        debugger;
        $.ajax(
         {
             cache: false,
             type: "POST",
             data: { MonthName: MonthName, MonthYear: MonthYear },
             dataType: "html",
             url: '/ESICMonthlyUploadingFile/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModeldata').html(data);

             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        debugger;
        var MonthName = $('#MonthName').val();
        var MonthYear = $('#MonthYear').val();
        alert(MonthYear)
        $.ajax(
        {

            cache: false,
            type: "POST",
            dataType: "html",
            data: { actionMode: actionMode, "MonthName": MonthName, "MonthYear": MonthYear },
            url: '/ESICMonthlyUploadingFile/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModeldata").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record

    AjaxCallESICMonthlyUploadingFile: function () {
        var ESICMonthlyUploadingFileData = null;

        if (ESICMonthlyUploadingFile.ActionName == "Create") {
            ESICMonthlyUploadingFileData = null;
            ESICMonthlyUploadingFileData = ESICMonthlyUploadingFile.GetESICMonthlyUploadingFile();
            ajaxRequest.makeRequest("/ESICMonthlyUploadingFile/Create", "POST", ESICMonthlyUploadingFileData, ESICMonthlyUploadingFile.Success, "CreateESICMonthlyUploadingFileRecord");

        }

    },
    //Get properties data from the Create, Update and Delete page
    GetESICMonthlyUploadingFile: function () {
        var Data = {
        };

        if (ESICMonthlyUploadingFile.ActionName == "Create" || ESICMonthlyUploadingFile.ActionName == "Edit") {

            Data.ID = $('#ID').val();
            Data.XMLstring = ESICMonthlyUploadingFile.ParameterXml;
            Data.MonthName = $('#MonthName').val();
            Data.MonthYear = $('#MonthYear').val();
            Data.PaymentMode = $('#PaymentMode').val();
            Data.ReferenceNumber = $('#ReferenceNumber').val();
            Data.ChallanRemmittanceDate = $('#ChallanRemmittanceDate').val();
            Data.WorkersShare = $('#WorkersShare').val();
            Data.Acc01 = $('#Acc01').val();
            Data.Acc02 = $('#Acc02').val();
            Data.Acc10 = $('#Acc10').val();
            Data.Acc21 = $('#Acc21').val();
            Data.Acc22 = $('#Acc22').val();
            Data.TotalAmountRemited = $('#TotalAmountRemited').val();

        }
        else if (ESICMonthlyUploadingFile.ActionName == "Delete") {

            Data.ID = $('#ID').val();
            // Data.ID = $('input[name=ID]').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {

        debugger;
        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            ESICMonthlyUploadingFile.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
          //  $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);

            notify(splitData[0], splitData[1]);
        }
    },

};
