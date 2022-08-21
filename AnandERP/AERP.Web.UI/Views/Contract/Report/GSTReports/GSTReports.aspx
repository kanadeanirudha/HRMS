<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>


<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Inventory Item Price Report</title>
    <script runat="server">

        AERP.Web.UI.Controllers.GSTReportsController controller = new AERP.Web.UI.Controllers.GSTReportsController();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }
        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvGSTReports);
            if (!IsPostBack)
            {
                rvGSTReports.ProcessingMode = ProcessingMode.Local;
                List<AERP.DTO.GSTReports> GSTReports = null;
                List<AERP.DTO.OrganisationStudyCentreMaster> OrganisationStudyCentreMasterDetails = null;



                GSTReports = controller.GetGST1ReportsList();


                if (GSTReports == null)
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;
                    rvGSTReports.LocalReport.ReportPath = Server.MapPath("~/Report/Contract/GST1Reports.rdlc");
                    rvGSTReports.LocalReport.DataSources.Clear();//collection Of Reports

                    ReportDataSource rdc = new ReportDataSource();
                    rdc.Name = "GSTReportsDataSet";//Data Set Name
                    rdc.Value = GSTReports;                //DTO object
                    rvGSTReports.LocalReport.DataSources.Add(rdc);

                    ReportParameter[] param = new ReportParameter[3];
                    param[0] = new ReportParameter("FromDate", GSTReports.Count > 0 ? GSTReports[0].FromDate : string.Empty, false);
                    param[1] = new ReportParameter("UptoDate", GSTReports.Count > 0 ? GSTReports[0].UptoDate : string.Empty, false);
                    param[2] = new ReportParameter("CentreName", GSTReports.Count > 0 ? GSTReports[0].CentreName : string.Empty, false);

                    rvGSTReports.LocalReport.SetParameters(param);

                    rvGSTReports.LocalReport.Refresh();
                    rvGSTReports.Visible = true;
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

                <rsweb:ReportViewer ID="rvGSTReports" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="" SizeToReportContent="True">
                    <LocalReport ReportEmbeddedResource="AERP.Web.UI.Report.Contract.GST1Reports.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="GSTReportsDataSet" />
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="StudyCentrePrintingFormat" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>


                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="GSTReportsDataSetTableAdapters.InventoryGSTReportsListTableAdapter"></asp:ObjectDataSource>

            </div>

        </div>
        <div id="NoRecordDiv" runat="server" style="text-align: center;">

            <b>No Record Found</b>

        </div>

    </form>
</body>
</html>


