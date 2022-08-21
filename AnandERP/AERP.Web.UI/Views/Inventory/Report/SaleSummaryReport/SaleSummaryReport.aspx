<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title> Sale Summary Report</title>
  <script runat="server">

            protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }
        List<AMS.DTO.RetailReports> SaleSummaryReport = null;
        AMS.Web.UI.Controllers.SaleSummaryReportController controller = new AMS.Web.UI.Controllers.SaleSummaryReportController();
        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvSaleSummaryReport);
            if (!IsPostBack)
            {
                rvSaleSummaryReport.ProcessingMode = ProcessingMode.Local;

                if (Request.RequestType == "POST")
                {
                    SaleSummaryReport = controller.GetSaleSummaryReportList();
                }
                
                if (SaleSummaryReport == null)
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;

                    rvSaleSummaryReport.LocalReport.ReportPath = Server.MapPath("~/Report/Inventory_1/SaleSummaryReport.rdlc");
                    rvSaleSummaryReport.LocalReport.DataSources.Clear();

                    ReportDataSource rdc1 = new ReportDataSource();
                    rdc1.Name = "SaleSummaryReportDataSet";
                    rdc1.Value = SaleSummaryReport;
                    rvSaleSummaryReport.LocalReport.DataSources.Add(rdc1);

                    ReportParameter[] param = new ReportParameter[3];
                    param[0] = new ReportParameter("DateFrom", SaleSummaryReport.Count > 0 ? SaleSummaryReport[0].DateFrom : string.Empty, false);
                    param[1] = new ReportParameter("DateTo", SaleSummaryReport.Count > 0 ? SaleSummaryReport[0].DateTo : string.Empty, false);
                    param[2] = new ReportParameter("CentreName", SaleSummaryReport.Count > 0 ? SaleSummaryReport[0].CentreName : string.Empty, false);
                    rvSaleSummaryReport.LocalReport.SetParameters(param);
                    
                    rvSaleSummaryReport.LocalReport.Refresh();
                    rvSaleSummaryReport.Visible = true;

                }
            }
            
             rvSaleSummaryReport.Drillthrough += new DrillthroughEventHandler(rvSaleSummaryReport_Drillthrough);  
        }
       public void rvSaleSummaryReport_Drillthrough(object sender, DrillthroughEventArgs e)
        {
            /*Collect report parameter from drillthrough report*/
            ReportParameterInfoCollection DrillThroughValues = e.Report.GetParameters();
           // Type parameterName = Type.Parse(DrillThroughValues[1].Values[0].ToString());
            if (DrillThroughValues[0].Name == "Date")
            {
                SaleSummaryReport = controller.GetDateWiseList(Convert.ToString(DrillThroughValues[0].Values[0].ToString()));
                
                /*Bind data source with report*/
                LocalReport localReport = (LocalReport)e.Report;
                localReport.DataSources.Clear();
                localReport.DataSources.Add(new ReportDataSource("DataSet1", SaleSummaryReport));
                localReport.EnableHyperlinks = true;

                /*Add parameter to the report if report have paramerter*/
                List<ReportParameter> parameters = new List<ReportParameter>();
                parameters.Add(new ReportParameter("Date", DrillThroughValues[0].Values[0].ToString()));
                parameters.Add(new ReportParameter("TotalSale", DrillThroughValues[1].Values[0].ToString()));
                localReport.SetParameters(parameters);
                localReport.Refresh();          
            }
         else if (DrillThroughValues[0].Name == "BillNumber")
            {
                SaleSummaryReport = controller.GetOrderNoList(Convert.ToString(DrillThroughValues[0].Values[0].ToString()));

                /*Bind data source with report*/
                LocalReport localReport = (LocalReport)e.Report;
                localReport.DataSources.Clear();
                localReport.DataSources.Add(new ReportDataSource("DataSet2", SaleSummaryReport));
                localReport.EnableHyperlinks = true;

                /*Add parameter to the report if report have paramerter*/
                List<ReportParameter> parameters = new List<ReportParameter>();
                parameters.Add(new ReportParameter("BillNumber", DrillThroughValues[0].Values[0].ToString()));
                parameters.Add(new ReportParameter("BillAmount", DrillThroughValues[1].Values[0].ToString()));
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
                <rsweb:ReportViewer ID="rvSaleSummaryReport" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="" SizeToReportContent="True">
                    <LocalReport ReportEmbeddedResource="AMS.Web.UI.Report.Inventory_1.SaleSummaryReport.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="SaleSummaryDataSet" />
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
