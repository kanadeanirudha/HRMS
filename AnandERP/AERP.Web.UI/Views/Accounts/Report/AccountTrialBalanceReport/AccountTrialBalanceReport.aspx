<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>


<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html>
<head id="Head1" runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Account Trial Balance Report</title>
    <script runat="server">
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }
        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvAccountTrialBalanceList);
            if (!IsPostBack)
            {
                List<AERP.DTO.AccountTrialBalanceReport> AccountTrialBalanceReport = null;
                List<AERP.DTO.OrganisationStudyCentreMaster> OrganisationStudyCentreMasterDetails = null;

                AERP.Web.UI.Controllers.AccountTrialBalanceReportController controller = new AERP.Web.UI.Controllers.AccountTrialBalanceReportController();
                if (Request.RequestType =="POST")
                {
                    OrganisationStudyCentreMasterDetails = controller.GetReportHeader();
                    AccountTrialBalanceReport = controller.GetAccountDetailsForReport();                    
                }

                if ((AccountTrialBalanceReport == null ? true : AccountTrialBalanceReport.Count == 0) || (OrganisationStudyCentreMasterDetails == null ? true : OrganisationStudyCentreMasterDetails.Count == 0))
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;    
                    NoRecordDiv.Visible = false;
                    rvAccountTrialBalanceList.ProcessingMode = ProcessingMode.Local;
                    rvAccountTrialBalanceList.LocalReport.ReportPath = Server.MapPath("~/Report/AccountReports/AccountTrialBalanceListReport.rdlc");
                    rvAccountTrialBalanceList.LocalReport.DataSources.Clear();
                    ReportDataSource rdc = new ReportDataSource();
                    rdc.Name = "DataSetAccountTrialBalanceReport";
                    rdc.Value = AccountTrialBalanceReport;
                    rvAccountTrialBalanceList.LocalReport.DataSources.Add(rdc);

                    ReportDataSource rdc2 = new ReportDataSource();
                    rdc2.Name = "StudyCentrePrintingFormat";
                    rdc2.Value = OrganisationStudyCentreMasterDetails;
                    rvAccountTrialBalanceList.LocalReport.DataSources.Add(rdc2);

                    ReportParameter[] param = new ReportParameter[4];
                    param[0] = new ReportParameter("GroupBy", AccountTrialBalanceReport.Count > 0 ? AccountTrialBalanceReport[0].GroupBy : string.Empty, false);
                    param[1] = new ReportParameter("SessionFromDate", AccountTrialBalanceReport.Count > 0 ? AccountTrialBalanceReport[0].SessionFromDate : string.Empty, false);
                    param[2] = new ReportParameter("SessionUptoDate", AccountTrialBalanceReport.Count > 0 ? AccountTrialBalanceReport[0].SessionUptoDate : string.Empty, false);
                    param[3] = new ReportParameter("BalancesheetName", AccountTrialBalanceReport.Count > 0 ? AccountTrialBalanceReport[0].AccBalsheetName : string.Empty, false);
                    rvAccountTrialBalanceList.LocalReport.SetParameters(param);
                    
                    rvAccountTrialBalanceList.LocalReport.Refresh();
                    rvAccountTrialBalanceList.Visible = true;
                }
            }
        }
       

    </script>

</head>
<body>
    <form id="Form1" runat="server">
        <div id="MainDiv" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div id="dataDiv">
            <rsweb:ReportViewer ID="rvAccountTrialBalanceList" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="100%" SizeToReportContent="True">
                <LocalReport ReportEmbeddedResource="AERP.Web.UI.Report.AccountReports.AccountTrialBalanceListReport.rdlc">
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="StudyCentrePrintingFormat" />
                        <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="DataSetAccountTrialBalanceReport" />
                    </DataSources>
                </LocalReport>
            </rsweb:ReportViewer>
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
