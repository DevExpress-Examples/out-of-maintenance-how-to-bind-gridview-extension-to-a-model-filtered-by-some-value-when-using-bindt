Imports System.Web
Imports System.Data
Imports System.Data.OleDb
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.Web.ASPxEditors
Imports System.Collections
Imports DevExpress.Data.Linq
Imports DevExpress.Data.Linq.Helpers
Imports DevExpress.Data.Filtering
Imports DevExpress.Data.Filtering.Helpers


Public NotInheritable Class LargeDatabaseDataProvider
    Private Sub New()
    End Sub
    Shared m_db As LargeDatabaseDataContextDataContext
    Public Shared ReadOnly Property DB() As LargeDatabaseDataContextDataContext
        Get
            If m_db Is Nothing Then
                m_db = New LargeDatabaseDataContextDataContext()
            End If
            Return m_db
        End Get
    End Property
    Public Shared Function GetProducts() As IQueryable
        Return From product In DB.Products Select product
    End Function

    Public Shared Function GetColors() As IQueryable
        Dim source = (From product In DB.Products Group product By product.Color Into Group Select Group.FirstOrDefault)
        Return source
    End Function

    Public Shared Function GetProductsByFilter(colorName As Object) As IQueryable(Of Product)

        Dim source As IQueryable(Of Product) = From product In DB.Products Where product.Color.Equals(colorName)
                                               Select product
        Return source
    End Function

End Class
