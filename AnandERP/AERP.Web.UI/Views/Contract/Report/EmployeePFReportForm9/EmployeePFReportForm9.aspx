<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>


<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Inventory Item Price Report</title>
    <script runat="server">

        AERP.Web.UI.Controllers.EmployeePFReportForm9Controller controller = new AERP.Web.UI.Controllers.EmployeePFReportForm9Controller();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }
        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvEmployeePFReportForm9);
            if (!IsPostBack)
            {
                rvEmployeePFReportForm9.ProcessingMode = ProcessingMode.Local;
                List<AERP.DTO.EmployeePFReportForm9> EmployeePFReportForm9 = null;

                if (Request.RequestType == "POST")
                {

                    EmployeePFReportForm9 = controller.GetEmployeePFReportForm9List();
                }

                if (EmployeePFReportForm9 == null)
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;
                    rvEmployeePFReportForm9.LocalReport.ReportPath = Server.MapPath("~/Report/Contract/EmployeePFReportForm9.rdlc");
                    rvEmployeePFReportForm9.LocalReport.DataSources.Clear();//collection Of Reports

                    ReportDataSource rdc = new ReportDataSource();
                    rdc.Name = "EmployeePFReportForm9DataSet1";//Data Set Name
                    rdc.Value = EmployeePFReportForm9;                //DTO object
                    rvEmployeePFReportForm9.LocalReport.DataSources.Add(rdc);

                    ReportParameter[] param = new ReportParameter[4];
                    param[0] = new ReportParameter("CentreName", EmployeePFReportForm9.Count > 0 ? EmployeePFReportForm9[0].CentreName : string.Empty, false);
                    param[1] = new ReportParameter("CentreEstCode", EmployeePFReportForm9.Count > 0 ? EmployeePFReportForm9[0].CentreName : string.Empty, false);
                    param[2] = new ReportParameter("MonthName", EmployeePFReportForm9.Count > 0 ? EmployeePFReportForm9[0].MonthFullName : string.Empty, false);
                    param[3] = new ReportParameter("Year", EmployeePFReportForm9.Count > 0 ? EmployeePFReportForm9[0].MonthYear : string.Empty, false);
                    rvEmployeePFReportForm9.LocalReport.SetParameters(param);
                    rvEmployeePFReportForm9.LocalReport.Refresh();
                    rvEmployeePFReportForm9.Visible = true;
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

                <rsweb:ReportViewer ID="rvEmployeePFReportForm9" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="" SizeToReportContent="True">
                    <LocalReport ReportEmbeddedResource="AERP.Web.UI.Report.Contract.EmployeePFReportForm9.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="EmployeePFReportForm9DataSet1" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>

              
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="EmployeePFReportForm9ListDataSet1TableAdapters.InventoryEmployeePFReportForm9ListTableAdapter"></asp:ObjectDataSource>

            </div>

        </div>
        <div id="NoRecordDiv" runat="server" style="text-align: center;">

            <b>No Record Found</b>

        </div>
       
    </form>
</body>
</html>


