////this class contain methods related to nationality functionality
//var GeneralTaskReportingDetails = {
//    //Member variables
//    ActionName: null,
//    SelectedXMLstring: null,
//    SelectedDepartmentIDs:null,
//    SelectedDepartmentNames: null,
//    SelectedApprovalStageDetailsXMLstring:null,
//    //Class intialisation method
//    Initialize: function () {
//        GeneralTaskReportingDetails.constructor();
//    },
//    //Attach all event of page
//    constructor: function () {
//        //Reset button click event function to reset all controls of form
//        $("#myDataTable tbody").on("click", "tr td p i[id=showStages]", function () {
//            var val = $(this).attr("tag");
//            $.ajax(
//              {
//                  cache: false,
//                  type: "GET",
//                  dataType: "html",
//                  data: { "Ids": val },
//                  url: '/GeneralTaskReportingDetails/ApprovalStages',
//                  success: function (data) {
//                      //Rebind Grid Data
//                      $('#approvalStages').html(data);
//                      $("#approvalStages").show("slow");
//                  }
//              });
//        });
//        $("#myDataTable1 tbody").on("click", "tr td p i[id=showStageDetails]", function () {
//            var val = $(this).attr("tag");
//            var selectedItem = $("#CentreCode :selected").val();
//            $.ajax(
//              {
//                  cache: false,
//                  type: "GET",
//                  dataType: "html",
//                  data: { "Ids": val, "centreCode": selectedItem },
//                  url: '/GeneralTaskReportingDetails/ApprovalStageDetails',
//                  success: function (data) {
//                      //Rebind Grid Data
//                      $('#approvalStageDetails').html(data);
//                      $("#approvalStageDetails").show("slow");
//                  }
//              });
//        });

//        $("#closeApprovalStageDetails").on("click", function () {
//            $("#approvalStageDetails").hide("slow");
//        });
//        $("#closeApprovalStages").on("click", function () {
//            $("#approvalStages").hide("slow");
//        });


//        $('#CreateGeneralTaskReportingMasterRecord').on("click", function () {

//            GeneralTaskReportingDetails.ActionName = "CreateReportingMaster";
//            GeneralTaskReportingDetails.GetPrimaryKeyValues();
//            //if (GeneralTaskReportingDetails.SelectedXMLstring != "") {
//                GeneralTaskReportingDetails.AjaxCallGeneralTaskReportingDetails();
//            //}
//            //else {
//            //    $('#msgDiv').html("Base Table Key Values must be selected");
//            //    $('#msgDiv').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', "#FFCC80");
//            //}
//        });

//        $('#CreateApprovalStageDetailsRecord').on("click", function () {

//            GeneralTaskReportingDetails.ActionName = "CreateApprovalStageDetails";
//            GeneralTaskReportingDetails.getDataFromDataTable();
//            if (GeneralTaskReportingDetails.SelectedApprovalStageDetailsXMLstring != "") {
//                GeneralTaskReportingDetails.AjaxCallGeneralTaskReportingDetails();
//            }
//            else {
//                $('#msgDiv').html("No authorities selected");
//                $('#msgDiv').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', "#FFCC80");
//            }
//        });

//        $('#EditApprovalStageDetailsRecord').on("click", function () {

//            GeneralTaskReportingDetails.ActionName = "EditApprovalStageDetails";
//            GeneralTaskReportingDetails.GetSelectedDepartmentForEdit();
//            if (GeneralTaskReportingDetails.SelectedDepartmentIDs!= "") {
//                GeneralTaskReportingDetails.AjaxCallGeneralTaskReportingDetails();
//            }
//            else {
//                $('#msgDiv').html("At least one department must be selected");
//                $('#msgDiv').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', "#FFCC80");
//            }
//        });

//        $('#DeleteGeneralTaskReportingDetailsRecord').on("click", function () {

//            GeneralTaskReportingDetails.ActionName = "Delete";
//            GeneralTaskReportingDetails.AjaxCallGeneralTaskReportingDetails();
//        });

//        //$("#UserSearch").on("keyup", function () {
//        //    oTable.fnFilter(this.value);
//        //});

//        $("#searchBtn").on("click", function () {
//            $("#UserSearch").focus();
//        });

//        $("#showrecord").on("change", function () {
//            var showRecord = $("#showrecord").val();
//            $("select[name*='myDataTable_length']").val(showRecord);
//            $("select[name*='myDataTable_length']").change();
//        });

//        //$(".ajax").colorbox();
//        InitAnimatedBorder();
//        CloseAlert();

//        $('#reset').on("click", function () {
//            //alert("ASD");
//            $("input").not(':button, :checkbox,').val("");
//            $('input:checkbox,input:radio').removeAttr('checked');
//            $('#AccountName').focus();
//            $('#TaskCode').val('');
//            $('#TaskApprovalBasedTable').val("");
//            $('#TaskApprovalParamPrimaryKey').val("");
//            $('#TaskApprovalTableDisplayField').val("");
//            return false;
//        });


//        $("#CentreList").change(function () {
//            $('#myDataTable').html("");
//            $('#myDataTable_info').text("No entries to show");
//            $('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
//        });

//        $("#ShowList").click(function () {

//            var SelectedCentreCode = $('#CentreCode').val();
//            var SelectedCentreName = $('#CentreCode :selected').text();
//            centreName = SelectedCentreCode;
//            if (SelectedCentreCode != "") {
//                $.ajax(
//             {
//                 cache: false,
//                 type: "POST",
//                 data: { actionMode: null, centerCode: SelectedCentreCode },
//                 dataType: "html",
//                 url: '/GeneralTaskReportingDetails/List',
//                 success: function (result) {
//                     //Rebind Grid Data                
//                     $('#ListViewModel').html(result);
//                     $("#btnDiv").show();
//                 }
//             });
//            }
//            else {
//                $('#SuccessMessage').html("Please select Centre");
//                $('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', "#FFCC80");
//            }
//        });

//        $("#TaskApprovalBasedTable").change(function () {

//            var selectedItem = $(this).val();
//            GeneralTaskReportingDetails.ResetBaseTableKeyValues();
//            if (selectedItem != "") {
//                var $ddlPrimaryKey = $("#TaskApprovalParamPrimaryKey");
//                var $PrimaryKeyProgress = $("#states-loading-progress");
//                var $ddlColumnList = $("#TaskApprovalTableDisplayField");
//                var $ColumnListProgress = $("#states-loading-progress");
//                $PrimaryKeyProgress.show();
//                $ColumnListProgress.show();
//                $.ajax({
//                    cache: false,
//                    type: "GET",
//                    url: "/GeneralTaskReportingDetails/GetPrimaryKeyList",
//                    data: { "tableName": selectedItem },
//                    success: function (data) {
//                        //------------------binding dropdown 1
//                        $ddlPrimaryKey.html('');
//                        $('#TaskApprovalParamPrimaryKey').append('<option value>----------Select Primary Key ----------</option>');
//                        $.each(data.Result1, function (id, option) {

