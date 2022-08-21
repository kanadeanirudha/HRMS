var OrganisationDepartmentMaster = {
    variable: null,
    Initialize: function () {
        OrganisationDepartmentMaster.constructor();
    },
    constructor: function () {

        $('#CreateOrganisationDepartmentMasterRecord').on("click", function () {

            OrganisationDepartmentMaster.ActionName = "Create";
            OrganisationDepartmentMaster.AjaxCallOrganisationDepartmentMaster();
        });
        $('#EditOrganisationDepartmentMasterRecord').on("click", function () {
            OrganisationDepartmentMaster.ActionName = "Edit";
            OrganisationDepartmentMaster.AjaxCallOrganisationDepartmentMaster();
        });
        $('#DeleteOrganisationDepartmentMasterRecord').on("click", function () {
            OrganisationDepartmentMaster.ActionName = "Delete";
            OrganisationDepartmentMaster.AjaxCallOrganisationDepartmentMaster();
        });
        $('#closeBtn').on("click", function () {
            $.magnificPopup.close();
        });
        $("#UserSearch").on("keyup", function () {
            var oTable = $("#myDataTable").dataTable();
            oTable.fnFilter(this.value);
        });
        $("#searchBtn").on("click", function () {
            $("#UserSearch").focus();
        });
        $("#showrecord").on("change", function () {
            var showRecord = $("#showrecord").val();
            $("select[name*='myDataTable_length']").val(showRecord);
            $("select[name*='myDataTable_length']").change();
        });

        InitAnimatedBorder();
        CloseAlert();

        $('#reset').on("click", function () {
            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#DepartmentName').focus();
            $('#AcademicNonacademic').val("Academic");
            return false;
        });
    },
    LoadList: function () {

        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            url: '/OrganisationDepartmentMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $('#ListViewModel').html(data);
            }
        });
    },
    ReloadList: function (message, colorCode, actionMode) {
        $.ajax(
       {
           cache: false,
           type: "POST",
           dataType: "html",
           data: { actionMode: actionMode },
           url: '/OrganisationDepartmentMaster/List',
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

    AjaxCallOrganisationDepartmentMaster: function () {
        var OrganisationDepartmentMasterMasterData = null;
        if (OrganisationDepartmentMaster.ActionName == "Create") {
            $("#FormCreateOrganisationDepartmentMaster").validate();
            if ($("#FormCreateOrganisationDepartmentMaster").valid()) {

                OrganisationDepartmentMasterMasterData = OrganisationDepartmentMaster.GetOrganisationDepartmentMaster();
                ajaxRequest.makeRequest("/OrganisationDepartmentMaster/Create", "POST", OrganisationDepartmentMasterMasterData, OrganisationDepartmentMaster.Success);
            }
        }
        else if (OrganisationDepartmentMaster.ActionName == "Edit") {
            $("#FormEditOrganisationDepartmentMaster").validate();
            if ($("#FormEditOrganisationDepartmentMaster").valid()) {

                OrganisationDepartmentMasterMasterData = OrganisationDepartmentMaster.GetOrganisationDepartmentMaster();
                ajaxRequest.makeRequest("/OrganisationDepartmentMaster/Edit", "POST", OrganisationDepartmentMasterMasterData, OrganisationDepartmentMaster.Success);
            }
        }
        else if (OrganisationDepartmentMaster.ActionName == "Delete") {

            OrganisationDepartmentMasterMasterData = OrganisationDepartmentMaster.GetOrganisationDepartmentMaster();
            ajaxRequest.makeRequest("/OrganisationDepartmentMaster/Delete", "POST", OrganisationDepartmentMasterMasterData, OrganisationDepartmentMaster.Success);
        }
    },

    GetOrganisationDepartmentMaster: function () {

        var Data = {
        };
        if (OrganisationDepartmentMaster.ActionName == "Create" || OrganisationDepartmentMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.DepartmentName = $('#DepartmentName').val();
            Data.DeptShortCode = $('#DeptShortCode').val();
            Data.PrintShortDesc = $('#PrintShortDesc').val();
            Data.AcademicNonacademic = $('#AcademicNonacademic').val();
            if ((Data.AcademicNonacademic) == 'Academic') {
                Data.TeachingActivity = true;
            }
            else {
                Data.TeachingActivity = false;
            }
            //Data.TeachingActivity = $('input[name=TeachingActivity]:checked').val() ? true : false;
        }
        else if (OrganisationDepartmentMaster.ActionName == "Delete") {
            Data.ID = $('#ID').val();
        }
        return Data;
    },

    Success: function (data) {
        var splitData = data.split(',');
        if (data != null) {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            OrganisationDepartmentMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            OrganisationDepartmentMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    
};


