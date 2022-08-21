//this class contain methods related to nationality functionality
var AccountCategoryMasterReport = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        AccountCategoryMasterReport.constructor();
    },
    //Attach all event of page
    constructor: function () {
        $('#btnAccountCategoryMasterReportSubmit').on("click", function () {
            $("#AccBalsheetMstId").val($("#selectedBalsheetID").val());
            $("#SelectedHeadID").val();
            $("#SelectedCategoryID").val();
            $("#IsPosted").val(true);
        });


        $("#SelectedHeadID").change(function () {
            debugger;
            var selectedItem = $(this).val();
           
            var $ddlCategoryDetails = $("#SelectedCategoryID");
            var $CategoryDetailsProgress = $("#states-loading-progress");
            $CategoryDetailsProgress.show();
            if ($("#SelectedHeadID").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/AccountCategoryMasterReport/GetCategoryAccountHeadWise",
                    data: { "SelectedHeadID": selectedItem },
                    success: function (data) {
                        $ddlCategoryDetails.html('');
                        $ddlCategoryDetails.append('<option value="0">All</option>');


                        $.each(data, function (id, option) {

                            $ddlCategoryDetails.append($('<option></option>').val(option.id).html(option.name));
                        });

                        $CategoryDetailsProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Category.');
                        $BranchDetailsProgress.hide();
                    }
                });
            }
            else {
                $('#SelectedCategoryID').find('option').remove().end().append('<option value="0">All</option>');
            }
        });





    },

};