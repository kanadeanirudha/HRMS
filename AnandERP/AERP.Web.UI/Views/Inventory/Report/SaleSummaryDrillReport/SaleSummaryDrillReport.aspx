<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Sale Summary Report</title>
    <script runat="server">

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }
        List<AMS.DTO.SaleSummaryDrillReport> SaleSummaryDrillReport = null;
        AMS.Web.UI.Controllers.SaleSummaryDrillReportController controller = new AMS.Web.UI.Controllers.SaleSummaryDrillReportController();
        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvSaleSummaryDrillReport);
            if (!IsPostBack)
            {
                rvSaleSummaryDrillReport.ProcessingMode = ProcessingMode.Local;

                if (Request.RequestType == "POST")
                {
                    SaleSummaryDrillReport = controller.GetSaleSummaryDrillReport_YearList();
                }

                if (SaleSummaryDrillReport == null)
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;

                    rvSaleSummaryDrillReport.LocalReport.ReportPath = Server.MapPath("~/Report/Inventory_1/SaleSummaryDrillReport_YearWise.rdlc");
                    rvSaleSummaryDrillReport.LocalReport.DataSources.Clear();

                    ReportDataSource rdc1 = new ReportDataSource();
                    rdc1.Name = "SaleSummaryDrillReportDataSetYear";
                    rdc1.Value = SaleSummaryDrillReport;
                    rvSaleSummaryDrillReport.LocalReport.DataSources.Add(rdc1);

                    ReportParameter[] param = new ReportParameter[1];
                    param[0] = new ReportParameter("CentreName", SaleSummaryDrillReport.Count > 0 ? SaleSummaryDrillReport[0].CentreName : string.Empty, false);
                    rvSaleSummaryDrillReport.LocalReport.SetParameters(param);

                    rvSaleSummaryDrillReport.LocalReport.Refresh();
                    rvSaleSummaryDrillReport.Visible = true;

                }
            }

            rvSaleSummaryDrillReport.Drillthrough += new DrillthroughEventHandler(rvSaleSummaryDrillReport_Drillthrough);
        }
        public void rvSaleSummaryDrillReport_Drillthrough(object sender, DrillthroughEventArgs e)
        {
            /*Collect report parameter from drillthrough report*/
            ReportParameterInfoCollection DrillThroughValues = e.Report.GetParameters();
            // Type parameterName = Type.Parse(DrillThroughValues[1].Values[0].ToString());
            if (DrillThroughValues[1].Values[0].ToString() == "MonthWise")
            {
                SaleSummaryDrillReport = controller.GetSaleSummaryDrillReport_MonthList(Convert.ToString(DrillThroughValues[2].Values[0].ToString()));

                /*Bind data source with report*/
                LocalReport localReport = (LocalReport)e.Report;
                localReport.DataSources.Clear();
                localReport.DataSources.Add(new ReportDataSource("SaleSummaryDrillReportDataSetMonth", SaleSummaryDrillReport));
                localReport.EnableHyperlinks = true;

                /*Add parameter to the report if report have paramerter*/
                List<ReportParameter> parameters = new List<ReportParameter>();
                parameters.Add(new ReportParameter("NextReportFor", DrillThroughValues[2].Values[0].ToString()));
                parameters.Add(new ReportParameter("CentreName", DrillThroughValues[0].Values[0].ToString()));
                localReport.SetParameters(parameters);
                localReport.Refresh();
            }
            else if (DrillThroughValues[1].Values[0].ToString() == "DayWise")
            {
                SaleSummaryDrillReport = controller.GetSaleSummaryDrillReport_DayList(Convert.ToString(DrillThroughValues[2].Values[0].ToString()));

                /*Bind data source with report*/
                LocalReport localReport = (LocalReport)e.Report;
                localReport.DataSources.Clear();
                localReport.DataSources.Add(new ReportDataSource("SaleSummaryDrillReportDataSetDay", SaleSummaryDrillReport));
                localReport.EnableHyperlinks = true;

                /*Add parameter to the report if report have paramerter*/
                List<ReportParameter> parameters = new List<ReportParameter>();
                parameters.Add(new ReportParameter("NextReportFor", DrillThroughValues[2].Values[0].ToString()));
                parameters.Add(new ReportParameter("CentreName", DrillThroughValues[0].Values[0].ToString()));
                localReport.SetParameters(parameters);
                localReport.Refresh();
            }
            else if (DrillThroughValues[1].Values[0].ToString() == "BillWise")
            {
                SaleSummaryDrillReport = controller.GetSaleSummaryDrillReport_BillList(Convert.ToString(DrillThroughValues[2].Values[0].ToString()));

                /*Bind data source with report*/
                LocalReport localReport = (LocalReport)e.Report;
                localReport.DataSources.Clear();
                localReport.DataSources.Add(new ReportDataSource("SaleSummaryDrillReportDataSetBill", SaleSummaryDrillReport));
                localReport.EnableHyperlinks = true;

                /*Add parameter to the report if report have paramerter*/
                List<ReportParameter> parameters = new List<ReportParameter>();
                parameters.Add(new ReportParameter("NextReportFor", DrillThroughValues[2].Values[0].ToString()));
                parameters.Add(new ReportParameter("CentreName", DrillThroughValues[0].Values[0].ToString()));
                //parameters.Add(new ReportParameter("BillFor", DrillThroughValues[3].Values[0].ToString()));
                localReport.SetParameters(parameters);
                localReport.Refresh();
            }
            else if (DrillThroughValues[1].Values[0].ToString() == "ItemWise" && DrillThroughValues[3].Values[0].ToString() == "Sale")
            {
                SaleSummaryDrillReport = controller.GetSaleSummaryDrillReport_ItemList(Convert.ToString(DrillThroughValues[2].Values[0].ToString()));

                /*Bind data source with report*/
                LocalReport localReport = (LocalReport)e.Report;
                localReport.DataSources.Clear();
                localReport.DataSources.Add(new ReportDataSource("SaleSummaryDrillReportDataSetItem", SaleSummaryDrillReport));
                localReport.EnableHyperlinks = true;

                /*Add parameter to the report if report have paramerter*/
                List<ReportParameter> parameters = new List<ReportParameter>();
                parameters.Add(new ReportParameter("NextReportFor", DrillThroughValues[2].Values[0].ToString()));
                parameters.Add(new ReportParameter("CentreName", DrillThroughValues[0].Values[0].ToString()));
                parameters.Add(new ReportParameter("BillFor", DrillThroughValues[3].Values[0].ToString()));

                localReport.SetParameters(parameters);
                localReport.Refresh();
            }
            else if (DrillThroughValues[2].Values[0].ToString() == "ItemWise" && DrillThroughValues[3].Values[0].ToString() == "SaleReturn")
            {
                SaleSummaryDrillReport = controller.GetSaleSummaryDrillReport_ItemListSaleReturn(Convert.ToString(DrillThroughValues[1].Values[0].ToString()));

                /*Bind data source with report*/
                LocalReport localReport = (LocalReport)e.Report;
                localReport.DataSources.Clear();
                localReport.DataSources.Add(new ReportDataSource("SaleSummaryDrillReportDataSetItemSaleReturn", SaleSummaryDrillReport));
                localReport.EnableHyperlinks = true;

                /*Add parameter to the report if report have paramerter*/
                List<ReportParameter> parameters = new List<ReportParameter>();
                parameters.Add(new ReportParameter("NextReportFor", DrillThroughValues[1].Values[0].ToString()));
                parameters.Add(new ReportParameter("CentreName", DrillThroughValues[0].Values[0].ToString()));
                parameters.Add(new ReportParameter("BillFor", DrillThroughValues[3].Values[0].ToString()));
                localReport.SetParameters(parameters);
                localReport.Refresh();
            }
        }
        
    </script>
</head>
<body>
    <form id="Form1" runat="server">
        <div id="MainDiv" runat="server">
            <div id="categoryPrint">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <rsweb:ReportViewer ID="rvSaleSummaryDrillReport" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="" SizeToReportContent="True">
                    <LocalReport ReportEmbeddedResource="AMS.Web.UI.Report.Inventory_1.SaleSummaryReport.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="SaleSummaryDrillReportDataSetYear" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="DeveloperDBDataSet5TableAdapters.TBL_DaysOfCoverTableAdapter"></asp:ObjectDataSource>
            </div>
        </div>
        <div id="NoRecordDiv" runat="server" style="text-align: center;">
            <b>No Record Found</b>
        </div>
    </form>
</body>
</html>
