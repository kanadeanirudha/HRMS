<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Account Category Report</title>
    <script runat="server">
   
        AERP.Web.UI.Controllers.AccountCategoryMasterReportController controller = new AERP.Web.UI.Controllers.AccountCategoryMasterReportController();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }
        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvAccountCategoryReport);

            rvAccountCategoryReport.ProcessingMode = ProcessingMode.Local;

            List<AERP.DTO.AccountCategoryMasterReport> AccountCategoryMasterReport = null;
            List<AERP.DTO.OrganisationStudyCentreMaster> OrganisationStudyCentreMasterDetails = null;

            if (Request.RequestType == "POST")
            {
                OrganisationStudyCentreMasterDetails = controller.GetReportHeader();
                AccountCategoryMasterReport = controller.GetCategoryDetailsForReport();
            }

            if (AccountCategoryMasterReport == null || OrganisationStudyCentreMasterDetails == null)
            {
                MainDiv.Visible = false;
                NoRecordDiv.Visible = true;
            }
            else
            {
                MainDiv.Visible = true;
                NoRecordDiv.Visible = false;
                rvAccountCategoryReport.LocalReport.ReportPath = Server.MapPath("~/Report/AccountReports/AccountCategoryReport.rdlc");
                rvAccountCategoryReport.LocalReport.DataSources.Clear();

                ReportDataSource rdc = new ReportDataSource();
                rdc.Name = "DataSetAccountCategoryMasterReport";
                rdc.Value = AccountCategoryMasterReport;
                rvAccountCategoryReport.LocalReport.DataSources.Add(rdc);

                ReportDataSource rdc2 = new ReportDataSource();
                rdc2.Name = "StudyCentrePrintingFormat";
                rdc2.Value = OrganisationStudyCentreMasterDetails;
                rvAccountCategoryReport.LocalReport.DataSources.Add(rdc2);

                rvAccountCategoryReport.LocalReport.Refresh();
                rvAccountCategoryReport.Visible = true;
            }
        }




    </script>
</head>
<body>
    <form runat="server">
        <div id="MainDiv" runat="server">
            <div id="categoryPrint">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                <rsweb:ReportViewer ID="rvAccountCategoryReport" runat="server" AsyncRendering="false" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="" SizeToReportContent="True">
                    <LocalReport ReportEmbeddedResource="AERP.Web.UI.Report.AccountReports.AccountCategoryReport.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSetAccountCategoryMasterReport" />
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="StudyCentrePrintingFormat" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>

            </div>

            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="AERPDataSetTableAdapters.USP_AccountCategoryMaster_ReportTableAdapter"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetData" TypeName="AERPDataSetTableAdapters.OrgStudyCentrePrintingFormatTableAdapter"></asp:ObjectDataSource>

        </div>
        <div id="NoRecordDiv" runat="server" style="text-align: center;">

            <b>No Record Found</b>

        </div>
       
    </form>
</body>
</html>

<script type="text/javascript">
    $(document).ready(function () {
        AccountCategoryMasterReport.Initialize();
    });
</script>
