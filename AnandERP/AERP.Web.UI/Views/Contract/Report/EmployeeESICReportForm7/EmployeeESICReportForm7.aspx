<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>


<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Inventory Item Price Report</title>
    <script runat="server">

        AERP.Web.UI.Controllers.EmployeeESICReportForm7Controller controller = new AERP.Web.UI.Controllers.EmployeeESICReportForm7Controller();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }
        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvEmployeeESICReportForm7);
            if (!IsPostBack)
            {
                rvEmployeeESICReportForm7.ProcessingMode = ProcessingMode.Local;
                List<AERP.DTO.EmployeeESICReportForm7> EmployeeESICReportForm7 = null;

                if (Request.RequestType == "POST")
                {

                    EmployeeESICReportForm7 = controller.GetEmployeeESICReportForm7List();
                }

                if (EmployeeESICReportForm7 == null)
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;
                    rvEmployeeESICReportForm7.LocalReport.ReportPath = Server.MapPath("~/Report/Contract/EmployeeESICReportForm7.rdlc");
                    rvEmployeeESICReportForm7.LocalReport.DataSources.Clear();//collection Of Reports

                    ReportDataSource rdc = new ReportDataSource();
                    rdc.Name = "EmployeeESICReportForm7DataSet1";//Data Set Name
                    rdc.Value = EmployeeESICReportForm7;                //DTO object
                    rvEmployeeESICReportForm7.LocalReport.DataSources.Add(rdc);

                    ReportParameter[] param = new ReportParameter[3];
                     param[0] = new ReportParameter("CentreName", EmployeeESICReportForm7.Count > 0 ? EmployeeESICReportForm7[0].CentreName : string.Empty, false);
                   // param[1] = new ReportParameter("CentreEstCode", EmployeePFReportForm9.Count > 0 ? EmployeePFReportForm9[0].CentreName : string.Empty, false);
                    param[1] = new ReportParameter("MonthName", EmployeeESICReportForm7.Count > 0 ? EmployeeESICReportForm7[0].MonthFullName : string.Empty, false);
                    param[2] = new ReportParameter("Year", EmployeeESICReportForm7.Count > 0 ? EmployeeESICReportForm7[0].MonthYear : string.Empty, false);
                    rvEmployeeESICReportForm7.LocalReport.SetParameters(param);
                    rvEmployeeESICReportForm7.LocalReport.Refresh();
                    rvEmployeeESICReportForm7.Visible = true;
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

                <rsweb:ReportViewer ID="rvEmployeeESICReportForm7" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="" SizeToReportContent="True">
                    <LocalReport ReportEmbeddedResource="AERP.Web.UI.Report.Contract.EmployeeESICReportForm7.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="EmployeeESICReportForm7DataSet1" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>

              
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="EmployeeESICReportForm7ListDataSet1TableAdapters.InventoryEmployeeESICReportForm7ListTableAdapter"></asp:ObjectDataSource>

            </div>

        </div>
        <div id="NoRecordDiv" runat="server" style="text-align: center;">

            <b>No Record Found</b>

        </div>
       
    </form>
</body>
</html>


