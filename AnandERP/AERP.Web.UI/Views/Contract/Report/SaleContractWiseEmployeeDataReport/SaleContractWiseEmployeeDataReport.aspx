<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>


<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Inventory Item Price Report</title>
    <script runat="server">

        AERP.Web.UI.Controllers.SaleContractWiseEmployeeDataReportController controller = new AERP.Web.UI.Controllers.SaleContractWiseEmployeeDataReportController();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }
        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvSaleContractWiseEmployeeDataReport);
            if (!IsPostBack)
            {
                rvSaleContractWiseEmployeeDataReport.ProcessingMode = ProcessingMode.Local;
                List<AERP.DTO.SaleContractWiseEmployeeDataReport> SaleContractWiseEmployeeDataReport = null;
                List<AERP.DTO.OrganisationStudyCentreMaster> OrganisationStudyCentreMasterDetails = null;



                SaleContractWiseEmployeeDataReport = controller.GetSaleContractWiseEmployeeDataReportList();


                if (SaleContractWiseEmployeeDataReport == null)
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;
                    rvSaleContractWiseEmployeeDataReport.LocalReport.ReportPath = Server.MapPath("~/Report/Contract/SaleContractWiseEmployeeDataReport.rdlc");
                    rvSaleContractWiseEmployeeDataReport.LocalReport.DataSources.Clear();//collection Of Reports

                    ReportDataSource rdc = new ReportDataSource();
                    rdc.Name = "SaleContractWiseEmployeeDataReportDataSet";//Data Set Name
                    rdc.Value = SaleContractWiseEmployeeDataReport;                //DTO object
                    rvSaleContractWiseEmployeeDataReport.LocalReport.DataSources.Add(rdc);

                    ReportParameter[] param = new ReportParameter[1];
                    param[0] = new ReportParameter("ContractNumber", SaleContractWiseEmployeeDataReport.Count > 0 ? SaleContractWiseEmployeeDataReport[0].ContractNumber: string.Empty, false);
                    
                    rvSaleContractWiseEmployeeDataReport.LocalReport.SetParameters(param);

                    rvSaleContractWiseEmployeeDataReport.LocalReport.Refresh();
                    rvSaleContractWiseEmployeeDataReport.Visible = true;
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

                <rsweb:ReportViewer ID="rvSaleContractWiseEmployeeDataReport" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="" SizeToReportContent="True">
                    <LocalReport ReportEmbeddedResource="AERP.Web.UI.Report.Contract.SaleContractWiseEmployeeDataReport.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="SaleContractWiseEmployeeDataReportDataSet" />
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="StudyCentrePrintingFormat" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>

              
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="SaleContractWiseEmployeeDataReportListDataSetTableAdapters.InventorySaleContractWiseEmployeeDataReportListTableAdapter"></asp:ObjectDataSource>

            </div>

        </div>
        <div id="NoRecordDiv" runat="server" style="text-align: center;">

            <b>No Record Found</b>

        </div>
       
    </form>
</body>
</html>


