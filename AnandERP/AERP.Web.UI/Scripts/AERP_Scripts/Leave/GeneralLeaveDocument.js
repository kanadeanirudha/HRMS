////this class contain methods related to nationality functionality
//var GeneralLeaveDocument = {
//    //Member variables
//    ActionName: null,
//    //Class intialisation method
//    Initialize: function () {
//        //organisationStudyCentre.loadData();

//        GeneralLeaveDocument.constructor();
//        //GeneralLeaveDocument.initializeValidation();
//    },
//    //Attach all event of page
//    constructor: function () {

//        $('#CountryName').focus();

//        $("#reset").click(function () {

//            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
//            $('input:checkbox,input:radio').removeAttr('checked');
//            $('#DocumentName').focus();
          
//            return false;
//        });


//        // Create new record
//        $('#CreateGeneralLeaveDocumentRecord').on("click", function () {
//            GeneralLeaveDocument.ActionName = "Create";
//            GeneralLeaveDocument.AjaxCallGeneralLeaveDocument();
//        });

//        $('#EditGeneralLeaveDocumentRecord').on("click", function () {
            
//            GeneralLeaveDocument.ActionName = "Edit";
//            GeneralLeaveDocument.AjaxCallGeneralLeaveDocument();
//        });

//        $('#DeleteGeneralLeaveDocumentRecord').on("click", function () {

//            GeneralLeaveDocument.ActionName = "Delete";
//            GeneralLeaveDocument.AjaxCallGeneralLeaveDocument();
//        });

       
//        $('#DocumentName').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);            
//        });

//        $("#UserSearch").keyup(function () {
//            var oTable = $("#myDataTable").dataTable();
//            oTable.fnFilter(this.value);
//        });

//        $("#searchBtn").click(function () {
//            $("#UserSearch").focus();
//        });


//        $("#showrecord").change(function () {
//            var showRecord = $("#showrecord").val();
//            $("select[name*='myDataTable_length']").val(showRecord);
//            $("select[name*='myDataTable_length']").change();
//        });

//        //$(".ajax").colorbox();
//        InitAnimatedBorder();
//        CloseAlert();



//    },
//    ////Load method is used to load *-Load-* page
//    LoadList: function () {

//        $.ajax(
//         {
//             cache: false,
//             type: "POST",

//             dataType: "html",
//             url: '/GeneralLeaveDocument/List',
//             success: function (data) {
//                 //Rebind Grid Data
//                 $('#ListViewModel').html(data);
//             }
//         });
//    },
//    //ReloadList method is used to load List page
//    ReloadList: function (message, colorCode, actionMode) {

//        $.ajax(
//        {
//            cache: false,
//            type: "POST",
//            dataType: "html",
//            data: { "actionMode": actionMode },
//            url: '/GeneralLeaveDocument/List',
//            success: function (data) {
//                //Rebind Grid Data
//                $("#ListViewModel").empty().append(data);
//                //twitter type notification
//                $('#SuccessMessage').html(message);
//                $('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
//            }
//        });
//    },


//    //Fire ajax call to insert update and delete record
//    AjaxCallGeneralLeaveDocument: function () {
//        var GeneralLeaveDocumentData = null;
//        if (GeneralLeaveDocument.ActionName == "Create") {
//            $("#FormCreateGeneralLeaveDocument").validate();
//            if ($("#FormCreateGeneralLeaveDocument").valid()) {
//                GeneralLeaveDocumentData = null;
//                GeneralLeaveDocumentData = GeneralLeaveDocument.GetGeneralLeaveDocument();
//                ajaxRequest.makeRequest("/GeneralLeaveDocument/Create", "POST", GeneralLeaveDocumentData, GeneralLeaveDocument.Success);
//            }
//        }
//        else if (GeneralLeaveDocument.ActionName == "Edit") {
//            $("#FormEditGeneralLeaveDocument").validate();
//            if ($("#FormEditGeneralLeaveDocument").valid()) {
//                GeneralLeaveDocumentData = null;
//                GeneralLeaveDocumentData = GeneralLeaveDocument.GetGeneralLeaveDocument();
//                ajaxRequest.makeRequest("/GeneralLeaveDocument/Edit", "POST", GeneralLeaveDocumentData, GeneralLeaveDocument.Success);
//            }
//        }
//        else if (GeneralLeaveDocument.ActionName == "Delete") {
//            GeneralLeaveDocumentData = null;
//            //$("#FormCreateGeneralLeaveDocument").validate();
//            GeneralLeaveDocumentData = GeneralLeaveDocument.GetGeneralLeaveDocument();
//            ajaxRequest.makeRequest("/GeneralLeaveDocument/Delete", "POST", GeneralLeaveDocumentData, GeneralLeaveDocument.Success);

//        }
//    },
//    //Get properties data from the Create, Update and Delete page
//    GetGeneralLeaveDocument: function () {
//        var Data = {
//        };
        
//        if (GeneralLeaveDocument.ActionName == "Create" || GeneralLeaveDocument.ActionName == "Edit") {
//            Data.ID = $('input[name=ID]').val();
//            Data.DocumentName = $('#DocumentName').val();
//            Data.DocumentType = $('#DocumentType').val();
//            Data.DocumentDescription = $('#DocumentDescription').val();           
//        }
//        else if (GeneralLeaveDocument.ActionName == "Delete") {
//            Data.ID = $('#ID').val();
//        }
//        return Data;
//    },

