//this class contain methods related to nationality functionality
var EmployeeDocumentRequired = {
    //Member variables
    ActionName: null,
    SelectedIDs: null,
    EmployeeDocumentRequiredIDs: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        EmployeeDocumentRequired.constructor();
        //EmployeeDocumentRequired.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {
        $("#reset").click(function () {

            //$("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('.placeholder').val('');
           
        });

        // Create new record
        $('#CreateEmployeeDocumentRequiredRecord').on("click", function () {
           
            EmployeeDocumentRequired.ActionName = "Create";           
            EmployeeDocumentRequired.getValueUsingParentTag_Check_UnCheck();
            EmployeeDocumentRequired.AjaxCallEmployeeDocumentRequired();
        });

        $('#EditEmployeeDocumentRequiredRecord').on("click", function () {
           
            EmployeeDocumentRequired.ActionName = "Edit";
            EmployeeDocumentRequired.AjaxCallEmployeeDocumentRequired();
        });

        $('#DeleteEmployeeDocumentRequiredRecord').on("click", function () {

            EmployeeDocumentRequired.ActionName = "Delete";
            EmployeeDocumentRequired.AjaxCallEmployeeDocumentRequired();
        });

        $('#JobStatusDescription').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });


        $('#JobStatusCode').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $("#UserSearch").keyup(function () {
            var oTable = $("#myDataTable").dataTable();
            oTable.fnFilter(this.value);
        });

        $("#searchBtn").click(function () {
            $("#UserSearch").focus();
        });
        

        $("#showrecord").change(function () {
            var showRecord = $("#showrecord").val();
            $("select[name*='myDataTable_length']").val(showRecord);
            $("select[name*='myDataTable_length']").change();
        });

        //$(".ajax").colorbox();
        InitAnimatedBorder();
        CloseAlert();


        $("#ShowList").click(function () {
           
            var SelectedCentreCode = $('#CentreCode').val();
            var SelectedCentreName = $('#CentreCode :selected').text();

            if (SelectedCentreCode != "") {
                $.ajax(
             {
                 cache: false,
                 type: "POST",
                 data: { actionMode: null, centerCode: SelectedCentreCode, centreName: SelectedCentreName },

                 dataType: "html",
                 url: '/EmployeeDocumentRequired/List',
                 success: function (result) {
                     //Rebind Grid Data                
                     $('#ListViewModel').html(result);
                     // $('#Createbutton').show();
                 }
             });
            }
            else {
                //ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectCentre", "SuccessMessage", "#FFCC80");
                EmployeeDocumentRequired.ReloadList("Please select center", "warning", null);
                //   $('#Createbutton').hide();
            }
        });

        $("#myDataTableCreate tbody tr td input[id='Required']").on('click', function () {
           
            var $this = $(this);
            if ($this.is(":checked")) {
                $(this).closest("tr").find('td input[id="Compulsary"]').attr("disabled", false);
            }
            else {
                $(this).closest("tr").find('td input[id="Compulsary"]').prop('checked', false);
                $(this).closest("tr").find('td input[id="Compulsary"]').attr("disabled", true);
            }
            //var compulsaryFlag = $(this).closest("tr").find('td input[id="Compulsary"]').val();
            //var splitedCompulsaryFlag = compulsaryFlag.split('~');          
        });
    },
    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax(

         {

             cache: false,
             type: "POST",

             dataType: "html",
             url: '/EmployeeDocumentRequired/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        var SelectedCentreCode = $('#CentreCode').val();
        var SelectedCentreName = $('#CentreCode :selected').text();

        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { actionMode: null, centerCode: SelectedCentreCode, centreName: SelectedCentreName },
            url: '/EmployeeDocumentRequired/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', colorCode);
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallEmployeeDocumentRequired: function () {
        var EmployeeDocumentRequiredData = null;
        if (EmployeeDocumentRequired.ActionName == "Create") {
            $("#FormCreateEmployeeDocumentRequired").validate();
            if ($("#FormCreateEmployeeDocumentRequired").valid()) {
                EmployeeDocumentRequiredData = null;
                EmployeeDocumentRequiredData = EmployeeDocumentRequired.GetEmployeeDocumentRequired();
                ajaxRequest.makeRequest("/EmployeeDocumentRequired/Create", "POST", EmployeeDocumentRequiredData, EmployeeDocumentRequired.Success);
            }
        }       
    },
    //Get properties data from the Create, Update and Delete page
    GetEmployeeDocumentRequired: function () {
        var Data = {
        };
        if (EmployeeDocumentRequired.ActionName == "Create") {
            Data.LeaveRuleMasterID = $('input[name=LeaveRuleMasterID]').val();
            Data.SelectedIDs = EmployeeDocumentRequired.SelectedIDs;
        }       
        return Data;
    },


    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (data != null) {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            EmployeeDocumentRequired.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            EmployeeDocumentRequired.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
    },

    getValueUsingParentTag_Check_UnCheck: function () {      
        var sList = "";
        var xmlParamList = "<rows>";
        var DataArray = [];
        var sArray = [];
        var DatatableData, TotalRecord, TotalRow;
        $('#myDataTableCreate input[type=checkbox]').each(function () {
            if ($(this).val() != "on") {
                var a = $(this).val();
                sArray = $(this).val().split("~");
                if (this.checked == true) {
                    //xmlInsert code here
                    DataArray = DataArray + ',' + a + '~' + 'T';
                }
                else if (this.checked == false) {
                    //xmlUpdate code here
                    DataArray = DataArray + ',' + a + '~' + 'F';
                    }
            }
        });

        sArray = DataArray.split(',');
        TotalRecord = sArray.length - 1;
       
        var splitedArray = [];
        var splitedArrayForReq = [];
        var splitedArrayForCom = [];
        var i = 1;
        for (; i < TotalRecord ;) {
            splitedArrayForReq = sArray[i].split('~');
            splitedArrayForCom = sArray[i + 1].split('~');
            if ((splitedArrayForReq[0] == 0) && (splitedArrayForReq[3] == "T")) {
                if ((splitedArrayForCom[0] == 0) && (splitedArrayForCom[3] == "T")) {
                    xmlParamList = xmlParamList + "<row>" + "<ID>" + splitedArrayForReq[0] + "</ID>" + "<DocumentID>" + splitedArrayForReq[1] + "</DocumentID>" + "<DocumentCompulsaryFlag>1</DocumentCompulsaryFlag>" + "<IsActive>1</IsActive>" + "</row>";
                }
                else {
                    xmlParamList = xmlParamList + "<row>" + "<ID>" + splitedArrayForReq[0] + "</ID>" + "<DocumentID>" + splitedArrayForReq[1] + "</DocumentID>" + "<DocumentCompulsaryFlag>0</DocumentCompulsaryFlag>" + "<IsActive>1</IsActive>" + "</row>";
                }
            }
            else if ((splitedArrayForReq[0] != 0) && (splitedArrayForReq[3] == "T")) {
               
                if ((splitedArrayForCom[2] == "NC") && (splitedArrayForCom[3] == "T")) {
                    xmlParamList = xmlParamList + "<row>" + "<ID>" + splitedArrayForReq[0] + "</ID>" + "<DocumentID>" + splitedArrayForReq[1] + "</DocumentID>" + "<DocumentCompulsaryFlag>1</DocumentCompulsaryFlag>" + "<IsActive>1</IsActive>" + "</row>";
                }
                else if ((splitedArrayForCom[2] == "C") && (splitedArrayForCom[3] == "F")) {
                    xmlParamList = xmlParamList + "<row>" + "<ID>" + splitedArrayForReq[0] + "</ID>" + "<DocumentID>" + splitedArrayForReq[1] + "</DocumentID>" + "<DocumentCompulsaryFlag>0</DocumentCompulsaryFlag>" + "<IsActive>1</IsActive>" + "</row>";
                }
                else if ((splitedArrayForCom[2] == "C") && (splitedArrayForCom[3] == "T")) {
                    xmlParamList = xmlParamList + "<row>" + "<ID>" + splitedArrayForReq[0] + "</ID>" + "<DocumentID>" + splitedArrayForReq[1] + "</DocumentID>" + "<DocumentCompulsaryFlag>1</DocumentCompulsaryFlag>" + "<IsActive>1</IsActive>" + "</row>";
                }
                else if ((splitedArrayForCom[2] == "NC") && (splitedArrayForCom[3] == "F")) {
                    xmlParamList = xmlParamList + "<row>" + "<ID>" + splitedArrayForReq[0] + "</ID>" + "<DocumentID>" + splitedArrayForReq[1] + "</DocumentID>" + "<DocumentCompulsaryFlag>0</DocumentCompulsaryFlag>" + "<IsActive>1</IsActive>" + "</row>";
                }
            }
            else if ((splitedArrayForReq[0] != 0) && (splitedArrayForReq[3] == "F")) {
                xmlParamList = xmlParamList + "<row>" + "<ID>" + splitedArrayForReq[0] + "</ID>" + "<DocumentID>" + splitedArrayForReq[1] + "</DocumentID>" + "<DocumentCompulsaryFlag>0</DocumentCompulsaryFlag>" + "<IsActive>0</IsActive>" + "</row>";
            }
            i = i + 2;
        }
        EmployeeDocumentRequired.SelectedIDs = xmlParamList + "</rows>";
       // alert(EmployeeDocumentRequired.SelectedIDs);
    },
};

