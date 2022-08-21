<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html>
<head id="Head1" runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Account Profit And Loss Report</title>
    <script runat="server">
       
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }
        int format = 0; decimal _totalIncomeSum, _totalExpenditureSum;
        List<AERP.DTO.AccountProfitAndLossReport> AccountProfitAndLossReport = null;
        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvAccountProfitAndLossList);
            if (!IsPostBack)
            {
                List<AERP.DTO.OrganisationStudyCentreMaster> OrganisationStudyCentreMasterDetails = null;
                AERP.Web.UI.Controllers.AccountProfitAndLossReportController controller = new AERP.Web.UI.Controllers.AccountProfitAndLossReportController();
                if (Request.RequestType == "POST")
                {
                    OrganisationStudyCentreMasterDetails = controller.GetReportHeader();
                    AccountProfitAndLossReport = controller.GetAccountDetailsForReport(string.Empty, out format);                    
                }

             
                if (AccountProfitAndLossReport == null || OrganisationStudyCentreMasterDetails == null || AccountProfitAndLossReport.Count == 0 || OrganisationStudyCentreMasterDetails.Count == 0)
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;
                    rvAccountProfitAndLossList.LocalReport.ReportPath = Server.MapPath("~/Report/AccountReports/AccountProfitAndLossListReport.rdlc");                   
                    rvAccountProfitAndLossList.LocalReport.DataSources.Clear();
                    _totalIncomeSum = AccountProfitAndLossReport.Where(x => !string.IsNullOrEmpty(x.HeadCode) &&  x.HeadCode.Contains("I")).Sum(x => x.ClosingBalance);
                    _totalExpenditureSum = AccountProfitAndLossReport.Where(x => !string.IsNullOrEmpty(x.HeadCode) && x.HeadCode.Contains("E")).Sum(x => x.ClosingBalance);

                    ReportDataSource rdc2 = new ReportDataSource();
                    rdc2.Name = "StudyCentrePrintingFormat";
                    rdc2.Value = OrganisationStudyCentreMasterDetails;
                    rvAccountProfitAndLossList.LocalReport.DataSources.Add(rdc2);

                    rvAccountProfitAndLossList.LocalReport.SubreportProcessing +=

                   new Microsoft.Reporting.WebForms.SubreportProcessingEventHandler(LocalReport_SubreportProcessing);

                    ReportParameter[] param = new ReportParameter[6];
                    param[0] = new ReportParameter("TotalIncomeSum", string.Format(" Total : {0:0.00}", Math.Abs(_totalIncomeSum)), false);
                    param[1] = new ReportParameter("TotalExpenditureSum", string.Format("Total : {0:0.00}", Math.Abs(_totalExpenditureSum)), false);
                    param[2] = new ReportParameter("GroupBy",AccountProfitAndLossReport.Count > 0 ? AccountProfitAndLossReport[0].GroupBy :string.Empty, false);
                    param[3] = new ReportParameter("SessionFromDate", AccountProfitAndLossReport.Count > 0 ? AccountProfitAndLossReport[0].SessionFromDate : string.Empty, false);
                    param[4] = new ReportParameter("SessionUptoDate", AccountProfitAndLossReport.Count > 0 ? AccountProfitAndLossReport[0].SessionUptoDate : string.Empty, false);
                    param[5] = new ReportParameter("BalancesheetName", AccountProfitAndLossReport.Count > 0 ? AccountProfitAndLossReport[0].AccBalsheetName : string.Empty, false);
                    rvAccountProfitAndLossList.LocalReport.SetParameters(param);                    
                    rvAccountProfitAndLossList.LocalReport.Refresh();
                    rvAccountProfitAndLossList.Visible = true;
                }
            }
        }
        
        void LocalReport_SubreportProcessing(object sender,Microsoft.Reporting.WebForms.SubreportProcessingEventArgs e)
        {
            e.DataSources.Clear();
            var ExpenditureData = AccountProfitAndLossReport.Where(x => !string.IsNullOrEmpty(x.HeadCode) && x.HeadCode.Contains("E")).Select(x => new { x.CategoryDescription, x.GroupDescription, x.AccountName, x.ClosingBalance });
            e.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource(){
                Name = "DataSetAccountProfitAndLossExpenditureReport",
                Value = ExpenditureData
            });
            var IncomeData = AccountProfitAndLossReport.Where(x => !string.IsNullOrEmpty(x.HeadCode) && x.HeadCode.Contains("I")).Select(x => new { x.CategoryDescription, x.GroupDescription, x.AccountName, x.ClosingBalance });
            e.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource(){
                Name = "DataSetAccountProfitAndLossIncomeReport",
                Value = IncomeData
            });
        }

    </script>
</head>
    <body>
       <form id="Form1" runat="server">
        <div id="MainDiv" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div id="dataDiv">
            <rsweb:ReportViewer ID="rvAccountProfitAndLossList" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="99%" SizeToReportContent="True">
                <LocalReport ReportEmbeddedResource="AERP.Web.UI.Report.AccountReports.AccountProfitAndLossExpenditure.rdlc">
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="ObjectDataSource3" Name="DataSetAccountProfitAndLossExpenditureReport" />
                    </DataSources>
                </LocalReport>
            </rsweb:ReportViewer>
                <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="GetData" TypeName="AERPDataSet121TableAdapters.AccountProfitAndLossTableAdapter"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetData" TypeName="AERPDataSet3TableAdapters.AccountGeneralLedgerReportTableAdapter"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="AERPDataSetTableAdapters.OrgStudyCentrePrintingFormatTableAdapter"></asp:ObjectDataSource>
               </div>
        </div>
        <div id="NoRecordDiv" runat="server" style="text-align:center;" >
                
           <b>No Record Found</b> 
        
        </div>
    </form>
</body>
</html>