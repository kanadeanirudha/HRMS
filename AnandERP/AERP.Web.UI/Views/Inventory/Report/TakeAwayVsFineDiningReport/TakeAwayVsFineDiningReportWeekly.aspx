<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
  <script runat="server">

      AMS.Web.UI.Controllers.TakeAwayVsFineDiningReportController controller = new AMS.Web.UI.Controllers.TakeAwayVsFineDiningReportController();

      protected void Page_PreInit(object sender, EventArgs e)
      {
          Context.Handler = this.Page;
      }
      void Page_Load(object sender, EventArgs e)
      {
          ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
          scriptManager.RegisterPostBackControl(this.rvRetailReports);
          if (!IsPostBack)
          {
              rvRetailReports.ProcessingMode = ProcessingMode.Local;

              List<AMS.DTO.RetailReports> RetailReports = null;

              RetailReports = controller.GetDinningReportList();
            
              if (RetailReports == null)
              {
                  MainDiv.Visible = false;
                  NoRecordDiv.Visible = true;
              }
              else
              {
                  MainDiv.Visible = true;
                  NoRecordDiv.Visible = false;
                  rvRetailReports.LocalReport.ReportPath = Server.MapPath("~/Report/Inventory_1/TakeAwayVsFineDiningReportWeekly.rdlc");
                  rvRetailReports.LocalReport.DataSources.Clear();

                  ReportDataSource rdc = new ReportDataSource();
                  rdc.Name = "TakeAwayVsFineDiningReportDataSet1";
                  rdc.Value = RetailReports;
                  rvRetailReports.LocalReport.DataSources.Add(rdc);
                  
                  
                  ReportParameter[] param = new ReportParameter[4];
                  param[0] = new ReportParameter("CentreName", RetailReports.Count > 0 ? RetailReports[0].CentreName : string.Empty, false);
                  param[1] = new ReportParameter("GranularityName", RetailReports.Count > 0 ? RetailReports[0].GranularityName : string.Empty, false);
                  param[2] = new ReportParameter("DateFrom", RetailReports.Count > 0 ? RetailReports[0].DateFrom : string.Empty, false);
                  param[3] = new ReportParameter("DateTo", RetailReports.Count > 0 ? RetailReports[0].DateTo : string.Empty, false);
                  rvRetailReports.LocalReport.SetParameters(param);
                  rvRetailReports.Visible = true;
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

                <rsweb:ReportViewer ID="rvRetailReports" runat="server" AsyncRendering="false" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="" SizeToReportContent="True">
                    <LocalReport ReportEmbeddedResource="AMS.Web.UI.Report.Inventory_1.TakeAwayVsFineDiningReportWeekly.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="TakeAwayVsFineDiningReportDataSet1" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>

                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="DeveloperDBDataSetTableAdapters.TakeAwayVsFineDiningReportDataSet1"></asp:ObjectDataSource>

            </div>

        </div>
        <div id="NoRecordDiv" runat="server" style="text-align: center;">

            <b>No Record Found</b>

        </div>
       
    </form>
</body>
</html>
