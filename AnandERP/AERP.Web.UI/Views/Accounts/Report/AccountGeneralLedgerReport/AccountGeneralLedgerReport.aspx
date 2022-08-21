<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title></title>
    <script runat="server">
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }

        AERP.Web.UI.Controllers.AccountGeneralLedgerReportController controller = new AERP.Web.UI.Controllers.AccountGeneralLedgerReportController();
        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvAccountGeneralLedgerReport);
            if (!IsPostBack)
            {
                List<AERP.DTO.AccountGeneralLedgerReport> AccountGeneralLedgerReport = null;
                List<AERP.DTO.OrganisationStudyCentreMaster> OrganisationStudyCentreMasterDetails = null;
                rvAccountGeneralLedgerReport.LocalReport.ReportPath = Server.MapPath("~/Report/AccountReports/AccountGeneralLedgerReport.rdlc");
                if (Request.RequestType == "POST")
                {
                    OrganisationStudyCentreMasterDetails = controller.GetReportHeader();
                    AccountGeneralLedgerReport = controller.GetAccountGeneralLedgerReportData(OrganisationStudyCentreMasterDetails.Count > 0 ? OrganisationStudyCentreMasterDetails[0].CentreCode : string.Empty);
                }
                if (AccountGeneralLedgerReport == null || AccountGeneralLedgerReport.Count == 0 || OrganisationStudyCentreMasterDetails == null || OrganisationStudyCentreMasterDetails.Count == 0)
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;
                    rvAccountGeneralLedgerReport.LocalReport.DataSources.Clear();

                    ReportDataSource rdc1 = new ReportDataSource();
                    rdc1.Name = "AccountGeneralLedgerReport";
                    rdc1.Value = AccountGeneralLedgerReport;
                    rvAccountGeneralLedgerReport.LocalReport.DataSources.Add(rdc1);
                    ReportDataSource rdc2 = new ReportDataSource();
                    rdc2.Name = "StudyCentreDetails";
                    rdc2.Value = OrganisationStudyCentreMasterDetails;
                    rvAccountGeneralLedgerReport.LocalReport.DataSources.Add(rdc2);

                    ReportParameter[] param = new ReportParameter[4];
                    param[0] = new ReportParameter("ConsolidiateType", AccountGeneralLedgerReport[0].ConsolidiateType, false);
                    param[1] = new ReportParameter("AccountName", AccountGeneralLedgerReport[0].AccountName, false);
                    param[2] = new ReportParameter("FromDate", AccountGeneralLedgerReport[0].FromDate, false);
                    param[3] = new ReportParameter("ToDate", AccountGeneralLedgerReport[0].ToDate, false);
                    rvAccountGeneralLedgerReport.LocalReport.SetParameters(param);
                    rvAccountGeneralLedgerReport.Visible = true;
                }

            }
        }

    </script>
</head>
<body>
    <form runat="server">
        <div id="MainDiv" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div id="dataDiv">
                <rsweb:ReportViewer ID="rvAccountGeneralLedgerReport" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="99%" SizeToReportContent="True">
                    <LocalReport ReportEmbeddedResource="AERP.Web.UI.Report.AccountReports.AccountGeneralLedgerReport.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="StudyCentreDetails" />
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="AccountGeneralLedgerReport" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>
                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetData" TypeName="AERPDataSet3TableAdapters.AccountGeneralLedgerReportTableAdapter"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="AERPDataSetTableAdapters.OrgStudyCentrePrintingFormatTableAdapter"></asp:ObjectDataSource>
            </div>
        </div>
        <div id="NoRecordDiv" runat="server" style="text-align: center;">

            <b>No Record Found</b>

        </div>
    </form>
</body>
</html>

