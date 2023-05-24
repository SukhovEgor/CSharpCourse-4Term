using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    public abstract partial class ElementBaseUserControl : UserControl
    {
        public abstract PassiveElementBase GetElement();

        public void InputParameters(List<Action> actions)
        {
            foreach(var action in actions)
            {
                action.Invoke();
            }
        }
    }
}
