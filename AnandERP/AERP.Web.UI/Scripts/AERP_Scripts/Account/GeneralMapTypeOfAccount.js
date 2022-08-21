//this class contain methods related to nationality functionality
var GeneralMapTypeOfAccount = {
    //Member variables
    ActionName: null,
    CheckInfo: false,
    CheckText: true,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        GeneralMapTypeOfAccount.constructor();
        //GeneralMapTypeOfAccount.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#MarchandiseBaseCategoryName').focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#MarchandiseBaseCategoryName').focus();
            return false;
        });
        $('input[id^=txtControl]').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
            AERPValidation.NotAllowSpaces(e);
        });

       
        // Create new record

        $('#CreateGeneralMapTypeOfAccountRecord').on("click", function () {
            debugger;
            GeneralMapTypeOfAccount.ActionName = "Create";
            if ($('#ModuleName :selected').val() == null || $('#ModuleName :selected').val() == "") {
                $("#displayErrorMessage p").text("Please Select Module.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            else if ($('#MenuName :selected').val() == null || $('#MenuName :selected').val() == "") {
                $("#displayErrorMessage p").text("Please Select Menu.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
              
                GeneralMapTypeOfAccount.GetXmlData();
                if (GeneralMapTypeOfAccount.CheckInfo == false) {
                    $("#displayErrorMessage p").text("Please Select At least one Account Before Saving Information.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    return false;
                }
                if (GeneralMapTypeOfAccount.CheckText == true) {
                    GeneralMapTypeOfAccount.AjaxCallGeneralMapTypeOfAccount();
                }
                else
                {
                    $("#displayErrorMessage p").text("Please Enter Control Name.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    return false;
                }
        });

        $('#EditGeneralMapTypeOfAccountRecord').on("click", function () {

            GeneralMapTypeOfAccount.ActionName = "Edit";
            GeneralMapTypeOfAccount.AjaxCallGeneralMapTypeOfAccount();
        });

        $('#DeleteGeneralMapTypeOfAccountRecord').on("click", function () {

            GeneralMapTypeOfAccount.ActionName = "Delete";
            GeneralMapTypeOfAccount.AjaxCallGeneralMapTypeOfAccount();
        });

        InitAnimatedBorder();

        CloseAlert();
       
        $("#ModuleName").change(function () {
            
            var selectedItem = $("#ModuleName").val();
            var $ddlDepartment = $("#MenuName");
            if ($("#ModuleName").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/GeneralMapTypeOfAccount/GetMenuByModuleName",

                    data: { "ModuleName": selectedItem },
                    success: function (data) {
                        $ddlDepartment.html('');
                        $ddlDepartment.append('<option value="">----Select Menu----</option>');
                        $.each(data, function (id, option) {

                            $ddlDepartment.append($('<option></option>').val(option.id).html(option.name));
                        });
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Department.');
                        $DepartmentProgress.hide();
                    }
                });
            }
            else {
               
                $('#MenuName').find('option').remove().end().append('<option value>All</option>');
            }
           

        });

    },

    CheckedAll: function () {
        $("#tblData thead tr th input[class='checkall-user']").on('click', function () {
            var $this = $(this);
            if ($this.is(":checked")) {
                $("#tblData tbody tr td  input[class='check-user']").prop("checked", true);
            }
            else {
                $("#tblData tbody tr td  input[class='check-user']").prop("checked", false);
            }
        });
    },
  
    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax(
         {
             cache: false,
             type: "POST",

             dataType: "html",
             url: '/GeneralMapTypeOfAccount/List',
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
            url: '/GeneralMapTypeOfAccount/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },

    //Get xml method for inserting records
    GetXmlData: function () {
        GeneralMapTypeOfAccount.CheckText = true;
        var DataArray = [];
        var table = $('#tblData').DataTable();
        var data = table.$('input,select').each(function () {
            if ($(this).attr('type') == 'checkbox') {
                

                DataArray.push($(this).is(":checked") ? 1 : 0);
                if($(this).is(":checked") == 1)
                {
                    GeneralMapTypeOfAccount.CheckInfo = true;
                }
            
            }
            else {
                DataArray.push($(this).val());
            }            
        });
        
        table.destroy();

        var TotalRecord = DataArray.length;
       // alert(DataArray)
       // alert(TotalRecord);
        var ParameterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 5) {

            if (DataArray[i] == 1)
            {
                if (DataArray[i + 4] == "" || DataArray[i + 4] == null)
            {
                
                // $("#displayErrorMessage p").text("Please Enter Control Name.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                 GeneralMapTypeOfAccount.CheckText = false;
                 break;
                 
             }
            else
             {
                 ParameterXml = ParameterXml + "<row><ID>" + 0 + "</ID><GeneralTypeOfAccountId>" + DataArray[i + 1] + "</GeneralTypeOfAccountId><DebitCreditStatus>" + DataArray[i + 3] + "</DebitCreditStatus><ControlName>" + DataArray[i + 4] + "</ControlName></row>";
             }

            }
        }
    
        if (ParameterXml.length > 10)
            GeneralMapTypeOfAccount.XMLstring = ParameterXml + "</rows>";

        else
            GeneralMapTypeOfAccount.XMLstring = "";

       // alert(GeneralMapTypeOfAccount.XMLstring)
    },

    //Fire ajax call to insert update and delete record

    AjaxCallGeneralMapTypeOfAccount: function () {
        var GeneralMapTypeOfAccountData = null;

        if (GeneralMapTypeOfAccount.ActionName == "Create") {

            $("#FormCreateGeneralMapTypeOfAccount").validate();
            if ($("#FormCreateGeneralMapTypeOfAccount").valid()) {
                GeneralMapTypeOfAccountData = null;
                GeneralMapTypeOfAccountData = GeneralMapTypeOfAccount.GetGeneralMapTypeOfAccount();
                ajaxRequest.makeRequest("/GeneralMapTypeOfAccount/Create", "POST", GeneralMapTypeOfAccountData, GeneralMapTypeOfAccount.Success, "CreateGeneralMapTypeOfAccountRecord");
            }
        }
        else if (GeneralMapTypeOfAccount.ActionName == "Edit") {
            $("#FormEditGeneralMapTypeOfAccount").validate();
            if ($("#FormEditGeneralMapTypeOfAccount").valid()) {
                GeneralMapTypeOfAccountData = null;
                GeneralMapTypeOfAccountData = GeneralMapTypeOfAccount.GetGeneralMapTypeOfAccount();
                ajaxRequest.makeRequest("/GeneralMapTypeOfAccount/Edit", "POST", GeneralMapTypeOfAccountData, GeneralMapTypeOfAccount.Success, "EditGeneralMapTypeOfAccountRecord");
            }
        }
        else if (GeneralMapTypeOfAccount.ActionName == "Delete") {

            GeneralMapTypeOfAccountData = null;
            $("#FormCreateGeneralMapTypeOfAccount").validate();
            GeneralMapTypeOfAccountData = GeneralMapTypeOfAccount.GetGeneralMapTypeOfAccount();
            ajaxRequest.makeRequest("/GeneralMapTypeOfAccount/Delete", "POST", GeneralMapTypeOfAccountData, GeneralMapTypeOfAccount.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetGeneralMapTypeOfAccount: function () {
        var Data = {
        };

        if (GeneralMapTypeOfAccount.ActionName == "Create" || GeneralMapTypeOfAccount.ActionName == "Edit") {

            Data.GeneralMapTypeOfAccountID = $('input[name=GeneralMapTypeOfAccountID]').val();
            Data.GeneralTypeOfAccountId = $('input[name=GeneralTypeOfAccountId]').val();
            Data.ControlName = $('#ControlName').val();
            Data.MenuCode = $('#MenuCode').val();
            Data.MenuName = $('#MenuName :selected').val();
            Data.DebitCreditStatus = $('#DebitCreditStatus').val();
            Data.AccName = $('#AccName').val();
            Data.MenuName = $('#MenuName').val();
            Data.UserMainMenuMasterID = $('#UserMainMenuMasterID').val();
            Data.GeneralTypeOfAccountId = $('#GeneralTypeOfAccountId').val();                 
            Data.XMLstring = GeneralMapTypeOfAccount.XMLstring;
        }
        else if (GeneralMapTypeOfAccount.ActionName == "Delete") {

            Data.ID = $('#ID').val();
            Data.MenuCode = $('#MenuCode').val();
            // Data.ID = $('input[name=ID]').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {


        var splitData = data.split(',');                  
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            GeneralMapTypeOfAccount.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};

//this is used to for showing successfully record updation message and reload the list view
// editSuccess: function (data) {



// if (data == "True") {

//        parent.$.colorbox.close();
//    var actionMode = "1";
//       GeneralMapTypeOfAccount.ReloadList("Record Updated Sucessfully.", actionMode);
//        //  alert("Record Created Sucessfully.");

//    } else {
//        parent.$.colorbox.close();
//        // alert("Record Not Updated Sucessfully. Please Try Again..");
//    }

//},
////this is used to for showing successfully record deletion message and reload the list view
//deleteSuccess: function (data) {


//    if (data == "True") {

//        parent.$.colorbox.close();
//        GeneralMapTypeOfAccount.ReloadList("Record Deleted Sucessfully.");
//      //  alert("Record Deleted Sucessfully.");

//    } else {
//        parent.$.colorbox.close();
//       // alert("Record Not Deleted Sucessfully. Please Try Again..");
//    }


//},


