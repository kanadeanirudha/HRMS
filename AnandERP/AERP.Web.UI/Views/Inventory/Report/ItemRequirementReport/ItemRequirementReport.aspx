<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Inventory Item Price Report</title>
    <script runat="server">

        AERP.Web.UI.Controllers.ItemRequirementReportController controller = new AERP.Web.UI.Controllers.ItemRequirementReportController();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }
        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvItemRequirementReport);
            if (!IsPostBack)
            {
                rvItemRequirementReport.ProcessingMode = ProcessingMode.Local;
                List<AERP.DTO.InventoryReport> InventoryReport = null;
                //List<AERP.DTO.OrganisationStudyCentreMaster> OrganisationStudyCentreMasterDetails = null;



                InventoryReport = controller.GetItemRequirementReportList();


                if (InventoryReport == null)
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;
                    rvItemRequirementReport.LocalReport.ReportPath = Server.MapPath("~/Report/Inventory/ItemRequirementReport.rdlc");
                    rvItemRequirementReport.LocalReport.DataSources.Clear();//collection Of Reports

                    ReportDataSource rdc = new ReportDataSource();
                    rdc.Name = "ItemRequirementReportDataSet";//Data Set Name
                    rdc.Value = InventoryReport;                //DTO object
                    rvItemRequirementReport.LocalReport.DataSources.Add(rdc);

                    ReportParameter[] param = new ReportParameter[4];
                    param[0] = new ReportParameter("CentreName", InventoryReport.Count > 0 ? InventoryReport[0].CentreName : string.Empty, false);
                    param[1] = new ReportParameter("ItemDescription", InventoryReport.Count > 0 ? InventoryReport[0].ItemDescription : string.Empty, false);
                    param[2] = new ReportParameter("FromDate", InventoryReport.Count > 0 ? (InventoryReport[0].FromDate != null ? InventoryReport[0].FromDate : "Start") : string.Empty, false);
                    param[3] = new ReportParameter("UptoDate", InventoryReport.Count > 0 ? (InventoryReport[0].UptoDate != null ? InventoryReport[0].UptoDate : "End") : string.Empty, false);
                    rvItemRequirementReport.LocalReport.SetParameters(param);

                    rvItemRequirementReport.LocalReport.Refresh();
                    rvItemRequirementReport.Visible = true;
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

                <rsweb:ReportViewer ID="rvItemRequirementReport" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="" SizeToReportContent="True">
                    <LocalReport ReportEmbeddedResource="AERP.Web.UI.Report.Inventory.ItemRequirementReport.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="ItemRequirementReportDataSet" />
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="StudyCentrePrintingFormat" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>


                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="ItemRequirementReportDataSetTableAdapters.ItemRequirementReportTableAdapter"></asp:ObjectDataSource>

            </div>

        </div>
        <div id="NoRecordDiv" runat="server" style="text-align: center;">

            <b>No Record Found</b>

        </div>

    </form>
</body>
</html>


