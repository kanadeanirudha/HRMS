<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>


<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Inventory Item Price Report</title>
    <script runat="server">

        AERP.Web.UI.Controllers.SaleContractSalaryWageSheetReportController controller = new AERP.Web.UI.Controllers.SaleContractSalaryWageSheetReportController();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }
        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvSaleContractSalaryWageSheetReport);
            if (!IsPostBack)
            {
                rvSaleContractSalaryWageSheetReport.ProcessingMode = ProcessingMode.Local;
                List<AERP.DTO.SaleContractSalaryWageSheetReport> SaleContractSalaryWageSheetReport = null;
                List<AERP.DTO.OrganisationStudyCentreMaster> OrganisationStudyCentreMasterDetails = null;



                SaleContractSalaryWageSheetReport = controller.GetSaleContractSalaryWageSheetReportList();


                if (SaleContractSalaryWageSheetReport == null)
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;
                    rvSaleContractSalaryWageSheetReport.LocalReport.ReportPath = Server.MapPath("~/Report/Contract/SaleContractSalaryWageSheetReport.rdlc");
                    rvSaleContractSalaryWageSheetReport.LocalReport.DataSources.Clear();//collection Of Reports

                    ReportDataSource rdc = new ReportDataSource();
                    rdc.Name = "SaleContractSalaryWageSheetReportDataSet";//Data Set Name
                    rdc.Value = SaleContractSalaryWageSheetReport;                //DTO object
                    rvSaleContractSalaryWageSheetReport.LocalReport.DataSources.Add(rdc);

                    ReportParameter[] param = new ReportParameter[2];
                    param[0] = new ReportParameter("ContractNumber", SaleContractSalaryWageSheetReport.Count > 0 ? SaleContractSalaryWageSheetReport[0].ContractNumber: string.Empty, false);
                    param[1] = new ReportParameter("SpanName", SaleContractSalaryWageSheetReport.Count > 0 ? SaleContractSalaryWageSheetReport[0].SaleContractBillingSpanName: string.Empty, false);
                    
                    rvSaleContractSalaryWageSheetReport.LocalReport.SetParameters(param);

                    rvSaleContractSalaryWageSheetReport.LocalReport.Refresh();
                    rvSaleContractSalaryWageSheetReport.Visible = true;
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

                <rsweb:ReportViewer ID="rvSaleContractSalaryWageSheetReport" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="" SizeToReportContent="True">
                    <LocalReport ReportEmbeddedResource="AERP.Web.UI.Report.Contract.SaleContractSalaryWageSheetReport.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="SaleContractSalaryWageSheetReportDataSet" />
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="StudyCentrePrintingFormat" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>

              
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="SaleContractSalaryWageSheetReportListDataSetTableAdapters.InventorySaleContractSalaryWageSheetReportListTableAdapter"></asp:ObjectDataSource>

            </div>

        </div>
        <div id="NoRecordDiv" runat="server" style="text-align: center;">

            <b>No Record Found</b>

        </div>
       
    </form>
</body>
</html>


