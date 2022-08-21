<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Report For All Contract Expiry</title>
    <script runat="server">
   
        AERP.Web.UI.Controllers.CCRMContractExpiryReportController controller = new AERP.Web.UI.Controllers.CCRMContractExpiryReportController();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }
       
        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvCCRMContractExpiryReport);
            if (!IsPostBack)
            {
                rvCCRMContractExpiryReport.ProcessingMode = ProcessingMode.Local;
                List<AERP.DTO.CCRMContractExpiryReport> CCRMContractExpiryReport = null;
                //List<AERP.DTO.OrganisationStudyCentreMaster> OrganisationStudyCentreMasterDetails = null;

                //if (Request.RequestType == "POST")

                CCRMContractExpiryReport = controller.GetContractExpiryList("All");

                
                if (CCRMContractExpiryReport == null)
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;
                    rvCCRMContractExpiryReport.LocalReport.ReportPath = Server.MapPath("~/Report/CCRM/CCRMContractExpiryReport.rdlc");
                    rvCCRMContractExpiryReport.LocalReport.DataSources.Clear();//collection Of Reports

                    ReportDataSource rdc = new ReportDataSource();
                    rdc.Name = "CCRMContractExpiryReportDataSet1";//Data Set Name
                    rdc.Value = CCRMContractExpiryReport;                //DTO object
                    rvCCRMContractExpiryReport.LocalReport.DataSources.Add(rdc);

                    //ReportDataSource rdc2 = new ReportDataSource();
                    //rdc2.Name = "StudyCentrePrintingFormat";
                    //rdc2.Value = OrganisationStudyCentreMasterDetails;
                    //rvCCRMContractExpiryReport.LocalReport.DataSources.Add(rdc2);

                    rvCCRMContractExpiryReport.LocalReport.Refresh();
                    rvCCRMContractExpiryReport.Visible = true;
                }
            }
        
        }
        
    </script>
</head>
<body>
    <form runat="server">
        <div id="MainDiv" runat="server">
            <div id="categoryPrint">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                <rsweb:ReportViewer ID="rvCCRMContractExpiryReport" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="" SizeToReportContent="True">
                    <LocalReport ReportEmbeddedResource="AERP.Web.UI.Report.CCRM.CCRMContractExpiryReport.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="CCRMContractExpiryReportDataSet1" />
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="StudyCentrePrintingFormat" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>

              
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="CCRMContractExpiryReportDataSet1TableAdapters.CCRMContractExpiryReportTableAdapter"></asp:ObjectDataSource>

            </div>

        </div>
        <div id="NoRecordDiv" runat="server" style="text-align: center;">

            <b>No Record Found</b>

        </div>
       
    </form>
</body>
</html>
