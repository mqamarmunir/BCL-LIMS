// Copyright: Maxim Saplin 2010, 2011
// Under LGPL License

using System.ComponentModel;
using System.Web.UI;

namespace Saplin.Controls
{
    /// <summary>
    /// Controls specific texts of the DropDownCheckBoxes' elements
    /// </summary>
    public class DropDownTexts : StateManagedComplexProperty
    {
        private StateBag viewState;
        
        public DropDownTexts()
        {
            SelectBoxCaption = "Select";
            OkButton = "OK";
            CancelButton = "Cancel";
            SelectAllNode = "Select all";
        }
        
        /// <summary>
        /// Caption of the control
        /// </summary>
        [Localizable(true)]
        [DefaultValue("Select")]
        [NotifyParentProperty(true)]
        public string SelectBoxCaption
        {
            get
            {
                return ViewState["SelectBoxCaption"] as string;
            }
            set
            {
                ViewState["SelectBoxCaption"] = value;
            }
        }

        /// <summary>
        /// 'OK' button text
        /// </summary>
        [Localizable(true)]
        [DefaultValue("OK")]
        [NotifyParentProperty(true)]
        public string OkButton
        {
            get
            {
                return ViewState["OkButton"] as string;
            }
            set
            {
                ViewState["OkButton"] = value;
            }
        }

        /// <summary>
        /// 'Cancel' button text
        /// </summary>
        [Localizable(true)]
        [DefaultValue("Cancel")]
        [NotifyParentProperty(true)]
        public string CancelButton
        {
            get
            {
                return ViewState["CancelButton"] as string;
            }
            set
            {
                ViewState["CancelButton"] = value;
            }
        }


        /// <summary>
        /// 'Select all' node (check box) text
        /// </summary>
        [Localizable(true)]
        [DefaultValue("Select All")]
        [NotifyParentProperty(true)]
        public string SelectAllNode
        {
            get
            {
                return ViewState["SelectAllNode"] as string;
            }
            set
            {
                ViewState["SelectAllNode"] = value;
            }
        }

    }
}
