<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>


<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Inventory Item Price Report</title>
    <script runat="server">

        AERP.Web.UI.Controllers.PaymentOfBonusController controller = new AERP.Web.UI.Controllers.PaymentOfBonusController();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }
        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvPaymentOfBonus);
            if (!IsPostBack)
            {
                rvPaymentOfBonus.ProcessingMode = ProcessingMode.Local;
                List<AERP.DTO.PaymentOfBonus> PaymentOfBonus = null;
                List<AERP.DTO.OrganisationStudyCentreMaster> OrganisationStudyCentreMasterDetails = null;



                PaymentOfBonus = controller.GetPaymentOfBonusList();


                if (PaymentOfBonus == null)
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;
                    rvPaymentOfBonus.LocalReport.ReportPath = Server.MapPath("~/Report/Contract/PaymentOfBonus.rdlc");
                    rvPaymentOfBonus.LocalReport.DataSources.Clear();//collection Of Reports

                    ReportDataSource rdc = new ReportDataSource();
                    rdc.Name = "PaymentOfBonusDataSet1";//Data Set Name
                    rdc.Value = PaymentOfBonus;                //DTO object
                    rvPaymentOfBonus.LocalReport.DataSources.Add(rdc);

                    //ReportParameter[] param = new ReportParameter[8];
                    //param[0] = new ReportParameter("EmployeeName", PaymentOfBonus.Count > 0 ? PaymentOfBonus[0].EmployeeName : string.Empty, false);
                    //param[1] = new ReportParameter("CentreAdress", PaymentOfBonus.Count > 0 ? PaymentOfBonus[0].CentreAdress : string.Empty, false);
                    //param[2] = new ReportParameter("CentreName", PaymentOfBonus.Count > 0 ? PaymentOfBonus[0].CentreName : string.Empty, false);
                    //param[3] = new ReportParameter("EmployeeFathersFullName", PaymentOfBonus.Count > 0 ? PaymentOfBonus[0].EmployeeFathersFullName : string.Empty, false);
                    //param[4] = new ReportParameter("PFAccountNmber", PaymentOfBonus.Count > 0 ? PaymentOfBonus[0].PFAccountNmber : string.Empty, false);
                    //param[5] = new ReportParameter("RateOfContribution", PaymentOfBonus.Count > 0 ? Convert.ToString(PaymentOfBonus[0].RateOfContribution):  string.Empty, false);
                    //param[6] = new ReportParameter("FromDate", PaymentOfBonus.Count > 0 ? Convert.ToString(PaymentOfBonus[0].FromDate):  string.Empty, false);
                    //param[7] = new ReportParameter("UptoDate", PaymentOfBonus.Count > 0 ? Convert.ToString(PaymentOfBonus[0].UptoDate):  string.Empty, false);
                    //rvPaymentOfBonus.LocalReport.SetParameters(param);

                    rvPaymentOfBonus.LocalReport.Refresh();
                    rvPaymentOfBonus.Visible = true;
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

                <rsweb:ReportViewer ID="rvPaymentOfBonus" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="" SizeToReportContent="True">
                    <LocalReport ReportEmbeddedResource="AERP.Web.UI.Report.Contract.PaymentOfBonus.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="PaymentOfBonusDataSet1" />
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="StudyCentrePrintingFormat" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>

              
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="PaymentOfBonusListDataSet1TableAdapters.InventoryPaymentOfBonusListTableAdapter"></asp:ObjectDataSource>

            </div>

        </div>
        <div id="NoRecordDiv" runat="server" style="text-align: center;">

            <b>No Record Found</b>

        </div>
       
    </form>
</body>
</html>


