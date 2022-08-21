<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
  <script runat="server">
   
        AMS.Web.UI.Controllers.DiscountReportController controller = new AMS.Web.UI.Controllers.DiscountReportController();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }
        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvDiscountReport);
            if (!IsPostBack)
            {
                rvDiscountReport.ProcessingMode = ProcessingMode.Local;

                List<AMS.DTO.RetailReports> DiscountReport = null;

                if (Request.RequestType == "POST")
                {
                    DiscountReport = controller.GetDiscountReportList();
                }

                if (DiscountReport == null)
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;
                    rvDiscountReport.LocalReport.ReportPath = Server.MapPath("~/Report/Inventory_1/DiscountReport.rdlc");
                    rvDiscountReport.LocalReport.DataSources.Clear();

                    ReportDataSource rdc = new ReportDataSource();
                    rdc.Name = "DiscountReportDataSet1";
                    rdc.Value = DiscountReport;
                    rvDiscountReport.LocalReport.DataSources.Add(rdc);

                    ReportParameter[] param = new ReportParameter[4];
                    param[0] = new ReportParameter("DiscountType", DiscountReport.Count > 0 ? DiscountReport[0].DiscountType : string.Empty, false);
                    param[1] = new ReportParameter("DateFrom", DiscountReport.Count > 0 ? DiscountReport[0].DateFrom : string.Empty, false);
                    param[2] = new ReportParameter("DateTo", DiscountReport.Count > 0 ? DiscountReport[0].DateTo : string.Empty, false);
                    param[3] = new ReportParameter("CentreName", DiscountReport.Count > 0 ? DiscountReport[0].CentreName : string.Empty, false);
                    rvDiscountReport.LocalReport.SetParameters(param);
                    
                    rvDiscountReport.LocalReport.Refresh();
                    rvDiscountReport.Visible = true;
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
                <rsweb:ReportViewer ID="rvDiscountReport" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="" SizeToReportContent="True">
                    <LocalReport ReportEmbeddedResource="AMS.Web.UI.Report.Inventory_1.DiscountReport.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DiscountReportDataSet1" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="DeveloperDBDataSet5TableAdapters.TBL_DiscountReportTableAdapter"></asp:ObjectDataSource>
            </div>
        </div>
        <div id="NoRecordDiv" runat="server" style="text-align: center;">
            <b>No Record Found</b>
        </div>
    </form>
</body>
</html>
