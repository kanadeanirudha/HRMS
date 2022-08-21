<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html>
<head id="Head1" runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>AccountIndividualBalanceReport</title>
    <script runat="server">
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }
        
        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvAccountIndividualBalanceList);
            if (!IsPostBack)
            {
                List<AERP.DTO.AccountGeneralLedgerReport> AccountIndividualBalanceReport = null;
                List<AERP.DTO.OrganisationStudyCentreMaster> OrganisationStudyCentreMasterDetails = null;
                AERP.Web.UI.Controllers.AccountIndividualBalanceReportController controller = new AERP.Web.UI.Controllers.AccountIndividualBalanceReportController();
                rvAccountIndividualBalanceList.LocalReport.ReportPath = Server.MapPath("~/Report/AccountReports/AccountIndividualBalanceListReport.rdlc");
                
                if (Request.RequestType =="POST")
                {
                    OrganisationStudyCentreMasterDetails = controller.GetReportHeader();
                    AccountIndividualBalanceReport = controller.GetAccountDetailsForReport();                    
                }

                if (AccountIndividualBalanceReport == null || AccountIndividualBalanceReport.Count == 0 || OrganisationStudyCentreMasterDetails == null || OrganisationStudyCentreMasterDetails.Count == 0) 
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;    
                    NoRecordDiv.Visible = false;

                    rvAccountIndividualBalanceList.LocalReport.DataSources.Clear();
                    ReportDataSource rdc = new ReportDataSource();
                    rdc.Name = "DataSetAccountIndividualBalanceReport";
                    rdc.Value = AccountIndividualBalanceReport;
                    rvAccountIndividualBalanceList.LocalReport.DataSources.Add(rdc);

                    ReportDataSource rdc2 = new ReportDataSource();
                    rdc2.Name = "StudyCentrePrintingFormat";
                    rdc2.Value = OrganisationStudyCentreMasterDetails;
                    rvAccountIndividualBalanceList.LocalReport.DataSources.Add(rdc2);

                    ReportParameter[] param = new ReportParameter[3];
                    param[0] = new ReportParameter("AccountName", AccountIndividualBalanceReport[0].AccountName, false);
                    param[1] = new ReportParameter("ToDate", AccountIndividualBalanceReport[0].ToDate, false);
                    param[2] = new ReportParameter("PersonTypeName", AccountIndividualBalanceReport[0].PersonTypeName, false);
                    rvAccountIndividualBalanceList.LocalReport.SetParameters(param);
                    rvAccountIndividualBalanceList.LocalReport.Refresh();
                    rvAccountIndividualBalanceList.Visible = true;
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
            <rsweb:ReportViewer ID="rvAccountIndividualBalanceList" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="99%" SizeToReportContent="True">
                <LocalReport ReportEmbeddedResource="AERP.Web.UI.Report.AccountReports.AccountIndividualBalanceListReport.rdlc">
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="StudyCentrePrintingFormat" />
                        <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="DataSetAccountIndividualBalanceReport" />
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
