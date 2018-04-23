<script type="text/javascript">
    function OnSelectedIndexChanged(s, e) {
        grid.Refresh();
    }

    function OnBeginCallback(s, e) {
        e.customArgs["cmbValue"] = cmb.GetValue();
    }
</script>
@Html.DevExpress().ComboBox( _
        Sub(cmbSettings)
                cmbSettings.Name = "cmb"
                 cmbSettings.Properties.ValueField = "Color"
                cmbSettings.Properties.TextField = "Color"
                cmbSettings.SelectedIndex = 2
                cmbSettings.Properties.ClientSideEvents.SelectedIndexChanged = "OnSelectedIndexChanged"
        End Sub).BindList(Model).GetHtml()

<br />
@Html.Partial("GridViewPartial")

