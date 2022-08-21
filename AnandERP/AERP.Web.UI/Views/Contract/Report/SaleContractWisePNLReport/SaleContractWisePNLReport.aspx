<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>


<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Inventory Item Price Report</title>
    <script runat="server">

        AERP.Web.UI.Controllers.SaleContractWisePNLReportController controller = new AERP.Web.UI.Controllers.SaleContractWisePNLReportController();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }
        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvSaleContractWisePNLReport);
            if (!IsPostBack)
            {
                rvSaleContractWisePNLReport.ProcessingMode = ProcessingMode.Local;
                List<AERP.DTO.SaleContractWisePNLReport> SaleContractWisePNLReport = null;
                List<AERP.DTO.OrganisationStudyCentreMaster> OrganisationStudyCentreMasterDetails = null;



                SaleContractWisePNLReport = controller.GetSaleContractWisePNLReportList();


                if (SaleContractWisePNLReport == null)
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;
                    rvSaleContractWisePNLReport.LocalReport.ReportPath = Server.MapPath("~/Report/Contract/SaleContractWisePNLReport.rdlc");
                    rvSaleContractWisePNLReport.LocalReport.DataSources.Clear();//collection Of Reports

                    ReportDataSource rdc = new ReportDataSource();
                    rdc.Name = "SaleContractWisePNLReportDataSet";//Data Set Name
                    rdc.Value = SaleContractWisePNLReport;                //DTO object
                    rvSaleContractWisePNLReport.LocalReport.DataSources.Add(rdc);

                    ReportParameter[] param = new ReportParameter[2];
                    param[0] = new ReportParameter("ContractNumber", SaleContractWisePNLReport.Count > 0 ? SaleContractWisePNLReport[0].ContractNumber: string.Empty, false);
                    param[1] = new ReportParameter("SpanName", SaleContractWisePNLReport.Count > 0 ? SaleContractWisePNLReport[0].SaleContractBillingSpanName: string.Empty, false);
                    
                    rvSaleContractWisePNLReport.LocalReport.SetParameters(param);

                    rvSaleContractWisePNLReport.LocalReport.Refresh();
                    rvSaleContractWisePNLReport.Visible = true;
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

                <rsweb:ReportViewer ID="rvSaleContractWisePNLReport" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="" SizeToReportContent="True">
                    <LocalReport ReportEmbeddedResource="AERP.Web.UI.Report.Contract.SaleContractWisePNLReport.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="SaleContractWisePNLReportDataSet" />
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="StudyCentrePrintingFormat" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>

              
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="SaleContractWisePNLReportListDataSetTableAdapters.InventorySaleContractWisePNLReportListTableAdapter"></asp:ObjectDataSource>

            </div>

        </div>
        <div id="NoRecordDiv" runat="server" style="text-align: center;">

            <b>No Record Found</b>

        </div>
       
    </form>
</body>
</html>


