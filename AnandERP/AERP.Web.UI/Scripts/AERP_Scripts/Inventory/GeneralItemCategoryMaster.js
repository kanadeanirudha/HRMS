//this class contain methods related to nationality functionality
var GeneralItemCategoryMaster = {
    //Member variables
    ActionName: null,

    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        GeneralItemCategoryMaster.constructor();
        //generalCountryMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            return false;
        });


        // Create new record
        $('#CreateGeneralItemCategoryMasterRecord').on("click", function () {
            GeneralItemCategoryMaster.ActionName = "Create";
            if ($("#selectedGroupDescription").val()==""  || $("#selectedGroupDescription").val() == null) {
                $("#displayErrorMessage p").text("Please Enter Merchandise Group").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            else if ($('#SelectedMerchandiseDepartmentID :selected').val() == "") {
                $("#displayErrorMessage p").text("Please Select Merchandise Department.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            else if ($('#SelectedMerchandiseCategoryID :selected').val() == "") {
                $("#displayErrorMessage p").text("Please Select Merchandise Category.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            else if ($('#SelectedMarchandiseSubCategoryID :selected').val() == "") {
                $("#displayErrorMessage p").text("Please Select Merchandise SubCategory.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            else if ($('#SelectedMarchandiseBaseCatgoryID :selected').val() == "") {
                $("#displayErrorMessage p").text("Please Select Merchandise Base Catgory.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            GeneralItemCategoryMaster.AjaxCallGeneralItemCategoryMaster();
        });
        $('#CreateGeneralItemCategoryMasterRecordExcel').on("click", function () {

            VendorMaster.ActionName = "UploadExcel";
            VendorMaster.AjaxCallVendorMaster();
        });

        $('#EditGeneralItemCategoryMasterRecord').on("click", function () {
            GeneralItemCategoryMaster.ActionName = "Edit";
            GeneralItemCategoryMaster.AjaxCallGeneralItemCategoryMaster();
        });
        $('#EditBMCGeneralItemCategoryMasterRecord').on("click", function () {
            GeneralItemCategoryMaster.ActionName = "EditBMC";
            GeneralItemCategoryMaster.AjaxCallGeneralItemCategoryMaster();
        });
        

        $('#DeleteGeneralItemCategoryMasterRecord').on("click", function () {
            GeneralItemCategoryMaster.ActionName = "Delete";
            GeneralItemCategoryMaster.AjaxCallGeneralItemCategoryMaster();
        });

        $('#CreateGeneralItemCategoryMasterInsertGroupRecord').on("click", function () {
            GeneralItemCategoryMaster.ActionName = "CreateBMC";
            if ($("#GroupDescription").val() == "" || $("#GroupDescription").val() == null) {
                $("#displayErrorMessage p").text("Please Enter Group Description").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            if ($("#MarchandiseGroupCode").val() == "" || $("#MarchandiseGroupCode").val() == null) {
                $("#displayErrorMessage p").text("Please Enter Group Code").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            GeneralItemCategoryMaster.AjaxCallGeneralItemCategoryMaster();
        });

        $('#CreateGeneralItemCategoryMasterInsertDepartmentRecord').on("click", function () {
            GeneralItemCategoryMaster.ActionName = "CreateBMCDepartment";
            if ($("#MerchantiseDepartmentName").val() == "" || $("#MerchantiseDepartmentName").val() == null) {
                $("#displayErrorMessage p").text("Please Enter Department").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            if ($("#MerchantiseDepartmentCode").val() == "" || $("#MerchantiseDepartmentCode").val() == null) {
                $("#displayErrorMessage p").text("Please Enter Department Code").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }


            GeneralItemCategoryMaster.AjaxCallGeneralItemCategoryMaster();
        });
        $('#CreateGeneralItemCategoryMasterInsertCategoryRecord').on("click", function () {
            GeneralItemCategoryMaster.ActionName = "CreateBMCCategory";
            if ($("#MerchantiseCategoryName").val() == "" || $("#MerchantiseCategoryName").val() == null) {
                $("#displayErrorMessage p").text("Please Enter Category").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            if ($("#MerchantiseCategoryCode").val() == "" || $("#MerchantiseCategoryCode").val() == null) {
                $("#displayErrorMessage p").text("Please Enter Category Code").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            GeneralItemCategoryMaster.AjaxCallGeneralItemCategoryMaster();
        });
        $('#CreateGeneralItemCategoryMasterInsertSubCategoryRecord').on("click", function () {
            GeneralItemCategoryMaster.ActionName = "CreateBMCSUbCategory";
            if ($("#MarchantiseSubCategoryName").val() == "" || $("#MarchantiseSubCategoryName").val() == null) {
                $("#displayErrorMessage p").text("Please Enter Sub Category").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            if ($("#MerchantiseSubCategoryCode").val() == "" || $("#MerchantiseSubCategoryCode").val() == null) {
                $("#displayErrorMessage p").text("Please Enter Sub Category Code").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            GeneralItemCategoryMaster.AjaxCallGeneralItemCategoryMaster();
        });
        $('#CreateGeneralItemCategoryMasterInsertBaseCategoryRecord').on("click", function () {
            GeneralItemCategoryMaster.ActionName = "CreateBMCBaseCategory";
            if ($("#MarchandiseBaseCategoryName").val() == "" || $("#MarchandiseBaseCategoryName").val() == null) {
                $("#displayErrorMessage p").text("Please Enter Base Category").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            if ($("#MarchandiseBaseCatgoryCode").val() == "" || $("#MarchandiseBaseCatgoryCode").val() == null) {
                $("#displayErrorMessage p").text("Please Enter Base Category Code").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            GeneralItemCategoryMaster.AjaxCallGeneralItemCategoryMaster();
        });

        $('#ItemCategoryDescription').on("keydown", function (e) {
            AERPValidation.AllowAlphaNumericOnly(e)
        });


        $("#SelectedMarchandiseGroupID").change(function () {
            var MarchandiseGroupID = $("#SelectedMarchandiseGroupID :selected").val();
            if (MarchandiseGroupID == "" || MarchandiseGroupID == null) {
                $("#SelectedMerchandiseDepartmentID").attr("disabled", true);
                $("#SelectedMerchandiseCategoryID").attr("disabled", true);
                $("#SelectedMarchandiseSubCategoryID").attr("disabled", true);
                $("#SelectedMarchandiseBaseCatgoryID").attr("disabled", true);
            }
            else {
                $("#SelectedMerchandiseDepartmentID").attr("disabled", false);

            }
            $("#SelectedMerchandiseDepartmentID").val("");
            $("#SelectedMerchandiseCategoryID").val("");
            $("#SelectedMarchandiseSubCategoryID").val("");
            $("#SelectedMarchandiseBaseCatgoryID").val("");
            $("#ItemCategoryCode").val("");

        });
        $("#SelectedMerchandiseDepartmentID").change(function () {
            var MerchandiseDepartmentID = $("#SelectedMerchandiseDepartmentID :selected").val();
            if (MerchandiseDepartmentID == "" || MerchandiseDepartmentID == null) {
                $("#SelectedMerchandiseCategoryID").attr("disabled", true);
                $("#SelectedMarchandiseSubCategoryID").attr("disabled", true);
                $("#SelectedMarchandiseBaseCatgoryID").attr("disabled", true);
            }
            else {
                $("#SelectedMerchandiseCategoryID").attr("disabled", false);
            }
            $("#ItemCategoryCode").val("");
            $("#SelectedMerchandiseCategoryID").val("");
            $("#SelectedMarchandiseSubCategoryID").val("");
            $("#SelectedMarchandiseBaseCatgoryID").val("");


            // ajax call for next  merchandise Category drop down

            debugger;
            var selectedItem = $(this).val();
            var DepartmentCode = $("#SelectedMerchandiseDepartmentID").val();
            if (DepartmentCode == '') {
                notify('Please select Department.', 'warning');
                return false;
            }
            var $ddlExam = $("#SelectedMerchandiseCategoryID");
            var $ExamProgress = $("#states-loading-progress");
            $ExamProgress.show();
            if ($("#SelectedMerchandiseDepartmentID").val() != "") {
                $.ajax({
                    cache: false,
                    type: "POST",
                    url: "/GeneralItemCategoryMaster/GetCategoryIDByDepartmentID",

                    data: { "MerchandiseDepartmentID": selectedItem },
                    success: function (data) {
                        $ddlExam.html('');
                        $ddlExam.append('<option value="">--------Select Category-------</option>');
                        $.each(data, function (id, option) {

                            $ddlExam.append($('<option></option>').val(option.id).html(option.CategoryName + '(' + option.name + ')'));
                        });
                        $ExamProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Examinations.');
                        $ExamProgress.hide();
                    }
                });
            }

        });
        $("#SelectedMerchandiseCategoryID").change(function () {
            var MerchandiseCategoryID = $("#SelectedMerchandiseCategoryID :selected").val();
            if (MerchandiseCategoryID == "" || MerchandiseCategoryID == null) {
                $("#SelectedMarchandiseSubCategoryID").attr("disabled", true);
                $("#SelectedMarchandiseBaseCatgoryID").attr("disabled", true);
            }
            else {
                $("#SelectedMarchandiseSubCategoryID").attr("disabled", false);
            }
            $("#ItemCategoryCode").val("");
            $("#SelectedMarchandiseSubCategoryID").val("");
            $("#SelectedMarchandiseBaseCatgoryID").val("");

            // ajax call for next  merchandise Sub Category drop down

            debugger;
            var selectedItem = $(this).val();
            var CategoryCodeCode = $("#SelectedMerchandiseCategoryID").val();
            if (CategoryCodeCode == '') {
                notify('Please select Category.', 'warning');
                return false;
            }
            var $ddlExam = $("#SelectedMarchandiseSubCategoryID");
            var $ExamProgress = $("#states-loading-progress");
            $ExamProgress.show();
            if ($("#SelectedMerchandiseCategoryID").val() != "") {
                $.ajax({
                    cache: false,
                    type: "POST",
                    url: "/GeneralItemCategoryMaster/GetSubCategoryIDByCategoryID",

                    data: { "MerchandiseCategoryID": selectedItem },
                    success: function (data) {
                        $ddlExam.html('');
                        $ddlExam.append('<option value="">--------Select Sub category-------</option>');
                        $.each(data, function (id, option) {

                            $ddlExam.append($('<option></option>').val(option.id).html(option.SubCategoryName + '(' + option.name + ')'));
                        });
                        $ExamProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Examinations.');
                        $ExamProgress.hide();
                    }
                });
            }

        });
        $("#SelectedMarchandiseSubCategoryID").change(function () {
            var MarchandiseSubCategoryID = $("#SelectedMarchandiseSubCategoryID :selected").val();
            if (MarchandiseSubCategoryID == "" || MarchandiseSubCategoryID == null) {
                $("#SelectedMarchandiseBaseCatgoryID").attr("disabled", true);
            }
            else {
                $("#SelectedMarchandiseBaseCatgoryID").attr("disabled", false);
            }
            $("#ItemCategoryCode").val("");
            $("#SelectedMarchandiseBaseCatgoryID").val("");

            // ajax call for next  merchandise Sub Category drop down

            debugger;
            var selectedItem = $(this).val();
            var SubCategoryCodeCode = $("#SelectedMarchandiseSubCategoryID").val();
            if (SubCategoryCodeCode == '') {
                notify('Please select Category.', 'warning');
                return false;
            }
            var $ddlExam = $("#SelectedMarchandiseBaseCatgoryID");
            var $ExamProgress = $("#states-loading-progress");
            $ExamProgress.show();
            if ($("#SelectedMarchandiseSubCategoryID").val() != "") {
                $.ajax({
                    cache: false,
                    type: "POST",
                    url: "/GeneralItemCategoryMaster/GetBaseCategoryIDBySubCategoryID",

                    data: { "MerchandiseSubCategoryID": selectedItem },
                    success: function (data) {
                        $ddlExam.html('');
                        $ddlExam.append('<option value="">--------Select Base Category-------</option>');
                        $.each(data, function (id, option) {

                            $ddlExam.append($('<option></option>').val(option.id).html(option.BaseCategoryName + '(' + option.name + ')'));
                        });
                        $ExamProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Examinations.');
                        $ExamProgress.hide();
                    }
                });
            }

        });
        $("#SelectedMarchandiseBaseCatgoryID").change(function () {
            debugger;
            debugger;
            var MarchandiseGroupID = $("#SelectedMarchandiseGroupID").val();
            var MerchandiseDepartmentID = $("#SelectedMerchandiseDepartmentID :selected").val();
            var MerchandiseCategoryID = $("#SelectedMerchandiseCategoryID :selected").val();
            var MarchandiseSubCategoryID = $("#SelectedMarchandiseSubCategoryID :selected").val();
            var MarchandiseBaseCatgoryID = $("#SelectedMarchandiseBaseCatgoryID :selected").val();

            if (GeneralItemCategoryMaster.ActionName == "Edit") {
                if (MarchandiseGroupID == "" || MarchandiseGroupID == null || MarchandiseBaseCatgoryID == "" || MarchandiseBaseCatgoryID == null) {

                    $("#ItemCategoryCode").val("");

                }
                else {

                    var SelectedMarchandiseGroupID = $("#SelectedMarchandiseGroupID").val();
                    var SelectedMarchandiseGroupID1 = SelectedMarchandiseGroupID.split('~');

                    var SelectedMerchandiseDepartmentID = $("#SelectedMerchandiseDepartmentID :selected").val();
                    var SelectedMerchandiseDepartmentID1 = SelectedMerchandiseDepartmentID.split('~');

                    var SelectedMerchandiseCategoryID = $("#SelectedMerchandiseCategoryID :selected").val();
                    var SelectedMerchandiseCategoryID1 = SelectedMerchandiseCategoryID.split('~');

                    var SelectedMarchandiseSubCategoryID = $("#SelectedMarchandiseSubCategoryID :selected").val();
                    var SelectedMarchandiseSubCategoryID1 = SelectedMarchandiseSubCategoryID.split('~');

                    var SelectedMarchandiseBaseCatgoryID = $("#SelectedMarchandiseBaseCatgoryID :selected").val();
                    var SelectedMarchandiseBaseCatgoryID1 = SelectedMarchandiseBaseCatgoryID.split('~');


                    var ItemCategoryCode = SelectedMarchandiseGroupID1[1] + SelectedMerchandiseDepartmentID1[1] + SelectedMerchandiseCategoryID1[1] + SelectedMarchandiseSubCategoryID1[1] + SelectedMarchandiseBaseCatgoryID1[1];

                    $("#ItemCategoryCode").val(ItemCategoryCode)

                }
            }
            else {
                debugger;
                debugger;
                debugger;
                var abc1 = $("#SelectedMarchandiseBaseCatgoryID :selected").text();
                var abc2 = abc1.replace("(", "&");
                var abc3 = abc2.split('&');
                var abc4 = abc3[1].split(')');
                var abc5 = abc4[0].split(',');
                $("#ItemCategoryCode").val(abc5)
                $("#ItemCategoryDescription").val(abc3[0])

            }

        });

        $('#addMarchandiseGroup').click(function () {

            $('#DivGroup').show(true);
            $('#DivDepartment').hide(true);
            $('#DivCategory').hide(true);
            $('#DivSubCategory').hide(true);
            $('#DivBaseCategory').hide(true);

        });
        $('#addMarchandiseDepartment').click(function () {

            $('#DivGroup').hide(true);
            $('#DivDepartment').show(true);
            $('#DivCategory').hide(true);
            $('#DivSubCategory').hide(true);
            $('#DivBaseCategory').hide(true);

        });
        $('#addMarchandiseCategory').click(function () {

            $('#DivGroup').hide(true);
            $('#DivDepartment').hide(true);
            $('#DivCategory').show(true);
            $('#DivSubCategory').hide(true);
            $('#DivBaseCategory').hide(true);

        });
        $('#addMarchandiseSubCategory').click(function () {

            $('#DivGroup').hide(true);
            $('#DivDepartment').hide(true);
            $('#DivCategory').hide(true);
            $('#DivSubCategory').show(true);
            $('#DivBaseCategory').hide(true);

        });
        $('#addMarchandiseBaseCategory').click(function () {

            $('#DivGroup').hide(true);
            $('#DivDepartment').hide(true);
            $('#DivCategory').hide(true);
            $('#DivSubCategory').hide(true);
            $('#DivBaseCategory').show(true);

        });

        $("#ExcelFile").change(function () {

            ////  var filename = "OptionImageFile";
            //var MyFileType = $('#MyFile')[0].files[0].type;
            //var Extension = MyFileType.split('/');
            //MyFileFileName = $('#MyFile')[0].files[0].name;
            var file = $('#ExcelFile')[0].files[0];
            var MyFileFileName = file.name;
            var Extension = '.' + MyFileFileName.split('.').pop();
            if (MyFileFileName != "" && MyFileFileName != "undefined") {

                if (Extension == ".xls" || Extension == ".xlsx") {
                    var a = "";
                }
                else {
                    $("#displayErrorMessage p").text("Option excel only allows file types of xls and xlsx.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    $("#ExcelFile").replaceWith($("#ExcelFile").val('').clone(true));
                    return false;
                }
            }
            else {
                alert();
                $("#displayErrorMessage p").text("The selected file does not appear to be an excel file.").closest('div').fadeIn().closest('div').addClass('alert-' + "success");

                $("#ExcelFile").replaceWith($("#ExcelFile").val('').clone(true));

            }
        });


        InitAnimatedBorder();

        CloseAlert();

    },



    //LoadList method is used to load List page
    LoadList: function () {
        $.ajax(
         {
             cache: false,
             type: "POST",
             dataType: "html",
             url: '/GeneralItemCategoryMaster/List',
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
            url: '/GeneralItemCategoryMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallGeneralItemCategoryMaster: function () {
        var GeneralItemCategoryMasterData = null;
        if (GeneralItemCategoryMaster.ActionName == "Create") {
            $("#FormCreateGeneralItemCategoryMasterBMC").validate();
            if ($("#FormCreateGeneralItemCategoryMasterBMC").valid()) {
                GeneralItemCategoryMasterData = null;
                GeneralItemCategoryMasterData = GeneralItemCategoryMaster.GetGeneralItemCategoryMaster();
                ajaxRequest.makeRequest("/GeneralItemCategoryMaster/Create", "POST", GeneralItemCategoryMasterData, GeneralItemCategoryMaster.Success, "CreateGeneralItemCategoryMasterRecord");
            }
        }
        else if (GeneralItemCategoryMaster.ActionName == "CreateBMC") {
            //$("#FormCreateGeneralItemCategoryMasterBMC").validate();
            //if ($("#FormCreateGeneralItemCategoryMasterBMC").valid()) {
            GeneralItemCategoryMasterData = null;
            GeneralItemCategoryMasterData = GeneralItemCategoryMaster.GetGeneralItemCategoryMaster();
            ajaxRequest.makeRequest("/GeneralItemMarchandiseGroup/Create", "POST", GeneralItemCategoryMasterData, GeneralItemCategoryMaster.CategorySuccess, "CreateGeneralItemCategoryMasterInsertGroupRecord");
            //}
        }
        else if (GeneralItemCategoryMaster.ActionName == "CreateBMCDepartment") {
            //$("#FormCreateGeneralItemCategoryMasterBMC").validate();
            //if ($("#FormCreateGeneralItemCategoryMasterBMC").valid()) {
            GeneralItemCategoryMasterData = null;
            GeneralItemCategoryMasterData = GeneralItemCategoryMaster.GetGeneralItemCategoryMaster();
            ajaxRequest.makeRequest("/GeneralItemMerchantiseDepartment/Create", "POST", GeneralItemCategoryMasterData, GeneralItemCategoryMaster.BMCSuccess, "CreateGeneralItemCategoryMasterInsertDepartmentRecord");
            // }
        }
        else if (GeneralItemCategoryMaster.ActionName == "CreateBMCCategory") {
            //$("#FormCreateGeneralItemCategoryMasterBMC").validate();
            //if ($("#FormCreateGeneralItemCategoryMasterBMC").valid()) {
            GeneralItemCategoryMasterData = null;
            GeneralItemCategoryMasterData = GeneralItemCategoryMaster.GetGeneralItemCategoryMaster();
            ajaxRequest.makeRequest("/GeneralItemMerchantiseCategory/Create", "POST", GeneralItemCategoryMasterData, GeneralItemCategoryMaster.BMCSuccess, "CreateGeneralItemCategoryMasterInsertCategoryRecord");
            // }
        }
        else if (GeneralItemCategoryMaster.ActionName == "CreateBMCSUbCategory") {
            //$("#FormCreateGeneralItemCategoryMasterBMC").validate();
            //if ($("#FormCreateGeneralItemCategoryMasterBMC").valid()) {
            GeneralItemCategoryMasterData = null;
            GeneralItemCategoryMasterData = GeneralItemCategoryMaster.GetGeneralItemCategoryMaster();
            ajaxRequest.makeRequest("/GeneralItemMarchandiseSubCategory/Create", "POST", GeneralItemCategoryMasterData, GeneralItemCategoryMaster.BMCSuccess, "CreateGeneralItemCategoryMasterInsertSubCategoryRecord");
            //}
        }
        else if (GeneralItemCategoryMaster.ActionName == "CreateBMCBaseCategory") {
            //$("#FormCreateGeneralItemCategoryMasterBMC").validate();
            //if ($("#FormCreateGeneralItemCategoryMasterBMC").valid()) {
            GeneralItemCategoryMasterData = null;
            GeneralItemCategoryMasterData = GeneralItemCategoryMaster.GetGeneralItemCategoryMaster();
            ajaxRequest.makeRequest("/GeneralItemMarchandiseBaseCategory/Create", "POST", GeneralItemCategoryMasterData, GeneralItemCategoryMaster.BMCSuccess, "CreateGeneralItemCategoryMasterInsertBaseCategoryRecord");
            //}
        }
        else if (GeneralItemCategoryMaster.ActionName == "Edit") {
            $("#FormEditGeneralItemCategoryMaster").validate();
            if ($("#FormEditGeneralItemCategoryMaster").valid()) {
                GeneralItemCategoryMasterData = null;
                GeneralItemCategoryMasterData = GeneralItemCategoryMaster.GetGeneralItemCategoryMaster();
                ajaxRequest.makeRequest("/GeneralItemCategoryMaster/Edit", "POST", GeneralItemCategoryMasterData, GeneralItemCategoryMaster.Success, "EditGeneralItemCategoryMasterRecord");
            }
        }
        else if (GeneralItemCategoryMaster.ActionName == "EditBMC") {
            $("#FormEditGeneralItemCategoryMaster").validate();
            if ($("#FormEditGeneralItemCategoryMaster").valid()) {
                GeneralItemCategoryMasterData = null;
                GeneralItemCategoryMasterData = GeneralItemCategoryMaster.GetGeneralItemCategoryMaster();
                ajaxRequest.makeRequest("/GeneralItemCategoryMaster/EditBMC", "POST", GeneralItemCategoryMasterData, GeneralItemCategoryMaster.Success, "EditBMCGeneralItemCategoryMasterRecord");
            }
        }
        
        else if (VendorMaster.ActionName == "UploadExcel") {

            $("#FormCreateGeneralItemCategoryMasterExcel").validate();
            if ($("#FormCreateGeneralItemCategoryMasterExcel").valid()) {
                VendorMasterData = null;
                VendorMasterData = VendorMaster.GetCategoryDetails();
                ajaxRequest.makeRequest("/GeneralItemCategoryMaster/UploadExcel", "POST", VendorMasterData, VendorMaster.SaveSuccess, "CreateGeneralItemCategoryMasterRecordExcel");
            }
        }
        else if (GeneralItemCategoryMaster.ActionName == "Delete") {
            GeneralItemCategoryMasterData = null;
            //$("#FormCreateGeneralItemCategoryMaster").validate();
            GeneralItemCategoryMasterData = GeneralItemCategoryMaster.GetGeneralItemCategoryMaster();
            ajaxRequest.makeRequest("/GeneralItemCategoryMaster/Delete", "POST", GeneralItemCategoryMasterData, GeneralItemCategoryMaster.Success);

        }
    },

    GetCategoryDetails: function () {
        var Data = {
        };
        if (VendorMaster.ActionName == "UploadExcel") {


            var data = new FormData();
            var files = $("#ExcelFile").get(0).files;
            if (files.length > 0) {
                data.append("ExcelFile", files[0]);
                $.ajax({
                    url: "/GeneralItemCategoryMaster/UploadExcelFile",
                    type: "POST",
                    processData: false,
                    contentType: false,
                    data: data,               //Q => Question
                    dataType: 'json',
                    success: function (data) {
                        //  CRMCallEnquiryDetails.XMLstringParam = $.parseXML(data);
                        // Data.XMLstring = data;
                        //  alert(CRMCallEnquiryDetails.XMLstring);
                    },
                    error: function (er) {
                        alert(er.error);

                    }

                });

            }

            // Data.XMLstring = CRMCallEnquiryDetails.XMLstringParam;
            //  alert(CRMCallEnquiryDetails.XMLstringParam);
        }

        return Data;
    },
    //Get properties data from the Create, Update and Delete page
    GetGeneralItemCategoryMaster: function () {

        debugger;
        var Data = {
        };
        if (GeneralItemCategoryMaster.ActionName == "Edit") {
            debugger;
            // Data.GeneralItemCategoryMasterID = $('input[name=GeneralItemCategoryMasterID]').val();
            Data.ID = $('input[name=ID]').val();
            Data.ItemCategoryDescription = $('#ItemCategoryDescription').val();
            Data.ItemCategoryCode = $('#ItemCategoryCode').val();

            var SelectedMarchandiseGroupID = $("#SelectedMarchandiseGroupID :selected").val().split("~");
            Data.MarchandiseGroupID = SelectedMarchandiseGroupID[0];
            var SelectedMerchandiseDepartmentID = $("#SelectedMerchandiseDepartmentID :selected").val().split("~");
            Data.MerchandiseDepartmentID = SelectedMerchandiseDepartmentID[0];
            var SelectedMerchandiseCategoryID = $("#SelectedMerchandiseCategoryID :selected").val().split("~");
            Data.MerchandiseCategoryID = SelectedMerchandiseCategoryID[0];
            var SelectedMarchandiseSubCategoryID = $("#SelectedMarchandiseSubCategoryID :selected").val().split("~");
            Data.MarchandiseSubCategoryID = SelectedMarchandiseSubCategoryID[0];
            var SelectedMarchandiseBaseCatgoryID = $("#SelectedMarchandiseBaseCatgoryID :selected").val().split("~");
            Data.MarchandiseBaseCatgoryID = SelectedMarchandiseBaseCatgoryID[0];
        }
        else if (GeneralItemCategoryMaster.ActionName == "Delete") {
            Data.ID = $('input[name=GeneralItemCategoryMasterID]').val();

        }
        else if (GeneralItemCategoryMaster.ActionName == "Create" || GeneralItemCategoryMaster.ActionName == "CreateBMC" || GeneralItemCategoryMaster.ActionName == "CreateBMCDepartment" || GeneralItemCategoryMaster.ActionName == "CreateBMCCategory" || GeneralItemCategoryMaster.ActionName == "CreateBMCSUbCategory" || GeneralItemCategoryMaster.ActionName == "CreateBMCBaseCategory" || GeneralItemCategoryMaster.ActionName == "EditBMC") {
            debugger;
            //Data.ID = $('input[name=GeneralItemCategoryMasterID]').val();
            Data.GroupDescription = $('#GroupDescription').val();
            Data.MarchandiseGroupCode = $('#MarchandiseGroupCode').val();
            Data.MerchantiseDepartmentName = $('#MerchantiseDepartmentName').val();
            Data.MerchantiseDepartmentCode = $('#MerchantiseDepartmentCode').val();
            Data.MerchantiseCategoryName = $('#MerchantiseCategoryName').val();
            Data.MerchantiseCategoryCode = $('#MerchantiseCategoryCode').val();
            Data.MarchantiseSubCategoryName = $('#MarchantiseSubCategoryName').val();
            Data.MarchantiseSubCategoryCode = $('#MerchantiseSubCategoryCode').val();
            Data.MarchandiseBaseCategoryName = $('#MarchandiseBaseCategoryName').val();
            Data.MarchandiseBaseCategoryCode = $('#MarchandiseBaseCatgoryCode').val();
           
            Data.ItemCategoryDescription = $('#ItemCategoryDescription').val();
            Data.ItemCategoryCode = $('#ItemCategoryCode').val();
            Data.MarchandiseGroupID = $('#SelectedMarchandiseGroupID').val();
            Data.MerchandiseDepartmentID = $('#SelectedMerchandiseDepartmentID').val();
            Data.MerchandiseCategoryID = $('#SelectedMerchandiseCategoryID').val();
            Data.MarchandiseSubCategoryID = $('#SelectedMarchandiseSubCategoryID').val();
            Data.MarchandiseBaseCatgoryID = $('#SelectedMarchandiseBaseCatgoryID').val();
            Data.ID = $('input[name=ID]').val();
            debugger;
            Data.IsConsumable = $('input[id=IsConsumable]:checked').val() ? true : false;
            Data.IsMachine = $('input[id=IsMachine]:checked').val() ? true : false;
            Data.IsToner = $('input[id=IsToner]:checked').val() ? true : false;
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()

            GeneralItemCategoryMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

    CategorySuccess: function (data) {
        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            //$.magnificPopup.close()
            $("#selectedGroupDescription").val("");
            $("#SelectedMerchandiseDepartmentID").val("");
            $("#SelectedMerchandiseCategoryID").val("");
            $("#SelectedMarchandiseSubCategoryID").val("");
            $("#SelectedMarchandiseBaseCatgoryID").val("");
            $('#DivGroup').hide(true);
            $('#DivDepartment').hide(true);
            $('#DivCategory').hide(true);
            $('#DivSubCategory').hide(true);
            $('#DivBaseCategory').hide(true);
            //GeneralItemCategoryMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

    BMCSuccess: function (data) {
        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            if (GeneralItemCategoryMaster.ActionName == "CreateBMCDepartment") {
                //$.magnificPopup.close()
                $("#SelectedMerchandiseCategoryID").val("");
                $("#SelectedMarchandiseSubCategoryID").val("");
                $("#SelectedMarchandiseBaseCatgoryID").val("");
                $('#DivGroup').hide(true);
                $('#DivDepartment').hide(true);
                $('#DivCategory').hide(true);
                $('#DivSubCategory').hide(true);
                $('#DivBaseCategory').hide(true);
                $('#GroupDescription').val("");
                $('#MarchandiseGroupCode').val("");
                $('#MerchantiseDepartmentName').val("");
                $('#MerchantiseDepartmentCode').val("");
                $('#MerchantiseCategoryName').val("");
                $('#MerchantiseCategoryCode').val("");
                $('#MarchantiseSubCategoryName').val("");
                $('#MerchantiseSubCategoryCode').val("");
                $('#MarchandiseBaseCategoryName').val("");
                $('#MarchandiseBaseCatgoryCode').val("");
                var GroupCode = $("#GroupCode").val();
                $.ajax({
                    cache: false,
                    type: "POST",
                    dataType: "json",
                    data: { "GroupCode": GroupCode },
                    url: '/GeneralItemCategoryMaster/GetDepartmentIDByGroupCode',
                    success: function (data) {
                        var $ddlExam = $("#SelectedMerchandiseDepartmentID");
                        $ddlExam.html('');
                        $ddlExam.append('<option value="">--------Select Department-------</option>');
                        $.each(data, function (id, option) {

                            $ddlExam.append($('<option></option>').val(option.id).html(option.DepartmentName + '(' + option.name + ')'));
                        });
                    }
                });
                $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
            }
            else if (GeneralItemCategoryMaster.ActionName == "CreateBMCCategory") {
                //$.magnificPopup.close()
                $("#SelectedMarchandiseSubCategoryID").val("");
                $("#SelectedMarchandiseBaseCatgoryID").val("");
                $('#DivGroup').hide(true);
                $('#DivDepartment').hide(true);
                $('#DivCategory').hide(true);
                $('#DivSubCategory').hide(true);
                $('#DivBaseCategory').hide(true);
                var SelectedMerchandiseDepartmentID = $("#SelectedMerchandiseDepartmentID").val();
                $.ajax({
                    cache: false,
                    type: "POST",
                    dataType: "json",
                    data: { "MerchandiseDepartmentID": SelectedMerchandiseDepartmentID },
                    url: "/GeneralItemCategoryMaster/GetCategoryIDByDepartmentID",
                    success: function (data) {
                        var $ddlExam = $("#SelectedMerchandiseCategoryID");
                        $ddlExam.html('');
                        $ddlExam.append('<option value="">--------Select Category-------</option>');
                        $.each(data, function (id, option) {

                            $ddlExam.append($('<option></option>').val(option.id).html(option.CategoryName + '(' + option.name + ')'));
                        });
                    }
                });
                $('#GroupDescription').val("");
                $('#MarchandiseGroupCode').val("");
                $('#MerchantiseDepartmentName').val("");
                $('#MerchantiseDepartmentCode').val("");
                $('#MerchantiseCategoryName').val("");
                $('#MerchantiseCategoryCode').val("");
                $('#MarchantiseSubCategoryName').val("");
                $('#MerchantiseSubCategoryCode').val("");
                $('#MarchandiseBaseCategoryName').val("");
                $('#MarchandiseBaseCatgoryCode').val("");

                //GeneralItemCategoryMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
                $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
            }
            else if (GeneralItemCategoryMaster.ActionName == "CreateBMCSUbCategory") {
                //$.magnificPopup.close()
                $("#SelectedMarchandiseBaseCatgoryID").val("");
                $('#DivGroup').hide(true);
                $('#DivDepartment').hide(true);
                $('#DivCategory').hide(true);
                $('#DivSubCategory').hide(true);
                $('#DivBaseCategory').hide(true);
                var SelectedMerchandiseCategoryID = $("#SelectedMerchandiseCategoryID").val();
                $.ajax({
                    cache: false,
                    type: "POST",
                    dataType: "json",
                    data: { "MerchandiseCategoryID": SelectedMerchandiseCategoryID },
                    url: "/GeneralItemCategoryMaster/GetSubCategoryIDByCategoryID",
                    success: function (data) {
                        var $ddlExam = $("#SelectedMarchandiseSubCategoryID");
                        $ddlExam.html('');
                        $ddlExam.append('<option value="">--------Select Sub Category-------</option>');
                        $.each(data, function (id, option) {

                            $ddlExam.append($('<option></option>').val(option.id).html(option.SubCategoryName + '(' + option.name + ')'));
                        });
                    }
                });
                $('#GroupDescription').val("");
                $('#MarchandiseGroupCode').val("");
                $('#MerchantiseDepartmentName').val("");
                $('#MerchantiseDepartmentCode').val("");
                $('#MerchantiseCategoryName').val("");
                $('#MerchantiseCategoryCode').val("");
                $('#MarchantiseSubCategoryName').val("");
                $('#MerchantiseSubCategoryCode').val("");
                $('#MarchandiseBaseCategoryName').val("");
                $('#MarchandiseBaseCatgoryCode').val("");

                //GeneralItemCategoryMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
                $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
            }
            else if (GeneralItemCategoryMaster.ActionName == "CreateBMCBaseCategory") {
                //$.magnificPopup.close()
                $('#DivGroup').hide(true);
                $('#DivDepartment').hide(true);
                $('#DivCategory').hide(true);
                $('#DivSubCategory').hide(true);
                $('#DivBaseCategory').hide(true);
                var SelectedMerchandiseDepartmentID = $("#SelectedMarchandiseSubCategoryID").val();
                $.ajax({
                    cache: false,
                    type: "POST",
                    dataType: "json",
                    data: { "MerchandiseSubCategoryID": SelectedMerchandiseDepartmentID },
                    url: "/GeneralItemCategoryMaster/GetBaseCategoryIDBySubCategoryID",
                    success: function (data) {
                        var $ddlExam = $("#SelectedMarchandiseBaseCatgoryID");
                        $ddlExam.html('');
                        $ddlExam.append('<option value="">--------Select Base Category-------</option>');
                        $.each(data, function (id, option) {

                            $ddlExam.append($('<option></option>').val(option.id).html(option.BaseCategoryName + '(' + option.name + ')'));
                        });
                    }
                });
                $('#GroupDescription').val("");
                $('#MarchandiseGroupCode').val("");
                $('#MerchantiseDepartmentName').val("");
                $('#MerchantiseDepartmentCode').val("");
                $('#MerchantiseCategoryName').val("");
                $('#MerchantiseCategoryCode').val("");
                $('#MarchantiseSubCategoryName').val("");
                $('#MerchantiseSubCategoryCode').val("");
                $('#MarchandiseBaseCategoryName').val("");
                $('#MarchandiseBaseCatgoryCode').val("");

                //GeneralItemCategoryMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
                $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
            }
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },


};

