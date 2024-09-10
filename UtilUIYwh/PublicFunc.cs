using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UtilUIYwh
{
    public  class PublicFunc
    {
        public static void InitCombox(ComboBox box, Type type)
        {
            box.Items.Clear();
            foreach (var item in Enum.GetValues(type))
            {
                box.Items.Add(item.ToString());
            }
            box.SelectedIndex = 0;
        }
    }
}
