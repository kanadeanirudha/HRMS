////this class contain methods related to nationality functionality
//var EmployeeSpecializationResearchAreaDetails = {
//    //Member variables
//    ActionName: null,
//    //Class intialisation method
//    Initialize: function () {
//        //organisationStudyCentre.loadData();

//        EmployeeSpecializationResearchAreaDetails.constructor();
//        //EmployeeSpecializationResearchAreaDetails.initializeValidation();
//    },
//    //Attach all event of page
//    constructor: function () {
//        $("#reset").click(function () {

//            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
//            $('input:checkbox,input:radio').removeAttr('checked');
//            $('#SpecializationField').focus();
//            $('#SpecializationField').val('');
//        });


//        // Create new record
//        $('#CreateEmployeeSpecializationResearchAreaDetailsRecord').on("click", function () {
//            EmployeeSpecializationResearchAreaDetails.ActionName = "Create";
//            EmployeeSpecializationResearchAreaDetails.AjaxCallEmployeeSpecializationResearchAreaDetails();
//        });

//        $('#EditEmployeeSpecializationResearchAreaDetailsRecord').on("click", function () {
//            EmployeeSpecializationResearchAreaDetails.ActionName = "Edit";
//            EmployeeSpecializationResearchAreaDetails.AjaxCallEmployeeSpecializationResearchAreaDetails();
//        });

//        $('#DeleteEmployeeSpecializationResearchAreaDetailsRecord').on("click", function () {

//            EmployeeSpecializationResearchAreaDetails.ActionName = "Delete";
//            EmployeeSpecializationResearchAreaDetails.AjaxCallEmployeeSpecializationResearchAreaDetails();
//        });
//        $('#Description').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
//        });
//        $("#UserSearch").keyup(function () {
//            oTable = $("#myDataTable").dataTable();
//            oTable.fnFilter(this.value);
//        });

//        $("#searchBtn").click(function () {
//            $("#UserSearch").focus();
//        });

//        $('#SpecializationField').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
//        });


//        $("#showrecord").change(function () {
//            var showRecord = $("#showrecord").val();
//            $("select[name*='myDataTable_length']").val(showRecord);
//            $("select[name*='myDataTable_length']").change();
//        });

//        $(".ajax").colorbox();


//    },
//    //LoadList method is used to load List page
//    LoadList: function () {
//        var EmployeeID = $("#EmployeeID").val();
//        $.ajax(
//         {
//             cache: false,
//             type: "POST",
//             dataType: "html",
//             data: { "EmployeeID": EmployeeID },

//             url: '/EmployeeSpecializationResearchAreaDetails/List',

//             success: function (data) {
//                 //Rebind Grid Data
//                 $('#ListViewModel').html(data);
//             }
//         });
//    },
//    //ReloadList method is used to load List page
//    ReloadList: function (message, colorCode, actionMode) {
//        var EmployeeID = $("#EmployeeID").val();
//        $.ajax(
//        {
//            cache: false,
//            type: "POST",
//            dataType: "html",
//            url: '/EmployeeSpecializationResearchAreaDetails/List',
//            data: { "actionMode": actionMode, "EmployeeID": EmployeeID },

//            success: function (data) {
//                //Rebind Grid Data
//                $("#ListViewModel").empty().append(data);
//                //twitter type notification
//                $('#EmployeeFormStatusMessages').html(message);
//                $('#EmployeeFormStatusMessages').delay(600).slideDown('slow').delay(1000).slideUp(2000).css('background-color', colorCode);
//            }
//        });
//    },


//    //Fire ajax call to insert update and delete record
//    AjaxCallEmployeeSpecializationResearchAreaDetails: function () {
//        var EmployeeSpecializationResearchAreaDetailsData = null;
//        if (EmployeeSpecializationResearchAreaDetails.ActionName == "Create") {

