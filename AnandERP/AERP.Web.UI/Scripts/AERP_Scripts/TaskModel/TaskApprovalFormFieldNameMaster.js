//this class contain methods related to nationality functionality
var TaskApprovalFormFieldNameMaster = {
    //Member variables
    ActionName: null,
//Class intialisation method
    Initialize: function () {
//organisationStudyCentre.loadData();
    TaskApprovalFormFieldNameMaster.constructor();
//TaskApprovalFormFieldNameMaster.initializeValidation();
   },
//Attach all event of page
        constructor: function () {

         $('#GroupDescription').focus();

         $("#reset").click(function ()
         {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#GroupDescription').focus();
            return false;
         });

         // Create new record For Task Approval details
         $('#CreateTaskApprovalFormFieldNameMasterDetails').on("click", function ()
         {
             debugger;
            TaskApprovalFormFieldNameMaster.ActionName = "CreateTaskApprovalFormFieldNameMasterDetails";
            TaskApprovalFormFieldNameMaster.GetXmlData();
            TaskApprovalFormFieldNameMaster.AjaxCallTaskApprovalFormFieldNameMaster();
            
            //else {
            //    $('#SuccessMessage').html("No data available in table");
            //    $('#SuccessMessage').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', "#FFCC80");

            
          });

            // Create new record For Task_Approval_Form_Field_Name_Master 

           $('#CreateTaskApprovalFormFieldNameMasterRecord').on("click", function () {
           // debugger
            TaskApprovalFormFieldNameMaster.ActionName = "Create";
            TaskApprovalFormFieldNameMaster.AjaxCallTaskApprovalFormFieldNameMaster();
        });

        //$('#EditTaskApprovalFormFieldNameMasterRecord').on("click", function () {

        //    TaskApprovalFormFieldNameMaster.ActionName = "Edit";
        //    TaskApprovalFormFieldNameMaster.AjaxCallTaskApprovalFormFieldNameMaster();
        //});
            // Delete new record For Task Approval details
          $('#DeleteTaskApprovalFormFieldNameDetails').on("click", function () {

            TaskApprovalFormFieldNameMaster.ActionName = "DeleteTaskApprovalFormFieldNameDetails";
            TaskApprovalFormFieldNameMaster.AjaxCallTaskApprovalFormFieldNameMaster();
        });


        $('#Addbtn').on("click", function () {
           debugger;

            var DataArray = [];
            var data = $('#tblData tbody tr td input').each(function () {
                DataArray.push($(this).val());
            });

            if ($('#LableName').val() != "" && $('#LableName').val() != null && $('#SequenceNumber').val() != "" && $('#SequenceNumber').val() > 0 && $('#ColumnNumber').val() != "" && $('#ColumnNumber').val() > 0 && $('#FieldName').val() != "" && $('#FieldName') != null)
            {
                //Code For Adding Data to the data table
                $("#tblData tbody").append
                    (
                        "<tr>" +
                            //"<td style=display:none><input id='ItemNumber' type='hidden'  value=" + $('#ItemNumber').val() + "  style='display:none' />" + $('#ItemNumber').val() + "</td>" +
                        "<td style=display:none><input id='TaskApprovalFormFieldMasterId' type='hidden' value="+ $('#TaskApprovalFormFieldMasterId').val()+" style='display:none' />" + $('#TaskApprovalFormFieldMasterId').val() + "</td>" +
                        "<td><input id='LableName'type='text' value=" + $('#LableName').val().replace(/ /g, "~") + " style='display:none' />" + $('#LableName').val() + "</td>" +
                        "<td><input id='SequenceNumber'type='text' value=" + $('#SequenceNumber').val() + " style='display:none' />" + $('#SequenceNumber').val() + "</td>" +
                        "<td><input id='ColumnNumber'type='text' value=" + $('#ColumnNumber').val() + " style='display:none' />" + $('#ColumnNumber').val() + "</td>" +
                        "<td><input id='FieldName'type='text' value=" + $('#FieldName').val().replace(/ /g, "~") + " style='display:none' />" + $('#FieldName').val() + "</td>" +



                        "<td><i class='zmdi zmdi-delete zmdi-hc-fw' style='cursor:pointer'' title = Delete></td>" +
                        "</tr>"
                       );

                $("#LableName").val("");
                $("#SequenceNumber").val("");
                $("#ColumnNumber").val("");
                $("#FieldName").val("");

            }

            //Delete record in table
            $("#tblData tbody").on("click", "tr td i", function () {
                $(this).closest('tr').remove();
            });

        });
        //$('#GroupDescription').on("keydown", function (e) {
        //    AMSValidation.AllowCharacterOnly(e);
        //});

        //$('#MarchandiseGroupCode').on("keydown", function (e) {
        //    AMSValidation.NotAllowSpaces(e);

        //});

        InitAnimatedBorder();

        CloseAlert();

        //   $('#CountryName').on("keydown", function (e) {
        //AMSValidation.AllowCharacterOnly(e);
        // });
        //  $('#ContryCode').on("keydown", function (e) {
        //   AMSValidation.AllowCharacterOnly(e);
        //  if (e.keyCode == 32) {
        //       return false;
        // }
        // });
        //$("#UserSearch").keyup(function () {
        //    var oTable = $("#myDataTable").dataTable();
        //    oTable.fnFilter(this.value);
        //});

        //$("#searchBtn").click(function () {
        //    $("#UserSearch").focus();
        //});


        //$("#showrecord").change(function () {
        //    var showRecord = $("#showrecord").val();
        //    $("select[name*='myDataTable_length']").val(showRecord);
        //    $("select[name*='myDataTable_length']").change();
        //});

        // $(".ajax").colorbox();


    },
    //LoadList method is used to load List page
    LoadList: function () {
         debugger;
        $.ajax(
         {
             cache: false,
             type: "POST",

             dataType: "html",
             url: '/TaskApprovalFormFieldNameMaster/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);

             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        debugger;
        $.ajax(
        {

            cache: false,
            type: "POST",
            dataType: "html",
            data: { actionMode: actionMode },
            url: '/TaskApprovalFormFieldNameMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().html(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },

    GetXmlData: function () {
        debugger;
        var DataArray = [];
        //TaskApprovalFormFieldNameMaster.flag = true;
        $('#tblData input').each(function () {
            DataArray.push($(this).val());
        });
        var TotalRecord = DataArray.length;
        //alert(DataArray);
        //alert(TotalRecord);
        var ParameterXml = "<rows>";

        for (var i = 0; i < TotalRecord; i = i + 5)
        {
            ParameterXml = ParameterXml + "<row><ID>" + 0 + "</ID><TaskApprovalFormFieldMasterId>" + DataArray[i] + "</TaskApprovalFormFieldMasterId><LableName>" + DataArray[i + 1].replace(/~/g, ' ') + "</LableName><SequenceNumber>" + DataArray[i + 2] + "</SequenceNumber><ColumnNumber>" + DataArray[i + 3] + "</ColumnNumber><FieldName>" + DataArray[i + 4].replace(/~/g, ' ') + "</FieldName></row>";
        }
        //alert(ParameterXml);
        if (ParameterXml.length >= 10)
            (TaskApprovalFormFieldNameMaster.ParameterXml = ParameterXml + "</rows>");

        else
            TaskApprovalFormFieldNameMaster.ParameterXml = " ";
       // alert(TaskApprovalFormFieldNameMaster.ParameterXml);
    },




    //Fire ajax call to insert update and delete record



AjaxCallTaskApprovalFormFieldNameMaster: function () {
    var TaskApprovalFormFieldNameMasterData = null;

    if (TaskApprovalFormFieldNameMaster.ActionName == "CreateTaskApprovalFormFieldNameMasterDetails") {
        //  debugger;
        $("#FormCreateTaskApprovalFormFieldNameMaster").validate();
        // if ($("#FormCreateTaskApprovalFormFieldNameMaster").valid())
        {
            TaskApprovalFormFieldNameMasterData = null;
            TaskApprovalFormFieldNameMasterData = TaskApprovalFormFieldNameMaster.GetTaskApprovalFormFieldNameMaster();
            ajaxRequest.makeRequest("/TaskApprovalFormFieldNameMaster/CreateTaskApprovalFormFieldNameMasterDetails", "POST", TaskApprovalFormFieldNameMasterData, TaskApprovalFormFieldNameMaster.Success);
        }
    }
        //else if (TaskApprovalFormFieldNameMaster.ActionName == "Edit") {
        //    $("#FormEditTaskApprovalFormFieldNameMaster").validate();
        //    if ($("#FormEditTaskApprovalFormFieldNameMaster").valid()) {
        //        TaskApprovalFormFieldNameMasterData = null;
        //        TaskApprovalFormFieldNameMasterData = TaskApprovalFormFieldNameMaster.GetTaskApprovalFormFieldNameMaster();
        //        ajaxRequest.makeRequest("/TaskApprovalFormFieldNameMaster/Edit", "POST", TaskApprovalFormFieldNameMasterData, TaskApprovalFormFieldNameMaster.Success);
        //    }
        //}
    else if (TaskApprovalFormFieldNameMaster.ActionName == "DeleteTaskApprovalFormFieldNameDetails") {

        TaskApprovalFormFieldNameMasterData = null;
        //$("#FormCreateTaskApprovalFormFieldNameMaster").validate();
        TaskApprovalFormFieldNameMasterData = TaskApprovalFormFieldNameMaster.GetTaskApprovalFormFieldNameMaster ();
        ajaxRequest.makeRequest("/TaskApprovalFormFieldNameMaster/DeleteTaskApprovalFormFieldNameDetails", "POST", TaskApprovalFormFieldNameMasterData, TaskApprovalFormFieldNameMaster.Success);

    }
},
    //Get properties data from the Create, Update and Delete page
    GetTaskApprovalFormFieldNameMaster: function ()
    {
        debugger;
        var Data = {
        };

        if (TaskApprovalFormFieldNameMaster.ActionName == "CreateTaskApprovalFormFieldNameMasterDetails")
        {
               Data.XMLstring                          =  TaskApprovalFormFieldNameMaster.ParameterXml;
               Data.TaskApprovalFormFieldMasterId      =      $('#TaskApprovalFormFieldMasterId').val();
          
        }
      
        else if (TaskApprovalFormFieldNameMaster.ActionName == "DeleteTaskApprovalFormFieldNameDetails")
        {

            Data.TaskApprovalFormFieldNameDetailsID = $('#TaskApprovalFormFieldNameDetailsID').val();
            // Data.ID = $('input[name=ID]').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {


        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            TaskApprovalFormFieldNameMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
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
//       TaskApprovalFormFieldNameMaster.ReloadList("Record Updated Sucessfully.", actionMode);
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
//        TaskApprovalFormFieldNameMaster.ReloadList("Record Deleted Sucessfully.");
//      //  alert("Record Deleted Sucessfully.");

//    } else {
//        parent.$.colorbox.close();
//       // alert("Record Not Deleted Sucessfully. Please Try Again..");
//    }


//},


