<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title></title>
    <script runat="server">
        static bool _pageLoad; static int _counter;
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }
       
        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvAccountDayBookReport);
            if (!Page.IsPostBack)
            {
                AERP.Web.UI.Controllers.AccountDayBookReportController controller = new AERP.Web.UI.Controllers.AccountDayBookReportController();
                List<AERP.DTO.AccountDayBookReport> AccountDayBookReport = null;
                List<AERP.DTO.OrganisationStudyCentreMaster> OrganisationStudyCentreMasterDetails = null;
                rvAccountDayBookReport.LocalReport.ReportPath = Server.MapPath("~/Report/AccountReports/AccountDayBookReport.rdlc");

                if (Request.RequestType == "POST")
                {
                    OrganisationStudyCentreMasterDetails = controller.GetReportHeader();
                    AccountDayBookReport = controller.GetDayBookReportData(OrganisationStudyCentreMasterDetails.Count > 0 ? OrganisationStudyCentreMasterDetails[0].CentreCode : string.Empty);
                }

                if (AccountDayBookReport == null || AccountDayBookReport.Count ==0 || OrganisationStudyCentreMasterDetails == null || OrganisationStudyCentreMasterDetails.Count == 0)
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;
                    rvAccountDayBookReport.LocalReport.DataSources.Clear();

                    ReportDataSource rdc1 = new ReportDataSource();
                    rdc1.Name = "AccountDayBookReport";
                    rdc1.Value = AccountDayBookReport;
                    rvAccountDayBookReport.LocalReport.DataSources.Add(rdc1);
                    ReportDataSource rdc2 = new ReportDataSource();
                    rdc2.Name = "StudyCentreDetails";
                    rdc2.Value = OrganisationStudyCentreMasterDetails;
                    rvAccountDayBookReport.LocalReport.DataSources.Add(rdc2);

                    ReportParameter[] param = new ReportParameter[3];
                    param[0] = new ReportParameter("Pattern", AccountDayBookReport[0].Pattern , false);
                    param[1] = new ReportParameter("SessionFromDate",  AccountDayBookReport[0].SessionFromDate  , false);
                    param[2] = new ReportParameter("SessionUptoDate",  AccountDayBookReport[0].SessionUptoDate , false);
                    rvAccountDayBookReport.LocalReport.SetParameters(param);
                    rvAccountDayBookReport.Visible = true;
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
            <rsweb:ReportViewer ID="rvAccountDayBookReport" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="99%" PageCountMode="Actual" SizeToReportContent="True">
                <LocalReport ReportEmbeddedResource="AERP.Web.UI.Report.AccountReports.AccountDayBookReport.rdlc">
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="AccountDayBookReport" />
                        <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="StudyCentreDetails" />
                    </DataSources>
                </LocalReport>
            </rsweb:ReportViewer>
               </div>
            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetData" TypeName="AERPDataSetTableAdapters.OrgStudyCentrePrintingFormatTableAdapter"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="AERPDataSetTableAdapters.AccountDayBookReportTableAdapter"></asp:ObjectDataSource>
        </div>
        <div id="NoRecordDiv" runat="server" style="text-align:center;" >
                
           <b>No Record Found</b> 
        
        </div>
    </form>
</body>
</html>

