using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace WinFormsApp
{
    public partial class CapacitorUserControl : ElementBaseUserControl
    {
        public CapacitorUserControl()
        {
            InitializeComponent();
        }

        public override PassiveElementBase GetElement()
        {
            var newCapacitor = new Capacitor();

            var actions = new List<Action>()
            {
                () =>
                {
                    newCapacitor.Capacity = Convert.ToDouble(CapacityTextBox.Text.DotToComma());
                },
                () =>
                {
                    newCapacitor.Frequency = Convert.ToDouble(FrequencyTextBox.Text.DotToComma());
                }
            };

            InputParameters(actions);

            return newCapacitor;
        } 
    }
}
