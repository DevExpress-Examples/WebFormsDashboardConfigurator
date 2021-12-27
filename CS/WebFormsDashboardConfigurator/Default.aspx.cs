using System;

namespace WebFormsDashboardConfigurator {
    public partial class Default : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            ASPxDashboard1.UseDashboardConfigurator = true;
        }
    }
}