//            $("#FormCreateEmployeeSpecializationResearchAreaDetails").validate();
//            if ($("#FormCreateEmployeeSpecializationResearchAreaDetails").valid()) {
//                EmployeeSpecializationResearchAreaDetailsData = null;
//                EmployeeSpecializationResearchAreaDetailsData = EmployeeSpecializationResearchAreaDetails.GetEmployeeSpecializationResearchAreaDetails();
//                ajaxRequest.makeRequest("/EmployeeSpecializationResearchAreaDetails/Create", "POST", EmployeeSpecializationResearchAreaDetailsData, EmployeeSpecializationResearchAreaDetails.Success);
//            }
//        }
//        else if (EmployeeSpecializationResearchAreaDetails.ActionName == "Edit") {
//            $("#FormEditEmployeeSpecializationResearchAreaDetails").validate();
//            if ($("#FormEditEmployeeSpecializationResearchAreaDetails").valid()) {
//                EmployeeSpecializationResearchAreaDetailsData = null;
//                EmployeeSpecializationResearchAreaDetailsData = EmployeeSpecializationResearchAreaDetails.GetEmployeeSpecializationResearchAreaDetails();
//                ajaxRequest.makeRequest("/EmployeeSpecializationResearchAreaDetails/Edit", "POST", EmployeeSpecializationResearchAreaDetailsData, EmployeeSpecializationResearchAreaDetails.Success);
//            }
//        }
//        else if (EmployeeSpecializationResearchAreaDetails.ActionName == "Delete") {
//            EmployeeSpecializationResearchAreaDetailsData = null;
//            $("#FormDeleteEmployeeSpecializationResearchAreaDetails").validate();
//            EmployeeSpecializationResearchAreaDetailsData = EmployeeSpecializationResearchAreaDetails.GetEmployeeSpecializationResearchAreaDetails();
//            ajaxRequest.makeRequest("/EmployeeSpecializationResearchAreaDetails/Delete", "POST", EmployeeSpecializationResearchAreaDetailsData, EmployeeSpecializationResearchAreaDetails.Success);

//        }
//    },
//    //Get properties data from the Create, Update and Delete page
//    GetEmployeeSpecializationResearchAreaDetails: function () {
//        var Data = {
//        };
//        if (EmployeeSpecializationResearchAreaDetails.ActionName == "Create" || EmployeeSpecializationResearchAreaDetails.ActionName == "Edit") {
//            Data.ID = $('#ID').val();
//            Data.EmployeeID = $("#EmployeeID").val()
//            Data.SpecializationField = $('#SpecializationField').val();
//            Data.ResearchArea = $('#ResearchArea').val();

//        }
//        else if (EmployeeSpecializationResearchAreaDetails.ActionName == "Delete") {
//            Data.ID = $('#ID').val();
//        }
//        return Data;
//    },


//    //this is used to for showing successfully record creation message and reload the list view
//    Success: function (data) {
//        var splitData = data.split(',');
//        if (data != null) {
//            parent.$.colorbox.close();
//            EmployeeSpecializationResearchAreaDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
//        } else {
//            parent.$.colorbox.close();
//            EmployeeSpecializationResearchAreaDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
//        }

//    },
//    //this is used to for showing successfully record updation message and reload the list view
//    //editSuccess: function (data) {

//    //    
//    //    
//    //    if (data == "True") {

//    //        parent.$.colorbox.close();
//    //        var actionMode = "1";
//    //        EmployeeSpecializationResearchAreaDetails.ReloadList("Record Updated Sucessfully.", actionMode);
//    //        //  alert("Record Created Sucessfully.");

//    //    } else {
//    //        parent.$.colorbox.close();
//    //        // alert("Record Not Updated Sucessfully. Please Try Again..");
//    //    }

//    //},
//    ////this is used to for showing successfully record deletion message and reload the list view
//    //deleteSuccess: function (data) {

//    //    
//    //    if (data == "True") {

//    //        parent.$.colorbox.close();
//    //        EmployeeSpecializationResearchAreaDetails.ReloadList("Record Deleted Sucessfully.");
//    //        //  alert("Record Deleted Sucessfully.");

//    //    } else {
//    //        parent.$.colorbox.close();
//    //        // alert("Record Not Deleted Sucessfully. Please Try Again..");
//    //    }


//    //},
//};

/////////////////////////new js//////////////////////////////

