<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
  <script runat="server">
   
        AMS.Web.UI.Controllers.VendorServiceLevelReportController controller = new AMS.Web.UI.Controllers.VendorServiceLevelReportController();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }
        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvVendorServiceLevelReport);

            if (!IsPostBack)
            {
                rvVendorServiceLevelReport.ProcessingMode = ProcessingMode.Local;

                List<AMS.DTO.RetailReports> VendorServiceLevelReport = null;

                if (Request.RequestType == "POST")
                {
                    VendorServiceLevelReport = controller.GetVendorServiceLevelList();
                }

                if (VendorServiceLevelReport == null)
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;
                    rvVendorServiceLevelReport.LocalReport.ReportPath = Server.MapPath("~/Report/Inventory_1/VendorServiceLevelReport.rdlc");
                    rvVendorServiceLevelReport.LocalReport.DataSources.Clear();

                    ReportDataSource rdc = new ReportDataSource();
                    rdc.Name = "VendorServiceLevelReportDataSet";
                    rdc.Value = VendorServiceLevelReport;
                    rvVendorServiceLevelReport.LocalReport.DataSources.Add(rdc);

                    ReportParameter[] param = new ReportParameter[2];
                    param[0] = new ReportParameter("DateFrom", VendorServiceLevelReport.Count > 0 ? VendorServiceLevelReport[0].DateFrom : string.Empty, false);
                    param[1] = new ReportParameter("DateTo", VendorServiceLevelReport.Count > 0 ? VendorServiceLevelReport[0].DateTo : string.Empty, false);
                    rvVendorServiceLevelReport.LocalReport.SetParameters(param);
                    
                    rvVendorServiceLevelReport.LocalReport.Refresh();
                    rvVendorServiceLevelReport.Visible = true;
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
                <rsweb:ReportViewer ID="rvVendorServiceLevelReport" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="" SizeToReportContent="True">
                    <LocalReport ReportEmbeddedResource="AMS.Web.UI.Report.Inventory_1.VendorServiceLevelReport.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="VendorServiceLevelReportDataSet" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="DeveloperDBDataSet5TableAdapters.TBL_VendorServiceLevelReportTableAdapter"></asp:ObjectDataSource>
            </div>
        </div>
        <div id="NoRecordDiv" runat="server" style="text-align: center;">
            <b>No Record Found</b>
        </div>
    </form>
</body>
</html>
