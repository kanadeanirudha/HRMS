<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>


<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Inventory Item Price Report</title>
    <script runat="server">

        AERP.Web.UI.Controllers.SaleContractLifeSpanReportController controller = new AERP.Web.UI.Controllers.SaleContractLifeSpanReportController();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }
        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvSaleContractLifeSpanReport);
            if (!IsPostBack)
            {
                rvSaleContractLifeSpanReport.ProcessingMode = ProcessingMode.Local;
                List<AERP.DTO.SaleContractLifeSpanReport> SaleContractLifeSpanReport = null;
                List<AERP.DTO.OrganisationStudyCentreMaster> OrganisationStudyCentreMasterDetails = null;



                SaleContractLifeSpanReport = controller.GetSaleContractLifeSpanReportList();


                if (SaleContractLifeSpanReport == null)
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;
                    rvSaleContractLifeSpanReport.LocalReport.ReportPath = Server.MapPath("~/Report/Contract/SaleContractLifeSpanReport.rdlc");
                    rvSaleContractLifeSpanReport.LocalReport.DataSources.Clear();//collection Of Reports

                    ReportDataSource rdc = new ReportDataSource();
                    rdc.Name = "SaleContractLifeSpanReportDataSet1";//Data Set Name
                    rdc.Value = SaleContractLifeSpanReport;                //DTO object
                    rvSaleContractLifeSpanReport.LocalReport.DataSources.Add(rdc);

                    //ReportParameter[] param = new ReportParameter[8];
                    //param[0] = new ReportParameter("EmployeeName", SaleContractLifeSpanReport.Count > 0 ? SaleContractLifeSpanReport[0].EmployeeName : string.Empty, false);
                    //param[1] = new ReportParameter("CentreAdress", SaleContractLifeSpanReport.Count > 0 ? SaleContractLifeSpanReport[0].CentreAdress : string.Empty, false);
                    //param[2] = new ReportParameter("CentreName", SaleContractLifeSpanReport.Count > 0 ? SaleContractLifeSpanReport[0].CentreName : string.Empty, false);
                    //param[3] = new ReportParameter("EmployeeFathersFullName", SaleContractLifeSpanReport.Count > 0 ? SaleContractLifeSpanReport[0].EmployeeFathersFullName : string.Empty, false);
                    //param[4] = new ReportParameter("PFAccountNmber", SaleContractLifeSpanReport.Count > 0 ? SaleContractLifeSpanReport[0].PFAccountNmber : string.Empty, false);
                    //param[5] = new ReportParameter("RateOfContribution", SaleContractLifeSpanReport.Count > 0 ? Convert.ToString(SaleContractLifeSpanReport[0].RateOfContribution):  string.Empty, false);
                    //param[6] = new ReportParameter("FromDate", SaleContractLifeSpanReport.Count > 0 ? Convert.ToString(SaleContractLifeSpanReport[0].FromDate):  string.Empty, false);
                    //param[7] = new ReportParameter("UptoDate", SaleContractLifeSpanReport.Count > 0 ? Convert.ToString(SaleContractLifeSpanReport[0].UptoDate):  string.Empty, false);
                    //rvSaleContractLifeSpanReport.LocalReport.SetParameters(param);

                    rvSaleContractLifeSpanReport.LocalReport.Refresh();
                    rvSaleContractLifeSpanReport.Visible = true;
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

                <rsweb:ReportViewer ID="rvSaleContractLifeSpanReport" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="" SizeToReportContent="True">
                    <LocalReport ReportEmbeddedResource="AERP.Web.UI.Report.Contract.SaleContractLifeSpanReport.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="SaleContractLifeSpanReportDataSet1" />
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="StudyCentrePrintingFormat" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>

              
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="SaleContractLifeSpanReportListDataSet1TableAdapters.InventorySaleContractLifeSpanReportListTableAdapter"></asp:ObjectDataSource>

            </div>

        </div>
        <div id="NoRecordDiv" runat="server" style="text-align: center;">

            <b>No Record Found</b>

        </div>
       
    </form>
</body>
</html>


