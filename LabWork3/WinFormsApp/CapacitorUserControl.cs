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
                    newCapacitor.Capacity = Convert.ToDouble(CapacityTextBox.Text);
                },
                () =>
                {
                    newCapacitor.Frequency = Convert.ToDouble(FrequencyTextBox.Text);
                }
            };

            InputParameters(actions);

            return newCapacitor;
        } 
    }
}