//    //this is used to for showing successfully record creation message and reload the list view
//    Success: function (data) {
//        var splitData = data.split(',');
//        if (data != null) {
//            parent.$.colorbox.close();
//            GeneralLeaveDocument.ReloadList(splitData[0], splitData[1], splitData[2]);
//        } else {
//            parent.$.colorbox.close();
//            GeneralLeaveDocument.ReloadList(splitData[0], splitData[1], splitData[2]);
//        }

//    },
//    //this is used to for showing successfully record updation message and reload the list view
//    //editSuccess: function (data) {



//    //    if (data == "True") {

//    //        parent.$.colorbox.close();
//    //        var actionMode = "1";
//    //        GeneralLeaveDocument.ReloadList("Record Updated Sucessfully.", actionMode);
//    //        //  alert("Record Created Sucessfully.");

//    //    } else {
//    //        parent.$.colorbox.close();
//    //        // alert("Record Not Updated Sucessfully. Please Try Again..");
//    //    }

//    //},
//    ////this is used to for showing successfully record deletion message and reload the list view
//    //deleteSuccess: function (data) {


//    //    if (data == "True") {

//    //        parent.$.colorbox.close();
//    //        GeneralLeaveDocument.ReloadList("Record Deleted Sucessfully.");
//    //      //  alert("Record Deleted Sucessfully.");

//    //    } else {
//    //        parent.$.colorbox.close();
//    //       // alert("Record Not Deleted Sucessfully. Please Try Again..");
//    //    }


//    //},
//};

//////////////////////////////////////////new js////////////////////////////////////

//this class contain methods related to nationality functionality
var GeneralLeaveDocument = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        GeneralLeaveDocument.constructor();
        //GeneralLeaveDocument.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#CountryName').focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#DocumentName').focus();
            $('#DocumentType').val('');
            return false;
        });


        // Create new record
        $('#CreateGeneralLeaveDocumentRecord').on("click", function () {
            GeneralLeaveDocument.ActionName = "Create";
            GeneralLeaveDocument.AjaxCallGeneralLeaveDocument();
        });

        $('#EditGeneralLeaveDocumentRecord').on("click", function () {

            GeneralLeaveDocument.ActionName = "Edit";
            GeneralLeaveDocument.AjaxCallGeneralLeaveDocument();
        });

        $('#DeleteGeneralLeaveDocumentRecord').on("click", function () {

            GeneralLeaveDocument.ActionName = "Delete";
            GeneralLeaveDocument.AjaxCallGeneralLeaveDocument();
        });


        $('#DocumentName').on("keydown", function (e) {
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



    },
    ////Load method is used to load *-Load-* page
    LoadList: function () {

        $.ajax(
         {
             cache: false,
             type: "POST",

             dataType: "html",
             url: '/GeneralLeaveDocument/List',
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
            data: { "actionMode": actionMode },
            url: '/GeneralLeaveDocument/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
                notify(message,"success");
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallGeneralLeaveDocument: function () {
        var GeneralLeaveDocumentData = null;
        if (GeneralLeaveDocument.ActionName == "Create") {
            $("#FormCreateGeneralLeaveDocument").validate();
            if ($("#FormCreateGeneralLeaveDocument").valid()) {
                GeneralLeaveDocumentData = null;
                GeneralLeaveDocumentData = GeneralLeaveDocument.GetGeneralLeaveDocument();
                ajaxRequest.makeRequest("/GeneralLeaveDocument/Create", "POST", GeneralLeaveDocumentData, GeneralLeaveDocument.Success);
            }
        }
        else if (GeneralLeaveDocument.ActionName == "Edit") {
            $("#FormEditGeneralLeaveDocument").validate();
            if ($("#FormEditGeneralLeaveDocument").valid()) {
                GeneralLeaveDocumentData = null;
                GeneralLeaveDocumentData = GeneralLeaveDocument.GetGeneralLeaveDocument();
                ajaxRequest.makeRequest("/GeneralLeaveDocument/Edit", "POST", GeneralLeaveDocumentData, GeneralLeaveDocument.Success);
            }
        }
        else if (GeneralLeaveDocument.ActionName == "Delete") {
            GeneralLeaveDocumentData = null;
            //$("#FormCreateGeneralLeaveDocument").validate();
            GeneralLeaveDocumentData = GeneralLeaveDocument.GetGeneralLeaveDocument();
            ajaxRequest.makeRequest("/GeneralLeaveDocument/Delete", "POST", GeneralLeaveDocumentData, GeneralLeaveDocument.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetGeneralLeaveDocument: function () {
        var Data = {
        };

        if (GeneralLeaveDocument.ActionName == "Create" || GeneralLeaveDocument.ActionName == "Edit") {
            Data.ID = $('input[name=ID]').val();
            Data.DocumentName = $('#DocumentName').val();
            Data.DocumentType = $('#DocumentType').val();
            Data.DocumentDescription = $('#DocumentDescription').val();
        }
        else if (GeneralLeaveDocument.ActionName == "Delete") {
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
            GeneralLeaveDocument.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            GeneralLeaveDocument.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    
};