//                            $ddlPrimaryKey.append($('<option></option>').val(option.id).html(option.name));
//                        });
//                        $PrimaryKeyProgress.hide();
//                        //------------------binding dropdown 2
//                        $ddlColumnList.html('');
//                        $('#TaskApprovalTableDisplayField').append('<option value>----------Select Display Field----------</option>');
//                        $.each(data.Result2, function (id, option) {

//                            $ddlColumnList.append($('<option></option>').val(option.id).html(option.name));
//                        });
//                        $ColumnListProgress.hide();
//                    },
//                    error: function (xhr, ajaxOptions, thrownError) {
//                        alert('Failed to retrieve data.');
//                        $PrimaryKeyProgress.hide();
//                    }
//                });
//            }
//            else {
//                $('#TaskApprovalParamPrimaryKey').find('option').remove().end().append('<option value>----------Select Primary Key ----------</option>');
//                $('#TaskApprovalTableDisplayField').find('option').remove().end().append('<option value>----------Select Display Field----------</option>');
//            }
//        });

//        $('#TaskApprovalParamPrimaryKey').on("change", function () {
//            GeneralTaskReportingDetails.ResetBaseTableKeyValues();
//        });
//        $('#TaskApprovalTableDisplayField').on("change", function () {
//            GeneralTaskReportingDetails.ResetBaseTableKeyValues();
//        });

//        $("#populate_ddl").on("click", function () {

//            var selectedItem1 = $("#TaskApprovalParamPrimaryKey :selected").val();
//            var selectedItem2 = $("#TaskApprovalTableDisplayField :selected").val();
//            var selectedItem3 = $("#TaskApprovalBasedTable :selected").val();
//            if (selectedItem1 != '' && selectedItem2 != '' && selectedItem3 != '') {
//                var $ddlTaskApprovalKeyValue = $("#TaskApprovalKeyValue");
//                var $TaskApprovalKeyValueProgress = $("#states-loading-progress");
//                $TaskApprovalKeyValueProgress.show();
//                $.ajax({
//                    cache: false,
//                    type: "GET",
//                    url: "/GeneralTaskReportingDetails/GetPrimaryKeyValueList",
//                    data: { "tableName": selectedItem3, "primaryKey": selectedItem1, "displayField": selectedItem2 },
//                    success: function (data) {
//                        $ddlTaskApprovalKeyValue.html('');
//                        $('#TaskApprovalKeyValue').append('<option value>-----Select Primary Key Values-------</option>');
//                        $('#e5_f .ms-drop ul').html('');
//                        $.each(data, function (id, option) {
//                            $ddlTaskApprovalKeyValue.append($('<option></option>').val(option.id).html(option.name));
//                            $('#e5_f .ms-drop ul').append('<li> <label><input type="checkbox" value="' + option.id+"~"+option.name + '" name="selectItem">' + option.name + '</label></li>');
//                        });
//                        $TaskApprovalKeyValueProgress.hide();
//                    },
//                    error: function (xhr, ajaxOptions, thrownError) {
//                        alert('Failed to retrieve data.');
//                        $PrimaryKeyProgress.hide();
//                    }
//                });
//            }
//            else {
//                if (selectedItem3 == "") {
//                    $('#msgDiv').html("Please select Approval Base Table ");
//                    $('#msgDiv').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', "#FFCC80");
//                }
//                else if (selectedItem1 == "") {
//                    $('#msgDiv').html("Please select Base Table Primary Key");
//                    $('#msgDiv').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', "#FFCC80");
//                }
//                else if (selectedItem2 == "") {
//                    $('#msgDiv').html("Please select Base Table Display Field ");
//                    $('#msgDiv').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', "#FFCC80");
//                }
//            }
//        });

//        //FOLLOWING FUNCTION IS SEARCHLIST OF item list
//        $("#EmployeeName").autocomplete({

//            source: function (request, response) {
//                $.ajax({
//                    url: "/GeneralTaskReportingDetails/GetEmployeeRoleCentrewise",
//                    type: "POST",
//                    dataType: "json",
//                    data: { term: request.term, centreCode: $("#CentreCode").val() },
//                    success: function (data) {
//                        response($.map(data, function (item) {
//                            return { label: item.name, value: item.name, id: item.id, roleId: item.roleId };
//                        }))
//                    }
//                })
//            },
//            select: function (event, ui) {
//                $(this).val(ui.item.label);                                             // display the selected text
//                $("#RoleID").val(ui.item.roleId);
//            }
//        });

//        // Add new record in table
//        $('#btnAdd').on("click", function () {
//            GeneralTaskReportingDetails.GetSelectedDepartment();
//            if (GeneralTaskReportingDetails.SelectedDepartmentIDs != "" && $('#RoleID').val() != "") {
//                $("#tblData tbody").append(
//                                        "<tr>" +
//                                        "<td ><input type='text' value=" + $('#RoleID').val() + " style='display:none' /> " + $('#EmployeeName').val() + "</td>" +
//                                        "<td><input type='hidden' value=" + GeneralTaskReportingDetails.SelectedDepartmentIDs + "  /> " + GeneralTaskReportingDetails.SelectedDepartmentNames.slice(0, -1) + "</td>" +
//                                        "<td  style='text-align:center; '> <i class='icon-trash' style='cursor:pointer' title = Delete></td>" +
//                                        "</tr>"
//                                        );
//                $("#EmployeeName").val("");
//                $("#RoleID").val("");
//                $('#EmployeeName').focus();
//            }
//            else if ($('#RoleID').val() == "") {
//                $('#msgDiv').html("Invalid employee");
//                $('#msgDiv').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', "#FFCC80");
//            }
//            else if (GeneralTaskReportingDetails.SelectedDepartmentIDs == "") {
//                $('#msgDiv').html("At least one department must be selected");
//                $('#msgDiv').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', "#FFCC80");
//            }
//        });

//        //Delete record in table
//        $("#tblData tbody").on("click", "tr td i[class=icon-trash]", function () {
//            $(this).closest('tr').remove();
//        });

//        $('#NumberOfApprovalStages').on("keydown", function (e) {
//            AMSValidation.AllowNumbersOnly(e);
//            AMSValidation.NotAllowSpaces(e);
//        });

