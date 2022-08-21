//this class contain methods related to nationality functionality
var AdminSnPosts = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        AdminSnPosts.constructor();
        //generalCountryMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {
        $("#SelectedCentreCode").focus();

        $("#SelectedCentreCode").change(function () {

            var selectedItem = $(this).val();
            var $ddlDepartments = $("#SelectedDepartmentID");
            var $departmentProgress = $("#states-loading-progress");
            $departmentProgress.show();
            if ($("#SelectedCentreCode").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/AdminSnPosts/GetDepartmentByCentreCode",
                    //url: "@(Url.RouteUrl("GetDepartmentByCentreCode"))",
                    data: { "SelectedCentreCode": selectedItem },
                    success: function (data) {
                        $ddlDepartments.html('');
                        $ddlDepartments.append('<option value="">--Select Department-</option>');
                        $.each(data, function (id, option) {

                            $ddlDepartments.append($('<option></option>').val(option.id).html(option.name));
                        });
                        $departmentProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Departments.');
                        $departmentProgress.hide();
                    }
                });
                $('#btnCreate').hide();
            }
            else {
                $('#myDataTable tbody').empty();
                $('#SelectedDepartmentID').find('option').remove().end().append('<option value>---Select Department---</option>');
                $('#btnCreate').hide();
            }
        });

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#DesignationIdWithName').focus();
            //var dt = new Date();
            // document.write("getYear() : " + dt.getYear());
            $('#DesignationIdWithName').val('');
            $('#Posttype').val(0);
            $('#Designationtype').val(0);
            $('#NoOfPosts').val('0');
            return false;
        });

        $('#SelectedDepartmentID').on("change", function () {

            //var valuCentreCode = $('#SelectedCentreCode :selected').val();
            //var valuDepartmentID = $('#SelectedDepartmentID').val();
            //AdminSnPosts.LoadListByCentreCodeAndDepartmentID(valuCentreCode, valuDepartmentID);
            //$('#btnCreate').show();
        });

        $("#btnShowList").unbind("click").on("click", function () {

            var valuCentreCode = $('#SelectedCentreCode :selected').val();
            var valuDepartmentID = $('#SelectedDepartmentID :selected').val();
            if (valuCentreCode != "" && valuDepartmentID != "") {
                AdminSnPosts.LoadListByCentreCodeAndDepartmentID(valuCentreCode, valuDepartmentID);
            }
            else if ($("#SelectedCentreCode").val() == '') {
                notify("Please Select Centre.", "warning");
                return false;
            }
            if ($("#SelectedDepartmentID").val() == '') {
                notify("Please Select Department.", "warning");
                return false;
            }
        });

        // Create new record
        $('#CreateAdminSnPostsRecord').on("click", function () {
            if ($("#SelectedCentreCode").val() == '') {
                $("#displayErrorMessage p").text("Please Select Centre.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            if ($("#SelectedDepartmentID").val() == '') {
                $("#displayErrorMessage p").text("Please Select Department.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            AdminSnPosts.ActionName = "Create";
            AdminSnPosts.AjaxCallAdminSnPosts();
        });

        $('#EditAdminSnPostsRecord').on("click", function () {
            //alert();
            //debugger;
            AdminSnPosts.ActionName = "Edit";
            AdminSnPosts.AjaxCallAdminSnPosts();
        });

        $('#DeleteAdminSnPostsRecord').on("click", function () {

            AdminSnPosts.ActionName = "Delete";
            AdminSnPosts.AjaxCallAdminSnPosts();
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

        $('#NoOfPosts').on("keydown", function (e) {
            AERPValidation.AllowNumbersOnly(e);
            AERPValidation.NotAllowSpaces(e);
        });


    },
    //LoadList method is used to load List page
    LoadList: function () {
        $.ajax(
         {
             cache: false,
             type: "POST",

             dataType: "html",
             url: '/AdminSnPosts/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
                 $('#btnCreate').hide();
             }
         });
        $('#btnCreate').hide();
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {

        var SelectedCentreCode = $('#SelectedCentreCode :selected').val();
        var SelectedDepartmentID = $('#SelectedDepartmentID :selected').val();
        $.ajax(
        {
            cache: false,
            type: "POST",

            dataType: "html",
            data: { "centerCode": SelectedCentreCode, "departmentID": SelectedDepartmentID, "actionMode": actionMode },
            url: '/AdminSnPosts/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                $('#DivCreateNew').show(true);
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
                notify(message, colorCode);
            }
        });
    },
    //ReloadList method is used to load List page
    LoadListByCentreCodeAndDepartmentID: function (SelectedCentreCode, SelectedDepartmentID) {

        var selectedText = $('#SelectedDepartmentID').text();
        var selectedVal = $('#SelectedDepartmentID').val();
        $.ajax(
          {
              cache: false,
              type: "POST",
              data: { centerCode: SelectedCentreCode, departmentID: selectedVal },

              dataType: "html",
              url: '/AdminSnPosts/List',
              success: function (result) {
                  //Rebind Grid Data                
                  $('#ListViewModel').html(result);
                  $('#DivCreateNew').show(true);
              }
          });
    },
    //Fire ajax call to insert update and delete record
    AjaxCallAdminSnPosts: function () {
        var AdminSnPostsData = null;
        if (AdminSnPosts.ActionName == "Create") {
            $("#FormCreateAdminSnPosts").validate();
            if ($("#FormCreateAdminSnPosts").valid()) {
                AdminSnPostsData = null;
                AdminSnPostsData = AdminSnPosts.GetAdminSnPosts();
                ajaxRequest.makeRequest("/AdminSnPosts/Create", "POST", AdminSnPostsData, AdminSnPosts.Success);

            }
        }
        else if (AdminSnPosts.ActionName == "Edit") {
            //debugger;
            $("#FormEditAdminSnPosts").validate();
            if ($("#FormEditAdminSnPosts").valid()) {
                AdminSnPostsData = null;
                AdminSnPostsData = AdminSnPosts.GetAdminSnPosts();
                ajaxRequest.makeRequest("/AdminSnPosts/Edit", "POST", AdminSnPostsData, AdminSnPosts.Success);
            }
        }
        else if (AdminSnPosts.ActionName == "Delete") {
            AdminSnPostsData = null;
            //$("#FormCreateAdminSnPosts").validate();
            AdminSnPostsData = AdminSnPosts.GetAdminSnPosts();
            ajaxRequest.makeRequest("/AdminSnPosts/Delete", "POST", AdminSnPostsData, AdminSnPosts.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetAdminSnPosts: function () {
        
        var Data = {
        };
        if (AdminSnPosts.ActionName == "Create") {
            Data.ID = $('input[name=ID]').val();
            Data.SelectedCentreCode = $('input[name=SelectedCentreCode]').val();
            Data.SelectedDepartmentID = $('input[name=SelectedDepartmentID]').val();
            Data.SelectedCentreName = $('input[name=SelectedCentreName]').val();
            Data.SelectedDepartmentName = $('input[name=SelectedDepartmentName]').val();
            Data.DesignationIdWithName = $('#DesignationIdWithName').val();
            Data.Posttype = $('#Posttype').val();
            Data.Designationtype = $('#Designationtype').val();
            Data.CentreCodeWithName = $('input[name=SelectedCentreCode]').val();
            Data.DepartmentIdWithName = $('input[name=DepartmentID]').val();
            var splitedCentreCode = $('input[name=CentreCode]').val().split(':');
            Data.CentreCode = splitedCentreCode[0];
            Data.CentreCodewithDeptID = $('#CentreCodewithDeptID').val();
            Data.NoOfPosts = $('#NoOfPosts').val();
        }
        else if (AdminSnPosts.ActionName == "Edit") {
            //Data.ID = $('input[name=ID]').val();
            //Data.IsActive = $('input[name=IsActive]:checked').val() ? true : false;
            //alert($('input[id=IsActive]:checked').val());
            //alert($("#IsActive").val());
            Data.ID = $('input[id=ID]').val();
            //Data.IsActive = $('input[id=IsActive]:checked').val() ? true : false;
            Data.IsActive = $("#IsActive").val();
            
        }
        else if (AdminSnPosts.ActionName == "Delete") {
            Data.ID = $('input[name=ID]').val();
            Data.CentreCodeWithName = $('input[name=SelectedCentreCode]').val();
            Data.DepartmentIdWithName = $('input[name=SelectedDepartmentID]').val();
        }
        return Data;
    },
    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (data != null) {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            AdminSnPosts.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            AdminSnPosts.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    


};

