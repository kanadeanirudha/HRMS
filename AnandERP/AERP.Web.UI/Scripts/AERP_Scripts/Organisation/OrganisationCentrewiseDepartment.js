var OrganisationCentrewiseDepartment = {
    variable: null,
    SelectedDomainIDs: null,
    Initialize: function () {
        OrganisationCentrewiseDepartment.constructor();
    },
    constructor: function () {


        $("#btnShowList").unbind("click").on("click", function () {

            var SelectedCentreCode = $("#SelectedCentreCode").val();
            var SelectedCentreName = $("#SelectedCentreCode option:selected").text();
            if (SelectedCentreCode != "" && SelectedCentreName != "") {
                $.ajax(
                     {
                         cache: false,
                         type: "GET",
                         data: { "centreCode": SelectedCentreCode, "centreName": SelectedCentreName },
                         dataType: "html",
                         url: '/OrganisationCentrewiseDepartment/List',
                         success: function (data) {
                             //Rebind Grid Data
                             $('#ListViewModel').html(data);
                         }
                     });
            }
            else {
                notify("Please select Centre.", "warning");
            }

        });

        $("#SelectedCentreCode").change(function () {
            //$('#myDataTable').html("");
            //$('#myDataTable_info').text("No entries to show");
            //$('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');

        });




        $('#CreateOrganisationCentrewiseDepartmentRecord').on("click", function () {
            if ($("#SelectedCentreCode").val() == "") {
                $("#displayErrorMessage p").text("Please Select Centre.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            OrganisationCentrewiseDepartment.ActionName = "Create";
            OrganisationCentrewiseDepartment.getValueUsingParentTag_Check_UnCheck();
            OrganisationCentrewiseDepartment.AjaxCallOrganisationCentrewiseDepartment();
        });
        $('#EditOrganisationCentrewiseDepartmentRecord').on("click", function () {
            if ($("#SelectedCentreCode").val() == "") {
                $("#displayErrorMessage p").text("Please Select Centre.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                return false;
            }
            OrganisationCentrewiseDepartment.ActionName = "Edit";
            OrganisationCentrewiseDepartment.getValueUsingParentTag_Check_UnCheck();
            OrganisationCentrewiseDepartment.AjaxCallOrganisationCentrewiseDepartment();
        });
        $('#DeleteOrganisationCentrewiseDepartmentRecord').on("click", function () {
            OrganisationCentrewiseDepartment.ActionName = "Delete";
            OrganisationCentrewiseDepartment.AjaxCallOrganisationCentrewiseDepartment();
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
        //$(".ajax").colorbox();
        InitAnimatedBorder();
        CloseAlert();



    },
    LoadList: function () {


        $.ajax(
        {
            cache: false,
            type: "GET",
            dataType: "html",
            url: '/OrganisationCentrewiseDepartment/List',
            success: function (data) {
                //Rebind Grid Data
                $('#ListViewModel').html(data);
            }
        });
    },
    ReloadList: function (message, colorCode, actionMode, centreCode) {

        var aaa = centreCode.split('~');
        var SelectedCentreCode = aaa[0];
        var SelectedCentreName = aaa[1];
        $.ajax(
       {
           cache: false,
           type: "POST",
           data: { "centreCode": SelectedCentreCode, "centreName": SelectedCentreName, "actionMode": actionMode },
           dataType: "html",
           url: '/OrganisationCentrewiseDepartment/List',
           success: function (data) {
               //Rebind Grid Data
               $("#ListViewModel").empty().append(data);
               //twitter type notification
               //$('#SuccessMessage').html(message);
               //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
               notify(message, colorCode);
           }
       });
    },

    AjaxCallOrganisationCentrewiseDepartment: function () {
        var OrganisationCentrewiseDepartmentMasterData = null;
        if (OrganisationCentrewiseDepartment.ActionName == "Create") {
            $("#FormCreateOrganisationCentrewiseDepartment").validate();
            if ($("#FormCreateOrganisationCentrewiseDepartment").valid()) {

                OrganisationCentrewiseDepartmentMasterData = OrganisationCentrewiseDepartment.GetOrganisationCentrewiseDepartmentMaster();
                ajaxRequest.makeRequest("/OrganisationCentrewiseDepartment/Create", "POST", OrganisationCentrewiseDepartmentMasterData, OrganisationCentrewiseDepartment.Success);
            }
        }
        else if (OrganisationCentrewiseDepartment.ActionName == "Edit") {
            $("#FormEditOrganisationCentrewiseDepartmentMaster").validate();


            OrganisationCentrewiseDepartmentMasterData = OrganisationCentrewiseDepartment.GetOrganisationCentrewiseDepartmentMaster();
            ajaxRequest.makeRequest("/OrganisationCentrewiseDepartment/Edit", "POST", OrganisationCentrewiseDepartmentMasterData, OrganisationCentrewiseDepartment.Success);

        }
        else if (OrganisationCentrewiseDepartment.ActionName == "Delete") {

            OrganisationCentrewiseDepartmentMasterData = OrganisationCentrewiseDepartment.GetOrganisationCentrewiseDepartmentMaster();
            ajaxRequest.makeRequest("/OrganisationCentrewiseDepartment/Delete", "POST", OrganisationCentrewiseDepartmentMasterData, OrganisationCentrewiseDepartment.Success);
        }
    },

    getValueUsingParentTag_Check_UnCheck: function () {
        debugger
        var sList = "";
        var xmlParamList = "<rows>"
        //alert();
        //$('#checkboxlist input[type=checkbox]').each(function () {
        $('#checkboxlist option').each(function () {

            if ($(this).val() != "on") {
                //AdminRoleDomainID = $(this).val();
                AdminRoleDomainID = $(this).val().split("~");
                if (this.selected == true) {

                    //xmlInsert code here
                    xmlParamList = xmlParamList + "<row>" + "<ID>" + AdminRoleDomainID[0] + "</ID>" + "<AdminRoleDomainID>" + AdminRoleDomainID[1] + "</AdminRoleDomainID></row>";
                }

            }
            
        });
        if (xmlParamList.length > 6)
            OrganisationCentrewiseDepartment.SelectedDomainIDs = xmlParamList + "</rows>";
        else
            OrganisationCentrewiseDepartment.SelectedDomainIDs = "";
        // alert(GeneralTaxGroupMaster.SelectedTaxMaterIDs);
    },

    GetOrganisationCentrewiseDepartmentMaster: function () {
        var Data = {};
        Data.ID = $('input[name=ID]').val();
        Data.CentrewiseDepartmentID = $('input[name=CentrewiseDepartmentID]').val();
        Data.DepartmentID = $('input[name=DepartmentID]').val();
        Data.CentreCode = $('#CentreCode').val();
        Data.ActiveFlag = $("#ActiveFlag").is(":checked") ? "true" : "false";
        Data.DepartmentSeqNo = $('#DepartmentSeqNo').val();
        Data.SelectedCentreName = $('#SelectedCentreName').val();
        Data.SelectedDomainIDs = OrganisationCentrewiseDepartment.SelectedDomainIDs;

        return Data;
    },

    Success: function (data) {

        var CentreCode = data.CentreCodeWithName;
        var splitData = data.errorMessage.split(',');
        //parent.$.colorbox.close();
        $.magnificPopup.close();
        OrganisationCentrewiseDepartment.ReloadList(splitData[0], splitData[1], splitData[2], CentreCode);
    },

};