//        $('#FeeCriteriaCode').on("keydown", function (e) {
//            AMSValidation.NotAllowSpaces(e);
//        });
//    },
//    ResetBaseTableKeyValues: function () {
//        $('#TaskApprovalKeyValue').find('option').remove().end().append('<option value>-----Select Primary Key Values-------</option>');
//        $('#e5_f .ms-drop ul').html('<li class="ms-no-results" style="display: list-item;">No matches found</li>');
//    },
//    //LoadList method is used to load List page
//    LoadList: function () {
//        $.ajax(
//           {
//               cache: false,
//               type: "POST",
//               dataType: "html",
//               url: '/GeneralTaskReportingDetails/List',
//               success: function (data) {
//                   //Rebind Grid Data
//                   $('#ListViewModel').html(data);
//               }
//           });
//    },
//    //ReloadList method is used to load List page
//    ReloadList: function (message, colorCode, actionMode) {
//        $.ajax(
//        {
//            cache: false,
//            type: "GET",
//            data: { "actionMode": actionMode },
//            dataType: "html",
//            url: '/GeneralTaskReportingDetails/List',
//            success: function (data) {
//                //Rebind Grid Data
//                $("#ListViewModel").empty().append(data);
//                $("#btnDiv").show();
//                ////twitter type notification
//                $('#SuccessMessage').html(message);
//                $('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', colorCode);
//            }
//        });
//    },
//    //Fire ajax call to insert update and delete record
//    AjaxCallGeneralTaskReportingDetails: function () {
//        var GeneralTaskReportingDetailsData = null;
//        if (GeneralTaskReportingDetails.ActionName == "CreateReportingMaster") {
//            $("#FormCreateTaskReportingMaster").validate();
//            if ($("#FormCreateTaskReportingMaster").valid()) {
//                GeneralTaskReportingDetailsData = null;
//                GeneralTaskReportingDetailsData = GeneralTaskReportingDetails.GetGeneralTaskReportingDetails();
//                ajaxRequest.makeRequest("/GeneralTaskReportingDetails/CreateTaskReportingMaster", "POST", GeneralTaskReportingDetailsData, GeneralTaskReportingDetails.CreateReportingMasterSuccess);
//            }
//        }
//        else if (GeneralTaskReportingDetails.ActionName == "CreateApprovalStageDetails") {
//            $("#FormCreateApprovalStageDetails").validate();
//            if ($("#FormCreateApprovalStageDetails").valid()) {
//                GeneralTaskReportingDetailsData = null;
//                GeneralTaskReportingDetailsData = GeneralTaskReportingDetails.GetGeneralTaskReportingDetails();
//                ajaxRequest.makeRequest("/GeneralTaskReportingDetails/CreateApprovalStageDetails", "POST", GeneralTaskReportingDetailsData, GeneralTaskReportingDetails.CreateApprovalStageDetailsSuccess);
//            }
//        }
//        else if (GeneralTaskReportingDetails.ActionName == "EditApprovalStageDetails") {
//            $("#FormEditApprovalStageDetails").validate();
//            if ($("#FormEditApprovalStageDetails").valid()) {
//                GeneralTaskReportingDetailsData = null;
//                GeneralTaskReportingDetailsData = GeneralTaskReportingDetails.GetGeneralTaskReportingDetails();
//                ajaxRequest.makeRequest("/GeneralTaskReportingDetails/EditApprovalStageDetails", "POST", GeneralTaskReportingDetailsData, GeneralTaskReportingDetails.EditApprovalStageDetailsSuccess);
//            }
//        } 
//    },
//    //Method to create xml of Selected Criteria Param  
//    GetPrimaryKeyValues: function () {

//        var xmlParamList = "<rows>"
//        $('#e5_f input[type=checkbox]').each(function () {

//            if ($(this).val() != "on") {
//                if (this.checked == true) {
//                    xmlParamList = xmlParamList + "<row>" + "<PrimaryKeyValue>" + $(this).val().split('~')[0] + "</PrimaryKeyValue><DisplayKeyValue>" + $(this).val().split('~')[1] + "</DisplayKeyValue></row>";
//                }
//            }
//        });
//        if (xmlParamList.length > 6)
//            GeneralTaskReportingDetails.SelectedXMLstring = xmlParamList + "</rows>";
//        else
//            GeneralTaskReportingDetails.SelectedXMLstring = "";
//    },
//    //Method to create xml of Selected Criteria Param  
//    GetSelectedDepartment: function () {

//        var xmlParamList = "<rows>";
//        GeneralTaskReportingDetails.SelectedDepartmentNames = "";
//        GeneralTaskReportingDetails.SelectedDepartmentIDs = "";
//        $('#e5_f input[type=checkbox]').each(function () {

//            if ($(this).val() != "on") {
//                if (this.checked == true) {
//                    //GeneralTaskReportingDetails.SelectedXMLstring = xmlParamList + "<row>" + "<DepartmentID>" + $(this).val().split('~')[0] + "</DepartmentID>" + "</row>";
//                    GeneralTaskReportingDetails.SelectedDepartmentIDs += $(this).val().split('~')[0] + "~";
//                    GeneralTaskReportingDetails.SelectedDepartmentNames += $(this).val().split('~')[1] + ','
//                }
//            }
//        });
//    },
//    getDataFromDataTable: function () {
//        var DataArray = [];
//        var table = $('#tblData').DataTable();
//        var data = table.$('input,select,input tag').each(function () {
//            DataArray.push($(this).val());
//        });
//        var xmlParamList = "<rows>";
//        var aa = [];
//        var x = 0;
//        var Count = DataArray.length / 2;
//        for (var i = 0; i < Count; i++) {
//            aa = DataArray[x + 1].split('~');
//            xmlParamList = xmlParamList + "<row><RoleID>" + DataArray[x] + "</RoleID>" + "<DepartmentID>" + DataArray[x + 1].replace(/\~/g, ',').slice(0, -1) + "</DepartmentID>";
//            //for (var j = 0; j < aa.length - 1; j++) {
//            //    xmlParamList = xmlParamList + "<DepartmentID>" + aa[j] + "</DepartmentID>";
//            //}
//            xmlParamList = xmlParamList + "</row>";
//            x = x + 2;
//        }
//        table.destroy();
//        if (xmlParamList.length > 6)
//            GeneralTaskReportingDetails.SelectedApprovalStageDetailsXMLstring = xmlParamList + "</rows>";
//        else
//            GeneralTaskReportingDetails.SelectedApprovalStageDetailsXMLstring = "";
//        //alert(GeneralTaskReportingDetails.SelectedApprovalStageDetailsXMLstring);
//    },
//    //Method to create xml of Selected Criteria Param  
//    GetSelectedDepartmentForEdit: function () {

//        var xmlParamList = "<rows>";
//        GeneralTaskReportingDetails.SelectedDepartmentIDs = "";
//        $('#e5_f input[type=checkbox]').each(function () {

