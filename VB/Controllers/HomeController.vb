Imports System.IO
Imports System.Web
Imports System.Web.Mvc
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraPrintingLinks
Imports DevExpress.Web.Mvc
Imports DevExpress.Web.ASPxGridView
Imports System.Data
Imports DevExpress.XtraReports.UI
Imports System.Collections.Generic
Imports DevExpress.Data.Filtering


Namespace CS.Controllers
    Public Class HomeController
        Inherits Controller
        Public Function Index() As ActionResult
            ViewData("CmbValue") = "Blue"
            Return View(LargeDatabaseDataProvider.GetColors())
        End Function

        Public Function DataBindingToLargeDatabasePartial() As ActionResult
            ViewData("CmbValue") = Request.Params("cmbValue")
            Return PartialView("GridViewPartial")
        End Function
    End Class

End Namespace
