@Html.DevExpress().GridView( _
    Sub(settings)
            settings.Name = "grid"
            settings.CallbackRouteValues = New With {.Controller = "Home", .Action = "DataBindingToLargeDatabasePartial"}

            settings.KeyFieldName = "ProductID"
            settings.Width = System.Web.UI.WebControls.Unit.Percentage(100)

            settings.Settings.ShowFilterRow = True
            settings.Settings.ShowFilterRowMenu = True
       

            settings.Columns.Add("Name")
            settings.Columns.Add("ProductNumber")
            settings.Columns.Add("StandardCost")
            settings.Columns.Add("Color")
            settings.Columns.Add("SafetyStockLevel")

  
            settings.ClientSideEvents.BeginCallback = "OnBeginCallback"
            
    End Sub).BindToLINQ("", "", (Function(s, e)
                                        e.QueryableSource = VB.LargeDatabaseDataProvider.GetProductsByFilter(ViewData("CmbValue"))
                                        e.KeyExpression = "ProductID"
                                End Function)).GetHtml() 
