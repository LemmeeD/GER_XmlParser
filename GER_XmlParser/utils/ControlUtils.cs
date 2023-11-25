using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GER_XmlParser.utils
{
    class ControlUtils
    {
        // FIELDS
        // PROPERTIES

        // CONSTRUCTORS

        // METHODS
        public static void EnableAllChildControls(Control control, bool enable = true)
        {
            foreach (Control child in control.Controls)
            {
                child.Enabled = enable;
                EnableAllChildControls(child, enable);
            }
            return;
        }
    }
}
