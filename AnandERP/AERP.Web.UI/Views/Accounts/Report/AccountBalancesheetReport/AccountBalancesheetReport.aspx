<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title></title>
    <script runat="server">
        List<AERP.DTO.AccountBalancesheetReport> AccountBalancesheetReport = null;
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }
        int format = 0; decimal _totalLiabilitySum, _totalAssetSum;
        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvAccountBalancesheetReport);
            if (!IsPostBack)
            {
                List<AERP.DTO.OrganisationStudyCentreMaster> OrganisationStudyCentreMasterDetails = null;
                AERP.Web.UI.Controllers.AccountBalancesheetReportController controller = new AERP.Web.UI.Controllers.AccountBalancesheetReportController();
               
                if (Request.RequestType == "POST")
                {
                    OrganisationStudyCentreMasterDetails = controller.GetReportHeader();
                    AccountBalancesheetReport = controller.GetAccountBalancesheetReport(string.Empty, out format);
                }
                if (AccountBalancesheetReport == null || OrganisationStudyCentreMasterDetails == null || AccountBalancesheetReport.Count == 0 || OrganisationStudyCentreMasterDetails.Count==0)
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;
                    
                    if (format == 1)
                    {
                        rvAccountBalancesheetReport.LocalReport.ReportPath = Server.MapPath("~/Report/AccountReports/AccountBalancesheetReport.rdlc");
                    }
                    else
                    {
                        rvAccountBalancesheetReport.LocalReport.ReportPath = Server.MapPath("~/Report/AccountReports/AccountBalancesheetReportFormat2.rdlc");
                    }

                    rvAccountBalancesheetReport.LocalReport.DataSources.Clear();
                    _totalLiabilitySum = AccountBalancesheetReport.Where(x => !string.IsNullOrEmpty(x.HeadCode) && (x.HeadCode.Contains("L") || x.HeadCode.Contains("E"))).Sum(x => x.ClosingBalance);
                    _totalAssetSum = AccountBalancesheetReport.Where(x => !string.IsNullOrEmpty(x.HeadCode) && (x.HeadCode.Contains("A") || x.HeadCode.Contains("I"))).Sum(x => x.ClosingBalance);

                    ReportDataSource rdc2 = new ReportDataSource();
                    rdc2.Name = "StudyCentreDetails";
                    rdc2.Value = OrganisationStudyCentreMasterDetails;
                    rvAccountBalancesheetReport.LocalReport.DataSources.Add(rdc2);

                    rvAccountBalancesheetReport.LocalReport.SubreportProcessing +=

                   new Microsoft.Reporting.WebForms.SubreportProcessingEventHandler(LocalReport_SubreportProcessing);

                    ReportParameter[] param = new ReportParameter[6];
                    param[0] = new ReportParameter("TotalLiabilitySum",format ==1 ? string.Format(" Total : {0:0.00}", Math.Abs(_totalLiabilitySum)) :string.Format("{0:0.00}", Math.Abs(_totalLiabilitySum)), false);
                    param[1] = new ReportParameter("TotalAssetSum",format ==1 ? string.Format("Total : {0:0.00}", Math.Abs(_totalAssetSum)) : string.Format("{0:0.00}", Math.Abs(_totalAssetSum)), false);
                    param[2] = new ReportParameter("GroupBy", AccountBalancesheetReport.Count > 0 ? AccountBalancesheetReport[0].GroupBy : string.Empty, false);
                    param[3] = new ReportParameter("SessionFrom", AccountBalancesheetReport.Count > 0 ? AccountBalancesheetReport[0].SessionFromDate : string.Empty, false);
                    param[4] = new ReportParameter("SessionUpto", AccountBalancesheetReport.Count > 0 ? AccountBalancesheetReport[0].SessionUptoDate : string.Empty, false);
                    param[5] = new ReportParameter("BalancesheetName", AccountBalancesheetReport.Count > 0 ? AccountBalancesheetReport[0].AccBalsheetName : string.Empty, false);
                    rvAccountBalancesheetReport.LocalReport.SetParameters(param);
                    rvAccountBalancesheetReport.LocalReport.Refresh();
                    rvAccountBalancesheetReport.Visible = true;
                }
            }
        }

        void LocalReport_SubreportProcessing(object sender, Microsoft.Reporting.WebForms.SubreportProcessingEventArgs e)
        {
            e.DataSources.Clear();
            var AssetData = AccountBalancesheetReport.Where(x => !string.IsNullOrEmpty(x.HeadCode) && (x.HeadCode.Contains("A") || x.HeadCode.Contains("I"))).Select(x => new { x.CategoryDescription, x.GroupDescription, x.AccountName, x.ClosingBalance });
            e.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource()
            {
                Name = "DataSetAccountBalancesheetReportAsset",
                Value = AssetData,                
            });
            var LiabilityData = AccountBalancesheetReport.Where(x => !string.IsNullOrEmpty(x.HeadCode) && (x.HeadCode.Contains("L") || x.HeadCode.Contains("E"))).Select(x => new { x.CategoryDescription, x.GroupDescription, x.AccountName, x.ClosingBalance });
            e.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource()
            {
                Name = "DataSetAccountBalancesheetReportLiability",
                Value = LiabilityData
            });
        }
    </script>
</head>
<body>
    <form id="Form1" runat="server">
        <div id="MainDiv" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div id="dataDiv">
                <rsweb:ReportViewer ID="rvAccountBalancesheetReport" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="99%" SizeToReportContent="True">
                    <LocalReport ReportEmbeddedResource="AERP.Web.UI.Report.AccountReports.AccountBalancesheetReport.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource3" Name="DataSetAccountBalancesheetReportAsset" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>
                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetData" TypeName="AERPDataSetTableAdapters.OrgStudyCentrePrintingFormatTableAdapter"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="AERPDataSetTableAdapters.AccountBalancesheetReportTableAdapter"></asp:ObjectDataSource>
            </div>
        </div>
        <div id="NoRecordDiv" runat="server" style="text-align: center;">

            <b>No Record Found</b>

        </div>
    </form>
</body>
</html>

