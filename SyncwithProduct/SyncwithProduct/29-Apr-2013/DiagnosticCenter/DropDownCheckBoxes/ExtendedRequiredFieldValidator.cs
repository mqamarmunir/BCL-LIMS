using System;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Saplin.Controls
{
    /// <summary>
    /// Extended required field validator to use with CheckBoxList control
    /// </summary>
    public class ExtendedRequiredFieldValidator : BaseValidator
    {
        protected override bool ControlPropertiesValid()
        {
            var control = FindControl(ControlToValidate);
            if (control != null)
            {
                var listControl = control as CheckBoxList;
                return (listControl != null);
            }
            
            return false;
        }

        protected override bool EvaluateIsValid()
        {
            return EvaluateIsChecked();
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            if (EnableClientScript) { this.ClientScript(); }

        }

        private void ClientScript()
        {
            var script = new StringBuilder();

            script.Append("<script language=\"javascript\">");
            script.Append("\r");
            script.Append("\r");
            script.Append("function cb_verify(sender) {");
            script.Append("\r");
            script.Append("var val = document.getElementById(document.getElementById(sender.id).controltovalidate);");
            script.Append("\r");
            script.Append("var col = val.getElementsByTagName(\"*\");");
            script.Append("\r");
            script.Append("if ( col != null ) {");
            script.Append("\r");
            script.Append("for ( i = 0; i < col.length; i++ ) {");
            script.Append("\r");
            script.Append("if (col.item(i).tagName == \"INPUT\") {");
            script.Append("\r");
            script.Append("if ( col.item(i).checked ) {");
            script.Append("\r");
            script.Append("\r");
            script.Append("return true;");
            script.Append("\r");
            script.Append("}");
            script.Append("\r");
            script.Append("}");
            script.Append("\r");
            script.Append("}");
            script.Append("\r");
            script.Append("\r");
            script.Append("\r");
            script.Append("return false;");
            script.Append("\r");
            script.Append("}");
            script.Append("\r");
            script.Append("}");
            script.Append("\r");
            script.Append("</script>");

            Page.ClientScript.RegisterClientScriptBlock(GetType(), "dropDownValidator", script.ToString());
            Page.ClientScript.RegisterExpandoAttribute(ClientID, "evaluationfunction", "cb_verify");
        }

        private bool EvaluateIsChecked()
        {
            var control = ((CheckBoxList)FindControl(ControlToValidate));

            return control.Items.Cast<ListItem>().Any(li => li.Selected);
        }
    }

}
