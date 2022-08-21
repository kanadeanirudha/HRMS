<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>


<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Inventory Item Price Report</title>
    <script runat="server">

        AERP.Web.UI.Controllers.SalesRegisterReportController controller = new AERP.Web.UI.Controllers.SalesRegisterReportController();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }
        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvSalesRegisterReport);
            if (!IsPostBack)
            {
                rvSalesRegisterReport.ProcessingMode = ProcessingMode.Local;
                List<AERP.DTO.SalesRegisterReport> SalesRegisterReport = null;
                List<AERP.DTO.OrganisationStudyCentreMaster> OrganisationStudyCentreMasterDetails = null;



                SalesRegisterReport = controller.GetSalesRegisterReportList();


                if (SalesRegisterReport == null)
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;
                    rvSalesRegisterReport.LocalReport.ReportPath = Server.MapPath("~/Report/Contract/SalesRegisterReport.rdlc");
                    rvSalesRegisterReport.LocalReport.DataSources.Clear();//collection Of Reports

                    ReportDataSource rdc = new ReportDataSource();
                    rdc.Name = "SalesRegisterReportDataSet";//Data Set Name
                    rdc.Value = SalesRegisterReport;                //DTO object
                    rvSalesRegisterReport.LocalReport.DataSources.Add(rdc);

                    //ReportParameter[] param = new ReportParameter[8];
                    //param[0] = new ReportParameter("EmployeeName", SalesRegisterReport.Count > 0 ? SalesRegisterReport[0].EmployeeName : string.Empty, false);
                    //param[1] = new ReportParameter("CentreAdress", SalesRegisterReport.Count > 0 ? SalesRegisterReport[0].CentreAdress : string.Empty, false);
                    //param[2] = new ReportParameter("CentreName", SalesRegisterReport.Count > 0 ? SalesRegisterReport[0].CentreName : string.Empty, false);
                    //param[3] = new ReportParameter("EmployeeFathersFullName", SalesRegisterReport.Count > 0 ? SalesRegisterReport[0].EmployeeFathersFullName : string.Empty, false);
                    //param[4] = new ReportParameter("PFAccountNmber", SalesRegisterReport.Count > 0 ? SalesRegisterReport[0].PFAccountNmber : string.Empty, false);
                    //param[5] = new ReportParameter("RateOfContribution", SalesRegisterReport.Count > 0 ? Convert.ToString(SalesRegisterReport[0].RateOfContribution):  string.Empty, false);
                    //param[6] = new ReportParameter("FromDate", SalesRegisterReport.Count > 0 ? Convert.ToString(SalesRegisterReport[0].FromDate):  string.Empty, false);
                    //param[7] = new ReportParameter("UptoDate", SalesRegisterReport.Count > 0 ? Convert.ToString(SalesRegisterReport[0].UptoDate):  string.Empty, false);
                    //rvSalesRegisterReport.LocalReport.SetParameters(param);

                    rvSalesRegisterReport.LocalReport.Refresh();
                    rvSalesRegisterReport.Visible = true;
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

                <rsweb:ReportViewer ID="rvSalesRegisterReport" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="" SizeToReportContent="True">
                    <LocalReport ReportEmbeddedResource="AERP.Web.UI.Report.Contract.SalesRegisterReport.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="SalesRegisterReportDataSet" />
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="StudyCentrePrintingFormat" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>

              
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="SalesRegisterReportListDataSetTableAdapters.InventorySalesRegisterReportListTableAdapter"></asp:ObjectDataSource>

            </div>

        </div>
        <div id="NoRecordDiv" runat="server" style="text-align: center;">

            <b>No Record Found</b>

        </div>
       
    </form>
</body>
</html>


