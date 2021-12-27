Imports System

Namespace WebFormsDashboardConfigurator
	Partial Public Class [Default]
		Inherits System.Web.UI.Page

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			ASPxDashboard1.UseDashboardConfigurator = True
		End Sub
	End Class
End Namespace