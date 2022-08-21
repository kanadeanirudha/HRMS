<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Account Balancesheet Type Report</title>
    <script runat="server">
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }
        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvAccountBalancesheetType);
            if (!IsPostBack)
            {
                List<AERP.DTO.AccountBalancesheetTypeReport> AccountBalancesheetTypeReport = null;
                List<AERP.DTO.OrganisationStudyCentreMaster> OrganisationStudyCentreMasterDetails = null;

                AERP.Web.UI.Controllers.AccountBalancesheetTypeReportController controller = new AERP.Web.UI.Controllers.AccountBalancesheetTypeReportController();
               
                OrganisationStudyCentreMasterDetails = controller.GetReportHeader();
                AccountBalancesheetTypeReport = controller.GetListAccountBalancesheetTypeReport();
                if (AccountBalancesheetTypeReport.Count == 0 || OrganisationStudyCentreMasterDetails.Count == 0)
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;    
                    NoRecordDiv.Visible = false;
                    rvAccountBalancesheetType.LocalReport.ReportPath = Server.MapPath("~/Report/AccountReports/AccountBalancesheetTypeReport.rdlc");
                    rvAccountBalancesheetType.LocalReport.DataSources.Clear();
                    ReportDataSource rdc = new ReportDataSource();
                    rdc.Name = "DataSetAccountBalancesheetTypeReport";
                    rdc.Value = AccountBalancesheetTypeReport;
                    rvAccountBalancesheetType.LocalReport.DataSources.Add(rdc);

                    ReportDataSource rdc2 = new ReportDataSource();
                    rdc2.Name = "StudyCentrePrintingFormat";
                    rdc2.Value = OrganisationStudyCentreMasterDetails;
                    rvAccountBalancesheetType.LocalReport.DataSources.Add(rdc2);

                    rvAccountBalancesheetType.LocalReport.Refresh();
                    rvAccountBalancesheetType.Visible = true;
                }
            }
        }
       

    </script>

</head>
<body>
    <form runat="server">
        <div id="MainDiv" runat="server">
            <div>
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <rsweb:ReportViewer ID="rvAccountBalancesheetType" runat="server" AsyncRendering="False" SizeToReportContent="True" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
                    <LocalReport ReportEmbeddedResource="AERP.Web.UI.Report.AccountReports.AccountBalancesheetTypeReport.rdlc">

                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSetAccountBalancesheetTypeReport" />
                               <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="StudyCentrePrintingFormat" />

                        </DataSources>

                    </LocalReport>
                </rsweb:ReportViewer>

                  <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="AERPDataSetTableAdapters.AccBalsheetTypeMasterTableAdapter"></asp:ObjectDataSource>

                  <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetData" TypeName="AERPDataSetTableAdapters.OrgStudyCentrePrintingFormatTableAdapter"></asp:ObjectDataSource>
      
                <br />


            </div>
        </div>
        <div id="NoRecordDiv" runat="server" style="text-align:center;" >
                
           <b>No Record Found</b> 
        
        </div>

    </form>
</body>
</html>
