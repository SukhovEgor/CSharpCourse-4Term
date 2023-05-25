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
    public partial class InductorCoilUserControl : ElementBaseUserControl
    {
        public InductorCoilUserControl()
        {
            InitializeComponent();
        }

        public override PassiveElementBase GetElement()
        {
            var newInductorCoil = new InductorCoil();

            var actions = new List<Action>()
            {
                () =>
                {
                    newInductorCoil.Inductance = Convert.ToDouble(InductanceTextBox.Text.DotToComma());
                },
                () =>
                {
                    newInductorCoil.Frequency = Convert.ToDouble(FrequencyTextBox.Text.DotToComma());
                }
            };

            InputParameters(actions);

            return newInductorCoil;
        }
    }
}