//            if ($(this).val() != "on") {
//                if (this.checked == true) {
//                    xmlParamList = xmlParamList + "<row><DepartmentID>" + $(this).val().split('~')[0] + "</DepartmentID></row>";
//                }
//            }
//        });
//        if (xmlParamList.length > 6) {
//            GeneralTaskReportingDetails.SelectedDepartmentIDs = xmlParamList + "</rows>";
//        }
//        else {
//            GeneralTaskReportingDetails.SelectedDepartmentIDs = "";
//        }
//    },
//    //Get properties data from the Create, Update and Delete page
//    GetGeneralTaskReportingDetails: function () {

//        var Data = {
//        };
//        if (GeneralTaskReportingDetails.ActionName == "CreateReportingMaster") {
//            Data.TaskCode = $('#TaskCode').val();
//            Data.CentreCode = $('#CentreCode').val();
//            Data.ApprovalType = $('#ApprovalType').val();
//            Data.NumberOfApprovalStages = $("#NumberOfApprovalStages").val();
//            Data.TaskApprovalBasedTable = $("#TaskApprovalBasedTable").val();
//            Data.TaskApprovalParamPrimaryKey = $("#TaskApprovalParamPrimaryKey").val();
//            Data.TaskApprovalTableDisplayField = $("#TaskApprovalTableDisplayField").val();
//            Data.KeyValueXmlString = GeneralTaskReportingDetails.SelectedXMLstring;
//        }
//        if (GeneralTaskReportingDetails.ActionName == "CreateApprovalStageDetails") {
//            Data.GeneralTaskReportingMasterID = $('#GeneralTaskReportingMasterID').val();
//            Data.StageSequenceNumber = $('#StageSequenceNumber').val();
//            Data.CentreCode = $('#CentreCode').val();
//            Data.RangeFrom = $("#RangeFrom").val();
//            Data.RangeUpto = $("#RangeUpto").val();
//            if ($("#tblData tbody tr").length > 1) {
//                Data.IsParallel = 1;
//            }
//            else {
//                Data.IsParallel = 0;
//            }
//            Data.SelectedApprovalStageDetailsXMLstring = GeneralTaskReportingDetails.SelectedApprovalStageDetailsXMLstring;
//        }
//        if (GeneralTaskReportingDetails.ActionName == "EditApprovalStageDetails") {
//            Data.GeneralTaskReportingDetailsID = $('#GeneralTaskReportingDetailsID').val();
//            Data.CentreCode = $('#CentreCode').val();
//            Data.RoleID = $('#RoleID').val();
//            Data.RangeFrom = $("#RangeFrom").val();
//            Data.RangeUpto = $("#RangeUpto").val();
//            Data.SelectedApprovalStageDetailsXMLstring = GeneralTaskReportingDetails.SelectedDepartmentIDs;
//        } 
//        return Data;
//    },
//    //this is used to for showing successfully record creation message and reload the list view
//    CreateReportingMasterSuccess: function (data) {
//        var splitData = data.split(',');
//        parent.$.colorbox.close();
//        $('#SuccessMessage').html(splitData[0]);
//        $('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', splitData[1]);
//        ReloadmyDataTable();

//    },
//    CreateApprovalStageDetailsSuccess: function (data) {
//        var splitData = data.split(',');
//        parent.$.colorbox.close();
//        $('#SuccessMessage').html(splitData[0]);
//        $('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', splitData[1]);
//        ReloadmyDataTable1();
//        ReloadmyDataTable2(1);

//    },
//    EditApprovalStageDetailsSuccess: function (data) {
//        var splitData = data.split(',');
//        parent.$.colorbox.close();
//        $('#SuccessMessage').html(splitData[0]);
//        $('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', splitData[1]);
//        ReloadmyDataTable1();
//        ReloadmyDataTable2(2);

//    },
//};

///////////////////////////////new js///////////////////////

