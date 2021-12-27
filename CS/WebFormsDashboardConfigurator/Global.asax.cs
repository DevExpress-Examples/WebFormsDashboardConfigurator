using DevExpress.DashboardCommon;
using DevExpress.DashboardWeb;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Excel;
using DevExpress.DataAccess.Web;
using System;
using System.Web;

namespace WebFormsDashboardConfigurator {
    public class Global : System.Web.HttpApplication {
        protected void Application_Start(object sender, EventArgs e) {
            ASPxDashboard.StaticInitialize();
            DashboardConfigurator.Default.SetDashboardStorage(new DashboardFileStorage(Server.MapPath("App_Data/Dashboards")));
            DashboardConfigurator.Default.SetDataSourceStorage(CreateDataSourceStorage());
            DashboardConfigurator.Default.SetConnectionStringsProvider(new ConfigFileConnectionStringsProvider());
            DashboardConfigurator.Default.ConfigureDataConnection += Default_ConfigureDataConnection;
        }

        public DataSourceInMemoryStorage CreateDataSourceStorage() {
            DataSourceInMemoryStorage dataSourceStorage = new DataSourceInMemoryStorage();

            // Registers an OLAP data source.
            DashboardOlapDataSource olapDataSource = new DashboardOlapDataSource("OLAP Data Source", "olapConnection");
            DashboardOlapDataSource.OlapDataProvider = OlapDataProviderType.Xmla;
            dataSourceStorage.RegisterDataSource("olapDataSource", olapDataSource.SaveToXml());

            // Registers an Excel data source.
            DashboardExcelDataSource excelDataSource = new DashboardExcelDataSource("Excel Data Source");
            excelDataSource.ConnectionName = "xlsSales";
            excelDataSource.SourceOptions = new ExcelSourceOptions(new ExcelWorksheetSettings("Sheet1"));
            dataSourceStorage.RegisterDataSource("excelDataSource", excelDataSource.SaveToXml());

            return dataSourceStorage;
        }

        private void Default_ConfigureDataConnection(object sender, ConfigureDataConnectionWebEventArgs e) {
            if (e.ConnectionName == "olapConnection") {
                OlapConnectionParameters olapParams = new OlapConnectionParameters();
                olapParams.ConnectionString = "Provider=MSOLAP;Data Source=http://demos.devexpress.com/Services/OLAP/msmdpump.dll;"
                    + "Initial catalog=Adventure Works DW Standard Edition;Cube name=Adventure Works;Query Timeout=100;";
                e.ConnectionParameters = olapParams;
            }
            if (e.ConnectionName == "xlsSales") {
                ExcelDataSourceConnectionParameters excelParams = new ExcelDataSourceConnectionParameters(HttpContext.Current.Server.MapPath("App_Data/Sales.xlsx"));
                e.ConnectionParameters = excelParams;
            }
        }

        protected void Session_Start(object sender, EventArgs e) {

        }

        protected void Application_BeginRequest(object sender, EventArgs e) {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e) {

        }

        protected void Application_Error(object sender, EventArgs e) {

        }

        protected void Session_End(object sender, EventArgs e) {

        }

        protected void Application_End(object sender, EventArgs e) {

        }
    }
}