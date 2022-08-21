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
          scriptManager.RegisterPostBackControl(this.rvRetailSalesAndMarginReportsDaily);
          if (!IsPostBack)
          {
              rvRetailSalesAndMarginReportsDaily.ProcessingMode = ProcessingMode.Local;

              List<AMS.DTO.RetailReports> RetailSalesAndMarginReportsDaily = null;

              if (Request.RequestType == "POST")
              {
                  RetailSalesAndMarginReportsDaily = controller.GetRetailSalesAndMarginReport();
              }

              if (RetailSalesAndMarginReportsDaily == null)
              {
                  MainDiv.Visible = false;
                  NoRecordDiv.Visible = true;
              }
              else
              {
                  MainDiv.Visible = true;
                  NoRecordDiv.Visible = false;
                  rvRetailSalesAndMarginReportsDaily.LocalReport.ReportPath = Server.MapPath("~/Report/Inventory_1/RetailSalesAndMarginReportsDaily.rdlc");
                  rvRetailSalesAndMarginReportsDaily.LocalReport.DataSources.Clear();

                  ReportDataSource rdc = new ReportDataSource();
                  rdc.Name = "WareHouseSaleDataSetNew";
                  rdc.Value = RetailSalesAndMarginReportsDaily;
                  rvRetailSalesAndMarginReportsDaily.LocalReport.DataSources.Add(rdc);

                  ReportParameter[] param = new ReportParameter[5];
                  param[0] = new ReportParameter("DateFrom", RetailSalesAndMarginReportsDaily.Count > 0 ? RetailSalesAndMarginReportsDaily[0].DateFrom : string.Empty, false);
                  param[1] = new ReportParameter("DateTo", RetailSalesAndMarginReportsDaily.Count > 0 ? RetailSalesAndMarginReportsDaily[0].DateTo : string.Empty, false);
                  param[2] = new ReportParameter("CentreName", RetailSalesAndMarginReportsDaily.Count > 0 ? RetailSalesAndMarginReportsDaily[0].CentreName : string.Empty, false);
                  param[3] = new ReportParameter("GeneralUnitsName", RetailSalesAndMarginReportsDaily.Count > 0 ? RetailSalesAndMarginReportsDaily[0].GeneralUnitsName : string.Empty, false);
                  param[4] = new ReportParameter("GranularityName", RetailSalesAndMarginReportsDaily.Count > 0 ? RetailSalesAndMarginReportsDaily[0].GranularityName : string.Empty, false);
                  rvRetailSalesAndMarginReportsDaily.LocalReport.SetParameters(param);
                  
                  
                  rvRetailSalesAndMarginReportsDaily.LocalReport.Refresh();
                  rvRetailSalesAndMarginReportsDaily.Visible = true;
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

                <rsweb:ReportViewer ID="rvRetailSalesAndMarginReportsDaily" runat="server" AsyncRendering="false" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="" SizeToReportContent="True">
                    <LocalReport ReportEmbeddedResource="AMS.Web.UI.Report.Inventory_1.RetailSalesAndMarginReportsDaily.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="WareHouseSaleDataSetNew" />
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
