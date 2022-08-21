<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title> Inventory Sale and Wastage Report</title>
  <script runat="server">
        AMS.Web.UI.Controllers.InventoryConsumptionDetailDrillReportController controller = new AMS.Web.UI.Controllers.InventoryConsumptionDetailDrillReportController();
            protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }
        List<AMS.DTO.InventoryConsumptionDetailDrillReport> InventorySaleandWastageReport = null;
      
        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvInventorySaleandWastageReport);
            if (!IsPostBack)
            {
                rvInventorySaleandWastageReport.ProcessingMode = ProcessingMode.Local;

                if (Request.RequestType == "POST")
                {
                    InventorySaleandWastageReport = controller.GetInventorySaleandWastageReportBySearch_GroupDescription();
                }
                
                if (InventorySaleandWastageReport == null)
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;

                    rvInventorySaleandWastageReport.LocalReport.ReportPath = Server.MapPath("~/Report/Inventory_1/InventorySaleandWastageReport_GroupDescription.rdlc");
                    rvInventorySaleandWastageReport.LocalReport.DataSources.Clear();

                    ReportDataSource rdc1 = new ReportDataSource();
                    rdc1.Name = "InventorySaleandWastageDataSet";
                    rdc1.Value = InventorySaleandWastageReport;
                    rvInventorySaleandWastageReport.LocalReport.DataSources.Add(rdc1);

                    ReportParameter[] param = new ReportParameter[4];
                    param[0] = new ReportParameter("DateFrom", InventorySaleandWastageReport.Count > 0 ? InventorySaleandWastageReport[0].DateFrom : string.Empty, false);
                    param[1] = new ReportParameter("DateTo", InventorySaleandWastageReport.Count > 0 ? InventorySaleandWastageReport[0].DateTo : string.Empty, false);
                    param[2] = new ReportParameter("GranularityName", InventorySaleandWastageReport.Count > 0 ? InventorySaleandWastageReport[0].GranularityName : string.Empty, false);
                    param[3] = new ReportParameter("GeneralUnitsName", InventorySaleandWastageReport.Count > 0 ? InventorySaleandWastageReport[0].GeneralUnitsName : string.Empty, false);
                    rvInventorySaleandWastageReport.LocalReport.SetParameters(param);
                    
                    rvInventorySaleandWastageReport.LocalReport.Refresh();
                    rvInventorySaleandWastageReport.Visible = true;

                }
            }
            
             rvInventorySaleandWastageReport.Drillthrough += new DrillthroughEventHandler(rvInventorySaleandWastageReport_Drillthrough);  
        }
       public void rvInventorySaleandWastageReport_Drillthrough(object sender, DrillthroughEventArgs e)
        {
            /*Collect report parameter from drillthrough report*/
            ReportParameterInfoCollection DrillThroughValues = e.Report.GetParameters();
           // Type parameterName = Type.Parse(DrillThroughValues[1].Values[0].ToString());
            if (DrillThroughValues[0].Name == "MarchandiseGroupCode")
            {
                InventorySaleandWastageReport = controller.GetInventorySaleandWastageReportBySearch_MerchandiseDepartmentNameWise(Convert.ToString(DrillThroughValues[0].Values[0].ToString()));
                
                /*Bind data source with report*/
                LocalReport localReport = (LocalReport)e.Report;
                localReport.DataSources.Clear();
                localReport.DataSources.Add(new ReportDataSource("InventorySaleandWastageDataSet3", InventorySaleandWastageReport));
                localReport.EnableHyperlinks = true;

                /*Add parameter to the report if report have paramerter*/
                List<ReportParameter> parameters = new List<ReportParameter>();
                parameters.Add(new ReportParameter("MarchandiseGroupCode", DrillThroughValues[0].Values[0].ToString()));
                parameters.Add(new ReportParameter("DateFrom", InventorySaleandWastageReport.Count > 0 ? InventorySaleandWastageReport[0].DateFrom : string.Empty, false));
                parameters.Add(new ReportParameter("DateTo", InventorySaleandWastageReport.Count > 0 ? InventorySaleandWastageReport[0].DateTo : string.Empty, false));
                parameters.Add(new ReportParameter("GranularityName", InventorySaleandWastageReport.Count > 0 ? InventorySaleandWastageReport[0].GranularityName : string.Empty, false));
                parameters.Add(new ReportParameter("GeneralUnitsName", InventorySaleandWastageReport.Count > 0 ? InventorySaleandWastageReport[0].GeneralUnitsName : string.Empty, false));
                localReport.SetParameters(parameters);
                localReport.Refresh();          
            }
          else if (DrillThroughValues[0].Name == "MerchandiseDepartmentCode")
            {
                InventorySaleandWastageReport = controller.GetInventorySaleandWastageReportBySearch_MerchandiseCategoryNameWise(Convert.ToString(DrillThroughValues[0].Values[0].ToString()));
      
                /*Bind data source with report*/
                LocalReport localReport = (LocalReport)e.Report;
                localReport.DataSources.Clear();
                localReport.DataSources.Add(new ReportDataSource("InventorySaleandWastageDataSet2", InventorySaleandWastageReport));
                localReport.EnableHyperlinks = true;

                /*Add parameter to the report if report have paramerter*/
                List<ReportParameter> parameters = new List<ReportParameter>();
                parameters.Add(new ReportParameter("MerchandiseDepartmentCode", DrillThroughValues[0].Values[0].ToString()));
                parameters.Add(new ReportParameter("DateFrom", InventorySaleandWastageReport.Count > 0 ? InventorySaleandWastageReport[0].DateFrom : string.Empty, false));
                parameters.Add(new ReportParameter("DateTo", InventorySaleandWastageReport.Count > 0 ? InventorySaleandWastageReport[0].DateTo : string.Empty, false));
                parameters.Add(new ReportParameter("GranularityName", InventorySaleandWastageReport.Count > 0 ? InventorySaleandWastageReport[0].GranularityName : string.Empty, false));
                parameters.Add(new ReportParameter("GeneralUnitsName", InventorySaleandWastageReport.Count > 0 ? InventorySaleandWastageReport[0].GeneralUnitsName : string.Empty, false));
               localReport.SetParameters(parameters);
                localReport.Refresh(); 
            }
        else if (DrillThroughValues[0].Name == "MerchandiseCategoryCode")
            {
                InventorySaleandWastageReport = controller.GetInventorySaleandWastageReportBySearch_MerchandiseSubCategoryNameWise(Convert.ToString(DrillThroughValues[0].Values[0].ToString()));
      
                /*Bind data source with report*/
                LocalReport localReport = (LocalReport)e.Report;
                localReport.DataSources.Clear();
                localReport.DataSources.Add(new ReportDataSource("InventorySaleandWastageDataSet4", InventorySaleandWastageReport));
                localReport.EnableHyperlinks = true;

                /*Add parameter to the report if report have paramerter*/
                List<ReportParameter> parameters = new List<ReportParameter>();
                parameters.Add(new ReportParameter("MerchandiseCategoryCode", DrillThroughValues[0].Values[0].ToString()));
                parameters.Add(new ReportParameter("DateFrom", InventorySaleandWastageReport.Count > 0 ? InventorySaleandWastageReport[0].DateFrom : string.Empty, false));
                parameters.Add(new ReportParameter("DateTo", InventorySaleandWastageReport.Count > 0 ? InventorySaleandWastageReport[0].DateTo : string.Empty, false));
                parameters.Add(new ReportParameter("GranularityName", InventorySaleandWastageReport.Count > 0 ? InventorySaleandWastageReport[0].GranularityName : string.Empty, false));
                parameters.Add(new ReportParameter("GeneralUnitsName", InventorySaleandWastageReport.Count > 0 ? InventorySaleandWastageReport[0].GeneralUnitsName : string.Empty, false));
               localReport.SetParameters(parameters);
                localReport.Refresh(); 
            }
          else if (DrillThroughValues[0].Name == "MarchandiseSubCatgoryCode")
            {
                InventorySaleandWastageReport = controller.GetInventorySaleandWastageReportBySearch_MerchandiseBaseCategoryNameWise(Convert.ToString(DrillThroughValues[0].Values[0].ToString()));
      
                /*Bind data source with report*/
                LocalReport localReport = (LocalReport)e.Report;
                localReport.DataSources.Clear();
                localReport.DataSources.Add(new ReportDataSource("InventorySaleandWastageDataSet1", InventorySaleandWastageReport));
                localReport.EnableHyperlinks = true;

                /*Add parameter to the report if report have paramerter*/
                List<ReportParameter> parameters = new List<ReportParameter>();
                parameters.Add(new ReportParameter("MarchandiseSubCatgoryCode", DrillThroughValues[0].Values[0].ToString()));
                parameters.Add(new ReportParameter("DateFrom", InventorySaleandWastageReport.Count > 0 ? InventorySaleandWastageReport[0].DateFrom : string.Empty, false));
                parameters.Add(new ReportParameter("DateTo", InventorySaleandWastageReport.Count > 0 ? InventorySaleandWastageReport[0].DateTo : string.Empty, false));
                parameters.Add(new ReportParameter("GranularityName", InventorySaleandWastageReport.Count > 0 ? InventorySaleandWastageReport[0].GranularityName : string.Empty, false));
                parameters.Add(new ReportParameter("GeneralUnitsName", InventorySaleandWastageReport.Count > 0 ? InventorySaleandWastageReport[0].GeneralUnitsName : string.Empty, false));
               localReport.SetParameters(parameters);
                localReport.Refresh(); 
            }
       else if (DrillThroughValues[0].Name == "MarchandiseBaseCatgoryCode")
            {
                InventorySaleandWastageReport = controller.GetInventorySaleandWastageReportBySearch_ItemDescription(Convert.ToString(DrillThroughValues[0].Values[0].ToString()));
      
                /*Bind data source with report*/
                LocalReport localReport = (LocalReport)e.Report;
                localReport.DataSources.Clear();
                localReport.DataSources.Add(new ReportDataSource("InventorySaleandWastageDataSet5", InventorySaleandWastageReport));
                localReport.EnableHyperlinks = true;

                /*Add parameter to the report if report have paramerter*/
                List<ReportParameter> parameters = new List<ReportParameter>();
                parameters.Add(new ReportParameter("MarchandiseBaseCatgoryCode", DrillThroughValues[0].Values[0].ToString()));
                parameters.Add(new ReportParameter("DateFrom", InventorySaleandWastageReport.Count > 0 ? InventorySaleandWastageReport[0].DateFrom : string.Empty, false));
                parameters.Add(new ReportParameter("DateTo", InventorySaleandWastageReport.Count > 0 ? InventorySaleandWastageReport[0].DateTo : string.Empty, false));
                parameters.Add(new ReportParameter("GranularityName", InventorySaleandWastageReport.Count > 0 ? InventorySaleandWastageReport[0].GranularityName : string.Empty, false));
                parameters.Add(new ReportParameter("GeneralUnitsName", InventorySaleandWastageReport.Count > 0 ? InventorySaleandWastageReport[0].GeneralUnitsName : string.Empty, false));
               localReport.SetParameters(parameters);
                localReport.Refresh(); 
            }
        }
        
    </script>
</head>
<body>
    <form id="Form1" runat="server">
        <div id="MainDiv" runat="server">
            <div id="categoryPrint">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <rsweb:ReportViewer ID="rvInventorySaleandWastageReport" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="" SizeToReportContent="True">
                    <LocalReport ReportEmbeddedResource="AMS.Web.UI.Report.Inventory_1.InventorySaleandWastageReport.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="InventorySaleandWastageDataSet" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="DeveloperDBDataSet5TableAdapters.TBL_DaysOfCoverTableAdapter"></asp:ObjectDataSource>
            </div>
        </div>
        <div id="NoRecordDiv" runat="server" style="text-align: center;">
            <b>No Record Found</b>
        </div>
    </form>
</body>
</html>
