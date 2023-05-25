using Model;

namespace WinFormsApp
{
    public partial class ResistorUserControl : ElementBaseUserControl
    {
        public ResistorUserControl()
        {
            InitializeComponent();
        }
        public override PassiveElementBase GetElement()
        {
            var newResistor = new Resistor();

            var actions = new List<Action>()
            {
                () =>
                {
                    newResistor.Resistance = Convert.ToDouble(ResistanceTextBox.Text.DotToComma());
                }
            };

            InputParameters(actions);

            return newResistor;
        }
    }
}