//this class contain methods related to nationality functionality
var EmployeeSpecializationResearchAreaDetails = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        EmployeeSpecializationResearchAreaDetails.constructor();
        //EmployeeSpecializationResearchAreaDetails.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {
        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#SpecializationField').focus();
            $('#SpecializationField').val('');
        });


        // Create new record
        $('#CreateEmployeeSpecializationResearchAreaDetailsRecord').on("click", function () {
            EmployeeSpecializationResearchAreaDetails.ActionName = "Create";
            EmployeeSpecializationResearchAreaDetails.AjaxCallEmployeeSpecializationResearchAreaDetails();
        });

        $('#EditEmployeeSpecializationResearchAreaDetailsRecord').on("click", function () {
            EmployeeSpecializationResearchAreaDetails.ActionName = "Edit";
            EmployeeSpecializationResearchAreaDetails.AjaxCallEmployeeSpecializationResearchAreaDetails();
        });

        $('#DeleteEmployeeSpecializationResearchAreaDetailsRecord').on("click", function () {

            EmployeeSpecializationResearchAreaDetails.ActionName = "Delete";
            EmployeeSpecializationResearchAreaDetails.AjaxCallEmployeeSpecializationResearchAreaDetails();
        });
        $('#Description').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $("#UserSearch").keyup(function () {
            oTable = $("#myDataTable").dataTable();
            oTable.fnFilter(this.value);
        });

        $("#searchBtn").click(function () {
            $("#UserSearch").focus();
        });

        $('#SpecializationField').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });


        $("#showrecord").change(function () {
            var showRecord = $("#showrecord").val();
            $("select[name*='myDataTable_length']").val(showRecord);
            $("select[name*='myDataTable_length']").change();
        });

        //$(".ajax").colorbox();
        InitAnimatedBorder();
        CloseAlert();


    },
    //LoadList method is used to load List page
    LoadList: function () {
        var EmployeeID = $("#EmployeeID").val();
        $.ajax(
         {
             cache: false,
             type: "POST",
             dataType: "html",
             data: { "EmployeeID": EmployeeID },

             url: '/EmployeeSpecializationResearchAreaDetails/List',

             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        var EmployeeID = $("#EmployeeID").val();
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            url: '/EmployeeSpecializationResearchAreaDetails/List',
            data: { "actionMode": actionMode, "EmployeeID": EmployeeID },

            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#EmployeeFormStatusMessages').html(message);
                //$('#EmployeeFormStatusMessages').delay(600).slideDown('slow').delay(1000).slideUp(2000).css('background-color', colorCode);
                notify(message,"success");
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallEmployeeSpecializationResearchAreaDetails: function () {
        var EmployeeSpecializationResearchAreaDetailsData = null;
        if (EmployeeSpecializationResearchAreaDetails.ActionName == "Create") {

            $("#FormCreateEmployeeSpecializationResearchAreaDetails").validate();
            if ($("#FormCreateEmployeeSpecializationResearchAreaDetails").valid()) {
                EmployeeSpecializationResearchAreaDetailsData = null;
                EmployeeSpecializationResearchAreaDetailsData = EmployeeSpecializationResearchAreaDetails.GetEmployeeSpecializationResearchAreaDetails();
                ajaxRequest.makeRequest("/EmployeeSpecializationResearchAreaDetails/Create", "POST", EmployeeSpecializationResearchAreaDetailsData, EmployeeSpecializationResearchAreaDetails.Success);
            }
        }
        else if (EmployeeSpecializationResearchAreaDetails.ActionName == "Edit") {
            $("#FormEditEmployeeSpecializationResearchAreaDetails").validate();
            if ($("#FormEditEmployeeSpecializationResearchAreaDetails").valid()) {
                EmployeeSpecializationResearchAreaDetailsData = null;
                EmployeeSpecializationResearchAreaDetailsData = EmployeeSpecializationResearchAreaDetails.GetEmployeeSpecializationResearchAreaDetails();
                ajaxRequest.makeRequest("/EmployeeSpecializationResearchAreaDetails/Edit", "POST", EmployeeSpecializationResearchAreaDetailsData, EmployeeSpecializationResearchAreaDetails.Success);
            }
        }
        else if (EmployeeSpecializationResearchAreaDetails.ActionName == "Delete") {
            EmployeeSpecializationResearchAreaDetailsData = null;
            $("#FormDeleteEmployeeSpecializationResearchAreaDetails").validate();
            EmployeeSpecializationResearchAreaDetailsData = EmployeeSpecializationResearchAreaDetails.GetEmployeeSpecializationResearchAreaDetails();
            ajaxRequest.makeRequest("/EmployeeSpecializationResearchAreaDetails/Delete", "POST", EmployeeSpecializationResearchAreaDetailsData, EmployeeSpecializationResearchAreaDetails.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetEmployeeSpecializationResearchAreaDetails: function () {
        var Data = {
        };
        if (EmployeeSpecializationResearchAreaDetails.ActionName == "Create" || EmployeeSpecializationResearchAreaDetails.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.EmployeeID = $("#EmployeeID").val()
            Data.SpecializationField = $('#SpecializationField').val();
            Data.ResearchArea = $('#ResearchArea').val();

        }
        else if (EmployeeSpecializationResearchAreaDetails.ActionName == "Delete") {
            Data.ID = $('#ID').val();
        }
        return Data;
    },


    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (data != null) {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            EmployeeSpecializationResearchAreaDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            EmployeeSpecializationResearchAreaDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    
};

