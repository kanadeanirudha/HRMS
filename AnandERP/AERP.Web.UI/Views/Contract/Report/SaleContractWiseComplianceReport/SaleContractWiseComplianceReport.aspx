<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>


<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Inventory Item Price Report</title>
    <script runat="server">

        AERP.Web.UI.Controllers.SaleContractWiseComplianceReportController controller = new AERP.Web.UI.Controllers.SaleContractWiseComplianceReportController();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }
        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvSaleContractWiseComplianceReport);
            if (!IsPostBack)
            {
                rvSaleContractWiseComplianceReport.ProcessingMode = ProcessingMode.Local;
                List<AERP.DTO.SaleContractWiseComplianceReport> SaleContractWiseComplianceReport = null;
                List<AERP.DTO.OrganisationStudyCentreMaster> OrganisationStudyCentreMasterDetails = null;



                SaleContractWiseComplianceReport = controller.GetSaleContractWiseComplianceReportList();


                if (SaleContractWiseComplianceReport.Count == 0)
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;
                    if (SaleContractWiseComplianceReport[0].ReportType == "PF")
                    {
                        rvSaleContractWiseComplianceReport.LocalReport.ReportPath = Server.MapPath("~/Report/Contract/SaleContractWiseComplianceReport.rdlc");
                    }
                    else if (SaleContractWiseComplianceReport[0].ReportType == "ESIC")
                    {
                        rvSaleContractWiseComplianceReport.LocalReport.ReportPath = Server.MapPath("~/Report/Contract/SaleContractWiseESICComplianceReport.rdlc");
                    }
                    else
                    {
                        rvSaleContractWiseComplianceReport.LocalReport.ReportPath = Server.MapPath("~/Report/Contract/SaleContractWisePTComplianceReport.rdlc");
                    }
                    rvSaleContractWiseComplianceReport.LocalReport.DataSources.Clear();//collection Of Reports

                    ReportDataSource rdc = new ReportDataSource();
                    rdc.Name = "SaleContractWiseComplianceReportDataSet";//Data Set Name
                    rdc.Value = SaleContractWiseComplianceReport;                //DTO object
                    rvSaleContractWiseComplianceReport.LocalReport.DataSources.Add(rdc);

                    ReportParameter[] param = new ReportParameter[3];
                    param[0] = new ReportParameter("SalaryMonthDisplay", SaleContractWiseComplianceReport.Count > 0 ? SaleContractWiseComplianceReport[0].SalaryMonthDisplay : string.Empty, false);
                    param[1] = new ReportParameter("SalaryYear", SaleContractWiseComplianceReport.Count > 0 ? SaleContractWiseComplianceReport[0].SalaryYear : string.Empty, false);
                    param[2] = new ReportParameter("ReportType", SaleContractWiseComplianceReport.Count > 0 ? SaleContractWiseComplianceReport[0].ReportType : string.Empty, false);

                    rvSaleContractWiseComplianceReport.LocalReport.SetParameters(param);

                    rvSaleContractWiseComplianceReport.LocalReport.Refresh();
                    rvSaleContractWiseComplianceReport.Visible = true;
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

                <rsweb:ReportViewer ID="rvSaleContractWiseComplianceReport" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="" SizeToReportContent="True">
                    <LocalReport ReportEmbeddedResource="AERP.Web.UI.Report.Contract.SaleContractWiseComplianceReport.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="SaleContractWiseComplianceReportDataSet" />
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="StudyCentrePrintingFormat" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>


                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="SaleContractWiseComplianceReportListDataSetTableAdapters.InventorySaleContractWiseComplianceReportListTableAdapter"></asp:ObjectDataSource>

            </div>

        </div>
        <div id="NoRecordDiv" runat="server" style="text-align: center;">

            <b>No Record Found</b>

        </div>

    </form>
</body>
</html>


