<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Account Group Report</title>
    <script runat="server">
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }
        AERP.Web.UI.Controllers.AccountCategoryMasterReportController controller = new AERP.Web.UI.Controllers.AccountCategoryMasterReportController();
        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvAccountGroupMaster);
            if (!IsPostBack)
            {
                rvAccountGroupMaster.ProcessingMode = ProcessingMode.Local;
                List<AERP.DTO.AccountGroupMasterReport> AccountGroupMasterReport = null;
                List<AERP.DTO.OrganisationStudyCentreMaster> OrganisationStudyCentreMasterDetails = null;
                AERP.Web.UI.Controllers.AccountGroupMasterReportController controller = new AERP.Web.UI.Controllers.AccountGroupMasterReportController();

             
                rvAccountGroupMaster.LocalReport.ReportPath = Server.MapPath("~/Report/AccountReports/AccountGroupMasterReport.rdlc");
                rvAccountGroupMaster.LocalReport.DataSources.Clear();

              
                if (Request.RequestType == "POST")
                {
                    AccountGroupMasterReport = controller.GetGroupDetailsForReport();
                    OrganisationStudyCentreMasterDetails = controller.GetReportHeader();
                }
                if (AccountGroupMasterReport == null || OrganisationStudyCentreMasterDetails == null)
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;
                    ReportDataSource rdc1 = new ReportDataSource();
                    rdc1.Name = "AccountGroupMasterDataSet";
                    rdc1.Value = AccountGroupMasterReport;
                    rvAccountGroupMaster.LocalReport.DataSources.Add(rdc1);
                    ReportDataSource rdc2 = new ReportDataSource();
                    rdc2.Name = "StudyCentreDetails";
                    rdc2.Value = OrganisationStudyCentreMasterDetails;
                    rvAccountGroupMaster.LocalReport.DataSources.Add(rdc2);
                    rvAccountGroupMaster.LocalReport.Refresh();
                    rvAccountGroupMaster.Visible = true;

                }

            }
        }

</script>
</head>
<body>
    <form runat="server">
      <div id="MainDiv" runat="server">
             <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            
            <rsweb:ReportViewer ID="rvAccountGroupMaster" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="100%" SizeToReportContent="True">
                <LocalReport ReportEmbeddedResource="AERP.Web.UI.Report.AccountReports.AccountGroupMasterReport.rdlc">
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="AccountGroupMasterReportDataSet" />
                    </DataSources>
                </LocalReport>
            </rsweb:ReportViewer>
            
          
            
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="AERPDataSetTableAdapters.USP_AccountGroupMaster_REPORTTableAdapter"></asp:ObjectDataSource>
            
       </div>
         <div id="NoRecordDiv" runat="server" style="text-align:center;" >
                
           <b>No Record Found</b> 
        
        </div>

    </form>
</body>
</html>

