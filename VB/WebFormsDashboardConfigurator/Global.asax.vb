Imports DevExpress.DashboardCommon
Imports DevExpress.DashboardWeb
Imports DevExpress.DataAccess.ConnectionParameters
Imports DevExpress.DataAccess.Excel
Imports DevExpress.DataAccess.Web
Imports System
Imports System.Web

Namespace WebFormsDashboardConfigurator
	Public Class [Global]
		Inherits System.Web.HttpApplication

		Protected Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
			DashboardConfigurator.Default.SetDashboardStorage(New DashboardFileStorage(Server.MapPath("App_Data/Dashboards")))
			DashboardConfigurator.Default.SetDataSourceStorage(CreateDataSourceStorage())
			DashboardConfigurator.Default.SetConnectionStringsProvider(New ConfigFileConnectionStringsProvider())
			AddHandler DashboardConfigurator.Default.ConfigureDataConnection, AddressOf Default_ConfigureDataConnection
		End Sub

		Public Function CreateDataSourceStorage() As DataSourceInMemoryStorage
			Dim dataSourceStorage As New DataSourceInMemoryStorage()

			' Registers an OLAP data source.
			Dim olapDataSource As New DashboardOlapDataSource("OLAP Data Source", "olapConnection")
			DashboardOlapDataSource.OlapDataProvider = OlapDataProviderType.Xmla
			dataSourceStorage.RegisterDataSource("olapDataSource", olapDataSource.SaveToXml())

			' Registers an Excel data source.
			Dim excelDataSource As New DashboardExcelDataSource("Excel Data Source")
			excelDataSource.SourceOptions = New ExcelSourceOptions(New ExcelWorksheetSettings("Sheet1"))
			dataSourceStorage.RegisterDataSource("excelDataSource", excelDataSource.SaveToXml())

			Return dataSourceStorage
		End Function

		Private Sub Default_ConfigureDataConnection(ByVal sender As Object, ByVal e As ConfigureDataConnectionWebEventArgs)
			If e.ConnectionName = "olapConnection" Then
				Dim olapParams As New OlapConnectionParameters()
				olapParams.ConnectionString = "Provider=MSOLAP;Data Source=http://demos.devexpress.com/Services/OLAP/msmdpump.dll;" & "Initial catalog=Adventure Works DW Standard Edition;Cube name=Adventure Works;Query Timeout=100;"
				e.ConnectionParameters = olapParams
			End If
			If e.DataSourceName = "Excel Data Source" Then
				Dim excelParams As New ExcelDataSourceConnectionParameters(HttpContext.Current.Server.MapPath("App_Data/Sales.xlsx"))
				e.ConnectionParameters = excelParams
			End If
		End Sub

		Protected Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)

		End Sub

		Protected Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)

		End Sub

		Protected Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)

		End Sub

		Protected Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)

		End Sub

		Protected Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)

		End Sub

		Protected Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)

		End Sub
	End Class
End Namespace