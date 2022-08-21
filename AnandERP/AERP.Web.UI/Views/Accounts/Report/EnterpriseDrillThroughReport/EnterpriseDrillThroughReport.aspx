<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Account Master Report</title>
    <script runat="server">
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }
        List<AMS.DTO.EnterpriseDrillThroughReport> EnterpriseDrillThroughReport = null;
        AMS.Web.UI.Controllers.EnterpriseDrillThroughReportController controller = new AMS.Web.UI.Controllers.EnterpriseDrillThroughReportController();
        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvAccountMaster);
            if (!Page.IsPostBack)
            {
                rvAccountMaster.ProcessingMode = ProcessingMode.Local;
                rvAccountMaster.LocalReport.ReportPath = Server.MapPath("~/Report/AccountReports/EnterpriseDrillThroughReport.rdlc");
                rvAccountMaster.LocalReport.DataSources.Clear();

                EnterpriseDrillThroughReport = controller.GetCentreList();
                ReportDataSource rdc1 = new ReportDataSource();
                rdc1.Name = "EmployeeDataSet";
                rdc1.Value = EnterpriseDrillThroughReport;
                rvAccountMaster.LocalReport.DataSources.Add(rdc1);

                if (EnterpriseDrillThroughReport.Count == 0)
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;
                }

                rvAccountMaster.LocalReport.Refresh();
                rvAccountMaster.Visible = true;
            }
            rvAccountMaster.Drillthrough += new DrillthroughEventHandler(rvAccountMaster_Drillthrough);

        }
        public void rvAccountMaster_Drillthrough(object sender, DrillthroughEventArgs e)
        {
            /*Collect report parameter from drillthrough report*/
            ReportParameterInfoCollection DrillThroughValues = e.Report.GetParameters();
           // Type parameterName = Type.Parse(DrillThroughValues[1].Values[0].ToString());
            if (DrillThroughValues[0].Name == "CentreCode")
            {
                EnterpriseDrillThroughReport = controller.GetDepartementList(DrillThroughValues[0].Values[0].ToString());

                /*Bind data source with report*/
                LocalReport localReport = (LocalReport)e.Report;
                localReport.DataSources.Clear();
                localReport.DataSources.Add(new ReportDataSource("DataSet1", EnterpriseDrillThroughReport));
                localReport.EnableHyperlinks = true;

                /*Add parameter to the report if report have paramerter*/
                List<ReportParameter> parameters = new List<ReportParameter>();
                parameters.Add(new ReportParameter("CentreCode", DrillThroughValues[0].Values[0].ToString()));
                localReport.SetParameters(parameters);
                localReport.Refresh();          
            }
            else if (DrillThroughValues[0].Name == "DepartmentID")
            {
                EnterpriseDrillThroughReport = controller.GetEmployeeList(Convert.ToInt32(DrillThroughValues[0].Values[0].ToString()));

                /*Bind data source with report*/
                LocalReport localReport = (LocalReport)e.Report;
                localReport.DataSources.Clear();
                localReport.DataSources.Add(new ReportDataSource("DataSet2", EnterpriseDrillThroughReport));
                localReport.EnableHyperlinks = true;

                /*Add parameter to the report if report have paramerter*/
                List<ReportParameter> parameters = new List<ReportParameter>();
                parameters.Add(new ReportParameter("DepartmentID", DrillThroughValues[0].Values[0].ToString()));
                localReport.SetParameters(parameters);
                localReport.Refresh(); 
            }
           

        }
        
        
    </script>
</head>
<body>
    <form runat="server">
        <div id="MainDiv" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

            <rsweb:ReportViewer ID="rvAccountMaster" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="100%" SizeToReportContent="True">
                <LocalReport ReportEmbeddedResource="AMS.Web.UI.Report.AccountReports.EnterpriseDrillThroughReport.rdlc">
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="EmployeeDataSet" />
                    </DataSources>
                </LocalReport>
            </rsweb:ReportViewer>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="EmployeeDBTableAdapters.EmpEmployeeMasterTableAdapter"></asp:ObjectDataSource>

        </div>
        <div id="NoRecordDiv" runat="server">No Record Found</div>
    </form>
</body>
</html>

