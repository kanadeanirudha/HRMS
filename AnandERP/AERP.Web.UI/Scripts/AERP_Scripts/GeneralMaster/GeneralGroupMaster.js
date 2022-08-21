//this class contain methods related to nationality functionality
var GeneralGroupMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        GeneralGroupMaster.constructor();
        //GeneralGroupMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {
        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#RegionID').focus();
            $('#RegionID').val('');
            $('#GroupDependentObject').val(" ");
            $('#JobProfileID').val(" ");
        });

        $("#CentreCode").change(function () {
            
            var selectedItem = $(this).val();
            var $ddlDepartment = $("#DepartmentID");
            var $DepartmentProgress = $("#states-loading-progress");
            $DepartmentProgress.show();
            if ($("#CentreCode").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/GeneralGroupMaster/GetDepartmentByCentreCode",

                    data: { "SelectedCentreCode": selectedItem },
                    success: function (data) {
                        $ddlDepartment.html('');
                        $ddlDepartment.append('<option value="">--------Select Department-------</option>');
                        $.each(data, function (id, option) {

                            $ddlDepartment.append($('<option></option>').val(option.id).html(option.name));
                        });
                        $DepartmentProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve departments.');
                        $DepartmentProgress.hide();
                    }
                });
            }
        });

        // Create new record
        $('#CreateGeneralGroupMasterRecord').on("click", function () {
            GeneralGroupMaster.ActionName = "Create";
            GeneralGroupMaster.AjaxCallGeneralGroupMaster();
        });

        $('#EditGeneralGroupMasterRecord').on("click", function () {
            GeneralGroupMaster.ActionName = "Edit";
            GeneralGroupMaster.AjaxCallGeneralGroupMaster();
        });

        $('#DeleteGeneralGroupMasterRecord').on("click", function () {
            GeneralGroupMaster.ActionName = "Delete";
            GeneralGroupMaster.AjaxCallGeneralGroupMaster();
        });

        $('#CreateEmployeeGroupDetailsRecord').on("click", function () {
            
           
            if ($("#mode").val() == "Create") {
                GeneralGroupMaster.ActionName = "CreateGroupDetails";
            }
            else {
                GeneralGroupMaster.ActionName = "EditGroupDetails";
            }
            GeneralGroupMaster.AjaxCallGeneralGroupMaster();
        });

        $('#Description').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        //$("#UserSearch").keyup(function () {
        //    oTable = $("#myDataTable").dataTable();
        //    oTable.fnFilter(this.value);
        //});

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

        $("#CreateNewDepartment").click(function () {
            var DependentObjectID = $('input[name=ID]').val();
          
            $.ajax(
                 {
                     cache: false,
                     type: "GET",
                     data: { ID: DependentObjectID, EmployeeGroupDetailsID: 0, DependentObjectID: 0, mode: 'Create' },
                     dataType: "html",
                     url: '/GeneralGroupMaster/DropdownList',
                     success: function (data) {
                         //Rebind Grid Data
                         $('#EditDependentObject').html('');
                         $('#EditDependentObject').html(data);
                         $('#EditDependentObject').show(true);
                         $('#EditGroupMaster').hide(true);
                     }
                 });
        });

        $("#CreateNewDesignation").click(function () {
            
            var DependentObjectID = $('input[name=ID]').val();
            $.ajax(
                 {
                     cache: false,
                     type: "GET",
                     // data: { ID: 0, GroupMasterID: DependentObjectID },
                     data: { ID: DependentObjectID, EmployeeGroupDetailsID: 0, DependentObjectID: 0, mode: 'Create' },
                     dataType: "html",
                     url: '/GeneralGroupMaster/DropdownList',
                     success: function (data) {
                         //Rebind Grid Data
                         $('#EditDependentObject').html('');
                         $('#EditDependentObject').html(data);
                         $('#EditDependentObject').show(true);
                         $('#EditGroupMaster').hide(true);
                     }
                 });
      });

        $("#CreateNewPayScale").click(function () {
            var DependentObjectID = $('input[name=ID]').val();
            $.ajax(
                 {
                     cache: false,
                     type: "GET",
                     data: { ID: 0, GroupMasterID: DependentObjectID, mode:'Create' },
                     dataType: "html",
                     url: '/GeneralGroupMaster/DropdownList',
                     success: function (data) {
                         //Rebind Grid Data
                         $('#EditDependentObject').html('');
                         $('#EditDependentObject').html(data);
                         $('#EditDependentObject').show(true);
                         $('#EditGroupMaster').hide(true);
                     }
                 });
        });

        $("#EditGroup").click(function () {
            $('#EditGroupMaster').show(true);
            $('#EditDependentObject').hide(true);
            $('#EditDependentObject').hide(true);
            $('#EditDependentObject').hide(true);
        });


    },
    //LoadList method is used to load List page
    LoadList: function () {
        $.ajax(
         {
             cache: false,
             type: "POST",

             dataType: "html",
             url: '/GeneralGroupMaster/List',
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
            url: '/GeneralGroupMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', colorCode);
                notify(message, "success");
            }
        });
    },
    //ReloadList method is used to load List page
    ReloadGroupDetailsList: function (message, colorCode, actionMode) {
        
        var iID = $('input[name=ID]').val();
        $.ajax(
        {
            cache: false,
            type: "GET",
            //data: { ID: ID, EmployeeGroupDetailsID: 0, DependentObjectID: 0, mode: 'Edit' },
            data: { ID: iID },
            dataType: "html",
            url: '/GeneralGroupMaster/CreateGroupDetails',
            success: function (data) {
                //Rebind Grid Data
              //  $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#SuccessMessageGroupDetails').html(message);
                //$('#SuccessMessageGroupDetails').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', colorCode);
                notify(message,"success");
            }
        });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallGeneralGroupMaster: function () {
        var GeneralGroupMasterData = null;
        if (GeneralGroupMaster.ActionName == "Create") {
            $("#FormCreateGeneralGroupMaster").validate();
            if ($("#FormCreateGeneralGroupMaster").valid()) {
                GeneralGroupMasterData = null;
                GeneralGroupMasterData = GeneralGroupMaster.GetGeneralGroupMaster();
                ajaxRequest.makeRequest("/GeneralGroupMaster/Create", "POST", GeneralGroupMasterData, GeneralGroupMaster.Success);
            }
        }
        else if (GeneralGroupMaster.ActionName == "Edit") {
            $("#FormEditGeneralGroupMaster").validate();
            if ($("#FormEditGeneralGroupMaster").valid()) {
                GeneralGroupMasterData = null;
                GeneralGroupMasterData = GeneralGroupMaster.GetGeneralGroupMaster();
                ajaxRequest.makeRequest("/GeneralGroupMaster/Edit", "POST", GeneralGroupMasterData, GeneralGroupMaster.Success);
            }
        }
        else if (GeneralGroupMaster.ActionName == "Delete") {
            GeneralGroupMasterData = null;
            $("#FormDeleteGeneralGroupMaster").validate();
            GeneralGroupMasterData = GeneralGroupMaster.GetGeneralGroupMaster();
            ajaxRequest.makeRequest("/GeneralGroupMaster/Delete", "POST", GeneralGroupMasterData, GeneralGroupMaster.Success);

        }
        else if (GeneralGroupMaster.ActionName == "CreateGroupDetails") {
            GeneralGroupMasterData = null;
            $("#FormCreateEmployeeGroupDetails").validate();
            GeneralGroupMasterData = GeneralGroupMaster.GetGeneralGroupMaster();
            ajaxRequest.makeRequest("/GeneralGroupMaster/CreateGroupDetails", "POST", GeneralGroupMasterData, GeneralGroupMaster.SuccessGroupDetails);
        }
        else if (GeneralGroupMaster.ActionName == "EditGroupDetails") {
            GeneralGroupMasterData = null;
            $("#FormCreateEmployeeGroupDetails").validate();
            GeneralGroupMasterData = GeneralGroupMaster.GetGeneralGroupMaster();
            ajaxRequest.makeRequest("/GeneralGroupMaster/EditGroupDetails", "POST", GeneralGroupMasterData, GeneralGroupMaster.SuccessGroupDetails);
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetGeneralGroupMaster: function () {
        var Data = {
        };
        if (GeneralGroupMaster.ActionName == "Create" || GeneralGroupMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.JobProfileID = $('#JobProfileID').val();
            Data.GroupName = $('#GroupName').val();
            Data.GroupDependentObject = $('#GroupDependentObject').val();

        }
        else if (GeneralGroupMaster.ActionName == "CreateGroupDetails") {
            
            Data.ID = $('#ID').val();
            Data.GroupName = $('input[name=GroupName]').val();
            Data.GroupDependentObject = $('input[name=GroupDependentObject]').val();
            if (Data.GroupDependentObject == "Department") {
                Data.DependentObjectID = $('#DepartmentID').val();
            }
            if (Data.GroupDependentObject == "Designation") {
                Data.DependentObjectID = $('#DependentObjectID').val();
            }
            if (Data.GroupDependentObject == "PayScale") {
                Data.DependentObjectID = $('#DependentObjectID').val();
            }
        }
        else if (GeneralGroupMaster.ActionName == "EditGroupDetails") {
            
         
            Data.ID = $('input[name=ID]').val();
            Data.EmployeeGroupDetailsID = $('input[name=EmployeeGroupDetailsID]').val();
            Data.GroupDependentObject = $('input[name=GroupDependentObject]').val();
            if (Data.GroupDependentObject == "Department") {
                Data.DependentObjectID = $('#DepartmentID').val();
            }
            if (Data.GroupDependentObject == "Designation") {
                Data.DependentObjectID = $('#DependentObjectID').val();
            }
            if (Data.GroupDependentObject == "PayScale") {
                Data.DependentObjectID = $('#DependentObjectID').val();
            }
            Data.IsActive = $('#IsAct:checked').val() ? true : false;
            Data.GroupName = $('input[name=GroupName]').val();
        }     
        return Data;
    },


    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (data != null) {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            GeneralGroupMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            GeneralGroupMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },

    SuccessGroupDetails: function (data) {
        
        EmplyeeGroupDetailsTable();
        var splitData = data.split(',');       
           
        $('#SuccessMessageGroupDetails').html(splitData[0]);
        $('#SuccessMessageGroupDetails').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', splitData[1]);
        $('#myDataTableForEmplyeeGroupDetails tr').hover(function () {
            $(this).css('cursor', 'pointer');
        });
        $("#EditDependentObject").hide(true);
        
    },

    //this is used to for showing successfully record updation message and reload the list view
    //editSuccess: function (data) {

    //    
    //    
    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        var actionMode = "1";
    //        GeneralGroupMaster.ReloadList("Record Updated Sucessfully.", actionMode);
    //        //  alert("Record Created Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //        // alert("Record Not Updated Sucessfully. Please Try Again..");
    //    }

    //},
    ////this is used to for showing successfully record deletion message and reload the list view
    //deleteSuccess: function (data) {

    //    
    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        GeneralGroupMaster.ReloadList("Record Deleted Sucessfully.");
    //        //  alert("Record Deleted Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //        // alert("Record Not Deleted Sucessfully. Please Try Again..");
    //    }


    //},
};

