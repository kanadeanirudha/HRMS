<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
  <script runat="server">

      AMS.Web.UI.Controllers.RetailSalesAndMarginReportsController controller = new AMS.Web.UI.Controllers.RetailSalesAndMarginReportsController();

      protected void Page_PreInit(object sender, EventArgs e)
      {
          Context.Handler = this.Page;
      }
      void Page_Load(object sender, EventArgs e)
      {
          ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
          scriptManager.RegisterPostBackControl(this.rvRetailSalesAndMarginReportsWeekly);
          if (!IsPostBack)
          {
              rvRetailSalesAndMarginReportsWeekly.ProcessingMode = ProcessingMode.Local;

              List<AMS.DTO.RetailReports> RetailSalesAndMarginReportsWeekly = null;

              if (Request.RequestType == "POST")
              {
                  RetailSalesAndMarginReportsWeekly = controller.GetRetailSalesAndMarginReport();
              }

              if (RetailSalesAndMarginReportsWeekly == null)
              {
                  MainDiv.Visible = false;
                  NoRecordDiv.Visible = true;
              }
              else
              {
                  MainDiv.Visible = true;
                  NoRecordDiv.Visible = false;
                  rvRetailSalesAndMarginReportsWeekly.LocalReport.ReportPath = Server.MapPath("~/Report/Inventory_1/RetailSalesAndMarginReportsWeekly.rdlc");
                  rvRetailSalesAndMarginReportsWeekly.LocalReport.DataSources.Clear();

                  ReportDataSource rdc = new ReportDataSource();
                  rdc.Name = "WareHouseSaleDataSet2";
                  rdc.Value = RetailSalesAndMarginReportsWeekly;
                  rvRetailSalesAndMarginReportsWeekly.LocalReport.DataSources.Add(rdc);
                  rvRetailSalesAndMarginReportsWeekly.LocalReport.Refresh();
                  rvRetailSalesAndMarginReportsWeekly.Visible = true;
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

                <rsweb:ReportViewer ID="rvRetailSalesAndMarginReportsWeekly" runat="server" AsyncRendering="false" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="" SizeToReportContent="True">
                    <LocalReport ReportEmbeddedResource="AMS.Web.UI.Report.Inventory_1.RetailSalesAndMarginReportsWeekly.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="WareHouseSaleDataSet2" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>

                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="DeveloperDBDataSetTableAdapters.TBL_WareHouseSaleDataTableAdapter"></asp:ObjectDataSource>

            </div>

        </div>
        <div id="NoRecordDiv" runat="server" style="text-align: center;">

            <b>No Record Found</b>

        </div>
       
    </form>
</body>
</html>
