//this class contain methods related to nationality functionality
var OrganisationStudyCentrePrintingFormat = {
    //Member variables
    ActionName: null,
    LogoPathName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        OrganisationStudyCentrePrintingFormat.constructor();
        //OrganisationStudyCentrePrintingFormat.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {
        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#RegionID').focus();
            $('#RegionID').val('');
        });

        

        $("#closeBt").on('click', function () {
            $.magnificPopup.close();
            OrganisationStudyCentrePrintingFormat.LoadList();
        });

        // Create new record
        $('#CreateOrganisationStudyCentrePrintingFormatRecord').on("click", function () {

            OrganisationStudyCentrePrintingFormat.ActionName = "Create";
            OrganisationStudyCentrePrintingFormat.AjaxCallOrganisationStudyCentrePrintingFormat();
        });

        $('#EditOrganisationStudyCentrePrintingFormatRecord').on("click", function () {

            OrganisationStudyCentrePrintingFormat.GetLogo();
            OrganisationStudyCentrePrintingFormat.ActionName = "Edit";
            OrganisationStudyCentrePrintingFormat.AjaxCallOrganisationStudyCentrePrintingFormat();
        });

        $('#DeleteOrganisationStudyCentrePrintingFormatRecord').on("click", function () {

            OrganisationStudyCentrePrintingFormat.ActionName = "Delete";
            OrganisationStudyCentrePrintingFormat.AjaxCallOrganisationStudyCentrePrintingFormat();
        });
        $('#WeekDescription').on("keydown", function (e) {
            AERPValidation.AllowCharacterOnly(e);
        });
        $("#UserSearch").keyup(function () {
            oTable = $("#myDataTable").dataTable();
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
    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax(

         {

             cache: false,
             type: "POST",

             dataType: "html",
             url: '/OrganisationStudyCentrePrintingFormat/List',
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
            url: '/OrganisationStudyCentrePrintingFormat/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', colorCode);
                notify(message,colorCode);
            }
        });
    },

    GetLogo: function (eventClick) {
        var imgValue = new FormData();
        var files = $("#LogoFile").get(0).files;
        alert(files[0]);
        if (files.length > 0 && (OrganisationStudyCentrePrintingFormat.LogoPathName == null || OrganisationStudyCentrePrintingFormat.LogoPathName == "")) {
            imgValue.append("MyImages", files[0]);

            $.ajax({
                url: "/OrganisationStudyCentrePrintingFormat/UploadFile",
                type: "POST",
                processData: false,
                contentType: false,
                data: imgValue,
                dataType: 'json',
                async: false,
                success: function (imgValue) {
                    $("#displayErrorMessage p").text("Uploading Logo...").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                    $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                    OrganisationStudyCentrePrintingFormat.LogoPathName = imgValue;
                },
                error: function (er) {
                    alert(er);
                }
            });
        }
    },

    //Fire ajax call to insert update and delete record
    AjaxCallOrganisationStudyCentrePrintingFormat: function () {
        var OrganisationStudyCentrePrintingFormatData = null;
        if (OrganisationStudyCentrePrintingFormat.ActionName == "Create") {
            $("#FormCreateOrganisationStudyCentrePrintingFormat").validate();
            if ($("#FormCreateOrganisationStudyCentrePrintingFormat").valid()) {
                OrganisationStudyCentrePrintingFormatData = null;
                OrganisationStudyCentrePrintingFormatData = OrganisationStudyCentrePrintingFormat.GetOrganisationStudyCentrePrintingFormat();
                ajaxRequest.makeRequest("/OrganisationStudyCentrePrintingFormat/Create", "POST", OrganisationStudyCentrePrintingFormatData, OrganisationStudyCentrePrintingFormat.Success);
            }
        }
        else if (OrganisationStudyCentrePrintingFormat.ActionName == "Edit") {
            $("#FormEditOrganisationStudyCentrePrintingFormat").validate();
            if ($("#FormEditOrganisationStudyCentrePrintingFormat").valid()) {
                OrganisationStudyCentrePrintingFormatData = null;
                OrganisationStudyCentrePrintingFormatData = OrganisationStudyCentrePrintingFormat.GetOrganisationStudyCentrePrintingFormat();
                ajaxRequest.makeRequest("/OrganisationStudyCentrePrintingFormat/Edit", "POST", OrganisationStudyCentrePrintingFormatData, OrganisationStudyCentrePrintingFormat.Success);
            }
        }
        else if (OrganisationStudyCentrePrintingFormat.ActionName == "Delete") {
            OrganisationStudyCentrePrintingFormatData = null;
            $("#FormDeleteOrganisationStudyCentrePrintingFormat").validate();
            OrganisationStudyCentrePrintingFormatData = OrganisationStudyCentrePrintingFormat.GetOrganisationStudyCentrePrintingFormat();
            ajaxRequest.makeRequest("/OrganisationStudyCentrePrintingFormat/Delete", "POST", OrganisationStudyCentrePrintingFormatData, OrganisationStudyCentrePrintingFormat.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetOrganisationStudyCentrePrintingFormat: function () {
        var Data = {
        };
        if (OrganisationStudyCentrePrintingFormat.ActionName == "Create" || OrganisationStudyCentrePrintingFormat.ActionName == "Edit") {
            var LogoFileSize = null;
            var LogoType = null;
            var LogoFilename = null;
            var LogoFileWidth = null;
            var LogoFileHeight = null;

            var img = document.getElementById('previewLogo');
            if ($("#LogoFile").val() != "") {
                if (typeof ($("#LogoFile")[0].files) != "undefined") {
                    LogoFileSize = parseFloat($("#LogoFile")[0].files[0].size / 1024).toFixed(2);
                    LogoType = $('#LogoFile')[0].files[0].type;
                    LogoFilename = $('#LogoFile')[0].files[0].name;
                    LogoFileWidth = img.width;
                    LogoFileHeight = img.height;
                }


                if (LogoType == "image/jpeg") {
                    Data.Logo = $('#previewLogo').attr('src').replace(/data:image\/jpeg;base64,/g, '');
                }
                else if (LogoType == "image/png") {
                    Data.Logo = $('#previewLogo').attr('src').replace(/data:image\/png;base64,/g, '');
                }
                else if (LogoType == "image/gif") {
                    Data.Logo = $('#previewLogo').attr('src').replace(/data:image\/gif;base64,/g, '');
                }
                else if (LogoType == "image/jpg") {
                    Data.Logo = $('#previewLogo').attr('src').replace(/data:image\/jpg;base64,/g, '');
                }
                else if (LogoType == "image/bmp") {
                    Data.Logo = $('#previewLogo').attr('src').replace(/data:image\/bmp;base64,/g, '');
                }

                Data.LogoType = LogoType;
                Data.LogoFilename = LogoFilename;
                Data.LogoFileWidth = LogoFileWidth;
                Data.LogoFileHeight = LogoFileHeight;
                Data.LogoFileSize = LogoFileSize;
            }
            Data.ID = $('#ID').val();
            Data.CentreCode = $('#CentreCode').val();
            Data.PrintingLine1 = $('#PrintingLine1').val();
            Data.PrintingLine2 = $('#PrintingLine2').val();
            Data.PrintingLine3 = $('#PrintingLine3').val();
            Data.PrintingLine4 = $('#PrintingLine4').val();
            //Data.Logo = $('#
            //    ').val();
        }
        else if (OrganisationStudyCentrePrintingFormat.ActionName == "Delete") {
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
            OrganisationStudyCentrePrintingFormat.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            OrganisationStudyCentrePrintingFormat.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
};

