<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>


<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Inventory Item Price Report</title>
    <script runat="server">

        AERP.Web.UI.Controllers.EmployeeReportForm5MonthlyController controller = new AERP.Web.UI.Controllers.EmployeeReportForm5MonthlyController();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }
        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvEmployeeReportForm5Monthly);
            if (!IsPostBack)
            {
                rvEmployeeReportForm5Monthly.ProcessingMode = ProcessingMode.Local;
                List<AERP.DTO.EmployeeReportForm5Monthly> EmployeeReportForm5Monthly = null;

                 if (Request.RequestType == "POST")
                {
                  
                EmployeeReportForm5Monthly = controller.GetEmployeeReportForm5MonthlyList();
                }

                if (EmployeeReportForm5Monthly == null)
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;
                    rvEmployeeReportForm5Monthly.LocalReport.ReportPath = Server.MapPath("~/Report/Contract/EmployeeReportForm5Monthly.rdlc");
                    rvEmployeeReportForm5Monthly.LocalReport.DataSources.Clear();//collection Of Reports

                    ReportDataSource rdc = new ReportDataSource();
                    rdc.Name = "EmployeeReportForm5MonthlyDataSet1";//Data Set Name
                    rdc.Value = EmployeeReportForm5Monthly;                //DTO object
                    rvEmployeeReportForm5Monthly.LocalReport.DataSources.Add(rdc);

                    ReportParameter[] param = new ReportParameter[2];
                    param[0] = new ReportParameter("CentreAdress", EmployeeReportForm5Monthly.Count > 0 ? EmployeeReportForm5Monthly[0].CentreAdress : string.Empty, false);
                    param[1] = new ReportParameter("CentreName", EmployeeReportForm5Monthly.Count > 0 ? EmployeeReportForm5Monthly[0].CentreName : string.Empty, false);
                    rvEmployeeReportForm5Monthly.LocalReport.SetParameters(param);
                    rvEmployeeReportForm5Monthly.LocalReport.Refresh();
                    rvEmployeeReportForm5Monthly.Visible = true;
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

                <rsweb:ReportViewer ID="rvEmployeeReportForm5Monthly" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="" SizeToReportContent="True">
                    <LocalReport ReportEmbeddedResource="AERP.Web.UI.Report.Contract.EmployeeReportForm5Monthly.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="EmployeeReportForm5MonthlyDataSet1" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>

              
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="EmployeeReportForm5MonthlyListDataSet1TableAdapters.InventoryEmployeeReportForm5MonthlyListTableAdapter"></asp:ObjectDataSource>

            </div>

        </div>
        <div id="NoRecordDiv" runat="server" style="text-align: center;">

            <b>No Record Found</b>

        </div>
       
    </form>
</body>
</html>


