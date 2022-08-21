<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Account Master Report</title>
    <script runat="server">
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }
        
        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvAccountMaster);
            if (!Page.IsPostBack)
            {
                List<AERP.DTO.AccountMasterReport> AccountMasterReport = null;
                List<AERP.DTO.OrganisationStudyCentreMaster> OrganisationStudyCentreMasterDetails = null;
                AERP.Web.UI.Controllers.AccountMasterReportController controller = new AERP.Web.UI.Controllers.AccountMasterReportController();

                rvAccountMaster.ProcessingMode = ProcessingMode.Local;
                rvAccountMaster.LocalReport.ReportPath = Server.MapPath("~/Report/AccountReports/AccountMasterReport.rdlc");
                rvAccountMaster.LocalReport.DataSources.Clear();

                AccountMasterReport = controller.GetAccountDetailsForReport();
                OrganisationStudyCentreMasterDetails = controller.GetReportHeader();
                ReportDataSource rdc1 = new ReportDataSource();
                rdc1.Name = "AccountMasterDataSet";
                rdc1.Value = AccountMasterReport;
                rvAccountMaster.LocalReport.DataSources.Add(rdc1);
                ReportDataSource rdc2 = new ReportDataSource();
                rdc2.Name = "StudyCentreDetails";
                rdc2.Value = OrganisationStudyCentreMasterDetails;
                rvAccountMaster.LocalReport.DataSources.Add(rdc2);

                if (AccountMasterReport.Count == 0)
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;
                }

                rvAccountMaster.LocalReport.Refresh();
                rvAccountMaster.Visible = true;
            }
        }

</script>
</head>
<body>
    <form runat="server">
      <div id="MainDiv" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            
            <rsweb:ReportViewer ID="rvAccountMaster" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="100%" SizeToReportContent="True">
                <LocalReport ReportEmbeddedResource="AERP.Web.UI.Report.AccountReports.AccountMasterReport.rdlc">
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="AccountMasterDataSet" />
                        <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="StudyCentreDetails" />
                    </DataSources>
                </LocalReport>
            </rsweb:ReportViewer>
            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetData" TypeName="AERPDataSetTableAdapters.USP_GeneralStudyCentreMaster_ReportSearchListTableAdapter"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="AERPDataSetTableAdapters.USP_AccountNameList_ReportTableAdapter"></asp:ObjectDataSource>
            
       </div>
        <div id="NoRecordDiv" runat="server" style="   background-color: #f78181;    border-radius: 5px;color: #fff;    font-size: 15px;    font-weight: bold;    height: 30px;    line-height: 30px;    margin: 9px;    text-align: center;"> No Record Found</div>
    </form>
</body>
</html>

