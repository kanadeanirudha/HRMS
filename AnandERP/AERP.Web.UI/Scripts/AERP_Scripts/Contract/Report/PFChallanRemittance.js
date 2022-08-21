//this class contain methods related to nationality functionality
var PFChallanRemittance = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        PFChallanRemittance.constructor();
        //PFChallanRemittance.initializeValidation();
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
                $("#UploadFile").show(true);
                $("#UploadFilelink").attr("href", "PFChallanRemittance/DownloadTxtFile?MonthName=" + MonthName + "&MonthYear=" + MonthYear)


                PFChallanRemittance.LoadList(MonthName, MonthYear);
                $("#DownloadPFFile").show(true);
                //$("#DownloadExcelPFFile").attr("href", "PFChallanRemittance/DownloadExcelPFFile?GridHtml=" + $("#DivAddRowTable1").html())

               
            }
           
            else if (MonthName == '' ||MonthName == 0) {
                notify('Please select Month', 'warning');
                $("#UploadFile").hide(true);
                $("#tblDataPRQ tbody tr").remove();
                return false;
            }
            else if(MonthYear==''||MonthYear==0)
            {
                notify('Please select Year', 'warning');
                $("#UploadFile").hide(true);
                $("#tblDataPRQ tbody tr").remove();
                return false;
            }
           
          
        });
        $('#btnSubmit').on("click", function () {
            $("#GridHtml").val($("#DownloadExcelView").html())
        });
        // Create new record

        $('#CreatePFChallanRemittanceRecord').on("click", function () {
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
            
            PFChallanRemittance.ActionName = "Create";
            PFChallanRemittance.AjaxCallPFChallanRemittance();
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
             url: '/PFChallanRemittance/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModeldata').html(data);
                 //$("#DownloadExcelPFFile").attr("href", "PFChallanRemittance/DownloadExcelPFFile?GridHtml=" + $("#DivAddRowTable1").html())
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
            url: '/PFChallanRemittance/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModeldata").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record

    AjaxCallPFChallanRemittance: function () {
        var PFChallanRemittanceData = null;

        if (PFChallanRemittance.ActionName == "Create") {
            PFChallanRemittanceData = null;
            PFChallanRemittanceData = PFChallanRemittance.GetPFChallanRemittance();
            ajaxRequest.makeRequest("/PFChallanRemittance/Create", "POST", PFChallanRemittanceData, PFChallanRemittance.Success, "CreatePFChallanRemittanceRecord");

        }

    },
    //Get properties data from the Create, Update and Delete page
    GetPFChallanRemittance: function () {
        var Data = {
        };

        if (PFChallanRemittance.ActionName == "Create" || PFChallanRemittance.ActionName == "Edit") {

            Data.ID = $('#ID').val();
            Data.XMLstring = PFChallanRemittance.ParameterXml;
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
        else if (PFChallanRemittance.ActionName == "Delete") {

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
            PFChallanRemittance.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
          //  $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);

            notify(splitData[0], splitData[1]);
        }
    },

};
