<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title></title>
    <script runat="server">
        static bool _pageLoad; static int _counter;
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }

        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvEmployeeAttendanceReport);
            if (!Page.IsPostBack)
            {
                AMS.Web.UI.Controllers.EmployeeAttendanceReportController controller = new AMS.Web.UI.Controllers.EmployeeAttendanceReportController();
                List<AMS.DTO.EmployeeAttendanceReport> EmployeeAttendanceReport = null;
                //List<AMS.DTO.OrganisationStudyCentreMaster> OrganisationStudyCentreMasterDetails = null;
                rvEmployeeAttendanceReport.LocalReport.ReportPath = Server.MapPath("~/Report/Employee/EmployeeAttendanceReport.rdlc");

                if (Request.RequestType == "POST")
                {
                    //OrganisationStudyCentreMasterDetails = controller.GetReportHeader();
                    EmployeeAttendanceReport = controller.GetEmployeeAttendanceReportData();
                }

                if (EmployeeAttendanceReport == null || EmployeeAttendanceReport.Count == 0)
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;
                    rvEmployeeAttendanceReport.LocalReport.DataSources.Clear();

                    ReportDataSource rdc1 = new ReportDataSource();
                    rdc1.Name = "EmployeeAttendanceReportDataSet";
                    rdc1.Value = EmployeeAttendanceReport;
                    rvEmployeeAttendanceReport.LocalReport.DataSources.Add(rdc1);                    
                   
                    rvEmployeeAttendanceReport.LocalReport.Refresh();
                    rvEmployeeAttendanceReport.Visible = true;                   
                    
                }
            }
        }
    </script>
</head>
<body>
     <form runat="server">
        <div id="MainDiv" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div id="dataDiv">
                <rsweb:ReportViewer ID="rvEmployeeAttendanceReport" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="99%" PageCountMode="Actual" SizeToReportContent="True">
                    <LocalReport ReportEmbeddedResource="AMS.Web.UI.Report.Employee.EmployeeAttendanceReport.rdlc">
                        <DataSources>
                            <%--<rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="StudyCentrePrintingFormat" />--%>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="EmployeeAttendanceReport" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="EmployeeAttendanceReportDataSetTableAdapters.EmployeeAttendanceReport"></asp:ObjectDataSource>
                <%--<asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetData" TypeName="EmployeeAttendanceTableAdapters.OrgStudyCentrePrintingFormatTableAdapter"></asp:ObjectDataSource>--%>
            </div>
        </div>
        <div id="NoRecordDiv" runat="server" style="text-align: center;">
            <b>No Record Found</b>
        </div>
    </form>
    <div>
        <br />
        <br />       
    </div>
</body>
</html>
