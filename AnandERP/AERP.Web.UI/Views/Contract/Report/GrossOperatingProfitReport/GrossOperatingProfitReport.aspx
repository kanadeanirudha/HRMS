<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>


<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Inventory Item Price Report</title>
    <script runat="server">

        AERP.Web.UI.Controllers.GrossOperatingProfitReportController controller = new AERP.Web.UI.Controllers.GrossOperatingProfitReportController();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }
        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvGrossOperatingProfitReport);
            if (!IsPostBack)
            {
                rvGrossOperatingProfitReport.ProcessingMode = ProcessingMode.Local;
                List<AERP.DTO.GrossOperatingProfitReport> GrossOperatingProfitReport = null;
                List<AERP.DTO.OrganisationStudyCentreMaster> OrganisationStudyCentreMasterDetails = null;



                GrossOperatingProfitReport = controller.GetGrossOperatingProfitReportList();


                if (GrossOperatingProfitReport == null)
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;
                    rvGrossOperatingProfitReport.LocalReport.ReportPath = Server.MapPath("~/Report/Contract/GrossOperatingProfitReport.rdlc");
                    rvGrossOperatingProfitReport.LocalReport.DataSources.Clear();//collection Of Reports

                    ReportDataSource rdc = new ReportDataSource();
                    rdc.Name = "GrossOperatingProfitReportDataSet";//Data Set Name
                    rdc.Value = GrossOperatingProfitReport;                //DTO object
                    rvGrossOperatingProfitReport.LocalReport.DataSources.Add(rdc);

                    ReportParameter[] param = new ReportParameter[2];
                    param[0] = new ReportParameter("CustomerMasterName", GrossOperatingProfitReport.Count > 0 ? (GrossOperatingProfitReport[0].CustomerMasterName != null ?GrossOperatingProfitReport[0].CustomerMasterName:"All Customers"): string.Empty, false);
                    param[1] = new ReportParameter("BranchMasterName", GrossOperatingProfitReport.Count > 0 ? (GrossOperatingProfitReport[0].CustomerBranchMasterName!=null ?GrossOperatingProfitReport[0].CustomerBranchMasterName:"All Branches"): string.Empty, false);
                    
                    rvGrossOperatingProfitReport.LocalReport.SetParameters(param);

                    rvGrossOperatingProfitReport.LocalReport.Refresh();
                    rvGrossOperatingProfitReport.Visible = true;
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

                <rsweb:ReportViewer ID="rvGrossOperatingProfitReport" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="" SizeToReportContent="True">
                    <LocalReport ReportEmbeddedResource="AERP.Web.UI.Report.Contract.GrossOperatingProfitReport.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="GrossOperatingProfitReportDataSet" />
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="StudyCentrePrintingFormat" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>

              
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="GrossOperatingProfitReportListDataSetTableAdapters.InventoryGrossOperatingProfitReportListTableAdapter"></asp:ObjectDataSource>

            </div>

        </div>
        <div id="NoRecordDiv" runat="server" style="text-align: center;">

            <b>No Record Found</b>

        </div>
       
    </form>
</body>
</html>


