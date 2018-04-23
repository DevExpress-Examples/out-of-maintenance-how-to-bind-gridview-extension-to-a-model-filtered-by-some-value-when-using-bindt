# How to bind GridView extension to a Model filtered by some value when using BindToLINQ


<p>When using server mode, all data operations are processed at the database level rather than at the GridView level. So, it is impossible to implement custom filtering when using the BindToLINQ method. At the same time, it is possible to assign a filter criteria to the GridView's QueryableSource before the GridView sends a request to a database. For this, do the following:</p><p>- In the BindToLINQ function, add the "where" statement to filter a grid;</p><p>- When a user submits a form or performs a callback to GridView, you can fill a Session by a value from Request.Params and use this Session in the "where" statement.</p><p>Here is a small example of using the BindToLINQ method: </p><br />


```cs
@Html.DevExpress().GridView(
    settings => {
        settings.Name = "grid";
        ...

    }).BindToLINQ(string.Empty, string.Empty, (s, e) => {
        e.QueryableSource = LargeDatabaseDataProvider.GetProductsByFilter(ViewData["CmbValue"]);
        e.KeyExpression = "ProductID";
}).GetHtml()

```



```vb
@Html.DevExpress().GridView( _
    Sub(settings)
            settings.Name = "grid"
             ...

    End Sub).BindToLINQ("", "", (Function(s, e)
                                        e.QueryableSource = VB.LargeDatabaseDataProvider.GetProductsByFilter(ViewData("CmbValue"))
                                        e.KeyExpression = "ProductID"
                                End Function)).GetHtml()  


```

<p><strong>See also:<br />
</strong><a href="http://msdn.microsoft.com/en-us/library/aa992075%28v=vs.80%29.aspx"><u>Walkthrough: Installing the AdventureWorks Database</u></a></p>

<br/>