//this class contain methods related to nationality functionality
var GeneralTaskReportingDetails = {
    //Member variables
    map: {},
    map2: {},
    ActionName: null,
    SelectedXMLstring: null,
    SelectedDepartmentIDs: null,
    SelectedDepartmentNames: null,
    SelectedApprovalStageDetailsXMLstring: null,


    //Class intialisation method
    Initialize: function () {
        GeneralTaskReportingDetails.constructor();
    },
    //Attach all event of page
    constructor: function () {
        //Reset button click event function to reset all controls of form
        //$("#myDataTable tbody").on("click", "tr td p i[id=showStages]", function () {
        $("#myDataTable tbody").on("click", "tr td p i[id=showStages]", function () {
            var val = $(this).attr("tag");
            $.ajax(
              {
                  cache: false,
                  type: "GET",
                  dataType: "html",
                  data: { "Ids": val },
                  url: '/GeneralTaskReportingDetails/ApprovalStages',
                  success: function (data) {
                      //Rebind Grid Data
                      $("#approvalStages").show("slow");
                      $('#approvalStages').html(data);
                      //$("#approvalStages").show("slow");

                  }
              });
        });
        $("#myDataTable1 tbody").on("click", "tr td p i[id=showStageDetails]", function () {
            debugger;
            var val = $(this).attr("tag");
            var selectedItem = $("#CentreCode :selected").val();
            $.ajax(
              {
                  cache: false,
                  type: "GET",
                  dataType: "html",
                  data: { "Ids": val, "centreCode": selectedItem },
                  url: '/GeneralTaskReportingDetails/ApprovalStageDetails',
                  success: function (data) {
                      //Rebind Grid Data
                      debugger;
                      $("#approvalStageDetails").show("slow");
                      $('#approvalStageDetails').html(data);
                      //$("#approvalStageDetails").show("slow");
                  }
              });
        });

        $("#closeApprovalStageDetails").on("click", function () {
            $("#approvalStageDetails").hide("slow");
        });
        $("#closeApprovalStages").on("click", function () {
            $("#approvalStages").hide("slow");
        });


        $('#CreateGeneralTaskReportingMasterRecord').on("click", function () {
            GeneralTaskReportingDetails.ActionName = "CreateReportingMaster";
            GeneralTaskReportingDetails.GetPrimaryKeyValues();
            //if (GeneralTaskReportingDetails.SelectedXMLstring != "") {
            GeneralTaskReportingDetails.AjaxCallGeneralTaskReportingDetails();
            //}
            //else {
            //    $('#msgDiv').html("Base Table Key Values must be selected");
            //    $('#msgDiv').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', "#FFCC80");
            //}
        });

        $('#CreateApprovalStageDetailsRecord').on("click", function () {
            GeneralTaskReportingDetails.ActionName = "CreateApprovalStageDetails";
            GeneralTaskReportingDetails.getDataFromDataTable();
            if (GeneralTaskReportingDetails.SelectedApprovalStageDetailsXMLstring != "") {
                GeneralTaskReportingDetails.AjaxCallGeneralTaskReportingDetails();
            }
            else {
                $('#msgDiv').html("No authorities selected");
                $('#msgDiv').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', "#FFC107");
            }
        });

        $('#EditApprovalStageDetailsRecord').on("click", function () {
            GeneralTaskReportingDetails.ActionName = "EditApprovalStageDetails";
            GeneralTaskReportingDetails.GetSelectedDepartmentForEdit();
            if (GeneralTaskReportingDetails.SelectedDepartmentIDs != "") {
                GeneralTaskReportingDetails.AjaxCallGeneralTaskReportingDetails();
            }
            else {
                $('#msgDiv').html("At least one department must be selected");
                $('#msgDiv').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', "#FFC107");
            }
        });

        $('#DeleteGeneralTaskReportingDetailsRecord').on("click", function () {
            GeneralTaskReportingDetails.ActionName = "Delete";
            GeneralTaskReportingDetails.AjaxCallGeneralTaskReportingDetails();
        });

        //$("#UserSearch").on("keyup", function () {
        //    oTable.fnFilter(this.value);
        //});

        $("#searchBtn").on("click", function () {
            debugger;
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

        $('#reset').on("click", function () {
            //alert("ASD");
            $("input").not(':button, :checkbox,').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#AccountName').focus();
            $('#TaskCode').val('');
            $('#TaskApprovalBasedTable').val("");
            $('#TaskApprovalParamPrimaryKey').val("");
            $('#TaskApprovalTableDisplayField').val("");
            return false;
        });


        $("#CentreList").change(function () {
            $('#myDataTable').html("");
            $('#myDataTable_info').text("No entries to show");
            $('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
        });

        $("#ShowList").unbind("change").click(function () {
            debugger;
            var SelectedCentreCode = $('#CentreCode').val();
            var SelectedCentreName = $('#CentreCode :selected').text();
            centreName = SelectedCentreCode;
            if (SelectedCentreCode != "") {
                $.ajax(
             {
                 cache: false,
                 type: "POST",
                 data: { actionMode: null, centerCode: SelectedCentreCode },
                 dataType: "html",
                 url: '/GeneralTaskReportingDetails/List',
                 success: function (result) {
                     //Rebind Grid Data                
                     $('#ListViewModel').html(result);
                     $("#btnDiv").show();
                 }
             });
            }
            else {
                $('#SuccessMessage').html("Please select Centre");
                $('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', "#FFC107");
            }
        });

        $("#TaskApprovalBasedTable").change(function () {
            var selectedItem = $(this).val();
            GeneralTaskReportingDetails.ResetBaseTableKeyValues();
            if (selectedItem != "") {
                var $ddlPrimaryKey = $("#TaskApprovalParamPrimaryKey");
                var $PrimaryKeyProgress = $("#states-loading-progress");
                var $ddlColumnList = $("#TaskApprovalTableDisplayField");
                var $ColumnListProgress = $("#states-loading-progress");
                $PrimaryKeyProgress.show();
                $ColumnListProgress.show();
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/GeneralTaskReportingDetails/GetPrimaryKeyList",
                    data: { "tableName": selectedItem },
                    success: function (data) {
                        //------------------binding dropdown 1
                        $ddlPrimaryKey.html('');
                        $('#TaskApprovalParamPrimaryKey').append('<option value>----------Select Primary Key ----------</option>');
                        $.each(data.Result1, function (id, option) {

                            $ddlPrimaryKey.append($('<option></option>').val(option.id).html(option.name));
                        });
                        $PrimaryKeyProgress.hide();
                        //------------------binding dropdown 2
                        $ddlColumnList.html('');
                        $('#TaskApprovalTableDisplayField').append('<option value>----------Select Display Field----------</option>');
                        $.each(data.Result2, function (id, option) {

                            $ddlColumnList.append($('<option></option>').val(option.id).html(option.name));
                        });
                        $ColumnListProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve data.');
                        $PrimaryKeyProgress.hide();
                    }
                });
            }
            else {
                $('#TaskApprovalParamPrimaryKey').find('option').remove().end().append('<option value>----------Select Primary Key ----------</option>');
                $('#TaskApprovalTableDisplayField').find('option').remove().end().append('<option value>----------Select Display Field----------</option>');
            }
        });

        $('#TaskApprovalParamPrimaryKey').on("change", function () {
            GeneralTaskReportingDetails.ResetBaseTableKeyValues();
        });
        $('#TaskApprovalTableDisplayField').on("change", function () {
            GeneralTaskReportingDetails.ResetBaseTableKeyValues();
        });

        $("#TaskApprovalTableDisplayField").change(function () {
            var selectedItem1 = $("#TaskApprovalParamPrimaryKey :selected").val();
            var selectedItem2 = $("#TaskApprovalTableDisplayField :selected").val();
            var selectedItem3 = $("#TaskApprovalBasedTable :selected").val();
            if (selectedItem1 != '' && selectedItem2 != '' && selectedItem3 != '') {
                var $ddlTaskApprovalKeyValue = $("#TaskApprovalKeyValue");
                var $TaskApprovalKeyValueProgress = $("#states-loading-progress");
                $TaskApprovalKeyValueProgress.show();
                $.ajax({
                    cache: false,
                    type: "GET",
                    dataType: "json",
                    url: "/GeneralTaskReportingDetails/GetPrimaryKeyValueList",
                    data: { "tableName": selectedItem3, "primaryKey": selectedItem1, "displayField": selectedItem2 },
                    success: function (data) {
                        $ddlTaskApprovalKeyValue.html('');
                        $('#TaskApprovalKeyValue').append('<option value>-----Select Primary Key Values-------</option>');
                        $('#e5_f .dropdown-menu ul').html('');
                        $.each(data, function (id, option) {
                            $ddlTaskApprovalKeyValue.append($('<option></option>').val(option.id + "~" + option.name).html(option.name));
                            //$('#e5_f .dropdown-menu ul').append('<li> <label><input type="hidden" value="' + option.id + "~" + option.name + '" name="selectItem">' + option.name + '</label></li>');
                        });
                        $(".selectpicker").selectpicker('refresh');
                        $TaskApprovalKeyValueProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve data.');
                        $PrimaryKeyProgress.hide();
                    }
                });
            }
            else {
                if (selectedItem3 == "") {
                    $('#msgDiv').html("Please select Approval Base Table ");
                    $('#msgDiv').delay(400).slideDown(400).delay(5000).slideUp(400).css('background-color', "#FFC107");
                }
                else if (selectedItem1 == "") {
                    $('#msgDiv').html("Please select Base Table Primary Key");
                    $('#msgDiv').delay(400).slideDown(400).delay(5000).slideUp(400).css('background-color', "#FFC107");
                }
                else if (selectedItem2 == "") {
                    $('#msgDiv').html("Please select Base Table Display Field ");
                    $('#msgDiv').delay(400).slideDown(400).delay(5000).slideUp(400).css('background-color', "#FFC107");
                }
            }
        });

        //FOLLOWING FUNCTION IS SEARCHLIST OF item list
        //$("#EmployeeName").autocomplete({

        //    source: function (request, response) {
        //        $.ajax({
        //            url: "/GeneralTaskReportingDetails/GetEmployeeRoleCentrewise",
        //            type: "POST",
        //            dataType: "json",
        //            data: { term: request.term, centreCode: $("#CentreCode").val() },
        //            success: function (data) {
        //                response($.map(data, function (item) {
        //                    return { label: item.name, value: item.name, id: item.id, roleId: item.roleId };
        //                }))
        //            }
        //        })
        //    },
        //    select: function (event, ui) {
        //        $(this).val(ui.item.label);                                             // display the selected text
        //        $("#RoleID").val(ui.item.roleId);
        //    }
        //});


        /////////////new search functionality//////////////////
        arrayName: { };
        var getData = function () {
            debugger
            return function findMatches(q, cb) {
                debugger;
                var matches, substringRegex;
                // an array that will be populated with substring matches
                matches = [];
                // regex used to determine if a string contains the substring `q`
                //alert(q);
                substrRegex = new RegExp(q, 'i');

                var valuCentreCode = $("#CentreCode").val();

                $.ajax({
                    url: "/GeneralTaskReportingDetails/GetEmployeeRoleCentrewise",
                    type: "POST",
                    data: { term: q, centreCode: valuCentreCode },
                    dataType: "json",
                    success: function (data) {

                        $.each(data, function (i, response) {
                            //alert(response.id);
                            if (substrRegex.test(response.name)) {
                                //GeneralTaskReportingDetails.map2[response.name] = response;
                                GeneralTaskReportingDetails.map[response.name] = response;
                                matches.push(response.name);

                            }
                        });
                    },
                    async: false
                })
                cb(matches);
            };

        };

        $("#EmployeeName").typeahead({
            hint: true,
            highlight: true,
            minLength: 1
        }, {
            source: getData()
        }).on("typeahead:selected", function (obj, item) {
            //alert(GeneralTaskReportingDetails.map[item].id);
            //$(this).val(item.label);
            debugger;
            $("#RoleID").val(GeneralTaskReportingDetails.map[item].roleId);
            //alert(map[item].roleId);
        });
        $('#EmployeeName').on("keydown", function (e) {
            if (e.keyCode == 8 || e.keyCode == 46) {
                $('#EmployeeName').typeahead('val', '');
                $('#RoleID').val("0");
            }
        });

        $("#HODAuthorizedEmployeeName").typeahead({
            hint: true,
            highlight: true,
            minLength: 1
        }, {
            source: getData()
        }).on("typeahead:selected", function (obj, item) {
            //alert(GeneralTaskReportingDetails.map[item].id);
            //$(this).val(item.label);
            $("#HODAuthorizedEmployeeRoleID").val(GeneralTaskReportingDetails.map[item].roleId);
            //alert(map[item].roleId);
        });
        $('#HODAuthorizedEmployeeName').on("keydown", function (e) {
            debugger;
            if (e.keyCode == 8 || e.keyCode == 46) {
                $('#HODAuthorizedEmployeeName').typeahead('val', '');
                $('#HODAuthorizedEmployeeRoleID').val("0");
            }
        });

        /////////////end new search functionality////////////

        //icon-trash zmdi zmdi-refresh
        // Add new record in table
        $('#btnAdd').on("click", function () {
            GeneralTaskReportingDetails.GetSelectedDepartment();
            debugger;
            if (GeneralTaskReportingDetails.SelectedDepartmentIDs != "" && $('#RoleID').val() != "" && $('#RoleID').val() != 0) {

                if ($('#HODAuthorizedEmployeeRoleID').val() == "" && $('#HODAuthorizedEmployeeRoleID').val() == 0)
                {
                    $("#tblData tbody").append(
                                       "<tr class='active'>" +
                                       "<td ><input type='text' value=" + $('#RoleID').val() + " style='display:none' /> " + $('#EmployeeName').val() + "</td>" +
                                       "<td><input type='hidden' value=" + GeneralTaskReportingDetails.SelectedDepartmentIDs + "  /> " + GeneralTaskReportingDetails.SelectedDepartmentNames.slice(0, -1) + "</td>" +
                                        "<td ><input type='text' value=" + 0 + " style='display:none' /> " + '' + "</td>" +
                                        "<td  style=''> <button class='btn btn-danger btn-xs waves-effect' type='button'><i class='icon-trash' style='cursor:pointer' title = Delete>Delete </button></td>" +
                                       "</tr>"
                                       );
                }
                else
                {
                    $("#tblData tbody").append(
                                       "<tr class='active'>" +
                                       "<td ><input type='text' value=" + $('#RoleID').val() + " style='display:none' /> " + $('#EmployeeName').val() + "</td>" +
                                       "<td><input type='hidden' value=" + GeneralTaskReportingDetails.SelectedDepartmentIDs + "  /> " + GeneralTaskReportingDetails.SelectedDepartmentNames.slice(0, -1) + "</td>" +

                                       "<td ><input type='text' value=" + $('#HODAuthorizedEmployeeRoleID').val() + " style='display:none' /> " + $('#HODAuthorizedEmployeeName').val() + "</td>" +
                                        "<td  style=''> <button class='btn btn-danger btn-xs waves-effect' type='button'><i class='icon-trash' style='cursor:pointer' title = Delete>Delete </button></td>" +
                                       "</tr>"
                                       );
                }
               
                //alert('abo clr');
                $("#EmployeeName").val("");
                $("#HODAuthorizedEmployeeName").val("");
               // $("#RoleID").val("");
                $('#HODAuthorizedEmployeeRoleID').val("0");
                $('#EmployeeName').focus();

                //$("#checkboxlist1").prop('selectedIndex', 0);
                //GeneralTaskReportingDetails.SelectedDepartmentIDs = "";
                //GeneralTaskReportingDetails.SelectedDepartmentNames = "";


            }
            else if ($('#RoleID').val() == "" || $('#RoleID').val() == 0) {
                $('#msgDiv').html("Invalid employee");
                $('#msgDiv').delay(400).slideDown(400).delay(5000).slideUp(400).css('background-color', "#FFC107");
            }
            else if (GeneralTaskReportingDetails.SelectedDepartmentIDs == "") {
                $('#msgDiv').html("At least one department must be selected");
                $('#msgDiv').delay(400).slideDown(400).delay(5000).slideUp(400).css('background-color', "#FFC107");
            }
        });

        //Delete record in table
        //$("#tblData tbody").on("click", "tr td i[class=icon-trash]", function () {
        //    $(this).closest('tr').remove();
        //});

        $("#tblData tbody").on("click", "tr td button", function () {
            $(this).closest('tr').remove();
           
            $("#HODAuthorizedEmployeeName").val("");
            $('#HODAuthorizedEmployeeRoleID').val("0");
            $('#EmployeeName').focus();
       
        });

        $('#NumberOfApprovalStages').on("keydown", function (e) {
            AERPValidation.AllowNumbersOnly(e);
            AERPValidation.NotAllowSpaces(e);
        });

        $('#FeeCriteriaCode').on("keydown", function (e) {
            AERPValidation.NotAllowSpaces(e);
        });
    },
    ResetBaseTableKeyValues: function () {
        $('#TaskApprovalKeyValue').find('option').remove().end().append('<option value>-----Select Primary Key Values-------</option>');
        $('#e5_f .ms-drop ul').html('<li class="ms-no-results" style="display: list-item;">No matches found</li>');
    },
    //LoadList method is used to load List page
    LoadList: function () {
        $.ajax(
           {
               cache: false,
               type: "POST",
               dataType: "html",
               url: '/GeneralTaskReportingDetails/List',
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
            type: "GET",
            data: { "actionMode": actionMode },
            dataType: "html",
            url: '/GeneralTaskReportingDetails/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                $("#btnDiv").show();
                ////twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', colorCode);
                notify(message, colorCode);
            }
        });
    },
    //Fire ajax call to insert update and delete record
    AjaxCallGeneralTaskReportingDetails: function () {
        var GeneralTaskReportingDetailsData = null;
        if (GeneralTaskReportingDetails.ActionName == "CreateReportingMaster") {
            $("#FormCreateTaskReportingMaster").validate();
            if ($("#FormCreateTaskReportingMaster").valid()) {
                GeneralTaskReportingDetailsData = null;
                GeneralTaskReportingDetailsData = GeneralTaskReportingDetails.GetGeneralTaskReportingDetails();
                ajaxRequest.makeRequest("/GeneralTaskReportingDetails/CreateTaskReportingMaster", "POST", GeneralTaskReportingDetailsData, GeneralTaskReportingDetails.CreateReportingMasterSuccess);
            }
        }
        else if (GeneralTaskReportingDetails.ActionName == "CreateApprovalStageDetails") {
            $("#FormCreateApprovalStageDetails").validate();
            if ($("#FormCreateApprovalStageDetails").valid()) {
                GeneralTaskReportingDetailsData = null;
                GeneralTaskReportingDetailsData = GeneralTaskReportingDetails.GetGeneralTaskReportingDetails();
                ajaxRequest.makeRequest("/GeneralTaskReportingDetails/CreateApprovalStageDetails", "POST", GeneralTaskReportingDetailsData, GeneralTaskReportingDetails.CreateApprovalStageDetailsSuccess);
            }
        }
        else if (GeneralTaskReportingDetails.ActionName == "EditApprovalStageDetails") {
            $("#FormEditApprovalStageDetails").validate();
            if ($("#FormEditApprovalStageDetails").valid()) {
                GeneralTaskReportingDetailsData = null;
                GeneralTaskReportingDetailsData = GeneralTaskReportingDetails.GetGeneralTaskReportingDetails();
                ajaxRequest.makeRequest("/GeneralTaskReportingDetails/EditApprovalStageDetails", "POST", GeneralTaskReportingDetailsData, GeneralTaskReportingDetails.EditApprovalStageDetailsSuccess);
            }
        }
    },
    //Method to create xml of Selected Criteria Param  
    GetPrimaryKeyValues: function () {
        //debugger
        //var xmlParamList = "<rows>"
        //$('#e5_f input[type=checkbox]').each(function () {

        //    if ($(this).val() != "on") {
        //        if (this.checked == true) {
        //            xmlParamList = xmlParamList + "<row>" + "<PrimaryKeyValue>" + $(this).val().split('~')[0] + "</PrimaryKeyValue><DisplayKeyValue>" + $(this).val().split('~')[1] + "</DisplayKeyValue></row>";
        //        }
        //    }
        //});
        //if (xmlParamList.length > 6)
        //    GeneralTaskReportingDetails.SelectedXMLstring = xmlParamList + "</rows>";
        //else
        //    GeneralTaskReportingDetails.SelectedXMLstring = "";

        //---------------new code nj--------------
        var DataArray = "";

        var TaskApprovalKey = $("select[name=TaskApprovalKeyValue]").val();
        if ($("#TaskApprovalKeyValue").val() != null && $("#TaskApprovalKeyValue").val() != "") {
            TaskApprovalKey = $("select[name=TaskApprovalKeyValue]").val().toString();
            DataArray = TaskApprovalKey.split(',');
        }

        var TotalRecord = DataArray.length;
        var xmlParamList = "<rows>";
        for (var i = 0; i < TotalRecord; i++) {
            if (DataArray[i] != "") {
                xmlParamList = xmlParamList + "<row><PrimaryKeyValue>" + DataArray[i].split('~')[0] + "</PrimaryKeyValue><DisplayKeyValue>" + DataArray[i].split('~')[1] + "</DisplayKeyValue></row>";
            }
        }
        if (xmlParamList.length > 6) {
            GeneralTaskReportingDetails.SelectedXMLstring = xmlParamList + "</rows>";
        } else {
            GeneralTaskReportingDetails.SelectedXMLstring = "";
        }
    },
    //Method to create xml of Selected Criteria Param  
    GetSelectedDepartment: function () {
        //alert('ok');
        var xmlParamList = "<rows>";
        GeneralTaskReportingDetails.SelectedDepartmentNames = "";
        GeneralTaskReportingDetails.SelectedDepartmentIDs = "";
        debugger;
        //test
        if ($("select[id=checkboxlist1]").val() != null && $("select[id=checkboxlist1]").val() != "") {
            var selectedItem = $("select[id=checkboxlist1]").val();
            for (var i = 0; i < selectedItem.length; i++) {
                if (selectedItem[i] !== "") {
                    //alert(selectedItem[i]);
                    GeneralTaskReportingDetails.SelectedDepartmentIDs += selectedItem[i].split('~')[0] + "~";
                    GeneralTaskReportingDetails.SelectedDepartmentNames += selectedItem[i].split('~')[1] + ','
                }
            }
        }

        //end test
        //original code below
        //$('#e5_f input[type=checkbox]').each(function () {
        //    //alert($(this).val());
        //    if ($(this).val() != "on") {
        //        if (this.checked == true) {
        //            GeneralTaskReportingDetails.SelectedDepartmentIDs += $(this).val().split('~')[0] + "~";
        //            GeneralTaskReportingDetails.SelectedDepartmentNames += $(this).val().split('~')[1] + ','
        //        }
        //    }
        //});
    },
    getDataFromDataTable: function () {
        debugger;
        var DataArray = [];
        var table = $('#tblData').DataTable();
        var data = table.$('input,select,input tag').each(function () {
            debugger;
            DataArray.push($(this).val());
        });
        var xmlParamList = "<rows>";
        var aa = [];
        var x = 0;
        var Count = DataArray.length / 3;
        for (var i = 0; i < Count; i++) {
            debugger;
            aa = DataArray[x + 1].split('~');
            xmlParamList = xmlParamList + "<row><RoleID>" + DataArray[x] + "</RoleID>" + "<DepartmentID>" + DataArray[x + 1].replace(/\~/g, ',').slice(0, -1) + "</DepartmentID><HODAuthorizedEmployeeRoleID>" + DataArray[x+2] + "</HODAuthorizedEmployeeRoleID>";
            //for (var j = 0; j < aa.length - 1; j++) {
            //    xmlParamList = xmlParamList + "<DepartmentID>" + aa[j] + "</DepartmentID>";
            //}
            xmlParamList = xmlParamList + "</row>";
            x = x + 2;
        }
        table.destroy();
        if (xmlParamList.length > 6)
            GeneralTaskReportingDetails.SelectedApprovalStageDetailsXMLstring = xmlParamList + "</rows>";
        else
            GeneralTaskReportingDetails.SelectedApprovalStageDetailsXMLstring = "";
        //alert(GeneralTaskReportingDetails.SelectedApprovalStageDetailsXMLstring);
    },
    //Method to create xml of Selected Criteria Param  
    GetSelectedDepartmentForEdit: function () {
        var xmlParamList = "<rows>";
        GeneralTaskReportingDetails.SelectedDepartmentIDs = "";
        //old
        //$('#e5_f input[type=checkbox]').each(function () {

        //    if ($(this).val() != "on") {
        //        if (this.checked == true) {
        //            xmlParamList = xmlParamList + "<row><DepartmentID>" + $(this).val().split('~')[0] + "</DepartmentID></row>";
        //        }
        //    }
        //});

        //old end

        //new 
        var selectedItemEdit = $("select[id=checkboxlist1]").val();
        if (selectedItemEdit != null) {
            for (var i = 0; i < selectedItemEdit.length; i++) {
                if (selectedItemEdit[i] !== "") {
                    //alert(selectedItem[i]);
                    //GeneralTaskReportingDetails.SelectedDepartmentIDs += selectedItem[i].split('~')[0] + "~";
                    //GeneralTaskReportingDetails.SelectedDepartmentNames += selectedItem[i].split('~')[1] + ','
                    xmlParamList = xmlParamList + "<row><DepartmentID>" + selectedItemEdit[i].split('~')[0] + "</DepartmentID></row>";
                }
            }
        } else {
            //$('#msgDiv').html("At least one department must be selected");
            //$('#msgDiv').delay(400).slideDown(400).delay(5000).slideUp(400).css('background-color', "#FFC107");
        }

        //new end

        if (xmlParamList.length > 6) {
            GeneralTaskReportingDetails.SelectedDepartmentIDs = xmlParamList + "</rows>";
        }
        else {
            GeneralTaskReportingDetails.SelectedDepartmentIDs = "";
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetGeneralTaskReportingDetails: function () {

        var Data = {
        };
        if (GeneralTaskReportingDetails.ActionName == "CreateReportingMaster") {
            Data.TaskCode = $('#TaskCode').val();
            Data.CentreCode = $('#CentreCode').val();
            Data.ApprovalType = $('#ApprovalType').val();
            Data.NumberOfApprovalStages = $("#NumberOfApprovalStages").val();
            Data.TaskApprovalBasedTable = $("#TaskApprovalBasedTable").val();
            Data.TaskApprovalParamPrimaryKey = $("#TaskApprovalParamPrimaryKey").val();
            Data.TaskApprovalTableDisplayField = $("#TaskApprovalTableDisplayField").val();
            Data.KeyValueXmlString = GeneralTaskReportingDetails.SelectedXMLstring;
        }
        if (GeneralTaskReportingDetails.ActionName == "CreateApprovalStageDetails") {
            Data.GeneralTaskReportingMasterID = $('#GeneralTaskReportingMasterID').val();

            Data.StageSequenceNumber = $('#StageSequenceNumber').val();
            Data.CentreCode = $('#CentreCode').val();
            Data.RangeFrom = $("#RangeFrom").val();
            Data.RangeUpto = $("#RangeUpto").val();
            if ($("#tblData tbody tr").length > 1) {
                Data.IsParallel = 1;
            }
            else {
                Data.IsParallel = 0;
            }
            Data.SelectedApprovalStageDetailsXMLstring = GeneralTaskReportingDetails.SelectedApprovalStageDetailsXMLstring;
        }
        if (GeneralTaskReportingDetails.ActionName == "EditApprovalStageDetails") {
            Data.GeneralTaskReportingDetailsID = $('#GeneralTaskReportingDetailsID').val();
            Data.CentreCode = $('#CentreCode').val();
            Data.RoleID = $('#RoleID').val();
            Data.RangeFrom = $("#RangeFrom").val();
            Data.RangeUpto = $("#RangeUpto").val();
            Data.SelectedApprovalStageDetailsXMLstring = GeneralTaskReportingDetails.SelectedDepartmentIDs;
        }
        return Data;
    },
    //this is used to for showing successfully record creation message and reload the list view
    CreateReportingMasterSuccess: function (data) {
        var splitData = data.split(',');
        //parent.$.colorbox.close();
        //alert('in js');
        $.magnificPopup.close();
        //$('#SuccessMessage').html(splitData[0]);
        //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', splitData[1]);
        notify(splitData[0], splitData[1]);
        ReloadmyDataTable();

    },
    CreateApprovalStageDetailsSuccess: function (data) {
        var splitData = data.split(',');
        //parent.$.colorbox.close();

        $.magnificPopup.close();
        //$('#SuccessMessage').html(splitData[0]);
        //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', splitData[1]);
        notify(splitData[0], splitData[1]);
        ReloadmyDataTable1();
        ReloadmyDataTable2(1);

    },
    EditApprovalStageDetailsSuccess: function (data) {
        var splitData = data.split(',');
        //parent.$.colorbox.close();

        $.magnificPopup.close();
        //$('#SuccessMessage').html(splitData[0]);
        //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', splitData[1]);
        notify(splitData[0], splitData[1]);
        ReloadmyDataTable1();
        ReloadmyDataTable2(2);

    },


    //transfered from view




};