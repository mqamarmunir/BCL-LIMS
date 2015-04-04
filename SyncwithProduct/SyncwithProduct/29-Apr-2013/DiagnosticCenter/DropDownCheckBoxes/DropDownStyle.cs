// Copyright: Maxim Saplin 2010, 2011
// Under LGPL License

using System.Web.UI.WebControls;

namespace Saplin.Controls
{
    public class DropDownStyle : StateManagedComplexProperty
    {
        public string SelectBoxCssClass
        { 
            get
            {
                return ViewState["SelectBoxCssClass"] as string;
            }
            set
            {
                ViewState["SelectBoxCssClass"] = value;
            }
        }

        public string DropDownBoxCssClass
        {
            get
            {
                return ViewState["DropDownBoxCssClass"] as string;
            }
            set
            {
                ViewState["DropDownBoxCssClass"] = value;
            }
        }

        public Unit SelectBoxWidth
        {
            get
            {
                return (Unit)(ViewState["SelectBoxWidth"] ?? new Unit());
            }
            set
            {
                ViewState["SelectBoxWidth"] = value;
            }
        }

        public Unit DropDownBoxBoxWidth
        {
            get
            {
                return (Unit)(ViewState["DropDownBoxBoxWidth"] ?? new Unit());
            }
            set
            {
                ViewState["DropDownBoxBoxWidth"] = value;
            }
        }

        public Unit DropDownBoxBoxHeight
        {
            get
            {
                return (Unit)(ViewState["DropDownBoxBoxHeight"] ?? new Unit());
            }
            set
            {
                ViewState["DropDownBoxBoxHeight"] = value;
            }
        }
    }
}