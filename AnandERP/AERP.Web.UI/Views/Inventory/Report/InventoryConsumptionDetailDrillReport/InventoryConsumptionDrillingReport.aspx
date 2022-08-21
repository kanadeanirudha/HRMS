<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
  <script runat="server">
 AMS.Web.UI.Controllers.InventoryConsumptionDetailDrillReportController controller = new AMS.Web.UI.Controllers.InventoryConsumptionDetailDrillReportController();

      protected void Page_PreInit(object sender, EventArgs e)
      {
          Context.Handler = this.Page;
      }
      List<AMS.DTO.InventoryConsumptionDetailDrillReport> InventoryConsumptionDetailDrillReport = null;
      void Page_Load(object sender, EventArgs e)
      {
          ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
          scriptManager.RegisterPostBackControl(this.rvInventoryConsumptionDetailDrillReport);
          if (!IsPostBack)
          {
              rvInventoryConsumptionDetailDrillReport.ProcessingMode = ProcessingMode.Local;

              if (Request.RequestType == "POST")
              {
                  InventoryConsumptionDetailDrillReport = controller.GetInventoryConsumptionDetailDrillReportBySearch_GroupDesciption();
              }

              if (InventoryConsumptionDetailDrillReport == null)
              {
                  MainDiv.Visible = false;
                  NoRecordDiv.Visible = true;
              }
              else
              {
                  MainDiv.Visible = true;
                  NoRecordDiv.Visible = false;
                  rvInventoryConsumptionDetailDrillReport.LocalReport.ReportPath = Server.MapPath("~/Report/Inventory_1/InventoryConsumptionDetailDrillReport.rdlc");
                  rvInventoryConsumptionDetailDrillReport.LocalReport.DataSources.Clear();

                  ReportDataSource rdc = new ReportDataSource();
                  rdc.Name = "InventoryConsumptionDetailDrillReportDataSet";
                  rdc.Value = InventoryConsumptionDetailDrillReport;
                  rvInventoryConsumptionDetailDrillReport.LocalReport.DataSources.Clear();
                  rvInventoryConsumptionDetailDrillReport.LocalReport.DataSources.Add(rdc);


                  ReportParameter[] param = new ReportParameter[4];
                  param[0] = new ReportParameter("GeneralUnitsName", InventoryConsumptionDetailDrillReport.Count > 0 ? InventoryConsumptionDetailDrillReport[0].GeneralUnitsName : string.Empty, false);
                  param[1] = new ReportParameter("GranularityName", InventoryConsumptionDetailDrillReport.Count > 0 ? InventoryConsumptionDetailDrillReport[0].GranularityName : string.Empty, false);
                  param[2] = new ReportParameter("DateFrom", InventoryConsumptionDetailDrillReport.Count > 0 ? InventoryConsumptionDetailDrillReport[0].DateFrom : string.Empty, false);
                  param[3] = new ReportParameter("DateTo", InventoryConsumptionDetailDrillReport.Count > 0 ? InventoryConsumptionDetailDrillReport[0].DateTo : string.Empty, false);
                  rvInventoryConsumptionDetailDrillReport.LocalReport.SetParameters(param);
                  rvInventoryConsumptionDetailDrillReport.LocalReport.Refresh();
                  rvInventoryConsumptionDetailDrillReport.Visible = true;
                 
                
              }
          }
          //For Binding Two Reports
          rvInventoryConsumptionDetailDrillReport.Drillthrough += new DrillthroughEventHandler(rvInventoryConsumptionDetailDrillReport_Drillthrough);
      }
      public void rvInventoryConsumptionDetailDrillReport_Drillthrough(object sender, DrillthroughEventArgs e)
      {
          /*Collect report parameter from drillthrough report*/
          ReportParameterInfoCollection DrillThroughValues = e.Report.GetParameters();
          // Type parameterName = Type.Parse(DrillThroughValues[1].Values[0].ToString());
                          if (DrillThroughValues[0].Name == "MarchandiseGroupCode")
                            {
                                InventoryConsumptionDetailDrillReport = controller.GetInventoryConsumptionDetailDrillReportBySearch_MerchandiseDepartmentNameWise(Convert.ToString(DrillThroughValues[0].Values[0].ToString()));

                                /*Bind data source with report*/
                                LocalReport localReport = (LocalReport)e.Report;
                                localReport.DataSources.Clear();
                                localReport.DataSources.Add(new ReportDataSource("DataSet1", InventoryConsumptionDetailDrillReport));
                                localReport.EnableHyperlinks = true;
                              
                                /*Add parameter to the report if report have paramerter(All From RDLC)*/
                                List<ReportParameter> parameters = new List<ReportParameter>();
                                parameters.Add(new ReportParameter("MarchandiseGroupCode", DrillThroughValues[0].Values[0].ToString()));
                                parameters.Add(new ReportParameter("GeneralUnitsName", InventoryConsumptionDetailDrillReport.Count > 0 ? InventoryConsumptionDetailDrillReport[0].GeneralUnitsName : string.Empty, false));
                                parameters.Add(new ReportParameter("GranularityName", InventoryConsumptionDetailDrillReport.Count > 0 ? InventoryConsumptionDetailDrillReport[0].GranularityName : string.Empty, false));
                                parameters.Add(new ReportParameter("DateFrom", InventoryConsumptionDetailDrillReport.Count > 0 ? InventoryConsumptionDetailDrillReport[0].DateFrom : string.Empty, false));
                                parameters.Add(new ReportParameter("DateTo", InventoryConsumptionDetailDrillReport.Count > 0 ? InventoryConsumptionDetailDrillReport[0].DateTo : string.Empty, false));
                                
                                localReport.SetParameters(parameters);
                                localReport.Refresh();
                            }
                             else if (DrillThroughValues[0].Name == "MerchantiseDepartmentCode")
                            {
                                InventoryConsumptionDetailDrillReport = controller.GetInventoryConsumptionDetailDrillReportBySearch_MerchandiseCategoryNameWise(Convert.ToString(DrillThroughValues[0].Values[0].ToString()));

                                /*Bind data source with report*/
                                LocalReport localReport = (LocalReport)e.Report;
                                localReport.DataSources.Clear();
                                localReport.DataSources.Add(new ReportDataSource("DataSet2", InventoryConsumptionDetailDrillReport));
                                localReport.EnableHyperlinks = true;

                                /*Add parameter to the report if report have paramerter*/
                                List<ReportParameter> parameters = new List<ReportParameter>();
                                parameters.Add(new ReportParameter("MerchantiseDepartmentCode", DrillThroughValues[0].Values[0].ToString()));
                                parameters.Add(new ReportParameter("GeneralUnitsName", InventoryConsumptionDetailDrillReport.Count > 0 ? InventoryConsumptionDetailDrillReport[0].GeneralUnitsName : string.Empty, false));
                                parameters.Add(new ReportParameter("GranularityName", InventoryConsumptionDetailDrillReport.Count > 0 ? InventoryConsumptionDetailDrillReport[0].GranularityName : string.Empty, false));
                                parameters.Add(new ReportParameter("DateFrom", InventoryConsumptionDetailDrillReport.Count > 0 ? InventoryConsumptionDetailDrillReport[0].DateFrom : string.Empty, false));
                                parameters.Add(new ReportParameter("DateTo", InventoryConsumptionDetailDrillReport.Count > 0 ? InventoryConsumptionDetailDrillReport[0].DateTo : string.Empty, false));
                                localReport.SetParameters(parameters);
                                localReport.Refresh();
                            }
                           else if (DrillThroughValues[0].Name == "MerchantiseCategoryCode")
                              {
                                  InventoryConsumptionDetailDrillReport = controller.GetInventoryConsumptionDetailDrillReportBySearch_MerchandiseSubCategoryNameWise(Convert.ToString(DrillThroughValues[0].Values[0].ToString()));

                                  /*Bind data source with report*/
                                  LocalReport localReport = (LocalReport)e.Report;
                                  localReport.DataSources.Clear();
                                  localReport.DataSources.Add(new ReportDataSource("DataSet3", InventoryConsumptionDetailDrillReport));
                                  localReport.EnableHyperlinks = true;

                                  /*Add parameter to the report if report have paramerter*/
                                  List<ReportParameter> parameters = new List<ReportParameter>();
                                  parameters.Add(new ReportParameter("MerchantiseCategoryCode", DrillThroughValues[0].Values[0].ToString()));
                                  parameters.Add(new ReportParameter("GeneralUnitsName", InventoryConsumptionDetailDrillReport.Count > 0 ? InventoryConsumptionDetailDrillReport[0].GeneralUnitsName : string.Empty, false));
                                  parameters.Add(new ReportParameter("GranularityName", InventoryConsumptionDetailDrillReport.Count > 0 ? InventoryConsumptionDetailDrillReport[0].GranularityName : string.Empty, false));
                                  parameters.Add(new ReportParameter("DateFrom", InventoryConsumptionDetailDrillReport.Count > 0 ? InventoryConsumptionDetailDrillReport[0].DateFrom : string.Empty, false));
                                  parameters.Add(new ReportParameter("DateTo", InventoryConsumptionDetailDrillReport.Count > 0 ? InventoryConsumptionDetailDrillReport[0].DateTo : string.Empty, false));
                                  localReport.SetParameters(parameters);
                                  localReport.Refresh();
                              }
                              else if (DrillThroughValues[0].Name == "MarchandiseSubCatgoryCode")
                              {
                                  InventoryConsumptionDetailDrillReport = controller.GetInventoryConsumptionDetailDrillReportBySearch_MerchandiseBaseCategoryNameWise(Convert.ToString(DrillThroughValues[0].Values[0].ToString()));

                                  /*Bind data source with report*/
                                  LocalReport localReport = (LocalReport)e.Report;
                                  localReport.DataSources.Clear();
                                  localReport.DataSources.Add(new ReportDataSource("DataSet4", InventoryConsumptionDetailDrillReport));
                                  localReport.EnableHyperlinks = true;

                                  /*Add parameter to the report if report have paramerter*/
                                  List<ReportParameter> parameters = new List<ReportParameter>();
                                  parameters.Add(new ReportParameter("MarchandiseSubCatgoryCode", DrillThroughValues[0].Values[0].ToString()));
                                  parameters.Add(new ReportParameter("GeneralUnitsName", InventoryConsumptionDetailDrillReport.Count > 0 ? InventoryConsumptionDetailDrillReport[0].GeneralUnitsName : string.Empty, false));
                                  parameters.Add(new ReportParameter("GranularityName", InventoryConsumptionDetailDrillReport.Count > 0 ? InventoryConsumptionDetailDrillReport[0].GranularityName : string.Empty, false));
                                  parameters.Add(new ReportParameter("DateFrom", InventoryConsumptionDetailDrillReport.Count > 0 ? InventoryConsumptionDetailDrillReport[0].DateFrom : string.Empty, false));
                                  parameters.Add(new ReportParameter("DateTo", InventoryConsumptionDetailDrillReport.Count > 0 ? InventoryConsumptionDetailDrillReport[0].DateTo : string.Empty, false));
                                  localReport.SetParameters(parameters);
                                  localReport.Refresh();
                              }
                              else if (DrillThroughValues[0].Name == "MarchandiseBaseCatgoryCode")
                              {
                                  InventoryConsumptionDetailDrillReport = controller.GetInventoryConsumptionDetailDrillReportBySearch_DescriptionWise(Convert.ToString(DrillThroughValues[0].Values[0].ToString()));

                                  /*Bind data source with report*/
                                  LocalReport localReport = (LocalReport)e.Report;
                                  localReport.DataSources.Clear();
                                  localReport.DataSources.Add(new ReportDataSource("DataSet5", InventoryConsumptionDetailDrillReport));
                                  localReport.EnableHyperlinks = true;

                                  /*Add parameter to the report if report have paramerter*/
                                  List<ReportParameter> parameters = new List<ReportParameter>();
                                  parameters.Add(new ReportParameter("MarchandiseBaseCatgoryCode", DrillThroughValues[0].Values[0].ToString()));
                                  parameters.Add(new ReportParameter("GeneralUnitsName", InventoryConsumptionDetailDrillReport.Count > 0 ? InventoryConsumptionDetailDrillReport[0].GeneralUnitsName : string.Empty, false));
                                  parameters.Add(new ReportParameter("GranularityName", InventoryConsumptionDetailDrillReport.Count > 0 ? InventoryConsumptionDetailDrillReport[0].GranularityName : string.Empty, false));
                                  parameters.Add(new ReportParameter("DateFrom", InventoryConsumptionDetailDrillReport.Count > 0 ? InventoryConsumptionDetailDrillReport[0].DateFrom : string.Empty, false));
                                  parameters.Add(new ReportParameter("DateTo", InventoryConsumptionDetailDrillReport.Count > 0 ? InventoryConsumptionDetailDrillReport[0].DateTo : string.Empty, false));
                                  localReport.SetParameters(parameters);
                                  localReport.Refresh();
                              }
                             
                        }
    </script>
</head>
<body>
    <form runat="server">
        <div id="MainDiv" runat="server">
            <div id="categoryPrint">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                <rsweb:ReportViewer ID="rvInventoryConsumptionDetailDrillReport" runat="server" AsyncRendering="false" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="" SizeToReportContent="True">
                    <LocalReport ReportEmbeddedResource="AMS.Web.UI.Report.Inventory_1.InventoryConsumptionDetailDrillReport.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="InventoryConsumptionDetailDrillReport" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>

                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="DeveloperDBDataSetTableAdapters.TBL_InventoryConsumptionDrillReportDataSet"></asp:ObjectDataSource>

            </div>

        </div>
        <div id="NoRecordDiv" runat="server" style="text-align: center;">

            <b>No Record Found</b>

        </div>
       
    </form>
</body>
</html>
