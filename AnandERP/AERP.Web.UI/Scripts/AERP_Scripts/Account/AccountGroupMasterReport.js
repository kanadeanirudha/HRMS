//this class contain methods related to nationality functionality
var AccountGroupMasterReport = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        AccountGroupMasterReport.constructor();
    },
    //Attach all event of page
    constructor: function () {
    
        $('#btnAccountGroupMasterReportSubmit').on("click", function () {
            $("#AccountBalsheetMstID").val($("#selectedBalsheetID").val());
            $("#SelectedHeadID").val();
            $("#SelectedCategoryID").val();
            $("#SelectedGroupID").val();
            $("#IsPosted").val(true);
        });


        $("#SelectedHeadID").change(function () {
            debugger;
            var selectedItem = $(this).val();
           
            var $ddlCategoryDetails = $("#SelectedCategoryID");
            var $CategoryDetailsProgress = $("#states-loading-progress");
            $CategoryDetailsProgress.show();
            if ($("#SelectedHeadID").val() != '') {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/AccountCategoryMasterReport/GetCategoryAccountHeadWise",
                    data: { "SelectedHeadID": selectedItem },
                    success: function (data) {
                        $ddlCategoryDetails.html('');
                        $ddlCategoryDetails.append('<option value="0">All</option>');


                        $.each(data, function (id, option) {

                            $ddlCategoryDetails.append($('<option value="0">All</option>').val(option.id).html(option.name));

                        });

                        $CategoryDetailsProgress.hide();
                        $('#SelectedGroupID').find('option').remove().end().append('<option value="0">All</option>');
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Category.');
                        $BranchDetailsProgress.hide();
                    }
                });
            }
            else {
                $('#SelectedCategoryID').find('option').remove().end().append('<option value="0">All</option>');
                $('#SelectedGroupID').find('option').remove().end().append('<option value="0">All</option>');
            }
        });

        $("#SelectedCategoryID").change(function () {
            debugger;
            var selectedItem = $(this).val();

            var $ddlGroupDetails = $("#SelectedGroupID");
            var $GroupDetailsProgress = $("#states-loading-progress");
            $GroupDetailsProgress.show();
            if ($("#SelectedCategoryID").val() != '') {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/AccountGroupMasterReport/GetGroupAccountCategoryWise",
                    data: { "SelectedCategoryID": selectedItem },
                    success: function (data) {
                        $ddlGroupDetails.html('');
                        $ddlGroupDetails.append('<option value="0">All</option>');


                        $.each(data, function (id, option) {

                            $ddlGroupDetails.append($('<option value="0">All</option>').val(option.id).html(option.name));

                           
                        });

                        $GroupDetailsProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Category.');
                        $GroupDetailsProgress.hide();
                    }
                });
            }
            else {
                $('#SelectedGroupID').find('option').remove().end().append('<option value="0">All</option>');
            }
        });

       

        //$("#SelectedCategoryID").attr("disabled", true);
        //$("#SelectedGroupID").attr("disabled", true);
       // $("#btnShow").hide();

    },
   
};