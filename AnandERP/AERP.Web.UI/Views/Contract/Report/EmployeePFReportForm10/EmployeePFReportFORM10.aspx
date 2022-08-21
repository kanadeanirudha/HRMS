<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>


<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Inventory Item Price Report</title>
    <script runat="server">

        AERP.Web.UI.Controllers.EmployeePFReportForm10Controller controller = new AERP.Web.UI.Controllers.EmployeePFReportForm10Controller();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }
        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvEmployeePFReportForm10);
            if (!IsPostBack)
            {
                rvEmployeePFReportForm10.ProcessingMode = ProcessingMode.Local;
                List<AERP.DTO.EmployeePFReportForm10> EmployeePFReportForm10 = null;

                EmployeePFReportForm10 = controller.GetEmployeePFReportForm10List();


                if (EmployeePFReportForm10 == null)
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;
                    rvEmployeePFReportForm10.LocalReport.ReportPath = Server.MapPath("~/Report/Contract/EmployeePFReportForm10.rdlc");
                    rvEmployeePFReportForm10.LocalReport.DataSources.Clear();//collection Of Reports

                    ReportDataSource rdc = new ReportDataSource();
                    rdc.Name = "EmployeePFReportForm10DataSet1";//Data Set Name
                    rdc.Value = EmployeePFReportForm10;                //DTO object
                    rvEmployeePFReportForm10.LocalReport.DataSources.Add(rdc);

                    ReportParameter[] param = new ReportParameter[2];
                    param[0] = new ReportParameter("CentreAdress", EmployeePFReportForm10.Count > 0 ? EmployeePFReportForm10[0].CentreAdress : string.Empty, false);
                    param[1] = new ReportParameter("CentreName", EmployeePFReportForm10.Count > 0 ? EmployeePFReportForm10[0].CentreName : string.Empty, false);
                    //param[2] = new ReportParameter("PFAccountNmber", EmployeePFReportForm10.Count > 0 ? EmployeePFReportForm10[0].PFAccountNmber : string.Empty, false);
                    //param[3] = new ReportParameter("RateOfContribution", EmployeePFReportForm10.Count > 0 ? Convert.ToString(EmployeePFReportForm10[0].RateOfContribution) : string.Empty, false);
                    //param[4] = new ReportParameter("FromDate", EmployeePFReportForm10.Count > 0 ? Convert.ToString(EmployeePFReportForm10[0].FromDate) : string.Empty, false);
                    //param[5] = new ReportParameter("UptoDate", EmployeePFReportForm10.Count > 0 ? Convert.ToString(EmployeePFReportForm10[0].UptoDate) : string.Empty, false);
                    rvEmployeePFReportForm10.LocalReport.SetParameters(param);

                    rvEmployeePFReportForm10.LocalReport.Refresh();
                    rvEmployeePFReportForm10.Visible = true;
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

                <rsweb:ReportViewer ID="rvEmployeePFReportForm10" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="" SizeToReportContent="True">
                    <LocalReport ReportEmbeddedResource="AERP.Web.UI.Report.Contract.EmployeePFReportForm10.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="EmployeePFReportForm10DataSet1" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>

              
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="EmployeePFReportForm10ListDataSet1TableAdapters.InventoryEmployeePFReportForm10ListTableAdapter"></asp:ObjectDataSource>

            </div>

        </div>
        <div id="NoRecordDiv" runat="server" style="text-align: center;">

            <b>No Record Found</b>

        </div>
       
    </form>
</body>
</html>


